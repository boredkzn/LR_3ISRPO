using ISRPO3.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISRPO3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RestouranController : ControllerBase
    {
        private RestouranContext? _db;
        public RestouranController(RestouranContext restouranContext)
        {
            _db = restouranContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restouran>>> Get()
        {
            return await _db.MainTable.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restouran>> Get(int id)
        {
            Restouran restouran = await _db.MainTable.FirstOrDefaultAsync(x => x.Id == id);
            if (restouran == null)
                return NotFound();
            return new ObjectResult(restouran);       
        }
        [HttpPost]
        public async Task<ActionResult<Restouran>> Post(Restouran restouran)
        {
            if (restouran == null)
            {
                return BadRequest();
            }
            _db.MainTable.Add(restouran);
            var all = _db.MainTable.ToList();
            foreach (var one in all)
            {
                if (restouran.Date_reservation == one.Date_reservation)
                {
                    return BadRequest();
                }
            }
            await _db.SaveChangesAsync();
            
            return Ok(restouran);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Restouran>> Put(Restouran restouran)
        {
            if (restouran == null)
            {
                return BadRequest();
            }
            if (!_db.MainTable.Any(x => x.Id == restouran.Id))
            {
                return NotFound();
            }
            _db.Update(restouran);
            await _db.SaveChangesAsync();
            return Ok(restouran);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restouran>> Delete(int id)
        {
            Restouran restouran = _db.MainTable.FirstOrDefault(x => x.Id == id);
            if (restouran == null)
                return NotFound();
            _db.MainTable.Remove(restouran);
            await _db.SaveChangesAsync();
            return Ok(restouran);
        }
    }


}
