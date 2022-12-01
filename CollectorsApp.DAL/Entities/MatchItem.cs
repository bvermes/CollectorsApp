using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsApp.DAL.Entities
{
    public class MatchItem
    {
        public string HomeTeamName { get; set; }
        public string GuestTeamName { get; set; }

        public double HomeBetOdds { get; set; }
        public double GuestBetOdds { get;set; }
        public double DrawBetOdds { get; set; }

        public MatchItem(string homeTeamName, string guestTeamName, double homeBetOdds, double guestBetOdds, double drawBetOdds)
        {
            HomeTeamName = homeTeamName;
            GuestTeamName = guestTeamName;
            HomeBetOdds = homeBetOdds;
            GuestBetOdds = guestBetOdds;
            DrawBetOdds = drawBetOdds;
        }
    }
}
