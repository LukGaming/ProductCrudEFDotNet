using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCrud.Models;
using System;
using System.IO;

namespace ProductCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly DataContext _context;
        public ImagesController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Post(List<IFormFile> images, int productId)
        {
            Product product = _context.Products.FirstOrDefault(x => x.Id == productId);
            if (product.Id > 0)
            {
                List<string> filesPath = new List<string>();
                var path = "Images";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                foreach (var image in images)
                {
                    if (image.Length > 0)
                    {
                        var filePath = Path.Combine(path, Path.GetFileName(path));
                        filesPath.Add(image.FileName);
                        using (var stream = System.IO.File.Create(path + "/" + image.FileName))
                        {
                            await image.CopyToAsync(stream);
                        }
                        Images imageToDb = new Images();
                        imageToDb.ImageName = image.FileName;
                        imageToDb.Product = product;

                        _context.Images.Add(imageToDb);
                        await _context.SaveChangesAsync();
                    }

                }
                return Ok(filesPath);
            }
            return Ok("não foi possível encontrar o produto");

        }
        [HttpDelete]
        public ActionResult Delete(int imageId)
        {
            var path = "Images";
            Images image = _context.Images.FirstOrDefault(x => x.id == imageId);
            if (image.id > 0)
            {
                if (System.IO.File.Exists(Path.Combine(path, image.ImageName)))
                {
                    System.IO.File.Delete(Path.Combine(path, image.ImageName));
                    _context.Images.Remove(image);
                    _context.SaveChanges();
                    return Ok("Imagem Removida com sucesso!");
                }
                else
                {
                    return Ok("Não foi possível remover essa imagem");
                }
            }
            else
            {
                return Ok("Não foi possível remover essa imagem");
            }

        }
    }
}
