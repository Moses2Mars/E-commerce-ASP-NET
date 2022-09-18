using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PlatformAccess
/// </summary>
public class PlatformAccess
{
    public PlatformAccess()
    {

    }

    public static void InsertPlatform(Platform platform)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO [platforms] (name, image) VALUES (@NAME, @IMAGE)", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@NAME", platform.Name));
            command.Parameters.Add(new SqlParameter("@IMAGE", platform.Image));
            // non query is anything that is not a select
            command.ExecuteNonQuery();

        }
    }

    public static void InsertGamePlatform(int game_id, int platform_id, float price)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO [game_platforms] (game_id, platform_id, price) VALUES (@GAMEID, @PLATFORMID, @PRICE)", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@GAMEID", game_id));
            command.Parameters.Add(new SqlParameter("@PLATFORMID", platform_id));
            command.Parameters.Add(new SqlParameter("@PRICE", price));
            
            // non query is anything that is not a select
            command.ExecuteNonQuery();

        }
    }

    public static void UpdateGamePlatformPrice(int game_id, int platform_id, float price, float discount)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE [game_platforms] SET price = @PRICE, discount = @DISCOUNT WHERE game_id = @GAMEID AND platform_id = @PLATID", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@GAMEID", game_id));
            command.Parameters.Add(new SqlParameter("@PLATID", platform_id));
            command.Parameters.Add(new SqlParameter("@PRICE", price));
            command.Parameters.Add(new SqlParameter("@DISCOUNT", discount));
            // non query is anything that is not a select
            command.ExecuteNonQuery();

        }
    }


    public static DataSet getAllPlatforms()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM[platforms] ORDER BY ID", connection);
            command.CommandType = CommandType.Text;


            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static int getPlatformIdFromName(string name)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT Id FROM[platforms] WHERE REPLACE(NAME, ' ', '') = @NAME", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@NAME", name));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            var rows = ds.Tables[0].Rows;
            //if rows = 1 fetch these info
            if(rows.Count > 0)
            {
                var datag = rows[0];

                return (int)datag["Id"];
            }
            return 1;

        }
    }

    public static DataSet getGameWithAllPlatforms(int gameId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT P.Id, P.name, P.image, GP.price FROM[platforms] as P INNER JOIN [game_platforms] as GP ON P.Id = GP.platform_id WHERE game_id = @GAMEID ORDER BY PRICE", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@GAMEID", gameId));


            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static DataSet getGameNameWithAllPlatforms(int gameId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT P.Id as 'PlatformId', P.name as 'PlatformName', G.Name as 'GameName', G.Image as 'GameImage', GP.price FROM[platforms] as P INNER JOIN [game_platforms] as GP ON P.Id = GP.platform_id INNER JOIN [games] AS G ON GP.game_id = G.Id WHERE game_id = @GAMEID ORDER BY PRICE", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@GAMEID", gameId));


            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static DataSet getAllPlatformsWithGameCount()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT P.Id, P.NAME as name, (SELECT COUNT(game_id) FROM [game_platforms] WHERE platform_id = P.Id) as count FROM[platforms] as P ORDER BY ID", connection);
            command.CommandType = CommandType.Text;


            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }
    public static bool DoesPlatformNameExist(string GameName)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            SqlCommand command1 = new SqlCommand("SELECT * FROM[platforms] WHERE name = @name", connection);
            command1.CommandType = CommandType.Text;

            command1.Parameters.Add(new SqlParameter("@name", GameName));

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            adapter.Fill(ds);

            // 1 user ya3ne 1 row
            var rows = ds.Tables[0].Rows;
            if (rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public static bool DoesPlatformImageExist(string GameImageName)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            SqlCommand command1 = new SqlCommand("SELECT * FROM[platforms] WHERE image = @IMAGE", connection);
            command1.CommandType = CommandType.Text;

            command1.Parameters.Add(new SqlParameter("@IMAGE", GameImageName));

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            adapter.Fill(ds);

            // 1 user ya3ne 1 row
            var rows = ds.Tables[0].Rows;
            if (rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}