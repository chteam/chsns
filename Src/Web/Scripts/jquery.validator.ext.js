$(function () {
    jQuery.validator.addMethod("equalsClient", function (value, element, params) {
        var id1 = params.id1;
        var id2 = params.id2;
        if (this.optional(element)) {
            return true;
        }
        if ($('#' + id1).val() == $('#' + id2).val()) {
            return true;
        }
        return false;
    });
    jQuery.validator.addMethod("containsChar", function (value, element, params) {
        if (this.optional(element)) {
            return true;
        }
        var p = value;
        if (params.hl && !/[a-zA-Z]+/g.test(p)) {
            return false
        }
        if (params.hn && !/[\d]+/g.test(p)) {
            return false
        }
        if (params.hc && !/[\u4e00 - \u9fa5]+/g.test(p)) {
            return false
        }
        if (params.hs && !/[^\w\d]+/g.test(p)) {
            return false
        }
        return true;
    });
});                
