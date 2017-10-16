using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecretService.Services;
using SecretService.Data;

namespace SecretService.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private UserService _service;
        StopService _stopService;

        public UserController(UserService userService, StopService stopService)
        {
            _service = userService;
            _stopService = stopService;
        }

        [HttpGet("[action]")]
        public IEnumerable<Stop> Get()
        {
            return _stopService.Get();
        }
    }
}