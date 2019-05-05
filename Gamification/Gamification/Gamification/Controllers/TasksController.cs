using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gamification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TasksController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _db.GameTasks;

            return Ok(tasks);
        }

        [HttpGet("user/{userName}")]
        public IActionResult GetTasks(string userName)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == userName);

            return Ok(user);
        }

        [HttpPost("create")]
        public IActionResult CreateTask(GameTask task)
        {
            _db.GameTasks.Add(task);
            _db.SaveChanges();

            return Ok(task);
        }

        [HttpGet("{name}")]
        public IActionResult GetTask(string name)
        {
            var task = _db.GameTasks.FirstOrDefault(t => t.Name == name);

            return Ok(task);
        }

        [HttpGet("remove/{name}")]
        public IActionResult RemoveTask(string name)
        {
            var bonus = _db.GameTasks.Remove(_db.GameTasks.FirstOrDefault(t => t.Name == name));
            _db.SaveChanges();

            return Ok();
        }
    }
}