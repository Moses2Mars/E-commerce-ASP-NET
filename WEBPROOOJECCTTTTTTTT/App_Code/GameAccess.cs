using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GameAccess
/// </summary>
public class GameAccess
{
    public GameAccess()
    {

    }

    public static void InsertGame(Game game)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO [games] (name, image, description, genre) VALUES (@NAME, @IMAGE, @DESCRIPTION, @GENRE)", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@NAME", game.Name));
            command.Parameters.Add(new SqlParameter("@IMAGE", game.Image));
            command.Parameters.Add(new SqlParameter("@DESCRIPTION", game.Description));
            command.Parameters.Add(new SqlParameter("@GENRE", game.Genre));

            command.ExecuteNonQuery();

        }
    }

    public static void updateGameName(string gameName, int gameId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE [games] SET name = @NAME WHERE ID = @ID", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@NAME", gameName));
            command.Parameters.Add(new SqlParameter("@ID", gameId));

            command.ExecuteNonQuery();

        }
    }

    public static DataSet getAllGames()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT MIN(P.price - ( P.price * ( P.discount / 100 ) )) AS price, G.name, G.image, G.Id FROM[games] AS G INNER JOIN [game_platforms] AS P ON G.Id = P.game_id GROUP BY G.name, G.image, G.Id", connection);
            command.CommandType = CommandType.Text;

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static DataSet getAllGamesFromPlatform(int platformId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT MIN(P.price - ( P.price * ( P.discount / 100 ) )) AS price, G.name, G.image, G.Id FROM[games] AS G INNER JOIN [game_platforms] AS P ON G.Id = P.game_id WHERE P.platform_id = @PLATID GROUP BY G.name, G.image, G.Id", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@PLATID", platformId));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static DataSet getAllFreeGames()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT P.price, G.name, G.image, G.Id FROM[games] AS G INNER JOIN [game_platforms] AS P ON G.Id = P.game_id WHERE P.Price = 0 GROUP BY G.name, G.image, P.price, G.Id", connection);
            command.CommandType = CommandType.Text;

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static DataSet getAllFreeGamesFromPlatform(int platformId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT P.price, G.name, G.image, G.Id FROM[games] AS G INNER JOIN [game_platforms] AS P ON G.Id = P.game_id WHERE P.Price = 0 AND P.platform_id = @PLATID GROUP BY G.name, G.image, P.price, G.Id", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@PLATID", platformId));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static DataSet getAllDiscountedGames()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT MIN(P.price - ( P.price * ( P.discount / 100 ) )) AS price, G.name, G.image, " +
                "G.Id FROM[games] AS G INNER JOIN [game_platforms] AS P ON G.Id = P.game_id WHERE P.discount > 0 GROUP BY G.name, G.image, G.Id", connection);
            command.CommandType = CommandType.Text;

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static DataSet getAllDiscountedGamesFromPlatform(int platformId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT MIN(P.price - ( P.price * ( P.discount / 100 ) )) AS price, G.name, G.image, G.Id FROM[games] AS G INNER JOIN [game_platforms] AS P ON G.Id = P.game_id WHERE P.discount > 0 AND P.platform_id = @PLATID GROUP BY G.name, G.image, G.Id", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@PLATID", platformId));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static DataSet getLimitedDiscountedGames()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT TOP 8 MIN(P.price - ( P.price * ( P.discount / 100 ) )) AS price, G.name, G.image, G.Id FROM[games] AS G INNER JOIN [game_platforms] AS P ON G.Id = P.game_id WHERE P.discount > 0 GROUP BY G.name, G.image, G.Id", connection);
            command.CommandType = CommandType.Text;

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static DataSet getNewGames()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT MIN(P.price - ( P.price * ( P.discount / 100 ) )) AS price, G.name, G.image, G.Id FROM[games] AS G INNER JOIN [game_platforms] AS P ON G.Id = P.game_id GROUP BY G.name, G.image, G.Id ORDER BY G.Id DESC", connection);
            command.CommandType = CommandType.Text;

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static DataSet getNewGamesFromPlatform(int platformId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT MIN(P.price - ( P.price * ( P.discount / 100 ) )) AS price, G.name, G.image, G.Id FROM[games] AS G INNER JOIN [game_platforms] AS P ON G.Id = P.game_id WHERE P.platform_id = @PLATID GROUP BY G.name, G.image, G.Id ORDER BY G.Id DESC", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@PLATID", platformId));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static DataSet getLimitedNewGames()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT TOP 8 MIN(P.price - ( P.price * ( P.discount / 100 ) )) AS price, G.name, G.image, G.Id FROM[games] AS G INNER JOIN [game_platforms] AS P ON G.Id = P.game_id GROUP BY G.name, G.image, G.Id ORDER BY G.Id DESC", connection);
            command.CommandType = CommandType.Text;

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static DataSet getTopSellingGames()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT MIN(P.price - ( P.price * ( P.discount / 100 ) )) AS price, G.name, G.image, G.Id FROM[games] AS G INNER JOIN [game_platforms] AS P ON G.Id = P.game_id GROUP BY G.name, G.image, G.Id ORDER BY (SELECT MAX(game_id) FROM [game_ownership] AS GO WHERE G.Id = GO.game_id) DESC", connection);
            command.CommandType = CommandType.Text;

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static DataSet getTopSellingGamesFromPlatform(int platformId)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT MIN(P.price - ( P.price * ( P.discount / 100 ) )) AS price, G.name, G.image, G.Id FROM[games] AS G INNER JOIN [game_platforms] AS P ON G.Id = P.game_id WHERE P.platform_id = @PLATID GROUP BY G.name, G.image, G.Id ORDER BY (SELECT MAX(game_id) FROM [game_ownership] AS GO WHERE G.Id = GO.game_id) DESC", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@PLATID", platformId));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static DataSet getLimitedTopSellingGames()
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT TOP 8 MIN(P.price - ( P.price * ( P.discount / 100 ) )) AS price, G.name, G.image, G.Id FROM[games] AS G INNER JOIN [game_platforms] AS P ON G.Id = P.game_id GROUP BY G.name, G.image, G.Id ORDER BY (SELECT MAX(game_id) FROM [game_ownership] AS GO WHERE G.Id = GO.game_id) DESC", connection);
            command.CommandType = CommandType.Text;

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds;
        }
    }

    public static Game getGameFromId(int id)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM[games] WHERE Id = @id", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@id", id));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            var row = ds.Tables[0].Rows[0];

            return new Game()
            {
                Id = (int)row["Id"],
                Name = (string)row["name"],
                Image = (string)row["image"],
                Description = (string)row["description"],
                Genre = (string)row["genre"],
            };
        }
    }



    public static int getGameIdFromName(string GameName)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM[games] WHERE name = @name", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@name", GameName));

            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            var rows = ds.Tables[0].Rows;
            var Gamedata = rows[0];
            return (int)Gamedata["Id"];
        }
    }

    public static bool DoesGameNameExist(string GameName)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            SqlCommand command1 = new SqlCommand("SELECT * FROM[games] WHERE name = @name", connection);
            command1.CommandType = CommandType.Text;

            command1.Parameters.Add(new SqlParameter("@name", GameName));

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            adapter.Fill(ds);

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

    public static bool DoesGameImageExist(string GameImageName)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            SqlCommand command1 = new SqlCommand("SELECT * FROM[games] WHERE image = @IMAGE", connection);
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