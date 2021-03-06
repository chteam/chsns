﻿/// <reference path="Framework.js" />

//重典
//20070728,20080210,20080901,20081014
//分页JS
var Pager_Set = function(containers, npid, cid, epid, oc) {
	//nowPageid存当前载入页的hide
	//allCountid存所有条数
	//everyPageid：存每页的条数的hide
	//oc is event
	var pr_dn = function(i, d) {//返回一个HIDE中存的数学值，def为非法情况下的默认值
		if (i == "" || $v(i) == null || $v(i) == "")
			return d;
		return parseInt($v(i));
	};
	if (!oc) oc = "setpage";
	var c = pr_dn(cid, 20);
	var ep = pr_dn(epid, 20);
	var np = pr_dn(npid, 1);
	var pc = parseInt((c + ep - 1) / ep); //计算总条数
	if (pc <= 1) {
		containers.hide();
		return;
	} else {
		containers.show();
	}
	var st = function(tc) { return '<span class="this-page">' + tc + '</span>'; };
	var bt = '<span class="break">...</span>';
	var unst = function(p, txt, ot) {
		return '<a href="javascript:$(\'' + npid + '\').val(\'' + p + '\');' + oc + '(' + p + ')" class="page-size' + ot + '">' + txt + '</a>';
	};
	//初始化
	var alltext = new String();
	if (np > 1) {
		if (np - 2 > 1) alltext += unst("1", "« 第一页", "") + bt;
		alltext += unst(np - 1, "< 上一页", "");
	}
	for (i = 2; i <= 6; i++)
		if ((np + i - 4) >= 1 && (np + i - 4) <= pc)
		if (4 == i)
		alltext += st(np);
	else
		alltext += unst(np + i - 4, np + i - 4, Math.abs(i - 4));
	if (np < pc) {
		alltext += unst(1 + np, "下一页 >", "");
		if (np + 2 < pc) alltext += bt + unst(pc, "最后页 »", "");
	}
	containers.html(alltext);
};
var pagefun = function(oc) { Pager_Set($(".page"), "#NowPage", "#PageCount", "#EveryPage", oc); };