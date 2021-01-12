using ExplicacionCapa.BL;
using ExplicacionCapas.Transversal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace ExplicacionCapas.Api.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly UsersBL _usersBL;

        public UsersController()
        {
            _usersBL = new UsersBL();
        }

        // GET api/<controller>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(IEnumerable<UserEntity>))]
        public IHttpActionResult Get()
        {
            try
            {
                var users = _usersBL.GetUsers();

                if (users == null || users.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(UserEntity))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Id is required");
                }

                var user = _usersBL.GetUser(id);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Post([FromBody] UserEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    return BadRequest("Entity is required");
                }

                _usersBL.Create(entity);

                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, [FromBody] UserEntity entity)
        {
            try
            {
                if (id > 0)
                {
                    return BadRequest("id is required");
                }

                if (entity == null)
                {
                    return BadRequest("Entity is required");
                }

                _usersBL.Update(id, entity);

                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("")]
        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    return BadRequest("id is required");
                }

                _usersBL.Delete(id);

                return StatusCode(System.Net.HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}