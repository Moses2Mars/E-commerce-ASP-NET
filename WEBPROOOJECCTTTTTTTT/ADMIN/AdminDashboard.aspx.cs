using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ADMIN_AdminDashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Role"] == null || Session["Role"].ToString() != "ADMIN")
        {
            Response.Redirect("../LoginRegister.aspx");
        }
    }

    protected void createGame_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreateGame.aspx");
    }

    protected void updateGame_Click(object sender, EventArgs e)
    {
        Response.Redirect("UpdateGame.aspx");
    }

    protected void createPlatform_Click(object sender, EventArgs e)
    {
        Response.Redirect("CreatePlatform.aspx");
    }

    protected void browse_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Home.aspx");
    }
}