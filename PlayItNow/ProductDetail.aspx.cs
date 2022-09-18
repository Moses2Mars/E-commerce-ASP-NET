using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProductDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            

            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("ProductList.aspx");
                return;
            }
            
            int gameId = int.Parse(Request.QueryString["id"]);

            Game game = GameAccess.getGameFromId(gameId);

            GameName.Text = game.Name;
            GameDescription.Text = game.Description;
            GameGenre.Text = game.Genre;
            GameImage.ImageUrl = "./GameImages/" + game.Image;

            OtherGamesRepeater.DataSource = GameAccess.getLimitedNewGames();
            OtherGamesRepeater.DataBind();

            PlatformPrice.DataSource = PlatformAccess.getGameWithAllPlatforms(int.Parse(Request.QueryString["id"]));
            PlatformPrice.DataBind();

            gameOwnerCount.Text = GameOwnershipAccess.getGameOwnershipCountForGame(gameId).ToString();
            wishlistCount.Text = WishlistAccess.getWishlistCountForGame(gameId).ToString();
            cartCount.Text = CartAccess.getCartCountForGame(gameId).ToString();

        }
    }

    protected void addToCart_Click(object sender, EventArgs e)
    {
        if(Session["ID"] == null)
        {
            Response.Redirect("LoginRegister.aspx");
            return;
        }
        Button btn = (Button)sender;

        int userId = int.Parse(Session["ID"].ToString());
        int gameId = int.Parse(Request.QueryString["id"]);
        int platformId = int.Parse(btn.CommandArgument.ToString());

        if(CartAccess.doesUserHaveGameInCart(userId, gameId, platformId))
        {
            handler.Text = "Game Is Already In Your Cart!";
            return;
        }

        if(GameOwnershipAccess.doesUserOwnGame(userId, gameId, platformId))
        {
            handler.Text = "You Already Own This Game!";
            return;
        }

        try
        {
            CartAccess.InsertGameIntoCart(userId, gameId, platformId);
            Response.Redirect("Cart.aspx");
        }catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
       

    }

    protected void buyNow_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
        {
            Response.Redirect("LoginRegister.aspx");
            return;
        }

        User user = UserAccess.GetUser(Session["Username"].ToString());

        Button btn = (Button)sender;
        string info = btn.CommandArgument.ToString();
        string[] args = new string[2];
        char[] splitter = { ';' };
        args = info.Split(splitter);

        int userId = int.Parse(Session["ID"].ToString());
        int gameId = int.Parse(Request.QueryString["id"]);
        int platformId = int.Parse(args[0]);
        double price = double.Parse(args[1]);
        double grandTotal = ((price * 0.05) + price);

        if(grandTotal > user.Wallet)
        {
            handler.Text = "Not Enough Funds In Your Wallet!";
            return;
        }

        if (CartAccess.doesUserHaveGameInCart(userId, gameId, platformId))
        {
            handler.Text = "Game Is Already In Your Cart!";
            return;
        }

        if (GameOwnershipAccess.doesUserOwnGame(userId, gameId, platformId))
        {
            handler.Text = "You Already Own This Game!";
            return;
        }

        if (WishlistAccess.doesUserHaveGameInWishlist(userId, gameId, platformId))
        {
            WishlistAccess.DeleteGameFromWishlist(userId, gameId, platformId);
        }

        GameOwnershipAccess.InsertSingleGameOwnership(userId, gameId, platformId);
        Response.Redirect("MyAccount.aspx");


    }

    protected void addWishlist_Click(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
        {
            Response.Redirect("LoginRegister.aspx");
            return;
        }
        Button btn = (Button)sender;
        string info = btn.CommandArgument.ToString();

        int userId = int.Parse(Session["ID"].ToString());
        int gameId = int.Parse(Request.QueryString["id"]);
        int platformId = int.Parse(info);

        if (CartAccess.doesUserHaveGameInCart(userId, gameId, platformId))
        {
            handler.Text = "Game Is Already In Your Cart!";
            return;
        }
        
        if (GameOwnershipAccess.doesUserOwnGame(userId, gameId, platformId))
        {
            handler.Text = "You Already Own This Game!";
            return;
        }

        if (WishlistAccess.doesUserHaveGameInWishlist(userId, gameId, platformId))
        {
            handler.Text = "You Already Have This Game In Your Wishlist!";
            return;
        }

        WishlistAccess.InsertGameIntoWishlist(userId, gameId, platformId);
        Response.Redirect("Wishlist.aspx");
    }
}