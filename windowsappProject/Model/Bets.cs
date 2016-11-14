using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace windowsappProject.Model
{
    public class Bets
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String BetName { get; set; }
        public String Person1 { get; set; }
        public String Person2 { get; set; }
        public String Status { get; set; }
        public DateTime Date { get; set; }

    }
}
