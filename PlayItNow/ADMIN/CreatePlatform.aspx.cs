using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

public partial class CreatePlatform : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Role"] == null || Session["Role"].ToString() != "ADMIN")
        {
            Response.Redirect("../LoginRegister.aspx");
        }

        if (!Page.IsPostBack)
        {

        }
    }

    protected void CreatePlatformFunction(object sender, EventArgs e)
    {
        if (!PlatformImage.HasFile)
        {
            Label3.Text = "Please Choose An Image!";
            return;
        }

        try
        {
            string extension = Path.GetExtension(PlatformImage.FileName);

            // check Image Size
            if (PlatformImage.PostedFile.ContentLength >= 1024000)
            {
                Label3.Text = "Image Size Too Large! Please Upload Another";
                return;
            }

            // check if game already exists
            if (PlatformAccess.DoesPlatformImageExist(PlatformImage.FileName) || PlatformAccess.DoesPlatformNameExist(PlatformNameTXT.Text))
            {
                Label3.Text = "Game Already Exists!";
                return;
            }


            // check extension
            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg" || extension == ".svg")
            {
                string name = PlatformNameTXT.Text;
                string image = PlatformImage.FileName;

                // insert game into DB
                PlatformAccess.InsertPlatform(new Platform() { Name = name, Image = image });

                // save image
                string filename = Path.GetFileName(PlatformImage.FileName);
                PlatformImage.SaveAs(Server.MapPath("/PlatformImages/" + filename));

                Label3.Text = "Platform Created Successfully!";
            }
            else
            {
                Label3.Text = "Only PNG, JPG and JPEG Are Accepted! You Chose: <b>" + extension + "</b>";
                return;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }

    }

    protected void bcktoDash_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashboard.aspx");
    }
}