namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_BAIGIANG
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int USERID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_BAIGIANG { get; set; }

        [StringLength(50)]
        public string TRANGTHAI { get; set; }

        public virtual BAIGIANG BAIGIANG { get; set; }

        public virtual USERS USERS { get; set; }
    }
}
