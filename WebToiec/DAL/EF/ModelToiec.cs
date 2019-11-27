namespace DAL.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelToiec : DbContext
    {
        public ModelToiec()
            : base("name=ModelToiec")
        {
        }

        public virtual DbSet<ADMIN> ADMIN { get; set; }
        public virtual DbSet<BAIGIANG> BAIGIANG { get; set; }
        public virtual DbSet<CAUHOI_3_4> CAUHOI_3_4 { get; set; }
        public virtual DbSet<CAUHOIPART_6_7> CAUHOIPART_6_7 { get; set; }
        public virtual DbSet<CHI_TIET_TU_VUNG> CHI_TIET_TU_VUNG { get; set; }
        public virtual DbSet<CHUDE_TUVUNG> CHUDE_TUVUNG { get; set; }
        public virtual DbSet<DANHSACH_BAIGIANG> DANHSACH_BAIGIANG { get; set; }
        public virtual DbSet<DAP_AN> DAP_AN { get; set; }
        public virtual DbSet<KHOAHOC> KHOAHOC { get; set; }
        public virtual DbSet<PART_1_2> PART_1_2 { get; set; }
        public virtual DbSet<PART_3_4> PART_3_4 { get; set; }
        public virtual DbSet<PART_5_6_7> PART_5_6_7 { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TUVUNG> TUVUNG { get; set; }
        public virtual DbSet<USER_BAIGIANG> USER_BAIGIANG { get; set; }
        public virtual DbSet<USER_CHUDE> USER_CHUDE { get; set; }
        public virtual DbSet<USER_KHOAHOC> USER_KHOAHOC { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }
        public virtual DbSet<USERS_PROFILE> USERS_PROFILE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN>()
                .Property(e => e.TAIKHOAN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.MATKHAU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAIGIANG>()
                .Property(e => e.NOIDUNGBAIGIANG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAIGIANG>()
                .Property(e => e.VIDEO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BAIGIANG>()
                .HasMany(e => e.USER_BAIGIANG)
                .WithRequired(e => e.BAIGIANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CAUHOI_3_4>()
                .Property(e => e.NOIDUNG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CAUHOI_3_4>()
                .HasMany(e => e.DAP_AN)
                .WithOptional(e => e.CAUHOI_3_4)
                .HasForeignKey(e => e.IDCAU_34);

            modelBuilder.Entity<CAUHOIPART_6_7>()
                .Property(e => e.NOIDUNG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_TU_VUNG>()
                .Property(e => e.NGHIACUATU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_TU_VUNG>()
                .Property(e => e.PHATAM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_TU_VUNG>()
                .Property(e => e.PHIENAM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_TU_VUNG>()
                .Property(e => e.VIDU)
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_TU_VUNG>()
                .Property(e => e.HINHANH)
                .IsUnicode(false);

            modelBuilder.Entity<CHUDE_TUVUNG>()
                .Property(e => e.TENCHUDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHUDE_TUVUNG>()
                .HasMany(e => e.CHI_TIET_TU_VUNG)
                .WithRequired(e => e.CHUDE_TUVUNG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CHUDE_TUVUNG>()
                .HasMany(e => e.USER_CHUDE)
                .WithRequired(e => e.CHUDE_TUVUNG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DANHSACH_BAIGIANG>()
                .Property(e => e.TENDANHSACH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DAP_AN>()
                .Property(e => e.DAPAN_C)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DAP_AN>()
                .Property(e => e.DAPAN_D)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DAP_AN>()
                .Property(e => e.DAPANDUNG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DAP_AN>()
                .Property(e => e.DAPAN_B)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DAP_AN>()
                .Property(e => e.DAPAN_A)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHOAHOC>()
                .Property(e => e.GIATIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<KHOAHOC>()
                .HasMany(e => e.USER_KHOAHOC)
                .WithRequired(e => e.KHOAHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PART_1_2>()
                .Property(e => e.HINH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PART_1_2>()
                .Property(e => e.AMTHANH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PART_1_2>()
                .Property(e => e.DAPANDUNG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PART_1_2>()
                .Property(e => e.TEXT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PART_3_4>()
                .Property(e => e.AMTHANH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PART_3_4>()
                .Property(e => e.TEXT)
                .IsUnicode(false);

            modelBuilder.Entity<PART_3_4>()
                .HasOptional(e => e.CAUHOI_3_4)
                .WithRequired(e => e.PART_3_4);

            modelBuilder.Entity<PART_5_6_7>()
                .Property(e => e.NOIDUNGCAUHOI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PART_5_6_7>()
                .HasOptional(e => e.CAUHOIPART_6_7)
                .WithRequired(e => e.PART_5_6_7);

            modelBuilder.Entity<TUVUNG>()
                .Property(e => e.TU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TUVUNG>()
                .Property(e => e.THELOAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TUVUNG>()
                .HasMany(e => e.CHI_TIET_TU_VUNG)
                .WithRequired(e => e.TUVUNG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_BAIGIANG>()
                .Property(e => e.TRANGTHAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USER_CHUDE>()
                .Property(e => e.TRANGTHAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.TAIKHOANUSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.MATKHAUUSER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .HasMany(e => e.USER_BAIGIANG)
                .WithRequired(e => e.USERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USERS>()
                .HasMany(e => e.USER_CHUDE)
                .WithRequired(e => e.USERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USERS>()
                .HasMany(e => e.USER_KHOAHOC)
                .WithRequired(e => e.USERS)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USERS>()
                .HasOptional(e => e.USERS_PROFILE)
                .WithRequired(e => e.USERS);

            modelBuilder.Entity<USERS_PROFILE>()
                .Property(e => e.HOTEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERS_PROFILE>()
                .Property(e => e.GIOITINH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERS_PROFILE>()
                .Property(e => e.NGHENGHIEP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERS_PROFILE>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERS_PROFILE>()
                .Property(e => e.EMAIL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERS_PROFILE>()
                .Property(e => e.THANHPHO)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
