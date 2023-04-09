$(document).on('click', '.language-selector-list li', function (e) {
    var current = $(e.currentTarget);
    var parent = current.closest('.language-selector');

    var prevSelected = parent.find('.language.selected');
    prevSelected.find('.fa-check').remove();
    prevSelected.removeClass('selected');

    current.find('a').append('<i class="fa fa-check text-success ms-2"></i>');
    current.addClass('selected');

    var toggle = parent.find('.language-selector-btn');
    toggle.find('i').remove();
    toggle.append(`<i class="flag-${current.data('flag')} flag m-0"></i>`);
    toggle.data('current-culture', current.data('culture'))
})

function getLanguageInputValues() {
    return Array.from($('.language-input')).map(e => ({
        culture: $(e).data('culture'),
        value: $(e).find('input').val()
    }));
}
function getLanguageInputValuesMultiple() {
    var inputs = Array.from($('.language-input')).map(e => ({
        culture: $(e).data('culture'),
        prop: $(e).data('type') == 0 ? $(e).find('input').data("name") : $(e).find('textarea').data("name"),
        value: $(e).data('type') == 0 ? $(e).find('input').val() : $(e).find('textarea').val(),
    }));

    var table = [];
    var grps = groupBy(inputs, 'culture');
    Object.keys(grps).forEach(culture => {
        var rows = grps[culture];
        var row = {
            LangCode: culture
        };
        rows.forEach(x => row[x.prop] = x.value);
        table.push(row);
    });
    return table;
}