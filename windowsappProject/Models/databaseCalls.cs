using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windowsappProject.Models
{
    class databaseCalls
    {
        Signup s = new Signup();
        login l = new login();

        public databaseCalls()
        {}

        public void posttoneo4j(string posting, Dictionary<string, string> parameters)
        {
            using (var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "manus")))
            using (var session = driver.Session())
            {
                if (posting == "signup")
                {
                    s.signup(session, parameters);
                }
                else if (posting == "Login")
                {
                    var result = l.Login(session, parameters);
                    foreach (var record in result)
                    {
                        Debug.WriteLine($"{record["title"].As<string>()} {record["name"].As<string>()}");
                    }
                    
                }

            }

        }
       

        
    }
}
