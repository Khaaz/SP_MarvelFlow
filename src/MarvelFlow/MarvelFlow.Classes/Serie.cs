﻿using MarvelFlow.Classes.Lib;
using MarvelFlow.Classes.Lib.ExceptionFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelFlow.Classes
{
    public class Serie : Movie
    {
        public string Id { get; private set; }

        public Universe Universe { get; private set; }

        public int NumberSeasons { get; private set; }

        public Dictionary<int, Season> ListSeasons { get; private set; }

        public bool IsOver { get; private set; }

        public List<string> ListHeroString { get; private set; }

        public List<Hero> ListHeroes { get; set; }

        /// <summary>
        /// Default constructor for Serie
        /// listSeasons is a Dictionary = numeroSeason => Season
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        /// <param name="productor"></param>
        /// <param name="numberSeasons"></param>
        /// <param name="listSeasons"></param>
        /// <param name="isOver"></param>
        public Serie(string id, string title, string affiche, string desc, string real, string date, Universe universe, int numberSeasons, Dictionary<int, Season> listSeasons, bool isOver, List<string> listHeros) 
            : base(title, affiche, desc, real, date)
        {

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Id de la serie null", nameof(id));
            }

            this.Id = id;
            this.Universe = universe;
            this.NumberSeasons = numberSeasons;
            this.ListSeasons = listSeasons;
            this.IsOver = isOver;

            ListHeroString = listHeros;

            this.ListHeroes = new List<Hero>();
        }

        /// <summary>
        /// Constructor Serie mainly used by init json
        /// Create Serie with List of Seasons
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="desc"></param>
        /// <param name="productor"></param>
        /// <param name="numberSeasons"></param>
        /// <param name="listSeasons"></param>
        /// <param name="isOver"></param>
        public Serie(string id, string title, string affiche, string desc, string real, string date, Universe universe, int numberSeasons, List<Season> listSeasons, bool isOver, List<string> listHeros)
            : base(title, affiche, desc, real, date)
        {

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("Id de la serie null", nameof(id));
            }

            this.Id = id;
            this.Universe = universe;
            this.NumberSeasons = numberSeasons;

            this.ListSeasons = new Dictionary<int, Season>();
            foreach (Season s in listSeasons)
            {
                this.ListSeasons.Add(s.SeasonNumber, s);
            }

            this.IsOver = isOver;

            ListHeroString = listHeros;

            this.ListHeroes = new List<Hero>();
        }

        /// <summary>
        /// Add a season (to the end) to the list with correct season number
        /// update number of seasons
        /// 
        /// error if the season number doesn't match the id in the Dicionnary
        /// </summary>
        /// <param name="season"></param>
        /// <exception cref="Exception">Season number and key doesn't match</exception>
        /// <returns>Updated Dictionary of Seasons</returns>
        public Dictionary<int, Season> AddSeason(Season season)
        {
            checkSeasonNumberIndex(season.SeasonNumber, NumberSeasons + 1);

            ListSeasons.Add(season.SeasonNumber, season);
            NumberSeasons += 1;
            return ListSeasons;
        }

        /// <summary>
        /// Surcharge AddSeason allowing to add a season with the episode number wanted
        /// 
        /// return an error if the key already exist
        /// error if the season number doesn't match the id in the Dicionnary
        /// </summary>
        /// <param name="index"></param>
        /// <param name="season"></param>
        /// <exception cref="Exception">Season number and key doesn't match</exception>
        /// <exception cref="Exception">The season already exist</exception>
        /// <returns>Updated Dictionary of Seasons</returns>
        public Dictionary<int, Season> AddSeason(int index, Season season)
        {
            checkSeasonNumberIndex(season.SeasonNumber, index);

            if (ListSeasons.ContainsKey(index))
            {
                throw new SerieException(SerieEnum.EXIST);
            }
            ListSeasons.Add(index, season);
            NumberSeasons += 1;
            return ListSeasons;
        }

        /// <summary>
        /// Edit a season by passing the index of the season
        /// 
        /// return an error if the season doesn't exist
        /// error if the season number doesn't match the id in the Dicionnary
        /// </summary>
        /// <param name="index"></param>
        /// <param name="season"></param>
        /// <exception cref="Exception">Season number and key doesn't match</exception>
        /// <exception cref="Exception">The season doesn't exist</exception>
        /// <returns>Updated Dictionary of Seasons</returns>
        public Dictionary<int, Season> EditSeason(int index, Season season)
        {
            checkSeasonNumberIndex(season.SeasonNumber, index);

            if (!ListSeasons.ContainsKey(index))
            {
                throw new SerieException(SerieEnum.NOTEXIST);
            }
            ListSeasons[index] = season;
            return ListSeasons;
        }

        /// <summary>
        /// Check if the season number match the id insert id in the dictionnary
        /// Raise an Exception if it's not the case
        /// </summary>
        /// <param name="seasonNbr"></param>
        /// <param name="index"></param>
        /// <exception cref="SerieException">NOTMATCH</exception>
        private void checkSeasonNumberIndex(int seasonNbr, int index)
        {
            if (seasonNbr != index)
            {
                throw new SerieException(SerieEnum.NOTMATCH);
            }
        }

        public override string GetId()
        {
            return Id;
        }

        public override Universe GetUniverse()
        {
            return Universe;
        }

        public override List<Hero> GetListHeros()
        {
            return ListHeroes;
        }

        public override List<string> GetHeroString()
        {
            return ListHeroString;
        }

        /// <summary>
        /// Ajoute un hero in ListHeros
        /// </summary>
        /// <param name="h"></param>
        public override void AddListHero(Hero h)
        {
            this.ListHeroes.Add(h);
        }

        /// <summary>
        /// Sort ListHero by hero Name
        /// </summary>
        public override void SortListHeros()
        {
            ListHeroes = ListHeroes.OrderBy(h => h.Name).ToList();
        }

        /// <summary>
        /// Remove a specified hero in ListHeros
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public override bool RemoveListHero(Hero h)
        {
            this.ListHeroes.Remove(h);
            return true;
        }
    }
}
