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
using SQLite.Net;
using SQLite.Net.Platform.WinRT;

namespace windowsappProject.Data
{
    public class PreviousBets
    {
        public List<Bets> Previous()
        {
            List<Bets> temp=new List<Bets>();          

            using (var db = DbConnection)
            {
                // Activate Tracing 
                db.TraceListener = new DebugTraceListener();
                // Database stuff.
                // ...
                String Status="Done";
                // Create the table if it does not exist 
                var c = db.CreateTable<Bets>();
                var info = db.GetMapping(typeof(Bets));
                Bets BETS = new Bets();
                BETS.Person1 = "MANUS";
                BETS.Person2 = "AOIFE";
                BETS.BetName = "FUNNY";
                BETS.Date = new DateTime();
                BETS.Status = "Done";
                var i = db.InsertOrReplace(BETS);

                temp= (from p in db.Table<Bets>() where p.Status==Status select p).ToList();
            }
            return temp;
        }

        private static SQLiteConnection DbConnection
        {
            get
            {
                return new SQLiteConnection(
                    new SQLitePlatformWinRT(),
                    Path.Combine(ApplicationData.Current.LocalFolder.Path, "Storage.sqlite"));
            }
        }

    }
    public class DebugTraceListener : ITraceListener
    {
        public void Receive(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
