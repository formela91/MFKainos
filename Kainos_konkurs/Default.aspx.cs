using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;
using System.Net;
using System.Xml;
using System.IO;

namespace Kainos_konkurs
{

    public partial class _Default : Page
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
            NpgsqlCommand command = new NpgsqlCommand("SELECT movie.movie_id, movie.title, movie.avg_score FROM public.movie WHERE movie.vote_count >= 100 ORDER BY movie.avg_score DESC LIMIT 20;", myConnection);
            NpgsqlDataReader reader = command.ExecuteReader();

            /*
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(); // jakis data adapter, nie wyszlo z tym nic
            adapter.SelectCommand = command;
            DataSet data = new System.Data.DataSet();
            adapter.Fill(data);
            */
            var id = new List<int>(); //deklaracja listy zawierajacej numery ID filmow wybranych z bazy danych
            var title = new List<string>();
            var avgScore = new List<string>();

            while (reader.Read())
            {

                id.Add(reader.GetInt32(0)); // dodanie pierwszej kolumny z bazy do listy ID
                title.Add(reader.GetString(1));
                avgScore.Add(reader.GetString(2));
                

            }
            reader.Close(); // zamkniecie readera
            myConnection.Close(); // zamkniecie polaczenia z baza danych

            TableRow tRow_top = new TableRow();
            Table1.Rows.Add(tRow_top);
            TableCell tCell_top1 = new TableCell();
            tCell_top1.Text = "Tytuł";
            tRow_top.Cells.Add(tCell_top1);
            TableCell tCell_top2 = new TableCell();
            tCell_top2.Text = "Śr. ocena";
            tRow_top.Cells.Add(tCell_top2);

            
            for (int i = 0; i < 20; i++)
            {
                TableRow tRow = new TableRow();
                Table1.Rows.Add(tRow);

                TableCell tCell = new TableCell();
                tCell.Text = title[i];
                tRow.Cells.Add(tCell);

                TableCell tCell2 = new TableCell();
                tCell2.Text = avgScore[i];

                tRow.Cells.Add(tCell2);

                TableCell tCell3 = new TableCell();
                tRow.Cells.Add(tCell3);

                System.Web.UI.WebControls.HyperLink h = new HyperLink();
                h.Text = "Szczegółowy opis";
                // h.NavigateUrl = "http://www.omdbapi.com/?t=" + title[i].ToString() + "&y=&plot=short&r=xml";
                h.NavigateUrl = "movie.aspx/?id=" + id[i].ToString();
                tCell3.Controls.Add(h);
            }
             
        }
    }
}