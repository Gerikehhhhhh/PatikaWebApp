using Microsoft.AspNetCore.Mvc.Infrastructure;
using MySql.Data.MySqlClient;
using PatikaWebApp.Models;

namespace PatikaWebApp.Services;

public class GyogyszerService
{
    public List<Gyogyszer> GetAllGyogyszer()
    {
        using (MySqlConnection conn = new DatabaseManager.DatabaseManager().CreateConnection())
        {
            try
            {
                conn.Open();
                List<Gyogyszer> result = new List<Gyogyszer>();
                string sql = "SELECT * FROM gyogyszer";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Gyogyszer ujGyogyszer = new Gyogyszer();
                    ujGyogyszer.Id = reader.GetInt32("Id");
                    ujGyogyszer.Nev = reader.GetString("Nev");
                    ujGyogyszer.Hatoanyag = reader.GetString("Hatoanyag");
                    ujGyogyszer.Venykoteles = reader.GetInt32("Venykoteles");
                    ujGyogyszer.Kepnev = reader.GetString("Kepnev");

                    result.Add(ujGyogyszer);
                }

                conn.Close();

                return result;
            }
            catch (Exception ex)
            {
                return new List<Gyogyszer>() {new Gyogyszer() {Nev = ex.Message}};
            }
        }
    }

    public Gyogyszer GetById(int id)
    {
        try
        {
            Gyogyszer result = new Gyogyszer();
            using (MySqlConnection conn = new DatabaseManager.DatabaseManager().CreateConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM gyogyszer WHERE Id = @Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                result.Id = reader.GetInt32("Id");
                result.Nev = reader.GetString("Nev");
                result.Hatoanyag = reader.GetString("Hatoanyag");
                result.Venykoteles = reader.GetInt32("Venykoteles");
                result.Kepnev = reader.GetString("Kepnev");
            }

            return result;
        }
        catch (Exception ex)
        {
            Gyogyszer hiba = new Gyogyszer();
            hiba.Nev = ex.Message;
            
            return hiba;
        }
    }
}