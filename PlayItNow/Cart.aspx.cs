using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["ID"] == null)
        {
            Response.Redirect("LoginRegister.aspx");
            return;
        }

        int userid = int.Parse(Session["ID"].ToString());
        gamesInCartRepeater.DataSource = CartAccess.getAllCartGamesForUser(userid);
        gamesInCartRepeater.DataBind();

        double subTot = CartAccess.getSubTotal(userid);
        subTotal.Text = subTot.ToString();
        grandTotal.Text = (( subTot*0.05 ) + subTot ).ToString();
        austDiscount.Visible = false;
    }

    protected void trashBtn_Click(object sender, EventArgs e)
    {
        //remove game from cart
        LinkButton btn = (LinkButton)sender;
        string info = btn.CommandArgument.ToString();
        string[] args = new string[2];
        char[] splitter = { ';' };
        args = info.Split(splitter);

        int gameId = int.Parse(args[0]);
        int platformId = int.Parse(args[1]);
        int userid = int.Parse(Session["ID"].ToString());

        CartAccess.RemoveGameFromCart(userid, gameId, platformId);
        Response.Redirect(Request.RawUrl);
    }

    protected void refreshCart_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void checkOut_Click(object sender, EventArgs e)
    {
        //first check user's wallet
        User user = UserAccess.GetUser(Session["Username"].ToString());
        double wallet = user.Wallet;

        //next check how much the grandTotal is
        double grandTot = double.Parse(grandTotal.Text);

        // check if possible
        if(grandTot > wallet)
        {
            handler.Text = "Not Enough Funds In Your Wallet! Please Add Money And Come Back";
            return;
        }

        double newWallet = wallet - grandTot;

        int userid = int.Parse(Session["ID"].ToString());
        //update user wallet
        UserAccess.updateWalletWithGrandTotal(int.Parse(Session["ID"].ToString()), newWallet);
        // add reference to table game ownerships
        GameOwnershipAccess.InsertGameOwnership(userid);

        //remove references from cart table
        CartAccess.checkOut(userid);

        Response.Redirect(Request.RawUrl);

    }

    protected void couponBTN_Click(object sender, EventArgs e)
    {
        string coupon = couponCode.Text;

        if (coupon != "AUST")
            return;

        double grandTot = double.Parse(grandTotal.Text);
        grandTotal.Text = (grandTot - (grandTot *0.5)).ToString();

        couponBTN.Enabled = false;
        austDiscount.Visible = true;

    }
}