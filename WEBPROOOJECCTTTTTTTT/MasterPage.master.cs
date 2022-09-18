using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ID"] != null && Session["Username"] != null)
        {
            loginRegister.Visible = false;
            showUsername.Visible = true;
            showUsername.InnerHtml = "Welcome " + (string)Session["Username"].ToString();
            cartCount.Text = CartAccess.getCartCount(int.Parse(Session["ID"].ToString())).ToString();
            wishlistCount.Text = WishlistAccess.getWishlistCount(int.Parse(Session["ID"].ToString())).ToString();
        } else
        {
            loginRegister.Visible = true;
            showUsername.Visible = false;
            cartCount.Text = "0";
            wishlistCount.Text = "0";
        }
        
    }
}
