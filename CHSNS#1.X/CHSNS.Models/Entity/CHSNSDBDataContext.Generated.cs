
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CHSNS.Models
{
    /// <summary>
    /// The DataContext class for the sq_menglei database.
    /// </summary>
    public partial class CHSNSDBDataContext : DataContext
    {
        private static MappingSource mappingCache = new AttributeMappingSource();
        
        #region Constructors
        /// <summary>
        /// Initializes the <see cref="CHSNSDBDataContext"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute]
        static CHSNSDBDataContext()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CHSNSDBDataContext"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute]
        public CHSNSDBDataContext()
            : base(Properties.Settings.Default.SqMengleiConnectionString, mappingCache)
        {
            OnCreated();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CHSNSDBDataContext"/> class.
        /// </summary>
        /// <param name="connection">The connection string.</param>
        [DebuggerNonUserCodeAttribute]
        public CHSNSDBDataContext(string connection)
            : base(connection, mappingCache)
        {
            OnCreated();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CHSNSDBDataContext"/> class.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        [DebuggerNonUserCodeAttribute]
        public CHSNSDBDataContext(IDbConnection connection)
            : base(connection, mappingCache)
        {
            OnCreated();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CHSNSDBDataContext"/> class.
        /// </summary>
        /// <param name="connection">The connection string.</param>
        /// <param name="mappingSource">The mapping source.</param>
        [DebuggerNonUserCodeAttribute]
        public CHSNSDBDataContext(string connection, MappingSource mappingSource)
            : base(connection, mappingSource)
        {
            OnCreated();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CHSNSDBDataContext"/> class.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        /// <param name="mappingSource">The mapping source.</param>
        [DebuggerNonUserCodeAttribute]
        public CHSNSDBDataContext(IDbConnection connection, MappingSource mappingSource)
            : base(connection, mappingSource)
        {
            OnCreated();
        }
        #endregion
        
        #region Tables
        /// <summary>Represents the dbo.Account table in the underlying database.</summary>
        public Table<Account> Account
        {
            get { return GetTable<Account>(); }
        }
        
        /// <summary>Represents the dbo.Album table in the underlying database.</summary>
        public Table<Album> Album
        {
            get { return GetTable<Album>(); }
        }
        
        /// <summary>Represents the dbo.Application table in the underlying database.</summary>
        public Table<Application> Application
        {
            get { return GetTable<Application>(); }
        }
        
        /// <summary>Represents the dbo.BasicInformation table in the underlying database.</summary>
        public Table<BasicInformation> BasicInformation
        {
            get { return GetTable<BasicInformation>(); }
        }
        
        /// <summary>Represents the dbo.Blogs table in the underlying database.</summary>
        public Table<Blogs> Blogs
        {
            get { return GetTable<Blogs>(); }
        }
        
        /// <summary>Represents the dbo.category table in the underlying database.</summary>
        public Table<Category> Category
        {
            get { return GetTable<Category>(); }
        }
        
        /// <summary>Represents the dbo.City table in the underlying database.</summary>
        public Table<City> City
        {
            get { return GetTable<City>(); }
        }
        
        /// <summary>Represents the dbo.Comment table in the underlying database.</summary>
        public Table<Comment> Comment
        {
            get { return GetTable<Comment>(); }
        }
        
        /// <summary>Represents the dbo.ContactInformation table in the underlying database.</summary>
        public Table<ContactInformation> ContactInformation
        {
            get { return GetTable<ContactInformation>(); }
        }
        
        /// <summary>Represents the dbo.Event table in the underlying database.</summary>
        public Table<Event> Event
        {
            get { return GetTable<Event>(); }
        }
        
        /// <summary>Represents the dbo.Field table in the underlying database.</summary>
        public Table<Field> Field
        {
            get { return GetTable<Field>(); }
        }
        
        /// <summary>Represents the dbo.FieldInformation table in the underlying database.</summary>
        public Table<FieldInformation> FieldInformation
        {
            get { return GetTable<FieldInformation>(); }
        }
        
        /// <summary>Represents the dbo.Friend table in the underlying database.</summary>
        public Table<Friend> Friend
        {
            get { return GetTable<Friend>(); }
        }
        
        /// <summary>Represents the dbo.Group table in the underlying database.</summary>
        public Table<Group> Group
        {
            get { return GetTable<Group>(); }
        }
        
        /// <summary>Represents the dbo.GroupUser table in the underlying database.</summary>
        public Table<GroupUser> GroupUser
        {
            get { return GetTable<GroupUser>(); }
        }
        
        /// <summary>Represents the dbo.LogTag table in the underlying database.</summary>
        public Table<LogTag> LogTag
        {
            get { return GetTable<LogTag>(); }
        }
        
        /// <summary>Represents the dbo.Message table in the underlying database.</summary>
        public Table<Message> Message
        {
            get { return GetTable<Message>(); }
        }
        
        /// <summary>Represents the dbo.MiniField table in the underlying database.</summary>
        public Table<MiniField> MiniField
        {
            get { return GetTable<MiniField>(); }
        }
        
        /// <summary>Represents the dbo.Note table in the underlying database.</summary>
        public Table<Note> Note
        {
            get { return GetTable<Note>(); }
        }
        
        /// <summary>Represents the dbo.PersonalInformation table in the underlying database.</summary>
        public Table<PersonalInformation> PersonalInformation
        {
            get { return GetTable<PersonalInformation>(); }
        }
        
        /// <summary>Represents the dbo.Photos table in the underlying database.</summary>
        public Table<Photos> Photos
        {
            get { return GetTable<Photos>(); }
        }
        
        /// <summary>Represents the dbo.Profile table in the underlying database.</summary>
        public Table<Profile> Profile
        {
            get { return GetTable<Profile>(); }
        }
        
        /// <summary>Represents the dbo.Province table in the underlying database.</summary>
        public Table<Province> Province
        {
            get { return GetTable<Province>(); }
        }
        
        /// <summary>Represents the dbo.Push table in the underlying database.</summary>
        public Table<Push> Push
        {
            get { return GetTable<Push>(); }
        }
        
        /// <summary>Represents the dbo.QinShi table in the underlying database.</summary>
        public Table<QinShi> QinShi
        {
            get { return GetTable<QinShi>(); }
        }
        
        /// <summary>Represents the dbo.Reply table in the underlying database.</summary>
        public Table<Reply> Reply
        {
            get { return GetTable<Reply>(); }
        }
        
        /// <summary>Represents the dbo.Services table in the underlying database.</summary>
        public Table<Services> ServicesTable
        {
            get { return GetTable<Services>(); }
        }
        
        /// <summary>Represents the dbo.SuperNote table in the underlying database.</summary>
        public Table<SuperNote> SuperNote
        {
            get { return GetTable<SuperNote>(); }
        }
        
        /// <summary>Represents the dbo.Tags table in the underlying database.</summary>
        public Table<Tags> Tags
        {
            get { return GetTable<Tags>(); }
        }
        
        /// <summary>Represents the dbo.ViewData table in the underlying database.</summary>
        public Table<ViewData> ViewData
        {
            get { return GetTable<ViewData>(); }
        }
        
        #endregion

        #region Functions
        #endregion

        #region Extensibility Method Definitions
        /// <summary>Called after this instance is created.</summary>
        partial void OnCreated();
        /// <summary>Called before a Account is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertAccount(Account instance);
        /// <summary>Called before a Account is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateAccount(Account instance);
        /// <summary>Called before a Account is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteAccount(Account instance);
        /// <summary>Called before a Album is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertAlbum(Album instance);
        /// <summary>Called before a Album is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateAlbum(Album instance);
        /// <summary>Called before a Album is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteAlbum(Album instance);
        /// <summary>Called before a Application is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertApplication(Application instance);
        /// <summary>Called before a Application is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateApplication(Application instance);
        /// <summary>Called before a Application is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteApplication(Application instance);
        /// <summary>Called before a BasicInformation is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertBasicInformation(BasicInformation instance);
        /// <summary>Called before a BasicInformation is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateBasicInformation(BasicInformation instance);
        /// <summary>Called before a BasicInformation is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteBasicInformation(BasicInformation instance);
        /// <summary>Called before a Blogs is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertBlogs(Blogs instance);
        /// <summary>Called before a Blogs is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateBlogs(Blogs instance);
        /// <summary>Called before a Blogs is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteBlogs(Blogs instance);
        /// <summary>Called before a Category is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertCategory(Category instance);
        /// <summary>Called before a Category is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateCategory(Category instance);
        /// <summary>Called before a Category is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteCategory(Category instance);
        /// <summary>Called before a City is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertCity(City instance);
        /// <summary>Called before a City is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateCity(City instance);
        /// <summary>Called before a City is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteCity(City instance);
        /// <summary>Called before a Comment is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertComment(Comment instance);
        /// <summary>Called before a Comment is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateComment(Comment instance);
        /// <summary>Called before a Comment is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteComment(Comment instance);
        /// <summary>Called before a ContactInformation is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertContactInformation(ContactInformation instance);
        /// <summary>Called before a ContactInformation is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateContactInformation(ContactInformation instance);
        /// <summary>Called before a ContactInformation is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteContactInformation(ContactInformation instance);
        /// <summary>Called before a Event is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertEvent(Event instance);
        /// <summary>Called before a Event is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateEvent(Event instance);
        /// <summary>Called before a Event is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteEvent(Event instance);
        /// <summary>Called before a Field is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertField(Field instance);
        /// <summary>Called before a Field is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateField(Field instance);
        /// <summary>Called before a Field is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteField(Field instance);
        /// <summary>Called before a FieldInformation is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertFieldInformation(FieldInformation instance);
        /// <summary>Called before a FieldInformation is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateFieldInformation(FieldInformation instance);
        /// <summary>Called before a FieldInformation is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteFieldInformation(FieldInformation instance);
        /// <summary>Called before a Friend is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertFriend(Friend instance);
        /// <summary>Called before a Friend is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateFriend(Friend instance);
        /// <summary>Called before a Friend is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteFriend(Friend instance);
        /// <summary>Called before a Group is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertGroup(Group instance);
        /// <summary>Called before a Group is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateGroup(Group instance);
        /// <summary>Called before a Group is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteGroup(Group instance);
        /// <summary>Called before a GroupUser is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertGroupUser(GroupUser instance);
        /// <summary>Called before a GroupUser is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateGroupUser(GroupUser instance);
        /// <summary>Called before a GroupUser is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteGroupUser(GroupUser instance);
        /// <summary>Called before a LogTag is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertLogTag(LogTag instance);
        /// <summary>Called before a LogTag is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateLogTag(LogTag instance);
        /// <summary>Called before a LogTag is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteLogTag(LogTag instance);
        /// <summary>Called before a Message is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertMessage(Message instance);
        /// <summary>Called before a Message is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateMessage(Message instance);
        /// <summary>Called before a Message is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteMessage(Message instance);
        /// <summary>Called before a MiniField is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertMiniField(MiniField instance);
        /// <summary>Called before a MiniField is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateMiniField(MiniField instance);
        /// <summary>Called before a MiniField is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteMiniField(MiniField instance);
        /// <summary>Called before a Note is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertNote(Note instance);
        /// <summary>Called before a Note is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateNote(Note instance);
        /// <summary>Called before a Note is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteNote(Note instance);
        /// <summary>Called before a PersonalInformation is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertPersonalInformation(PersonalInformation instance);
        /// <summary>Called before a PersonalInformation is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdatePersonalInformation(PersonalInformation instance);
        /// <summary>Called before a PersonalInformation is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeletePersonalInformation(PersonalInformation instance);
        /// <summary>Called before a Photos is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertPhotos(Photos instance);
        /// <summary>Called before a Photos is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdatePhotos(Photos instance);
        /// <summary>Called before a Photos is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeletePhotos(Photos instance);
        /// <summary>Called before a Profile is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertProfile(Profile instance);
        /// <summary>Called before a Profile is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateProfile(Profile instance);
        /// <summary>Called before a Profile is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteProfile(Profile instance);
        /// <summary>Called before a Province is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertProvince(Province instance);
        /// <summary>Called before a Province is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateProvince(Province instance);
        /// <summary>Called before a Province is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteProvince(Province instance);
        /// <summary>Called before a Push is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertPush(Push instance);
        /// <summary>Called before a Push is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdatePush(Push instance);
        /// <summary>Called before a Push is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeletePush(Push instance);
        /// <summary>Called before a QinShi is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertQinShi(QinShi instance);
        /// <summary>Called before a QinShi is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateQinShi(QinShi instance);
        /// <summary>Called before a QinShi is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteQinShi(QinShi instance);
        /// <summary>Called before a Reply is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertReply(Reply instance);
        /// <summary>Called before a Reply is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateReply(Reply instance);
        /// <summary>Called before a Reply is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteReply(Reply instance);
        /// <summary>Called before a Services is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertServices(Services instance);
        /// <summary>Called before a Services is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateServices(Services instance);
        /// <summary>Called before a Services is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteServices(Services instance);
        /// <summary>Called before a SuperNote is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertSuperNote(SuperNote instance);
        /// <summary>Called before a SuperNote is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateSuperNote(SuperNote instance);
        /// <summary>Called before a SuperNote is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteSuperNote(SuperNote instance);
        /// <summary>Called before a Tags is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertTags(Tags instance);
        /// <summary>Called before a Tags is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateTags(Tags instance);
        /// <summary>Called before a Tags is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteTags(Tags instance);
        /// <summary>Called before a ViewData is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertViewData(ViewData instance);
        /// <summary>Called before a ViewData is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateViewData(ViewData instance);
        /// <summary>Called before a ViewData is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteViewData(ViewData instance);
        #endregion
    }
}

