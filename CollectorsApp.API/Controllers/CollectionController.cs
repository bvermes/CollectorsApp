using CollectorsApp.BLL.Interfaces;
using CollectorsApp.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using CollectorsApp.BLL.DataTransferObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CollectorsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectibleService _collectibleService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CollectionController(ICollectibleService collectibleService, IWebHostEnvironment webHostEnvironment)
        {
            _collectibleService = collectibleService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/<CollectionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollectibleDto>>> GetForSale()
        {
            return (await _collectibleService.GetCollectiblesAsync()).ToList();
        }

        [HttpGet("for-sale")]
        public async Task<ActionResult<IEnumerable<CollectibleDto>>> Get()
        {
            return (await _collectibleService.GetCollectiblesForSaleAsync()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CollectibleDto>> Get(int id)
        {
            return await _collectibleService.GetCollectibleAsync(id);
        }

        // POST api/<CollectionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CollectibleDto collectible)
        {
            await _collectibleService.AddCollectibleAsync(collectible);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CollectibleDto collectible)
        {
            await _collectibleService.UpdateColletctibleAsync(id, collectible);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _collectibleService.DeleteCollectibleAsync(id);
            return NoContent();
        }

        [HttpPost("SaveFile")]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = _webHostEnvironment.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {
                return new JsonResult("anonymous.png");
            }
        }
    }
}
