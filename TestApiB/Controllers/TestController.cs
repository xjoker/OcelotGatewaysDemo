using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TestApiB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("HealthCheck")]
        public string HealthCheck()
        {
            return "OK";
        }

        [HttpGet]
        public string Get()
        {
            var r = new
            {
                data =
                    $"TestApiB - {DateTime.Now} - {Request.HttpContext.Connection.LocalIpAddress}:{Request.HttpContext.Connection.LocalPort}"
            };

            return JsonConvert.SerializeObject(r);
        }
    }
}