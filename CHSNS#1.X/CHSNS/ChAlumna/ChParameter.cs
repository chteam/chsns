using System;

namespace CHSNS {
	public class ChParameter {
		static public object canNull(long l){
			if (l == 0)
				return DBNull.Value;
			else
				return l;
		}
	}
}
