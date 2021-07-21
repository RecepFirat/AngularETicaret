using AngularETicaret.Infrastructure.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularETicaret.API.Controllers
{

    public class BugeyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BugeyController(StoreContext context)
        {
            _context = context;
        }


        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            return Ok();
        }
    }
}
