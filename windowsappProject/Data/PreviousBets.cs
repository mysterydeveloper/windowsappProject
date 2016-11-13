using Neo4j.Driver.V1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using windowsappProject.Model;
using SQLitePCL;

namespace windowsappProject.Data
{
    public class PreviousBets
    {
        public List<Bets> Previous()
        {
            List<Bets> temp=new List<Bets>();

            temp.Add(new Bets() { BetName = "hello", Person1 = "manus", Person2 = "callon" });
            temp.Add(new Bets() { BetName = "hello", Person1 = "manus", Person2 = "callon" });
            temp.Add(new Bets() { BetName = "hello", Person1 = "manus", Person2 = "callon" });
            temp.Add(new Bets() { BetName = "hello", Person1 = "manus", Person2 = "callon" });
            temp.Add(new Bets() { BetName = "hello", Person1 = "manus", Person2 = "callon" });
            temp.Add(new Bets() { BetName = "hello", Person1 = "manus", Person2 = "callon" });
            SQLiteConnection connection = new SQLiteConnection("Bets.db");
           
            string ssql = "CREATE TABLE IF NOT EXISTS Betting (IDBet Integer Primary Key AutoIncrement Not Null+Person1 Varchar(100)+Person1 Varchar(100)+Person2 Varchar(100)+Betname Varchar(100) )";

            string Query = "select Betname,Person1,Person2 from Betting";

            ISQLiteStatement istate = connection.Prepare(ssql);

            istate.Step();

            istate = connection.Prepare(Query);


            istate.Step();

            /*using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var Betnames = reader.GetString(0);
                    var p1 = reader.GetString(1);
                    var p2 = reader.GetString(2);
                    Debug.WriteLine(Betnames+p1+p2);
                    temp.Add(new Bets() { BetName = Betnames,Person1=p1,Person2=p2 });
                }
            }*/
            return temp;
        }

    }
}
