﻿using System;
namespace CHSNS.Operator {
	public interface IViewOperator {
		void Update(byte type,  long ownerid);
		CHSNS.Model.ViewListPas ViewList(byte type, int everyrow, long ownerid, int count);
	}
}