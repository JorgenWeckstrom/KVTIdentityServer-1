using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomIdentityServer4.UserServices
{
    public sealed class UserRepository : IUserRepository
    {
        // some dummy data. Replce this with your user persistence. 
        private static List<KvtUser> _users = new List<KvtUser>
        {
            new KvtUser{
                SubjectId = "100",
              //  UserName = "jaya",
                Password = "jaya12",
                Email = "jayapradhareddy@gmail.com"
            },
            new KvtUser{
                SubjectId = "101",
               // UserName = "amar",
                Password = "amar12",
                Email = "amarnath.valluri@gmail.com"
            },
        };
 
        public bool ValidateCredentials(string email, string password)
        {
            var user = FindByEmail(email);
            if (user != null)
            {
                return user.Password.Equals(password);
            }

            return false;
        }

        public KvtUser FindBySubjectId(string subjectId)
        {
            return _users.FirstOrDefault(x => x.SubjectId == subjectId);
        }

        public KvtUser FindByEmail(string email)
        {
            return _users.FirstOrDefault(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
        public static void AddUser(KvtUser user)
        {
            _users.Add(user);
        }

        public static IEnumerable<KvtUser> GetUsers()
        {
            return _users;
        }
    }

}