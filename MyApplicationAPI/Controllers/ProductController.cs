using DataAccess;
using JWT_Token.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using RepositoriesLibrary.Interfaces;
using RepositoriesLibrary.Models;
using System.Runtime.InteropServices;
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

        public IResult Buy([FromForm] int prodID, [FromForm] string userID)

        {



            _unitOfWork.prodRep.Buy(prodID, userID);
            _unitOfWork.Commit();
            return Results.Ok();
            
            
        }

        [HttpGet]
        [Route("GetByCategory")]

        public IActionResult GetByCategory(int ID)
        {


            if (_unitOfWork.prodRep.GetByCategory(ID) != null)
            {
                return Ok( _unitOfWork.prodRep.GetByCategory(ID));
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetById")]

        public IActionResult GetById(int ID)
        {
            var result = _unitOfWork.prodRep.Get(ID);
            if (result != null)
            {
                return Ok(result);
            }
            else return BadRequest();
        }

        [HttpGet]
        [Route("GetPopulars")]

        public IActionResult GetPopulars()
        {
             return Ok(_unitOfWork.prodRep.GetPopular());
           
        }

        [HttpGet]
        [Route("GetBrands")]

        public IActionResult GetBrands()
        {
            return Ok(_unitOfWork.prodRep.GetBrand());

        }

        [HttpPost]
        [Route("Add")]
        
        public IResult Add([FromForm] string name, [FromForm] string model, [FromForm] float price,[FromForm] bool visible,[FromForm] int capacity,[FromForm] int sold, [FromForm] string image, [FromForm] int categoryId)
        {
            
                 _unitOfWork.prodRep.Create(new Product() { Name = name, Model=model, Price = price,Capacity=capacity,Visible=visible,Sold=sold, Image = image, CategoryId = categoryId });
              
                _unitOfWork.Commit();
                return Results.Ok();
           


        }



        [HttpPost]
        [Route("Delete")]

        public IResult Delete([FromForm] int deleteid)

        {
            
                _unitOfWork.prodRep.Delete(deleteid);
                _unitOfWork.Commit();
                return Results.Ok();
            
            
        }


        [HttpPost]
        [Route("Update")]

        public IResult Update([FromForm] int id, [FromForm] string name, [FromForm] string model, [FromForm] float price, [FromForm] bool visible, [FromForm] int capacity, [FromForm] int sold, [FromForm] string image, [FromForm] int categoryId)

        {
             
               if( _unitOfWork.prodRep.UpdateProduct(id, new Product() {Id=id, Name = name, Model = model, Price = price, Capacity = capacity, Visible = visible, Sold = sold, Image = image, CategoryId = categoryId }))
            {
                _unitOfWork.Commit();
                return Results.Ok();
            }
            else return Results.BadRequest();
           

        }

    }
}
