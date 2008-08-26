
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
    /// The class representing the dbo.Comment table.
    /// </summary>
    [Table(Name="dbo.Comment")]
    public partial class Comment
        : LinqEntityBase
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Comment"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Comment()
        {
            OnCreated();
        }
        #endregion
        
        #region Column Mapped Properties
        
        private long _trueid = default(long);

        /// <summary>
        /// Gets the trueid column value.
        /// </summary>
        [Column(Name="trueid", Storage="_trueid", DbType="bigint NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false)]
        public long TrueID
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
        
        private Nullable<long> _id;

        /// <summary>
        /// Gets or sets the id column value.
        /// </summary>
        [Column(Name="id", Storage="_id", DbType="bigint")]
        public Nullable<long> ID
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
        
        private Nullable<long> _logid;

        /// <summary>
        /// Gets or sets the Logid column value.
        /// </summary>
        [Column(Name="Logid", Storage="_logid", DbType="bigint")]
        public Nullable<long> LogID
        {
            get { return _logid; }
            set
            {
                if (_logid != value)
                {
                    OnLogidChanging(value);
                    OnPropertyChanging("Logid");
                    _logid = value;
                    OnPropertyChanged("Logid");
                    OnLogidChanged();
                }
            }
        }
        
        private long _ownerid;

        /// <summary>
        /// Gets or sets the ownerid column value.
        /// </summary>
        [Column(Name="ownerid", Storage="_ownerid", DbType="bigint NOT NULL", CanBeNull=false)]
        public long OwnerID
        {
            get { return _ownerid; }
            set
            {
                if (_ownerid != value)
                {
                    OnOwneridChanging(value);
                    OnPropertyChanging("Ownerid");
                    _ownerid = value;
                    OnPropertyChanged("Ownerid");
                    OnOwneridChanged();
                }
            }
        }
        
        private long _senderid;

        /// <summary>
        /// Gets or sets the senderid column value.
        /// </summary>
        [Column(Name="senderid", Storage="_senderid", DbType="bigint NOT NULL", CanBeNull=false)]
        public long SenderID
        {
            get { return _senderid; }
            set
            {
                if (_senderid != value)
                {
                    OnSenderidChanging(value);
                    OnPropertyChanging("Senderid");
                    _senderid = value;
                    OnPropertyChanged("Senderid");
                    OnSenderidChanged();
                }
            }
        }
        
        private System.DateTime _addtime;

        /// <summary>
        /// Gets or sets the addtime column value.
        /// </summary>
        [Column(Name="addtime", Storage="_addtime", DbType="smalldatetime NOT NULL", CanBeNull=false)]
        public System.DateTime AddTime
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
        
        private string _body;

        /// <summary>
        /// Gets or sets the body column value.
        /// </summary>
        [Column(Name="body", Storage="_body", DbType="ntext NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
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
        
        private bool _isReply;

        /// <summary>
        /// Gets or sets the IsReply column value.
        /// </summary>
        [Column(Name="IsReply", Storage="_isReply", DbType="bit NOT NULL", CanBeNull=false)]
        public bool IsReply
        {
            get { return _isReply; }
            set
            {
                if (_isReply != value)
                {
                    OnIsReplyChanging(value);
                    OnPropertyChanging("IsReply");
                    _isReply = value;
                    OnPropertyChanged("IsReply");
                    OnIsReplyChanged();
                }
            }
        }
        
        private bool _isSee;

        /// <summary>
        /// Gets or sets the IsSee column value.
        /// </summary>
        [Column(Name="IsSee", Storage="_isSee", DbType="bit NOT NULL", CanBeNull=false)]
        public bool IsSee
        {
            get { return _isSee; }
            set
            {
                if (_isSee != value)
                {
                    OnIsSeeChanging(value);
                    OnPropertyChanging("IsSee");
                    _isSee = value;
                    OnPropertyChanged("IsSee");
                    OnIsSeeChanged();
                }
            }
        }
        
        private bool _isDel;

        /// <summary>
        /// Gets or sets the IsDel column value.
        /// </summary>
        [Column(Name="IsDel", Storage="_isDel", DbType="bit NOT NULL", CanBeNull=false)]
        public bool IsDel
        {
            get { return _isDel; }
            set
            {
                if (_isDel != value)
                {
                    OnIsDelChanging(value);
                    OnPropertyChanging("IsDel");
                    _isDel = value;
                    OnPropertyChanged("IsDel");
                    OnIsDelChanged();
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
        /// <summary>Called when Trueid is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTrueidChanging(long value);
        /// <summary>Called after Trueid has Changed.</summary>
        partial void OnTrueidChanged();
        /// <summary>Called when Id is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIdChanging(Nullable<long> value);
        /// <summary>Called after Id has Changed.</summary>
        partial void OnIdChanged();
        /// <summary>Called when Logid is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnLogidChanging(Nullable<long> value);
        /// <summary>Called after Logid has Changed.</summary>
        partial void OnLogidChanged();
        /// <summary>Called when Ownerid is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnOwneridChanging(long value);
        /// <summary>Called after Ownerid has Changed.</summary>
        partial void OnOwneridChanged();
        /// <summary>Called when Senderid is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnSenderidChanging(long value);
        /// <summary>Called after Senderid has Changed.</summary>
        partial void OnSenderidChanged();
        /// <summary>Called when Addtime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnAddtimeChanging(System.DateTime value);
        /// <summary>Called after Addtime has Changed.</summary>
        partial void OnAddtimeChanged();
        /// <summary>Called when Body is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnBodyChanging(string value);
        /// <summary>Called after Body has Changed.</summary>
        partial void OnBodyChanged();
        /// <summary>Called when IsReply is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIsReplyChanging(bool value);
        /// <summary>Called after IsReply has Changed.</summary>
        partial void OnIsReplyChanged();
        /// <summary>Called when IsSee is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIsSeeChanging(bool value);
        /// <summary>Called after IsSee has Changed.</summary>
        partial void OnIsSeeChanged();
        /// <summary>Called when IsDel is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIsDelChanging(bool value);
        /// <summary>Called after IsDel has Changed.</summary>
        partial void OnIsDelChanged();
        /// <summary>Called when Type is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnTypeChanging(byte value);
        /// <summary>Called after Type has Changed.</summary>
        partial void OnTypeChanged();
        /// <summary>Called when Istellme is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIstellmeChanging(byte value);
        /// <summary>Called after Istellme has Changed.</summary>
        partial void OnIstellmeChanged();
        #endregion
        
    }
}

