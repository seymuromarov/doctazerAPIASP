using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doctazer.API.Data;
using Doctazer.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Doctazer.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly doctazerAPIContext _context;

        public UserController(doctazerAPIContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return Ok(user);
        }

        //var mybien = await _context.Bien
        //   .Include(bien => bien.Adresse).ThenInclude(adresse => adresse.Ville)
        //   .Include(bien => bien.Type)
        //   .Include(bien => bien.Pieces).ThenInclude(piece => piece.Type)

        //   .FirstOrDefaultAsync(bien => bien.Id == id);
        //    return Ok(mybien);

    }
}
