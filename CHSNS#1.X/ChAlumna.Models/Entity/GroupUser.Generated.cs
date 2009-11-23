
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
    /// The class representing the dbo.GroupUser table.
    /// </summary>
    [Table(Name="dbo.GroupUser")]
    public partial class GroupUser
        : LinqEntityBase
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupUser"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public GroupUser()
        {
            OnCreated();
            _group = default(EntityRef<Group>);
        }
        #endregion
        
        #region Column Mapped Properties
        
        private long _trueID = default(long);

        /// <summary>
        /// Gets the TrueID column value.
        /// </summary>
        [Column(Name="TrueID", Storage="_trueID", DbType="bigint NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false)]
        public long TrueID
        {
            get { return _trueID; }
            set
            {
                if (_trueID != value)
                {
                    OnTrueIDChanging(value);
                    OnPropertyChanging("TrueID");
                    _trueID = value;
                    OnPropertyChanged("TrueID");
                    OnTrueIDChanged();
                }
            }
        }
        
        private Nullable<long> _iD;

        /// <summary>
        /// Gets or sets the ID column value.
        /// </summary>
        [Column(Name="ID", Storage="_iD", DbType="bigint")]
        public Nullable<long> ID
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
        
        private long _groupID;

        /// <summary>
        /// Gets or sets the GroupID column value.
        /// </summary>
        [Column(Name="GroupID", Storage="_groupID", DbType="bigint NOT NULL", CanBeNull=false)]
        public long GroupID
        {
            get { return _groupID; }
            set
            {
                if (_groupID != value)
                {
                    if (_group.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnGroupIDChanging(value);
                    OnPropertyChanging("GroupID");
                    _groupID = value;
                    OnPropertyChanged("GroupID");
                    OnGroupIDChanged();
                }
            }
        }
        
        private byte _level;

        /// <summary>
        /// Gets or sets the Level column value.
        /// </summary>
        [Column(Name="Level", Storage="_level", DbType="tinyint NOT NULL", CanBeNull=false)]
        public byte Level
        {
            get { return _level; }
            set
            {
                if (_level != value)
                {
                    OnLevelChanging(value);
                    OnPropertyChanging("Level");
                    _level = value;
                    OnPropertyChanged("Level");
                    OnLevelChanged();
                }
            }
        }
        
        private System.DateTime _addTime;

        /// <summary>
        /// Gets or sets the AddTime column value.
        /// </summary>
        [Column(Name="AddTime", Storage="_addTime", DbType="smalldatetime NOT NULL", CanBeNull=false)]
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
        
        private long _logCount;

        /// <summary>
        /// Gets or sets the LogCount column value.
        /// </summary>
        [Column(Name="LogCount", Storage="_logCount", DbType="bigint NOT NULL", CanBeNull=false)]
        public long LogCount
        {
            get { return _logCount; }
            set
            {
                if (_logCount != value)
                {
                    OnLogCountChanging(value);
                    OnPropertyChanging("LogCount");
                    _logCount = value;
                    OnPropertyChanged("LogCount");
                    OnLogCountChanged();
                }
            }
        }
        
        private byte _class;

        /// <summary>
        /// Gets or sets the Class column value.
        /// </summary>
        [Column(Name="Class", Storage="_class", DbType="tinyint NOT NULL", CanBeNull=false)]
        public byte Class
        {
            get { return _class; }
            set
            {
                if (_class != value)
                {
                    OnClassChanging(value);
                    OnPropertyChanging("Class");
                    _class = value;
                    OnPropertyChanged("Class");
                    OnClassChanged();
                }
            }
        }
        
        private bool _isTrue;

        /// <summary>
        /// Gets or sets the IsTrue column value.
        /// </summary>
        [Column(Name="IsTrue", Storage="_isTrue", DbType="bit NOT NULL", CanBeNull=false)]
        public bool IsTrue
        {
            get { return _isTrue; }
            set
            {
                if (_isTrue != value)
                {
                    OnIsTrueChanging(value);
                    OnPropertyChanging("IsTrue");
                    _isTrue = value;
                    OnPropertyChanged("IsTrue");
                    OnIsTrueChanged();
                }
            }
        }
        
        private bool _isRss;

        /// <summary>
        /// Gets or sets the IsRss column value.
        /// </summary>
        [Column(Name="IsRss", Storage="_isRss", DbType="bit NOT NULL", CanBeNull=false)]
        public bool IsRss
        {
            get { return _isRss; }
            set
            {
                if (_isRss != value)
                {
                    OnIsRssChanging(value);
                    OnPropertyChanging("IsRss");
                    _isRss = value;
                    OnPropertyChanged("IsRss");
                    OnIsRssChanged();
                }
            }
        }
        #endregion
        
        #region Association Mapped Properties
        
        private EntityRef<Group> _group;

        /// <summary>
        /// Gets or sets the Group association.
        /// </summary>
        [Association(Name="FK_GroupUser_Group", Storage="_group", ThisKey="GroupID", OtherKey="ID", IsForeignKey=true)]
        public Group Group
        {
            get { return _group.Entity; }
            set
            {
                Group previousValue = _group.Entity;
                if (previousValue != value || _group.HasLoadedOrAssignedValue == false)
                {
                    OnPropertyChanging("Group");
                    if (previousValue != null)
                    {
                        _group.Entity = null;
                        previousValue.GroupUserList.Remove(this);
                    }
                    _group.Entity = value;
                    if (value != null)
                    {
                        value.GroupUserList.Add(this);
                        _groupID = value.ID;
                    }
                    else
                    {
                        _groupID = default(long);
                    }
                    OnPropertyChanged("Group");
                }
            }
        }
        #endregion
        
        #region Extensibility Method Definitions
        /// <summary>Called when this instance is loaded.</summary>
        partial void OnLoaded();
        /// <summary>Called when this instance is being saved.</summary>
        partial void OnValidate(ChangeAction action);
        /// <summary>Called when this instance is created.</summary>
        partial void OnCreated();
        /// <summary>Called when TrueID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTrueIDChanging(long value);
        /// <summary>Called after TrueID has Changed.</summary>
        partial void OnTrueIDChanged();
        /// <summary>Called when ID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIDChanging(Nullable<long> value);
        /// <summary>Called after ID has Changed.</summary>
        partial void OnIDChanged();
        /// <summary>Called when UserID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnUserIDChanging(long value);
        /// <summary>Called after UserID has Changed.</summary>
        partial void OnUserIDChanged();
        /// <summary>Called when GroupID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnGroupIDChanging(long value);
        /// <summary>Called after GroupID has Changed.</summary>
        partial void OnGroupIDChanged();
        /// <summary>Called when Level is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnLevelChanging(byte value);
        /// <summary>Called after Level has Changed.</summary>
        partial void OnLevelChanged();
        /// <summary>Called when AddTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnAddTimeChanging(System.DateTime value);
        /// <summary>Called after AddTime has Changed.</summary>
        partial void OnAddTimeChanged();
        /// <summary>Called when LogCount is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnLogCountChanging(long value);
        /// <summary>Called after LogCount has Changed.</summary>
        partial void OnLogCountChanged();
        /// <summary>Called when Class is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnClassChanging(byte value);
        /// <summary>Called after Class has Changed.</summary>
        partial void OnClassChanged();
        /// <summary>Called when IsTrue is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIsTrueChanging(bool value);
        /// <summary>Called after IsTrue has Changed.</summary>
        partial void OnIsTrueChanged();
        /// <summary>Called when IsRss is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIsRssChanging(bool value);
        /// <summary>Called after IsRss has Changed.</summary>
        partial void OnIsRssChanged();
        #endregion
        
    }
}

