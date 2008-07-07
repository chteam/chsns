
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
    /// The class representing the Account table.
    /// </summary>
    [Table(Name="Account")]
    public partial class Account
        : CHSNSEntity
    {
        
        #region Default Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        [DebuggerNonUserCodeAttribute()]
        public Account()
        {
            OnCreated();
        }
        #endregion
        
        #region Column Mapped Properties
        
        private long _iD = default(long);

        /// <summary>
        /// Gets the ID column value.
        /// </summary>
        [Column(Name="ID", Storage="_iD", DbType="integer", IsPrimaryKey=true, IsDbGenerated=true, CanBeNull=false)]
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
        
        private string _email;

        /// <summary>
        /// Gets or sets the Email column value.
        /// </summary>
        [Column(Name="Email", Storage="_email", DbType="nvarchar", CanBeNull=false)]
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    OnEmailChanging(value);
                    OnPropertyChanging("Email");
                    _email = value;
                    OnPropertyChanged("Email");
                    OnEmailChanged();
                }
            }
        }
        
        private string _passwordMd5;

        /// <summary>
        /// Gets or sets the PasswordMd5 column value.
        /// </summary>
        [Column(Name="PasswordMd5", Storage="_passwordMd5", DbType="varchar", CanBeNull=false)]
        public string PasswordMd5
        {
            get { return _passwordMd5; }
            set
            {
                if (_passwordMd5 != value)
                {
                    OnPasswordMd5Changing(value);
                    OnPropertyChanging("PasswordMd5");
                    _passwordMd5 = value;
                    OnPropertyChanged("PasswordMd5");
                    OnPasswordMd5Changed();
                }
            }
        }
        
        private System.DateTime _regTime = default(System.DateTime);

        /// <summary>
        /// Gets the RegTime column value.
        /// </summary>
        [Column(Name="RegTime", Storage="_regTime", DbType="timestamp", IsDbGenerated=true, IsVersion=true, CanBeNull=false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public System.DateTime RegTime
        {
            get { return _regTime; }
            set
            {
                if (_regTime != value)
                {
                    OnRegTimeChanging(value);
                    OnPropertyChanging("RegTime");
                    _regTime = value;
                    OnPropertyChanged("RegTime");
                    OnRegTimeChanged();
                }
            }
        }
        
        private System.DateTime _loginTime = default(System.DateTime);

        /// <summary>
        /// Gets the LoginTime column value.
        /// </summary>
        [Column(Name="LoginTime", Storage="_loginTime", DbType="timestamp", IsDbGenerated=true, IsVersion=true, CanBeNull=false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public System.DateTime LoginTime
        {
            get { return _loginTime; }
            set
            {
                if (_loginTime != value)
                {
                    OnLoginTimeChanging(value);
                    OnPropertyChanging("LoginTime");
                    _loginTime = value;
                    OnPropertyChanged("LoginTime");
                    OnLoginTimeChanged();
                }
            }
        }
        
        private string _nickName;

        /// <summary>
        /// Gets or sets the NickName column value.
        /// </summary>
        [Column(Name="NickName", Storage="_nickName", DbType="nvarchar", CanBeNull=false)]
        public string NickName
        {
            get { return _nickName; }
            set
            {
                if (_nickName != value)
                {
                    OnNickNameChanging(value);
                    OnPropertyChanging("NickName");
                    _nickName = value;
                    OnPropertyChanged("NickName");
                    OnNickNameChanged();
                }
            }
        }
        
        private string _question;

        /// <summary>
        /// Gets or sets the Question column value.
        /// </summary>
        [Column(Name="Question", Storage="_question", DbType="nvarchar")]
        public string Question
        {
            get { return _question; }
            set
            {
                if (_question != value)
                {
                    OnQuestionChanging(value);
                    OnPropertyChanging("Question");
                    _question = value;
                    OnPropertyChanged("Question");
                    OnQuestionChanged();
                }
            }
        }
        
        private string _answer;

        /// <summary>
        /// Gets or sets the Answer column value.
        /// </summary>
        [Column(Name="Answer", Storage="_answer", DbType="nvarchar")]
        public string Answer
        {
            get { return _answer; }
            set
            {
                if (_answer != value)
                {
                    OnAnswerChanging(value);
                    OnPropertyChanging("Answer");
                    _answer = value;
                    OnPropertyChanged("Answer");
                    OnAnswerChanged();
                }
            }
        }
        
        private long _roles;

        /// <summary>
        /// Gets or sets the Roles column value.
        /// </summary>
        [Column(Name="Roles", Storage="_roles", DbType="integer", CanBeNull=false)]
        public long Roles
        {
            get { return _roles; }
            set
            {
                if (_roles != value)
                {
                    OnRolesChanging(value);
                    OnPropertyChanging("Roles");
                    _roles = value;
                    OnPropertyChanged("Roles");
                    OnRolesChanged();
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
        /// <summary>Called when ID is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnIDChanging(long value);
        /// <summary>Called after ID has Changed.</summary>
        partial void OnIDChanged();
        /// <summary>Called when Email is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnEmailChanging(string value);
        /// <summary>Called after Email has Changed.</summary>
        partial void OnEmailChanged();
        /// <summary>Called when PasswordMd5 is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnPasswordMd5Changing(string value);
        /// <summary>Called after PasswordMd5 has Changed.</summary>
        partial void OnPasswordMd5Changed();
        /// <summary>Called when RegTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnRegTimeChanging(System.DateTime value);
        /// <summary>Called after RegTime has Changed.</summary>
        partial void OnRegTimeChanged();
        /// <summary>Called when LoginTime is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnLoginTimeChanging(System.DateTime value);
        /// <summary>Called after LoginTime has Changed.</summary>
        partial void OnLoginTimeChanged();
        /// <summary>Called when NickName is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnNickNameChanging(string value);
        /// <summary>Called after NickName has Changed.</summary>
        partial void OnNickNameChanged();
        /// <summary>Called when Question is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnQuestionChanging(string value);
        /// <summary>Called after Question has Changed.</summary>
        partial void OnQuestionChanged();
        /// <summary>Called when Answer is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnAnswerChanging(string value);
        /// <summary>Called after Answer has Changed.</summary>
        partial void OnAnswerChanged();
        /// <summary>Called when Roles is changing.</summary>
        /// <param name="value">The new value.</param>
        partial void OnRolesChanging(long value);
        /// <summary>Called after Roles has Changed.</summary>
        partial void OnRolesChanged();
        #endregion
        
    }
}

