using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;


namespace Kainos_konkurs
{
    public partial class movie : System.Web.UI.Page
    {
        String Title, imdbRating, Genre, Plot, Poster;

        protected void Page_Load(object sender, EventArgs e)
        {
string queryID;
        string movieTitle;
        queryID = Request.QueryString["id"];

        string connectionString2 = "Server=ec2-54-83-18-87.compute-1.amazonaws.com;" +
            "Port=5432;" +
            "Database=d2sb5n839b5ern;" +
            "Uid=iadpqgbdapdehb;" +
            "Pwd=WDBoz0PV43X147eaKFdXoD5hEF;" +
            "sslmode=require";

        NpgsqlConnection myConnection = new NpgsqlConnection(connectionString2); // nawiazanie polaczenia z baza danych npgsql poprzez connection string
        myConnection.Open();

        // wywolywanie komend mySQL poprzez C#
        NpgsqlCommand command = new NpgsqlCommand("SELECT movie.title FROM public.movie WHERE movie.movie_id ="+queryID+";", myConnection);
        NpgsqlDataReader reader = command.ExecuteReader();
        
        movieTitle = command.ExecuteScalar() as string;
        myConnection.Close();
        string requestUrl = "http://www.omdbapi.com/?t="+movieTitle+"&y=&plot=full&r=xml";
        HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
        HttpWebResponse response = request.GetResponse() as HttpWebResponse;

       // TextBox1.Text = response.ContentLength.ToString();

        Stream receiveStream = response.GetResponseStream();

        // Pipes the stream to a higher level stream reader with the required encoding format. 
        StreamReader readStream = new StreamReader(receiveStream);

        // Console.WriteLine("Response stream received.");
        // Console.WriteLine(readStream.ReadToEnd());
        string receivedXml = readStream.ReadToEnd();
        //TextBox1.Text = receivedXml;
        response.Close();
        readStream.Close();


        XmlDocument doc = new XmlDocument();
        doc.LoadXml(receivedXml);

        XmlElement root = doc.DocumentElement;

        // Check to see if the element has a genre attribute. 
        //String year = root.GetAttribute("rated");
        //String rated = reader.getAttribute("rated");


//select a list of Nodes matching xpath expression
XmlNodeList oXmlNodeList = doc.SelectNodes("root/movie");


//looping through the all the node details one by one
foreach (XmlNode x in oXmlNodeList)
{
  //for the current Node retrieving all the Attributes details
  Title = x.Attributes["title"].Value;
  Genre = x.Attributes["genre"].Value;
  imdbRating = x.Attributes["imdbRating"].Value;
  Plot = x.Attributes["plot"].Value;
  Poster = x.Attributes["poster"].Value;

       
}
            
Image1.ImageUrl =Poster;
Label1.Text = Title;
Label2.Text = Genre;
Label3.Text = imdbRating;
Label4.Text = Plot;
             
    }
        }
    }
