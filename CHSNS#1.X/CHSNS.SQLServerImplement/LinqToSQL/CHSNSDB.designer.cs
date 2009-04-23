using System.Data.Linq;
namespace CHSNS.Operator
{
    using System.ComponentModel;
	using System;
    using Abstractions;
    using System.Data.Linq.Mapping;
	
	
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
		
		public CHSNSDBDataContext(string connection, MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CHSNSDBDataContext(System.Data.IDbConnection connection, MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public Table<Account> Account
		{
			get
			{
				return GetTable<Account>();
			}
		}
		
		public Table<ViewData> ViewData
		{
			get
			{
				return GetTable<ViewData>();
			}
		}
		
		public Table<Album> Album
		{
			get
			{
				return GetTable<Album>();
			}
		}
		
		public Table<Application> Application
		{
			get
			{
				return GetTable<Application>();
			}
		}
		
		public Table<BasicInformation> BasicInformation
		{
			get
			{
				return GetTable<BasicInformation>();
			}
		}
		
		public Table<Blogs> Blogs
		{
			get
			{
				return GetTable<Blogs>();
			}
		}
		
		public Table<Category> Category
		{
			get
			{
				return GetTable<Category>();
			}
		}
		
		public Table<Comment> Comment
		{
			get
			{
				return GetTable<Comment>();
			}
		}
		
		public Table<ContactInformation> ContactInformation
		{
			get
			{
				return GetTable<ContactInformation>();
			}
		}
		
		public Table<Entry> Entry
		{
			get
			{
				return GetTable<Entry>();
			}
		}
		
		public Table<EntryVersion> EntryVersion
		{
			get
			{
				return GetTable<EntryVersion>();
			}
		}
		
		public Table<Event> Event
		{
			get
			{
				return GetTable<Event>();
			}
		}
		
		public Table<FieldInformation> FieldInformation
		{
			get
			{
				return GetTable<FieldInformation>();
			}
		}
		
		public Table<Friend> Friend
		{
			get
			{
				return GetTable<Friend>();
			}
		}
		
		public Table<Group> Group
		{
			get
			{
				return GetTable<Group>();
			}
		}
		
		public Table<GroupUser> GroupUser
		{
			get
			{
				return GetTable<GroupUser>();
			}
		}
		
		public Table<LogTag> LogTag
		{
			get
			{
				return GetTable<LogTag>();
			}
		}
		
		public Table<Message> Message
		{
			get
			{
				return GetTable<Message>();
			}
		}
		
		public Table<Note> Note
		{
			get
			{
				return GetTable<Note>();
			}
		}
		
		public Table<PersonalInformation> PersonalInformation
		{
			get
			{
				return GetTable<PersonalInformation>();
			}
		}
		
		public Table<Photo> Photo
		{
			get
			{
				return GetTable<Photo>();
			}
		}
		
		public Table<Profile> Profile
		{
			get
			{
				return GetTable<Profile>();
			}
		}
		
		public Table<Push> Push
		{
			get
			{
				return GetTable<Push>();
			}
		}
		
		public Table<Reply> Reply
		{
			get
			{
				return GetTable<Reply>();
			}
		}
		
		public Table<Services> Services
		{
			get
			{
				return GetTable<Services>();
			}
		}
		
		public Table<SuperNote> SuperNote
		{
			get
			{
				return GetTable<SuperNote>();
			}
		}
		
		public Table<Tags> Tags
		{
			get
			{
				return GetTable<Tags>();
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
    partial void OnValidate(ChangeAction action);
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
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_Username", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Username
		{
			get
			{
				return _Username;
			}
			set
			{
				if ((_Username != value))
				{
					OnUsernameChanging(value);
					SendPropertyChanging();
					_Username = value;
					SendPropertyChanged("Username");
					OnUsernameChanged();
				}
			}
		}
		
		[Column(Storage="_Password", DbType="Char(32) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return _Password;
			}
			set
			{
				if ((_Password != value))
				{
					OnPasswordChanging(value);
					SendPropertyChanging();
					_Password = value;
					SendPropertyChanged("Password");
					OnPasswordChanged();
				}
			}
		}
		
		[Column(Storage="_Code", DbType="BigInt")]
		public System.Nullable<long> Code
		{
			get
			{
				return _Code;
			}
			set
			{
				if ((_Code != value))
				{
					OnCodeChanging(value);
					SendPropertyChanging();
					_Code = value;
					SendPropertyChanged("Code");
					OnCodeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
		
		private DateTime _ViewTime;
		
		private byte _ViewClass;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
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
    partial void OnViewTimeChanging(DateTime value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_OwnerID", DbType="BigInt NOT NULL")]
		public long OwnerID
		{
			get
			{
				return _OwnerID;
			}
			set
			{
				if ((_OwnerID != value))
				{
					OnOwnerIDChanging(value);
					SendPropertyChanging();
					_OwnerID = value;
					SendPropertyChanged("OwnerID");
					OnOwnerIDChanged();
				}
			}
		}
		
		[Column(Storage="_ViewerID", DbType="BigInt NOT NULL")]
		public long ViewerID
		{
			get
			{
				return _ViewerID;
			}
			set
			{
				if ((_ViewerID != value))
				{
					OnViewerIDChanging(value);
					SendPropertyChanging();
					_ViewerID = value;
					SendPropertyChanged("ViewerID");
					OnViewerIDChanged();
				}
			}
		}
		
		[Column(Storage="_IpandComputer", DbType="NVarChar(50)")]
		public string IpandComputer
		{
			get
			{
				return _IpandComputer;
			}
			set
			{
				if ((_IpandComputer != value))
				{
					OnIpandComputerChanging(value);
					SendPropertyChanging();
					_IpandComputer = value;
					SendPropertyChanged("IpandComputer");
					OnIpandComputerChanged();
				}
			}
		}
		
		[Column(Storage="_ViewPageUrl", DbType="NVarChar(255)")]
		public string ViewPageUrl
		{
			get
			{
				return _ViewPageUrl;
			}
			set
			{
				if ((_ViewPageUrl != value))
				{
					OnViewPageUrlChanging(value);
					SendPropertyChanging();
					_ViewPageUrl = value;
					SendPropertyChanged("ViewPageUrl");
					OnViewPageUrlChanged();
				}
			}
		}
		
		[Column(Storage="_LastUrl", DbType="NVarChar(255)")]
		public string LastUrl
		{
			get
			{
				return _LastUrl;
			}
			set
			{
				if ((_LastUrl != value))
				{
					OnLastUrlChanging(value);
					SendPropertyChanging();
					_LastUrl = value;
					SendPropertyChanged("LastUrl");
					OnLastUrlChanged();
				}
			}
		}
		
		[Column(Storage="_ViewTime", DbType="DateTime NOT NULL")]
		public DateTime ViewTime
		{
			get
			{
				return _ViewTime;
			}
			set
			{
				if ((_ViewTime != value))
				{
					OnViewTimeChanging(value);
					SendPropertyChanging();
					_ViewTime = value;
					SendPropertyChanged("ViewTime");
					OnViewTimeChanged();
				}
			}
		}
		
		[Column(Storage="_ViewClass", DbType="TinyInt NOT NULL")]
		public byte ViewClass
		{
			get
			{
				return _ViewClass;
			}
			set
			{
				if ((_ViewClass != value))
				{
					OnViewClassChanging(value);
					SendPropertyChanging();
					_ViewClass = value;
					SendPropertyChanged("ViewClass");
					OnViewClassChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
		
		private DateTime _AddTime;
		
		private string _FaceUrl;
		
		private int _Count;
		
		private long _UserID;
		
		private int _Order;
		
		private byte _ShowLevel;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnLocationChanging(string value);
    partial void OnLocationChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnAddTimeChanging(DateTime value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				if ((_Name != value))
				{
					OnNameChanging(value);
					SendPropertyChanging();
					_Name = value;
					SendPropertyChanged("Name");
					OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Location", DbType="NVarChar(50)")]
		public string Location
		{
			get
			{
				return _Location;
			}
			set
			{
				if ((_Location != value))
				{
					OnLocationChanging(value);
					SendPropertyChanging();
					_Location = value;
					SendPropertyChanged("Location");
					OnLocationChanged();
				}
			}
		}
		
		[Column(Storage="_Description", DbType="NVarChar(150) NOT NULL", CanBeNull=false)]
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				if ((_Description != value))
				{
					OnDescriptionChanging(value);
					SendPropertyChanging();
					_Description = value;
					SendPropertyChanged("Description");
					OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public DateTime AddTime
		{
			get
			{
				return _AddTime;
			}
			set
			{
				if ((_AddTime != value))
				{
					OnAddTimeChanging(value);
					SendPropertyChanging();
					_AddTime = value;
					SendPropertyChanged("AddTime");
					OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_FaceUrl", DbType="NVarChar(250)")]
		public string FaceUrl
		{
			get
			{
				return _FaceUrl;
			}
			set
			{
				if ((_FaceUrl != value))
				{
					OnFaceUrlChanging(value);
					SendPropertyChanging();
					_FaceUrl = value;
					SendPropertyChanged("FaceUrl");
					OnFaceUrlChanged();
				}
			}
		}
		
		[Column(Storage="_Count", DbType="Int NOT NULL")]
		public int Count
		{
			get
			{
				return _Count;
			}
			set
			{
				if ((_Count != value))
				{
					OnCountChanging(value);
					SendPropertyChanging();
					_Count = value;
					SendPropertyChanged("Count");
					OnCountChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Name="[Order]", Storage="_Order", DbType="Int NOT NULL")]
		public int Order
		{
			get
			{
				return _Order;
			}
			set
			{
				if ((_Order != value))
				{
					OnOrderChanging(value);
					SendPropertyChanging();
					_Order = value;
					SendPropertyChanged("Order");
					OnOrderChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="TinyInt NOT NULL")]
		public byte ShowLevel
		{
			get
			{
				return _ShowLevel;
			}
			set
			{
				if ((_ShowLevel != value))
				{
					OnShowLevelChanging(value);
					SendPropertyChanging();
					_ShowLevel = value;
					SendPropertyChanged("ShowLevel");
					OnShowLevelChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
		
		private long? _Authorid;
		
		private DateTime _Addtime;
		
		private DateTime _Edittime;
		
		private string _Description;
		
		private bool _IsSystem;
		
		private bool _IsTrue;
		
		private string _DescriptionUrl;
		
		private long _UserCount;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
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
    partial void OnAuthoridChanging(long? value);
    partial void OnAuthoridChanged();
    partial void OnAddtimeChanging(DateTime value);
    partial void OnAddtimeChanged();
    partial void OnEdittimeChanging(DateTime value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Controller", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Controller
		{
			get
			{
				return _Controller;
			}
			set
			{
				if ((_Controller != value))
				{
					OnControllerChanging(value);
					SendPropertyChanging();
					_Controller = value;
					SendPropertyChanged("Controller");
					OnControllerChanged();
				}
			}
		}
		
		[Column(Storage="_Action", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Action
		{
			get
			{
				return _Action;
			}
			set
			{
				if ((_Action != value))
				{
					OnActionChanging(value);
					SendPropertyChanging();
					_Action = value;
					SendPropertyChanged("Action");
					OnActionChanged();
				}
			}
		}
		
		[Column(Storage="_ParamStr", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string ParamStr
		{
			get
			{
				return _ParamStr;
			}
			set
			{
				if ((_ParamStr != value))
				{
					OnParamStrChanging(value);
					SendPropertyChanging();
					_ParamStr = value;
					SendPropertyChanged("ParamStr");
					OnParamStrChanged();
				}
			}
		}
		
		[Column(Storage="_ClassName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string ClassName
		{
			get
			{
				return _ClassName;
			}
			set
			{
				if ((_ClassName != value))
				{
					OnClassNameChanging(value);
					SendPropertyChanging();
					_ClassName = value;
					SendPropertyChanged("ClassName");
					OnClassNameChanged();
				}
			}
		}
		
		[Column(Storage="_FullName", DbType="NVarChar(60) NOT NULL", CanBeNull=false)]
		public string FullName
		{
			get
			{
				return _FullName;
			}
			set
			{
				if ((_FullName != value))
				{
					OnFullNameChanging(value);
					SendPropertyChanging();
					_FullName = value;
					SendPropertyChanged("FullName");
					OnFullNameChanged();
				}
			}
		}
		
		[Column(Storage="_ShortName", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string ShortName
		{
			get
			{
				return _ShortName;
			}
			set
			{
				if ((_ShortName != value))
				{
					OnShortNameChanging(value);
					SendPropertyChanging();
					_ShortName = value;
					SendPropertyChanged("ShortName");
					OnShortNameChanged();
				}
			}
		}
		
		[Column(Storage="_Vision", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Vision
		{
			get
			{
				return _Vision;
			}
			set
			{
				if ((_Vision != value))
				{
					OnVisionChanging(value);
					SendPropertyChanging();
					_Vision = value;
					SendPropertyChanged("Vision");
					OnVisionChanged();
				}
			}
		}
		
		[Column(Storage="_Icon", DbType="NVarChar(250)")]
		public string Icon
		{
			get
			{
				return _Icon;
			}
			set
			{
				if ((_Icon != value))
				{
					OnIconChanging(value);
					SendPropertyChanging();
					_Icon = value;
					SendPropertyChanged("Icon");
					OnIconChanged();
				}
			}
		}
		
		[Column(Storage="_Authorid", DbType="BigInt")]
		public System.Nullable<long> Authorid
		{
			get
			{
				return _Authorid;
			}
			set
			{
				if ((_Authorid != value))
				{
					OnAuthoridChanging(value);
					SendPropertyChanging();
					_Authorid = value;
					SendPropertyChanged("Authorid");
					OnAuthoridChanged();
				}
			}
		}
		
		[Column(Storage="_Addtime", DbType="SmallDateTime NOT NULL")]
		public DateTime Addtime
		{
			get
			{
				return _Addtime;
			}
			set
			{
				if ((_Addtime != value))
				{
					OnAddtimeChanging(value);
					SendPropertyChanging();
					_Addtime = value;
					SendPropertyChanged("Addtime");
					OnAddtimeChanged();
				}
			}
		}
		
		[Column(Storage="_Edittime", DbType="SmallDateTime NOT NULL")]
		public DateTime Edittime
		{
			get
			{
				return _Edittime;
			}
			set
			{
				if ((_Edittime != value))
				{
					OnEdittimeChanging(value);
					SendPropertyChanging();
					_Edittime = value;
					SendPropertyChanged("Edittime");
					OnEdittimeChanged();
				}
			}
		}
		
		[Column(Storage="_Description", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				if ((_Description != value))
				{
					OnDescriptionChanging(value);
					SendPropertyChanging();
					_Description = value;
					SendPropertyChanged("Description");
					OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_IsSystem", DbType="Bit NOT NULL")]
		public bool IsSystem
		{
			get
			{
				return _IsSystem;
			}
			set
			{
				if ((_IsSystem != value))
				{
					OnIsSystemChanging(value);
					SendPropertyChanging();
					_IsSystem = value;
					SendPropertyChanged("IsSystem");
					OnIsSystemChanged();
				}
			}
		}
		
		[Column(Storage="_IsTrue", DbType="Bit NOT NULL")]
		public bool IsTrue
		{
			get
			{
				return _IsTrue;
			}
			set
			{
				if ((_IsTrue != value))
				{
					OnIsTrueChanging(value);
					SendPropertyChanging();
					_IsTrue = value;
					SendPropertyChanged("IsTrue");
					OnIsTrueChanged();
				}
			}
		}
		
		[Column(Storage="_DescriptionUrl", DbType="NVarChar(250)")]
		public string DescriptionUrl
		{
			get
			{
				return _DescriptionUrl;
			}
			set
			{
				if ((_DescriptionUrl != value))
				{
					OnDescriptionUrlChanging(value);
					SendPropertyChanging();
					_DescriptionUrl = value;
					SendPropertyChanged("DescriptionUrl");
					OnDescriptionUrlChanged();
				}
			}
		}
		
		[Column(Storage="_UserCount", DbType="BigInt NOT NULL")]
		public long UserCount
		{
			get
			{
				return _UserCount;
			}
			set
			{
				if ((_UserCount != value))
				{
					OnUserCountChanging(value);
					SendPropertyChanging();
					_UserCount = value;
					SendPropertyChanged("UserCount");
					OnUserCountChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
		
		private System.Nullable<DateTime> _Birthday;
		
		private int _ProvinceID;
		
		private long _CityID;
		
		private byte _ShowLevel;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
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
    partial void OnBirthdayChanging(System.Nullable<DateTime> value);
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
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(20)")]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				if ((_Name != value))
				{
					OnNameChanging(value);
					SendPropertyChanging();
					_Name = value;
					SendPropertyChanged("Name");
					OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Email", DbType="NVarChar(500)")]
		public string Email
		{
			get
			{
				return _Email;
			}
			set
			{
				if ((_Email != value))
				{
					OnEmailChanging(value);
					SendPropertyChanging();
					_Email = value;
					SendPropertyChanged("Email");
					OnEmailChanged();
				}
			}
		}
		
		[Column(Storage="_IsEmailTrue", DbType="Bit NOT NULL")]
		public bool IsEmailTrue
		{
			get
			{
				return _IsEmailTrue;
			}
			set
			{
				if ((_IsEmailTrue != value))
				{
					OnIsEmailTrueChanging(value);
					SendPropertyChanging();
					_IsEmailTrue = value;
					SendPropertyChanged("IsEmailTrue");
					OnIsEmailTrueChanged();
				}
			}
		}
		
		[Column(Storage="_Sex", DbType="Bit")]
		public bool? Sex
		{
			get
			{
				return _Sex;
			}
			set
			{
			    if ((_Sex == value)) return;
			    OnSexChanging(value);
			    SendPropertyChanging();
			    _Sex = value;
			    SendPropertyChanged("Sex");
			    OnSexChanged();
			}
		}

        [Column(Storage = "_Birthday", DbType = "SmallDateTime")]
        public DateTime? Birthday {
            get {
                return _Birthday;
            }
            set {
                if ((_Birthday == value)) return;
                OnBirthdayChanging(value);
                SendPropertyChanging();
                _Birthday = value;
                SendPropertyChanged("Birthday");
                OnBirthdayChanged();
            }
        }
		
		[Column(Storage="_ProvinceID", DbType="Int NOT NULL")]
		public int ProvinceID
		{
			get
			{
				return _ProvinceID;
			}
			set
			{
			    if ((_ProvinceID == value)) return;
			    OnProvinceIDChanging(value);
			    SendPropertyChanging();
			    _ProvinceID = value;
			    SendPropertyChanged("ProvinceID");
			    OnProvinceIDChanged();
			}
		}
		
		[Column(Storage="_CityID", DbType="BigInt NOT NULL")]
		public long CityID
		{
			get
			{
				return _CityID;
			}
			set
			{
			    if ((_CityID == value)) return;
			    OnCityIDChanging(value);
			    SendPropertyChanging();
			    _CityID = value;
			    SendPropertyChanged("CityID");
			    OnCityIDChanged();
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="TinyInt NOT NULL")]
		public byte ShowLevel
		{
			get
			{
				return _ShowLevel;
			}
			set
			{
			    if ((_ShowLevel == value)) return;
			    OnShowLevelChanging(value);
			    SendPropertyChanging();
			    _ShowLevel = value;
			    SendPropertyChanged("ShowLevel");
			    OnShowLevelChanged();
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Blogs")]
    internal partial class Blogs : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _UserID;
		
		private DateTime _CreateTime;
		
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
    partial void OnValidate(ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnCreateTimeChanging(DateTime value);
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
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_CreateTime", DbType="SmallDateTime NOT NULL")]
		public DateTime CreateTime
		{
			get
			{
				return _CreateTime;
			}
			set
			{
				if ((_CreateTime != value))
				{
					OnCreateTimeChanging(value);
					SendPropertyChanging();
					_CreateTime = value;
					SendPropertyChanged("CreateTime");
					OnCreateTimeChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				if ((_Title != value))
				{
					OnTitleChanging(value);
					SendPropertyChanging();
					_Title = value;
					SendPropertyChanged("Title");
					OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_SubTitle", DbType="NVarChar(500)")]
		public string SubTitle
		{
			get
			{
				return _SubTitle;
			}
			set
			{
				if ((_SubTitle != value))
				{
					OnSubTitleChanging(value);
					SendPropertyChanging();
					_SubTitle = value;
					SendPropertyChanged("SubTitle");
					OnSubTitleChanged();
				}
			}
		}
		
		[Column(Storage="_Publish", DbType="NVarChar(MAX)")]
		public string Publish
		{
			get
			{
				return _Publish;
			}
			set
			{
				if ((_Publish != value))
				{
					OnPublishChanging(value);
					SendPropertyChanging();
					_Publish = value;
					SendPropertyChanged("Publish");
					OnPublishChanged();
				}
			}
		}
		
		[Column(Storage="_WriteName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string WriteName
		{
			get
			{
				return _WriteName;
			}
			set
			{
				if ((_WriteName != value))
				{
					OnWriteNameChanging(value);
					SendPropertyChanging();
					_WriteName = value;
					SendPropertyChanged("WriteName");
					OnWriteNameChanged();
				}
			}
		}
		
		[Column(Storage="_CommentEmail", DbType="NVarChar(50)")]
		public string CommentEmail
		{
			get
			{
				return _CommentEmail;
			}
			set
			{
				if ((_CommentEmail != value))
				{
					OnCommentEmailChanging(value);
					SendPropertyChanging();
					_CommentEmail = value;
					SendPropertyChanged("CommentEmail");
					OnCommentEmailChanged();
				}
			}
		}
		
		[Column(Storage="_Skin", DbType="NVarChar(50)")]
		public string Skin
		{
			get
			{
				return _Skin;
			}
			set
			{
				if ((_Skin != value))
				{
					OnSkinChanging(value);
					SendPropertyChanging();
					_Skin = value;
					SendPropertyChanged("Skin");
					OnSkinChanged();
				}
			}
		}
		
		[Column(Storage="_Css", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Css
		{
			get
			{
				return _Css;
			}
			set
			{
				if ((_Css != value))
				{
					OnCssChanging(value);
					SendPropertyChanging();
					_Css = value;
					SendPropertyChanged("Css");
					OnCssChanged();
				}
			}
		}
		
		[Column(Storage="_MetaKey", DbType="NVarChar(400)")]
		public string MetaKey
		{
			get
			{
				return _MetaKey;
			}
			set
			{
				if ((_MetaKey != value))
				{
					OnMetaKeyChanging(value);
					SendPropertyChanging();
					_MetaKey = value;
					SendPropertyChanged("MetaKey");
					OnMetaKeyChanged();
				}
			}
		}
		
		[Column(Storage="_IsWebServices", DbType="Bit NOT NULL")]
		public bool IsWebServices
		{
			get
			{
				return _IsWebServices;
			}
			set
			{
				if ((_IsWebServices != value))
				{
					OnIsWebServicesChanging(value);
					SendPropertyChanging();
					_IsWebServices = value;
					SendPropertyChanged("IsWebServices");
					OnIsWebServicesChanged();
				}
			}
		}
		
		[Column(Storage="_PostCount", DbType="BigInt NOT NULL")]
		public long PostCount
		{
			get
			{
				return _PostCount;
			}
			set
			{
				if ((_PostCount != value))
				{
					OnPostCountChanging(value);
					SendPropertyChanging();
					_PostCount = value;
					SendPropertyChanged("PostCount");
					OnPostCountChanged();
				}
			}
		}
		
		[Column(Storage="_CommentCount", DbType="BigInt NOT NULL")]
		public long CommentCount
		{
			get
			{
				return _CommentCount;
			}
			set
			{
				if ((_CommentCount != value))
				{
					OnCommentCountChanging(value);
					SendPropertyChanging();
					_CommentCount = value;
					SendPropertyChanged("CommentCount");
					OnCommentCountChanged();
				}
			}
		}
		
		[Column(Storage="_TrackBackCount", DbType="BigInt NOT NULL")]
		public long TrackBackCount
		{
			get
			{
				return _TrackBackCount;
			}
			set
			{
				if ((_TrackBackCount != value))
				{
					OnTrackBackCountChanging(value);
					SendPropertyChanging();
					_TrackBackCount = value;
					SendPropertyChanged("TrackBackCount");
					OnTrackBackCountChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
    partial void OnValidate(ChangeAction action);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				if ((_Name != value))
				{
					OnNameChanging(value);
					SendPropertyChanging();
					_Name = value;
					SendPropertyChanged("Name");
					OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_Type", DbType="TinyInt NOT NULL")]
		public byte Type
		{
			get
			{
				return _Type;
			}
			set
			{
				if ((_Type != value))
				{
					OnTypeChanging(value);
					SendPropertyChanging();
					_Type = value;
					SendPropertyChanged("Type");
					OnTypeChanged();
				}
			}
		}
		
		[Column(Storage="_Count", DbType="BigInt NOT NULL")]
		public long Count
		{
			get
			{
				return _Count;
			}
			set
			{
				if ((_Count != value))
				{
					OnCountChanging(value);
					SendPropertyChanging();
					_Count = value;
					SendPropertyChanged("Count");
					OnCountChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt")]
		public System.Nullable<long> UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Comment")]
    internal partial class Comment : INotifyPropertyChanging, INotifyPropertyChanged, IComment
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private long? _ShowerID;
		
		private long _OwnerID;
		
		private long _SenderID;
		
		private DateTime _AddTime;
		
		private string _Body;
		
		private bool _IsReply;
		
		private bool _IsSee;
		
		private bool _IsDel;
		
		private byte _Type;
		
		private byte _IsTellMe;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnShowerIDChanging(System.Nullable<long> value);
    partial void OnShowerIDChanged();
    partial void OnOwnerIDChanging(long value);
    partial void OnOwnerIDChanged();
    partial void OnSenderIDChanging(long value);
    partial void OnSenderIDChanged();
    partial void OnAddTimeChanging(DateTime value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_ShowerID", DbType="BigInt")]
		public System.Nullable<long> ShowerID
		{
			get
			{
				return _ShowerID;
			}
			set
			{
				if ((_ShowerID != value))
				{
					OnShowerIDChanging(value);
					SendPropertyChanging();
					_ShowerID = value;
					SendPropertyChanged("ShowerID");
					OnShowerIDChanged();
				}
			}
		}
		
		[Column(Storage="_OwnerID", DbType="BigInt NOT NULL")]
		public long OwnerID
		{
			get
			{
				return _OwnerID;
			}
			set
			{
				if ((_OwnerID != value))
				{
					OnOwnerIDChanging(value);
					SendPropertyChanging();
					_OwnerID = value;
					SendPropertyChanged("OwnerID");
					OnOwnerIDChanged();
				}
			}
		}
		
		[Column(Storage="_SenderID", DbType="BigInt NOT NULL")]
		public long SenderID
		{
			get
			{
				return _SenderID;
			}
			set
			{
				if ((_SenderID != value))
				{
					OnSenderIDChanging(value);
					SendPropertyChanging();
					_SenderID = value;
					SendPropertyChanged("SenderID");
					OnSenderIDChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public DateTime AddTime
		{
			get
			{
				return _AddTime;
			}
			set
			{
				if ((_AddTime != value))
				{
					OnAddTimeChanging(value);
					SendPropertyChanging();
					_AddTime = value;
					SendPropertyChanged("AddTime");
					OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_Body", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Body
		{
			get
			{
				return _Body;
			}
			set
			{
				if ((_Body != value))
				{
					OnBodyChanging(value);
					SendPropertyChanging();
					_Body = value;
					SendPropertyChanged("Body");
					OnBodyChanged();
				}
			}
		}
		
		[Column(Storage="_IsReply", DbType="Bit NOT NULL")]
		public bool IsReply
		{
			get
			{
				return _IsReply;
			}
			set
			{
				if ((_IsReply != value))
				{
					OnIsReplyChanging(value);
					SendPropertyChanging();
					_IsReply = value;
					SendPropertyChanged("IsReply");
					OnIsReplyChanged();
				}
			}
		}
		
		[Column(Storage="_IsSee", DbType="Bit NOT NULL")]
		public bool IsSee
		{
			get
			{
				return _IsSee;
			}
			set
			{
				if ((_IsSee != value))
				{
					OnIsSeeChanging(value);
					SendPropertyChanging();
					_IsSee = value;
					SendPropertyChanged("IsSee");
					OnIsSeeChanged();
				}
			}
		}
		
		[Column(Storage="_IsDel", DbType="Bit NOT NULL")]
		public bool IsDel
		{
			get
			{
				return _IsDel;
			}
			set
			{
				if ((_IsDel != value))
				{
					OnIsDelChanging(value);
					SendPropertyChanging();
					_IsDel = value;
					SendPropertyChanged("IsDel");
					OnIsDelChanged();
				}
			}
		}
		
		[Column(Storage="_Type", DbType="TinyInt NOT NULL")]
		public byte Type
		{
			get
			{
				return _Type;
			}
			set
			{
				if ((_Type != value))
				{
					OnTypeChanging(value);
					SendPropertyChanging();
					_Type = value;
					SendPropertyChanged("Type");
					OnTypeChanged();
				}
			}
		}
		
		[Column(Storage="_IsTellMe", DbType="TinyInt NOT NULL")]
		public byte IsTellMe
		{
			get
			{
				return _IsTellMe;
			}
			set
			{
				if ((_IsTellMe != value))
				{
					OnIsTellMeChanging(value);
					SendPropertyChanging();
					_IsTellMe = value;
					SendPropertyChanged("IsTellMe");
					OnIsTellMeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
    partial void OnValidate(ChangeAction action);
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
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_Address", DbType="NVarChar(100)")]
		public string Address
		{
			get
			{
				return _Address;
			}
			set
			{
				if ((_Address != value))
				{
					OnAddressChanging(value);
					SendPropertyChanging();
					_Address = value;
					SendPropertyChanged("Address");
					OnAddressChanged();
				}
			}
		}
		
		[Column(Storage="_QQ", DbType="NVarChar(50)")]
		public string QQ
		{
			get
			{
				return _QQ;
			}
			set
			{
				if ((_QQ != value))
				{
					OnQQChanging(value);
					SendPropertyChanging();
					_QQ = value;
					SendPropertyChanged("QQ");
					OnQQChanged();
				}
			}
		}
		
		[Column(Storage="_Msn", DbType="NVarChar(50)")]
		public string Msn
		{
			get
			{
				return _Msn;
			}
			set
			{
				if ((_Msn != value))
				{
					OnMsnChanging(value);
					SendPropertyChanging();
					_Msn = value;
					SendPropertyChanged("Msn");
					OnMsnChanged();
				}
			}
		}
		
		[Column(Storage="_WangWang", DbType="NVarChar(50)")]
		public string WangWang
		{
			get
			{
				return _WangWang;
			}
			set
			{
				if ((_WangWang != value))
				{
					OnWangWangChanging(value);
					SendPropertyChanging();
					_WangWang = value;
					SendPropertyChanged("WangWang");
					OnWangWangChanged();
				}
			}
		}
		
		[Column(Storage="_NeteasePop", DbType="NVarChar(50)")]
		public string NeteasePop
		{
			get
			{
				return _NeteasePop;
			}
			set
			{
				if ((_NeteasePop != value))
				{
					OnNeteasePopChanging(value);
					SendPropertyChanging();
					_NeteasePop = value;
					SendPropertyChanged("NeteasePop");
					OnNeteasePopChanged();
				}
			}
		}
		
		[Column(Storage="_UC", DbType="NVarChar(50)")]
		public string UC
		{
			get
			{
				return _UC;
			}
			set
			{
				if ((_UC != value))
				{
					OnUCChanging(value);
					SendPropertyChanging();
					_UC = value;
					SendPropertyChanged("UC");
					OnUCChanged();
				}
			}
		}
		
		[Column(Storage="_Telphone", DbType="NVarChar(50)")]
		public string Telphone
		{
			get
			{
				return _Telphone;
			}
			set
			{
				if ((_Telphone != value))
				{
					OnTelphoneChanging(value);
					SendPropertyChanging();
					_Telphone = value;
					SendPropertyChanged("Telphone");
					OnTelphoneChanged();
				}
			}
		}
		
		[Column(Storage="_Mobiephone", DbType="NVarChar(50)")]
		public string Mobiephone
		{
			get
			{
				return _Mobiephone;
			}
			set
			{
				if ((_Mobiephone != value))
				{
					OnMobiephoneChanging(value);
					SendPropertyChanging();
					_Mobiephone = value;
					SendPropertyChanged("Mobiephone");
					OnMobiephoneChanged();
				}
			}
		}
		
		[Column(Storage="_WebSite", DbType="NVarChar(100)")]
		public string WebSite
		{
			get
			{
				return _WebSite;
			}
			set
			{
				if ((_WebSite != value))
				{
					OnWebSiteChanging(value);
					SendPropertyChanging();
					_WebSite = value;
					SendPropertyChanged("WebSite");
					OnWebSiteChanged();
				}
			}
		}
		
		[Column(Storage="_TellMethod", DbType="TinyInt NOT NULL")]
		public byte TellMethod
		{
			get
			{
				return _TellMethod;
			}
			set
			{
				if ((_TellMethod != value))
				{
					OnTellMethodChanging(value);
					SendPropertyChanging();
					_TellMethod = value;
					SendPropertyChanged("TellMethod");
					OnTellMethodChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="TinyInt NOT NULL")]
		public byte ShowLevel
		{
			get
			{
				return _ShowLevel;
			}
			set
			{
				if ((_ShowLevel != value))
				{
					OnShowLevelChanging(value);
					SendPropertyChanging();
					_ShowLevel = value;
					SendPropertyChanged("ShowLevel");
					OnShowLevelChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
		
		private DateTime _UpdateTime;
		
		private System.Nullable<long> _CurrentID;
		
		private int _EditCount;
		
		private long _ViewCount;
		
		private int _Status;
		
		private string _Ext;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnCreaterIDChanging(long value);
    partial void OnCreaterIDChanged();
    partial void OnUpdateTimeChanging(DateTime value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				if ((_Title != value))
				{
					OnTitleChanging(value);
					SendPropertyChanging();
					_Title = value;
					SendPropertyChanged("Title");
					OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_CreaterID", DbType="BigInt NOT NULL")]
		public long CreaterID
		{
			get
			{
				return _CreaterID;
			}
			set
			{
				if ((_CreaterID != value))
				{
					OnCreaterIDChanging(value);
					SendPropertyChanging();
					_CreaterID = value;
					SendPropertyChanged("CreaterID");
					OnCreaterIDChanged();
				}
			}
		}
		
		[Column(Storage="_UpdateTime", DbType="SmallDateTime NOT NULL")]
		public DateTime UpdateTime
		{
			get
			{
				return _UpdateTime;
			}
			set
			{
				if ((_UpdateTime != value))
				{
					OnUpdateTimeChanging(value);
					SendPropertyChanging();
					_UpdateTime = value;
					SendPropertyChanged("UpdateTime");
					OnUpdateTimeChanged();
				}
			}
		}
		
		[Column(Storage="_CurrentID", DbType="BigInt")]
		public System.Nullable<long> CurrentID
		{
			get
			{
				return _CurrentID;
			}
			set
			{
				if ((_CurrentID != value))
				{
					OnCurrentIDChanging(value);
					SendPropertyChanging();
					_CurrentID = value;
					SendPropertyChanged("CurrentID");
					OnCurrentIDChanged();
				}
			}
		}
		
		[Column(Storage="_EditCount", DbType="Int NOT NULL")]
		public int EditCount
		{
			get
			{
				return _EditCount;
			}
			set
			{
				if ((_EditCount != value))
				{
					OnEditCountChanging(value);
					SendPropertyChanging();
					_EditCount = value;
					SendPropertyChanged("EditCount");
					OnEditCountChanged();
				}
			}
		}
		
		[Column(Storage="_ViewCount", DbType="BigInt NOT NULL")]
		public long ViewCount
		{
			get
			{
				return _ViewCount;
			}
			set
			{
				if ((_ViewCount != value))
				{
					OnViewCountChanging(value);
					SendPropertyChanging();
					_ViewCount = value;
					SendPropertyChanged("ViewCount");
					OnViewCountChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
		{
			get
			{
				return _Status;
			}
			set
			{
				if ((_Status != value))
				{
					OnStatusChanging(value);
					SendPropertyChanging();
					_Status = value;
					SendPropertyChanged("Status");
					OnStatusChanged();
				}
			}
		}
		
		[Column(Storage="_Ext", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Ext
		{
			get
			{
				return _Ext;
			}
			set
			{
				if ((_Ext != value))
				{
					OnExtChanging(value);
					SendPropertyChanging();
					_Ext = value;
					SendPropertyChanged("Ext");
					OnExtChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.EntryVersion")]
    internal partial class EntryVersion : INotifyPropertyChanging, INotifyPropertyChanged, IEntryVersion
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Reason;
		
		private DateTime _AddTime;
		
		private string _Description;
		
		private string _Reference;
		
		private long _UserID;
		
		private int _Status;
		
		private System.Nullable<long> _EntryID;
		
		private string _ParentText;
		
		private string _Ext;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnReasonChanging(string value);
    partial void OnReasonChanged();
    partial void OnAddTimeChanging(DateTime value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Reason", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Reason
		{
			get
			{
				return _Reason;
			}
			set
			{
				if ((_Reason != value))
				{
					OnReasonChanging(value);
					SendPropertyChanging();
					_Reason = value;
					SendPropertyChanged("Reason");
					OnReasonChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public DateTime AddTime
		{
			get
			{
				return _AddTime;
			}
			set
			{
				if ((_AddTime != value))
				{
					OnAddTimeChanging(value);
					SendPropertyChanging();
					_AddTime = value;
					SendPropertyChanged("AddTime");
					OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_Description", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				if ((_Description != value))
				{
					OnDescriptionChanging(value);
					SendPropertyChanging();
					_Description = value;
					SendPropertyChanged("Description");
					OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_Reference", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Reference
		{
			get
			{
				return _Reference;
			}
			set
			{
				if ((_Reference != value))
				{
					OnReferenceChanging(value);
					SendPropertyChanging();
					_Reference = value;
					SendPropertyChanged("Reference");
					OnReferenceChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
		{
			get
			{
				return _Status;
			}
			set
			{
			    if ((_Status == value)) return;
			    OnStatusChanging(value);
			    SendPropertyChanging();
			    _Status = value;
			    SendPropertyChanged("Status");
			    OnStatusChanged();
			}
		}

        [Column(Storage = "_EntryID", DbType = "BigInt")]
        public long? EntryID {
            get {
                return _EntryID;
            }
            set {
                if ((_EntryID == value)) return;
                OnEntryIDChanging(value);
                SendPropertyChanging();
                _EntryID = value;
                SendPropertyChanged("EntryID");
                OnEntryIDChanged();
            }
        }
		
		[Column(Storage="_ParentText", DbType="NVarChar(50)")]
		public string ParentText
		{
			get
			{
				return _ParentText;
			}
			set
			{
				if ((_ParentText != value))
				{
					OnParentTextChanging(value);
					SendPropertyChanging();
					_ParentText = value;
					SendPropertyChanged("ParentText");
					OnParentTextChanged();
				}
			}
		}
		
		[Column(Storage="_Ext", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Ext
		{
			get
			{
				return _Ext;
			}
			set
			{
				if ((_Ext != value))
				{
					OnExtChanging(value);
					SendPropertyChanging();
					_Ext = value;
					SendPropertyChanged("Ext");
					OnExtChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
		
		private DateTime _AddTime;
		
		private int _ShowLevel;
		
		private string _Json;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnTemplateNameChanging(string value);
    partial void OnTemplateNameChanged();
    partial void OnOwnerIDChanging(long value);
    partial void OnOwnerIDChanged();
    partial void OnViewerIDChanging(System.Nullable<long> value);
    partial void OnViewerIDChanged();
    partial void OnAddTimeChanging(DateTime value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_TemplateName", DbType="NVarChar(250) NOT NULL", CanBeNull=false)]
		public string TemplateName
		{
			get
			{
				return _TemplateName;
			}
			set
			{
				if ((_TemplateName != value))
				{
					OnTemplateNameChanging(value);
					SendPropertyChanging();
					_TemplateName = value;
					SendPropertyChanged("TemplateName");
					OnTemplateNameChanged();
				}
			}
		}
		
		[Column(Storage="_OwnerID", DbType="BigInt NOT NULL")]
		public long OwnerID
		{
			get
			{
				return _OwnerID;
			}
			set
			{
				if ((_OwnerID != value))
				{
					OnOwnerIDChanging(value);
					SendPropertyChanging();
					_OwnerID = value;
					SendPropertyChanged("OwnerID");
					OnOwnerIDChanged();
				}
			}
		}
		
		[Column(Storage="_ViewerID", DbType="BigInt")]
		public System.Nullable<long> ViewerID
		{
			get
			{
				return _ViewerID;
			}
			set
			{
				if ((_ViewerID != value))
				{
					OnViewerIDChanging(value);
					SendPropertyChanging();
					_ViewerID = value;
					SendPropertyChanged("ViewerID");
					OnViewerIDChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public DateTime AddTime
		{
			get
			{
				return _AddTime;
			}
			set
			{
				if ((_AddTime != value))
				{
					OnAddTimeChanging(value);
					SendPropertyChanging();
					_AddTime = value;
					SendPropertyChanged("AddTime");
					OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="Int NOT NULL")]
		public int ShowLevel
		{
			get
			{
				return _ShowLevel;
			}
			set
			{
				if ((_ShowLevel != value))
				{
					OnShowLevelChanging(value);
					SendPropertyChanging();
					_ShowLevel = value;
					SendPropertyChanged("ShowLevel");
					OnShowLevelChanged();
				}
			}
		}
		
		[Column(Storage="_Json", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Json
		{
			get
			{
				return _Json;
			}
			set
			{
				if ((_Json != value))
				{
					OnJsonChanging(value);
					SendPropertyChanging();
					_Json = value;
					SendPropertyChanged("Json");
					OnJsonChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.FieldInformation")]
    internal partial class FieldInformation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _UserID;
		
		private long _Field;
		
		private short? _Year;
		
		private long? _MiniField;
		
		private long? _QinShi;
		
		private long? _Field1;
		
		private long? _Field2;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
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
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_Field", DbType="BigInt NOT NULL")]
		public long Field
		{
			get
			{
				return _Field;
			}
			set
			{
				if ((_Field != value))
				{
					OnFieldChanging(value);
					SendPropertyChanging();
					_Field = value;
					SendPropertyChanged("Field");
					OnFieldChanged();
				}
			}
		}
		
		[Column(Storage="_Year", DbType="SmallInt")]
		public System.Nullable<short> Year
		{
			get
			{
				return _Year;
			}
			set
			{
				if ((_Year != value))
				{
					OnYearChanging(value);
					SendPropertyChanging();
					_Year = value;
					SendPropertyChanged("Year");
					OnYearChanged();
				}
			}
		}
		
		[Column(Storage="_MiniField", DbType="BigInt")]
		public System.Nullable<long> MiniField
		{
			get
			{
				return _MiniField;
			}
			set
			{
				if ((_MiniField != value))
				{
					OnMiniFieldChanging(value);
					SendPropertyChanging();
					_MiniField = value;
					SendPropertyChanged("MiniField");
					OnMiniFieldChanged();
				}
			}
		}
		
		[Column(Storage="_QinShi", DbType="BigInt")]
		public System.Nullable<long> QinShi
		{
			get
			{
				return _QinShi;
			}
			set
			{
				if ((_QinShi != value))
				{
					OnQinShiChanging(value);
					SendPropertyChanging();
					_QinShi = value;
					SendPropertyChanged("QinShi");
					OnQinShiChanged();
				}
			}
		}
		
		[Column(Storage="_Field1", DbType="BigInt")]
		public System.Nullable<long> Field1
		{
			get
			{
				return _Field1;
			}
			set
			{
				if ((_Field1 != value))
				{
					OnField1Changing(value);
					SendPropertyChanging();
					_Field1 = value;
					SendPropertyChanged("Field1");
					OnField1Changed();
				}
			}
		}
		
		[Column(Storage="_Field2", DbType="BigInt")]
		public System.Nullable<long> Field2
		{
			get
			{
				return _Field2;
			}
			set
			{
				if ((_Field2 != value))
				{
					OnField2Changing(value);
					SendPropertyChanging();
					_Field2 = value;
					SendPropertyChanged("Field2");
					OnField2Changed();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
    partial void OnValidate(ChangeAction action);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_FromID", DbType="BigInt NOT NULL")]
		public long FromID
		{
			get
			{
				return _FromID;
			}
			set
			{
				if ((_FromID != value))
				{
					OnFromIDChanging(value);
					SendPropertyChanging();
					_FromID = value;
					SendPropertyChanged("FromID");
					OnFromIDChanged();
				}
			}
		}
		
		[Column(Storage="_ToID", DbType="BigInt NOT NULL")]
		public long ToID
		{
			get
			{
				return _ToID;
			}
			set
			{
				if ((_ToID != value))
				{
					OnToIDChanging(value);
					SendPropertyChanging();
					_ToID = value;
					SendPropertyChanged("ToID");
					OnToIDChanged();
				}
			}
		}
		
		[Column(Storage="_IsTrue", DbType="Bit NOT NULL")]
		public bool IsTrue
		{
			get
			{
				return _IsTrue;
			}
			set
			{
				if ((_IsTrue != value))
				{
					OnIsTrueChanging(value);
					SendPropertyChanging();
					_IsTrue = value;
					SendPropertyChanged("IsTrue");
					OnIsTrueChanged();
				}
			}
		}
		
		[Column(Storage="_IsCommon", DbType="Bit NOT NULL")]
		public bool IsCommon
		{
			get
			{
				return _IsCommon;
			}
			set
			{
				if ((_IsCommon != value))
				{
					OnIsCommonChanging(value);
					SendPropertyChanging();
					_IsCommon = value;
					SendPropertyChanged("IsCommon");
					OnIsCommonChanged();
				}
			}
		}
		
		[Column(Storage="_FriendType", DbType="Int")]
		public System.Nullable<int> FriendType
		{
			get
			{
				return _FriendType;
			}
			set
			{
				if ((_FriendType != value))
				{
					OnFriendTypeChanging(value);
					SendPropertyChanging();
					_FriendType = value;
					SendPropertyChanged("FriendType");
					OnFriendTypeChanged();
				}
			}
		}
		
		[Column(Storage="_FriendSummary", DbType="Int")]
		public System.Nullable<int> FriendSummary
		{
			get
			{
				return _FriendSummary;
			}
			set
			{
				if ((_FriendSummary != value))
				{
					OnFriendSummaryChanging(value);
					SendPropertyChanging();
					_FriendSummary = value;
					SendPropertyChanged("FriendSummary");
					OnFriendSummaryChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
		
		private DateTime _AddTime;
		
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
    partial void OnValidate(ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnLogoUrlChanging(string value);
    partial void OnLogoUrlChanged();
    partial void OnAddTimeChanging(DateTime value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				if ((_Name != value))
				{
					OnNameChanging(value);
					SendPropertyChanging();
					_Name = value;
					SendPropertyChanged("Name");
					OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_LogoUrl", DbType="NVarChar(250)")]
		public string LogoUrl
		{
			get
			{
				return _LogoUrl;
			}
			set
			{
				if ((_LogoUrl != value))
				{
					OnLogoUrlChanging(value);
					SendPropertyChanging();
					_LogoUrl = value;
					SendPropertyChanged("LogoUrl");
					OnLogoUrlChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public DateTime AddTime
		{
			get
			{
				return _AddTime;
			}
			set
			{
				if ((_AddTime != value))
				{
					OnAddTimeChanging(value);
					SendPropertyChanging();
					_AddTime = value;
					SendPropertyChanged("AddTime");
					OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_Summary", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Summary
		{
			get
			{
				return _Summary;
			}
			set
			{
				if ((_Summary != value))
				{
					OnSummaryChanging(value);
					SendPropertyChanging();
					_Summary = value;
					SendPropertyChanged("Summary");
					OnSummaryChanged();
				}
			}
		}
		
		[Column(Storage="_CreaterID", DbType="BigInt NOT NULL")]
		public long CreaterID
		{
			get
			{
				return _CreaterID;
			}
			set
			{
				if ((_CreaterID != value))
				{
					OnCreaterIDChanging(value);
					SendPropertyChanging();
					_CreaterID = value;
					SendPropertyChanged("CreaterID");
					OnCreaterIDChanged();
				}
			}
		}
		
		[Column(Storage="_UserCount", DbType="BigInt NOT NULL")]
		public long UserCount
		{
			get
			{
				return _UserCount;
			}
			set
			{
				if ((_UserCount != value))
				{
					OnUserCountChanging(value);
					SendPropertyChanging();
					_UserCount = value;
					SendPropertyChanged("UserCount");
					OnUserCountChanged();
				}
			}
		}
		
		[Column(Storage="_AdminCount", DbType="TinyInt NOT NULL")]
		public byte AdminCount
		{
			get
			{
				return _AdminCount;
			}
			set
			{
				if ((_AdminCount != value))
				{
					OnAdminCountChanging(value);
					SendPropertyChanging();
					_AdminCount = value;
					SendPropertyChanged("AdminCount");
					OnAdminCountChanged();
				}
			}
		}
		
		[Column(Storage="_PostCount", DbType="BigInt NOT NULL")]
		public long PostCount
		{
			get
			{
				return _PostCount;
			}
			set
			{
				if ((_PostCount != value))
				{
					OnPostCountChanging(value);
					SendPropertyChanging();
					_PostCount = value;
					SendPropertyChanged("PostCount");
					OnPostCountChanged();
				}
			}
		}
		
		[Column(Storage="_ViewCount", DbType="BigInt NOT NULL")]
		public long ViewCount
		{
			get
			{
				return _ViewCount;
			}
			set
			{
				if ((_ViewCount != value))
				{
					OnViewCountChanging(value);
					SendPropertyChanging();
					_ViewCount = value;
					SendPropertyChanged("ViewCount");
					OnViewCountChanged();
				}
			}
		}
		
		[Column(Storage="_JoinLevel", DbType="TinyInt NOT NULL")]
		public byte JoinLevel
		{
			get
			{
				return _JoinLevel;
			}
			set
			{
				if ((_JoinLevel != value))
				{
					OnJoinLevelChanging(value);
					SendPropertyChanging();
					_JoinLevel = value;
					SendPropertyChanged("JoinLevel");
					OnJoinLevelChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="TinyInt NOT NULL")]
		public byte ShowLevel
		{
			get
			{
				return _ShowLevel;
			}
			set
			{
				if ((_ShowLevel != value))
				{
					OnShowLevelChanging(value);
					SendPropertyChanging();
					_ShowLevel = value;
					SendPropertyChanged("ShowLevel");
					OnShowLevelChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="TinyInt NOT NULL")]
		public byte Status
		{
			get
			{
				return _Status;
			}
			set
			{
				if ((_Status != value))
				{
					OnStatusChanging(value);
					SendPropertyChanging();
					_Status = value;
					SendPropertyChanged("Status");
					OnStatusChanged();
				}
			}
		}
		
		[Column(Storage="_Type", DbType="TinyInt NOT NULL")]
		public byte Type
		{
			get
			{
				return _Type;
			}
			set
			{
				if ((_Type != value))
				{
					OnTypeChanging(value);
					SendPropertyChanging();
					_Type = value;
					SendPropertyChanged("Type");
					OnTypeChanged();
				}
			}
		}
		
		[Column(Storage="_Ext", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Ext
		{
			get
			{
				return _Ext;
			}
			set
			{
				if ((_Ext != value))
				{
					OnExtChanging(value);
					SendPropertyChanging();
					_Ext = value;
					SendPropertyChanged("Ext");
					OnExtChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.GroupUser")]
    internal partial class GroupUser : INotifyPropertyChanging, INotifyPropertyChanged, IGroupUser
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _UserID;
		
		private long _GroupID;
		
		private DateTime _AddTime;
		
		private long _PostCount;
		
		private byte _Status;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
    partial void OnCreated();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnGroupIDChanging(long value);
    partial void OnGroupIDChanged();
    partial void OnAddTimeChanging(DateTime value);
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
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_GroupID", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long GroupID
		{
			get
			{
				return _GroupID;
			}
			set
			{
				if ((_GroupID != value))
				{
					OnGroupIDChanging(value);
					SendPropertyChanging();
					_GroupID = value;
					SendPropertyChanged("GroupID");
					OnGroupIDChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public DateTime AddTime
		{
			get
			{
				return _AddTime;
			}
			set
			{
				if ((_AddTime != value))
				{
					OnAddTimeChanging(value);
					SendPropertyChanging();
					_AddTime = value;
					SendPropertyChanged("AddTime");
					OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_PostCount", DbType="BigInt NOT NULL")]
		public long PostCount
		{
			get
			{
				return _PostCount;
			}
			set
			{
				if ((_PostCount != value))
				{
					OnPostCountChanging(value);
					SendPropertyChanging();
					_PostCount = value;
					SendPropertyChanged("PostCount");
					OnPostCountChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="TinyInt NOT NULL")]
		public byte Status
		{
			get
			{
				return _Status;
			}
			set
			{
				if ((_Status != value))
				{
					OnStatusChanging(value);
					SendPropertyChanging();
					_Status = value;
					SendPropertyChanged("Status");
					OnStatusChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
    partial void OnValidate(ChangeAction action);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_TagID", DbType="BigInt NOT NULL")]
		public long TagID
		{
			get
			{
				return _TagID;
			}
			set
			{
				if ((_TagID != value))
				{
					OnTagIDChanging(value);
					SendPropertyChanging();
					_TagID = value;
					SendPropertyChanged("TagID");
					OnTagIDChanged();
				}
			}
		}
		
		[Column(Storage="_LogID", DbType="BigInt NOT NULL")]
		public long LogID
		{
			get
			{
				return _LogID;
			}
			set
			{
				if ((_LogID != value))
				{
					OnLogIDChanging(value);
					SendPropertyChanging();
					_LogID = value;
					SendPropertyChanged("LogID");
					OnLogIDChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
		
		private DateTime _SendTime;
		
		private bool _IsSee;
		
		private bool _IsFromDel;
		
		private bool _IsToDel;
		
		private bool _IsHtml;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
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
    partial void OnSendTimeChanging(DateTime value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_FromID", DbType="BigInt NOT NULL")]
		public long FromID
		{
			get
			{
				return _FromID;
			}
			set
			{
				if ((_FromID != value))
				{
					OnFromIDChanging(value);
					SendPropertyChanging();
					_FromID = value;
					SendPropertyChanged("FromID");
					OnFromIDChanged();
				}
			}
		}
		
		[Column(Storage="_ToID", DbType="BigInt NOT NULL")]
		public long ToID
		{
			get
			{
				return _ToID;
			}
			set
			{
				if ((_ToID != value))
				{
					OnToIDChanging(value);
					SendPropertyChanging();
					_ToID = value;
					SendPropertyChanged("ToID");
					OnToIDChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				if ((_Title != value))
				{
					OnTitleChanging(value);
					SendPropertyChanging();
					_Title = value;
					SendPropertyChanged("Title");
					OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_Body", DbType="NVarChar(4000) NOT NULL", CanBeNull=false)]
		public string Body
		{
			get
			{
				return _Body;
			}
			set
			{
				if ((_Body != value))
				{
					OnBodyChanging(value);
					SendPropertyChanging();
					_Body = value;
					SendPropertyChanged("Body");
					OnBodyChanged();
				}
			}
		}
		
		[Column(Storage="_SendTime", DbType="SmallDateTime NOT NULL")]
		public DateTime SendTime
		{
			get
			{
				return _SendTime;
			}
			set
			{
				if ((_SendTime != value))
				{
					OnSendTimeChanging(value);
					SendPropertyChanging();
					_SendTime = value;
					SendPropertyChanged("SendTime");
					OnSendTimeChanged();
				}
			}
		}
		
		[Column(Storage="_IsSee", DbType="Bit NOT NULL")]
		public bool IsSee
		{
			get
			{
				return _IsSee;
			}
			set
			{
				if ((_IsSee != value))
				{
					OnIsSeeChanging(value);
					SendPropertyChanging();
					_IsSee = value;
					SendPropertyChanged("IsSee");
					OnIsSeeChanged();
				}
			}
		}
		
		[Column(Storage="_IsFromDel", DbType="Bit NOT NULL")]
		public bool IsFromDel
		{
			get
			{
				return _IsFromDel;
			}
			set
			{
				if ((_IsFromDel != value))
				{
					OnIsFromDelChanging(value);
					SendPropertyChanging();
					_IsFromDel = value;
					SendPropertyChanged("IsFromDel");
					OnIsFromDelChanged();
				}
			}
		}
		
		[Column(Storage="_IsToDel", DbType="Bit NOT NULL")]
		public bool IsToDel
		{
			get
			{
				return _IsToDel;
			}
			set
			{
				if ((_IsToDel != value))
				{
					OnIsToDelChanging(value);
					SendPropertyChanging();
					_IsToDel = value;
					SendPropertyChanged("IsToDel");
					OnIsToDelChanged();
				}
			}
		}
		
		[Column(Storage="_IsHtml", DbType="Bit NOT NULL")]
		public bool IsHtml
		{
			get
			{
				return _IsHtml;
			}
			set
			{
				if ((_IsHtml != value))
				{
					OnIsHtmlChanging(value);
					SendPropertyChanging();
					_IsHtml = value;
					SendPropertyChanged("IsHtml");
					OnIsHtmlChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
		
		private DateTime _AddTime;
		
		private DateTime _EditTime;
		
		private byte _Type;
		
		private long _PID;
		
		private long _UserID;
		
		private byte _IsTellMe;
		
		private  bool? _IsAnonymous;
		
		private byte _ShowLevel;
		
		private long _ViewCount;
		
		private long _PushCount;
		
		private long _TrackBackCount;
		
		private long _CommentCount;
		
		private long _LastCommentUserID;
		
		private DateTime _LastCommentTime;
		
		private string _Ext;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnSummaryChanging(string value);
    partial void OnSummaryChanged();
    partial void OnBodyChanging(string value);
    partial void OnBodyChanged();
    partial void OnAddTimeChanging(DateTime value);
    partial void OnAddTimeChanged();
    partial void OnEditTimeChanging(DateTime value);
    partial void OnEditTimeChanged();
    partial void OnTypeChanging(byte value);
    partial void OnTypeChanged();
    partial void OnPIDChanging(long value);
    partial void OnPIDChanged();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnIsTellMeChanging(byte value);
    partial void OnIsTellMeChanged();
    partial void OnIsAnonymousChanging(bool? value);
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
    partial void OnLastCommentTimeChanging(DateTime value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				if ((_Title != value))
				{
					OnTitleChanging(value);
					SendPropertyChanging();
					_Title = value;
					SendPropertyChanged("Title");
					OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_Summary", DbType="NVarChar(4000)")]
		public string Summary
		{
			get
			{
				return _Summary;
			}
			set
			{
				if ((_Summary != value))
				{
					OnSummaryChanging(value);
					SendPropertyChanging();
					_Summary = value;
					SendPropertyChanged("Summary");
					OnSummaryChanged();
				}
			}
		}
		
		[Column(Storage="_Body", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Body
		{
			get
			{
				return _Body;
			}
			set
			{
				if ((_Body != value))
				{
					OnBodyChanging(value);
					SendPropertyChanging();
					_Body = value;
					SendPropertyChanged("Body");
					OnBodyChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public DateTime AddTime
		{
			get
			{
				return _AddTime;
			}
			set
			{
				if ((_AddTime != value))
				{
					OnAddTimeChanging(value);
					SendPropertyChanging();
					_AddTime = value;
					SendPropertyChanged("AddTime");
					OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_EditTime", DbType="SmallDateTime NOT NULL")]
		public DateTime EditTime
		{
			get
			{
				return _EditTime;
			}
			set
			{
				if ((_EditTime != value))
				{
					OnEditTimeChanging(value);
					SendPropertyChanging();
					_EditTime = value;
					SendPropertyChanged("EditTime");
					OnEditTimeChanged();
				}
			}
		}
		
		[Column(Storage="_Type", DbType="TinyInt NOT NULL")]
		public byte Type
		{
			get
			{
				return _Type;
			}
			set
			{
				if ((_Type != value))
				{
					OnTypeChanging(value);
					SendPropertyChanging();
					_Type = value;
					SendPropertyChanged("Type");
					OnTypeChanged();
				}
			}
		}
		
		[Column(Storage="_PID", DbType="BigInt NOT NULL")]
		public long PID
		{
			get
			{
				return _PID;
			}
			set
			{
				if ((_PID != value))
				{
					OnPIDChanging(value);
					SendPropertyChanging();
					_PID = value;
					SendPropertyChanged("PID");
					OnPIDChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_IsTellMe", DbType="TinyInt NOT NULL")]
		public byte IsTellMe
		{
			get
			{
				return _IsTellMe;
			}
			set
			{
				if ((_IsTellMe != value))
				{
					OnIsTellMeChanging(value);
					SendPropertyChanging();
					_IsTellMe = value;
					SendPropertyChanged("IsTellMe");
					OnIsTellMeChanged();
				}
			}
		}
		
		[Column(Storage="_IsAnonymous", DbType="Bit")]
		public System.Nullable<bool> IsAnonymous
		{
			get
			{
				return _IsAnonymous;
			}
			set
			{
				if ((_IsAnonymous != value))
				{
					OnIsAnonymousChanging(value);
					SendPropertyChanging();
					_IsAnonymous = value;
					SendPropertyChanged("IsAnonymous");
					OnIsAnonymousChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="TinyInt NOT NULL")]
		public byte ShowLevel
		{
			get
			{
				return _ShowLevel;
			}
			set
			{
				if ((_ShowLevel != value))
				{
					OnShowLevelChanging(value);
					SendPropertyChanging();
					_ShowLevel = value;
					SendPropertyChanged("ShowLevel");
					OnShowLevelChanged();
				}
			}
		}
		
		[Column(Storage="_ViewCount", DbType="BigInt NOT NULL")]
		public long ViewCount
		{
			get
			{
				return _ViewCount;
			}
			set
			{
				if ((_ViewCount != value))
				{
					OnViewCountChanging(value);
					SendPropertyChanging();
					_ViewCount = value;
					SendPropertyChanged("ViewCount");
					OnViewCountChanged();
				}
			}
		}
		
		[Column(Storage="_PushCount", DbType="BigInt NOT NULL")]
		public long PushCount
		{
			get
			{
				return _PushCount;
			}
			set
			{
				if ((_PushCount != value))
				{
					OnPushCountChanging(value);
					SendPropertyChanging();
					_PushCount = value;
					SendPropertyChanged("PushCount");
					OnPushCountChanged();
				}
			}
		}
		
		[Column(Storage="_TrackBackCount", DbType="BigInt NOT NULL")]
		public long TrackBackCount
		{
			get
			{
				return _TrackBackCount;
			}
			set
			{
				if ((_TrackBackCount != value))
				{
					OnTrackBackCountChanging(value);
					SendPropertyChanging();
					_TrackBackCount = value;
					SendPropertyChanged("TrackBackCount");
					OnTrackBackCountChanged();
				}
			}
		}
		
		[Column(Storage="_CommentCount", DbType="BigInt NOT NULL")]
		public long CommentCount
		{
			get
			{
				return _CommentCount;
			}
			set
			{
				if ((_CommentCount != value))
				{
					OnCommentCountChanging(value);
					SendPropertyChanging();
					_CommentCount = value;
					SendPropertyChanged("CommentCount");
					OnCommentCountChanged();
				}
			}
		}
		
		[Column(Storage="_LastCommentUserID", DbType="BigInt NOT NULL")]
		public long LastCommentUserID
		{
			get
			{
				return _LastCommentUserID;
			}
			set
			{
				if ((_LastCommentUserID != value))
				{
					OnLastCommentUserIDChanging(value);
					SendPropertyChanging();
					_LastCommentUserID = value;
					SendPropertyChanged("LastCommentUserID");
					OnLastCommentUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_LastCommentTime", DbType="SmallDateTime NOT NULL")]
		public DateTime LastCommentTime
		{
			get
			{
				return _LastCommentTime;
			}
			set
			{
				if ((_LastCommentTime != value))
				{
					OnLastCommentTimeChanging(value);
					SendPropertyChanging();
					_LastCommentTime = value;
					SendPropertyChanged("LastCommentTime");
					OnLastCommentTimeChanged();
				}
			}
		}
		
		[Column(Storage="_Ext", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Ext
		{
			get
			{
				return _Ext;
			}
			set
			{
				if ((_Ext != value))
				{
					OnExtChanging(value);
					SendPropertyChanging();
					_Ext = value;
					SendPropertyChanged("Ext");
					OnExtChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
    partial void OnValidate(ChangeAction action);
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
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_LoveLike", DbType="NVarChar(255)")]
		public string LoveLike
		{
			get
			{
				return _LoveLike;
			}
			set
			{
				if ((_LoveLike != value))
				{
					OnLoveLikeChanging(value);
					SendPropertyChanging();
					_LoveLike = value;
					SendPropertyChanged("LoveLike");
					OnLoveLikeChanged();
				}
			}
		}
		
		[Column(Storage="_LoveBook", DbType="NVarChar(255)")]
		public string LoveBook
		{
			get
			{
				return _LoveBook;
			}
			set
			{
				if ((_LoveBook != value))
				{
					OnLoveBookChanging(value);
					SendPropertyChanging();
					_LoveBook = value;
					SendPropertyChanged("LoveBook");
					OnLoveBookChanged();
				}
			}
		}
		
		[Column(Storage="_LoveMusic", DbType="NVarChar(255)")]
		public string LoveMusic
		{
			get
			{
				return _LoveMusic;
			}
			set
			{
				if ((_LoveMusic != value))
				{
					OnLoveMusicChanging(value);
					SendPropertyChanging();
					_LoveMusic = value;
					SendPropertyChanged("LoveMusic");
					OnLoveMusicChanged();
				}
			}
		}
		
		[Column(Storage="_LoveMovie", DbType="NVarChar(255)")]
		public string LoveMovie
		{
			get
			{
				return _LoveMovie;
			}
			set
			{
				if ((_LoveMovie != value))
				{
					OnLoveMovieChanging(value);
					SendPropertyChanging();
					_LoveMovie = value;
					SendPropertyChanged("LoveMovie");
					OnLoveMovieChanged();
				}
			}
		}
		
		[Column(Storage="_LoveSports", DbType="NVarChar(255)")]
		public string LoveSports
		{
			get
			{
				return _LoveSports;
			}
			set
			{
				if ((_LoveSports != value))
				{
					OnLoveSportsChanging(value);
					SendPropertyChanging();
					_LoveSports = value;
					SendPropertyChanged("LoveSports");
					OnLoveSportsChanged();
				}
			}
		}
		
		[Column(Storage="_LoveGame", DbType="NVarChar(255)")]
		public string LoveGame
		{
			get
			{
				return _LoveGame;
			}
			set
			{
				if ((_LoveGame != value))
				{
					OnLoveGameChanging(value);
					SendPropertyChanging();
					_LoveGame = value;
					SendPropertyChanged("LoveGame");
					OnLoveGameChanged();
				}
			}
		}
		
		[Column(Storage="_LoveComic", DbType="NVarChar(255)")]
		public string LoveComic
		{
			get
			{
				return _LoveComic;
			}
			set
			{
				if ((_LoveComic != value))
				{
					OnLoveComicChanging(value);
					SendPropertyChanging();
					_LoveComic = value;
					SendPropertyChanged("LoveComic");
					OnLoveComicChanged();
				}
			}
		}
		
		[Column(Storage="_JoinSociety", DbType="NVarChar(255)")]
		public string JoinSociety
		{
			get
			{
				return _JoinSociety;
			}
			set
			{
				if ((_JoinSociety != value))
				{
					OnJoinSocietyChanging(value);
					SendPropertyChanging();
					_JoinSociety = value;
					SendPropertyChanged("JoinSociety");
					OnJoinSocietyChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Photo")]
    internal partial class Photo : INotifyPropertyChanging, INotifyPropertyChanged, IPhoto
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _ID;
		
		private string _Name;
		
		private long? _AlbumID;
		
		private long _UserID;
		
		private DateTime _AddTime;
		
		private long _Order;
		
		private string _Ext;
		
		private int _Status;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnAlbumIDChanging(System.Nullable<long> value);
    partial void OnAlbumIDChanged();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnAddTimeChanging(DateTime value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				if ((_Name != value))
				{
					OnNameChanging(value);
					SendPropertyChanging();
					_Name = value;
					SendPropertyChanged("Name");
					OnNameChanged();
				}
			}
		}
		
		[Column(Storage="_AlbumID", DbType="BigInt")]
		public System.Nullable<long> AlbumID
		{
			get
			{
				return _AlbumID;
			}
			set
			{
				if ((_AlbumID != value))
				{
					OnAlbumIDChanging(value);
					SendPropertyChanging();
					_AlbumID = value;
					SendPropertyChanged("AlbumID");
					OnAlbumIDChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="DateTime NOT NULL")]
		public DateTime AddTime
		{
			get
			{
				return _AddTime;
			}
			set
			{
				if ((_AddTime != value))
				{
					OnAddTimeChanging(value);
					SendPropertyChanging();
					_AddTime = value;
					SendPropertyChanged("AddTime");
					OnAddTimeChanged();
				}
			}
		}
		
		[Column(Name="[Order]", Storage="_Order", DbType="BigInt NOT NULL")]
		public long Order
		{
			get
			{
				return _Order;
			}
			set
			{
				if ((_Order != value))
				{
					OnOrderChanging(value);
					SendPropertyChanging();
					_Order = value;
					SendPropertyChanged("Order");
					OnOrderChanged();
				}
			}
		}
		
		[Column(Storage="_Ext", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Ext
		{
			get
			{
				return _Ext;
			}
			set
			{
				if ((_Ext != value))
				{
					OnExtChanging(value);
					SendPropertyChanging();
					_Ext = value;
					SendPropertyChanged("Ext");
					OnExtChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
		{
			get
			{
				return _Status;
			}
			set
			{
				if ((_Status != value))
				{
					OnStatusChanging(value);
					SendPropertyChanging();
					_Status = value;
					SendPropertyChanged("Status");
					OnStatusChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[Table(Name="dbo.Profile")]
    internal partial class Profile : INotifyPropertyChanging, INotifyPropertyChanged, IProfile
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _UserID;

	    private string _Face;
		private string _Name;
		
		private int _Status;
		
		private long _Score;
		
		private long _ShowScore;
		
		private long _DelScore;
		
		private byte _ShowLevel;
		
		private string _MagicBox;
		
		private bool _IsMagicBox;
		
		private DateTime _RegTime;
		
		private DateTime _LoginTime;
		
		private long _ViewCount;
		
		private long _FileSizeAll;
		
		private long _FileSizeCount;
		
		private string _Applications;
		
		private string _Applicationlist;
		
		private string _Ext;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
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
    partial void OnRegTimeChanging(DateTime value);
    partial void OnRegTimeChanged();
    partial void OnLoginTimeChanging(DateTime value);
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

        [Column(Storage = "_UserID", DbType = "BigInt NOT NULL", IsPrimaryKey = true)]
        public long UserID {
            get {
                return _UserID;
            }
            set {
                if ((_UserID == value)) return;
                OnUserIDChanging(value);
                SendPropertyChanging();
                _UserID = value;
                SendPropertyChanged("UserID");
                OnUserIDChanged();
            }
        }

        [Column(Storage = "_Name", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string Name {
            get {
                return _Name;
            }
            set {
                if (_Name == value) return;
                OnNameChanging(value);
                SendPropertyChanging();
                _Name = value;
                SendPropertyChanged("Name");
                OnNameChanged();
            }
        }
        [Column(Storage = "_Face", DbType = "NVarChar(300) NULL", UpdateCheck = UpdateCheck.Never)]
        public string Face {
            get {
                return _Face;
            }
            set {
                if (_Face == value) return;
                OnNameChanging(value);
                SendPropertyChanging();
                _Face = value;
                SendPropertyChanged("Face");
                OnNameChanged();
            }
        }
		[Column(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
		{
			get
			{
				return _Status;
			}
			set
			{
			    if ((_Status == value)) return;
			    OnStatusChanging(value);
			    SendPropertyChanging();
			    _Status = value;
			    SendPropertyChanged("Status");
			    OnStatusChanged();
			}
		}
		
		[Column(Storage="_Score", DbType="BigInt NOT NULL")]
		public long Score
		{
			get
			{
				return _Score;
			}
			set
			{
				if ((_Score != value))
				{
					OnScoreChanging(value);
					SendPropertyChanging();
					_Score = value;
					SendPropertyChanged("Score");
					OnScoreChanged();
				}
			}
		}
		
		[Column(Storage="_ShowScore", DbType="BigInt NOT NULL")]
		public long ShowScore
		{
			get
			{
				return _ShowScore;
			}
			set
			{
				if ((_ShowScore != value))
				{
					OnShowScoreChanging(value);
					SendPropertyChanging();
					_ShowScore = value;
					SendPropertyChanged("ShowScore");
					OnShowScoreChanged();
				}
			}
		}
		
		[Column(Storage="_DelScore", DbType="BigInt NOT NULL")]
		public long DelScore
		{
			get
			{
				return _DelScore;
			}
			set
			{
				if ((_DelScore != value))
				{
					OnDelScoreChanging(value);
					SendPropertyChanging();
					_DelScore = value;
					SendPropertyChanged("DelScore");
					OnDelScoreChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="TinyInt NOT NULL")]
		public byte ShowLevel
		{
			get
			{
				return _ShowLevel;
			}
			set
			{
				if ((_ShowLevel != value))
				{
					OnShowLevelChanging(value);
					SendPropertyChanging();
					_ShowLevel = value;
					SendPropertyChanged("ShowLevel");
					OnShowLevelChanged();
				}
			}
		}
		
		[Column(Storage="_MagicBox", DbType="NText NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string MagicBox
		{
			get
			{
				return _MagicBox;
			}
			set
			{
				if ((_MagicBox != value))
				{
					OnMagicBoxChanging(value);
					SendPropertyChanging();
					_MagicBox = value;
					SendPropertyChanged("MagicBox");
					OnMagicBoxChanged();
				}
			}
		}
		
		[Column(Storage="_IsMagicBox", DbType="Bit NOT NULL")]
		public bool IsMagicBox
		{
			get
			{
				return _IsMagicBox;
			}
			set
			{
				if ((_IsMagicBox != value))
				{
					OnIsMagicBoxChanging(value);
					SendPropertyChanging();
					_IsMagicBox = value;
					SendPropertyChanged("IsMagicBox");
					OnIsMagicBoxChanged();
				}
			}
		}
		
		[Column(Storage="_RegTime", DbType="SmallDateTime NOT NULL")]
		public DateTime RegTime
		{
			get
			{
				return _RegTime;
			}
			set
			{
				if ((_RegTime != value))
				{
					OnRegTimeChanging(value);
					SendPropertyChanging();
					_RegTime = value;
					SendPropertyChanged("RegTime");
					OnRegTimeChanged();
				}
			}
		}
		
		[Column(Storage="_LoginTime", DbType="SmallDateTime NOT NULL")]
		public DateTime LoginTime
		{
			get
			{
				return _LoginTime;
			}
			set
			{
				if ((_LoginTime != value))
				{
					OnLoginTimeChanging(value);
					SendPropertyChanging();
					_LoginTime = value;
					SendPropertyChanged("LoginTime");
					OnLoginTimeChanged();
				}
			}
		}
		
		[Column(Storage="_ViewCount", DbType="BigInt NOT NULL")]
		public long ViewCount
		{
			get
			{
				return _ViewCount;
			}
			set
			{
				if ((_ViewCount != value))
				{
					OnViewCountChanging(value);
					SendPropertyChanging();
					_ViewCount = value;
					SendPropertyChanged("ViewCount");
					OnViewCountChanged();
				}
			}
		}
		
		[Column(Storage="_FileSizeAll", DbType="BigInt NOT NULL")]
		public long FileSizeAll
		{
			get
			{
				return _FileSizeAll;
			}
			set
			{
				if ((_FileSizeAll != value))
				{
					OnFileSizeAllChanging(value);
					SendPropertyChanging();
					_FileSizeAll = value;
					SendPropertyChanged("FileSizeAll");
					OnFileSizeAllChanged();
				}
			}
		}
		
		[Column(Storage="_FileSizeCount", DbType="BigInt NOT NULL")]
		public long FileSizeCount
		{
			get
			{
				return _FileSizeCount;
			}
			set
			{
				if ((_FileSizeCount != value))
				{
					OnFileSizeCountChanging(value);
					SendPropertyChanging();
					_FileSizeCount = value;
					SendPropertyChanged("FileSizeCount");
					OnFileSizeCountChanged();
				}
			}
		}
		
		[Column(Storage="_Applications", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Applications
		{
			get
			{
				return _Applications;
			}
			set
			{
				if ((_Applications != value))
				{
					OnApplicationsChanging(value);
					SendPropertyChanging();
					_Applications = value;
					SendPropertyChanged("Applications");
					OnApplicationsChanged();
				}
			}
		}
		
		[Column(Storage="_Applicationlist", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Applicationlist
		{
			get
			{
				return _Applicationlist;
			}
			set
			{
				if ((_Applicationlist != value))
				{
					OnApplicationlistChanging(value);
					SendPropertyChanging();
					_Applicationlist = value;
					SendPropertyChanged("Applicationlist");
					OnApplicationlistChanged();
				}
			}
		}
		
		[Column(Storage="_Ext", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Ext
		{
			get
			{
				return _Ext;
			}
			set
			{
			    if ((_Ext == value)) return;
			    OnExtChanging(value);
			    SendPropertyChanging();
			    _Ext = value;
			    SendPropertyChanged("Ext");
			    OnExtChanged();
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
		
		private DateTime _AddTime;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnLogIDChanging(long value);
    partial void OnLogIDChanged();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnAddTimeChanging(DateTime value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_LogID", DbType="BigInt NOT NULL")]
		public long LogID
		{
			get
			{
				return _LogID;
			}
			set
			{
				if ((_LogID != value))
				{
					OnLogIDChanging(value);
					SendPropertyChanging();
					_LogID = value;
					SendPropertyChanged("LogID");
					OnLogIDChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public DateTime AddTime
		{
			get
			{
				return _AddTime;
			}
			set
			{
				if ((_AddTime != value))
				{
					OnAddTimeChanging(value);
					SendPropertyChanging();
					_AddTime = value;
					SendPropertyChanged("AddTime");
					OnAddTimeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
		
		private DateTime _AddTime;
		
		private bool _IsSee;
		
		private bool _IsDel;
		
		private byte _IsTellMe;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnUserIDChanging(long value);
    partial void OnUserIDChanged();
    partial void OnSenderIDChanging(long value);
    partial void OnSenderIDChanged();
    partial void OnBodyChanging(string value);
    partial void OnBodyChanged();
    partial void OnAddTimeChanging(DateTime value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_SenderID", DbType="BigInt NOT NULL")]
		public long SenderID
		{
			get
			{
				return _SenderID;
			}
			set
			{
				if ((_SenderID != value))
				{
					OnSenderIDChanging(value);
					SendPropertyChanging();
					_SenderID = value;
					SendPropertyChanged("SenderID");
					OnSenderIDChanged();
				}
			}
		}
		
		[Column(Storage="_Body", DbType="NVarChar(4000) NOT NULL", CanBeNull=false)]
		public string Body
		{
			get
			{
				return _Body;
			}
			set
			{
				if ((_Body != value))
				{
					OnBodyChanging(value);
					SendPropertyChanging();
					_Body = value;
					SendPropertyChanged("Body");
					OnBodyChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public DateTime AddTime
		{
			get
			{
				return _AddTime;
			}
			set
			{
				if ((_AddTime != value))
				{
					OnAddTimeChanging(value);
					SendPropertyChanging();
					_AddTime = value;
					SendPropertyChanged("AddTime");
					OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_IsSee", DbType="Bit NOT NULL")]
		public bool IsSee
		{
			get
			{
				return _IsSee;
			}
			set
			{
				if ((_IsSee != value))
				{
					OnIsSeeChanging(value);
					SendPropertyChanging();
					_IsSee = value;
					SendPropertyChanged("IsSee");
					OnIsSeeChanged();
				}
			}
		}
		
		[Column(Storage="_IsDel", DbType="Bit NOT NULL")]
		public bool IsDel
		{
			get
			{
				return _IsDel;
			}
			set
			{
				if ((_IsDel != value))
				{
					OnIsDelChanging(value);
					SendPropertyChanging();
					_IsDel = value;
					SendPropertyChanged("IsDel");
					OnIsDelChanged();
				}
			}
		}
		
		[Column(Storage="_IsTellMe", DbType="TinyInt NOT NULL")]
		public byte IsTellMe
		{
			get
			{
				return _IsTellMe;
			}
			set
			{
				if ((_IsTellMe != value))
				{
					OnIsTellMeChanging(value);
					SendPropertyChanging();
					_IsTellMe = value;
					SendPropertyChanged("IsTellMe");
					OnIsTellMeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
		
		private DateTime _SendTime;
		
		private DateTime _AnswerTime;
		
		private long _UserID;
		
		private string _Email;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(long value);
    partial void OnIDChanged();
    partial void OnBodyChanging(string value);
    partial void OnBodyChanged();
    partial void OnAnswerChanging(string value);
    partial void OnAnswerChanged();
    partial void OnStatusChanging(byte value);
    partial void OnStatusChanged();
    partial void OnSendTimeChanging(DateTime value);
    partial void OnSendTimeChanged();
    partial void OnAnswerTimeChanging(DateTime value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Body", DbType="NVarChar(4000) NOT NULL", CanBeNull=false)]
		public string Body
		{
			get
			{
				return _Body;
			}
			set
			{
				if ((_Body != value))
				{
					OnBodyChanging(value);
					SendPropertyChanging();
					_Body = value;
					SendPropertyChanged("Body");
					OnBodyChanged();
				}
			}
		}
		
		[Column(Storage="_Answer", DbType="NVarChar(4000) NOT NULL", CanBeNull=false)]
		public string Answer
		{
			get
			{
				return _Answer;
			}
			set
			{
				if ((_Answer != value))
				{
					OnAnswerChanging(value);
					SendPropertyChanging();
					_Answer = value;
					SendPropertyChanged("Answer");
					OnAnswerChanged();
				}
			}
		}
		
		[Column(Storage="_Status", DbType="TinyInt NOT NULL")]
		public byte Status
		{
			get
			{
				return _Status;
			}
			set
			{
				if ((_Status != value))
				{
					OnStatusChanging(value);
					SendPropertyChanging();
					_Status = value;
					SendPropertyChanged("Status");
					OnStatusChanged();
				}
			}
		}
		
		[Column(Storage="_SendTime", DbType="SmallDateTime NOT NULL")]
		public DateTime SendTime
		{
			get
			{
				return _SendTime;
			}
			set
			{
				if ((_SendTime != value))
				{
					OnSendTimeChanging(value);
					SendPropertyChanging();
					_SendTime = value;
					SendPropertyChanged("SendTime");
					OnSendTimeChanged();
				}
			}
		}
		
		[Column(Storage="_AnswerTime", DbType="SmallDateTime NOT NULL")]
		public DateTime AnswerTime
		{
			get
			{
				return _AnswerTime;
			}
			set
			{
				if ((_AnswerTime != value))
				{
					OnAnswerTimeChanging(value);
					SendPropertyChanging();
					_AnswerTime = value;
					SendPropertyChanged("AnswerTime");
					OnAnswerTimeChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_Email", DbType="NVarChar(50)")]
		public string Email
		{
			get
			{
				return _Email;
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
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
		
		private DateTime _AddTime;
		
		private byte _ShowLevel;
		
		private System.Nullable<long> _SystemCategory;
		
		private System.Nullable<long> _Category;
		
		private byte _Type;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(ChangeAction action);
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
    partial void OnAddTimeChanging(DateTime value);
    partial void OnAddTimeChanged();
    partial void OnShowLevelChanging(byte value);
    partial void OnShowLevelChanged();
    partial void OnSystemCategoryChanging(long? value);
    partial void OnSystemCategoryChanged();
    partial void OnCategoryChanging(long? value);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(50)")]
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				if ((_Title != value))
				{
					OnTitleChanging(value);
					SendPropertyChanging();
					_Title = value;
					SendPropertyChanged("Title");
					OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_Faceurl", DbType="NVarChar(500)")]
		public string Faceurl
		{
			get
			{
				return _Faceurl;
			}
			set
			{
			    if ((_Faceurl == value)) return;
			    OnFaceurlChanging(value);
			    SendPropertyChanging();
			    _Faceurl = value;
			    SendPropertyChanged("Faceurl");
			    OnFaceurlChanged();
			}
		}
		
		[Column(Storage="_Url", DbType="NVarChar(500) NOT NULL", CanBeNull=false)]
		public string Url
		{
			get
			{
				return _Url;
			}
			set
			{
			    if ((_Url == value)) return;
			    OnUrlChanging(value);
			    SendPropertyChanging();
			    _Url = value;
			    SendPropertyChanged("Url");
			    OnUrlChanged();
			}
		}
		
		[Column(Storage="_Description", DbType="NVarChar(50)")]
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				if ((_Description != value))
				{
					OnDescriptionChanging(value);
					SendPropertyChanging();
					_Description = value;
					SendPropertyChanged("Description");
					OnDescriptionChanged();
				}
			}
		}
		
		[Column(Storage="_UserID", DbType="BigInt NOT NULL")]
		public long UserID
		{
			get
			{
				return _UserID;
			}
			set
			{
				if ((_UserID != value))
				{
					OnUserIDChanging(value);
					SendPropertyChanging();
					_UserID = value;
					SendPropertyChanged("UserID");
					OnUserIDChanged();
				}
			}
		}
		
		[Column(Storage="_ViewCount", DbType="BigInt NOT NULL")]
		public long ViewCount
		{
			get
			{
				return _ViewCount;
			}
			set
			{
				if ((_ViewCount != value))
				{
					OnViewCountChanging(value);
					SendPropertyChanging();
					_ViewCount = value;
					SendPropertyChanged("ViewCount");
					OnViewCountChanged();
				}
			}
		}
		
		[Column(Storage="_AddTime", DbType="SmallDateTime NOT NULL")]
		public DateTime AddTime
		{
			get
			{
				return _AddTime;
			}
			set
			{
				if ((_AddTime != value))
				{
					OnAddTimeChanging(value);
					SendPropertyChanging();
					_AddTime = value;
					SendPropertyChanged("AddTime");
					OnAddTimeChanged();
				}
			}
		}
		
		[Column(Storage="_ShowLevel", DbType="TinyInt NOT NULL")]
		public byte ShowLevel
		{
			get
			{
				return _ShowLevel;
			}
			set
			{
				if ((_ShowLevel != value))
				{
					OnShowLevelChanging(value);
					SendPropertyChanging();
					_ShowLevel = value;
					SendPropertyChanged("ShowLevel");
					OnShowLevelChanged();
				}
			}
		}
		
		[Column(Storage="_SystemCategory", DbType="BigInt")]
		public long? SystemCategory
		{
			get
			{
				return _SystemCategory;
			}
			set
			{
			    if ((_SystemCategory == value)) return;
			    OnSystemCategoryChanging(value);
			    SendPropertyChanging();
			    _SystemCategory = value;
			    SendPropertyChanged("SystemCategory");
			    OnSystemCategoryChanged();
			}
		}
		
		[Column(Storage="_Category", DbType="BigInt")]
		public long? Category
		{
			get
			{
				return _Category;
			}
			set
			{
				if ((_Category != value))
				{
					OnCategoryChanging(value);
					SendPropertyChanging();
					_Category = value;
					SendPropertyChanged("Category");
					OnCategoryChanged();
				}
			}
		}
		
		[Column(Storage="_Type", DbType="TinyInt NOT NULL")]
		public byte Type
		{
			get
			{
				return _Type;
			}
			set
			{
				if ((_Type != value))
				{
					OnTypeChanging(value);
					SendPropertyChanging();
					_Type = value;
					SendPropertyChanged("Type");
					OnTypeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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
    partial void OnValidate(ChangeAction action);
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
				return _ID;
			}
			set
			{
				if ((_ID != value))
				{
					OnIDChanging(value);
					SendPropertyChanging();
					_ID = value;
					SendPropertyChanged("ID");
					OnIDChanged();
				}
			}
		}
		
		[Column(Storage="_Title", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return _Title;
			}
			set
			{
				if ((_Title != value))
				{
					OnTitleChanging(value);
					SendPropertyChanging();
					_Title = value;
					SendPropertyChanged("Title");
					OnTitleChanged();
				}
			}
		}
		
		[Column(Storage="_Count", DbType="BigInt NOT NULL")]
		public long Count
		{
			get
			{
				return _Count;
			}
			set
			{
				if ((_Count != value))
				{
					OnCountChanging(value);
					SendPropertyChanging();
					_Count = value;
					SendPropertyChanged("Count");
					OnCountChanged();
				}
			}
		}
		
		[Column(Storage="_Type", DbType="TinyInt NOT NULL")]
		public byte Type
		{
			get
			{
				return _Type;
			}
			set
			{
				if ((_Type != value))
				{
					OnTypeChanging(value);
					SendPropertyChanging();
					_Type = value;
					SendPropertyChanged("Type");
					OnTypeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((PropertyChanging != null))
			{
				PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((PropertyChanged != null))
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

