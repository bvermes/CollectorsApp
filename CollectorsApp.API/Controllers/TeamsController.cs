using CollectorsApp.BLL.DataTransferObjects;
using CollectorsApp.BLL.Interfaces;
using CollectorsApp.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollectorsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamsService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TeamsController(ITeamService teamsService, IWebHostEnvironment webHostEnvironment)
        {
            _teamsService = teamsService;
            _webHostEnvironment = webHostEnvironment;   
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDto>>> Get()
        {
            return (await _teamsService.GetTeamsAsync()).ToList();
        }
        
        [HttpPost("modelresults")]
        public MatchItem GetModelResults([FromBody] MatchItemDto match)
        {
            var modelResults =  Option1_ExecProcess(match);
            return modelResults;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task Post([FromBody] TeamDto team)
        {
            await _teamsService.AddTeamAsync(team);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [NonAction]
        static MatchItem Option1_ExecProcess(MatchItemDto match)
        {

            string correctlanguage(string name){
                string correctname;
                switch (name)
                {
                    case "Alaves":
                        correctname = "Deportivo Alavés";
                        break;
                    case "Almeria": correctname = "Unión Deportiva Almería"; break;
                    case "Ath_Bilbao": correctname = "Athletic Club de Bilbao"; break;
                    case "Atl_Madrid": correctname = "Atlético de Madrid"; break;
                    case "Barcelona": correctname = "FC Barcelona"; break;
                    case "Betis": correctname = "Real Betis Balompié"; break;
                    case "Cadiz_CF": correctname = "Cádiz CF"; break;
                    case "Celta_Vigo": correctname = "RC Celta de Vigo"; break;
                    case "Cordoba": correctname = "Córdoba CF"; break;
                    case "Dep_La_Coruna": correctname = "Deportivo de La Coruña"; break;
                    case "Eibar": correctname = "SD Eibar"; break;
                    case "Elche": correctname = "Elche CF"; break;
                    case "Espanyol": correctname = "RCD Espanyol de Barcelona"; break;
                    case "Getafe": correctname = "Getafe CF"; break;
                    case "Gijon": correctname = "Real Sporting de Gijón"; break;
                    case "Girona": correctname = "Girona FC"; break;
                    case "Granada_CF": correctname = "Granada CF"; break;
                    case "Huesca": correctname = "SD Huesca"; break;
                    case "Las_Palmas": correctname = "Unión Deportiva Las Palmas"; break;
                    case "Leganes": correctname = "CD Leganés"; break;
                    case "Levante": correctname = "Levante Unión Deportiva"; break;
                    case "Malaga": correctname = "Málaga CF"; break;
                    case "Mallorca": correctname = "RCD Mallorca"; break;
                    case "Osasuna": correctname = "CA Osasuna"; break;
                    case "Rayo_Vallecano": correctname = "Rayo Vallecano"; break;
                    case "Real_Madrid": correctname = "Real Madrid CF"; break;
                    case "Real_Sociedad": correctname = "Real Sociedad"; break;
                    case "Sevilla": correctname = "Sevilla FC"; break;
                    case "Valencia": correctname = "Valencia CF"; break;
                    case "Valladolid": correctname = "Real Valladolid CF"; break;
                    case "Villarreal": correctname = "Villarreal CF"; break;
                    default:
                        correctname = "nothing";
                        break;
                }
                return correctname;
            }
            // 1) Create Process Info
            var psi = new ProcessStartInfo();
            psi.FileName = @"E:\Programs\Python\Python310\python.exe";

            // 2) Provide script and arguments
            var script = @"E:\Desktop\Onlab2\CollectorsApp\CollectorsApp\CollectorsApp.API\model\script.py";
            //var start = "2019-1-1";
            //var end = "2019-1-22";

            //DaysBetweenDates
            //scrpit
            //psi.Arguments = $"\"{script}\" \"{start}\" \"{end}\"";

            Console.WriteLine(match.HomeBetOdds + "\n");
            Console.WriteLine(match.DrawBetOdds + "\n");
            Console.WriteLine(match.GuestBetOdds + "\n");
            Console.WriteLine(match.HomeTeamName + "\n");
            Console.WriteLine(match.GuestTeamName + "\n");
            match.HomeTeamName = correctlanguage(match.HomeTeamName);
            match.GuestTeamName = correctlanguage(match.GuestTeamName);
            Console.WriteLine(match.HomeTeamName + "\n");
            Console.WriteLine(match.GuestTeamName + "\n");

            psi.Arguments = $"\"{script}\" \"{match.HomeBetOdds}\" \"{match.DrawBetOdds}\" \"{match.GuestBetOdds}\" \"{match.HomeTeamName}\" \"{match.GuestTeamName}\"";

            // 3) Process configuration
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            // 4) Execute process and get output
            var errors = "";
            var results = "";

            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            // 5) Display output
            Console.WriteLine("ERRORS:");
            Console.WriteLine(errors);
            string[] words = results.Split('\n');
            Console.WriteLine(results);
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";
            double homeodds = 0;
            double drawodds = 0;
            double awayodds = 0;
            foreach (string word in words)
            {
                Console.WriteLine(word);
                if(word.Length > 10)
                {
                    if (word.Substring(0, 8) == "homeodds")
                    {
                        homeodds = Convert.ToDouble(word.Substring(9, 13), provider);
                    }
                    if (word.Substring(0, 8) == "drawodds")
                    {
                        drawodds = Convert.ToDouble(word.Substring(9, 13), provider);
                    }
                    if (word.Substring(0, 8) == "awayodds")
                    {
                        awayodds = Convert.ToDouble(word.Substring(9, 13), provider);
                    }

                }
            }
            Console.WriteLine(homeodds);
            Console.WriteLine(drawodds);
            Console.WriteLine(awayodds);
            /*double homeo = Convert.ToDouble(words[4].Substring(0, 4));/*
            double homeodds;
            if (Double.TryParse(words[4].Substring(0, 4), out homeodds))
            {
                homeo = homeodds;
            }
            else
            {
                homeo = 0;
            }
            //.Replace(" ", String.Empty)
            //Double.TryParse(homeoraw, out homeodds);
            Console.WriteLine($"<{words[4].Substring(0, 4)}>");
            //Console.WriteLine($"<{homeo}>");
            Console.WriteLine($"<{harom}>");*/
            Console.WriteLine($"<{homeodds}>");
            Console.WriteLine($"<{drawodds}>");
            Console.WriteLine($"<{awayodds}>");
            MatchItem matchresults = new MatchItem(match.HomeTeamName, match.GuestTeamName, homeodds, drawodds, awayodds);
            return matchresults;
        }

    }
}
