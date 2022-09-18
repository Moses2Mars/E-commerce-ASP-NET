using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LoginRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session.Abandon();
            return;
        }
    }

    protected void RegisterUser(object sender, EventArgs e)
    {
        //if everything is valid lets continue else no
        Page.Validate("Group1");

        if (!Page.IsValid) return;

        // get values
        string username = usernameTXT.Text;
        string email = emailTXT.Text;
        string password = passwordTXT.Text;
        string role = "Gamer";

        // if user doesnt exist, register and login
        if (!UserAccess.IsUserExists(username))
        {
            UserAccess.InsertUser(new User() { Username = username, Email = email, Password = password, Role = role });
            User user = UserAccess.GetUser(username);

            Session["ID"] = user.Id;
            Session["Username"] = user.Username;
            Session["Role"] = user.Role;

            if (user.Role == "Game Publisher")
                Response.Redirect("CreateGame.aspx");
            else
            {
                Response.Redirect("Home.aspx");
            }
        }
    }

    protected void UserExistsValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //if the user doesnt exists this means it is valid
        string username = usernameTXT.Text;
        args.IsValid = !UserAccess.IsUserExists(username);
    }

    protected void Login(object sender, EventArgs e)
    {
        Page.Validate("Group2");
        if (!Page.IsValid)
        {
            return;
        }


        string username = LoginUsernameTXT.Text;
        string password = LoginPasswordTXT.Text;

        if (UserAccess.ValidateUserCredentials(username, password))
        {
            //get role for the user
            User user = UserAccess.GetUser(username);
            Session["ID"] = user.Id;
            Session["Username"] = user.Username;
            Session["Role"] = user.Role;

            if (user.Role == "ADMIN")
                Response.Redirect("/ADMIN/AdminDashboard.aspx");
            else
            {
                Response.Redirect("Home.aspx");
            }

        } else
        {
            handler.Text = "Username/Password are incorrect!";
        }
    }
}
