using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MyAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["ID"] == null)
                Response.Redirect("LoginRegister.aspx");

            adminBTN.Visible = false;

            if (Session["Role"].ToString() == "ADMIN")
            {
                adminBTN.Visible = true;
            }

            

            User user = UserAccess.GetUser(Session["Username"].ToString());
            username.Text = user.Username;
            email.Text = user.Email;
            dateRegistered.Text = user.DateRegistered.ToString();
            walletAmount.Text = user.Wallet.ToString();

            gamesInLibraryRepeater.DataSource = GameOwnershipAccess.getAllGamesForUser(int.Parse(Session["ID"].ToString()));
            gamesInLibraryRepeater.DataBind();
        } 
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        //add money to wallet
        UserAccess.updateWallet(int.Parse(Session["ID"].ToString()));
        Response.Redirect(Request.RawUrl);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //logout button
        Session.Abandon();
        Response.Redirect("Home.aspx");
    }

    protected void Button_Click(object sender, EventArgs e)
    {
        //update account

        string usern = username.Text;
        string emailn = email.Text;
        string passn = oldpassword.Text;

        if(usern.Trim().Length == 0 || emailn.Trim().Length == 0)
        {
            handler1.Text = "Missing Fields Detected!";
            return;
        }

        if(!UserAccess.ValidateUserCredentials(Session["Username"].ToString(), passn))
        {
            handler1.Text = "Incorrect Password!";
            return;
        }
        try
        {
            UserAccess.updateUsernameAndEmail(int.Parse(Session["ID"].ToString()), usern, emailn);
            Session["Username"] = usern;
            Response.Redirect(Request.RawUrl);
        }catch(Exception ex)
        {
            Response.Write(ex.ToString());
        }
        

    }

    protected void saveNewPassword_Click(object sender, EventArgs e)
    {
        //handler2
        if (!UserAccess.ValidateUserCredentials(Session["Username"].ToString(), currentpassword.Text))
        {
            handler2.Text = "Incorrect Password!";
            return;
        }
        string newpass = newpassword.Text;
        string confirmpass = confirmpassword.Text;

        if(newpass != confirmpass)
        {
            handler2.Text = "Passwords Do Not Match!";
            return;
        }

        UserAccess.updatePassword(int.Parse(Session["ID"].ToString()), newpass);
        handler2.Text = "Password Updated Successfully!";

        newpassword.Text = confirmpassword.Text = currentpassword.Text = "";
    }

    protected void trashBtn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Do You Want To Open The Game Using "+ btn.CommandArgument.ToString()+" Platform? ')", true);
    }

    protected void adminBTN_Click(object sender, EventArgs e)
    {
        Response.Redirect("/ADMIN/AdminDashboard.aspx");
    }
}