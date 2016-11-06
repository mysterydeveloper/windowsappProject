using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windowsappProject.Models
{
    class Signup
    {
        public Boolean signup(ISession session, Dictionary<string,string> parameters)
        {

            string username = parameters["username"];
            var result = session.Run("MATCH (a:User) WHERE a.username = {username} RETURN a.username"
                , new Dictionary<string, object> { { "username", username } });
            int counting = result.Count();
            if (counting > 0)
            {
                return false;
            }
            else
            {
                string email = parameters["email"];
                string password = parameters["password"];
                session.Run("CREATE (a:User {email:{email}, username:{username}, password:{password}})", new Dictionary<string, object> { { "email", email  },
                { "username",username }, { "password",password } });
                return true;
            }
        }
    }
}
