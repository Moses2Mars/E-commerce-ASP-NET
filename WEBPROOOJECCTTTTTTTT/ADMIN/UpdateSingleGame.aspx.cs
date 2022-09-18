using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ADMIN_UpdateSingleGame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Role"] == null || Session["Role"].ToString() != "ADMIN")
        {
            Response.Redirect("../LoginRegister.aspx");
        }
        if(!Page.IsPostBack) { 
            int id = int.Parse(Request.QueryString["id"]);
            Game game = GameAccess.getGameFromId(id);
            gameImage.ImageUrl = "../GameImages/"+game.Image;
            gameName.Text = game.Name;


            GameRepeater.DataSource = PlatformAccess.getGameNameWithAllPlatforms(id);
            GameRepeater.DataBind();
        }
    }

    protected void returnToDashboard_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashboard.aspx");
    }

    protected void editGameName_Click(object sender, EventArgs e)
    {
        string gName = gameName.Text;

        if(gName.Trim().Length== 0 )
        {
            gamenameHandler.Text = "Invalid Name!";
            return;
        }

        int id = int.Parse(Request.QueryString["id"]);

        GameAccess.updateGameName(gName, id);
        gamenameHandler.Text = "Game Name Updated Successfully!";

    }

    protected void editPlatPrice_Click(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        RepeaterItem item = (RepeaterItem)b.NamingContainer;

        TextBox gamePrice = (TextBox)GameRepeater.Items[item.ItemIndex].FindControl("gamePrice");
        TextBox gameDiscount = (TextBox)GameRepeater.Items[item.ItemIndex].FindControl("discountAmount");

        float price = float.Parse(gamePrice.Text);
        float discount = float.Parse(gameDiscount.Text);

        if(price < 0)
        {
            generalErrorHandler.Text = "Invalid Price!";
            return;
        }

        if(discount < 0 || discount >= 100 )
        {
            generalErrorHandler.Text = "Invalid Discount Amount!";
            return;
        }

        int platformId = int.Parse(b.CommandArgument.ToString());
        int gameId = int.Parse(Request.QueryString["id"]);

        PlatformAccess.UpdateGamePlatformPrice(gameId, platformId, price, discount);
        generalErrorHandler.Text = "Updated Successfully!";

    }
}