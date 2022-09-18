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

public partial class CreateGame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Role"] == null || Session["Role"].ToString() != "ADMIN")
        {
            Response.Redirect("../LoginRegister.aspx");
        }

        if (!Page.IsPostBack)
        {
            populateGamePlatform();
        }
    }

    protected void CreateGameFunction(object sender, EventArgs e)
    {
        if (!GameImage.HasFile)
        {
            Label3.Text = "Please Choose An Image!";
            return;
        }

        try
        {
            string extension = Path.GetExtension(GameImage.FileName);

            // check Image Size
            if(GameImage.PostedFile.ContentLength >= 1024000)
            {
                Label3.Text = "Image Size Too Large! Please Upload Another";
                return;
            }

            // check if game already exists
            if ( GameAccess.DoesGameImageExist(GameImage.FileName) || GameAccess.DoesGameNameExist(GameNameTXT.Text))
            {
                Label3.Text = "Game Already Exists!";
                return;
            }
                

            // check extension
            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
            {
                string name = GameNameTXT.Text;
                string image = GameImage.FileName;
                string genre = GameGenresTXT.Text;
                string description = Request.Form["GameDescriptionTXT"];

                // insert game into DB
                GameAccess.InsertGame(new Game() { Name = name, Image = image, Genre = genre, Description = description });
                
                int gameID = GameAccess.getGameIdFromName(name);
                float platformPrice = float.Parse(PlatformPrice.Text);

                //for each selected item in the checkbox
                foreach (ListItem item in PlatformCheckbox.Items)
                {
                    if (item.Selected)
                    {
                        int platformID = int.Parse(item.Value);
                        PlatformAccess.InsertGamePlatform(gameID, platformID, platformPrice);
                    }
                }

                // save image
                string filename = Path.GetFileName(GameImage.FileName);
                GameImage.SaveAs(Server.MapPath("/GameImages/" + filename));

                Response.Redirect("updateSingleGame.aspx?id=" + gameID);
            } else
            {
                Label3.Text = "Only PNG, JPG and JPEG Are Accepted! You Chose: <b>" + extension + "</b>";
                return;
            }
        } catch (Exception ex)
        {
            Response.Write(ex);
        }

    }

    private void populateGamePlatform()
    {
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from platforms";
            cmd.Connection = conn;
            conn.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    ListItem item = new ListItem();
                    item.Text = sdr["name"].ToString();
                    item.Value = sdr["id"].ToString();
                    PlatformCheckbox.Items.Add(item);
                }
            }
        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminDashboard.aspx");
    }
}