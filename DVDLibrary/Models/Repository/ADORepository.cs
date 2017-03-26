using DVDLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DVDLibrary.Models.Data;
using System.Data.SqlClient;
using DVDLibrary.Config;
using System.Data;

namespace DVDLibrary.Models.Repository
{
    public class ADORepository : IRepository
    {
        
        public List<DVDOb> GetAll()
        {
            List<DVDOb> dvd = new List<DVDOb>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetAllDVDs";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvd.Add(PopulateFromDataReader(dr));
                    }
                }
            }
            return dvd;
        }

        public List<DVDOb> GetAllByTitle(string title)
        {
            List<DVDOb> dvd = new List<DVDOb>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetAllDVDsByTitle";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@Title", title);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvd.Add(PopulateFromDataReader(dr));
                    }
                }
            }
            return dvd;
        }

        public List<DVDOb> GetAllByYear(string year)
        {
            List<DVDOb> dvd = new List<DVDOb>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetAllDVDsByYear";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@ReleaseDate", year);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvd.Add(PopulateFromDataReader(dr));
                    }
                }
            }
            return dvd;
        }

        public List<DVDOb> GetAllByDirector(string director)
        {
            List<DVDOb> dvd = new List<DVDOb>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetAllDVDsByDirector";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@Director", director);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvd.Add(PopulateFromDataReader(dr));
                    }
                }
            }
            return dvd;
        }

        public List<DVDOb> GetAllByRating(string rating)
        {
            List<DVDOb> dvd = new List<DVDOb>();

            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetAllDVDsByRating";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@Rating", rating);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvd.Add(PopulateFromDataReader(dr));
                    }
                }
            }
            return dvd;
        }

        public DVDOb GetDVDById(int id)
        {
            DVDOb dvd = new DVDOb();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetDVDById";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@DVDId", id);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        dvd = PopulateFromDataReader(dr);
                    }

                }
            }
            return dvd;
        }

        public void DVDDelete(int id)
        {
            DVDOb dvd = new DVDOb();

            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DeleteDVD";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@DVDId", id);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        dvd = PopulateFromDataReader(dr);
                    }

                }
            }
            return;
        }


        public void EditDVD(DVDOb dvd)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "EditDVD";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DVDId", dvd.DVDId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseDate", dvd.ReleaseDate);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void AddDVDRepo(DVDOb dvd)
        {
            using (var cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "AddDVD";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@ReleaseDate", dvd.ReleaseDate);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
            }

        public DVDOb PopulateFromDataReader(SqlDataReader dr)
        {
            DVDOb dvd = new DVDOb();

            dvd.DVDId = (int)dr["DVDId"];
            dvd.Title = dr["Title"].ToString();
            dvd.ReleaseDate = dr["ReleaseDate"].ToString();
            dvd.Director = dr["Director"].ToString();
            dvd.Rating = dr["Rating"].ToString();
            dvd.Notes = dr["Notes"].ToString();

            return dvd;
        }

    }
}