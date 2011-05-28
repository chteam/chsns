using System;
using System.Data.Entity;
using CHSNS.Models;

namespace CHSNS.DataContext
{
    public interface IDbEntities :IDisposable,IDbContext
    {
        IDbSet<Account> Account { get; set; }
        IDbSet<Album> Album { get; set; }
        IDbSet<Application> Application { get; set; }
        IDbSet<BasicInformation> BasicInformation { get; set; }
        IDbSet<Blogs> Blogs { get; set; }
        IDbSet<Category> Category { get; set; }
        IDbSet<Comment> Comment { get; set; }
        IDbSet<ContactInformation> ContactInformation { get; set; }
        IDbSet<Wiki> Wikis { get; set; }
        IDbSet<WikiVersion> WikiVersions { get; set; }
        IDbSet<Event> Event { get; set; }
        IDbSet<FieldInformation> FieldInformation { get; set; }
        IDbSet<Friend> Friends { get; set; }
        IDbSet<Group> Group { get; set; }
        IDbSet<GroupUser> GroupUser { get; set; }
        IDbSet<LogTag> LogTag { get; set; }
        IDbSet<Message> Message { get; set; }
        IDbSet<Photo> Photos { get; set; }
        IDbSet<Push> Push { get; set; }
        IDbSet<Reply> Reply { get; set; }
        IDbSet<Services> Services { get; set; }
        IDbSet<SuperNote> SuperNote { get; set; }
        IDbSet<Tags> Tags { get; set; }
        IDbSet<ViewData> ViewData { get; set; }
        IDbSet<Roles> Roles { get; set; }
        IDbSet<UserRole> UserRole { get; set; }
        IDbSet<Profile> Profile { get; set; }
        IDbSet<Note> Note { get; set; }

 
 
    }
}