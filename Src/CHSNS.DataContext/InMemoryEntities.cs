using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using CHSNS.Models;

namespace CHSNS.DataContext
{
    public class InMemoryEntities:IDbEntities
    {
        public void Dispose(){}

        public Database Database { get; private set; }
        public DbChangeTracker ChangeTracker { get; private set; }
        public DbContextConfiguration Configuration { get; private set; }
        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public DbSet Set(Type entityType)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            return 1;
        }

        public IEnumerable<DbEntityValidationResult> GetValidationErrors()
        {
            throw new NotImplementedException();
        }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public DbEntityEntry Entry(object entity)
        {
            throw new NotImplementedException();
        }

        public IDbSet<Account> Account { get; set; }
        public IDbSet<Album> Album { get; set; }
        public IDbSet<Application> Application { get; set; }
        public IDbSet<BasicInformation> BasicInformation { get; set; }
        public IDbSet<Blogs> Blogs { get; set; }
        public IDbSet<Category> Category { get; set; }
        public IDbSet<Comment> Comment { get; set; }
        public IDbSet<ContactInformation> ContactInformation { get; set; }
        public IDbSet<Wiki> Wikis { get; set; }
        public IDbSet<WikiVersion> WikiVersions { get; set; }
        public IDbSet<EventLog> Event { get; set; }
        public IDbSet<FieldInformation> FieldInformation { get; set; }
        public IDbSet<Friend> Friends { get; set; }
        public IDbSet<Group> Group { get; set; }
        public IDbSet<GroupUser> GroupUser { get; set; }
        public IDbSet<LogTag> LogTag { get; set; }
        public IDbSet<Message> Message { get; set; }
        public IDbSet<Photo> Photos { get; set; }
        public IDbSet<Push> Push { get; set; }
        public IDbSet<Reply> Reply { get; set; }
        public IDbSet<Services> Services { get; set; }
        public IDbSet<SuperNote> SuperNote { get; set; }
        public IDbSet<Tags> Tags { get; set; }
        public IDbSet<ViewData> ViewData { get; set; }
        public IDbSet<Roles> Roles { get; set; }
        public IDbSet<UserRole> UserRole { get; set; }
        public IDbSet<Profile> Profile { get; set; }
        public IDbSet<Note> Note { get; set; }
    }
}