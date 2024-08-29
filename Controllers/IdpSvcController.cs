using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace idpserviceapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdpSvcController : ControllerBase
    {
        // GET: api/<IdpSvcController>
        [Route("~/ValidateToken")]
        [HttpGet]
        public string Get(string token)
        {
            return "success";
        }


        // GET: api/<IdpSvcController>
        [Route("~/ReturnRoles")]
        [HttpGet]
        public IActionResult GetRoles(string upn)
        {
            var roles = GetUserRoles()
                .Select(role => new { RoleName = role.Name })
                .ToList();

            var jsonResult = JsonSerializer.Serialize(roles);

            return Content(jsonResult, "application/json");
        }
    

        // Assuming you have a method to get user roles
        private List<Role> GetUserRoles()
        {
            // This method should return a list of roles
            // Replace this with your actual implementation
            return new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "User" }
            };
        }


        public class Role
        {
            public string Name { get; set; }
        }


    }
}
