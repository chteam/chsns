using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.Data {
    public interface ICURDMediator<T> {
        void Create(T content);
        void Update(T content);
        void Remove(params long[] uid);
        IQueryable<T> List(long? uid);
    }
}
