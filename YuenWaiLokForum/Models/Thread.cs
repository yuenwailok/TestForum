namespace YuenWaiLokForum.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Thread
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Thread()
        {
            Replies = new HashSet<Reply>();
        }

        [Key]
        public int T_Id { get; set; }

        [Required]
        [StringLength(300)]
        public string ThreadName { get; set; }

        [Required]
        [StringLength(64)]
        public string Author { get; set; }

        public DateTime Date { get; set; }

        public int F_Id { get; set; }

        public string Content { get; set; }

        public virtual Forum Forum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reply> Replies { get; set; }
    }
}
