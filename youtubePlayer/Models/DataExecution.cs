using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace youtubePlayer.Models
{
    public class DataExecution
    {
        public int CalculateRemainingAge (int par)
        {
            int Remaining = 100 - par;
            return Remaining;
        }
    }
}
