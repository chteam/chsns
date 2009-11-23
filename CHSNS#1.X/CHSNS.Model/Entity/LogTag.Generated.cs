
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
    /// The class representing the dbo.LogTag table.
    /// </summary>
    [Table(Name="dbo.LogTag")]
    public partial class LogTag
        : LinqEntityBase
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="LogTag"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public LogTag()
        {
            OnCreated();
            _log = default(EntityRef<Note>);
            _tagidTags = default(EntityRef<Tags>);
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
        
        private long _tagID;

        /// <summary>
        /// Gets or sets the TagID column value.
        /// </summary>
        [Column(Name="TagID", Storage="_tagID", DbType="bigint NOT NULL", CanBeNull=false)]
        public long TagID
        {
            get { return _tagID; }
            set
            {
                if (_tagID != value)
                {
                    if (_tagidTags.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnTagIDChanging(value);
                    OnPropertyChanging("TagID");
                    _tagID = value;
                    OnPropertyChanged("TagID");
                    OnTagIDChanged();
                }
            }
        }
        
        private long _logID;

        /// <summary>
        /// Gets or sets the LogID column value.
        /// </summary>
        [Column(Name="LogID", Storage="_logID", DbType="bigint NOT NULL", CanBeNull=false)]
        public long LogID
        {
            get { return _logID; }
            set
            {
                if (_logID != value)
                {
                    if (_log.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    OnLogIDChanging(value);
                    OnPropertyChanging("LogID");
                    _logID = value;
                    OnPropertyChanged("LogID");
                    OnLogIDChanged();
                }
            }
        }
        #endregion
        
        #region Association Mapped Properties
        
        private EntityRef<Note> _log;

        /// <summary>
        /// Gets or sets the Note association.
        /// </summary>
        [Association(Name="FK_LogTag_Log", Storage="_log", ThisKey="LogID", OtherKey="ID", IsForeignKey=true)]
        public Note Log
        {
            get { return _log.Entity; }
            set
            {
                Note previousValue = _log.Entity;
                if (previousValue != value || _log.HasLoadedOrAssignedValue == false)
                {
                    OnPropertyChanging("Log");
                    if (previousValue != null)
                    {
                        _log.Entity = null;
                        previousValue.LogLogTagList.Remove(this);
                    }
                    _log.Entity = value;
                    if (value != null)
                    {
                        value.LogLogTagList.Add(this);
                        _logID = value.ID;
                    }
                    else
                    {
                        _logID = default(long);
                    }
                    OnPropertyChanged("Log");
                }
            }
        }
        
        private EntityRef<Tags> _tagidTags;

        /// <summary>
        /// Gets or sets the Tags association.
        /// </summary>
        [Association(Name="FK_LogTag_Tags", Storage="_tagidTags", ThisKey="TagID", OtherKey="Id", IsForeignKey=true)]
        public Tags TagidTags
        {
            get { return _tagidTags.Entity; }
            set
            {
                Tags previousValue = _tagidTags.Entity;
                if (previousValue != value || _tagidTags.HasLoadedOrAssignedValue == false)
                {
                    OnPropertyChanging("TagidTags");
                    if (previousValue != null)
                    {
                        _tagidTags.Entity = null;
                        previousValue.TagidLogTagList.Remove(this);
                    }
                    _tagidTags.Entity = value;
                    if (value != null)
                    {
                        value.TagidLogTagList.Add(this);
                        _tagID = value.Id;
                    }
                    else
                    {
                        _tagID = default(long);
                    }
                    OnPropertyChanged("TagidTags");
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
        /// <summary>Called when ID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIDChanging(long value);
        /// <summary>Called after ID has Changed.</summary>
        partial void OnIDChanged();
        /// <summary>Called when TagID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTagIDChanging(long value);
        /// <summary>Called after TagID has Changed.</summary>
        partial void OnTagIDChanged();
        /// <summary>Called when LogID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnLogIDChanging(long value);
        /// <summary>Called after LogID has Changed.</summary>
        partial void OnLogIDChanged();
        #endregion
        
    }
}

