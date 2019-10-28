using Carmax.API.Data;
using Carmax.API.Models;
using System.Web.Http;

namespace Carmax.API.Web.Controllers
{
    public class ContactsController : ApiController
    {
        private IDbContext _dbContext { get; set; }
        public ContactsController()
        {
            _dbContext = new DbContext() ;
        }

        public ContactsController(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET api/contacts
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_dbContext.GetContacts());
        }

        // GET api/contact/1
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_dbContext.GetContactById(id));
        }

        // POST api/contact
        [HttpPost]
        public IHttpActionResult Post([FromBody]Contact contact)
        {
            return Ok(_dbContext.AddContact(contact));
        }

        // PUT api/contact/1
        [HttpPut]
        public IHttpActionResult Put([FromUri]int id, [FromBody]Contact contact)
        {
            contact.Id = id;
            return Ok(_dbContext.UpdateContact(contact));
        }

        // DELETE api/contact/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_dbContext.DeleteContact(id));
        }
    }
}
