using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes
{
    enum Team
    {
        Avengers,
        GuardienGalaxy,
        Dora,
        BlackOrder,
        FamilleAsgardian
    }

    enum Statut
    {
        Neutre,
        Gentil,
        Méchant
    }

    enum Universe
    {
        MCU,
        SerieNetflix
    }
    public class Hero
    {
        
        // ATTRIBUT //

        private string hId { get; set; }

        private string nomHero { get; set; }

        private string image { get; set; }

        private string desc { get; set; }

        private Statut status { get; set; }

        private Boolean fav { get; set; }

        private Team teamHeros;

        private Universe univers { get; set; }

        private List<Movie> listMovies { get;}

        // CONSTRUCTEURS //
        private Hero(string hId, string nomHero, string image, string desc, Statut status, Team teamHeros, Universe univers)
        {
            if (string.IsNullOrWhiteSpace(nomHero))
            {
                throw new ArgumentException("message", nameof(nomHero));
            }

            this.hId = hId;
            this.nomHero = nomHero;
            this.image = image;
            this.desc = desc;
            this.status = status;
            fav = false;
            this.teamHeros = teamHeros;
            this.univers = univers;
        }
        
        //constructeur avec certains attributs prédéfinis :
                //  status = neutre  &  univers = MCU
        private Hero(string hId, string image, string nomHero, string desc, Team teamHeros)
        {
            if (string.IsNullOrWhiteSpace(nomHero))
            {
                throw new ArgumentException("message", nameof(nomHero));
            }

            this.hId = hId;
            this.nomHero = nomHero;
            this.image = image;
            this.desc = desc;
            status = Statut.Neutre;
            fav = false;
            this.teamHeros = teamHeros;
            univers = Universe.MCU;
        }

        // METHODES //
        private Team setTeamHeros()
                {
                    return teamHeros;
                }

                private void setTeamHeros(Team value)
                {
                    teamHeros = value;
                }

        public override string ToString()
        {
            return base.ToString();
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
