﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CrystalBlog.Entities.Users;
using CrystalBlog.Entities.Sites;
using CrystalBlog.Entities.Posts;

namespace CrystalBlog.Data
{
    public class CrystalDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<Site> Sites { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public CrystalDbContext(DbContextOptions<CrystalDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().ForSqlServerToTable("Users");
            builder.Entity<Role>().ForSqlServerToTable("Roles");
            builder.Entity<IdentityUserRole<int>>().ForSqlServerToTable("UserRoles");
            builder.Entity<IdentityUserLogin<int>>().ForSqlServerToTable("UserLogins");
            builder.Entity<IdentityUserClaim<int>>().ForSqlServerToTable("UserClaims");
            builder.Entity<IdentityUserToken<int>>().ForSqlServerToTable("UserTokens");
            builder.Entity<IdentityRoleClaim<int>>().ForSqlServerToTable("RoleClaims");
        }
    }
}
