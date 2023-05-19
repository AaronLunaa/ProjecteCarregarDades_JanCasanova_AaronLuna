using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteCarregarDades_JanCasanova_AaronLuna.model
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }
        public List<Actor> Actors { get; set; }

        public Movie()
        {
            Actors = new List<Actor>();
        }
    }
}
