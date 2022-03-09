namespace RepositoryLayer.Context
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using RepositoryLayer.Entities;
    using System.Collections.Generic;
    using System.Text;
    public class FundooContext:DbContext
    {
        public FundooContext(DbContextOptions options)
           : base(options)
        {
        }
        public DbSet<User> UserTables{ get; set; }
        public DbSet<Note> NotesTables { get; set; }
        public DbSet<Collabrate>CollabratesTables { get; set; }
        public DbSet<Label> LabelTables { get; set; }

    }
}
