
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
    /// The class representing the dbo.Tags table.
    /// </summary>
    [Table(Name="dbo.Tags")]
    public partial class Tags
        : LinqEntityBase
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Tags"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Tags()
        {
            OnCreated();
            _tagLogTagList = new EntitySet<LogTag>(
                new System.Action<LogTag>(this.Attach_TagLogTagList),
                new System.Action<LogTag>(this.Detach_TagLogTagList));
        }
        #endregion
        
        #region Column Mapped Properties
        
        private long _id = default(long);

        /// <summary>
        /// Gets the id column value.
        /// </summary>
        [Column(Name="id", Storage="_id", DbType="bigint NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false)]
        public long Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    OnIdChanging(value);
                    OnPropertyChanging("Id");
                    _id = value;
                    OnPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        
        private string _title;

        /// <summary>
        /// Gets or sets the title column value.
        /// </summary>
        [Column(Name="title", Storage="_title", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
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
        
        private long _count;

        /// <summary>
        /// Gets or sets the Count column value.
        /// </summary>
        [Column(Name="Count", Storage="_count", DbType="bigint NOT NULL", CanBeNull=false)]
        public long Count
        {
            get { return _count; }
            set
            {
                if (_count != value)
                {
                    OnCountChanging(value);
                    OnPropertyChanging("Count");
                    _count = value;
                    OnPropertyChanged("Count");
                    OnCountChanged();
                }
            }
        }
        
        private byte _type;

        /// <summary>
        /// Gets or sets the type column value.
        /// </summary>
        [Column(Name="type", Storage="_type", DbType="tinyint NOT NULL", CanBeNull=false)]
        public byte Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    OnTypeChanging(value);
                    OnPropertyChanging("Type");
                    _type = value;
                    OnPropertyChanged("Type");
                    OnTypeChanged();
                }
            }
        }
        #endregion
        
        #region Association Mapped Properties
        
        private EntitySet<LogTag> _tagLogTagList;
        
        /// <summary>
        /// Gets or sets the LogTag association.
        /// </summary>
        [Association(Name="FK_LogTag_Tags", Storage="_tagLogTagList", ThisKey="Id", OtherKey="TagID")]
        public EntitySet<LogTag> TagLogTagList
        {
            get { return _tagLogTagList; }
            set { _tagLogTagList.Assign(value); }
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Attach_TagLogTagList(LogTag entity)
        {
            OnPropertyChanging(null);
            entity.TagTags = this;
            OnPropertyChanged(null);
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Detach_TagLogTagList(LogTag entity)
        {
            OnPropertyChanging(null);
            entity.TagTags = null;
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
        /// <summary>Called when Id is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIdChanging(long value);
        /// <summary>Called after Id has Changed.</summary>
        partial void OnIdChanged();
        /// <summary>Called when Title is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTitleChanging(string value);
        /// <summary>Called after Title has Changed.</summary>
        partial void OnTitleChanged();
        /// <summary>Called when Count is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnCountChanging(long value);
        /// <summary>Called after Count has Changed.</summary>
        partial void OnCountChanged();
        /// <summary>Called when Type is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTypeChanging(byte value);
        /// <summary>Called after Type has Changed.</summary>
        partial void OnTypeChanged();
        #endregion
        
    }
}

