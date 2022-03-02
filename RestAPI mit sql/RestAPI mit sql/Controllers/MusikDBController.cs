using Microsoft.AspNetCore.Mvc;
using RestAPI_mit_sql.Models;
using System.Collections;

namespace RestAPI_mit_sql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusikDBController : ControllerBase
    {

        private readonly ILogger<MusikDBController> _logger;

        public MusikDBController(ILogger<MusikDBController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetMusikDB")]
        public List<TableMusikDB> Get()
        {

            SqlConnector sqlConnector = new SqlConnector();
            
            var Musik = sqlConnector.ReadData();
            return Musik;
            

        }
    }
}