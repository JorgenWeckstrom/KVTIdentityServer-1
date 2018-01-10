using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomIdentityServer4.UserServices
{
    public interface IUserRepository
    {
        bool  ValidateCredentials(string email, string password);
       KvtUser FindBySubjectId(string subjectId);
        //  KvtUser FindByUsername(string username);
        KvtUser FindByEmail(string email);

    }
    
}
