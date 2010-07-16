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
});