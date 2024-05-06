

using System.Data.SqlClient;
using Apbd_task6.models.dto;

namespace Apbd_task6.repository;


public class WarehouseRepository
{


    public bool cheakProduct(IConfiguration _configuration,int id)
    {
        
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT count(*) FROM [Productt] where IdProduct=@id";
        command.Parameters.AddWithValue("id", id);
        
        // Wykonanie zapytania
     
          int count = (int) command.ExecuteScalar();

          if (count != 0)
              return true;
          else
              return false;
    }

    public bool cheakWarehouse(IConfiguration _configuration, int id)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "SELECT count(*) FROM [Warehouse] where IdWarehouse=@id";
        command.Parameters.AddWithValue("id", id);
        
        // Wykonanie zapytania
     
        int count = (int) command.ExecuteScalar();

        if (count != 0)
            return true;
        else
            return false;
    }

    public bool cheackOrder(IConfiguration _configuration, int id,int amount)
    {
        
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select count(*) from [Orderr] where IdProduct=@id and Amount=@a";
        command.Parameters.AddWithValue("id", id);
        command.Parameters.AddWithValue("a",amount);
        int count = (int) command.ExecuteScalar();

        if (count != 0)
            return true;
        else
            return false;
        
    }

    public bool checkEndOrder(IConfiguration _configuration, int id)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select count(*) from [Orderr] where IdProduct=@id  and FulfilledAt is null";
        command.Parameters.AddWithValue("id", id);
        int count = (int) command.ExecuteScalar();

        if (count != 0)
            return true;
        else
            return false;
        
    }

    public void updateFulfilledAt(IConfiguration _configuration, int id)
    {
            using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "UPDATE [Orderr] set FulfilledAt=@t where IdProduct=@id";
            command.Parameters.AddWithValue("t", DateTime.Now);
            command.Parameters.AddWithValue("id", id);
            int nRows = command.ExecuteNonQuery();
            Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
    }

    public void add(DtoProductWarehouse dtoProductWarehouse, IConfiguration _configuration)
    {
        using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Default"));
        connection.Open();
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = ("INSERT INTO [Product_Warehouse] Values (@id,@ip,@io,@a,@p,@t)");

    }
}

