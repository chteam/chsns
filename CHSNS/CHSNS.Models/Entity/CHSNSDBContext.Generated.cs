
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CHSNS.Models
{
    /// <summary>
    /// The DataContext class for the CHSNSDB database.
    /// </summary>
    public partial class CHSNSDBContext : DataContext
    {
        private static MappingSource mappingCache = new AttributeMappingSource();
        
        #region Constructors
        /// <summary>
        /// Initializes the <see cref="CHSNSDBContext"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute]
        static CHSNSDBContext()
        { }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CHSNSDBContext"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute]
        public CHSNSDBContext()
            : base(Properties.Settings.Default.CHSNSDBConnectionString, mappingCache)
        {
            OnCreated();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CHSNSDBContext"/> class.
        /// </summary>
        /// <param name="connection">The connection string.</param>
        [DebuggerNonUserCodeAttribute]
        public CHSNSDBContext(string connection)
            : base(connection, mappingCache)
        {
            OnCreated();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CHSNSDBContext"/> class.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        [DebuggerNonUserCodeAttribute]
        public CHSNSDBContext(IDbConnection connection)
            : base(connection, mappingCache)
        {
            OnCreated();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CHSNSDBContext"/> class.
        /// </summary>
        /// <param name="connection">The connection string.</param>
        /// <param name="mappingSource">The mapping source.</param>
        [DebuggerNonUserCodeAttribute]
        public CHSNSDBContext(string connection, MappingSource mappingSource)
            : base(connection, mappingSource)
        {
            OnCreated();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CHSNSDBContext"/> class.
        /// </summary>
        /// <param name="connection">The database connection.</param>
        /// <param name="mappingSource">The mapping source.</param>
        [DebuggerNonUserCodeAttribute]
        public CHSNSDBContext(IDbConnection connection, MappingSource mappingSource)
            : base(connection, mappingSource)
        {
            OnCreated();
        }
        #endregion
        
        #region Tables
        /// <summary>Represents the dbo.Account table in the underlying database.</summary>
        public Table<Account> Account
        {
            get { return GetTable<Account>(); }
        }
        
        /// <summary>Represents the dbo.City table in the underlying database.</summary>
        public Table<City> City
        {
            get { return GetTable<City>(); }
        }
        
        /// <summary>Represents the dbo.Province table in the underlying database.</summary>
        public Table<Province> Province
        {
            get { return GetTable<Province>(); }
        }
        
        /// <summary>Represents the dbo.ViewData table in the underlying database.</summary>
        public Table<ViewData> ViewData
        {
            get { return GetTable<ViewData>(); }
        }
        
        #endregion

        #region Functions
        #endregion

        #region Extensibility Method Definitions
        /// <summary>Called after this instance is created.</summary>
        partial void OnCreated();
        /// <summary>Called before a Account is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertAccount(Account instance);
        /// <summary>Called before a Account is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateAccount(Account instance);
        /// <summary>Called before a Account is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteAccount(Account instance);
        /// <summary>Called before a City is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertCity(City instance);
        /// <summary>Called before a City is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateCity(City instance);
        /// <summary>Called before a City is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteCity(City instance);
        /// <summary>Called before a Province is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertProvince(Province instance);
        /// <summary>Called before a Province is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateProvince(Province instance);
        /// <summary>Called before a Province is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteProvince(Province instance);
        /// <summary>Called before a ViewData is inserted.</summary>
        /// <param name="instance">The instance.</param>
        partial void InsertViewData(ViewData instance);
        /// <summary>Called before a ViewData is updated.</summary>
        /// <param name="instance">The instance.</param>
        partial void UpdateViewData(ViewData instance);
        /// <summary>Called before a ViewData is deleted.</summary>
        /// <param name="instance">The instance.</param>
        partial void DeleteViewData(ViewData instance);
        #endregion
    }
}

