using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MeetupsApi.Models;
using MeetupsApi.Data;


namespace MeetupsApi.Controllers
{
    [ApiController]
    
    [Route("[controller]")]
    public class OrganizerController : ControllerBase
    {
        [HttpGet]        
        [Route("api/getAll")]
        public ActionResult<List<Meetups>> GetAllMetups()
        {
            var metupModel = new MeetupModel();
            return metupModel.GetAll();
        }

        [HttpGet]
        [Route("api/create")]
        public ActionResult<String> Create(int userOrganizer, string title,int canceled)
        {
            var metupModel = new MeetupModel();
            return metupModel.Create( userOrganizer,  title, canceled);            
        }

        [HttpGet]
        [Route("api/cancel")]
        public ActionResult<String> Cancel(int id)
        {
            var metupModel = new MeetupModel();
            return metupModel.Cancel(id);
        }

        [HttpGet]
        [Route("api/update")]
        public ActionResult<String> Update(string title,int id)
        {
            var metupModel = new MeetupModel();
            return metupModel.Update(id ,title);
        }

        [HttpGet]
        [Route("api/delete")]
        public ActionResult<String> Delete(int id)
        {
            var metupModel = new MeetupModel();
            return metupModel.Delete(id);

        }
        
    }
}
