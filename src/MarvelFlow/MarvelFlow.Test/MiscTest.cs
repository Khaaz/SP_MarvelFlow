using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using MarvelFlow.Classes;
using MarvelFlow.Classes.Lib;
using MarvelFlow.Service;
using MarvelFlow.Service.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarvelFlow.Test
{

    [TestClass]
    public class MiscTest
    {

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void AddNullSerieFailed()
        {
            var manager = new ManagerJson();
            manager.SaveListSerie(null);
        }

        //
        // Testing Manager Json
        //
        // throw Exception if file path inccorect
        // throw Exception if json invalid/corrupted

        [TestMethod]
        public void TestGetHeroSuccess()
        {
            var manager = new ManagerJson();
            Assert.IsTrue(manager.GetHeroes().Count > 0);
        }

        [TestMethod]
        public void TestGetFilmSuccess()
        {
            var manager = new ManagerJson();
            Assert.IsTrue(manager.GetFilms().Count > 0);
        }

        [TestMethod]
        public void TestGetSerieSuccess() // will error cause bad json file
        {
            var manager = new ManagerJson();
            Assert.IsTrue(manager.GetSeries().Count > 0);
        }

        [TestMethod]
        public void TestGetMovieSuccess()
        {
            var manager = new ManagerJson();
            List<ISearchableMovie> list = manager.GetMovies();
            Assert.IsTrue(list.Count > 0);
        }

        // Write Json
        [TestMethod]
        public void TestWriteJsonHeroSuccess()
        {
            List<Hero> listHero = new List<Hero>()
            {
                new Hero("im", "iron man", "ImagesHero/ironMan.png", "desc", 0, 0, 0),
                new Hero("sm", "spider man", "ImagesHero/ironMan.png", "desc", 0, 0, 0)
            };
            var manager = new ManagerJson();
            manager.SaveListHero(listHero);
        }

        [TestMethod]
        public void TestWriteJsonFilmSuccess()
        {
            List<string> list = new List<string>()
            {
                "IM",
                "SM"
            };

            List<Film> listFilm = new List<Film>()
            {
                new Film("im", "iron man", "ImagesMovie/IronMan.jpg", "desc", "real", "11/02/1998", 0, "Trailer/trailerInfinityWar.mp4", list),
                new Film("im", "iron man", "ImagesMovie/IronMan.jpg", "desc", "real", "11/02/1998", 0, "Trailer/trailerInfinityWar.mp4", list)
            };
            var manager = new ManagerJson();
            manager.SaveListFilm(listFilm);
        }


        // Testing Json class validity
        // (Doesn't send back Exceptionbut boolean for CheckValidity() method)

        // default - validity
        [TestMethod]
        public void TestHeroValid()
        {
            HeroJson Hero = new HeroJson("test", "test", "ImagesHero/ironMan.png","desc", 0, 0, 0);
            Assert.IsTrue(Hero.CheckValidity());
        }

        [TestMethod]
        public void TestFilmValid()
        {
            List<string> list = new List<string>()
            {
                "IM",
                "SM"
            };

            FilmJson Film = new FilmJson("test", "ImagesMovie/IronMan.jpg", "desc", "real", "11/02/1998", "IM", 0, "Trailer/trailerInfinityWar.mp4", list);
            Assert.IsTrue(Film.CheckValidity());
        }

        [TestMethod]
        public void TestSerieValid()
        {
            HeroJson Serie = new HeroJson("test", "test", "ImagesHero/ironMan.png", "desc", 0, 0, 0);
            Assert.IsTrue(Serie.CheckValidity());
        }

        // not valid - expected behavior = false
        //
        //hero
        [TestMethod]
        public void TestHeroInvalidID()
        {
            HeroJson Hero = new HeroJson("", "test", "ImagesHero/ironMan.png", "desc", 0, 0, 0);
            Assert.IsFalse(Hero.CheckValidity());
        }

        [TestMethod]
        public void TestHeroInvalidDesc()
        {
            HeroJson Hero = new HeroJson("", "   ", "ImagesMovies/ironMan.png", "desc", 0, 0, 0);
            Assert.IsFalse(Hero.CheckValidity());
        }

        [TestMethod]
        public void TestHeroInvalidPath()
        {
            HeroJson Hero = new HeroJson("id", "test", "ImagesMovies/ironMan.png", "desc", 0, 0, 0);
            Assert.IsFalse(Hero.CheckValidity());
        }

        [TestMethod]
        public void TestHeroInvalidFile()
        {
            HeroJson Hero = new HeroJson("id", "test", "ImagesMovies/ironMan8.png", "desc", 0, 0, 0);
            Assert.IsFalse(Hero.CheckValidity());
        }

        //
        //film

        [TestMethod]
        public void TestFilmInvalidID()
        {
            List<string> list = new List<string>()
            {
                "IM",
                "SM"
            };

            FilmJson Film = new FilmJson("", "ImagesMovie/IronMan.jpg", "desc", "real", DateTime.Now, "IM", 0, "trailerInfinityWar.mp4", list);
            Assert.IsFalse(Film.CheckValidity());
        }

        [TestMethod]
        public void TestFilmInvalidPath()
        {
            List<string> list = new List<string>()
            {
                "IM",
                "SM"
            };

            FilmJson Film = new FilmJson("", "ImagesHero/IronMan.jpg", "desc", "real", DateTime.Now, "IM", 0, "trailerInfinityWar.mp4", list);
            Assert.IsFalse(Film.CheckValidity());
        }

        [TestMethod]
        public void TestFilmInvalidFile()
        {
            List<string> list = new List<string>()
            {
                "IM",
                "SM"
            };

            FilmJson Film = new FilmJson("", "ImagesMovie/IronMan8.jpg", "desc", "real", DateTime.Now, "IM", 0, "trailerInfinityWar.mp4", list);
            Assert.IsFalse(Film.CheckValidity());
        }

        [TestMethod]
        public void TestFilmInvalidDate1()
        {
            List<string> list = new List<string>()
            {
                "IM",
                "SM"
            };

            FilmJson Film = new FilmJson("", "ImagesMovie/IronMan.jpg", "desc", "real", "11-02-1998", "IM", 0, "trailerInfinityWar.mp4", list);
            Assert.IsFalse(Film.CheckValidity());
        }

        [TestMethod]
        public void TestFilmInvalidDate2()
        {
            List<string> list = new List<string>()
            {
                "IM",
                "SM"
            };

            FilmJson Film = new FilmJson("", "ImagesMovie/IronMan.jpg", "desc", "real", "54/02/1998", "IM", 0, "trailerInfinityWar.mp4", list);
            Assert.IsFalse(Film.CheckValidity());
        }

        [TestMethod]
        public void TestFilmInvalidDate3()
        {
            List<string> list = new List<string>()
            {
                "IM",
                "SM"
            };

            FilmJson Film = new FilmJson("", "ImagesMovie/IronMan.jpg", "desc", "real", "11/13/1998", "IM", 0, "trailerInfinityWar.mp4", list);
            Assert.IsFalse(Film.CheckValidity());
        }

        [TestMethod]
        public void TestFilmInvalidDate4()
        {
            List<string> list = new List<string>()
            {
                "IM",
                "SM"
            };

            FilmJson Film = new FilmJson("", "ImagesMovie/IronMan.jpg", "desc", "real", "11/02/85", "IM", 0, "trailerInfinityWar.mp4", list);
            Assert.IsFalse(Film.CheckValidity());
        }

        [TestMethod]
        public void TestFilmInvaliPathBA()
        {
            List<string> list = new List<string>()
            {
                "IM",
                "SM"
            };

            FilmJson Film = new FilmJson("", "ImagesMovie/IronMan.jpg", "desc", "real", DateTime.Now, "IM", 0, "trailerInfinityWar8.mp4", list);
            Assert.IsFalse(Film.CheckValidity());
        }

        [TestMethod]
        public void TestFilmInvalidList()
        {
            List<string> list = new List<string>()
            {
                "IM",
                "SM"
            };

            FilmJson Film = new FilmJson("", "ImagesMovie/IronMan.jpg", "desc", "real", DateTime.Now, "IM", 0, "trailerInfinityWar.mp4", null);
            Assert.IsFalse(Film.CheckValidity());
        }

        [TestMethod]
        public void TestFilmInvalidEmptyList()
        {
            List<string> list = new List<string>();

            FilmJson Film = new FilmJson("", "ImagesMovie/IronMan.jpg", "desc", "real", DateTime.Now, "IM", 0, "trailerInfinityWar.mp4", list);
            Assert.IsFalse(Film.CheckValidity());
        }

        [TestMethod]
        public void TestFilmInvalidListContent()
        {
            List<string> list = new List<string>()
            {
                "",
                "SM"
            };

            FilmJson Film = new FilmJson("", "ImagesMovie/IronMan.jpg", "desc", "real", DateTime.Now, "IM", 0, "trailerInfinityWar.mp4", list);
            Assert.IsFalse(Film.CheckValidity());
        }
    }
}
