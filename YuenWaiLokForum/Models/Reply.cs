namespace YuenWaiLokForum.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reply
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reply()
        {
            Replies1 = new HashSet<Reply>();
        }

        [Key]
        public int R_Id { get; set; }

        [Required]
        [StringLength(320)]
        public string Title { get; set; }

        [Required]
        [StringLength(64)]
        public string Author { get; set; }

        public DateTime DateTime { get; set; }

        public int? LinkedReply_Id { get; set; }

        public int T_Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int F_Id { get; set; }

        public virtual Forum Forum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply> Replies1 { get; set; }

        public virtual Reply Reply1 { get; set; }

        public virtual Thread Thread { get; set; }
    }
}
