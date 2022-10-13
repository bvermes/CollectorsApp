using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectorsApp.DAL.Entities
{
    public class Team
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

        public Team(int id, string teamname, int matches_played, double overall, double attackingRating, double midfieldRating, double defenceRating, double clubWorth, double xIAverageAge, double defenceWidth, double defenceDepth, double offenceWidth, double likes, double dislikes, double avgoals, double avconceded, double avgoalattempts, double avshotsongoal, double avshotsoffgoal, double avblockedshots, double avpossession, double avfreekicks, double avGoalDiff, double avwins, double avdraws, double avloses)
        {
            Id = id;
            Teamname = teamname;
            Matches_played = matches_played;
            Overall = overall;
            AttackingRating = attackingRating;
            MidfieldRating = midfieldRating;
            DefenceRating = defenceRating;
            ClubWorth = clubWorth;
            XIAverageAge = xIAverageAge;
            DefenceWidth = defenceWidth;
            DefenceDepth = defenceDepth;
            OffenceWidth = offenceWidth;
            Likes = likes;
            Dislikes = dislikes;
            this.avgoals = avgoals;
            this.avconceded = avconceded;
            this.avgoalattempts = avgoalattempts;
            this.avshotsongoal = avshotsongoal;
            this.avshotsoffgoal = avshotsoffgoal;
            this.avblockedshots = avblockedshots;
            this.avpossession = avpossession;
            this.avfreekicks = avfreekicks;
            this.avGoalDiff = avGoalDiff;
            this.avwins = avwins;
            this.avdraws = avdraws;
            this.avloses = avloses; 
        }
    }
}
