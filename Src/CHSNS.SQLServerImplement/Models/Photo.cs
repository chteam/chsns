using CHSNS.Abstractions;

namespace CHSNS.SQLServerImplement
{
    public  partial class Photo :IPhoto
    {

        #region IPhoto Members


        public string Url        {            get;            set;        }

        #endregion
    }
}