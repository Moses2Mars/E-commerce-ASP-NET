using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WishlistAccess
/// </summary>
public class WishlistAccess
{
    public WishlistAccess()
    {

    }

    public static void InsertGameIntoWishlist(int userId, int gameId, int platformId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO [wishlist] (user_id, game_id, platform_id) VALUES (@USERID, @GAMEID, @PLATID)", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@USERID", userId));
            command.Parameters.Add(new SqlParameter("@GAMEID", gameId));
            command.Parameters.Add(new SqlParameter("@PLATID", platformId));

            // non query is anything that is not a select
            command.ExecuteNonQuery();
        }
    }

    public static void DeleteGameFromWishlist(int userId, int gameId, int platformId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM [wishlist] WHERE user_id = @USERID AND game_id = @GAMEID AND platform_id = @PLATID", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@USERID", userId));
            command.Parameters.Add(new SqlParameter("@GAMEID", gameId));
            command.Parameters.Add(new SqlParameter("@PLATID", platformId));

            // non query is anything that is not a select
            command.ExecuteNonQuery();
        }
    }

    public static DataSet getAllGamesForUserFromWishlist(int userId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT G.Name as 'GameName', G.Image, G.Id as 'GameId', GP.Price, P.Id as 'PlatformId', P.Name as 'PlatformName' FROM [games] AS G INNER JOIN [wishlist] AS W ON G.Id = W.game_id INNER JOIN [platforms] AS P ON W.platform_id = P.Id INNER JOIN [game_platforms] AS GP ON G.Id = GP.game_id AND P.Id = GP.platform_id WHERE W.user_id = @USERID", connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter("@USERID", userId));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static bool doesUserHaveGameInWishlist(int userId, int gameId, int platformId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT 1 FROM [wishlist] WHERE user_id = @USERID AND game_id = @GAMEID and platform_id = @PLATFORMID", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@USERID", userId));
            command.Parameters.Add(new SqlParameter("@GAMEID", gameId));
            command.Parameters.Add(new SqlParameter("@PLATFORMID", platformId));

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            return ds.Tables[0].Rows.Count == 1;
        }
    }

    public static int getWishlistCount(int userId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(user_id) AS COUNT FROM [wishlist] WHERE user_id = @USERID", connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter("@USERID", userId));

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            // 1 user ya3ne 1 row
            var rows = ds.Tables[0].Rows;
            //if rows = 1 fetch these info
            var datag = rows[0];

            int dbCount = (int)datag["COUNT"];


            return dbCount;
        }
    }

    public static int getWishlistCountForGame(int gameId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(DISTINCT(user_id)) AS COUNT FROM [wishlist] WHERE game_id = @GAMEID", connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter("@GAMEID", gameId));

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            // 1 user ya3ne 1 row
            var rows = ds.Tables[0].Rows;
            //if rows = 1 fetch these info
            var datag = rows[0];

            int dbCount = (int)datag["COUNT"];


            return dbCount;
        }
    }
}