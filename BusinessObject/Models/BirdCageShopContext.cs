using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessObject.Models
{
    public partial class BirdCageShopContext : DbContext
    {
        public BirdCageShopContext()
        {
        }

        public BirdCageShopContext(DbContextOptions<BirdCageShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cage> Cages { get; set; } = null!;
        public virtual DbSet<CageComponent> CageComponents { get; set; } = null!;
        public virtual DbSet<CageImage> CageImages { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Component> Components { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config["ConnectionStrings:BirdCageShopDB"];

            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cage>(entity =>
            {
                entity.ToTable("Cage");

                entity.Property(e => e.CageName).HasMaxLength(50);

                entity.Property(e => e.CagePrice).HasColumnType("money");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Cages)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Cage_Category");
            });

            modelBuilder.Entity<CageComponent>(entity =>
            {
                entity.ToTable("CageComponent");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Cage)
                    .WithMany(p => p.CageComponents)
                    .HasForeignKey(d => d.CageId)
                    .HasConstraintName("FK_CageComponent_Cage");

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.CageComponents)
                    .HasForeignKey(d => d.ComponentId)
                    .HasConstraintName("FK_CageComponent_Component");

                entity.Property(e => e.Material).HasMaxLength(50);

                entity.Property(e => e.Color).HasMaxLength(50);
            });

            modelBuilder.Entity<CageImage>(entity =>
            {
                entity.ToTable("CageImage");

                entity.HasOne(d => d.Cage)
                    .WithMany(p => p.CageImages)
                    .HasForeignKey(d => d.CageId)
                    .HasConstraintName("FK_CageImage_Cage");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.ToTable("Component");

                entity.Property(e => e.ComponentName).HasMaxLength(50);

                entity.Property(e => e.ComponentPrice).HasColumnType("money");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.TotalPrice).HasColumnType("money");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Cage)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CageId)
                    .HasConstraintName("FK_OrderDetail_Cage");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderDetail_Order");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Role).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
