
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
    /// The class representing the dbo.Note table.
    /// </summary>
    [Table(Name="dbo.Note")]
    public partial class Note
        : LinqEntityBase
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Note()
        {
            OnCreated();
            _logLogTagList = new EntitySet<LogTag>(
                new System.Action<LogTag>(this.Attach_LogLogTagList),
                new System.Action<LogTag>(this.Detach_LogLogTagList));
            _logidPushList = new EntitySet<Push>(
                new System.Action<Push>(this.Attach_LogidPushList),
                new System.Action<Push>(this.Detach_LogidPushList));
        }
        #endregion
        
        #region Column Mapped Properties
        
        private long _iD = default(long);

        /// <summary>
        /// Gets the ID column value.
        /// </summary>
        [Column(Name="ID", Storage="_iD", DbType="bigint NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false)]
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
        
        private string _title;

        /// <summary>
        /// Gets or sets the Title column value.
        /// </summary>
        [Column(Name="Title", Storage="_title", DbType="nvarchar(255) NOT NULL", CanBeNull=false)]
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
        /// Gets or sets the Body column value.
        /// </summary>
        [Column(Name="Body", Storage="_body", DbType="ntext NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
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
        
        private Nullable<bool> _anonymous;

        /// <summary>
        /// Gets or sets the Anonymous column value.
        /// </summary>
        [Column(Name="Anonymous", Storage="_anonymous", DbType="bit")]
        public Nullable<bool> Anonymous
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
        
        private long _lastCommentUserID;

        /// <summary>
        /// Gets or sets the LastCommentUserID column value.
        /// </summary>
        [Column(Name="LastCommentUserID", Storage="_lastCommentUserID", DbType="bigint NOT NULL", CanBeNull=false)]
        public long LastCommentUserID
        {
            get { return _lastCommentUserID; }
            set
            {
                if (_lastCommentUserID != value)
                {
                    OnLastCommentUserIDChanging(value);
                    OnPropertyChanging("LastCommentUserID");
                    _lastCommentUserID = value;
                    OnPropertyChanged("LastCommentUserID");
                    OnLastCommentUserIDChanged();
                }
            }
        }
        
        private System.DateTime _lastCommentTime;

        /// <summary>
        /// Gets or sets the LastCommentTime column value.
        /// </summary>
        [Column(Name="LastCommentTime", Storage="_lastCommentTime", DbType="smalldatetime NOT NULL", CanBeNull=false)]
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
        
        private byte _isTellMe;

        /// <summary>
        /// Gets or sets the IsTellMe column value.
        /// </summary>
        [Column(Name="IsTellMe", Storage="_isTellMe", DbType="tinyint NOT NULL", CanBeNull=false)]
        public byte IsTellMe
        {
            get { return _isTellMe; }
            set
            {
                if (_isTellMe != value)
                {
                    OnIsTellMeChanging(value);
                    OnPropertyChanging("IsTellMe");
                    _isTellMe = value;
                    OnPropertyChanged("IsTellMe");
                    OnIsTellMeChanged();
                }
            }
        }
        
        private string _summary;

        /// <summary>
        /// Gets or sets the Summary column value.
        /// </summary>
        [Column(Name="Summary", Storage="_summary", DbType="nvarchar(4000)")]
        public string Summary
        {
            get { return _summary; }
            set
            {
                if (_summary != value)
                {
                    OnSummaryChanging(value);
                    OnPropertyChanging("Summary");
                    _summary = value;
                    OnPropertyChanged("Summary");
                    OnSummaryChanged();
                }
            }
        }
        #endregion
        
        #region Association Mapped Properties
        
        private EntitySet<LogTag> _logLogTagList;
        
        /// <summary>
        /// Gets or sets the LogTag association.
        /// </summary>
        [Association(Name="FK_LogTag_Log", Storage="_logLogTagList", ThisKey="ID", OtherKey="LogID")]
        public EntitySet<LogTag> LogLogTagList
        {
            get { return _logLogTagList; }
            set { _logLogTagList.Assign(value); }
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Attach_LogLogTagList(LogTag entity)
        {
            OnPropertyChanging(null);
            entity.Log = this;
            OnPropertyChanged(null);
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Detach_LogLogTagList(LogTag entity)
        {
            OnPropertyChanging(null);
            entity.Log = null;
            OnPropertyChanged(null);
        }
        
        private EntitySet<Push> _logidPushList;
        
        /// <summary>
        /// Gets or sets the Push association.
        /// </summary>
        [Association(Name="FK_Push_Log", Storage="_logidPushList", ThisKey="ID", OtherKey="Logid")]
        public EntitySet<Push> LogidPushList
        {
            get { return _logidPushList; }
            set { _logidPushList.Assign(value); }
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Attach_LogidPushList(Push entity)
        {
            OnPropertyChanging(null);
            entity.Log = this;
            OnPropertyChanged(null);
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Detach_LogidPushList(Push entity)
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
        partial void OnAnonymousChanging(Nullable<bool> value);
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
        /// <summary>Called when LastCommentUserID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnLastCommentUserIDChanging(long value);
        /// <summary>Called after LastCommentUserID has Changed.</summary>
        partial void OnLastCommentUserIDChanged();
        /// <summary>Called when LastCommentTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnLastCommentTimeChanging(System.DateTime value);
        /// <summary>Called after LastCommentTime has Changed.</summary>
        partial void OnLastCommentTimeChanged();
        /// <summary>Called when IsTellMe is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIsTellMeChanging(byte value);
        /// <summary>Called after IsTellMe has Changed.</summary>
        partial void OnIsTellMeChanged();
        /// <summary>Called when Summary is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnSummaryChanging(string value);
        /// <summary>Called after Summary has Changed.</summary>
        partial void OnSummaryChanged();
        #endregion
        
    }
}

