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

        [HttpGet("get/{userId}")]
        public IActionResult GetTasks(string userId)
        {
            var tasks = _db.GameTasks.Where(t => t.TimeLimit == null || t.TimeLimit > DateTime.Now).ToList();

            var retTasks = new List<GameTask>();

            foreach (var t in tasks)
            {
                retTasks.Add(t);
            }

            foreach (var t in tasks)
            {
                var gameTask = _db.UsersGameTasks.FirstOrDefault(gt => gt.ApplicationUserId == userId && gt.GameTaskId == t.Id);

                if (gameTask != null)
                    retTasks.Remove(t);
            }

            return Ok(retTasks);
        }

        [HttpGet("activate/{id}/{userId}")]
        public IActionResult ActivateTask(int id, string userId)
        {
            var task = _db.GameTasks.FirstOrDefault(t => t.Id == id);

            if (task != null)
            {
                _db.UsersGameTasks.Add(new UsersGameTasks
                {
                    ApplicationUserId = userId,
                    GameTaskId = id
                });

                _db.SaveChanges();
            }
            else
                return BadRequest();

            return Ok();
        }

        [HttpGet("active/{userId}")]
        public IActionResult GetActiveTasks(string userId)
        {
            var tasks = _db.GameTasks.Where(t => t.TimeLimit == null || t.TimeLimit > DateTime.Now).ToList();

            var retTasks = new List<GameTask>();

            foreach (var t in tasks)
            {
                retTasks.Add(t);
            }

            foreach (var t in tasks)
            {
                var gameTask = _db.UsersGameTasks.FirstOrDefault(gt => gt.ApplicationUserId == userId && gt.GameTaskId == t.Id);

                if (gameTask == null)
                    retTasks.Remove(t);
            }

            return Ok(retTasks);
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