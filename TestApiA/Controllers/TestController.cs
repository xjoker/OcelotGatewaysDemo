using System;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace TestApiA.Controllers
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
        public IActionResult Get()
        {
            var r = new BaseResultModel(
                $"TestApiA - {DateTime.Now} - {Request.HttpContext.Connection.LocalIpAddress}:{Request.HttpContext.Connection.LocalPort}");

            return Ok(r);
        }
    }
}