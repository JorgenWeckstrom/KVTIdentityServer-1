using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace CustomIdentityServer4.UserServices
{
    public class KvtUser
    {
        [RequiredAttribute(ErrorMessage="SubjectId can't be empty")]
        public string SubjectId { get; set; }
        //  public string UserName { get;
        [RequiredAttribute(ErrorMessage = "Password can't be empty")] 
        public string Password { get; set; }
        
        [RequiredAttribute(ErrorMessage = "Email can't be empty")]
        [EmailAddressAttribute(ErrorMessage = "Enter valid email address")]
        public string Email { get; set; }
    }


}
