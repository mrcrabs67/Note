using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Note.Models
{
    public class NoteContext : DbContext
    {
        public DbSet<Notes> Notes { get; set; }

        public NoteContext(DbContextOptions<NoteContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
