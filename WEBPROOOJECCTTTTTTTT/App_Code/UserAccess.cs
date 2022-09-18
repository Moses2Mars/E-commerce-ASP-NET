using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
/// <summary>
/// Summary description for User
/// </summary>
public class UserAccess
{
    // extra security 
    private static readonly string STATIC_SALT = "589455615611g%$25&";
    public UserAccess()
    {

    }
    // if we find a user with the username = admin we dont insert it else we do
    public static bool IsUserExists(string username)
    {

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT 1 FROM[users] WHERE username = @username", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@username", username));

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            return ds.Tables[0].Rows.Count == 1;
        }
    }

    public static User GetUser(string username)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))


        {
            connection.Open();

            SqlCommand command = new SqlCommand("SELECT ID, USERNAME, EMAIL, ROLE, WALLET, date_registered FROM[users] WHERE username = @username", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@username", username));

            DataSet ds = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            // 1 user ya3ne 1 row
            var rows = ds.Tables[0].Rows;
            //if rows = 1 fetch these info
            if (rows.Count == 1)
            {
                var userData = rows[0];

                string dbUsername = (string)userData["username"];
                string dbRole = (string)userData["role"];
                int dbId = (int)userData["id"];
                string dbEmail = (string)userData["email"];
                DateTime dbDate = (DateTime)userData["date_registered"];
                double dbWallet = (double)userData["wallet"];

                return new User()
                {
                    Username = dbUsername,
                    Role = dbRole,
                    Id = dbId,
                    Email = dbEmail,
                    DateRegistered = dbDate,
                    Wallet = dbWallet,
                };
            }

            return null;
        }
    }

    public static void updateWallet(int id)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("UPDATE [users] SET WALLET += 50 WHERE Id = @ID", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@ID", id));

            command.ExecuteNonQuery();

        }
    }

    public static void updateWalletWithGrandTotal(int id, double newWallet)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("UPDATE [users] SET WALLET = @AMOUNT WHERE Id = @ID", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@AMOUNT", (float)newWallet));
            command.Parameters.Add(new SqlParameter("@ID", id));

            command.ExecuteNonQuery();

        }
    }

    public static void updateUsernameAndEmail(int id, string username, string email)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("UPDATE [users] SET username = @USERNAME, email = @EMAIL WHERE Id = @ID", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@ID", id));
            command.Parameters.Add(new SqlParameter("@USERNAME", username));
            command.Parameters.Add(new SqlParameter("@EMAIL", email));
            command.ExecuteNonQuery();

        }
    }

    public static void updatePassword(int id, string password)
    {
        string newpass = HashPassword(password);

        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();

            SqlCommand command = new SqlCommand("UPDATE [users] SET password = @PASSWORD WHERE Id = @ID", connection);
            command.CommandType = CommandType.Text;

            command.Parameters.Add(new SqlParameter("@ID", id));
            command.Parameters.Add(new SqlParameter("@PASSWORD", newpass));

            command.ExecuteNonQuery();

        }
    }
    public static bool ValidateUserCredentials(string username, string password)
    {
        //fetch the password of the user
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            // el select statment la nshouf el admin
            SqlCommand command = new SqlCommand("SELECT password FROM[users] WHERE username = @username", connection);
            command.CommandType = CommandType.Text;
            // replace @username with username value(ya3ne el name)
            command.Parameters.Add(new SqlParameter("@username", username));

            DataSet ds = new DataSet();
            // adapter will execute the query
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);

            //fetch the table the the rows
            var rows = ds.Tables[0].Rows;
            // if we onlu have 1 row we can start validation
            if (rows.Count == 1)
            {
                string savedPassword = (string)rows[0]["password"];
                string hashedPassword = HashPassword(password);

                if (savedPassword.Equals(hashedPassword))
                {
                    return true;
                }

            }
            return false;

        }
    }


    public static void InsertUser(User user)
    {
        using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
        {
            connection.Open();
            // el select statment la nshouf el admin
            SqlCommand command = new SqlCommand("INSERT INTO [users] (username, password, email, role, date_registered) VALUES (@USERNAME, @PASSWORD, @EMAIL, @ROLE, @DATE)", connection);
            command.CommandType = CommandType.Text;
            // replace @username with username value(ya3ne el name)
            command.Parameters.Add(new SqlParameter("@USERNAME", user.Username));
            command.Parameters.Add(new SqlParameter("@PASSWORD", HashPassword(user.Password)));
            command.Parameters.Add(new SqlParameter("@EMAIL", user.Email));
            command.Parameters.Add(new SqlParameter("@ROLE", user.Role));
            command.Parameters.Add(new SqlParameter("@Date", DateTime.Now.ToString("yyyy-MM-dd")));
            // non query is anything that is not a select
            command.ExecuteNonQuery();

        }
    }
    //hash password
    private static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            string hashedPassword =
                Utils.toHex(sha256.ComputeHash(Encoding.UTF8.GetBytes(password + STATIC_SALT)));
            // create utils class that transforms from bit to hexa
            return hashedPassword;
        }
    }
}