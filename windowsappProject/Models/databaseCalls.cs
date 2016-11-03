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

        public databaseCalls()
        {
            
        }

        public void posttoneo4j(string posting)
        {
            using (var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "manus")))
            using (var session = driver.Session())
            {
                if(posting =="test") {
                    testposting(session);
                }
                else if (posting == "signup")
                {
                    s.signup(session);
                }

            }

        }
        public void testposting(ISession session)
        {
           
            string name = "manus";
            string title = "mr";
            session.Run("CREATE (a:Person {name:{name}, title:{title}})",new Dictionary<string, object> { { "name", name  }, {"title",
                title } });
            var result = session.Run("MATCH (a:Person) WHERE a.name = 'Arthur' RETURN a.name AS name, a.title AS title");

            foreach (var record in result)
            {
                Debug.WriteLine($"{record["title"].As<string>()} {record["name"].As<string>()}");
            }
        }

        
    }
}
