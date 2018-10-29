using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medepia
{
   public class model
    {
        
        public class LeagueTable
        {
            public int teamId { get; set; }
            public string name { get; set; }
            public int overall { get; set; }
            public string teamLogo { get; set; }
            public int score {get;set; }
            public int playedMatch { get; set; }
            public int win { get; set; }
            public int loss { get; set; }
            public int onTerms { get; set; }
        }
        public class LeagueStage
        {
            public int id { get; set; }
            public string name { get; set; }
            public string tournamentName { get; set; }
            public string logo { get; set; }
          
                
            

            public IList<LeagueTable> leagueTable { get; set; }
        }

        public class Example
        {
            public IList<LeagueStage> leagueStage { get; set; }
        }

        public class deneme
        {
            public string teamName { get; set; }
            public int score { get; set; }
        }
    }
}
