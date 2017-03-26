using DVDLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Models.Repository
{
    public class MockRepository : IRepository
    {
        private static List<DVDOb> _dvds;

        static MockRepository()
        {
            _dvds = new List<DVDOb>()
            {

                new DVDOb { DVDId = 1, Title = "Die Hard", ReleaseDate = "1988", Director = "John McTiernan", Rating = "R", Notes = "Amazing" },
                new DVDOb { DVDId = 2, Title = "Die Hard 2", ReleaseDate = "1990", Director = "Renny Harlin", Rating = "R", Notes = "Video game was better" },
                new DVDOb { DVDId = 3, Title = "Die Hard with a Vengeance", ReleaseDate = "1995", Director = "John McTiernan", Rating = "R", Notes = "Samuel L FTW" },
                new DVDOb { DVDId = 4, Title = "Live Free or Die Hard", ReleaseDate = "2007", Director = "Len Wiseman", Rating = "PG13", Notes = "A good return to the series" },
                new DVDOb { DVDId = 5, Title = "A Good Day to Die Hard", ReleaseDate = "2013", Director = " John Moore", Rating = "R", Notes = "Everyone needs to know when to quit" },

            };
        }

        public void AddDVDRepo(DVDOb dvd)
        {
            if (_dvds.Any())
            {
                dvd.DVDId = _dvds.Max(c => c.DVDId) + 1;
            }
            else
            {
                dvd.DVDId = 0;
            }

            _dvds.Add(dvd);
        }

        public void DVDDelete(int id)
        {
            _dvds.RemoveAll(c => c.DVDId == id);
        }

        public void EditDVD(DVDOb dvd)
        {
            _dvds.RemoveAll(c => c.DVDId == dvd.DVDId);
            _dvds.Add(dvd);
        }

        public List<DVDOb> GetAll()
        {
            return _dvds;
        }

        public List<DVDOb> GetAllByDirector(string director)
        {
            var dvd = _dvds.Where(c => c.Director == director).ToList();

            return dvd;
        }

        public List<DVDOb> GetAllByRating(string rating)
        {
            var dvd = _dvds.Where(c => c.Rating == rating).ToList();

            return dvd;
        }

        public List<DVDOb> GetAllByTitle(string title)
        {
            var dvd = _dvds.Where(c => c.Title == title).ToList();

            return dvd;
        }

        public List<DVDOb> GetAllByYear(string year)
        {
            var dvd = _dvds.Where(c => c.ReleaseDate == year).ToList();

            return dvd;
        }

        public DVDOb GetDVDById(int id)
        {
            return _dvds.FirstOrDefault(c => c.DVDId == id);
        }
    }
}