using System;
using System.Collections.Generic;
using System.Linq;
using CHSNS.Model;

using CHSNS.Operator;
using CHSNS.SQLServerImplement;

namespace CHSNS.Service {
    public class EntryService {
        static readonly EntryService Instance = new EntryService();
        private readonly EntryOperator Entry;
        public EntryService() {
            Entry = new EntryOperator();
        }

        public static EntryService GetInstance() {
            return Instance;
        }

  
      
 
 
    }
}
