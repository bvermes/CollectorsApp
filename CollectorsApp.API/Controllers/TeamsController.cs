using CollectorsApp.BLL.DataTransferObjects;
using CollectorsApp.BLL.Interfaces;
using CollectorsApp.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

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
        
        [HttpGet("modelresults")]
        public string GetModelResults()
        {
            var modelResults = Option1_ExecProcess();
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
        static string Option1_ExecProcess()
        {
            // 1) Create Process Info
            var psi = new ProcessStartInfo();
            psi.FileName = @"D:\Program Files\Python\Python310\python.exe";

            // 2) Provide script and arguments
            var script = @"E:\Desktop\Onlab2\CollectorsApp\CollectorsApp.API\model\DaysBetweenDates.py";
            var start = "2019-1-1";
            var end = "2019-1-22";

            psi.Arguments = $"\"{script}\" \"{start}\" \"{end}\"";

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
            Console.WriteLine();
            Console.WriteLine("Results:");
            Console.WriteLine(results);
            return results;
        }
    }
}
