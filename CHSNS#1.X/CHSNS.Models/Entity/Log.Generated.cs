
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;

namespace CHSNS.Models
{
    /// <summary>
    /// The class representing the dbo.Log table.
    /// </summary>
    [Table(Name="dbo.Log")]
    public partial class Log
        : LinqEntityBase
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Log"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Log()
        {
            OnCreated();
            _logTagList = new EntitySet<LogTag>(
                new System.Action<LogTag>(this.Attach_LogTagList),
                new System.Action<LogTag>(this.Detach_LogTagList));
            _pushList = new EntitySet<Push>(
                new System.Action<Push>(this.Attach_PushList),
                new System.Action<Push>(this.Detach_PushList));
        }
        #endregion
        
        #region Column Mapped Properties
        
        private long _trueid = default(long);

        /// <summary>
        /// Gets the Trueid column value.
        /// </summary>
        [Column(Name="Trueid", Storage="_trueid", DbType="bigint NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false)]
        public long Trueid
        {
            get { return _trueid; }
            set
            {
                if (_trueid != value)
                {
                    OnTrueidChanging(value);
                    OnPropertyChanging("Trueid");
                    _trueid = value;
                    OnPropertyChanged("Trueid");
                    OnTrueidChanged();
                }
            }
        }
        
        private string _title;

        /// <summary>
        /// Gets or sets the title column value.
        /// </summary>
        [Column(Name="title", Storage="_title", DbType="nvarchar(255) NOT NULL", CanBeNull=false)]
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    OnTitleChanging(value);
                    OnPropertyChanging("Title");
                    _title = value;
                    OnPropertyChanged("Title");
                    OnTitleChanged();
                }
            }
        }
        
        private string _body;

        /// <summary>
        /// Gets or sets the body column value.
        /// </summary>
        [Column(Name="body", Storage="_body", DbType="ntext", UpdateCheck=UpdateCheck.Never)]
        public string Body
        {
            get { return _body; }
            set
            {
                if (_body != value)
                {
                    OnBodyChanging(value);
                    OnPropertyChanging("Body");
                    _body = value;
                    OnPropertyChanged("Body");
                    OnBodyChanged();
                }
            }
        }
        
        private byte _isPost;

        /// <summary>
        /// Gets or sets the IsPost column value.
        /// </summary>
        [Column(Name="IsPost", Storage="_isPost", DbType="tinyint NOT NULL", CanBeNull=false)]
        public byte IsPost
        {
            get { return _isPost; }
            set
            {
                if (_isPost != value)
                {
                    OnIsPostChanging(value);
                    OnPropertyChanging("IsPost");
                    _isPost = value;
                    OnPropertyChanged("IsPost");
                    OnIsPostChanged();
                }
            }
        }
        
        private bool _anonymous;

        /// <summary>
        /// Gets or sets the Anonymous column value.
        /// </summary>
        [Column(Name="Anonymous", Storage="_anonymous", DbType="bit NOT NULL", CanBeNull=false)]
        public bool Anonymous
        {
            get { return _anonymous; }
            set
            {
                if (_anonymous != value)
                {
                    OnAnonymousChanging(value);
                    OnPropertyChanging("Anonymous");
                    _anonymous = value;
                    OnPropertyChanged("Anonymous");
                    OnAnonymousChanged();
                }
            }
        }
        
        private System.DateTime _addTime;

        /// <summary>
        /// Gets or sets the AddTime column value.
        /// </summary>
        [Column(Name="AddTime", Storage="_addTime", DbType="datetime NOT NULL", CanBeNull=false)]
        public System.DateTime AddTime
        {
            get { return _addTime; }
            set
            {
                if (_addTime != value)
                {
                    OnAddTimeChanging(value);
                    OnPropertyChanging("AddTime");
                    _addTime = value;
                    OnPropertyChanged("AddTime");
                    OnAddTimeChanged();
                }
            }
        }
        
        private System.DateTime _editTime;

        /// <summary>
        /// Gets or sets the EditTime column value.
        /// </summary>
        [Column(Name="EditTime", Storage="_editTime", DbType="datetime NOT NULL", CanBeNull=false)]
        public System.DateTime EditTime
        {
            get { return _editTime; }
            set
            {
                if (_editTime != value)
                {
                    OnEditTimeChanging(value);
                    OnPropertyChanging("EditTime");
                    _editTime = value;
                    OnPropertyChanged("EditTime");
                    OnEditTimeChanged();
                }
            }
        }
        
        private long _viewCount;

        /// <summary>
        /// Gets or sets the ViewCount column value.
        /// </summary>
        [Column(Name="ViewCount", Storage="_viewCount", DbType="bigint NOT NULL", CanBeNull=false)]
        public long ViewCount
        {
            get { return _viewCount; }
            set
            {
                if (_viewCount != value)
                {
                    OnViewCountChanging(value);
                    OnPropertyChanging("ViewCount");
                    _viewCount = value;
                    OnPropertyChanged("ViewCount");
                    OnViewCountChanged();
                }
            }
        }
        
        private long _pushCount;

        /// <summary>
        /// Gets or sets the PushCount column value.
        /// </summary>
        [Column(Name="PushCount", Storage="_pushCount", DbType="bigint NOT NULL", CanBeNull=false)]
        public long PushCount
        {
            get { return _pushCount; }
            set
            {
                if (_pushCount != value)
                {
                    OnPushCountChanging(value);
                    OnPropertyChanging("PushCount");
                    _pushCount = value;
                    OnPropertyChanged("PushCount");
                    OnPushCountChanged();
                }
            }
        }
        
        private long _trackBackCount;

        /// <summary>
        /// Gets or sets the TrackBackCount column value.
        /// </summary>
        [Column(Name="TrackBackCount", Storage="_trackBackCount", DbType="bigint NOT NULL", CanBeNull=false)]
        public long TrackBackCount
        {
            get { return _trackBackCount; }
            set
            {
                if (_trackBackCount != value)
                {
                    OnTrackBackCountChanging(value);
                    OnPropertyChanging("TrackBackCount");
                    _trackBackCount = value;
                    OnPropertyChanged("TrackBackCount");
                    OnTrackBackCountChanged();
                }
            }
        }
        
        private long _commentCount;

        /// <summary>
        /// Gets or sets the CommentCount column value.
        /// </summary>
        [Column(Name="CommentCount", Storage="_commentCount", DbType="bigint NOT NULL", CanBeNull=false)]
        public long CommentCount
        {
            get { return _commentCount; }
            set
            {
                if (_commentCount != value)
                {
                    OnCommentCountChanging(value);
                    OnPropertyChanging("CommentCount");
                    _commentCount = value;
                    OnPropertyChanged("CommentCount");
                    OnCommentCountChanged();
                }
            }
        }
        
        private long _groupId;

        /// <summary>
        /// Gets or sets the GroupId column value.
        /// </summary>
        [Column(Name="GroupId", Storage="_groupId", DbType="bigint NOT NULL", CanBeNull=false)]
        public long GroupId
        {
            get { return _groupId; }
            set
            {
                if (_groupId != value)
                {
                    OnGroupIdChanging(value);
                    OnPropertyChanging("GroupId");
                    _groupId = value;
                    OnPropertyChanged("GroupId");
                    OnGroupIdChanged();
                }
            }
        }
        
        private long _lastCommentUserid;

        /// <summary>
        /// Gets or sets the LastCommentUserid column value.
        /// </summary>
        [Column(Name="LastCommentUserid", Storage="_lastCommentUserid", DbType="bigint NOT NULL", CanBeNull=false)]
        public long LastCommentUserid
        {
            get { return _lastCommentUserid; }
            set
            {
                if (_lastCommentUserid != value)
                {
                    OnLastCommentUseridChanging(value);
                    OnPropertyChanging("LastCommentUserid");
                    _lastCommentUserid = value;
                    OnPropertyChanged("LastCommentUserid");
                    OnLastCommentUseridChanged();
                }
            }
        }
        
        private System.DateTime _lastCommentTime;

        /// <summary>
        /// Gets or sets the LastCommentTime column value.
        /// </summary>
        [Column(Name="LastCommentTime", Storage="_lastCommentTime", DbType="datetime NOT NULL", CanBeNull=false)]
        public System.DateTime LastCommentTime
        {
            get { return _lastCommentTime; }
            set
            {
                if (_lastCommentTime != value)
                {
                    OnLastCommentTimeChanging(value);
                    OnPropertyChanging("LastCommentTime");
                    _lastCommentTime = value;
                    OnPropertyChanged("LastCommentTime");
                    OnLastCommentTimeChanged();
                }
            }
        }
        
        private byte _istellme;

        /// <summary>
        /// Gets or sets the istellme column value.
        /// </summary>
        [Column(Name="istellme", Storage="_istellme", DbType="tinyint NOT NULL", CanBeNull=false)]
        public byte Istellme
        {
            get { return _istellme; }
            set
            {
                if (_istellme != value)
                {
                    OnIstellmeChanging(value);
                    OnPropertyChanging("Istellme");
                    _istellme = value;
                    OnPropertyChanged("Istellme");
                    OnIstellmeChanged();
                }
            }
        }
        
        private long _iD;

        /// <summary>
        /// Gets or sets the ID column value.
        /// </summary>
        [Column(Name="ID", Storage="_iD", DbType="bigint NOT NULL", CanBeNull=false)]
        public long ID
        {
            get { return _iD; }
            set
            {
                if (_iD != value)
                {
                    OnIDChanging(value);
                    OnPropertyChanging("ID");
                    _iD = value;
                    OnPropertyChanged("ID");
                    OnIDChanged();
                }
            }
        }
        
        private long _userID;

        /// <summary>
        /// Gets or sets the UserID column value.
        /// </summary>
        [Column(Name="UserID", Storage="_userID", DbType="bigint NOT NULL", CanBeNull=false)]
        public long UserID
        {
            get { return _userID; }
            set
            {
                if (_userID != value)
                {
                    OnUserIDChanging(value);
                    OnPropertyChanging("UserID");
                    _userID = value;
                    OnPropertyChanged("UserID");
                    OnUserIDChanged();
                }
            }
        }
        #endregion
        
        #region Association Mapped Properties
        
        private EntitySet<LogTag> _logTagList;
        
        /// <summary>
        /// Gets or sets the LogTag association.
        /// </summary>
        [Association(Name="FK_LogTag_Log", Storage="_logTagList", ThisKey="ID", OtherKey="LogID")]
        public EntitySet<LogTag> LogTagList
        {
            get { return _logTagList; }
            set { _logTagList.Assign(value); }
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Attach_LogTagList(LogTag entity)
        {
            OnPropertyChanging(null);
            entity.Log = this;
            OnPropertyChanged(null);
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Detach_LogTagList(LogTag entity)
        {
            OnPropertyChanging(null);
            entity.Log = null;
            OnPropertyChanged(null);
        }
        
        private EntitySet<Push> _pushList;
        
        /// <summary>
        /// Gets or sets the Push association.
        /// </summary>
        [Association(Name="FK_Push_Log", Storage="_pushList", ThisKey="ID", OtherKey="Logid")]
        public EntitySet<Push> PushList
        {
            get { return _pushList; }
            set { _pushList.Assign(value); }
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Attach_PushList(Push entity)
        {
            OnPropertyChanging(null);
            entity.Log = this;
            OnPropertyChanged(null);
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Detach_PushList(Push entity)
        {
            OnPropertyChanging(null);
            entity.Log = null;
            OnPropertyChanged(null);
        }
        #endregion
        
        #region Extensibility Method Definitions
        /// <summary>Called when this instance is loaded.</summary>
        partial void OnLoaded();
        /// <summary>Called when this instance is being saved.</summary>
        partial void OnValidate(ChangeAction action);
        /// <summary>Called when this instance is created.</summary>
        partial void OnCreated();
        /// <summary>Called when Trueid is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTrueidChanging(long value);
        /// <summary>Called after Trueid has Changed.</summary>
        partial void OnTrueidChanged();
        /// <summary>Called when Title is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTitleChanging(string value);
        /// <summary>Called after Title has Changed.</summary>
        partial void OnTitleChanged();
        /// <summary>Called when Body is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnBodyChanging(string value);
        /// <summary>Called after Body has Changed.</summary>
        partial void OnBodyChanged();
        /// <summary>Called when IsPost is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIsPostChanging(byte value);
        /// <summary>Called after IsPost has Changed.</summary>
        partial void OnIsPostChanged();
        /// <summary>Called when Anonymous is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnAnonymousChanging(bool value);
        /// <summary>Called after Anonymous has Changed.</summary>
        partial void OnAnonymousChanged();
        /// <summary>Called when AddTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnAddTimeChanging(System.DateTime value);
        /// <summary>Called after AddTime has Changed.</summary>
        partial void OnAddTimeChanged();
        /// <summary>Called when EditTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnEditTimeChanging(System.DateTime value);
        /// <summary>Called after EditTime has Changed.</summary>
        partial void OnEditTimeChanged();
        /// <summary>Called when ViewCount is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnViewCountChanging(long value);
        /// <summary>Called after ViewCount has Changed.</summary>
        partial void OnViewCountChanged();
        /// <summary>Called when PushCount is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnPushCountChanging(long value);
        /// <summary>Called after PushCount has Changed.</summary>
        partial void OnPushCountChanged();
        /// <summary>Called when TrackBackCount is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTrackBackCountChanging(long value);
        /// <summary>Called after TrackBackCount has Changed.</summary>
        partial void OnTrackBackCountChanged();
        /// <summary>Called when CommentCount is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnCommentCountChanging(long value);
        /// <summary>Called after CommentCount has Changed.</summary>
        partial void OnCommentCountChanged();
        /// <summary>Called when GroupId is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGroupIdChanging(long value);
        /// <summary>Called after GroupId has Changed.</summary>
        partial void OnGroupIdChanged();
        /// <summary>Called when LastCommentUserid is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnLastCommentUseridChanging(long value);
        /// <summary>Called after LastCommentUserid has Changed.</summary>
        partial void OnLastCommentUseridChanged();
        /// <summary>Called when LastCommentTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnLastCommentTimeChanging(System.DateTime value);
        /// <summary>Called after LastCommentTime has Changed.</summary>
        partial void OnLastCommentTimeChanged();
        /// <summary>Called when Istellme is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIstellmeChanging(byte value);
        /// <summary>Called after Istellme has Changed.</summary>
        partial void OnIstellmeChanged();
        /// <summary>Called when ID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIDChanging(long value);
        /// <summary>Called after ID has Changed.</summary>
        partial void OnIDChanged();
        /// <summary>Called when UserID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnUserIDChanging(long value);
        /// <summary>Called after UserID has Changed.</summary>
        partial void OnUserIDChanged();
        #endregion
        
    }
}

