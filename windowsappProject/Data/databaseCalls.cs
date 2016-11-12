using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace windowsappProject.Data
{
    class databaseCalls
    {
        Signup s = new Signup();
        login l = new login();

        public databaseCalls()
        {}

        public bool posttoneo4j(string posting, Dictionary<string, string> parameters)
        {
            using (var driver = GraphDatabase.Driver("bolt://localhost", AuthTokens.Basic("neo4j", "manus")))
            using (var session = driver.Session())
            {
                if (posting == "signup")
                {
                    bool signup =s.signup(session, parameters);
                    return signup;
                }
                else if (posting == "Login")
                {
                    var result = l.Login(session, parameters);
                    foreach (var record in result)
                    {
                        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
                        localSettings.Values["#username"] = record["username"].As<string>();
                        localSettings.Values["#email"] = record["email"].As<string>();

                        //Debug.WriteLine($"{record["title"].As<string>()} {record["name"].As<string>()}");
                        return true;
                    }
                    return false;
                }
                return false;
            }

        }



        }
}
