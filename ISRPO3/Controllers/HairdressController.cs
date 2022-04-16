
using ISRPOLR3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISRPOLR3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HairdressController : ControllerBase
    {
        private HAIRDRESSContext? _db;
        public HairdressController(HAIRDRESSContext h)
        {
            _db = h;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HAIRDRESS>>> Get()
        {
            return await _db.Main.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HAIRDRESS>> Get(int id)
        {
            HAIRDRESS h = await _db.Main.FirstOrDefaultAsync(x => x.Id == id);
            if (h == null)
                return NotFound();
            return new ObjectResult(h);       
        }
        [HttpPost]
        public async Task<ActionResult<HAIRDRESS>> Post(HAIRDRESS h)
        {
            if (h == null)
            {
                return BadRequest();
            }
            _db.Main.Add(h);
            var all = _db.Main.ToList();
            foreach (var one in all)
            {
                if (h.Date == one.Date)
                {
                    return BadRequest();
                }
            }
            await _db.SaveChangesAsync();
            
            return Ok(h);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<HAIRDRESS>> Put(HAIRDRESS h)
        {
            if (h == null)
            {
                return BadRequest();
            }
            if (!_db.Main.Any(x => x.Id == h.Id))
            {
                return NotFound();
            }
            _db.Update(h);
            await _db.SaveChangesAsync();
            return Ok(h);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<HAIRDRESS>> Delete(int id)
        {
            HAIRDRESS h = _db.Main.FirstOrDefault(x => x.Id == id);
            if (h == null)
                return NotFound();
            _db.Main.Remove(h);
            await _db.SaveChangesAsync();
            return Ok(h);
        }
    }


}
