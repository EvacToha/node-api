using Microsoft.EntityFrameworkCore;
using NodeApl.API.Domain.Entities;

namespace NodeApl.API.Infrastructure.Data;



public class AppDbContext : DbContext
{
    public DbSet<Node> Nodes => Set<Node>();
    public DbSet<Sample> Samples => Set<Sample>();
    
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
        
        
        modelBuilder.Entity<Sample>()
            .HasOne(s => s.Node)
            .WithMany(n => n.Samples)
            .HasForeignKey(s => s.NodeId);
        
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
        
        modelBuilder.Entity<Sample>().HasData(
            new Sample { Id = 1, Name = "Описание Шаблона 1", CreateDate = new DateTime(2024, 12, 10), CreatedBy = "Антон", NodeId = 4},
            new Sample { Id = 2, Name = "Описание Шаблона 1", CreateDate = new DateTime(2024, 12, 10), CreatedBy = "Антон", NodeId = 4},
            new Sample { Id = 3, Name = "Описание Шаблона 1", CreateDate = new DateTime(2024, 12, 11), CreatedBy = "Антон", NodeId = 4},
            new Sample { Id = 4, Name = "Описание Шаблона 1", CreateDate = new DateTime(2024, 12, 11), CreatedBy = "Антон", NodeId = 4},
            new Sample { Id = 5, Name = "Описание Шаблона 1", CreateDate = new DateTime(2024, 12, 12), CreatedBy = "Антон", NodeId = 4},
            
            new Sample { Id = 6, Name = "Описание Шаблона 2", CreateDate = new DateTime(2024, 12, 03), CreatedBy = "Антон", NodeId = 5},
            new Sample { Id = 7, Name = "Описание Шаблона 2", CreateDate = new DateTime(2024, 12, 04), CreatedBy = "Антон", NodeId = 5},
            new Sample { Id = 8, Name = "Описание Шаблона 2", CreateDate = new DateTime(2024, 12, 04), CreatedBy = "Антон", NodeId = 5},
            new Sample { Id = 9, Name = "Описание Шаблона 2", CreateDate = new DateTime(2024, 12, 04), CreatedBy = "Антон", NodeId = 5},
            
            new Sample { Id = 10, Name = "Описание Шаблона 3", CreateDate = new DateTime(2024, 11, 20), CreatedBy = "Антон", NodeId = 6},
            new Sample { Id = 11, Name = "Описание Шаблона 3", CreateDate = new DateTime(2024, 11, 21), CreatedBy = "Антон", NodeId = 6},
            new Sample { Id = 12, Name = "Описание Шаблона 3", CreateDate = new DateTime(2024, 11, 21), CreatedBy = "Антон", NodeId = 6},
            new Sample { Id = 13, Name = "Описание Шаблона 3", CreateDate = new DateTime(2024, 11, 23), CreatedBy = "Антон", NodeId = 6},
            new Sample { Id = 14, Name = "Описание Шаблона 3", CreateDate = new DateTime(2024, 11, 23), CreatedBy = "Антон", NodeId = 6},
            new Sample { Id = 15, Name = "Описание Шаблона 3", CreateDate = new DateTime(2024, 11, 25), CreatedBy = "Антон", NodeId = 6},
            new Sample { Id = 16, Name = "Описание Шаблона 3", CreateDate = new DateTime(2024, 11, 25), CreatedBy = "Антон", NodeId = 6},
            new Sample { Id = 17, Name = "Описание Шаблона 3", CreateDate = new DateTime(2024, 11, 25), CreatedBy = "Антон", NodeId = 6},
            
            
            new Sample { Id = 18, Name = "Описание Изделия 1", CreateDate = new DateTime(2024, 12, 06), CreatedBy = "Антон", NodeId = 7},
            new Sample { Id = 19, Name = "Описание Изделия 1", CreateDate = new DateTime(2024, 12, 06), CreatedBy = "Антон", NodeId = 7},
            new Sample { Id = 20, Name = "Описание Изделия 1", CreateDate = new DateTime(2024, 12, 08), CreatedBy = "Антон", NodeId = 7},
            new Sample { Id = 21, Name = "Описание Изделия 1", CreateDate = new DateTime(2024, 12, 09), CreatedBy = "Антон", NodeId = 7},
            new Sample { Id = 22, Name = "Описание Изделия 1", CreateDate = new DateTime(2024, 12, 09), CreatedBy = "Антон", NodeId = 7},
            
            new Sample { Id = 23, Name = "Описание Изделия 2", CreateDate = new DateTime(2024, 12, 02), CreatedBy = "Антон", NodeId = 8},
            new Sample { Id = 24, Name = "Описание Изделия 2", CreateDate = new DateTime(2024, 12, 05), CreatedBy = "Антон", NodeId = 8},
            new Sample { Id = 25, Name = "Описание Изделия 2", CreateDate = new DateTime(2024, 12, 05), CreatedBy = "Антон", NodeId = 8},
            
            new Sample { Id = 26, Name = "Описание Документа 1", CreateDate = new DateTime(2024, 12, 05), CreatedBy = "Антон", NodeId = 9},
            new Sample { Id = 27, Name = "Описание Документа 1", CreateDate = new DateTime(2024, 12, 06), CreatedBy = "Антон", NodeId = 9},
            
            new Sample { Id = 28, Name = "Описание Документа 2", CreateDate = new DateTime(2024, 12, 07), CreatedBy = "Антон", NodeId = 10},
            new Sample { Id = 29, Name = "Описание Документа 2", CreateDate = new DateTime(2024, 12, 08), CreatedBy = "Антон", NodeId = 10},
            
            new Sample { Id = 30, Name = "Описание Документа 3", CreateDate = new DateTime(2024, 12, 09), CreatedBy = "Антон", NodeId = 11},
            new Sample { Id = 31, Name = "Описание Документа 3", CreateDate = new DateTime(2024, 12, 09), CreatedBy = "Антон", NodeId = 11},
            
            new Sample { Id = 32, Name = "Описание Документа 4", CreateDate = new DateTime(2024, 12, 11), CreatedBy = "Антон", NodeId = 12},
            new Sample { Id = 33, Name = "Описание Документа 4", CreateDate = new DateTime(2024, 12, 12), CreatedBy = "Антон", NodeId = 12}
            
            
            
            
        );
    }
}