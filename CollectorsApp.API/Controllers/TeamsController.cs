using CollectorsApp.BLL.DataTransferObjects;
using CollectorsApp.BLL.Interfaces;
using CollectorsApp.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
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
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            double homeodds = Convert.ToDouble(words[3].Substring(0, 5), provider);
            double drawodds = Convert.ToDouble(words[4].Substring(0, 5), provider);
            double awayodds = Convert.ToDouble(words[5].Substring(0, 5), provider);
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
            MatchItem matresults = new MatchItem(match.HomeTeamName, match.GuestTeamName, homeodds, drawodds, awayodds);
            return matresults;
        }

    }
}
