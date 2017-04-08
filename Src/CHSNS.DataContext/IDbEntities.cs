using System;
 
using CHSNS.Models;
using Microsoft.EntityFrameworkCore;

namespace CHSNS.DataContext
{
    public interface IDbEntities :IDisposable,IDbContext
    {
        DbSet<Account> Account { get; set; }
        DbSet<Album> Album { get; set; }
        DbSet<Application> Application { get; set; }
        DbSet<BasicInformation> BasicInformation { get; set; }
        DbSet<Blogs> Blogs { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<Comment> Comment { get; set; }
        DbSet<ContactInformation> ContactInformation { get; set; }
        DbSet<Wiki> Wikis { get; set; }
        DbSet<WikiVersion> WikiVersions { get; set; }
        DbSet<EventLog> Event { get; set; }
        DbSet<FieldInformation> FieldInformation { get; set; }
        DbSet<Friend> Friends { get; set; }
        DbSet<Group> Group { get; set; }
        DbSet<GroupUser> GroupUser { get; set; }
        DbSet<LogTag> LogTag { get; set; }
        DbSet<Message> Message { get; set; }
        DbSet<Photo> Photos { get; set; }
        DbSet<Push> Push { get; set; }
        DbSet<Reply> Reply { get; set; }
        DbSet<Services> Services { get; set; }
        DbSet<SuperNote> SuperNote { get; set; }
        DbSet<Tags> Tags { get; set; }
        DbSet<ViewData> ViewData { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<UserRole> UserRole { get; set; }
        DbSet<Profile> Profile { get; set; }
        DbSet<Note> Note { get; set; }

 
 
    }
}