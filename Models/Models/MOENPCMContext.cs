using System;
using DTOModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Models.Models
{
    public partial class MOENPCMContext : DbContext
    {
        public MOENPCMContext()
        {
        }

        public MOENPCMContext(DbContextOptions<MOENPCMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GroupDetails> GroupDetails { get; set; }
        public virtual DbSet<Parm> Parm { get; set; }
        public virtual DbSet<Pcmcost> Pcmcost { get; set; }
        public virtual DbSet<Pcmrequest> Pcmrequest { get; set; }
        public virtual DbSet<PcmrequestInfo> PcmrequestInfo { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductDeriveParm> ProductDeriveParm { get; set; }
        public virtual DbSet<ProductInputParm> ProductInputParm { get; set; }
        public virtual DbSet<ProductMetaData> ProductMetaData { get; set; }
        public virtual DbSet<ProductSubMetaData> ProductSubMetaData { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SupplierProduct> SupplierProduct { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; } //
        public virtual DbSet<ProductMetaDataDTO> ProductMetaDataDTOs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=YH1001898LT; Database=MOENPCM; User Id=sa; password=Password99; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupDetails>(entity =>
            {
                entity.Property(e => e.EmailId).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Parm>(entity =>
            {
                entity.Property(e => e.InputType).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);
            });

            modelBuilder.Entity<Pcmcost>(entity =>
            {
                entity.Property(e => e.DrivedJson).IsUnicode(false);

                entity.Property(e => e.SupplierStatus).IsUnicode(false);

                entity.HasOne(d => d.ProductInstance)
                    .WithMany(p => p.Pcmcost)
                    .HasForeignKey(d => d.ProductInstanceId)
                    .HasConstraintName("FK__PCMCost__Product__4E88ABD4");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Pcmcost)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__PCMCost__Supplie__4F7CD00D");
            });

            modelBuilder.Entity<Pcmrequest>(entity =>
            {
                entity.Property(e => e.AssignedTo).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.ProjectName).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.Version).IsUnicode(false);
            });

            modelBuilder.Entity<PcmrequestInfo>(entity =>
            {
                entity.HasKey(e => e.ProductInstanceId)
                    .HasName("PK__PCMReque__D305B3657A002B83");

                entity.Property(e => e.InputJson).IsUnicode(false);

                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.HasOne(d => d.Pcmrequest)
                    .WithMany(p => p.PcmrequestInfo)
                    .HasForeignKey(d => d.PcmrequestId)
                    .HasConstraintName("FK__PCMReques__PCMRe__4BAC3F29");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PcmrequestInfo)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_PCMRequestInfo_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);
            });

            modelBuilder.Entity<ProductDeriveParm>(entity =>
            {
                entity.Property(e => e.Formula).IsUnicode(false);

                entity.HasOne(d => d.Parm)
                    .WithMany(p => p.ProductDeriveParm)
                    .HasForeignKey(d => d.ParmId)
                    .HasConstraintName("FK__ProductDe__ParmI__45F365D3");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductDeriveParm)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductDe__Produ__44FF419A");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.ProductDeriveParm)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__ProductDe__Suppl__440B1D61");
            });

            modelBuilder.Entity<ProductInputParm>(entity =>
            {
                entity.Property(e => e.DefualtVal).IsUnicode(false);

                entity.Property(e => e.FieldType).IsUnicode(false);

                entity.Property(e => e.InputSource).IsUnicode(false);

                entity.HasOne(d => d.Parm)
                    .WithMany(p => p.ProductInputParm)
                    .HasForeignKey(d => d.ParmId)
                    .HasConstraintName("FK__ProductIn__ParmI__412EB0B6");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductInputParm)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductIn__Produ__403A8C7D");
            });

            modelBuilder.Entity<ProductMetaData>(entity =>
            {
                entity.Property(e => e.ReferenceName).IsUnicode(false);

                entity.Property(e => e.ReferenceParm).IsUnicode(false);

                entity.Property(e => e.ReferenceParmVal).IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductMetaData)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__ProductMe__Produ__5DCAEF64");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.ProductMetaData)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__ProductMe__Suppl__5CD6CB2B");
            });

            modelBuilder.Entity<ProductSubMetaData>(entity =>
            {
                entity.Property(e => e.ReferenceParmName).IsUnicode(false);

                entity.Property(e => e.SubParmName).IsUnicode(false);

                entity.Property(e => e.SubParmValue).IsUnicode(false);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<SupplierProduct>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SupplierProduct)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__SupplierP__Produ__3B75D760");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierProduct)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__SupplierP__Suppl__3A81B327");
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.Property(e => e.ContactName).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                entity.Property(e => e.UserName).IsUnicode(false);

                entity.Property(e => e.UserPassword).IsUnicode(false);

                entity.Property(e => e.UserRole).IsUnicode(false);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.UserDetails)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__UserDetai__Group__5441852A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
