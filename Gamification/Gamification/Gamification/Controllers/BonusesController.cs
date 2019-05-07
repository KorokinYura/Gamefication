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

        [HttpGet]
        public IActionResult GetBonuses()
        {
            var bonuses = new List<Bonus>();

            foreach (var b in _db.Bonuses)
            {
                if (ValidateBonus(b))
                    bonuses.Add(b);
            }

            return Ok(bonuses);
        }

        private bool ValidateBonus(Bonus b)
        {
            if (b.Amount > 0 && b.TimeLimit == null)
                return true;
            if (b.Amount > 0 && b.TimeLimit > DateTime.Now)
                return true;
            return false;
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
            var bonus = _db.Bonuses.FirstOrDefault(b => b.Name == name);

            return Ok(bonus);
        }

        [HttpGet("buy/{id}/{userId}")]
        public IActionResult BuyBonus(int id, string userId)
        {
            var bonus = _db.Bonuses.FirstOrDefault(b => b.Id == id);

            if (bonus != null)
            {
                bonus.Amount--;
                _db.Users.FirstOrDefault(u => u.Id == userId).Points -= bonus.Price.Value;

                _db.UsersBonuses.Add(new UsersBonuses
                {
                    ApplicationUserId = userId,
                    BonusId = bonus.Id
                });

                    _db.SaveChanges();
            }
            else
                return BadRequest(false);

            return Ok(true);
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