using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1;

class DataAccess
{
    //DbConnection conn = null;  Conncetionlarin base clasidir onun adi altinda
    //derived olaraq sqlconncetion cagirib islede bilerik

    SqlConnection? conn = null;


    public DataAccess()
    {
        //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        //builder.DataSource = < your_server_windows_name >;
        //builder.UserID = < your_user_name >;
        //builder.Password = < your_password >;
        //builder.InitialCatalog = < your_database_name >;

        string connectionString = @"Data Source=STHQ0123-01;Initial Catalog=Library;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=False;";

        conn = new SqlConnection(connectionString);
    }
    public void insertDatabase()
    {
        try
        {
            conn.Open();
            string insertData = "INSERT INTO Authors (Id, FirstName, LastName) VALUES (20, 'Kenan', 'Huseynli')";
            using SqlCommand cmd = new SqlCommand(insertData, conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Press enter");//kodda nese gorunsun deye yazmisam hecbir onem kesb elemeir
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            conn.Close();
        }
    }

    public void selectDatabase()
    {
        SqlDataReader reader = null;
        try
        {
            conn.Open();
            using SqlCommand command = new SqlCommand("SELECT * FROM Authors", conn);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                //Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
                Console.WriteLine(reader["Id"] + " " + reader["FirstName"] + " " + reader["LastName"]);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            reader.Close();
            conn.Close();
        }
    }



}



class Program
{
    static void Main(string[] args)
    {

        DataAccess access = new DataAccess();
        //access.insertDatabase();
        access.selectDatabase();

    }

}