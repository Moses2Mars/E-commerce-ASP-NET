using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GameOwnershipAccess
/// </summary>
public class GameOwnershipAccess
{
    public GameOwnershipAccess()
    {

    }

    public static void InsertGameOwnership(int userId)
    {
        foreach(DataRow dr in CartAccess.getAllCartGamesForUser(userId).Tables[0].Rows)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [game_ownership] (game_id, platform_id, user_id) VALUES (@GAMEID, @PLATFORMID, @USERID)", connection);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(new SqlParameter("@GAMEID", dr["GameId"]));
                command.Parameters.Add(new SqlParameter("@PLATFORMID", dr["PlatformId"]));
                command.Parameters.Add(new SqlParameter("@USERID", userId));
                // non query is anything that is not a select
                command.ExecuteNonQuery();

            }
        }
    }

    public static void InsertSingleGameOwnership(int userId, int gameId, int platformId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO [game_ownership] (game_id, platform_id, user_id) VALUES (@GAMEID, @PLATFORMID, @USERID)", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@GAMEID", gameId));
            command.Parameters.Add(new SqlParameter("@PLATFORMID", platformId));
            command.Parameters.Add(new SqlParameter("@USERID", userId));
            // non query is anything that is not a select
            command.ExecuteNonQuery();

        }
    }

    public static int getGameOwnershipCountForGame(int gameId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(DISTINCT(user_id)) AS COUNT FROM [game_ownership] WHERE game_id = @GAMEID", connection);
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

    public static DataSet getAllGamesForUser(int userId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT GO.user_id, G.Name as 'GameName', G.Image, G.Id as 'GameId', GP.Price, P.Id as 'PlatformId', P.Name as 'PlatformName' FROM [games] AS G INNER JOIN [game_ownership] AS GO ON G.Id = GO.game_id INNER JOIN [platforms] AS P ON GO.platform_id = P.Id INNER JOIN [game_platforms] AS GP ON G.Id = GP.game_id AND P.Id = GP.platform_id WHERE GO.user_id = @USERID", connection);
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter("@USERID", userId));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static bool doesUserOwnGame(int userId, int gameId, int platformId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT 1 FROM [game_ownership] WHERE user_id = @USERID AND game_id = @GAMEID and platform_id = @PLATFORMID", connection);
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
}