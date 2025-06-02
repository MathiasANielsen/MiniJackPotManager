using Microsoft.EntityFrameworkCore;
using MiniJackPotManager.Models;
using System.Collections.Generic;

namespace MiniJackPotManager.Data

{
    public class AppDbContent(DbContextOptions<AppDbContent> options) : DbContext(options)
    {
        public DbSet<Jackpot> Jackpots { get; set; }
    }
}
