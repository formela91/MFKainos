using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kainos_konkurs
{
    public partial class search : System.Web.UI.Page
    {
        int counter;

        protected void Page_Load(object sender, EventArgs e)
        {
            counter = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Genre = DropDownListGenre.SelectedValue;
            string Score = TextBoxScore.Text;

            string connectionString2 = "Server=ec2-54-83-18-87.compute-1.amazonaws.com;" +
            "Port=5432;" +
            "Database=d2sb5n839b5ern;" +
            "Uid=iadpqgbdapdehb;" +
            "Pwd=WDBoz0PV43X147eaKFdXoD5hEF;" +
            "sslmode=require";

            NpgsqlConnection myConnection = new NpgsqlConnection(connectionString2); // nawiazanie polaczenia z baza danych npgsql poprzez connection string
            myConnection.Open();


            var id = new List<int>(); //deklaracja listy zawierajacej numery ID filmow wybranych z bazy danych
            var title = new List<string>();
            var avgScore = new List<string>();
            
            if (Genre == "All"){

                NpgsqlCommand command = new NpgsqlCommand("SELECT DISTINCT movie.movie_id, movie.title, movie.avg_score FROM public.genre, public.genre_id, public.movie " +
               "WHERE genre_id.genre_id = genre.id AND movie.movie_id = genre_id.movie_id AND movie.avg_score >= '" + Score + "' ORDER BY movie.avg_score DESC;", myConnection);
                NpgsqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {

                    id.Add(reader.GetInt32(0)); // dodanie pierwszej kolumny z bazy do listy ID
                    title.Add(reader.GetString(1));
                    avgScore.Add(reader.GetString(2));
                    counter += 1;
                }
                reader.Close(); // zamkniecie readera
                myConnection.Close(); // zamkniecie polaczenia z baza danych
            }
            else
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT movie.movie_id, movie.title, movie.avg_score FROM public.genre, public.genre_id, public.movie " +
             "WHERE genre_id.genre_id = genre.id AND movie.movie_id = genre_id.movie_id AND genre.genre_name = '" + Genre + "' AND movie.avg_score >= '" + Score + "' ORDER BY movie.avg_score DESC;", myConnection);
                NpgsqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {

                    id.Add(reader.GetInt32(0)); // dodanie pierwszej kolumny z bazy do listy ID
                    title.Add(reader.GetString(1));
                    avgScore.Add(reader.GetString(2));
                    counter += 1;
                }
                reader.Close(); // zamkniecie readera
                myConnection.Close(); // zamkniecie polaczenia z baza danych
            }

         
                   
            TableRow tRow_top = new TableRow();
            Table1.Rows.Add(tRow_top);
            TableCell tCell_top1 = new TableCell();
            tCell_top1.Text = "Tytuł";
            tRow_top.Cells.Add(tCell_top1);
            TableCell tCell_top2 = new TableCell();
            tCell_top2.Text = "Śr. ocena";
            tRow_top.Cells.Add(tCell_top2);


            for (int i = 0; i < counter; i++) 
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
                h.NavigateUrl = "movie.aspx/?id=" + id[i].ToString();
                tCell3.Controls.Add(h);

            }

           


        }
       
    }
}