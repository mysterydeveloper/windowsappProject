using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windowsappProject.Data
{
    class login
    {
        public IStatementResult Login(ISession session, Dictionary<string, string> parameters)
        {

            string username = parameters["username"];
            string password = parameters["password"];
            var result = session.Run("MATCH (a:User) WHERE a.username = {username} AND a.password={password} RETURN a.username AS username, a.email AS email"
                , new Dictionary<string, object> { { "username", username }, { "password", password } });
            return result;
        }
    }
}
