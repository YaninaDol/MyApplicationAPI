using DataAccess;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoriesLibrary.Interfaces;
using RepositoriesLibrary.Models;
using System.Security.Claims;

namespace MyApplicationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [HttpGet]
        [Route("GetPopular")]

        public IResult GetPopular()
        {

            return Results.Ok( _unitOfWork.CategoryRep.GetPopular());
        }

    }
}
