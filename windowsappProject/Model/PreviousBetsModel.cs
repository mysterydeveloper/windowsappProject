using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using windowsappProject.Data;

namespace windowsappProject.Model
{
    public class PreviousBetsModel
    {
        public List<Bets> Betting { get; set; }
        PreviousBets pb;

        public PreviousBetsModel()
        {
            pb = new PreviousBets();
            Betting=pb.Previous();
        }
    }
}
