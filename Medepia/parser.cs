using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medepia
{
    
  public class parser
    {
        model.LeagueStage ls = new model.LeagueStage();
        public void parse()
        {
            string name;
            string leagueStage = "{\"id\": \"1\", \"name\": \"2017/2018 Sezonu\", \"tournamentName\": \"Spor Toto Süper Lig\",\"logo\": \"http://zmdp.cloud/iseAlim/images/1.png\"}";

            ls = JsonConvert.DeserializeObject<model.LeagueStage>(leagueStage);

           
           

        }
        public void parseTable()
        {
            string json = @"[
                {
                    'teamId':1,
                    'name':'Fenerbahçe',
                    'overall':75,
                    'teamLogo':'http://zmdp.cloud/iseAlim/images/2.png'
                 },
                {
                   'teamId':2,
                    'name':'Galatasaray',
                    'overall':74,
                    'teamLogo':'http://zmdp.cloud/iseAlim/images/3.png'
                },
                {
                    'teamId':3,
                    'name':'Beşiktaş',
                    'overall':77,
                    'teamLogo':'http://zmdp.cloud/iseAlim/images/4.png'
                },
                {   'teamId':4,
                    'name':'Mucur Gücü',
                    'overall':73,
                    'teamLogo':'http://zmdp.cloud/iseAlim/images/5.png'
                },
                {
                    'teamId':5,
                    'name':'Trabzonspor',
                    'overall':72,
                    'teamLogo':'http://zmdp.cloud/iseAlim/images/6.png'
                },
                {   'teamId':6,
                    'name':'Demir Grup Sivasspor',
                    'overall':70,
                    'teamLogo':'http://zmdp.cloud/iseAlim/images/7.png'
                }

]";



            JArray leagueTableArray = JArray.Parse(json);

            IList<model.LeagueTable> leagueTable = leagueTableArray.Select(p => new model.LeagueTable
            {
                teamId = (int)p["teamId"],
                name = (string)p["name"],
                overall = (int)p["overall"],
                teamLogo = (string)p["teamLogo"]
            }).ToList();

        }
    }
}
