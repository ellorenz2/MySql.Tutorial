using Microsoft.AspNetCore.Mvc;
using MySql.Tutorial.Data;
using MySql.Tutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MySql.Tutorial.Web.Controllers
{
 

    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {

        public static string connectionString = "Data Source=localhost;Database=tutorial_db;userid=xxxx;password=xxxxx";

        // GET: api/<UserDataController>
        [HttpGet]
        public IEnumerable<UserDataModel> Get()
        {

            MinimalDataContext minimalDataContext = new MinimalDataContext(connectionString);

            return minimalDataContext.GetUserData();
        }

        // GET api/<UserDataController>/5
        [HttpGet("{id}")]
        public UserDataModel Get(int id)
        {
            MinimalDataContext minimalDataContext = new MinimalDataContext(connectionString);

            UserDataModel model = new UserDataModel();
            model.Id = id;

            var result = minimalDataContext.GetUserData(model);

            return result;

        }

        // POST api/<UserDataController>
        [HttpPost]
        public void Post([FromBody] UserDataModel value)
        {


            MinimalDataContext minimalDataContext = new MinimalDataContext(connectionString);

            minimalDataContext.Insert(value);

        }

        // PUT api/<UserDataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDataModel value)
        {
            MinimalDataContext minimalDataContext = new MinimalDataContext(connectionString);

            minimalDataContext.Update(value);
        }

        // DELETE api/<UserDataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            MinimalDataContext minimalDataContext = new MinimalDataContext(connectionString);

            UserDataModel model = new UserDataModel();
            model.Id = id;

            minimalDataContext.Delete(model);
        }
    }
}
