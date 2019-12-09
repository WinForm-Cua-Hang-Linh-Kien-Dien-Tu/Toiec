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
        public virtual DbSet<DAP_AN> DAP_AN { get; set; }
        public virtual DbSet<KHOAHOC> KHOAHOC { get; set; }
        public virtual DbSet<PART_1_2> PART_1_2 { get; set; }
        public virtual DbSet<PART_3_4> PART_3_4 { get; set; }
        public virtual DbSet<PART_5_6_7> PART_5_6_7 { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TIN_TUC> TIN_TUC { get; set; }
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
                .Property(e => e.NOI_DUNG_BAI_GIANG)
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
                .Property(e => e.NOI_DUNG)
                .IsUnicode(false);

            modelBuilder.Entity<CAUHOI_3_4>()
                .HasMany(e => e.DAP_AN)
                .WithOptional(e => e.CAUHOI_3_4)
                .HasForeignKey(e => e.IDCAU_34);

            modelBuilder.Entity<CAUHOIPART_6_7>()
                .Property(e => e.NOI_DUNG)
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_TU_VUNG>()
                .Property(e => e.PHAT_AM)
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_TU_VUNG>()
                .Property(e => e.PHIEN_AM)
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_TU_VUNG>()
                .Property(e => e.VI_DU)
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_TU_VUNG>()
                .Property(e => e.HIN_HANH)
                .IsUnicode(false);

            modelBuilder.Entity<CHUDE_TUVUNG>()
                .HasMany(e => e.CHI_TIET_TU_VUNG)
                .WithRequired(e => e.CHUDE_TUVUNG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CHUDE_TUVUNG>()
                .HasMany(e => e.USER_CHUDE)
                .WithRequired(e => e.CHUDE_TUVUNG)
                .WillCascadeOnDelete(false);

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
                .Property(e => e.VIDEO_GIOI_THIEU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHOAHOC>()
                .Property(e => e.LOAI_KH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHOAHOC>()
                .HasMany(e => e.USER_KHOAHOC)
                .WithRequired(e => e.KHOAHOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PART_1_2>()
                .Property(e => e.HINH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PART_1_2>()
                .Property(e => e.AM_THANH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PART_1_2>()
                .Property(e => e.TEXT)
                .IsUnicode(false);

            modelBuilder.Entity<PART_1_2>()
                .Property(e => e.DAP_AN_DUNG)
                .IsFixedLength();

            modelBuilder.Entity<PART_3_4>()
                .Property(e => e.AM_THANH)
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
                .IsUnicode(false);

            modelBuilder.Entity<PART_5_6_7>()
                .HasOptional(e => e.CAUHOIPART_6_7)
                .WithRequired(e => e.PART_5_6_7);

            modelBuilder.Entity<TIN_TUC>()
                .Property(e => e.NGUON_TIN_TUC)
                .IsFixedLength();

            modelBuilder.Entity<TIN_TUC>()
                .Property(e => e.HINH_ANH)
                .IsUnicode(false);

            modelBuilder.Entity<TUVUNG>()
                .Property(e => e.TU)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TUVUNG>()
                .HasMany(e => e.CHI_TIET_TU_VUNG)
                .WithRequired(e => e.TUVUNG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER_BAIGIANG>()
                .Property(e => e.TRANG_THAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USER_CHUDE>()
                .Property(e => e.TRANG_THAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.TAI_KHOAN_USER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.MAT_KHAU_USER)
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
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERS_PROFILE>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);
        }
    }
}
