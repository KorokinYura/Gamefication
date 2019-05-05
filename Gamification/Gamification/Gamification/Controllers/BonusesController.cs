using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gamification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public BonusesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("get")]
        public IActionResult GetBonuses()
        {
            var bonuses = _db.Bonuses;

            return Ok(bonuses);
        }

        [HttpPost("create")]
        public IActionResult CreateBonus(Bonus bonus)
        {
            _db.Bonuses.Add(bonus);
            _db.SaveChanges();

            return Ok(bonus);
        }

        [HttpGet("get/{name}")]
        public IActionResult GetBonus(string name)
        {
            var bonus = _db.Bonuses.FirstOrDefault(t => t.Name == name);

            return Ok(bonus);
        }

        [HttpGet("remove/{name}")]
        public IActionResult RemoveBonus(string name)
        {
            var bonus = _db.Bonuses.Remove(_db.Bonuses.FirstOrDefault(t => t.Name == name));
            _db.SaveChanges();

            return Ok();
        }
    }
}