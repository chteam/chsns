using System.Collections.Generic;

namespace MvcHelper
{
    public class FlexGridRowData
    {
        #region Constructor

        public FlexGridRowData(string id, IList<string> data)
        {
            this.id = id;
            this.cell = data;
        }

        #endregion

        #region Properties

        public string id { get; set; }

        public IList<string> cell { get; set; }

        #endregion
    }
}
