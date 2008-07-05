
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
    /// The class representing the dbo.Role table.
    /// </summary>
    [Table(Name="dbo.Role")]
    public partial class Role
        : CHSNSEntity
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Role()
        {
            OnCreated();
            _accountList = new EntitySet<Account>(
                new System.Action<Account>(this.Attach_AccountList),
                new System.Action<Account>(this.Detach_AccountList));
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
        
        private string _roleName;

        /// <summary>
        /// Gets or sets the RoleName column value.
        /// </summary>
        [Column(Name="RoleName", Storage="_roleName", DbType="nvarchar(50) NOT NULL", CanBeNull=false)]
        public string RoleName
        {
            get { return _roleName; }
            set
            {
                if (_roleName != value)
                {
                    OnRoleNameChanging(value);
                    OnPropertyChanging("RoleName");
                    _roleName = value;
                    OnPropertyChanged("RoleName");
                    OnRoleNameChanged();
                }
            }
        }
        #endregion
        
        #region Association Mapped Properties
        
        private EntitySet<Account> _accountList;
        
        /// <summary>
        /// Gets or sets the Account association.
        /// </summary>
        [Association(Name="FK_Account_Role", Storage="_accountList", ThisKey="ID", OtherKey="RoleID")]
        public EntitySet<Account> AccountList
        {
            get { return _accountList; }
            set { _accountList.Assign(value); }
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Attach_AccountList(Account entity)
        {
            OnPropertyChanging(null);
            entity.Role = this;
            OnPropertyChanged(null);
        }
        
        [DebuggerNonUserCodeAttribute()]
        private void Detach_AccountList(Account entity)
        {
            OnPropertyChanging(null);
            entity.Role = null;
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
        /// <summary>Called when RoleName is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnRoleNameChanging(string value);
        /// <summary>Called after RoleName has Changed.</summary>
        partial void OnRoleNameChanged();
        #endregion
        
    }
}

