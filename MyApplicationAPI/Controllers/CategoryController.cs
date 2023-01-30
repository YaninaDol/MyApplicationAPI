using RepositoriesLibrary.Roles;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoriesLibrary.Interfaces;
using RepositoriesLibrary.Models;
using System.Security.Claims;

namespace MyApplicationAPI.Controllers
{
    [ApiController,Authorize]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpPost]

        [Route("Add")]
            public IResult Add (string categoryName)
        {
            
            try
            {
                
                _unitOfWork.CategoryRep.Create(new Category() { Name = categoryName });
                _unitOfWork.Commit();
                return Results.Ok();

            }
            catch (Exception ex) { return Results.Ok(ex.Message); }
           
        }

        [HttpPost]

        [Route("Delete")]
        public IResult Delete(int id)
        {
            try
            {
                _unitOfWork.CategoryRep.Delete(id);
                _unitOfWork.Commit();
                return Results.Ok();

            }
            catch (Exception ex) { return Results.BadRequest(ex.Message); }

        }

        [HttpGet]
        [Route("GetCategoryById")]

        public IResult GetCategoryById(int id)
        {

            try
            {
               
                return Results.Ok(_unitOfWork.CategoryRep.Get(id));

            }
            catch (Exception ex) { return Results.BadRequest(ex.Message); }

        }

        [HttpGet]
        [Route("GetPopular")]

        public IResult GetPopular()
        {

             return Results.Ok( _unitOfWork.CategoryRep.GetPopular());
          
        }
        [HttpGet]
        [Route("GetCountbyid")]

        public int GetCountbyid(int id)
        {

            return _unitOfWork.CategoryRep.GetCount(id);

        }
      
        [HttpGet]
        [Authorize(Roles = UserRoles.User)]
        [Route("GetAll")]

        public IResult GetAll()
        {
            try
            {
                return Results.Json(_unitOfWork.CategoryRep.GetAll());
            }
            catch (Exception ex) { return Results.BadRequest(ex.Message); }

        }

    }
}
