using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsApp.BLL.DataTransferObjects
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Teamname { get; set; }
        public int Matches_played { get; set; }
        public double Overall { get; set; }
        public double AttackingRating { get; set; }
        public double MidfieldRating { get; set; }
        public double DefenceRating { get; set; }
        public double ClubWorth { get; set; }
        public double XIAverageAge { get; set; }
        public double DefenceWidth { get; set; }

        public double DefenceDepth { get; set; }
        public double OffenceWidth { get; set; }
        public double Likes { get; set; }
        public double Dislikes { get; set; }
        public double avgoals { get; set; }
        public double avconceded { get; set; }
        public double avgoalattempts { get; set; }
        public double avshotsongoal { get; set; }
        public double avshotsoffgoal { get; set; }
        public double avblockedshots { get; set; }

        public double avpossession { get; set; }
        public double avfreekicks { get; set; }
        public double avGoalDiff { get; set; }
        public double avwins { get; set; }
        public double avdraws { get; set; }
        public double avloses { get; set; }
    }
}
