using DVDLibrary.Models;
using DVDLibrary.Models.Data;
using DVDLibrary.Models.Interfaces;
using DVDLibrary.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DVDLibrary.Controllers
{
    public class DVDController : ApiController
    {
        private IRepository _repo;

        public DVDController(IRepository repo)
        {
            _repo = repo;
        }

        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {

            return Ok(_repo.GetAll());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            _repo.DVDDelete(id);
        }


        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDById(int id)
        {

            DVDOb found = _repo.GetDVDById(id);

            return Ok(found);
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDByTitle(string title)
        {

            List<DVDOb> found = _repo.GetAllByTitle(title);

            return Ok(found);
        }

        [Route("dvds/year/{year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDByYear(string year)
        {

            List<DVDOb> found = _repo.GetAllByYear(year);

            return Ok(found);
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDByDirector(string director)
        {

            List<DVDOb> found = _repo.GetAllByDirector(director);

            return Ok(found);
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDVDByRating(string rating)
        {

            List<DVDOb> found = _repo.GetAllByRating(rating);

            return Ok(found);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Edit(DVDOb dvd)
        {

            _repo.EditDVD(dvd);

            return Ok("Index");
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(DVDOb dvd)
        {

            _repo.AddDVDRepo(dvd);

            return Ok("Index");
        }



    }
}
