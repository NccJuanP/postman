using Microsoft.AspNetCore.Mvc;
using ApiPostman.Data;
using ApiPostman.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPostman.Controllers{

    [Route("/api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase{
        private readonly ApiContext _context;
        public UsersController(ApiContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers(){
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id){
            var user = await _context.Users.FindAsync(id);
            if(user == null){
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user){
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user){
            if(id!= user.Id){
                return BadRequest();
            }
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id){
            var user = await _context.Users.FindAsync(id);
            if(user == null){
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}