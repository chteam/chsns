using System.Data.Entity;
using CHSNS.Models;

namespace CHSNS.DataContext
{
    public class SqlServerEntities : DbContext
    {
        public SqlServerEntities():base()
        {
            
        }
        public SqlServerEntities(string connectionStringOrName)
            : base(connectionStringOrName)
        {

        }


        public DbSet<Account> Account { get; set; }

        public DbSet<Album> Album { get; set; }

        public DbSet<Application> Application { get; set; }

        public DbSet<BasicInformation> BasicInformation { get; set; }

        public DbSet<Blogs> Blogs { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<ContactInformation> ContactInformation { get; set; }

        public DbSet<Wiki> Wikis { get; set; }

        public DbSet<WikiVersion> WikiVersions { get; set; }

        public DbSet<Event> Event { get; set; }

        public DbSet<FieldInformation> FieldInformation { get; set; }

        public DbSet<Friend> Friends { get; set; }

        public DbSet<Group> Group { get; set; }

        public DbSet<GroupUser> GroupUser { get; set; }

        public DbSet<LogTag> LogTag { get; set; }
        public DbSet<Message> Message { get; set; }

       // public DbSet<PersonalInformation> PersonalInformation { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Push> Push { get; set; }

        public DbSet<Reply> Reply { get; set; }

        public DbSet<Services> Services { get; set; }

        public DbSet<SuperNote> SuperNote { get; set; }

        public DbSet<Tags> Tags { get; set; }

        public DbSet<ViewData> ViewData { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<UserRole> UserRole { get; set; }

        public DbSet<Profile> Profile { get; set; }

        public DbSet<Note> Note { get; set; }
 
    }
}
