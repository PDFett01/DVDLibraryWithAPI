using DVDLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDLibrary.Models.Data;
using System.Data.Entity;

namespace DVDLibrary.Models.Repository
{
    public class EFRepository : IRepository
    {
        public void AddDVDRepo(DVDOb dvd)
        {
            DVDLibraryEntities ctx = new DVDLibraryEntities();
            var add = new DVD();

            add.Director = dvd.Director;
            add.Notes = dvd.Notes;
            add.Rating = dvd.Rating;
            add.ReleaseDate = dvd.ReleaseDate;
            add.Title = dvd.Title;

            ctx.DVDs.Add(add);
            ctx.SaveChanges();

        }

        public void DVDDelete(int id)
        {
                DVDLibraryEntities ctx = new DVDLibraryEntities();

                var dvd = new DVD() { DVDId = id };
                ctx.DVDs.Attach(dvd);
                ctx.DVDs.Remove(dvd);
                ctx.SaveChanges();


        }

        public void EditDVD(DVDOb dvd)
        {
            DVDLibraryEntities ctx = new DVDLibraryEntities();
                        
            var edit = ctx.DVDs.SingleOrDefault(d => d.DVDId == dvd.DVDId);

            edit.DVDId = dvd.DVDId;
            edit.Director = dvd.Director;
            edit.Notes = dvd.Notes;
            edit.Rating = dvd.Rating;
            edit.ReleaseDate = dvd.ReleaseDate;
            edit.Title = dvd.Title;

            ctx.Entry(edit).State = EntityState.Modified;
            ctx.SaveChanges();

        }

        public List<DVDOb> GetAll()
        {

            DVDLibraryEntities ctx = new DVDLibraryEntities();

            var dvds = ctx.DVDs.Select(x => new DVDOb()
            {
                DVDId = x.DVDId,
                Title = x.Title,
                Director = x.Director,
                Rating = x.Rating,
                Notes = x.Notes,
                ReleaseDate = x.ReleaseDate
            });

            return dvds.ToList();

        }

        public List<DVDOb> GetAllByDirector(string director)
        {
            DVDLibraryEntities ctx = new DVDLibraryEntities();

            var dvds = ctx.DVDs.Select(x => new DVDOb()
            {
                DVDId = x.DVDId,
                Title = x.Title,
                Director = x.Director,
                Rating = x.Rating,
                Notes = x.Notes,
                ReleaseDate = x.ReleaseDate
            });

            List<DVDOb> dvdbydirector = (from d in dvds
                                     where d.Director == director
                                     select d).ToList();

            return dvdbydirector;
        }

        public List<DVDOb> GetAllByRating(string rating)
        {
            DVDLibraryEntities ctx = new DVDLibraryEntities();

            var dvds = ctx.DVDs.Select(x => new DVDOb()
            {
                DVDId = x.DVDId,
                Title = x.Title,
                Director = x.Director,
                Rating = x.Rating,
                Notes = x.Notes,
                ReleaseDate = x.ReleaseDate
            });

            List<DVDOb> dvdbyrating = (from d in dvds
                                     where d.Rating == rating
                                     select d).ToList();

            return dvdbyrating;
        }

        public List<DVDOb> GetAllByTitle(string title)
        {
            DVDLibraryEntities ctx = new DVDLibraryEntities();

            var dvds = ctx.DVDs.Select(x => new DVDOb()
            {
                DVDId = x.DVDId,
                Title = x.Title,
                Director = x.Director,
                Rating = x.Rating,
                Notes = x.Notes,
                ReleaseDate = x.ReleaseDate
            });

            List<DVDOb> dvdbytitle = (from d in dvds
                                     where d.Title == title
                                     select d).ToList();

            return dvdbytitle;
        }

        public List<DVDOb> GetAllByYear(string year)
        {
            DVDLibraryEntities ctx = new DVDLibraryEntities();

            var dvds = ctx.DVDs.Select(x => new DVDOb()
            {
                DVDId = x.DVDId,
                Title = x.Title,
                Director = x.Director,
                Rating = x.Rating,
                Notes = x.Notes,
                ReleaseDate = x.ReleaseDate
            });

            List<DVDOb> dvdbyyear = (from d in dvds
                                     where d.ReleaseDate == year
                                     select d).ToList();

            return dvdbyyear;
        }

        public DVDOb GetDVDById(int id)
        {
            DVDLibraryEntities ctx = new DVDLibraryEntities();

            var dvds = ctx.DVDs.Select(x => new DVDOb()
            {
                DVDId = x.DVDId,
                Title = x.Title,
                Director = x.Director,
                Rating = x.Rating,
                Notes = x.Notes,
                ReleaseDate = x.ReleaseDate
            });

            DVDOb dvd = (from d in dvds
                         where d.DVDId == id
                         select d).FirstOrDefault();

            return dvd;

        }
    }
}