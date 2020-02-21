using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace iQueuueing.Models
{
    public class iQueueContext : DbContext
    {
        public iQueueContext(DbContextOptions<iQueueContext> options) : base(options)
        { }
        public DbSet<QueueItems> Queueitems { get; set; }
    }
}