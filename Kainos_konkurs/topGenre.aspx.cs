using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kainos_konkurs
{
    public partial class topGenre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString2 = "Server=ec2-54-83-18-87.compute-1.amazonaws.com;" +
            "Port=5432;" +
            "Database=d2sb5n839b5ern;" +
            "Uid=iadpqgbdapdehb;" +
            "Pwd=WDBoz0PV43X147eaKFdXoD5hEF;" +
            "sslmode=require";

            NpgsqlConnection myConnection = new NpgsqlConnection(connectionString2); // nawiazanie polaczenia z baza danych npgsql poprzez connection string
            myConnection.Open();



            // wywolywanie komend mySQL poprzez C#
            NpgsqlCommand command = new NpgsqlCommand("SELECT genre.genre_name, COUNT(genre_id.genre_ID) FROM public.genre, public.genre_id WHERE genre.id = genre_id.genre_id GROUP BY genre.genre_name ORDER BY COUNT(genre_id.genre_ID) DESC;", myConnection);
            NpgsqlDataReader reader = command.ExecuteReader();

            var genre = new List<string>(); //deklaracja listy zawierajacej numery ID filmow wybranych z bazy danych
            var genreSum = new List<Int64>();
            var genrePercentage = new List<float>();

            var sum = new float();
            while (reader.Read())
            {
                genre.Add(reader.GetString(0));
                genreSum.Add(reader.GetInt64(1));
                sum += reader.GetInt64(1);
            }
            reader.Close(); // zamkniecie readera

            myConnection.Close(); // zamkniecie polaczenia z baza danych


         
            //  genrePercentage[0] = genreSum[0] / sum;
            // Label1.Text = genrePercentage[0].ToString();

            for (int i = 0; i < 20; i++)
            {
                genrePercentage.Add(genreSum[i] * 100 / sum);
                Chart1.Series["Series1"].Points.AddXY(genre[i], genrePercentage[i]);

            }
        }
    }
}