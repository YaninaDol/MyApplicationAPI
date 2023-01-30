using JWT_Token.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RepositoriesLibrary.Interfaces;
using RepositoriesLibrary.Models;
using System.Security.Claims;

namespace MyApplicationAPI.Controllers
{
    [ApiController,Authorize]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        [HttpGet]
        [Route("ProductsList")]
        public async Task<ActionResult<IEnumerable<Product>>> ProductsList()
        {
            var nameIdentifier = this.HttpContext.User.Claims
           .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);


            
                return  _unitOfWork.prodRep.GetAll().ToList();
            

        }

        [HttpPost]
        [Route("Buy")]

        public IResult Buy([FromForm] int ID, [FromForm] int UserID)

        {
          //  var nameIdentifier = this.HttpContext.User.Claims
          //.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            
                if (_unitOfWork.prodRep.Buy(ID, UserID))
                {
                    _unitOfWork.Commit();
                    return Results.Ok();
                }
            else
                return Results.BadRequest();
            
        }

        [HttpGet]
        [Route("GetByCategory")]

        public IActionResult GetByCategory(int ID)
        {
            // var nameIdentifier = this.HttpContext.User.Claims
            //.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);


            if (_unitOfWork.prodRep.GetByCategory(ID) != null)
            {
                return Ok( _unitOfWork.prodRep.GetByCategory(ID));
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("Add")]

        public IResult Add(string Name, float price, string image, int categoryId)
        {
            //   var nameIdentifier = this.HttpContext.User.Claims
            //.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            try
            {
                _unitOfWork.prodRep.Create(new Product() { Name = Name, Price = price, Image = image, CategoryId = categoryId });

                _unitOfWork.Commit();
                return Results.Ok();
            }
            catch(Exception ex) { return Results.BadRequest(ex.Message); };


        }



        [HttpPost]
        [Route("Delete")]

        public IResult Delete([FromForm] int ID)

        {
            //   var nameIdentifier = this.HttpContext.User.Claims
            //.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            try { 
                _unitOfWork.prodRep.Delete(ID);
                _unitOfWork.Commit();
                return Results.Ok();
            }
            catch(Exception ex) { return Results.BadRequest(ex.Message); }
            
        }

    }
}
