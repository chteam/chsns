﻿using System.Data.Linq;
namespace CHSNS.Operator
{
    using System.Data.Linq.Mapping;
    using System.ComponentModel;
	using System;
    using Abstractions;
	
	
	[DatabaseAttribute(Name="CHSNS.Servicebase")]
	internal partial class CHSNSDBDataContext : DataContext
	{
		
		private static MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAccount(Account instance);
    partial void UpdateAccount(Account instance);
    partial void DeleteAccount(Account instance);
    partial void InsertViewData(ViewData instance);
    partial void UpdateViewData(ViewData instance);
    partial void DeleteViewData(ViewData instance);
    partial void InsertAlbum(Album instance);
    partial void UpdateAlbum(Album instance);
    partial void DeleteAlbum(Album instance);
    partial void InsertApplication(Application instance);
    partial void UpdateApplication(Application instance);
    partial void DeleteApplication(Application instance);
    partial void InsertBasicInformation(BasicInformation instance);
    partial void UpdateBasicInformation(BasicInformation instance);
    partial void DeleteBasicInformation(BasicInformation instance);
    partial void InsertBlogs(Blogs instance);
    partial void UpdateBlogs(Blogs instance);
    partial void DeleteBlogs(Blogs instance);
    partial void InsertCategory(Category instance);
    partial void UpdateCategory(Category instance);
    partial void DeleteCategory(Category instance);
    partial void InsertComment(Comment instance);
    partial void UpdateComment(Comment instance);
    partial void DeleteComment(Comment instance);
    partial void InsertContactInformation(ContactInformation instance);
    partial void UpdateContactInformation(ContactInformation instance);
    partial void DeleteContactInformation(ContactInformation instance);
    partial void InsertEntry(Entry instance);
    partial void UpdateEntry(Entry instance);
    partial void DeleteEntry(Entry instance);
    partial void InsertEntryVersion(EntryVersion instance);
    partial void UpdateEntryVersion(EntryVersion instance);
    partial void DeleteEntryVersion(EntryVersion instance);
    partial void InsertEvent(Event instance);
    partial void UpdateEvent(Event instance);
    partial void DeleteEvent(Event instance);
    partial void InsertFieldInformation(FieldInformation instance);
    partial void UpdateFieldInformation(FieldInformation instance);
    partial void DeleteFieldInformation(FieldInformation instance);
    partial void InsertFriend(Friend instance);
    partial void UpdateFriend(Friend instance);
    partial void DeleteFriend(Friend instance);
    partial void InsertGroup(Group instance);
    partial void UpdateGroup(Group instance);
    partial void DeleteGroup(Group instance);
    partial void InsertGroupUser(GroupUser instance);
    partial void UpdateGroupUser(GroupUser instance);
    partial void DeleteGroupUser(GroupUser instance);
    partial void InsertLogTag(LogTag instance);
    partial void UpdateLogTag(LogTag instance);
    partial void DeleteLogTag(LogTag instance);
    partial void InsertMessage(Message instance);
    partial void UpdateMessage(Message instance);
    partial void DeleteMessage(Message instance);
    partial void InsertNote(Note instance);
    partial void UpdateNote(Note instance);
    partial void DeleteNote(Note instance);
    partial void InsertPersonalInformation(PersonalInformation instance);
    partial void UpdatePersonalInformation(PersonalInformation instance);
    partial void DeletePersonalInformation(PersonalInformation instance);
    partial void InsertPhoto(Photo instance);
    partial void UpdatePhoto(Photo instance);
    partial void DeletePhoto(Photo instance);
    partial void InsertProfile(Profile instance);
    partial void UpdateProfile(Profile instance);
    partial void DeleteProfile(Profile instance);
    partial void InsertPush(Push instance);
    partial void UpdatePush(Push instance);
    partial void DeletePush(Push instance);
    partial void InsertReply(Reply instance);
    partial void UpdateReply(Reply instance);
    partial void DeleteReply(Reply instance);
    partial void InsertServices(Services instance);
    partial void UpdateServices(Services instance);
    partial void DeleteServices(Services instance);
    partial void InsertSuperNote(SuperNote instance);
    partial void UpdateSuperNote(SuperNote instance);
    partial void DeleteSuperNote(SuperNote instance);
    partial void InsertTags(Tags instance);
    partial void UpdateTags(Tags instance);
    partial void DeleteTags(Tags instance);
    #endregion
		

		public CHSNSDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CHSNSDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CHSNSDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CHSNSDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Account> Account
		{
			get
			{
				return this.GetTable<Account>();
			}
		}
		
		public Table<ViewData> ViewData
		{
			get
			{
				return this.GetTable<ViewData>();
			}
		}
		
		public System.Data.Linq.Table<Album> Album
		{
			get
			{
				return this.GetTable<Album>();
			}
		}
		
		public System.Data.Linq.Table<Application> Application
		{
			get
			{
				return this.GetTable<Application>();
			}
		}
		
		public System.Data.Linq.Table<BasicInformation> BasicInformation
		{
			get
			{
				return this.GetTable<BasicInformation>();
			}
		}
		
		public System.Data.Linq.Table<Blogs> Blogs
		{
			get
			{
				return this.GetTable<Blogs>();
			}
		}
		
		public System.Data.Linq.Table<Category> Category
		{
			get
			{
				return this.GetTable<Category>();
			}
		}
		
		public System.Data.Linq.Table<Comment> Comment
		{
			get
			{
				return this.GetTable<Comment>();
			}
		}
		
		public System.Data.Linq.Table<ContactInformation> ContactInformation
		{
			get
			{
				return this.GetTable<ContactInformation>();
			}
		}
		
		public System.Data.Linq.Table<Entry> Entry
		{
			get
			{
				return this.GetTable<Entry>();
			}
		}
		
		public System.Data.Linq.Table<EntryVersion> EntryVersion
		{
			get
			{
				return this.GetTable<EntryVersion>();
			}
		}
		
		public System.Data.Linq.Table<Event> Event
		{
			get
			{
				return this.GetTable<Event>();
			}
		}
		
		public System.Data.Linq.Table<FieldInformation> FieldInformation
		{
			get
			{
				return this.GetTable<FieldInformation>();
			}
		}
		
		public System.Data.Linq.Table<Friend> Friend
		{
			get
			{
				return this.GetTable<Friend>();
			}
		}
		
		public System.Data.Linq.Table<Group> Group
		{
			get
			{
				return this.GetTable<Group>();
			}
		}
		
		public System.Data.Linq.Table<GroupUser> GroupUser
		{
			get
			{
				return this.GetTable<GroupUser>();
			}
		}
		
		public System.Data.Linq.Table<LogTag> LogTag
		{
			get
			{
				return this.GetTable<LogTag>();
			}
		}
		
		public System.Data.Linq.Table<Message> Message
		{
			get
			{
				return this.GetTable<Message>();
			}
		}
		
		public System.Data.Linq.Table<Note> Note
		{
			get
			{
				return this.GetTable<Note>();
			}
		}
		
		public System.Data.Linq.Table<PersonalInformation> PersonalInformation
		{
			get
			{
				return this.GetTable<PersonalInformation>();
			}
		}
		
		public System.Data.Linq.Table<Photo> Photo
		{
			get
			{
				return this.GetTable<Photo>();
			}
		}
		
		public System.Data.Linq.Table<Profile> Profile
		{
			get
			{
				return this.GetTable<Profile>();
			}
		}
		
		public System.Data.Linq.Table<Push> Push
		{
			get
			{
				return this.GetTable<Push>();
			}
		}
		
		public System.Data.Linq.Table<Reply> Reply
		{
			get
			{
				return this.GetTable<Reply>();
			}
		}
		
		public System.Data.Linq.Table<Services> Services
		{
			get
			{
				return this.GetTable<Services>();
			}
		}
		
		public System.Data.Linq.Table<SuperNote> SuperNote
		{
			get
			{
				return this.GetTable<SuperNote>();
			}
		}
		
		public System.Data.Linq.Table<Tags> Tags
		{
			get
			{
				return this.GetTable<Tags>();
			}
		}
	}
	
	[Table(Name="dbo.Account")]
    internal partial class Account : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _UserID;
		
		private string _Username;
		
		private string _Password;
		
		private System.Nullable<long> _Code;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnCodeChanging(System.Nullable<long> value);
    partial void OnCodeChanged();
    #endregion
		
		public Account()
		{
			OnCreated();
		}
		
		[Column(Storage="_UserID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_Username", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[Column(Storage="_Password", DbType="Char(32) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[Column(Storage="_Code", DbType="BigInt")]
		public System.Nullable<long> Code
		{
			get
			{
				return this._Code;
			}
			set
			{
				if ((this._Code != value))
				{
					this.OnCodeChanging(value);
					this.SendPropertyChanging();
					this._Code = value;
					this.SendPropertyChanged("Code");
					this.OnCodeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.ViewData")]
    internal partial class ViewData : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private long _OwnerID;
		
		private long _ViewerID;
		
		private string _IpandComputer;
		
		private string _ViewPageUrl;
		
		private string _LastUrl;
		
		private System.DateTime _ViewTime;
		
		private byte _ViewClass;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnOwnerIDChanging(long value);
    partial void OnOwnerIDChanged();
    partial void OnViewerIDChanging(long value);
    partial void OnViewerIDChanged();
    partial void OnIpandComputerChanging(string value);
    partial void OnIpandComputerChanged();
    partial void OnViewPageUrlChanging(string value);
    partial void OnViewPageUrlChanged();
    partial void OnLastUrlChanging(string value);
    partial void OnLastUrlChanged();
    partial void OnViewTimeChanging(System.DateTime value);
    partial void OnViewTimeChanged();
    partial void OnViewClassChanging(byte value);
    partial void OnViewClassChanged();
    #endregion
		
		public ViewData()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_OwnerID", DbType="BigInt NOT NULL")]
		public long OwnerID
		{
			get
			{
				return this._OwnerID;
			}
			set
			{
				if ((this._OwnerID != value))
				{
					this.OnOwnerIDChanging(value);
					this.SendPropertyChanging();
					this._OwnerID = value;
					this.SendPropertyChanged("OwnerID");
					this.OnOwnerIDChanged();
				}
			}
		}
		
		[Column(Storage="_ViewerID", DbType="BigInt NOT NULL")]
		public long ViewerID
		{
			get
			{
				return this._ViewerID;
			}
			set
			{
				if ((this._ViewerID != value))
				{
					this.OnViewerIDChanging(value);
					this.SendPropertyChanging();
					this._ViewerID = value;
					this.SendPropertyChanged("ViewerID");
					this.OnViewerIDChanged();
				}
			}
		}
		
		[Column(Storage="_IpandComputer", DbType="NVarChar(50)")]
		public string IpandComputer
		{
			get
			{
				return this._IpandComputer;
			}
			set
			{
				if ((this._IpandComputer != value))
				{
					this.OnIpandComputerChanging(value);
					this.SendPropertyChanging();
					this._IpandComputer = value;
					this.SendPropertyChanged("IpandComputer");
					this.OnIpandComputerChanged();
				}
			}
		}
		
		[Column(Storage="_ViewPageUrl", DbType="NVarChar(255)")]
		public string ViewPageUrl
		{
			get
			{
				return this._ViewPageUrl;
			}
			set
			{
				if ((this._ViewPageUrl != value))
				{
					this.OnViewPageUrlChanging(value);
					this.SendPropertyChanging();
					this._ViewPageUrl = value;
					this.SendPropertyChanged("ViewPageUrl");
					this.OnViewPageUrlChanged();
				}
			}
		}
		
		[Column(Storage="_LastUrl", DbType="NVarChar(255)")]
		public string LastUrl
		{
			get
			{
				return this._LastUrl;
			}
			set
			{
				if ((this._LastUrl != value))
				{
					this.OnLastUrlChanging(value);
					this.SendPropertyChanging();
					this._LastUrl = value;
					this.SendPropertyChanged("LastUrl");
					this.OnLastUrlChanged();
				}
			}
		}
		
		[Column(Storage="_ViewTime", DbType="DateTime NOT NULL")]
		public System.DateTime ViewTime
		{
			get
			{
				return this._ViewTime;
			}
			set
			{
				if ((this._ViewTime != value))
				{
					this.OnViewTimeChanging(value);
					this.SendPropertyChanging();
					this._ViewTime = value;
					this.SendPropertyChanged("ViewTime");
					this.OnViewTimeChanged();
				}
			}
		}
		
		[Column(Storage="_ViewClass", DbType="TinyInt NOT NULL")]
		public byte ViewClass
		{
			get
			{
				return this._ViewClass;
			}
			set
			{
				if ((this._ViewClass != value))
				{
					this.OnViewClassChanging(value);
					this.SendPropertyChanging();
					this._ViewClass = value;
					this.SendPropertyChanged("ViewClass");
					this.OnViewClassChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Album")]
    internal partial class Album : INotifyPropertyChanging, INotifyPropertyChanged, IAlbum
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Name;
		
		private string _Location;
		
		private string _Description;
		
		private System.DateTime _AddTime;
		
		private string _FaceUrl;
		
		private int _Count;
		
		private long _UserID;
		
		private int _Order;
		
		private byte _ShowLevel;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnLocationChanging(string value);
    partial void OnLocationChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnAddTimeChanging(System.DateTime value);
    partial void OnAddTimeChanged();
    partial void OnFaceUrlChanging(string value);
    partial void OnFaceUrlChanged();
    partial void OnCountChanging(int value);
    partial void OnCountChanged();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnOrderChanging(int value);
    partial void OnOrderChanged();
    partial void OnShowLevelChanging(byte value);
    partial void OnShowLevelChanged();
    #endregion
		
		public Album()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Location", DbType="NVarChar(50)")]
		public string Location
		{
			get
			{
				return this._Location;
			}
			set
			{
				if ((this._Location != value))
				{
					this.OnLocationChanging(value);
					this.SendPropertyChanging();
					this._Location = value;
					this.SendPropertyChanged("Location");
					this.OnLocationChanged();
				}
			}
		}
		
		[Column(Storage="_Description", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime AddTime
		{
			get
			{
				return this._AddTime;
			}
			set
			{
				if ((this._AddTime != value))
				{
					this.OnAddTimeChanging(value);
					this.SendPropertyChanging();
					this._AddTime = value;
					this.SendPropertyChanged("AddTime");
					this.OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_FaceUrl", DbType="NVarChar(250)")]
		public string FaceUrl
		{
			get
			{
				return this._FaceUrl;
			}
			set
			{
				if ((this._FaceUrl != value))
				{
					this.OnFaceUrlChanging(value);
					this.SendPropertyChanging();
					this._FaceUrl = value;
					this.SendPropertyChanged("FaceUrl");
					this.OnFaceUrlChanged();
				}
			}
		}
		
		[Column(Storage="_Count", DbType="Int NOT NULL")]
		public int Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				if ((this._Count != value))
				{
					this.OnCountChanging(value);
					this.SendPropertyChanging();
					this._Count = value;
					this.SendPropertyChanged("Count");
					this.OnCountChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Name="[Order]", Storage="_Order", DbType="Int NOT NULL")]
		public int Order
		{
			get
			{
				return this._Order;
			}
			set
			{
				if ((this._Order != value))
				{
					this.OnOrderChanging(value);
					this.SendPropertyChanging();
					this._Order = value;
					this.SendPropertyChanged("Order");
					this.OnOrderChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="TinyInt NOT NULL")]
		public byte ShowLevel
		{
			get
			{
				return this._ShowLevel;
			}
			set
			{
				if ((this._ShowLevel != value))
				{
					this.OnShowLevelChanging(value);
					this.SendPropertyChanging();
					this._ShowLevel = value;
					this.SendPropertyChanged("ShowLevel");
					this.OnShowLevelChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Application")]
    internal partial class Application : INotifyPropertyChanging, INotifyPropertyChanged, IApplication
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Controller;
		
		private string _Action;
		
		private string _ParamStr;
		
		private string _ClassName;
		
		private string _FullName;
		
		private string _ShortName;
		
		private string _Vision;
		
		private string _Icon;
		
		private System.Nullable<long> _Authorid;
		
		private System.DateTime _Addtime;
		
		private System.DateTime _Edittime;
		
		private string _Description;
		
		private bool _IsSystem;
		
		private bool _IsTrue;
		
		private string _DescriptionUrl;
		
		private long _UserCount;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnControllerChanging(string value);
    partial void OnControllerChanged();
    partial void OnActionChanging(string value);
    partial void OnActionChanged();
    partial void OnParamStrChanging(string value);
    partial void OnParamStrChanged();
    partial void OnClassNameChanging(string value);
    partial void OnClassNameChanged();
    partial void OnFullNameChanging(string value);
    partial void OnFullNameChanged();
    partial void OnShortNameChanging(string value);
    partial void OnShortNameChanged();
    partial void OnVisionChanging(string value);
    partial void OnVisionChanged();
    partial void OnIconChanging(string value);
    partial void OnIconChanged();
    partial void OnAuthoridChanging(System.Nullable<long> value);
    partial void OnAuthoridChanged();
    partial void OnAddtimeChanging(System.DateTime value);
    partial void OnAddtimeChanged();
    partial void OnEdittimeChanging(System.DateTime value);
    partial void OnEdittimeChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnIsSystemChanging(bool value);
    partial void OnIsSystemChanged();
    partial void OnIsTrueChanging(bool value);
    partial void OnIsTrueChanged();
    partial void OnDescriptionUrlChanging(string value);
    partial void OnDescriptionUrlChanged();
    partial void OnUserCountChanging(long value);
    partial void OnUserCountChanged();
    #endregion
		
		public Application()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Controller", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Controller
		{
			get
			{
				return this._Controller;
			}
			set
			{
				if ((this._Controller != value))
				{
					this.OnControllerChanging(value);
					this.SendPropertyChanging();
					this._Controller = value;
					this.SendPropertyChanged("Controller");
					this.OnControllerChanged();
				}
			}
		}
		
		[Column(Storage="_Action", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Action
		{
			get
			{
				return this._Action;
			}
			set
			{
				if ((this._Action != value))
				{
					this.OnActionChanging(value);
					this.SendPropertyChanging();
					this._Action = value;
					this.SendPropertyChanged("Action");
					this.OnActionChanged();
				}
			}
		}
		
		[Column(Storage="_ParamStr", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string ParamStr
		{
			get
			{
				return this._ParamStr;
			}
			set
			{
				if ((this._ParamStr != value))
				{
					this.OnParamStrChanging(value);
					this.SendPropertyChanging();
					this._ParamStr = value;
					this.SendPropertyChanged("ParamStr");
					this.OnParamStrChanged();
				}
			}
		}
		
		[Column(Storage="_ClassName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ClassName
		{
			get
			{
				return this._ClassName;
			}
			set
			{
				if ((this._ClassName != value))
				{
					this.OnClassNameChanging(value);
					this.SendPropertyChanging();
					this._ClassName = value;
					this.SendPropertyChanged("ClassName");
					this.OnClassNameChanged();
				}
			}
		}
		
		[Column(Storage="_FullName", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
		public string FullName
		{
			get
			{
				return this._FullName;
			}
			set
			{
				if ((this._FullName != value))
				{
					this.OnFullNameChanging(value);
					this.SendPropertyChanging();
					this._FullName = value;
					this.SendPropertyChanged("FullName");
					this.OnFullNameChanged();
				}
			}
		}
		
		[Column(Storage="_ShortName", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string ShortName
		{
			get
			{
				return this._ShortName;
			}
			set
			{
				if ((this._ShortName != value))
				{
					this.OnShortNameChanging(value);
					this.SendPropertyChanging();
					this._ShortName = value;
					this.SendPropertyChanged("ShortName");
					this.OnShortNameChanged();
				}
			}
		}
		
		[Column(Storage="_Vision", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Vision
		{
			get
			{
				return this._Vision;
			}
			set
			{
				if ((this._Vision != value))
				{
					this.OnVisionChanging(value);
					this.SendPropertyChanging();
					this._Vision = value;
					this.SendPropertyChanged("Vision");
					this.OnVisionChanged();
				}
			}
		}
		
		[Column(Storage="_Icon", DbType="NVarChar(250)")]
		public string Icon
		{
			get
			{
				return this._Icon;
			}
			set
			{
				if ((this._Icon != value))
				{
					this.OnIconChanging(value);
					this.SendPropertyChanging();
					this._Icon = value;
					this.SendPropertyChanged("Icon");
					this.OnIconChanged();
				}
			}
		}
		
		[Column(Storage="_Authorid", DbType="BigInt")]
		public System.Nullable<long> Authorid
		{
			get
			{
				return this._Authorid;
			}
			set
			{
				if ((this._Authorid != value))
				{
					this.OnAuthoridChanging(value);
					this.SendPropertyChanging();
					this._Authorid = value;
					this.SendPropertyChanged("Authorid");
					this.OnAuthoridChanged();
				}
			}
		}
		
		[Column(Storage="_Addtime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime Addtime
		{
			get
			{
				return this._Addtime;
			}
			set
			{
				if ((this._Addtime != value))
				{
					this.OnAddtimeChanging(value);
					this.SendPropertyChanging();
					this._Addtime = value;
					this.SendPropertyChanged("Addtime");
					this.OnAddtimeChanged();
				}
			}
		}
		
		[Column(Storage="_Edittime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime Edittime
		{
			get
			{
				return this._Edittime;
			}
			set
			{
				if ((this._Edittime != value))
				{
					this.OnEdittimeChanging(value);
					this.SendPropertyChanging();
					this._Edittime = value;
					this.SendPropertyChanged("Edittime");
					this.OnEdittimeChanged();
				}
			}
		}
		
		[Column(Storage="_Description", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_IsSystem", DbType="Bit NOT NULL")]
		public bool IsSystem
		{
			get
			{
				return this._IsSystem;
			}
			set
			{
				if ((this._IsSystem != value))
				{
					this.OnIsSystemChanging(value);
					this.SendPropertyChanging();
					this._IsSystem = value;
					this.SendPropertyChanged("IsSystem");
					this.OnIsSystemChanged();
				}
			}
		}
		
		[Column(Storage="_IsTrue", DbType="Bit NOT NULL")]
		public bool IsTrue
		{
			get
			{
				return this._IsTrue;
			}
			set
			{
				if ((this._IsTrue != value))
				{
					this.OnIsTrueChanging(value);
					this.SendPropertyChanging();
					this._IsTrue = value;
					this.SendPropertyChanged("IsTrue");
					this.OnIsTrueChanged();
				}
			}
		}
		
		[Column(Storage="_DescriptionUrl", DbType="NVarChar(250)")]
		public string DescriptionUrl
		{
			get
			{
				return this._DescriptionUrl;
			}
			set
			{
				if ((this._DescriptionUrl != value))
				{
					this.OnDescriptionUrlChanging(value);
					this.SendPropertyChanging();
					this._DescriptionUrl = value;
					this.SendPropertyChanged("DescriptionUrl");
					this.OnDescriptionUrlChanged();
				}
			}
		}
		
		[Column(Storage="_UserCount", DbType="BigInt NOT NULL")]
		public long UserCount
		{
			get
			{
				return this._UserCount;
			}
			set
			{
				if ((this._UserCount != value))
				{
					this.OnUserCountChanging(value);
					this.SendPropertyChanging();
					this._UserCount = value;
					this.SendPropertyChanged("UserCount");
					this.OnUserCountChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.BasicInformation")]
    internal partial class BasicInformation : INotifyPropertyChanging, INotifyPropertyChanged, IBasicInformation
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _UserID;
		
		private string _Name;
		
		private string _Email;
		
		private bool _IsEmailTrue;
		
		private System.Nullable<bool> _Sex;
		
		private System.Nullable<System.DateTime> _Birthday;
		
		private int _ProvinceID;
		
		private long _CityID;
		
		private byte _ShowLevel;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnIsEmailTrueChanging(bool value);
    partial void OnIsEmailTrueChanged();
    partial void OnSexChanging(System.Nullable<bool> value);
    partial void OnSexChanged();
    partial void OnBirthdayChanging(System.Nullable<System.DateTime> value);
    partial void OnBirthdayChanged();
    partial void OnProvinceIDChanging(int value);
    partial void OnProvinceIDChanged();
    partial void OnCityIDChanging(long value);
    partial void OnCityIDChanged();
    partial void OnShowLevelChanging(byte value);
    partial void OnShowLevelChanged();
    #endregion
		
		public BasicInformation()
		{
			OnCreated();
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(20)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Email", DbType="NVarChar(500)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[Column(Storage="_IsEmailTrue", DbType="Bit NOT NULL")]
		public bool IsEmailTrue
		{
			get
			{
				return this._IsEmailTrue;
			}
			set
			{
				if ((this._IsEmailTrue != value))
				{
					this.OnIsEmailTrueChanging(value);
					this.SendPropertyChanging();
					this._IsEmailTrue = value;
					this.SendPropertyChanged("IsEmailTrue");
					this.OnIsEmailTrueChanged();
				}
			}
		}
		
		[Column(Storage="_Sex", DbType="Bit")]
		public System.Nullable<bool> Sex
		{
			get
			{
				return this._Sex;
			}
			set
			{
				if ((this._Sex != value))
				{
					this.OnSexChanging(value);
					this.SendPropertyChanging();
					this._Sex = value;
					this.SendPropertyChanged("Sex");
					this.OnSexChanged();
				}
			}
		}
		
		[Column(Storage="_Birthday", DbType="SmallDateTime")]
		public System.Nullable<System.DateTime> Birthday
		{
			get
			{
				return this._Birthday;
			}
			set
			{
				if ((this._Birthday != value))
				{
					this.OnBirthdayChanging(value);
					this.SendPropertyChanging();
					this._Birthday = value;
					this.SendPropertyChanged("Birthday");
					this.OnBirthdayChanged();
				}
			}
		}
		
		[Column(Storage="_ProvinceID", DbType="Int NOT NULL")]
		public int ProvinceID
		{
			get
			{
				return this._ProvinceID;
			}
			set
			{
				if ((this._ProvinceID != value))
				{
					this.OnProvinceIDChanging(value);
					this.SendPropertyChanging();
					this._ProvinceID = value;
					this.SendPropertyChanged("ProvinceID");
					this.OnProvinceIDChanged();
				}
			}
		}
		
		[Column(Storage="_CityID", DbType="BigInt NOT NULL")]
		public long CityID
		{
			get
			{
				return this._CityID;
			}
			set
			{
				if ((this._CityID != value))
				{
					this.OnCityIDChanging(value);
					this.SendPropertyChanging();
					this._CityID = value;
					this.SendPropertyChanged("CityID");
					this.OnCityIDChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="TinyInt NOT NULL")]
		public byte ShowLevel
		{
			get
			{
				return this._ShowLevel;
			}
			set
			{
				if ((this._ShowLevel != value))
				{
					this.OnShowLevelChanging(value);
					this.SendPropertyChanging();
					this._ShowLevel = value;
					this.SendPropertyChanged("ShowLevel");
					this.OnShowLevelChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Blogs")]
    internal partial class Blogs : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _UserID;
		
		private System.DateTime _CreateTime;
		
		private string _Title;
		
		private string _SubTitle;
		
		private string _Publish;
		
		private string _WriteName;
		
		private string _CommentEmail;
		
		private string _Skin;
		
		private string _Css;
		
		private string _MetaKey;
		
		private bool _IsWebServices;
		
		private long _PostCount;
		
		private long _CommentCount;
		
		private long _TrackBackCount;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnCreateTimeChanging(System.DateTime value);
    partial void OnCreateTimeChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnSubTitleChanging(string value);
    partial void OnSubTitleChanged();
    partial void OnPublishChanging(string value);
    partial void OnPublishChanged();
    partial void OnWriteNameChanging(string value);
    partial void OnWriteNameChanged();
    partial void OnCommentEmailChanging(string value);
    partial void OnCommentEmailChanged();
    partial void OnSkinChanging(string value);
    partial void OnSkinChanged();
    partial void OnCssChanging(string value);
    partial void OnCssChanged();
    partial void OnMetaKeyChanging(string value);
    partial void OnMetaKeyChanged();
    partial void OnIsWebServicesChanging(bool value);
    partial void OnIsWebServicesChanged();
    partial void OnPostCountChanging(long value);
    partial void OnPostCountChanged();
    partial void OnCommentCountChanging(long value);
    partial void OnCommentCountChanged();
    partial void OnTrackBackCountChanging(long value);
    partial void OnTrackBackCountChanged();
    #endregion
		
		public Blogs()
		{
			OnCreated();
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_CreateTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime CreateTime
		{
			get
			{
				return this._CreateTime;
			}
			set
			{
				if ((this._CreateTime != value))
				{
					this.OnCreateTimeChanging(value);
					this.SendPropertyChanging();
					this._CreateTime = value;
					this.SendPropertyChanged("CreateTime");
					this.OnCreateTimeChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_SubTitle", DbType="NVarChar(500)")]
		public string SubTitle
		{
			get
			{
				return this._SubTitle;
			}
			set
			{
				if ((this._SubTitle != value))
				{
					this.OnSubTitleChanging(value);
					this.SendPropertyChanging();
					this._SubTitle = value;
					this.SendPropertyChanged("SubTitle");
					this.OnSubTitleChanged();
				}
			}
		}
		
		[Column(Storage="_Publish", DbType="NVarChar(MAX)")]
		public string Publish
		{
			get
			{
				return this._Publish;
			}
			set
			{
				if ((this._Publish != value))
				{
					this.OnPublishChanging(value);
					this.SendPropertyChanging();
					this._Publish = value;
					this.SendPropertyChanged("Publish");
					this.OnPublishChanged();
				}
			}
		}
		
		[Column(Storage="_WriteName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string WriteName
		{
			get
			{
				return this._WriteName;
			}
			set
			{
				if ((this._WriteName != value))
				{
					this.OnWriteNameChanging(value);
					this.SendPropertyChanging();
					this._WriteName = value;
					this.SendPropertyChanged("WriteName");
					this.OnWriteNameChanged();
				}
			}
		}
		
		[Column(Storage="_CommentEmail", DbType="NVarChar(50)")]
		public string CommentEmail
		{
			get
			{
				return this._CommentEmail;
			}
			set
			{
				if ((this._CommentEmail != value))
				{
					this.OnCommentEmailChanging(value);
					this.SendPropertyChanging();
					this._CommentEmail = value;
					this.SendPropertyChanged("CommentEmail");
					this.OnCommentEmailChanged();
				}
			}
		}
		
		[Column(Storage="_Skin", DbType="NVarChar(50)")]
		public string Skin
		{
			get
			{
				return this._Skin;
			}
			set
			{
				if ((this._Skin != value))
				{
					this.OnSkinChanging(value);
					this.SendPropertyChanging();
					this._Skin = value;
					this.SendPropertyChanged("Skin");
					this.OnSkinChanged();
				}
			}
		}
		
		[Column(Storage="_Css", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Css
		{
			get
			{
				return this._Css;
			}
			set
			{
				if ((this._Css != value))
				{
					this.OnCssChanging(value);
					this.SendPropertyChanging();
					this._Css = value;
					this.SendPropertyChanged("Css");
					this.OnCssChanged();
				}
			}
		}
		
		[Column(Storage="_MetaKey", DbType="NVarChar(400)")]
		public string MetaKey
		{
			get
			{
				return this._MetaKey;
			}
			set
			{
				if ((this._MetaKey != value))
				{
					this.OnMetaKeyChanging(value);
					this.SendPropertyChanging();
					this._MetaKey = value;
					this.SendPropertyChanged("MetaKey");
					this.OnMetaKeyChanged();
				}
			}
		}
		
		[Column(Storage="_IsWebServices", DbType="Bit NOT NULL")]
		public bool IsWebServices
		{
			get
			{
				return this._IsWebServices;
			}
			set
			{
				if ((this._IsWebServices != value))
				{
					this.OnIsWebServicesChanging(value);
					this.SendPropertyChanging();
					this._IsWebServices = value;
					this.SendPropertyChanged("IsWebServices");
					this.OnIsWebServicesChanged();
				}
			}
		}
		
		[Column(Storage="_PostCount", DbType="BigInt NOT NULL")]
		public long PostCount
		{
			get
			{
				return this._PostCount;
			}
			set
			{
				if ((this._PostCount != value))
				{
					this.OnPostCountChanging(value);
					this.SendPropertyChanging();
					this._PostCount = value;
					this.SendPropertyChanged("PostCount");
					this.OnPostCountChanged();
				}
			}
		}
		
		[Column(Storage="_CommentCount", DbType="BigInt NOT NULL")]
		public long CommentCount
		{
			get
			{
				return this._CommentCount;
			}
			set
			{
				if ((this._CommentCount != value))
				{
					this.OnCommentCountChanging(value);
					this.SendPropertyChanging();
					this._CommentCount = value;
					this.SendPropertyChanged("CommentCount");
					this.OnCommentCountChanged();
				}
			}
		}
		
		[Column(Storage="_TrackBackCount", DbType="BigInt NOT NULL")]
		public long TrackBackCount
		{
			get
			{
				return this._TrackBackCount;
			}
			set
			{
				if ((this._TrackBackCount != value))
				{
					this.OnTrackBackCountChanging(value);
					this.SendPropertyChanging();
					this._TrackBackCount = value;
					this.SendPropertyChanged("TrackBackCount");
					this.OnTrackBackCountChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Category")]
    internal partial class Category : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Name;
		
		private byte _Type;
		
		private long _Count;
		
		private System.Nullable<long> _UserID;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnTypeChanging(byte value);
    partial void OnTypeChanged();
    partial void OnCountChanging(long value);
    partial void OnCountChanged();
    partial void OnUserIDChanging(System.Nullable<long> value);
    partial void OnUserIDChanged();
    #endregion
		
		public Category()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Type", DbType="TinyInt NOT NULL")]
		public byte Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		[Column(Storage="_Count", DbType="BigInt NOT NULL")]
		public long Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				if ((this._Count != value))
				{
					this.OnCountChanging(value);
					this.SendPropertyChanging();
					this._Count = value;
					this.SendPropertyChanged("Count");
					this.OnCountChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt")]
		public System.Nullable<long> UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Comment")]
    internal partial class Comment : INotifyPropertyChanging, INotifyPropertyChanged, IComment
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private System.Nullable<long> _ShowerID;
		
		private long _OwnerID;
		
		private long _SenderID;
		
		private System.DateTime _AddTime;
		
		private string _Body;
		
		private bool _IsReply;
		
		private bool _IsSee;
		
		private bool _IsDel;
		
		private byte _Type;
		
		private byte _IsTellMe;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnShowerIDChanging(System.Nullable<long> value);
    partial void OnShowerIDChanged();
    partial void OnOwnerIDChanging(long value);
    partial void OnOwnerIDChanged();
    partial void OnSenderIDChanging(long value);
    partial void OnSenderIDChanged();
    partial void OnAddTimeChanging(System.DateTime value);
    partial void OnAddTimeChanged();
    partial void OnBodyChanging(string value);
    partial void OnBodyChanged();
    partial void OnIsReplyChanging(bool value);
    partial void OnIsReplyChanged();
    partial void OnIsSeeChanging(bool value);
    partial void OnIsSeeChanged();
    partial void OnIsDelChanging(bool value);
    partial void OnIsDelChanged();
    partial void OnTypeChanging(byte value);
    partial void OnTypeChanged();
    partial void OnIsTellMeChanging(byte value);
    partial void OnIsTellMeChanged();
    #endregion
		
		public Comment()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_ShowerID", DbType="BigInt")]
		public System.Nullable<long> ShowerID
		{
			get
			{
				return this._ShowerID;
			}
			set
			{
				if ((this._ShowerID != value))
				{
					this.OnShowerIDChanging(value);
					this.SendPropertyChanging();
					this._ShowerID = value;
					this.SendPropertyChanged("ShowerID");
					this.OnShowerIDChanged();
				}
			}
		}
		
		[Column(Storage="_OwnerID", DbType="BigInt NOT NULL")]
		public long OwnerID
		{
			get
			{
				return this._OwnerID;
			}
			set
			{
				if ((this._OwnerID != value))
				{
					this.OnOwnerIDChanging(value);
					this.SendPropertyChanging();
					this._OwnerID = value;
					this.SendPropertyChanged("OwnerID");
					this.OnOwnerIDChanged();
				}
			}
		}
		
		[Column(Storage="_SenderID", DbType="BigInt NOT NULL")]
		public long SenderID
		{
			get
			{
				return this._SenderID;
			}
			set
			{
				if ((this._SenderID != value))
				{
					this.OnSenderIDChanging(value);
					this.SendPropertyChanging();
					this._SenderID = value;
					this.SendPropertyChanged("SenderID");
					this.OnSenderIDChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime AddTime
		{
			get
			{
				return this._AddTime;
			}
			set
			{
				if ((this._AddTime != value))
				{
					this.OnAddTimeChanging(value);
					this.SendPropertyChanging();
					this._AddTime = value;
					this.SendPropertyChanged("AddTime");
					this.OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_Body", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Body
		{
			get
			{
				return this._Body;
			}
			set
			{
				if ((this._Body != value))
				{
					this.OnBodyChanging(value);
					this.SendPropertyChanging();
					this._Body = value;
					this.SendPropertyChanged("Body");
					this.OnBodyChanged();
				}
			}
		}
		
		[Column(Storage="_IsReply", DbType="Bit NOT NULL")]
		public bool IsReply
		{
			get
			{
				return this._IsReply;
			}
			set
			{
				if ((this._IsReply != value))
				{
					this.OnIsReplyChanging(value);
					this.SendPropertyChanging();
					this._IsReply = value;
					this.SendPropertyChanged("IsReply");
					this.OnIsReplyChanged();
				}
			}
		}
		
		[Column(Storage="_IsSee", DbType="Bit NOT NULL")]
		public bool IsSee
		{
			get
			{
				return this._IsSee;
			}
			set
			{
				if ((this._IsSee != value))
				{
					this.OnIsSeeChanging(value);
					this.SendPropertyChanging();
					this._IsSee = value;
					this.SendPropertyChanged("IsSee");
					this.OnIsSeeChanged();
				}
			}
		}
		
		[Column(Storage="_IsDel", DbType="Bit NOT NULL")]
		public bool IsDel
		{
			get
			{
				return this._IsDel;
			}
			set
			{
				if ((this._IsDel != value))
				{
					this.OnIsDelChanging(value);
					this.SendPropertyChanging();
					this._IsDel = value;
					this.SendPropertyChanged("IsDel");
					this.OnIsDelChanged();
				}
			}
		}
		
		[Column(Storage="_Type", DbType="TinyInt NOT NULL")]
		public byte Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		[Column(Storage="_IsTellMe", DbType="TinyInt NOT NULL")]
		public byte IsTellMe
		{
			get
			{
				return this._IsTellMe;
			}
			set
			{
				if ((this._IsTellMe != value))
				{
					this.OnIsTellMeChanging(value);
					this.SendPropertyChanging();
					this._IsTellMe = value;
					this.SendPropertyChanged("IsTellMe");
					this.OnIsTellMeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.ContactInformation")]
    internal partial class ContactInformation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _UserID;
		
		private string _Address;
		
		private string _QQ;
		
		private string _Msn;
		
		private string _WangWang;
		
		private string _NeteasePop;
		
		private string _UC;
		
		private string _Telphone;
		
		private string _Mobiephone;
		
		private string _WebSite;
		
		private byte _TellMethod;
		
		private byte _ShowLevel;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnQQChanging(string value);
    partial void OnQQChanged();
    partial void OnMsnChanging(string value);
    partial void OnMsnChanged();
    partial void OnWangWangChanging(string value);
    partial void OnWangWangChanged();
    partial void OnNeteasePopChanging(string value);
    partial void OnNeteasePopChanged();
    partial void OnUCChanging(string value);
    partial void OnUCChanged();
    partial void OnTelphoneChanging(string value);
    partial void OnTelphoneChanged();
    partial void OnMobiephoneChanging(string value);
    partial void OnMobiephoneChanged();
    partial void OnWebSiteChanging(string value);
    partial void OnWebSiteChanged();
    partial void OnTellMethodChanging(byte value);
    partial void OnTellMethodChanged();
    partial void OnShowLevelChanging(byte value);
    partial void OnShowLevelChanged();
    #endregion
		
		public ContactInformation()
		{
			OnCreated();
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_Address", DbType="NVarChar(100)")]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[Column(Storage="_QQ", DbType="NVarChar(50)")]
		public string QQ
		{
			get
			{
				return this._QQ;
			}
			set
			{
				if ((this._QQ != value))
				{
					this.OnQQChanging(value);
					this.SendPropertyChanging();
					this._QQ = value;
					this.SendPropertyChanged("QQ");
					this.OnQQChanged();
				}
			}
		}
		
		[Column(Storage="_Msn", DbType="NVarChar(50)")]
		public string Msn
		{
			get
			{
				return this._Msn;
			}
			set
			{
				if ((this._Msn != value))
				{
					this.OnMsnChanging(value);
					this.SendPropertyChanging();
					this._Msn = value;
					this.SendPropertyChanged("Msn");
					this.OnMsnChanged();
				}
			}
		}
		
		[Column(Storage="_WangWang", DbType="NVarChar(50)")]
		public string WangWang
		{
			get
			{
				return this._WangWang;
			}
			set
			{
				if ((this._WangWang != value))
				{
					this.OnWangWangChanging(value);
					this.SendPropertyChanging();
					this._WangWang = value;
					this.SendPropertyChanged("WangWang");
					this.OnWangWangChanged();
				}
			}
		}
		
		[Column(Storage="_NeteasePop", DbType="NVarChar(50)")]
		public string NeteasePop
		{
			get
			{
				return this._NeteasePop;
			}
			set
			{
				if ((this._NeteasePop != value))
				{
					this.OnNeteasePopChanging(value);
					this.SendPropertyChanging();
					this._NeteasePop = value;
					this.SendPropertyChanged("NeteasePop");
					this.OnNeteasePopChanged();
				}
			}
		}
		
		[Column(Storage="_UC", DbType="NVarChar(50)")]
		public string UC
		{
			get
			{
				return this._UC;
			}
			set
			{
				if ((this._UC != value))
				{
					this.OnUCChanging(value);
					this.SendPropertyChanging();
					this._UC = value;
					this.SendPropertyChanged("UC");
					this.OnUCChanged();
				}
			}
		}
		
		[Column(Storage="_Telphone", DbType="NVarChar(50)")]
		public string Telphone
		{
			get
			{
				return this._Telphone;
			}
			set
			{
				if ((this._Telphone != value))
				{
					this.OnTelphoneChanging(value);
					this.SendPropertyChanging();
					this._Telphone = value;
					this.SendPropertyChanged("Telphone");
					this.OnTelphoneChanged();
				}
			}
		}
		
		[Column(Storage="_Mobiephone", DbType="NVarChar(50)")]
		public string Mobiephone
		{
			get
			{
				return this._Mobiephone;
			}
			set
			{
				if ((this._Mobiephone != value))
				{
					this.OnMobiephoneChanging(value);
					this.SendPropertyChanging();
					this._Mobiephone = value;
					this.SendPropertyChanged("Mobiephone");
					this.OnMobiephoneChanged();
				}
			}
		}
		
		[Column(Storage="_WebSite", DbType="NVarChar(100)")]
		public string WebSite
		{
			get
			{
				return this._WebSite;
			}
			set
			{
				if ((this._WebSite != value))
				{
					this.OnWebSiteChanging(value);
					this.SendPropertyChanging();
					this._WebSite = value;
					this.SendPropertyChanged("WebSite");
					this.OnWebSiteChanged();
				}
			}
		}
		
		[Column(Storage="_TellMethod", DbType="TinyInt NOT NULL")]
		public byte TellMethod
		{
			get
			{
				return this._TellMethod;
			}
			set
			{
				if ((this._TellMethod != value))
				{
					this.OnTellMethodChanging(value);
					this.SendPropertyChanging();
					this._TellMethod = value;
					this.SendPropertyChanged("TellMethod");
					this.OnTellMethodChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="TinyInt NOT NULL")]
		public byte ShowLevel
		{
			get
			{
				return this._ShowLevel;
			}
			set
			{
				if ((this._ShowLevel != value))
				{
					this.OnShowLevelChanging(value);
					this.SendPropertyChanging();
					this._ShowLevel = value;
					this.SendPropertyChanged("ShowLevel");
					this.OnShowLevelChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Entry")]
    internal partial class Entry : INotifyPropertyChanging, INotifyPropertyChanged, IEntry
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Title;
		
		private long _CreaterID;
		
		private System.DateTime _UpdateTime;
		
		private System.Nullable<long> _CurrentID;
		
		private int _EditCount;
		
		private long _ViewCount;
		
		private int _Status;
		
		private string _Ext;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnCreaterIDChanging(long value);
    partial void OnCreaterIDChanged();
    partial void OnUpdateTimeChanging(System.DateTime value);
    partial void OnUpdateTimeChanged();
    partial void OnCurrentIDChanging(System.Nullable<long> value);
    partial void OnCurrentIDChanged();
    partial void OnEditCountChanging(int value);
    partial void OnEditCountChanged();
    partial void OnViewCountChanging(long value);
    partial void OnViewCountChanged();
    partial void OnStatusChanging(int value);
    partial void OnStatusChanged();
    partial void OnExtChanging(string value);
    partial void OnExtChanged();
    #endregion
		
		public Entry()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_CreaterID", DbType="BigInt NOT NULL")]
		public long CreaterID
		{
			get
			{
				return this._CreaterID;
			}
			set
			{
				if ((this._CreaterID != value))
				{
					this.OnCreaterIDChanging(value);
					this.SendPropertyChanging();
					this._CreaterID = value;
					this.SendPropertyChanged("CreaterID");
					this.OnCreaterIDChanged();
				}
			}
		}
		
		[Column(Storage="_UpdateTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime UpdateTime
		{
			get
			{
				return this._UpdateTime;
			}
			set
			{
				if ((this._UpdateTime != value))
				{
					this.OnUpdateTimeChanging(value);
					this.SendPropertyChanging();
					this._UpdateTime = value;
					this.SendPropertyChanged("UpdateTime");
					this.OnUpdateTimeChanged();
				}
			}
		}
		
		[Column(Storage="_CurrentID", DbType="BigInt")]
		public System.Nullable<long> CurrentID
		{
			get
			{
				return this._CurrentID;
			}
			set
			{
				if ((this._CurrentID != value))
				{
					this.OnCurrentIDChanging(value);
					this.SendPropertyChanging();
					this._CurrentID = value;
					this.SendPropertyChanged("CurrentID");
					this.OnCurrentIDChanged();
				}
			}
		}
		
		[Column(Storage="_EditCount", DbType="Int NOT NULL")]
		public int EditCount
		{
			get
			{
				return this._EditCount;
			}
			set
			{
				if ((this._EditCount != value))
				{
					this.OnEditCountChanging(value);
					this.SendPropertyChanging();
					this._EditCount = value;
					this.SendPropertyChanged("EditCount");
					this.OnEditCountChanged();
				}
			}
		}
		
		[Column(Storage="_ViewCount", DbType="BigInt NOT NULL")]
		public long ViewCount
		{
			get
			{
				return this._ViewCount;
			}
			set
			{
				if ((this._ViewCount != value))
				{
					this.OnViewCountChanging(value);
					this.SendPropertyChanging();
					this._ViewCount = value;
					this.SendPropertyChanged("ViewCount");
					this.OnViewCountChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[Column(Storage="_Ext", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Ext
		{
			get
			{
				return this._Ext;
			}
			set
			{
				if ((this._Ext != value))
				{
					this.OnExtChanging(value);
					this.SendPropertyChanging();
					this._Ext = value;
					this.SendPropertyChanged("Ext");
					this.OnExtChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.EntryVersion")]
    internal partial class EntryVersion : INotifyPropertyChanging, INotifyPropertyChanged, IEntryVersion
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Reason;
		
		private System.DateTime _AddTime;
		
		private string _Description;
		
		private string _Reference;
		
		private long _UserID;
		
		private int _Status;
		
		private System.Nullable<long> _EntryID;
		
		private string _ParentText;
		
		private string _Ext;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnReasonChanging(string value);
    partial void OnReasonChanged();
    partial void OnAddTimeChanging(System.DateTime value);
    partial void OnAddTimeChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnReferenceChanging(string value);
    partial void OnReferenceChanged();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnStatusChanging(int value);
    partial void OnStatusChanged();
    partial void OnEntryIDChanging(System.Nullable<long> value);
    partial void OnEntryIDChanged();
    partial void OnParentTextChanging(string value);
    partial void OnParentTextChanged();
    partial void OnExtChanging(string value);
    partial void OnExtChanged();
    #endregion
		
		public EntryVersion()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Reason", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Reason
		{
			get
			{
				return this._Reason;
			}
			set
			{
				if ((this._Reason != value))
				{
					this.OnReasonChanging(value);
					this.SendPropertyChanging();
					this._Reason = value;
					this.SendPropertyChanged("Reason");
					this.OnReasonChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime AddTime
		{
			get
			{
				return this._AddTime;
			}
			set
			{
				if ((this._AddTime != value))
				{
					this.OnAddTimeChanging(value);
					this.SendPropertyChanging();
					this._AddTime = value;
					this.SendPropertyChanged("AddTime");
					this.OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_Description", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_Reference", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Reference
		{
			get
			{
				return this._Reference;
			}
			set
			{
				if ((this._Reference != value))
				{
					this.OnReferenceChanging(value);
					this.SendPropertyChanging();
					this._Reference = value;
					this.SendPropertyChanged("Reference");
					this.OnReferenceChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[Column(Storage="_EntryID", DbType="BigInt")]
		public System.Nullable<long> EntryID
		{
			get
			{
				return this._EntryID;
			}
			set
			{
				if ((this._EntryID != value))
				{
					this.OnEntryIDChanging(value);
					this.SendPropertyChanging();
					this._EntryID = value;
					this.SendPropertyChanged("EntryID");
					this.OnEntryIDChanged();
				}
			}
		}
		
		[Column(Storage="_ParentText", DbType="NVarChar(50)")]
		public string ParentText
		{
			get
			{
				return this._ParentText;
			}
			set
			{
				if ((this._ParentText != value))
				{
					this.OnParentTextChanging(value);
					this.SendPropertyChanging();
					this._ParentText = value;
					this.SendPropertyChanged("ParentText");
					this.OnParentTextChanged();
				}
			}
		}
		
		[Column(Storage="_Ext", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Ext
		{
			get
			{
				return this._Ext;
			}
			set
			{
				if ((this._Ext != value))
				{
					this.OnExtChanging(value);
					this.SendPropertyChanging();
					this._Ext = value;
					this.SendPropertyChanged("Ext");
					this.OnExtChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Event")]
    internal partial class Event : INotifyPropertyChanging, INotifyPropertyChanged, IEvent
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _TemplateName;
		
		private long _OwnerID;
		
		private System.Nullable<long> _ViewerID;
		
		private System.DateTime _AddTime;
		
		private int _ShowLevel;
		
		private string _Json;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnTemplateNameChanging(string value);
    partial void OnTemplateNameChanged();
    partial void OnOwnerIDChanging(long value);
    partial void OnOwnerIDChanged();
    partial void OnViewerIDChanging(System.Nullable<long> value);
    partial void OnViewerIDChanged();
    partial void OnAddTimeChanging(System.DateTime value);
    partial void OnAddTimeChanged();
    partial void OnShowLevelChanging(int value);
    partial void OnShowLevelChanged();
    partial void OnJsonChanging(string value);
    partial void OnJsonChanged();
    #endregion
		
		public Event()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_TemplateName", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string TemplateName
		{
			get
			{
				return this._TemplateName;
			}
			set
			{
				if ((this._TemplateName != value))
				{
					this.OnTemplateNameChanging(value);
					this.SendPropertyChanging();
					this._TemplateName = value;
					this.SendPropertyChanged("TemplateName");
					this.OnTemplateNameChanged();
				}
			}
		}
		
		[Column(Storage="_OwnerID", DbType="BigInt NOT NULL")]
		public long OwnerID
		{
			get
			{
				return this._OwnerID;
			}
			set
			{
				if ((this._OwnerID != value))
				{
					this.OnOwnerIDChanging(value);
					this.SendPropertyChanging();
					this._OwnerID = value;
					this.SendPropertyChanged("OwnerID");
					this.OnOwnerIDChanged();
				}
			}
		}
		
		[Column(Storage="_ViewerID", DbType="BigInt")]
		public System.Nullable<long> ViewerID
		{
			get
			{
				return this._ViewerID;
			}
			set
			{
				if ((this._ViewerID != value))
				{
					this.OnViewerIDChanging(value);
					this.SendPropertyChanging();
					this._ViewerID = value;
					this.SendPropertyChanged("ViewerID");
					this.OnViewerIDChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime AddTime
		{
			get
			{
				return this._AddTime;
			}
			set
			{
				if ((this._AddTime != value))
				{
					this.OnAddTimeChanging(value);
					this.SendPropertyChanging();
					this._AddTime = value;
					this.SendPropertyChanged("AddTime");
					this.OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="Int NOT NULL")]
		public int ShowLevel
		{
			get
			{
				return this._ShowLevel;
			}
			set
			{
				if ((this._ShowLevel != value))
				{
					this.OnShowLevelChanging(value);
					this.SendPropertyChanging();
					this._ShowLevel = value;
					this.SendPropertyChanged("ShowLevel");
					this.OnShowLevelChanged();
				}
			}
		}
		
		[Column(Storage="_Json", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Json
		{
			get
			{
				return this._Json;
			}
			set
			{
				if ((this._Json != value))
				{
					this.OnJsonChanging(value);
					this.SendPropertyChanging();
					this._Json = value;
					this.SendPropertyChanged("Json");
					this.OnJsonChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.FieldInformation")]
    internal partial class FieldInformation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _UserID;
		
		private long _Field;
		
		private System.Nullable<short> _Year;
		
		private System.Nullable<long> _MiniField;
		
		private System.Nullable<long> _QinShi;
		
		private System.Nullable<long> _Field1;
		
		private System.Nullable<long> _Field2;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnFieldChanging(long value);
    partial void OnFieldChanged();
    partial void OnYearChanging(System.Nullable<short> value);
    partial void OnYearChanged();
    partial void OnMiniFieldChanging(System.Nullable<long> value);
    partial void OnMiniFieldChanged();
    partial void OnQinShiChanging(System.Nullable<long> value);
    partial void OnQinShiChanged();
    partial void OnField1Changing(System.Nullable<long> value);
    partial void OnField1Changed();
    partial void OnField2Changing(System.Nullable<long> value);
    partial void OnField2Changed();
    #endregion
		
		public FieldInformation()
		{
			OnCreated();
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_Field", DbType="BigInt NOT NULL")]
		public long Field
		{
			get
			{
				return this._Field;
			}
			set
			{
				if ((this._Field != value))
				{
					this.OnFieldChanging(value);
					this.SendPropertyChanging();
					this._Field = value;
					this.SendPropertyChanged("Field");
					this.OnFieldChanged();
				}
			}
		}
		
		[Column(Storage="_Year", DbType="SmallInt")]
		public System.Nullable<short> Year
		{
			get
			{
				return this._Year;
			}
			set
			{
				if ((this._Year != value))
				{
					this.OnYearChanging(value);
					this.SendPropertyChanging();
					this._Year = value;
					this.SendPropertyChanged("Year");
					this.OnYearChanged();
				}
			}
		}
		
		[Column(Storage="_MiniField", DbType="BigInt")]
		public System.Nullable<long> MiniField
		{
			get
			{
				return this._MiniField;
			}
			set
			{
				if ((this._MiniField != value))
				{
					this.OnMiniFieldChanging(value);
					this.SendPropertyChanging();
					this._MiniField = value;
					this.SendPropertyChanged("MiniField");
					this.OnMiniFieldChanged();
				}
			}
		}
		
		[Column(Storage="_QinShi", DbType="BigInt")]
		public System.Nullable<long> QinShi
		{
			get
			{
				return this._QinShi;
			}
			set
			{
				if ((this._QinShi != value))
				{
					this.OnQinShiChanging(value);
					this.SendPropertyChanging();
					this._QinShi = value;
					this.SendPropertyChanged("QinShi");
					this.OnQinShiChanged();
				}
			}
		}
		
		[Column(Storage="_Field1", DbType="BigInt")]
		public System.Nullable<long> Field1
		{
			get
			{
				return this._Field1;
			}
			set
			{
				if ((this._Field1 != value))
				{
					this.OnField1Changing(value);
					this.SendPropertyChanging();
					this._Field1 = value;
					this.SendPropertyChanged("Field1");
					this.OnField1Changed();
				}
			}
		}
		
		[Column(Storage="_Field2", DbType="BigInt")]
		public System.Nullable<long> Field2
		{
			get
			{
				return this._Field2;
			}
			set
			{
				if ((this._Field2 != value))
				{
					this.OnField2Changing(value);
					this.SendPropertyChanging();
					this._Field2 = value;
					this.SendPropertyChanged("Field2");
					this.OnField2Changed();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Friend")]
    internal partial class Friend : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private long _FromID;
		
		private long _ToID;
		
		private bool _IsTrue;
		
		private bool _IsCommon;
		
		private System.Nullable<int> _FriendType;
		
		private System.Nullable<int> _FriendSummary;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnFromIDChanging(long value);
    partial void OnFromIDChanged();
    partial void OnToIDChanging(long value);
    partial void OnToIDChanged();
    partial void OnIsTrueChanging(bool value);
    partial void OnIsTrueChanged();
    partial void OnIsCommonChanging(bool value);
    partial void OnIsCommonChanged();
    partial void OnFriendTypeChanging(System.Nullable<int> value);
    partial void OnFriendTypeChanged();
    partial void OnFriendSummaryChanging(System.Nullable<int> value);
    partial void OnFriendSummaryChanged();
    #endregion
		
		public Friend()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_FromID", DbType="BigInt NOT NULL")]
		public long FromID
		{
			get
			{
				return this._FromID;
			}
			set
			{
				if ((this._FromID != value))
				{
					this.OnFromIDChanging(value);
					this.SendPropertyChanging();
					this._FromID = value;
					this.SendPropertyChanged("FromID");
					this.OnFromIDChanged();
				}
			}
		}
		
		[Column(Storage="_ToID", DbType="BigInt NOT NULL")]
		public long ToID
		{
			get
			{
				return this._ToID;
			}
			set
			{
				if ((this._ToID != value))
				{
					this.OnToIDChanging(value);
					this.SendPropertyChanging();
					this._ToID = value;
					this.SendPropertyChanged("ToID");
					this.OnToIDChanged();
				}
			}
		}
		
		[Column(Storage="_IsTrue", DbType="Bit NOT NULL")]
		public bool IsTrue
		{
			get
			{
				return this._IsTrue;
			}
			set
			{
				if ((this._IsTrue != value))
				{
					this.OnIsTrueChanging(value);
					this.SendPropertyChanging();
					this._IsTrue = value;
					this.SendPropertyChanged("IsTrue");
					this.OnIsTrueChanged();
				}
			}
		}
		
		[Column(Storage="_IsCommon", DbType="Bit NOT NULL")]
		public bool IsCommon
		{
			get
			{
				return this._IsCommon;
			}
			set
			{
				if ((this._IsCommon != value))
				{
					this.OnIsCommonChanging(value);
					this.SendPropertyChanging();
					this._IsCommon = value;
					this.SendPropertyChanged("IsCommon");
					this.OnIsCommonChanged();
				}
			}
		}
		
		[Column(Storage="_FriendType", DbType="Int")]
		public System.Nullable<int> FriendType
		{
			get
			{
				return this._FriendType;
			}
			set
			{
				if ((this._FriendType != value))
				{
					this.OnFriendTypeChanging(value);
					this.SendPropertyChanging();
					this._FriendType = value;
					this.SendPropertyChanged("FriendType");
					this.OnFriendTypeChanged();
				}
			}
		}
		
		[Column(Storage="_FriendSummary", DbType="Int")]
		public System.Nullable<int> FriendSummary
		{
			get
			{
				return this._FriendSummary;
			}
			set
			{
				if ((this._FriendSummary != value))
				{
					this.OnFriendSummaryChanging(value);
					this.SendPropertyChanging();
					this._FriendSummary = value;
					this.SendPropertyChanged("FriendSummary");
					this.OnFriendSummaryChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.[Group]")]
    internal partial class Group : INotifyPropertyChanging, INotifyPropertyChanged, IGroup
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Name;
		
		private string _LogoUrl;
		
		private System.DateTime _AddTime;
		
		private string _Summary;
		
		private long _CreaterID;
		
		private long _UserCount;
		
		private byte _AdminCount;
		
		private long _PostCount;
		
		private long _ViewCount;
		
		private byte _JoinLevel;
		
		private byte _ShowLevel;
		
		private byte _Status;
		
		private byte _Type;
		
		private string _Ext;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnLogoUrlChanging(string value);
    partial void OnLogoUrlChanged();
    partial void OnAddTimeChanging(System.DateTime value);
    partial void OnAddTimeChanged();
    partial void OnSummaryChanging(string value);
    partial void OnSummaryChanged();
    partial void OnCreaterIDChanging(long value);
    partial void OnCreaterIDChanged();
    partial void OnUserCountChanging(long value);
    partial void OnUserCountChanged();
    partial void OnAdminCountChanging(byte value);
    partial void OnAdminCountChanged();
    partial void OnPostCountChanging(long value);
    partial void OnPostCountChanged();
    partial void OnViewCountChanging(long value);
    partial void OnViewCountChanged();
    partial void OnJoinLevelChanging(byte value);
    partial void OnJoinLevelChanged();
    partial void OnShowLevelChanging(byte value);
    partial void OnShowLevelChanged();
    partial void OnStatusChanging(byte value);
    partial void OnStatusChanged();
    partial void OnTypeChanging(byte value);
    partial void OnTypeChanged();
    partial void OnExtChanging(string value);
    partial void OnExtChanged();
    #endregion
		
		public Group()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_LogoUrl", DbType="NVarChar(250)")]
		public string LogoUrl
		{
			get
			{
				return this._LogoUrl;
			}
			set
			{
				if ((this._LogoUrl != value))
				{
					this.OnLogoUrlChanging(value);
					this.SendPropertyChanging();
					this._LogoUrl = value;
					this.SendPropertyChanged("LogoUrl");
					this.OnLogoUrlChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime AddTime
		{
			get
			{
				return this._AddTime;
			}
			set
			{
				if ((this._AddTime != value))
				{
					this.OnAddTimeChanging(value);
					this.SendPropertyChanging();
					this._AddTime = value;
					this.SendPropertyChanged("AddTime");
					this.OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_Summary", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Summary
		{
			get
			{
				return this._Summary;
			}
			set
			{
				if ((this._Summary != value))
				{
					this.OnSummaryChanging(value);
					this.SendPropertyChanging();
					this._Summary = value;
					this.SendPropertyChanged("Summary");
					this.OnSummaryChanged();
				}
			}
		}
		
		[Column(Storage="_CreaterID", DbType="BigInt NOT NULL")]
		public long CreaterID
		{
			get
			{
				return this._CreaterID;
			}
			set
			{
				if ((this._CreaterID != value))
				{
					this.OnCreaterIDChanging(value);
					this.SendPropertyChanging();
					this._CreaterID = value;
					this.SendPropertyChanged("CreaterID");
					this.OnCreaterIDChanged();
				}
			}
		}
		
		[Column(Storage="_UserCount", DbType="BigInt NOT NULL")]
		public long UserCount
		{
			get
			{
				return this._UserCount;
			}
			set
			{
				if ((this._UserCount != value))
				{
					this.OnUserCountChanging(value);
					this.SendPropertyChanging();
					this._UserCount = value;
					this.SendPropertyChanged("UserCount");
					this.OnUserCountChanged();
				}
			}
		}
		
		[Column(Storage="_AdminCount", DbType="TinyInt NOT NULL")]
		public byte AdminCount
		{
			get
			{
				return this._AdminCount;
			}
			set
			{
				if ((this._AdminCount != value))
				{
					this.OnAdminCountChanging(value);
					this.SendPropertyChanging();
					this._AdminCount = value;
					this.SendPropertyChanged("AdminCount");
					this.OnAdminCountChanged();
				}
			}
		}
		
		[Column(Storage="_PostCount", DbType="BigInt NOT NULL")]
		public long PostCount
		{
			get
			{
				return this._PostCount;
			}
			set
			{
				if ((this._PostCount != value))
				{
					this.OnPostCountChanging(value);
					this.SendPropertyChanging();
					this._PostCount = value;
					this.SendPropertyChanged("PostCount");
					this.OnPostCountChanged();
				}
			}
		}
		
		[Column(Storage="_ViewCount", DbType="BigInt NOT NULL")]
		public long ViewCount
		{
			get
			{
				return this._ViewCount;
			}
			set
			{
				if ((this._ViewCount != value))
				{
					this.OnViewCountChanging(value);
					this.SendPropertyChanging();
					this._ViewCount = value;
					this.SendPropertyChanged("ViewCount");
					this.OnViewCountChanged();
				}
			}
		}
		
		[Column(Storage="_JoinLevel", DbType="TinyInt NOT NULL")]
		public byte JoinLevel
		{
			get
			{
				return this._JoinLevel;
			}
			set
			{
				if ((this._JoinLevel != value))
				{
					this.OnJoinLevelChanging(value);
					this.SendPropertyChanging();
					this._JoinLevel = value;
					this.SendPropertyChanged("JoinLevel");
					this.OnJoinLevelChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="TinyInt NOT NULL")]
		public byte ShowLevel
		{
			get
			{
				return this._ShowLevel;
			}
			set
			{
				if ((this._ShowLevel != value))
				{
					this.OnShowLevelChanging(value);
					this.SendPropertyChanging();
					this._ShowLevel = value;
					this.SendPropertyChanged("ShowLevel");
					this.OnShowLevelChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="TinyInt NOT NULL")]
		public byte Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[Column(Storage="_Type", DbType="TinyInt NOT NULL")]
		public byte Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		[Column(Storage="_Ext", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Ext
		{
			get
			{
				return this._Ext;
			}
			set
			{
				if ((this._Ext != value))
				{
					this.OnExtChanging(value);
					this.SendPropertyChanging();
					this._Ext = value;
					this.SendPropertyChanged("Ext");
					this.OnExtChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.GroupUser")]
    internal partial class GroupUser : INotifyPropertyChanging, INotifyPropertyChanged, IGroupUser
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _UserID;
		
		private long _GroupID;
		
		private System.DateTime _AddTime;
		
		private long _PostCount;
		
		private byte _Status;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnGroupIDChanging(long value);
    partial void OnGroupIDChanged();
    partial void OnAddTimeChanging(System.DateTime value);
    partial void OnAddTimeChanged();
    partial void OnPostCountChanging(long value);
    partial void OnPostCountChanged();
    partial void OnStatusChanging(byte value);
    partial void OnStatusChanged();
    #endregion
		
		public GroupUser()
		{
			OnCreated();
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_GroupID", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long GroupID
		{
			get
			{
				return this._GroupID;
			}
			set
			{
				if ((this._GroupID != value))
				{
					this.OnGroupIDChanging(value);
					this.SendPropertyChanging();
					this._GroupID = value;
					this.SendPropertyChanged("GroupID");
					this.OnGroupIDChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime AddTime
		{
			get
			{
				return this._AddTime;
			}
			set
			{
				if ((this._AddTime != value))
				{
					this.OnAddTimeChanging(value);
					this.SendPropertyChanging();
					this._AddTime = value;
					this.SendPropertyChanged("AddTime");
					this.OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_PostCount", DbType="BigInt NOT NULL")]
		public long PostCount
		{
			get
			{
				return this._PostCount;
			}
			set
			{
				if ((this._PostCount != value))
				{
					this.OnPostCountChanging(value);
					this.SendPropertyChanging();
					this._PostCount = value;
					this.SendPropertyChanged("PostCount");
					this.OnPostCountChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="TinyInt NOT NULL")]
		public byte Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.LogTag")]
    internal partial class LogTag : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private long _TagID;
		
		private long _LogID;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnTagIDChanging(long value);
    partial void OnTagIDChanged();
    partial void OnLogIDChanging(long value);
    partial void OnLogIDChanged();
    #endregion
		
		public LogTag()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_TagID", DbType="BigInt NOT NULL")]
		public long TagID
		{
			get
			{
				return this._TagID;
			}
			set
			{
				if ((this._TagID != value))
				{
					this.OnTagIDChanging(value);
					this.SendPropertyChanging();
					this._TagID = value;
					this.SendPropertyChanged("TagID");
					this.OnTagIDChanged();
				}
			}
		}
		
		[Column(Storage="_LogID", DbType="BigInt NOT NULL")]
		public long LogID
		{
			get
			{
				return this._LogID;
			}
			set
			{
				if ((this._LogID != value))
				{
					this.OnLogIDChanging(value);
					this.SendPropertyChanging();
					this._LogID = value;
					this.SendPropertyChanged("LogID");
					this.OnLogIDChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Message")]
    internal partial class Message : INotifyPropertyChanging, INotifyPropertyChanged, IMessage
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private long _FromID;
		
		private long _ToID;
		
		private string _Title;
		
		private string _Body;
		
		private System.DateTime _SendTime;
		
		private bool _IsSee;
		
		private bool _IsFromDel;
		
		private bool _IsToDel;
		
		private bool _IsHtml;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnFromIDChanging(long value);
    partial void OnFromIDChanged();
    partial void OnToIDChanging(long value);
    partial void OnToIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnBodyChanging(string value);
    partial void OnBodyChanged();
    partial void OnSendTimeChanging(System.DateTime value);
    partial void OnSendTimeChanged();
    partial void OnIsSeeChanging(bool value);
    partial void OnIsSeeChanged();
    partial void OnIsFromDelChanging(bool value);
    partial void OnIsFromDelChanged();
    partial void OnIsToDelChanging(bool value);
    partial void OnIsToDelChanged();
    partial void OnIsHtmlChanging(bool value);
    partial void OnIsHtmlChanged();
    #endregion
		
		public Message()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_FromID", DbType="BigInt NOT NULL")]
		public long FromID
		{
			get
			{
				return this._FromID;
			}
			set
			{
				if ((this._FromID != value))
				{
					this.OnFromIDChanging(value);
					this.SendPropertyChanging();
					this._FromID = value;
					this.SendPropertyChanged("FromID");
					this.OnFromIDChanged();
				}
			}
		}
		
		[Column(Storage="_ToID", DbType="BigInt NOT NULL")]
		public long ToID
		{
			get
			{
				return this._ToID;
			}
			set
			{
				if ((this._ToID != value))
				{
					this.OnToIDChanging(value);
					this.SendPropertyChanging();
					this._ToID = value;
					this.SendPropertyChanged("ToID");
					this.OnToIDChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_Body", DbType="NVarChar(4000) NOT NULL", CanBeNull=false)]
		public string Body
		{
			get
			{
				return this._Body;
			}
			set
			{
				if ((this._Body != value))
				{
					this.OnBodyChanging(value);
					this.SendPropertyChanging();
					this._Body = value;
					this.SendPropertyChanged("Body");
					this.OnBodyChanged();
				}
			}
		}
		
		[Column(Storage="_SendTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime SendTime
		{
			get
			{
				return this._SendTime;
			}
			set
			{
				if ((this._SendTime != value))
				{
					this.OnSendTimeChanging(value);
					this.SendPropertyChanging();
					this._SendTime = value;
					this.SendPropertyChanged("SendTime");
					this.OnSendTimeChanged();
				}
			}
		}
		
		[Column(Storage="_IsSee", DbType="Bit NOT NULL")]
		public bool IsSee
		{
			get
			{
				return this._IsSee;
			}
			set
			{
				if ((this._IsSee != value))
				{
					this.OnIsSeeChanging(value);
					this.SendPropertyChanging();
					this._IsSee = value;
					this.SendPropertyChanged("IsSee");
					this.OnIsSeeChanged();
				}
			}
		}
		
		[Column(Storage="_IsFromDel", DbType="Bit NOT NULL")]
		public bool IsFromDel
		{
			get
			{
				return this._IsFromDel;
			}
			set
			{
				if ((this._IsFromDel != value))
				{
					this.OnIsFromDelChanging(value);
					this.SendPropertyChanging();
					this._IsFromDel = value;
					this.SendPropertyChanged("IsFromDel");
					this.OnIsFromDelChanged();
				}
			}
		}
		
		[Column(Storage="_IsToDel", DbType="Bit NOT NULL")]
		public bool IsToDel
		{
			get
			{
				return this._IsToDel;
			}
			set
			{
				if ((this._IsToDel != value))
				{
					this.OnIsToDelChanging(value);
					this.SendPropertyChanging();
					this._IsToDel = value;
					this.SendPropertyChanged("IsToDel");
					this.OnIsToDelChanged();
				}
			}
		}
		
		[Column(Storage="_IsHtml", DbType="Bit NOT NULL")]
		public bool IsHtml
		{
			get
			{
				return this._IsHtml;
			}
			set
			{
				if ((this._IsHtml != value))
				{
					this.OnIsHtmlChanging(value);
					this.SendPropertyChanging();
					this._IsHtml = value;
					this.SendPropertyChanged("IsHtml");
					this.OnIsHtmlChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Note")]
    internal partial class Note : INotifyPropertyChanging, INotifyPropertyChanged, INote
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Title;
		
		private string _Summary;
		
		private string _Body;
		
		private System.DateTime _AddTime;
		
		private System.DateTime _EditTime;
		
		private byte _Type;
		
		private long _PID;
		
		private long _UserID;
		
		private byte _IsTellMe;
		
		private System.Nullable<bool> _IsAnonymous;
		
		private byte _ShowLevel;
		
		private long _ViewCount;
		
		private long _PushCount;
		
		private long _TrackBackCount;
		
		private long _CommentCount;
		
		private long _LastCommentUserID;
		
		private System.DateTime _LastCommentTime;
		
		private string _Ext;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnSummaryChanging(string value);
    partial void OnSummaryChanged();
    partial void OnBodyChanging(string value);
    partial void OnBodyChanged();
    partial void OnAddTimeChanging(System.DateTime value);
    partial void OnAddTimeChanged();
    partial void OnEditTimeChanging(System.DateTime value);
    partial void OnEditTimeChanged();
    partial void OnTypeChanging(byte value);
    partial void OnTypeChanged();
    partial void OnPIDChanging(long value);
    partial void OnPIDChanged();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnIsTellMeChanging(byte value);
    partial void OnIsTellMeChanged();
    partial void OnIsAnonymousChanging(System.Nullable<bool> value);
    partial void OnIsAnonymousChanged();
    partial void OnShowLevelChanging(byte value);
    partial void OnShowLevelChanged();
    partial void OnViewCountChanging(long value);
    partial void OnViewCountChanged();
    partial void OnPushCountChanging(long value);
    partial void OnPushCountChanged();
    partial void OnTrackBackCountChanging(long value);
    partial void OnTrackBackCountChanged();
    partial void OnCommentCountChanging(long value);
    partial void OnCommentCountChanged();
    partial void OnLastCommentUserIDChanging(long value);
    partial void OnLastCommentUserIDChanged();
    partial void OnLastCommentTimeChanging(System.DateTime value);
    partial void OnLastCommentTimeChanged();
    partial void OnExtChanging(string value);
    partial void OnExtChanged();
    #endregion
		
		public Note()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_Summary", DbType="NVarChar(4000)")]
		public string Summary
		{
			get
			{
				return this._Summary;
			}
			set
			{
				if ((this._Summary != value))
				{
					this.OnSummaryChanging(value);
					this.SendPropertyChanging();
					this._Summary = value;
					this.SendPropertyChanged("Summary");
					this.OnSummaryChanged();
				}
			}
		}
		
		[Column(Storage="_Body", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Body
		{
			get
			{
				return this._Body;
			}
			set
			{
				if ((this._Body != value))
				{
					this.OnBodyChanging(value);
					this.SendPropertyChanging();
					this._Body = value;
					this.SendPropertyChanged("Body");
					this.OnBodyChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime AddTime
		{
			get
			{
				return this._AddTime;
			}
			set
			{
				if ((this._AddTime != value))
				{
					this.OnAddTimeChanging(value);
					this.SendPropertyChanging();
					this._AddTime = value;
					this.SendPropertyChanged("AddTime");
					this.OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_EditTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime EditTime
		{
			get
			{
				return this._EditTime;
			}
			set
			{
				if ((this._EditTime != value))
				{
					this.OnEditTimeChanging(value);
					this.SendPropertyChanging();
					this._EditTime = value;
					this.SendPropertyChanged("EditTime");
					this.OnEditTimeChanged();
				}
			}
		}
		
		[Column(Storage="_Type", DbType="TinyInt NOT NULL")]
		public byte Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		[Column(Storage="_PID", DbType="BigInt NOT NULL")]
		public long PID
		{
			get
			{
				return this._PID;
			}
			set
			{
				if ((this._PID != value))
				{
					this.OnPIDChanging(value);
					this.SendPropertyChanging();
					this._PID = value;
					this.SendPropertyChanged("PID");
					this.OnPIDChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_IsTellMe", DbType="TinyInt NOT NULL")]
		public byte IsTellMe
		{
			get
			{
				return this._IsTellMe;
			}
			set
			{
				if ((this._IsTellMe != value))
				{
					this.OnIsTellMeChanging(value);
					this.SendPropertyChanging();
					this._IsTellMe = value;
					this.SendPropertyChanged("IsTellMe");
					this.OnIsTellMeChanged();
				}
			}
		}
		
		[Column(Storage="_IsAnonymous", DbType="Bit")]
		public System.Nullable<bool> IsAnonymous
		{
			get
			{
				return this._IsAnonymous;
			}
			set
			{
				if ((this._IsAnonymous != value))
				{
					this.OnIsAnonymousChanging(value);
					this.SendPropertyChanging();
					this._IsAnonymous = value;
					this.SendPropertyChanged("IsAnonymous");
					this.OnIsAnonymousChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="TinyInt NOT NULL")]
		public byte ShowLevel
		{
			get
			{
				return this._ShowLevel;
			}
			set
			{
				if ((this._ShowLevel != value))
				{
					this.OnShowLevelChanging(value);
					this.SendPropertyChanging();
					this._ShowLevel = value;
					this.SendPropertyChanged("ShowLevel");
					this.OnShowLevelChanged();
				}
			}
		}
		
		[Column(Storage="_ViewCount", DbType="BigInt NOT NULL")]
		public long ViewCount
		{
			get
			{
				return this._ViewCount;
			}
			set
			{
				if ((this._ViewCount != value))
				{
					this.OnViewCountChanging(value);
					this.SendPropertyChanging();
					this._ViewCount = value;
					this.SendPropertyChanged("ViewCount");
					this.OnViewCountChanged();
				}
			}
		}
		
		[Column(Storage="_PushCount", DbType="BigInt NOT NULL")]
		public long PushCount
		{
			get
			{
				return this._PushCount;
			}
			set
			{
				if ((this._PushCount != value))
				{
					this.OnPushCountChanging(value);
					this.SendPropertyChanging();
					this._PushCount = value;
					this.SendPropertyChanged("PushCount");
					this.OnPushCountChanged();
				}
			}
		}
		
		[Column(Storage="_TrackBackCount", DbType="BigInt NOT NULL")]
		public long TrackBackCount
		{
			get
			{
				return this._TrackBackCount;
			}
			set
			{
				if ((this._TrackBackCount != value))
				{
					this.OnTrackBackCountChanging(value);
					this.SendPropertyChanging();
					this._TrackBackCount = value;
					this.SendPropertyChanged("TrackBackCount");
					this.OnTrackBackCountChanged();
				}
			}
		}
		
		[Column(Storage="_CommentCount", DbType="BigInt NOT NULL")]
		public long CommentCount
		{
			get
			{
				return this._CommentCount;
			}
			set
			{
				if ((this._CommentCount != value))
				{
					this.OnCommentCountChanging(value);
					this.SendPropertyChanging();
					this._CommentCount = value;
					this.SendPropertyChanged("CommentCount");
					this.OnCommentCountChanged();
				}
			}
		}
		
		[Column(Storage="_LastCommentUserID", DbType="BigInt NOT NULL")]
		public long LastCommentUserID
		{
			get
			{
				return this._LastCommentUserID;
			}
			set
			{
				if ((this._LastCommentUserID != value))
				{
					this.OnLastCommentUserIDChanging(value);
					this.SendPropertyChanging();
					this._LastCommentUserID = value;
					this.SendPropertyChanged("LastCommentUserID");
					this.OnLastCommentUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_LastCommentTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime LastCommentTime
		{
			get
			{
				return this._LastCommentTime;
			}
			set
			{
				if ((this._LastCommentTime != value))
				{
					this.OnLastCommentTimeChanging(value);
					this.SendPropertyChanging();
					this._LastCommentTime = value;
					this.SendPropertyChanged("LastCommentTime");
					this.OnLastCommentTimeChanged();
				}
			}
		}
		
		[Column(Storage="_Ext", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Ext
		{
			get
			{
				return this._Ext;
			}
			set
			{
				if ((this._Ext != value))
				{
					this.OnExtChanging(value);
					this.SendPropertyChanging();
					this._Ext = value;
					this.SendPropertyChanged("Ext");
					this.OnExtChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.PersonalInformation")]
    internal partial class PersonalInformation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _UserID;
		
		private string _LoveLike;
		
		private string _LoveBook;
		
		private string _LoveMusic;
		
		private string _LoveMovie;
		
		private string _LoveSports;
		
		private string _LoveGame;
		
		private string _LoveComic;
		
		private string _JoinSociety;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnLoveLikeChanging(string value);
    partial void OnLoveLikeChanged();
    partial void OnLoveBookChanging(string value);
    partial void OnLoveBookChanged();
    partial void OnLoveMusicChanging(string value);
    partial void OnLoveMusicChanged();
    partial void OnLoveMovieChanging(string value);
    partial void OnLoveMovieChanged();
    partial void OnLoveSportsChanging(string value);
    partial void OnLoveSportsChanged();
    partial void OnLoveGameChanging(string value);
    partial void OnLoveGameChanged();
    partial void OnLoveComicChanging(string value);
    partial void OnLoveComicChanged();
    partial void OnJoinSocietyChanging(string value);
    partial void OnJoinSocietyChanged();
    #endregion
		
		public PersonalInformation()
		{
			OnCreated();
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_LoveLike", DbType="NVarChar(255)")]
		public string LoveLike
		{
			get
			{
				return this._LoveLike;
			}
			set
			{
				if ((this._LoveLike != value))
				{
					this.OnLoveLikeChanging(value);
					this.SendPropertyChanging();
					this._LoveLike = value;
					this.SendPropertyChanged("LoveLike");
					this.OnLoveLikeChanged();
				}
			}
		}
		
		[Column(Storage="_LoveBook", DbType="NVarChar(255)")]
		public string LoveBook
		{
			get
			{
				return this._LoveBook;
			}
			set
			{
				if ((this._LoveBook != value))
				{
					this.OnLoveBookChanging(value);
					this.SendPropertyChanging();
					this._LoveBook = value;
					this.SendPropertyChanged("LoveBook");
					this.OnLoveBookChanged();
				}
			}
		}
		
		[Column(Storage="_LoveMusic", DbType="NVarChar(255)")]
		public string LoveMusic
		{
			get
			{
				return this._LoveMusic;
			}
			set
			{
				if ((this._LoveMusic != value))
				{
					this.OnLoveMusicChanging(value);
					this.SendPropertyChanging();
					this._LoveMusic = value;
					this.SendPropertyChanged("LoveMusic");
					this.OnLoveMusicChanged();
				}
			}
		}
		
		[Column(Storage="_LoveMovie", DbType="NVarChar(255)")]
		public string LoveMovie
		{
			get
			{
				return this._LoveMovie;
			}
			set
			{
				if ((this._LoveMovie != value))
				{
					this.OnLoveMovieChanging(value);
					this.SendPropertyChanging();
					this._LoveMovie = value;
					this.SendPropertyChanged("LoveMovie");
					this.OnLoveMovieChanged();
				}
			}
		}
		
		[Column(Storage="_LoveSports", DbType="NVarChar(255)")]
		public string LoveSports
		{
			get
			{
				return this._LoveSports;
			}
			set
			{
				if ((this._LoveSports != value))
				{
					this.OnLoveSportsChanging(value);
					this.SendPropertyChanging();
					this._LoveSports = value;
					this.SendPropertyChanged("LoveSports");
					this.OnLoveSportsChanged();
				}
			}
		}
		
		[Column(Storage="_LoveGame", DbType="NVarChar(255)")]
		public string LoveGame
		{
			get
			{
				return this._LoveGame;
			}
			set
			{
				if ((this._LoveGame != value))
				{
					this.OnLoveGameChanging(value);
					this.SendPropertyChanging();
					this._LoveGame = value;
					this.SendPropertyChanged("LoveGame");
					this.OnLoveGameChanged();
				}
			}
		}
		
		[Column(Storage="_LoveComic", DbType="NVarChar(255)")]
		public string LoveComic
		{
			get
			{
				return this._LoveComic;
			}
			set
			{
				if ((this._LoveComic != value))
				{
					this.OnLoveComicChanging(value);
					this.SendPropertyChanging();
					this._LoveComic = value;
					this.SendPropertyChanged("LoveComic");
					this.OnLoveComicChanged();
				}
			}
		}
		
		[Column(Storage="_JoinSociety", DbType="NVarChar(255)")]
		public string JoinSociety
		{
			get
			{
				return this._JoinSociety;
			}
			set
			{
				if ((this._JoinSociety != value))
				{
					this.OnJoinSocietyChanging(value);
					this.SendPropertyChanging();
					this._JoinSociety = value;
					this.SendPropertyChanged("JoinSociety");
					this.OnJoinSocietyChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Photo")]
    internal partial class Photo : INotifyPropertyChanging, INotifyPropertyChanged, IPhoto
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Name;
		
		private System.Nullable<long> _AlbumID;
		
		private long _UserID;
		
		private System.DateTime _AddTime;
		
		private long _Order;
		
		private string _Ext;
		
		private int _Status;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnAlbumIDChanging(System.Nullable<long> value);
    partial void OnAlbumIDChanged();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnAddTimeChanging(System.DateTime value);
    partial void OnAddTimeChanged();
    partial void OnOrderChanging(long value);
    partial void OnOrderChanged();
    partial void OnExtChanging(string value);
    partial void OnExtChanged();
    partial void OnStatusChanging(int value);
    partial void OnStatusChanged();
    #endregion
		
		public Photo()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_AlbumID", DbType="BigInt")]
		public System.Nullable<long> AlbumID
		{
			get
			{
				return this._AlbumID;
			}
			set
			{
				if ((this._AlbumID != value))
				{
					this.OnAlbumIDChanging(value);
					this.SendPropertyChanging();
					this._AlbumID = value;
					this.SendPropertyChanged("AlbumID");
					this.OnAlbumIDChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="DateTime NOT NULL")]
		public System.DateTime AddTime
		{
			get
			{
				return this._AddTime;
			}
			set
			{
				if ((this._AddTime != value))
				{
					this.OnAddTimeChanging(value);
					this.SendPropertyChanging();
					this._AddTime = value;
					this.SendPropertyChanged("AddTime");
					this.OnAddTimeChanged();
				}
			}
		}
		
		[Column(Name="[Order]", Storage="_Order", DbType="BigInt NOT NULL")]
		public long Order
		{
			get
			{
				return this._Order;
			}
			set
			{
				if ((this._Order != value))
				{
					this.OnOrderChanging(value);
					this.SendPropertyChanging();
					this._Order = value;
					this.SendPropertyChanged("Order");
					this.OnOrderChanged();
				}
			}
		}
		
		[Column(Storage="_Ext", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Ext
		{
			get
			{
				return this._Ext;
			}
			set
			{
				if ((this._Ext != value))
				{
					this.OnExtChanging(value);
					this.SendPropertyChanging();
					this._Ext = value;
					this.SendPropertyChanged("Ext");
					this.OnExtChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Profile")]
    internal partial class Profile : INotifyPropertyChanging, INotifyPropertyChanged, IProfile
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _UserID;
		
		private string _Name;
		
		private int _Status;
		
		private long _Score;
		
		private long _ShowScore;
		
		private long _DelScore;
		
		private byte _ShowLevel;
		
		private string _MagicBox;
		
		private bool _IsMagicBox;
		
		private System.DateTime _RegTime;
		
		private System.DateTime _LoginTime;
		
		private long _ViewCount;
		
		private long _FileSizeAll;
		
		private long _FileSizeCount;
		
		private string _Applications;
		
		private string _Applicationlist;
		
		private string _Ext;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnStatusChanging(int value);
    partial void OnStatusChanged();
    partial void OnScoreChanging(long value);
    partial void OnScoreChanged();
    partial void OnShowScoreChanging(long value);
    partial void OnShowScoreChanged();
    partial void OnDelScoreChanging(long value);
    partial void OnDelScoreChanged();
    partial void OnShowLevelChanging(byte value);
    partial void OnShowLevelChanged();
    partial void OnMagicBoxChanging(string value);
    partial void OnMagicBoxChanged();
    partial void OnIsMagicBoxChanging(bool value);
    partial void OnIsMagicBoxChanged();
    partial void OnRegTimeChanging(System.DateTime value);
    partial void OnRegTimeChanged();
    partial void OnLoginTimeChanging(System.DateTime value);
    partial void OnLoginTimeChanged();
    partial void OnViewCountChanging(long value);
    partial void OnViewCountChanged();
    partial void OnFileSizeAllChanging(long value);
    partial void OnFileSizeAllChanged();
    partial void OnFileSizeCountChanging(long value);
    partial void OnFileSizeCountChanged();
    partial void OnApplicationsChanging(string value);
    partial void OnApplicationsChanged();
    partial void OnApplicationlistChanging(string value);
    partial void OnApplicationlistChanged();
    partial void OnExtChanging(string value);
    partial void OnExtChanged();
    #endregion
		
		public Profile()
		{
			OnCreated();
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[Column(Storage="_Score", DbType="BigInt NOT NULL")]
		public long Score
		{
			get
			{
				return this._Score;
			}
			set
			{
				if ((this._Score != value))
				{
					this.OnScoreChanging(value);
					this.SendPropertyChanging();
					this._Score = value;
					this.SendPropertyChanged("Score");
					this.OnScoreChanged();
				}
			}
		}
		
		[Column(Storage="_ShowScore", DbType="BigInt NOT NULL")]
		public long ShowScore
		{
			get
			{
				return this._ShowScore;
			}
			set
			{
				if ((this._ShowScore != value))
				{
					this.OnShowScoreChanging(value);
					this.SendPropertyChanging();
					this._ShowScore = value;
					this.SendPropertyChanged("ShowScore");
					this.OnShowScoreChanged();
				}
			}
		}
		
		[Column(Storage="_DelScore", DbType="BigInt NOT NULL")]
		public long DelScore
		{
			get
			{
				return this._DelScore;
			}
			set
			{
				if ((this._DelScore != value))
				{
					this.OnDelScoreChanging(value);
					this.SendPropertyChanging();
					this._DelScore = value;
					this.SendPropertyChanged("DelScore");
					this.OnDelScoreChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="TinyInt NOT NULL")]
		public byte ShowLevel
		{
			get
			{
				return this._ShowLevel;
			}
			set
			{
				if ((this._ShowLevel != value))
				{
					this.OnShowLevelChanging(value);
					this.SendPropertyChanging();
					this._ShowLevel = value;
					this.SendPropertyChanged("ShowLevel");
					this.OnShowLevelChanged();
				}
			}
		}
		
		[Column(Storage="_MagicBox", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string MagicBox
		{
			get
			{
				return this._MagicBox;
			}
			set
			{
				if ((this._MagicBox != value))
				{
					this.OnMagicBoxChanging(value);
					this.SendPropertyChanging();
					this._MagicBox = value;
					this.SendPropertyChanged("MagicBox");
					this.OnMagicBoxChanged();
				}
			}
		}
		
		[Column(Storage="_IsMagicBox", DbType="Bit NOT NULL")]
		public bool IsMagicBox
		{
			get
			{
				return this._IsMagicBox;
			}
			set
			{
				if ((this._IsMagicBox != value))
				{
					this.OnIsMagicBoxChanging(value);
					this.SendPropertyChanging();
					this._IsMagicBox = value;
					this.SendPropertyChanged("IsMagicBox");
					this.OnIsMagicBoxChanged();
				}
			}
		}
		
		[Column(Storage="_RegTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime RegTime
		{
			get
			{
				return this._RegTime;
			}
			set
			{
				if ((this._RegTime != value))
				{
					this.OnRegTimeChanging(value);
					this.SendPropertyChanging();
					this._RegTime = value;
					this.SendPropertyChanged("RegTime");
					this.OnRegTimeChanged();
				}
			}
		}
		
		[Column(Storage="_LoginTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime LoginTime
		{
			get
			{
				return this._LoginTime;
			}
			set
			{
				if ((this._LoginTime != value))
				{
					this.OnLoginTimeChanging(value);
					this.SendPropertyChanging();
					this._LoginTime = value;
					this.SendPropertyChanged("LoginTime");
					this.OnLoginTimeChanged();
				}
			}
		}
		
		[Column(Storage="_ViewCount", DbType="BigInt NOT NULL")]
		public long ViewCount
		{
			get
			{
				return this._ViewCount;
			}
			set
			{
				if ((this._ViewCount != value))
				{
					this.OnViewCountChanging(value);
					this.SendPropertyChanging();
					this._ViewCount = value;
					this.SendPropertyChanged("ViewCount");
					this.OnViewCountChanged();
				}
			}
		}
		
		[Column(Storage="_FileSizeAll", DbType="BigInt NOT NULL")]
		public long FileSizeAll
		{
			get
			{
				return this._FileSizeAll;
			}
			set
			{
				if ((this._FileSizeAll != value))
				{
					this.OnFileSizeAllChanging(value);
					this.SendPropertyChanging();
					this._FileSizeAll = value;
					this.SendPropertyChanged("FileSizeAll");
					this.OnFileSizeAllChanged();
				}
			}
		}
		
		[Column(Storage="_FileSizeCount", DbType="BigInt NOT NULL")]
		public long FileSizeCount
		{
			get
			{
				return this._FileSizeCount;
			}
			set
			{
				if ((this._FileSizeCount != value))
				{
					this.OnFileSizeCountChanging(value);
					this.SendPropertyChanging();
					this._FileSizeCount = value;
					this.SendPropertyChanged("FileSizeCount");
					this.OnFileSizeCountChanged();
				}
			}
		}
		
		[Column(Storage="_Applications", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Applications
		{
			get
			{
				return this._Applications;
			}
			set
			{
				if ((this._Applications != value))
				{
					this.OnApplicationsChanging(value);
					this.SendPropertyChanging();
					this._Applications = value;
					this.SendPropertyChanged("Applications");
					this.OnApplicationsChanged();
				}
			}
		}
		
		[Column(Storage="_Applicationlist", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Applicationlist
		{
			get
			{
				return this._Applicationlist;
			}
			set
			{
				if ((this._Applicationlist != value))
				{
					this.OnApplicationlistChanging(value);
					this.SendPropertyChanging();
					this._Applicationlist = value;
					this.SendPropertyChanged("Applicationlist");
					this.OnApplicationlistChanged();
				}
			}
		}
		
		[Column(Storage="_Ext", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Ext
		{
			get
			{
				return this._Ext;
			}
			set
			{
				if ((this._Ext != value))
				{
					this.OnExtChanging(value);
					this.SendPropertyChanging();
					this._Ext = value;
					this.SendPropertyChanged("Ext");
					this.OnExtChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Push")]
    internal partial class Push : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private long _LogID;
		
		private long _UserID;
		
		private System.DateTime _AddTime;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnLogIDChanging(long value);
    partial void OnLogIDChanged();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnAddTimeChanging(System.DateTime value);
    partial void OnAddTimeChanged();
    #endregion
		
		public Push()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_LogID", DbType="BigInt NOT NULL")]
		public long LogID
		{
			get
			{
				return this._LogID;
			}
			set
			{
				if ((this._LogID != value))
				{
					this.OnLogIDChanging(value);
					this.SendPropertyChanging();
					this._LogID = value;
					this.SendPropertyChanged("LogID");
					this.OnLogIDChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime AddTime
		{
			get
			{
				return this._AddTime;
			}
			set
			{
				if ((this._AddTime != value))
				{
					this.OnAddTimeChanging(value);
					this.SendPropertyChanging();
					this._AddTime = value;
					this.SendPropertyChanged("AddTime");
					this.OnAddTimeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Reply")]
    internal partial class Reply : INotifyPropertyChanging, INotifyPropertyChanged, IReply
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private long _UserID;
		
		private long _SenderID;
		
		private string _Body;
		
		private System.DateTime _AddTime;
		
		private bool _IsSee;
		
		private bool _IsDel;
		
		private byte _IsTellMe;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnSenderIDChanging(long value);
    partial void OnSenderIDChanged();
    partial void OnBodyChanging(string value);
    partial void OnBodyChanged();
    partial void OnAddTimeChanging(System.DateTime value);
    partial void OnAddTimeChanged();
    partial void OnIsSeeChanging(bool value);
    partial void OnIsSeeChanged();
    partial void OnIsDelChanging(bool value);
    partial void OnIsDelChanged();
    partial void OnIsTellMeChanging(byte value);
    partial void OnIsTellMeChanged();
    #endregion
		
		public Reply()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_SenderID", DbType="BigInt NOT NULL")]
		public long SenderID
		{
			get
			{
				return this._SenderID;
			}
			set
			{
				if ((this._SenderID != value))
				{
					this.OnSenderIDChanging(value);
					this.SendPropertyChanging();
					this._SenderID = value;
					this.SendPropertyChanged("SenderID");
					this.OnSenderIDChanged();
				}
			}
		}
		
		[Column(Storage="_Body", DbType="NVarChar(4000) NOT NULL", CanBeNull=false)]
		public string Body
		{
			get
			{
				return this._Body;
			}
			set
			{
				if ((this._Body != value))
				{
					this.OnBodyChanging(value);
					this.SendPropertyChanging();
					this._Body = value;
					this.SendPropertyChanged("Body");
					this.OnBodyChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime AddTime
		{
			get
			{
				return this._AddTime;
			}
			set
			{
				if ((this._AddTime != value))
				{
					this.OnAddTimeChanging(value);
					this.SendPropertyChanging();
					this._AddTime = value;
					this.SendPropertyChanged("AddTime");
					this.OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_IsSee", DbType="Bit NOT NULL")]
		public bool IsSee
		{
			get
			{
				return this._IsSee;
			}
			set
			{
				if ((this._IsSee != value))
				{
					this.OnIsSeeChanging(value);
					this.SendPropertyChanging();
					this._IsSee = value;
					this.SendPropertyChanged("IsSee");
					this.OnIsSeeChanged();
				}
			}
		}
		
		[Column(Storage="_IsDel", DbType="Bit NOT NULL")]
		public bool IsDel
		{
			get
			{
				return this._IsDel;
			}
			set
			{
				if ((this._IsDel != value))
				{
					this.OnIsDelChanging(value);
					this.SendPropertyChanging();
					this._IsDel = value;
					this.SendPropertyChanged("IsDel");
					this.OnIsDelChanged();
				}
			}
		}
		
		[Column(Storage="_IsTellMe", DbType="TinyInt NOT NULL")]
		public byte IsTellMe
		{
			get
			{
				return this._IsTellMe;
			}
			set
			{
				if ((this._IsTellMe != value))
				{
					this.OnIsTellMeChanging(value);
					this.SendPropertyChanging();
					this._IsTellMe = value;
					this.SendPropertyChanged("IsTellMe");
					this.OnIsTellMeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Services")]
    internal partial class Services : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Body;
		
		private string _Answer;
		
		private byte _Status;
		
		private System.DateTime _SendTime;
		
		private System.DateTime _AnswerTime;
		
		private long _UserID;
		
		private string _Email;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnBodyChanging(string value);
    partial void OnBodyChanged();
    partial void OnAnswerChanging(string value);
    partial void OnAnswerChanged();
    partial void OnStatusChanging(byte value);
    partial void OnStatusChanged();
    partial void OnSendTimeChanging(System.DateTime value);
    partial void OnSendTimeChanged();
    partial void OnAnswerTimeChanging(System.DateTime value);
    partial void OnAnswerTimeChanged();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    #endregion
		
		public Services()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Body", DbType="NVarChar(4000) NOT NULL", CanBeNull=false)]
		public string Body
		{
			get
			{
				return this._Body;
			}
			set
			{
				if ((this._Body != value))
				{
					this.OnBodyChanging(value);
					this.SendPropertyChanging();
					this._Body = value;
					this.SendPropertyChanged("Body");
					this.OnBodyChanged();
				}
			}
		}
		
		[Column(Storage="_Answer", DbType="NVarChar(4000) NOT NULL", CanBeNull=false)]
		public string Answer
		{
			get
			{
				return this._Answer;
			}
			set
			{
				if ((this._Answer != value))
				{
					this.OnAnswerChanging(value);
					this.SendPropertyChanging();
					this._Answer = value;
					this.SendPropertyChanged("Answer");
					this.OnAnswerChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="TinyInt NOT NULL")]
		public byte Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[Column(Storage="_SendTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime SendTime
		{
			get
			{
				return this._SendTime;
			}
			set
			{
				if ((this._SendTime != value))
				{
					this.OnSendTimeChanging(value);
					this.SendPropertyChanging();
					this._SendTime = value;
					this.SendPropertyChanged("SendTime");
					this.OnSendTimeChanged();
				}
			}
		}
		
		[Column(Storage="_AnswerTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime AnswerTime
		{
			get
			{
				return this._AnswerTime;
			}
			set
			{
				if ((this._AnswerTime != value))
				{
					this.OnAnswerTimeChanging(value);
					this.SendPropertyChanging();
					this._AnswerTime = value;
					this.SendPropertyChanged("AnswerTime");
					this.OnAnswerTimeChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_Email", DbType="NVarChar(50)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
			    if ((_Email == value)) return;
			    OnEmailChanging(value);
			    SendPropertyChanging();
			    _Email = value;
			    SendPropertyChanged("Email");
			    OnEmailChanged();
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.SuperNote")]
    internal partial class SuperNote : INotifyPropertyChanging, INotifyPropertyChanged, ISuperNote
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Title;
		
		private string _Faceurl;
		
		private string _Url;
		
		private string _Description;
		
		private long _UserID;
		
		private long _ViewCount;
		
		private System.DateTime _AddTime;
		
		private byte _ShowLevel;
		
		private System.Nullable<long> _SystemCategory;
		
		private System.Nullable<long> _Category;
		
		private byte _Type;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnFaceurlChanging(string value);
    partial void OnFaceurlChanged();
    partial void OnUrlChanging(string value);
    partial void OnUrlChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnViewCountChanging(long value);
    partial void OnViewCountChanged();
    partial void OnAddTimeChanging(System.DateTime value);
    partial void OnAddTimeChanged();
    partial void OnShowLevelChanging(byte value);
    partial void OnShowLevelChanged();
    partial void OnSystemCategoryChanging(System.Nullable<long> value);
    partial void OnSystemCategoryChanged();
    partial void OnCategoryChanging(System.Nullable<long> value);
    partial void OnCategoryChanged();
    partial void OnTypeChanging(byte value);
    partial void OnTypeChanged();
    #endregion
		
		public SuperNote()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(50)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_Faceurl", DbType="NVarChar(500)")]
		public string Faceurl
		{
			get
			{
				return this._Faceurl;
			}
			set
			{
				if ((this._Faceurl != value))
				{
					this.OnFaceurlChanging(value);
					this.SendPropertyChanging();
					this._Faceurl = value;
					this.SendPropertyChanged("Faceurl");
					this.OnFaceurlChanged();
				}
			}
		}
		
		[Column(Storage="_Url", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				if ((this._Url != value))
				{
					this.OnUrlChanging(value);
					this.SendPropertyChanging();
					this._Url = value;
					this.SendPropertyChanged("Url");
					this.OnUrlChanged();
				}
			}
		}
		
		[Column(Storage="_Description", DbType="NVarChar(50)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_ViewCount", DbType="BigInt NOT NULL")]
		public long ViewCount
		{
			get
			{
				return this._ViewCount;
			}
			set
			{
				if ((this._ViewCount != value))
				{
					this.OnViewCountChanging(value);
					this.SendPropertyChanging();
					this._ViewCount = value;
					this.SendPropertyChanged("ViewCount");
					this.OnViewCountChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public System.DateTime AddTime
		{
			get
			{
				return this._AddTime;
			}
			set
			{
				if ((this._AddTime != value))
				{
					this.OnAddTimeChanging(value);
					this.SendPropertyChanging();
					this._AddTime = value;
					this.SendPropertyChanged("AddTime");
					this.OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="TinyInt NOT NULL")]
		public byte ShowLevel
		{
			get
			{
				return this._ShowLevel;
			}
			set
			{
				if ((this._ShowLevel != value))
				{
					this.OnShowLevelChanging(value);
					this.SendPropertyChanging();
					this._ShowLevel = value;
					this.SendPropertyChanged("ShowLevel");
					this.OnShowLevelChanged();
				}
			}
		}
		
		[Column(Storage="_SystemCategory", DbType="BigInt")]
		public System.Nullable<long> SystemCategory
		{
			get
			{
				return this._SystemCategory;
			}
			set
			{
				if ((this._SystemCategory != value))
				{
					this.OnSystemCategoryChanging(value);
					this.SendPropertyChanging();
					this._SystemCategory = value;
					this.SendPropertyChanged("SystemCategory");
					this.OnSystemCategoryChanged();
				}
			}
		}
		
		[Column(Storage="_Category", DbType="BigInt")]
		public System.Nullable<long> Category
		{
			get
			{
				return this._Category;
			}
			set
			{
				if ((this._Category != value))
				{
					this.OnCategoryChanging(value);
					this.SendPropertyChanging();
					this._Category = value;
					this.SendPropertyChanged("Category");
					this.OnCategoryChanged();
				}
			}
		}
		
		[Column(Storage="_Type", DbType="TinyInt NOT NULL")]
		public byte Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Tags")]
    internal partial class Tags : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Title;
		
		private long _Count;
		
		private byte _Type;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnCountChanging(long value);
    partial void OnCountChanged();
    partial void OnTypeChanging(byte value);
    partial void OnTypeChanged();
    #endregion
		
		public Tags()
		{
			OnCreated();
		}
		
		[Column(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_Count", DbType="BigInt NOT NULL")]
		public long Count
		{
			get
			{
				return this._Count;
			}
			set
			{
				if ((this._Count != value))
				{
					this.OnCountChanging(value);
					this.SendPropertyChanging();
					this._Count = value;
					this.SendPropertyChanged("Count");
					this.OnCountChanged();
				}
			}
		}
		
		[Column(Storage="_Type", DbType="TinyInt NOT NULL")]
		public byte Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

