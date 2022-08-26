using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatAPImodels.WeatAPIEntities;
using Microsoft.EntityFrameworkCore;

namespace WeatAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly WContext _context;
        public UserController(WContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult login()
        {
            return Ok("hello");
        }
        /// <summary>
        /// get all user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<User>> Getalluser()
        {
            //return await _context.User.ToListAsync();
            var users = _context.User.ToList();
            return users;
        }
        /// <summary>
        /// select id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public User Getid(int id)
        {
            return _context.User.Find(id);
        }
        /// <summary>
        /// add user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUser([FromBody] WeatAPImodels.User.AddUserP model)
        {
            var r = WeatAPIBo.UserBo.AddUser(model);
            return Ok(r);
        }

        /// <summary>
        /// updata user
        /// </summary>
        
        [HttpPut]
        //public User upuser(int id)
        public async Task<IActionResult> updatauser(int id, User olduser)
        {
            if (id != olduser.Id)
            {
                return BadRequest();
            }
            _context.Entry(olduser).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!olduserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
            /*
            User olduser =  _context.User.Find(id);
            _context.Entry(olduser).State = EntityState.Modified;
            //olduser.State = EntityState.Modified;
            
            _context.SaveChanges();
            return olduser;
            */
        }
        
        /// <summary>
        /// deldete user
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Deleteuser(int id)
        {
            _context.User.Remove(Getid(id));
            _context.SaveChanges();
        }
        private bool olduserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
