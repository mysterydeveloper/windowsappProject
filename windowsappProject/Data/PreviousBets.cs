using Microsoft.Data.Sqlite;
using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace windowsappProject.Data
{
    public class PreviousBets
    {
        public List<Bets> Previous()
        {
            List<Bets> temp=new List<Bets>();
            using (var connection = new SqliteConnection("Data Source=Bets.db"))
            {
                var command = connection.CreateCommand();
                command.CommandText = "select Betname,Person1,Person2 from Betting where Done='yes' ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Betnames = reader.GetString(0);
                        var p1 = reader.GetString(1);
                        var p2 = reader.GetString(2);
                        Debug.WriteLine(Betnames+p1+p2);
                        temp.Add(new Bets() { BetName = Betnames,Person1=p1,Person2=p2 });
                    }
                }
            }
            return temp;
        }

    }
}
