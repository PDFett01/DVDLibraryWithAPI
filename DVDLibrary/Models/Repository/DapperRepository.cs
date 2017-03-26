using DVDLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDLibrary.Models.Data;
using System.Data.SqlClient;
using DVDLibrary.Config;
using Dapper;
using System.Data;

namespace DVDLibrary.Models.Repository
{
    public class DapperRepository : IRepository
    {
        public void AddDVDRepo(DVDOb dvd)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();

               
                parameters.Add("@Title", dvd.Title);
                parameters.Add("@ReleaseDate", dvd.ReleaseDate);
                parameters.Add("@Director", dvd.Director);
                parameters.Add("@Rating", dvd.Rating);
                parameters.Add("@Notes", dvd.Notes);

                cn.Execute("AddDVD", parameters, commandType: CommandType.StoredProcedure);

               
            }
        }
        public void DVDDelete(int id)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@DVDId", id);

                cn.Execute("DeleteDVD", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void EditDVD(DVDOb dvd)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@DVDId", dvd.DVDId);
                parameters.Add("@Title", dvd.Title);
                parameters.Add("@Director", dvd.Director);
                parameters.Add("@Rating", dvd.Rating);
                parameters.Add("@ReleaseDate", dvd.ReleaseDate);
                parameters.Add("@Notes", dvd.Notes);

                cn.Execute("EditDVD", parameters, commandType: CommandType.StoredProcedure);

            }
        }

        public List<DVDOb> GetAll()
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();

                return cn.Query<DVDOb>("GetAllDVDs", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<DVDOb> GetAllByDirector(string director)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Director", director);

                return cn.Query<DVDOb>("GetAllDVDsByDirector", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<DVDOb> GetAllByRating(string rating)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Rating", rating);

                return cn.Query<DVDOb>("GetAllDVDsByRating", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<DVDOb> GetAllByTitle(string title)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Title", title);

                return cn.Query<DVDOb>("GetAllDVDsByTitle", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<DVDOb> GetAllByYear(string year)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@ReleaseDate", year);

                return cn.Query<DVDOb>("GetAllDVDsByYear", parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public DVDOb GetDVDById(int id)
        {
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@DVDId", id);

                return cn.Query<DVDOb>("GetDVDById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}