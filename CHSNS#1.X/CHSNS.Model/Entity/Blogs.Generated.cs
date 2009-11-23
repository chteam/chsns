
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
    /// The class representing the dbo.Blogs table.
    /// </summary>
    [Table(Name="dbo.Blogs")]
    public partial class Blogs
        : LinqEntityBase
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Blogs"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Blogs()
        {
            OnCreated();
        }
        #endregion
        
        #region Column Mapped Properties
        
        private System.DateTime _createTime;

        /// <summary>
        /// Gets or sets the CreateTime column value.
        /// </summary>
        [Column(Name="CreateTime", Storage="_createTime", DbType="smalldatetime NOT NULL", CanBeNull=false)]
        public System.DateTime CreateTime
        {
            get { return _createTime; }
            set
            {
                if (_createTime != value)
                {
                    OnCreateTimeChanging(value);
                    OnPropertyChanging("CreateTime");
                    _createTime = value;
                    OnPropertyChanged("CreateTime");
                    OnCreateTimeChanged();
                }
            }
        }
        
        private string _title;

        /// <summary>
        /// Gets or sets the Title column value.
        /// </summary>
        [Column(Name="Title", Storage="_title", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
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
        
        private string _subTitle;

        /// <summary>
        /// Gets or sets the SubTitle column value.
        /// </summary>
        [Column(Name="SubTitle", Storage="_subTitle", DbType="nvarchar(500)")]
        public string SubTitle
        {
            get { return _subTitle; }
            set
            {
                if (_subTitle != value)
                {
                    OnSubTitleChanging(value);
                    OnPropertyChanging("SubTitle");
                    _subTitle = value;
                    OnPropertyChanged("SubTitle");
                    OnSubTitleChanged();
                }
            }
        }
        
        private string _publish;

        /// <summary>
        /// Gets or sets the Publish column value.
        /// </summary>
        [Column(Name="Publish", Storage="_publish", DbType="nvarchar(MAX)")]
        public string Publish
        {
            get { return _publish; }
            set
            {
                if (_publish != value)
                {
                    OnPublishChanging(value);
                    OnPropertyChanging("Publish");
                    _publish = value;
                    OnPropertyChanged("Publish");
                    OnPublishChanged();
                }
            }
        }
        
        private string _writeName;

        /// <summary>
        /// Gets or sets the WriteName column value.
        /// </summary>
        [Column(Name="WriteName", Storage="_writeName", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        public string WriteName
        {
            get { return _writeName; }
            set
            {
                if (_writeName != value)
                {
                    OnWriteNameChanging(value);
                    OnPropertyChanging("WriteName");
                    _writeName = value;
                    OnPropertyChanged("WriteName");
                    OnWriteNameChanged();
                }
            }
        }
        
        private string _commentEmail;

        /// <summary>
        /// Gets or sets the CommentEmail column value.
        /// </summary>
        [Column(Name="CommentEmail", Storage="_commentEmail", DbType="nvarchar(50)")]
        public string CommentEmail
        {
            get { return _commentEmail; }
            set
            {
                if (_commentEmail != value)
                {
                    OnCommentEmailChanging(value);
                    OnPropertyChanging("CommentEmail");
                    _commentEmail = value;
                    OnPropertyChanged("CommentEmail");
                    OnCommentEmailChanged();
                }
            }
        }
        
        private string _skin;

        /// <summary>
        /// Gets or sets the Skin column value.
        /// </summary>
        [Column(Name="Skin", Storage="_skin", DbType="nvarchar(50)")]
        public string Skin
        {
            get { return _skin; }
            set
            {
                if (_skin != value)
                {
                    OnSkinChanging(value);
                    OnPropertyChanging("Skin");
                    _skin = value;
                    OnPropertyChanged("Skin");
                    OnSkinChanged();
                }
            }
        }
        
        private string _css;

        /// <summary>
        /// Gets or sets the Css column value.
        /// </summary>
        [Column(Name="Css", Storage="_css", DbType="ntext", UpdateCheck=UpdateCheck.Never)]
        public string Css
        {
            get { return _css; }
            set
            {
                if (_css != value)
                {
                    OnCssChanging(value);
                    OnPropertyChanging("Css");
                    _css = value;
                    OnPropertyChanged("Css");
                    OnCssChanged();
                }
            }
        }
        
        private string _metaKey;

        /// <summary>
        /// Gets or sets the MetaKey column value.
        /// </summary>
        [Column(Name="MetaKey", Storage="_metaKey", DbType="nvarchar(400)")]
        public string MetaKey
        {
            get { return _metaKey; }
            set
            {
                if (_metaKey != value)
                {
                    OnMetaKeyChanging(value);
                    OnPropertyChanging("MetaKey");
                    _metaKey = value;
                    OnPropertyChanged("MetaKey");
                    OnMetaKeyChanged();
                }
            }
        }
        
        private bool _isWebServices;

        /// <summary>
        /// Gets or sets the IsWebServices column value.
        /// </summary>
        [Column(Name="IsWebServices", Storage="_isWebServices", DbType="bit NOT NULL", CanBeNull=false)]
        public bool IsWebServices
        {
            get { return _isWebServices; }
            set
            {
                if (_isWebServices != value)
                {
                    OnIsWebServicesChanging(value);
                    OnPropertyChanging("IsWebServices");
                    _isWebServices = value;
                    OnPropertyChanged("IsWebServices");
                    OnIsWebServicesChanged();
                }
            }
        }
        
        private long _postCount;

        /// <summary>
        /// Gets or sets the PostCount column value.
        /// </summary>
        [Column(Name="PostCount", Storage="_postCount", DbType="bigint NOT NULL", CanBeNull=false)]
        public long PostCount
        {
            get { return _postCount; }
            set
            {
                if (_postCount != value)
                {
                    OnPostCountChanging(value);
                    OnPropertyChanging("PostCount");
                    _postCount = value;
                    OnPropertyChanged("PostCount");
                    OnPostCountChanged();
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
        
        private long _userID;

        /// <summary>
        /// Gets or sets the UserID column value.
        /// </summary>
        [Column(Name="UserID", Storage="_userID", DbType="bigint NOT NULL", IsPrimaryKey=true, CanBeNull=false)]
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
        #endregion
        
        #region Extensibility Method Definitions
        /// <summary>Called when this instance is loaded.</summary>
        partial void OnLoaded();
        /// <summary>Called when this instance is being saved.</summary>
        partial void OnValidate(ChangeAction action);
        /// <summary>Called when this instance is created.</summary>
        partial void OnCreated();
        /// <summary>Called when CreateTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnCreateTimeChanging(System.DateTime value);
        /// <summary>Called after CreateTime has Changed.</summary>
        partial void OnCreateTimeChanged();
        /// <summary>Called when Title is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTitleChanging(string value);
        /// <summary>Called after Title has Changed.</summary>
        partial void OnTitleChanged();
        /// <summary>Called when SubTitle is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnSubTitleChanging(string value);
        /// <summary>Called after SubTitle has Changed.</summary>
        partial void OnSubTitleChanged();
        /// <summary>Called when Publish is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnPublishChanging(string value);
        /// <summary>Called after Publish has Changed.</summary>
        partial void OnPublishChanged();
        /// <summary>Called when WriteName is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnWriteNameChanging(string value);
        /// <summary>Called after WriteName has Changed.</summary>
        partial void OnWriteNameChanged();
        /// <summary>Called when CommentEmail is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnCommentEmailChanging(string value);
        /// <summary>Called after CommentEmail has Changed.</summary>
        partial void OnCommentEmailChanged();
        /// <summary>Called when Skin is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnSkinChanging(string value);
        /// <summary>Called after Skin has Changed.</summary>
        partial void OnSkinChanged();
        /// <summary>Called when Css is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnCssChanging(string value);
        /// <summary>Called after Css has Changed.</summary>
        partial void OnCssChanged();
        /// <summary>Called when MetaKey is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnMetaKeyChanging(string value);
        /// <summary>Called after MetaKey has Changed.</summary>
        partial void OnMetaKeyChanged();
        /// <summary>Called when IsWebServices is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIsWebServicesChanging(bool value);
        /// <summary>Called after IsWebServices has Changed.</summary>
        partial void OnIsWebServicesChanged();
        /// <summary>Called when PostCount is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnPostCountChanging(long value);
        /// <summary>Called after PostCount has Changed.</summary>
        partial void OnPostCountChanged();
        /// <summary>Called when CommentCount is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnCommentCountChanging(long value);
        /// <summary>Called after CommentCount has Changed.</summary>
        partial void OnCommentCountChanged();
        /// <summary>Called when TrackBackCount is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTrackBackCountChanging(long value);
        /// <summary>Called after TrackBackCount has Changed.</summary>
        partial void OnTrackBackCountChanged();
        /// <summary>Called when UserID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnUserIDChanging(long value);
        /// <summary>Called after UserID has Changed.</summary>
        partial void OnUserIDChanged();
        #endregion
        
    }
}

