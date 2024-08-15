$.validator.addMethod('nodigittext', function (value, element, params) {
    return !/\d/.test(value);
});

$.validator.unobtrusive.adapters.add('nodigittext', [], function (options) {
    var element = $(options.form).find('input#FirstName')[0];
    options.rules['nodigittext'] = options.params;
    options.messages['nodigittext'] = options.message;
});