using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Wishlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        if (!Page.IsPostBack)
        {
            gamesInWishlistRepeater.DataSource = WishlistAccess.getAllGamesForUserFromWishlist(int.Parse(Session["ID"].ToString()));
            gamesInWishlistRepeater.DataBind();
        }
       
    }

    protected void trashBtn_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        string info = btn.CommandArgument.ToString();
        string[] args = new string[2];
        char[] splitter = { ';' };
        args = info.Split(splitter);

        int gameId = int.Parse(args[0]);
        int platformId = int.Parse(args[1]);
        int userid = int.Parse(Session["ID"].ToString());

        WishlistAccess.DeleteGameFromWishlist(userid, gameId, platformId);
        Response.Redirect(Request.RawUrl);
    }

    protected void addToCart_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        string info = btn.CommandArgument.ToString();
        string[] args = new string[2];
        char[] splitter = { ';' };
        args = info.Split(splitter);

        int gameId = int.Parse(args[0]);
        int platformId = int.Parse(args[1]);
        int userid = int.Parse(Session["ID"].ToString());

        WishlistAccess.DeleteGameFromWishlist(userid, gameId,platformId);
        CartAccess.InsertGameIntoCart(userid,gameId,platformId);

        Response.Redirect(Request.RawUrl);
    }
}