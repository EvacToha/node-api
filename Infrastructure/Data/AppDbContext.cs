using Microsoft.EntityFrameworkCore;
using NodeApl.API.Domain.Entities;

namespace NodeApl.API.Infrastructure.Data;



public class AppDbContext : DbContext
{
    public DbSet<Node> Nodes => Set<Node>();
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();  
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Node>()
            .HasMany(n => n.Children)
            .WithOne()
            .HasForeignKey(n => n.ParentId);
        
        modelBuilder.Entity<Node>().HasData(
            new Node { Id = 1, Name = "Шаблоны", Type = "Шаблон" },
            new Node { Id = 4, Name = "Шаблон 1", Type = "Шаблон", ParentId = 1 },
            new Node { Id = 5, Name = "Шаблон 2", Type = "Шаблон", ParentId = 1 },
            new Node { Id = 6, Name = "Шаблон 3", Type = "Шаблон", ParentId = 1 },
            
            new Node { Id = 2, Name = "Изделия", Type = "Изделие" },
            new Node { Id = 7, Name = "Изделие 1", Type = "Изделие", ParentId = 2 },
            new Node { Id = 8, Name = "Изделие 2", Type = "Изделие", ParentId = 2 },
            
            new Node { Id = 3, Name = "Документы", Type = "Документ" },
            new Node { Id = 9, Name = "Документ 1", Type = "Документ", ParentId = 3 },
            new Node { Id = 10, Name = "Документ 2", Type = "Документ", ParentId = 3 },
            new Node { Id = 11, Name = "Документ 3", Type = "Документ", ParentId = 3 },
            new Node { Id = 12, Name = "Документ 4", Type = "Документ", ParentId = 3 }
        );
    }
}