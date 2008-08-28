
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
    /// The class representing the dbo.Application table.
    /// </summary>
    [Table(Name="dbo.Application")]
    public partial class Application
        : LinqEntityBase
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Application"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Application()
        {
            OnCreated();
        }
        #endregion
        
        #region Column Mapped Properties
        
        private string _fullname;

        /// <summary>
        /// Gets or sets the fullname column value.
        /// </summary>
        [Column(Name="fullname", Storage="_fullname", DbType="nvarchar(60) NOT NULL", CanBeNull=false)]
        public string Fullname
        {
            get { return _fullname; }
            set
            {
                if (_fullname != value)
                {
                    OnFullnameChanging(value);
                    OnPropertyChanging("Fullname");
                    _fullname = value;
                    OnPropertyChanged("Fullname");
                    OnFullnameChanged();
                }
            }
        }
        
        private string _shortname;

        /// <summary>
        /// Gets or sets the shortname column value.
        /// </summary>
        [Column(Name="shortname", Storage="_shortname", DbType="nvarchar(20) NOT NULL", CanBeNull=false)]
        public string Shortname
        {
            get { return _shortname; }
            set
            {
                if (_shortname != value)
                {
                    OnShortnameChanging(value);
                    OnPropertyChanging("Shortname");
                    _shortname = value;
                    OnPropertyChanged("Shortname");
                    OnShortnameChanged();
                }
            }
        }
        
        private string _folder;

        /// <summary>
        /// Gets or sets the Folder column value.
        /// </summary>
        [Column(Name="Folder", Storage="_folder", DbType="nvarchar(250) NOT NULL", CanBeNull=false)]
        public string Folder
        {
            get { return _folder; }
            set
            {
                if (_folder != value)
                {
                    OnFolderChanging(value);
                    OnPropertyChanging("Folder");
                    _folder = value;
                    OnPropertyChanged("Folder");
                    OnFolderChanged();
                }
            }
        }
        
        private string _vision;

        /// <summary>
        /// Gets or sets the Vision column value.
        /// </summary>
        [Column(Name="Vision", Storage="_vision", DbType="nvarchar(20) NOT NULL", CanBeNull=false)]
        public string Vision
        {
            get { return _vision; }
            set
            {
                if (_vision != value)
                {
                    OnVisionChanging(value);
                    OnPropertyChanging("Vision");
                    _vision = value;
                    OnPropertyChanged("Vision");
                    OnVisionChanged();
                }
            }
        }
        
        private string _icon;

        /// <summary>
        /// Gets or sets the icon column value.
        /// </summary>
        [Column(Name="icon", Storage="_icon", DbType="nvarchar(250)")]
        public string Icon
        {
            get { return _icon; }
            set
            {
                if (_icon != value)
                {
                    OnIconChanging(value);
                    OnPropertyChanging("Icon");
                    _icon = value;
                    OnPropertyChanged("Icon");
                    OnIconChanged();
                }
            }
        }
        
        private Nullable<long> _authorid;

        /// <summary>
        /// Gets or sets the Authorid column value.
        /// </summary>
        [Column(Name="Authorid", Storage="_authorid", DbType="bigint")]
        public Nullable<long> Authorid
        {
            get { return _authorid; }
            set
            {
                if (_authorid != value)
                {
                    OnAuthoridChanging(value);
                    OnPropertyChanging("Authorid");
                    _authorid = value;
                    OnPropertyChanged("Authorid");
                    OnAuthoridChanged();
                }
            }
        }
        
        private System.DateTime _addtime;

        /// <summary>
        /// Gets or sets the Addtime column value.
        /// </summary>
        [Column(Name="Addtime", Storage="_addtime", DbType="smalldatetime NOT NULL", CanBeNull=false)]
        public System.DateTime Addtime
        {
            get { return _addtime; }
            set
            {
                if (_addtime != value)
                {
                    OnAddtimeChanging(value);
                    OnPropertyChanging("Addtime");
                    _addtime = value;
                    OnPropertyChanged("Addtime");
                    OnAddtimeChanged();
                }
            }
        }
        
        private System.DateTime _edittime;

        /// <summary>
        /// Gets or sets the Edittime column value.
        /// </summary>
        [Column(Name="Edittime", Storage="_edittime", DbType="smalldatetime NOT NULL", CanBeNull=false)]
        public System.DateTime Edittime
        {
            get { return _edittime; }
            set
            {
                if (_edittime != value)
                {
                    OnEdittimeChanging(value);
                    OnPropertyChanging("Edittime");
                    _edittime = value;
                    OnPropertyChanged("Edittime");
                    OnEdittimeChanged();
                }
            }
        }
        
        private string _description;

        /// <summary>
        /// Gets or sets the Description column value.
        /// </summary>
        [Column(Name="Description", Storage="_description", DbType="ntext NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    OnDescriptionChanging(value);
                    OnPropertyChanging("Description");
                    _description = value;
                    OnPropertyChanged("Description");
                    OnDescriptionChanged();
                }
            }
        }
        
        private bool _isSystem;

        /// <summary>
        /// Gets or sets the isSystem column value.
        /// </summary>
        [Column(Name="isSystem", Storage="_isSystem", DbType="bit NOT NULL", CanBeNull=false)]
        public bool IsSystem
        {
            get { return _isSystem; }
            set
            {
                if (_isSystem != value)
                {
                    OnIsSystemChanging(value);
                    OnPropertyChanging("IsSystem");
                    _isSystem = value;
                    OnPropertyChanged("IsSystem");
                    OnIsSystemChanged();
                }
            }
        }
        
        private bool _isTrue;

        /// <summary>
        /// Gets or sets the isTrue column value.
        /// </summary>
        [Column(Name="isTrue", Storage="_isTrue", DbType="bit NOT NULL", CanBeNull=false)]
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
        
        private string _descriptionUrl;

        /// <summary>
        /// Gets or sets the DescriptionUrl column value.
        /// </summary>
        [Column(Name="DescriptionUrl", Storage="_descriptionUrl", DbType="nvarchar(250)")]
        public string DescriptionUrl
        {
            get { return _descriptionUrl; }
            set
            {
                if (_descriptionUrl != value)
                {
                    OnDescriptionUrlChanging(value);
                    OnPropertyChanging("DescriptionUrl");
                    _descriptionUrl = value;
                    OnPropertyChanged("DescriptionUrl");
                    OnDescriptionUrlChanged();
                }
            }
        }
        
        private long _userCount;

        /// <summary>
        /// Gets or sets the UserCount column value.
        /// </summary>
        [Column(Name="UserCount", Storage="_userCount", DbType="bigint NOT NULL", CanBeNull=false)]
        public long UserCount
        {
            get { return _userCount; }
            set
            {
                if (_userCount != value)
                {
                    OnUserCountChanging(value);
                    OnPropertyChanging("UserCount");
                    _userCount = value;
                    OnPropertyChanged("UserCount");
                    OnUserCountChanged();
                }
            }
        }
        
        private string _iD;

        /// <summary>
        /// Gets or sets the ID column value.
        /// </summary>
        [Column(Name="ID", Storage="_iD", DbType="varchar(50) NOT NULL", IsPrimaryKey=true, CanBeNull=false)]
        public string ID
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
        #endregion
        
        #region Association Mapped Properties
        #endregion
        
        #region Extensibility Method Definitions
        /// <summary>Called when this instance is loaded.</summary>
        partial void OnLoaded();
        /// <summary>Called when this instance is being saved.</summary>
        partial void OnValidate(ChangeAction action);
        /// <summary>Called when this instance is created.</summary>
        partial void OnCreated();
        /// <summary>Called when Fullname is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnFullnameChanging(string value);
        /// <summary>Called after Fullname has Changed.</summary>
        partial void OnFullnameChanged();
        /// <summary>Called when Shortname is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnShortnameChanging(string value);
        /// <summary>Called after Shortname has Changed.</summary>
        partial void OnShortnameChanged();
        /// <summary>Called when Folder is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnFolderChanging(string value);
        /// <summary>Called after Folder has Changed.</summary>
        partial void OnFolderChanged();
        /// <summary>Called when Vision is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnVisionChanging(string value);
        /// <summary>Called after Vision has Changed.</summary>
        partial void OnVisionChanged();
        /// <summary>Called when Icon is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIconChanging(string value);
        /// <summary>Called after Icon has Changed.</summary>
        partial void OnIconChanged();
        /// <summary>Called when Authorid is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnAuthoridChanging(Nullable<long> value);
        /// <summary>Called after Authorid has Changed.</summary>
        partial void OnAuthoridChanged();
        /// <summary>Called when Addtime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnAddtimeChanging(System.DateTime value);
        /// <summary>Called after Addtime has Changed.</summary>
        partial void OnAddtimeChanged();
        /// <summary>Called when Edittime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnEdittimeChanging(System.DateTime value);
        /// <summary>Called after Edittime has Changed.</summary>
        partial void OnEdittimeChanged();
        /// <summary>Called when Description is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnDescriptionChanging(string value);
        /// <summary>Called after Description has Changed.</summary>
        partial void OnDescriptionChanged();
        /// <summary>Called when IsSystem is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIsSystemChanging(bool value);
        /// <summary>Called after IsSystem has Changed.</summary>
        partial void OnIsSystemChanged();
        /// <summary>Called when IsTrue is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIsTrueChanging(bool value);
        /// <summary>Called after IsTrue has Changed.</summary>
        partial void OnIsTrueChanged();
        /// <summary>Called when DescriptionUrl is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnDescriptionUrlChanging(string value);
        /// <summary>Called after DescriptionUrl has Changed.</summary>
        partial void OnDescriptionUrlChanged();
        /// <summary>Called when UserCount is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnUserCountChanging(long value);
        /// <summary>Called after UserCount has Changed.</summary>
        partial void OnUserCountChanged();
        /// <summary>Called when ID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIDChanging(string value);
        /// <summary>Called after ID has Changed.</summary>
        partial void OnIDChanged();
        #endregion
        
    }
}

