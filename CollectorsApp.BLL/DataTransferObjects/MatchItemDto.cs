using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsApp.BLL.DataTransferObjects
{
    public class MatchItemDto
    {
        public string HomeTeamName { get; set; }
        public string GuestTeamName { get; set; }

        public double HomeBetOdds { get; set; }
        public double GuestBetOdds { get; set; }
        public double DrawBetOdds { get; set; }
    }
}
