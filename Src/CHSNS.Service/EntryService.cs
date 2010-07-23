using System;
using System.Collections.Generic;
using System.Linq;
using CHSNS.Model;

using CHSNS.Operator;
using CHSNS.SQLServerImplement;

namespace CHSNS.Service
{
    public class EntryService : BaseService<EntryService>
    {
        private readonly EntryOperator _entry;
        public EntryService()
        {
            _entry = new EntryOperator();
        }

        
    }
}
