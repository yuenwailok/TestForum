namespace YuenWaiLokForum.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ForumModel : DbContext
    {
        public ForumModel()
            : base("name=ForumModel1")
        {
        }

        public virtual DbSet<Forum> Forums { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<Thread> Threads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Forum>()
                .HasMany(e => e.Threads)
                .WithRequired(e => e.Forum)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Forum>()
                .HasMany(e => e.Replies)
                .WithRequired(e => e.Forum)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reply>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<Reply>()
                .HasMany(e => e.Replies1)
                .WithOptional(e => e.Reply1)
                .HasForeignKey(e => e.LinkedReply_Id);

            modelBuilder.Entity<Thread>()
                .Property(e => e.ThreadName)
                .IsFixedLength();

            modelBuilder.Entity<Thread>()
                .HasMany(e => e.Replies)
                .WithRequired(e => e.Thread)
                .WillCascadeOnDelete(false);
        }
    }
}
