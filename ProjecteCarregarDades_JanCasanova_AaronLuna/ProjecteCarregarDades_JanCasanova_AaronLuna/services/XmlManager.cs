using Microsoft.VisualBasic.Devices;
using ProjecteCarregarDades_JanCasanova_AaronLuna.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        public void SaveMoviesToDatabase(List<Movie> movies) //Credencials base de dades(administrador123, administrador)
        {
            // aqui va el codi per desar la informació de les pel·licules a la base de dades
        }
    }
}
