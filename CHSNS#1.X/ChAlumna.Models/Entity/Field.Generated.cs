
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
    /// The class representing the dbo.Field table.
    /// </summary>
    [Table(Name="dbo.Field")]
    public partial class Field
        : LinqEntityBase
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Field"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Field()
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
        
        private Nullable<long> _id;

        /// <summary>
        /// Gets or sets the id column value.
        /// </summary>
        [Column(Name="id", Storage="_id", DbType="bigint")]
        public Nullable<long> Id
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
        
        private string _name;

        /// <summary>
        /// Gets or sets the name column value.
        /// </summary>
        [Column(Name="name", Storage="_name", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    OnNameChanging(value);
                    OnPropertyChanging("Name");
                    _name = value;
                    OnPropertyChanged("Name");
                    OnNameChanged();
                }
            }
        }
        
        private Nullable<long> _pid;

        /// <summary>
        /// Gets or sets the pid column value.
        /// </summary>
        [Column(Name="pid", Storage="_pid", DbType="bigint")]
        public Nullable<long> PID
        {
            get { return _pid; }
            set
            {
                if (_pid != value)
                {
                    OnPidChanging(value);
                    OnPropertyChanging("Pid");
                    _pid = value;
                    OnPropertyChanged("Pid");
                    OnPidChanged();
                }
            }
        }
        
        private bool _istrue;

        /// <summary>
        /// Gets or sets the istrue column value.
        /// </summary>
        [Column(Name="istrue", Storage="_istrue", DbType="bit NOT NULL", CanBeNull=false)]
        public bool IsTrue
        {
            get { return _istrue; }
            set
            {
                if (_istrue != value)
                {
                    OnIstrueChanging(value);
                    OnPropertyChanging("Istrue");
                    _istrue = value;
                    OnPropertyChanged("Istrue");
                    OnIstrueChanged();
                }
            }
        }
        
        private int _class;

        /// <summary>
        /// Gets or sets the class column value.
        /// </summary>
        [Column(Name="class", Storage="_class", DbType="int NOT NULL", CanBeNull=false)]
        public int Class
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
        /// <summary>Called when Name is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnNameChanging(string value);
        /// <summary>Called after Name has Changed.</summary>
        partial void OnNameChanged();
        /// <summary>Called when Pid is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnPidChanging(Nullable<long> value);
        /// <summary>Called after Pid has Changed.</summary>
        partial void OnPidChanged();
        /// <summary>Called when Istrue is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIstrueChanging(bool value);
        /// <summary>Called after Istrue has Changed.</summary>
        partial void OnIstrueChanged();
        /// <summary>Called when Class is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnClassChanging(int value);
        /// <summary>Called after Class has Changed.</summary>
        partial void OnClassChanged();
        #endregion
        
    }
}

