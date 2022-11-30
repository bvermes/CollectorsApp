using CollectorsApp.BLL.Interfaces;
using CollectorsApp.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using CollectorsApp.BLL.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Diagnostics;

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
        public async Task<ActionResult<CollectibleDto>> Post([FromForm] CollectibleDto collectible)
        {
            collectible.ImageName = await SaveImage(collectible.ImageFile);
            await _collectibleService.AddCollectibleAsync(collectible);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm]CollectibleDto collectible)
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
        //https://www.youtube.com/watch?v=ORVShW0Yjaw&list=WL&index=45&ab_channel=CodAffection
        //https://github.com/CodAffection/React-Asp.Net-Core-API---Image-Upload-Retrieve-Update-and-Delete-/blob/master/EmployeeRegisterAPI/EmployeeRegisterAPI/Controllers/EmployeeController.cs

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }




    }
}
