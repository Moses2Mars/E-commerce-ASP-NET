using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartAccess
/// </summary>
public class CartAccess
{
    public CartAccess()
    {

    }

    public static void InsertGameIntoCart(int userId, int gameId, int platformId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO [cart] (user_id, game_id, platform_id) VALUES (@USERID, @GAMEID, @PLATID)", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@USERID", userId));
            command.Parameters.Add(new SqlParameter("@GAMEID", gameId));
            command.Parameters.Add(new SqlParameter("@PLATID", platformId));

            // non query is anything that is not a select
            command.ExecuteNonQuery();
        }
    }

    public static bool doesUserHaveGameInCart(int userId, int gameId, int platformId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT 1 FROM [cart] WHERE user_id = @USERID AND game_id = @GAMEID and platform_id = @PLATFORMID", connection);
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

    public static void RemoveGameFromCart(int userId, int gameId, int platformId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM [cart] WHERE user_id = @USERID AND game_id = @GAMEID AND platform_id = @PLATID", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@USERID", userId));
            command.Parameters.Add(new SqlParameter("@GAMEID", gameId));
            command.Parameters.Add(new SqlParameter("@PLATID", platformId));

            // non query is anything that is not a select
            command.ExecuteNonQuery();
        }
    }

    public static void checkOut(int userId)
    {
        foreach (DataRow dr in CartAccess.getAllCartGamesForUser(userId).Tables[0].Rows)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM [cart] WHERE user_id = @USERID AND game_id = @GAMEID AND platform_id = @PLATID", connection);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(new SqlParameter("@USERID", userId));
                command.Parameters.Add(new SqlParameter("@GAMEID", dr["GameId"]));
                command.Parameters.Add(new SqlParameter("@PLATID", dr["PlatformId"]));

                // non query is anything that is not a select
                command.ExecuteNonQuery();
            }
        }
    }

    public static DataSet getAllCartGamesForUser(int userId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT C.user_id, G.Name as 'GameName', G.Image, G.Id as 'GameId', GP.Price, P.Id as 'PlatformId', P.Name as 'PlatformName' FROM [games] AS G INNER JOIN [cart] AS C ON G.Id = C.game_id INNER JOIN [platforms] AS P ON C.platform_id = P.Id INNER JOIN [game_platforms] AS GP ON G.Id = GP.game_id AND P.Id = GP.platform_id WHERE C.user_id = @USERID", connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter("@USERID", userId));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static double getSubTotal(int userId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT SUM(GP.Price) AS SUBTOTAL FROM [game_platforms] AS GP INNER JOIN [cart] as C ON GP.game_id = C.game_id AND GP.platform_id = C.platform_id AND C.user_id = @USERID", connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter("@USERID", userId));

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            // 1 user ya3ne 1 row
            var rows = ds.Tables[0].Rows;
            //if rows = 1 fetch these info
            var datag = rows[0];

            try
            {
                return (double)datag["subtotal"];
            }catch (Exception ex)
            {
                return 0;
            }
        }
    }

    public static int getCartCount(int userId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(user_id) AS COUNT FROM [CART] WHERE user_id = @USERID", connection);
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

    public static int getCartCountForGame(int gameId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(DISTINCT(user_id)) AS COUNT FROM [cart] WHERE game_id = @GAMEID", connection);
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