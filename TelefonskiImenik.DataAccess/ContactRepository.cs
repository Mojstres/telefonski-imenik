using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace TelefonskiImenik.DataAccess
{
    public class ContactRepository(string connectionString)
    {
        public List<Contact> GetAll()
        {
            var contacts = new List<Contact>();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            var cmd = new MySqlCommand("SELECT id, naziv, stevilka FROM imenik", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                contacts.Add(new Contact(
                    reader.GetInt32("id"),
                    reader.GetString("naziv"),
                    reader.GetString("stevilka")
                ));
            }

            return contacts;
        }

        public List<Contact> Search(string query)
        {
            var contacts = new List<Contact>();

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            var cmd = new MySqlCommand("SELECT id, naziv, stevilka FROM imenik WHERE naziv LIKE @query", conn);
            cmd.Parameters.AddWithValue("@query", $"%{query}%");

            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                contacts.Add(new Contact(
                    reader.GetInt32("id"),
                    reader.GetString("naziv"),
                    reader.GetString("stevilka")
                ));
            }

            return contacts;
        }

        public void Add(Contact contact)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            var cmd = new MySqlCommand("INSERT INTO imenik (naziv, stevilka) VALUES (@naziv, @stevilka)", conn);
            cmd.Parameters.AddWithValue("@naziv", contact.Naziv);
            cmd.Parameters.AddWithValue("@stevilka", contact.Stevilka);
            cmd.ExecuteNonQuery();
        }
    }
}
