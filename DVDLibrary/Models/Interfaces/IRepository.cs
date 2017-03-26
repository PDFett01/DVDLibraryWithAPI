using DVDLibrary.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Interfaces
{
    public interface IRepository
    {

        List<DVDOb> GetAll();
        List<DVDOb> GetAllByTitle(string title);
        List<DVDOb> GetAllByYear(string year);
        List<DVDOb> GetAllByDirector(string director);
        List<DVDOb> GetAllByRating(string rating);
        DVDOb GetDVDById(int id);
        void  DVDDelete(int id);
        void EditDVD(DVDOb dvd);
        void AddDVDRepo(DVDOb dvd);


    }
}
