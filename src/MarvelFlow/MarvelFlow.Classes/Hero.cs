using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes
{
    public enum Team
    {
        Avengers,
        GuardienGalaxy,
        Dora,
        BlackOrder,
        FamilleAsgardian
    }

    public enum Statut
    {
        Neutre,
        Gentil,
        Mechant
    }

    public enum Universe
    {
        MCU,
        SerieNetflix
    }

    public class Hero
    {
        
        // ATTRIBUT //

        private string hId { get;  set; }

        private string nomHero { get; set; }

        private string image { get; set; }

        private string desc { get; set; }

        private Statut status { get; set; }

        private Team teamHeros { get; set; }

        private Universe univers { get; set; }

        private List<Movie> listMovies { get;}

        private Boolean fav { get; set; }

        // CONSTRUCTEURS //

        //constructeur avec certains attributs prédéfinis :
        //  status = neutre  &  univers = MCU
        public Hero(string hId, string nomHero, string image , string desc, Team teamHeros)
        {
            if (string.IsNullOrEmpty(hId))
            {
                throw new ArgumentException("Id du hero nulle", nameof(hId));
            }

            if (string.IsNullOrEmpty(nomHero))
            {
                throw new ArgumentException("Nom du hero nulle", nameof(nomHero));
            }

            this.hId = hId;
            this.nomHero = nomHero;
            this.image = image;
            this.desc = string.IsNullOrEmpty(desc) ? "desc" : desc;
            this.status = Statut.Neutre;
            this.teamHeros = teamHeros;
            this.univers = Universe.MCU;
            fav = false;
        }

        public Hero(string hId, string nomHero, string image, string desc, Statut status, Team teamHeros, Universe univers) 
            : this(hId, nomHero, image, desc, teamHeros)
        {
            this.status = status;
            this.univers = univers;
        }

        // METHODES //
        
        public override string ToString()
        {
            return nomHero;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

       
    }
}
