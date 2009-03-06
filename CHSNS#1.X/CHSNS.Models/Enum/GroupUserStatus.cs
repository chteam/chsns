using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CHSNS.ModelPas {
	public enum GroupUserStatus : byte {
		Lock = 0,
		Common = 1,
		Admin = 200,
		Ceater = 255
	}
}
