using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
//using System.Web.Http.Filters;
using CustomIdentityServer4.UserServices;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KVTIdenityserver
{
    [EnableCors("MyPolicy")]
    [Route("api/RegisterUser")]
    public class RegisterUserController : ControllerBase 
    {
        public HttpResponseMessage Put([FromBody] KvtUser user)
        {
            if (ModelState.IsValid)
            {
                UserRepository.AddUser(user);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
            {
                return new HttpResponseMessage((HttpStatusCode.BadRequest)); 
            }

        }
    }

    [Route("api/GetUsers")]
    public class KVTGetUsersController : ControllerBase
    {
        public IEnumerable<KvtUser> Get()
        {
            return UserRepository.GetUsers();
        }
    }
    [EnableCors("MyPolicy")]
    [Route("api/LoginUser")]
    public class KVTLoginController : ControllerBase
    {
        public void Put(KvtUser user)
        {
            HttpContext.Session.SetString("Email", user.Email);
            HttpContext.Session.SetString("Password", user.Password);
        }
    }

}
