using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iQueuueing.Models;

namespace iQueuueing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueueItemsController : ControllerBase
    {
        private readonly iQueueContext _context;

        public QueueItemsController(iQueueContext context)
        {
            _context = context;
        }

        // GET: api/QueueItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QueueItems>>> GetQueueitems()
        {
            return await _context.Queueitems.ToListAsync();
        }

        // GET: api/QueueItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QueueItems>> GetQueueItems(int id)
        {
            var queueItems = await _context.Queueitems.FindAsync(id);

            if (queueItems == null)
            {
                return NotFound();
            }

            return queueItems;
        }

        // PUT: api/QueueItems/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQueueItems(int id, QueueItems queueItems)
        {
            if (id != queueItems.Id)
            {
                return BadRequest();
            }

            _context.Entry(queueItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QueueItemsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/QueueItems
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<QueueItems>> PostQueueItems(QueueItems queueItems)
        {
            _context.Queueitems.Add(queueItems);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetQueueitems), new { id = queueItems.Id }, queueItems);
        }

        // DELETE: api/QueueItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QueueItems>> DeleteQueueItems(int id)
        {
            var queueItems = await _context.Queueitems.FindAsync(id);
            if (queueItems == null)
            {
                return NotFound();
            }

            _context.Queueitems.Remove(queueItems);
            await _context.SaveChangesAsync();

            return queueItems;
        }

        private bool QueueItemsExists(int id)
        {
            return _context.Queueitems.Any(e => e.Id == id);
        }
    }
}
