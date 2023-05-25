using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using ProjecteCarregarDades_JanCasanova_AaronLuna.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;


namespace ProjecteCarregarDades_JanCasanova_AaronLuna.services
{
    public class XmlManager
    {
        public List<Movie> ReadMoviesFromXml(string xmlFilePath)
        {
            List<Movie> movies = new List<Movie>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNodeList movieNodes = xmlDoc.SelectNodes("/catalog/movie");
            foreach (XmlNode movieNode in movieNodes)
            {
                Movie movie = new Movie();
                movie.Id = int.Parse(movieNode.Attributes["id"].Value);
                movie.Title = movieNode.SelectSingleNode("title").InnerText;
                movie.Genre = movieNode.SelectSingleNode("genre").InnerText;
                movie.Director = movieNode.SelectSingleNode("director").InnerText;
                movie.Year = int.Parse(movieNode.SelectSingleNode("year").InnerText);
                movie.Rating = double.Parse(movieNode.SelectSingleNode("rating").InnerText);

                XmlNodeList actorNodes = movieNode.SelectNodes("actors/actor");
                foreach (XmlNode actorNode in actorNodes)
                {
                    Actor actor = new Actor();
                    actor.Name = actorNode.Attributes["name"].Value;
                    actor.Role = actorNode.Attributes["role"].Value;
                    movie.Actors.Add(actor);
                }
                movies.Add(movie);
            }

            return movies;
        }
        public void ImportDataToDatabase(string xmlFilePath)
        {
            // Llegir el contingut del fitxer script.sql
            string script = File.ReadAllText("script.sql");

            string connectionString = "Server=db4free.net;Port=3306;Database=projectem02_m04;Uid=administrador123;Pwd=administrador";
            // Crear la connexió a la base de dades
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Obrir la connexió
                connection.Open();

                // Desactivar les restriccions de clau externa temporalment
                MySqlCommand disableConstraintsCommand = new MySqlCommand("SET FOREIGN_KEY_CHECKS=0", connection);
                disableConstraintsCommand.ExecuteNonQuery();

                // Executar les instruccions SQL per crear les taules
                MySqlCommand command = new MySqlCommand(script, connection);
                command.ExecuteNonQuery();

                // Llegir les pel·lícules des del fitxer XML
                List<Movie> movies = ReadMoviesFromXml(xmlFilePath);

                // Comandament per insertar les dades de les pel·lícules a la base de dades
                MySqlCommand movieCommand = new MySqlCommand("INSERT INTO movies (id, title, genre, director, year, rating) VALUES (@id, @title, @genre, @director, @year, @rating)", connection);
                movieCommand.Parameters.Add("@id", MySqlDbType.Int32);
                movieCommand.Parameters.Add("@title", MySqlDbType.VarChar);
                movieCommand.Parameters.Add("@genre", MySqlDbType.VarChar);
                movieCommand.Parameters.Add("@director", MySqlDbType.VarChar);
                movieCommand.Parameters.Add("@year", MySqlDbType.Int32);
                movieCommand.Parameters.Add("@rating", MySqlDbType.Decimal);

                // Comandament per insertar les dades dels actors a la base de dades
                MySqlCommand actorCommand = new MySqlCommand("INSERT INTO actors (movie_id, name, role) VALUES (@movieId, @name, @role)", connection);
                actorCommand.Parameters.Add("@movieId", MySqlDbType.Int32);
                actorCommand.Parameters.Add("@name", MySqlDbType.VarChar);
                actorCommand.Parameters.Add("@role", MySqlDbType.VarChar);

                // Executar els comandaments per cada pel·lícula i actor, i insertar les dades a la base de dades
                foreach (Movie movie in movies)
                {
                    // Insertar les dades de la pel·lícula
                    movieCommand.Parameters["@id"].Value = movie.Id;
                    movieCommand.Parameters["@title"].Value = movie.Title;
                    movieCommand.Parameters["@genre"].Value = movie.Genre;
                    movieCommand.Parameters["@director"].Value = movie.Director;
                    movieCommand.Parameters["@year"].Value = movie.Year;
                    movieCommand.Parameters["@rating"].Value = movie.Rating;

                    movieCommand.ExecuteNonQuery();

                    // Insertar les dades dels actors
                    foreach (Actor actor in movie.Actors)
                    {
                        actorCommand.Parameters["@movieId"].Value = movie.Id;
                        actorCommand.Parameters["@name"].Value = actor.Name;
                        actorCommand.Parameters["@role"].Value = actor.Role;

                        actorCommand.ExecuteNonQuery();
                    }
                }

                // Activar de nou les restriccions de clau externa
                MySqlCommand enableConstraintsCommand = new MySqlCommand("SET FOREIGN_KEY_CHECKS=1", connection);
                enableConstraintsCommand.ExecuteNonQuery();

                // Generar el fitxer XML des del stored procedure
                GenerateXmlFileFromStoredProcedure();

                // Tancar la connexió
                connection.Close();
            }
        }
        
        public static string getdades()
        {
            string resultVariable = string.Empty;
            string connectionString = "Server=db4free.net;Port=3306;Database=projectem02_m04;Uid=administrador123;Pwd=administrador";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("obtenirXML", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            resultVariable = reader.GetString("XML_Result");
                        }
                        else
                        { 
                            resultVariable=string.Empty;
                        }
                    }
                }

                connection.Close();
            }
            return resultVariable;
        }

        public static void CreateXmlFile(string xmlContent, string filePath)
        {
            File.WriteAllText(filePath, xmlContent);
        }

        public static string GetXmlFilePath()
        {
            string currentDirectory = "../../../../../";
            string fileName = "result.xml";
            return Path.Combine(currentDirectory, fileName);
        }

        public static void GenerateXmlFileFromStoredProcedure()
        {
            string xmlContent = getdades();
            string xmlFilePath = GetXmlFilePath();
            CreateXmlFile(xmlContent, xmlFilePath);
        }

    }
}
