using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class ProductList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            string query = "";

            if (Request.QueryString["query"] != null)
            {
                query = Request.QueryString["query"];

                if(Request.QueryString["platform"] == null)
                {
                    if (query == "Free")
                    {
                        GameRepeater.DataSource = GameAccess.getAllFreeGames();
                        GameRepeater.DataBind();
                    }
                    else if (query == "TopSelling")
                    {
                        GameRepeater.DataSource = GameAccess.getTopSellingGames();
                        GameRepeater.DataBind();
                    }
                    else if (query == "OnSale")
                    {
                        GameRepeater.DataSource = GameAccess.getAllDiscountedGames();
                        GameRepeater.DataBind();
                    }
                    else if (query == "New")
                    {
                        //******************
                        GameRepeater.DataSource = GameAccess.getNewGames();
                        GameRepeater.DataBind();
                    }
                }else
                {
                    string platform = Request.QueryString["platform"];
                    int platformId = PlatformAccess.getPlatformIdFromName(platform);

                    if (query == "Free")
                    {
                        GameRepeater.DataSource = GameAccess.getAllFreeGamesFromPlatform(platformId);
                        GameRepeater.DataBind();
                    }
                    else if (query == "TopSelling")
                    {
                        GameRepeater.DataSource = GameAccess.getTopSellingGamesFromPlatform(platformId);
                        GameRepeater.DataBind();
                    }
                    else if (query == "OnSale")
                    {
                        GameRepeater.DataSource = GameAccess.getAllDiscountedGamesFromPlatform(platformId);
                        GameRepeater.DataBind();
                    }
                    else if (query == "New")
                    {
                        GameRepeater.DataSource = GameAccess.getNewGamesFromPlatform(platformId);
                        GameRepeater.DataBind();
                    }
                }

                
            }
            else
            {
                if (Request.QueryString["platform"] == null)
                {
                    System.Diagnostics.Debug.WriteLine("in here");
                    GameRepeater.DataSource = GameAccess.getAllGames();
                    GameRepeater.DataBind();
                } else
                {
                    string platform = Request.QueryString["platform"];
                    Response.Write("platform: "+platform);
                    int platformId = PlatformAccess.getPlatformIdFromName(platform);
                    GameRepeater.DataSource = GameAccess.getAllGamesFromPlatform(platformId);
                    GameRepeater.DataBind();
                }
            }

            platformRepeater.DataSource= PlatformAccess.getAllPlatformsWithGameCount();
            platformRepeater.DataBind();
        
            
    }

    protected void routeToGenre_Click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        string platform = btn.CommandArgument.ToString();
        string url = Request.Url.AbsoluteUri;
        if (Request.QueryString["query"] != null)
        {
            
            string[] splitUrl = url.Split(new[] { "&platform=" }, StringSplitOptions.None);
            string newUrl = splitUrl[0] + "&platform=" + platform.Replace(" ", "");

            Response.Redirect(newUrl);
        } else
        {
            string[] splitUrl = url.Split(new[] { "?platform=" }, StringSplitOptions.None);
            string newUrl = splitUrl[0] + "?platform=" + platform.Replace(" ", "");
            Response.Redirect(newUrl);
        }
    }
}