using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        IFavoriteService _favoriteService;

        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _favoriteService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getallbyuser")]
        public IActionResult GetAllbyUser(int userId)
        {
            var result = _favoriteService.GetAllbyUser(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _favoriteService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("favoritecount")]
        public IActionResult ProductFavoriteCount(int id)
        {
            var result = _favoriteService.ProductFavoriteCount(id);
            return Ok(result);
            }

        [HttpDelete("delete")]
        public IActionResult Delete(Favorite favorite)
        {
            var result = _favoriteService.Delete(favorite);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }

        [HttpPost("add")]
        public IActionResult Add(Favorite favorite)
        {
            var result = _favoriteService.Add(favorite);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
