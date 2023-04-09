
$(function () {

    $('.select-all-btn').click(function () {
        $(this).closest('.check-grp').find('input[type="checkbox"]').prop('checked', true).change();
    });

});

function loadDataTable(elementId, url, columns, enableSearch, enablePagination, enableSorting) {
    //App.datatables();

    var dTable = $("#" + elementId).DataTable({
        ajax: {
            url: url,
            type: "POST",
            //data: { filter },
        },
        order: [[0, "desc"]],
        columns: columns,
        language: DataTableLangLookup || "",
        responsive: true,
        searching: enableSearch,
        paging: enablePagination,
        info: enablePagination,
        ordering: enableSorting,
        lengthChange: false,
        destroy: true,
        processing: true,
        serverSide: true,
        orderMulti: false,
        pageLength: 10,
        lengthMenu: [[10, 20, 30, -1], [10, 20, 30, 'All']]
    });

    //$('.dataTables_filter input').attr('placeholder', SearchBH);
    //if (!dTable.data().any()) {
    //    $("#total").text(0);
    //}

    return dTable;
}

function getCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function setCookie(name, value, expiryInMin) {
    var expires = "";
    if (expiryInMin) {
        var date = new Date();
        date.setTime(date.getTime() + (expiryInMin * 1000));
        expires = "; expires=" + date.toUTCString();
    }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}

var groupBy = function (xs, key) {
    return xs.reduce(function (rv, x) {
        (rv[x[key]] = rv[x[key]] || []).push(x);
        return rv;
    }, {});
};

function showLoading(spinnerIcon) {
    JsLoadingOverlay.show({
        'overlayBackgroundColor': '#a9a9a9',
        'overlayOpacity': 0.6,
        'spinnerIcon': spinnerIcon || 'ball-atom',
        'spinnerColor': '#696cff',
        'spinnerSize': '2x',
        'overlayIDName': 'overlay',
        'spinnerIDName': 'spinner',
        'spinnerZIndex': 99999,
        'overlayZIndex': 99998
    });
}

function hideLoading() {
    JsLoadingOverlay.hide();
}

function hideModalFunc(modalName) {
    bootstrap.Modal.getInstance(document.querySelector(modalName)).hide();
}

function serializeForm(formId, formData) {
    if (formData == null) {
        formData = new FormData();
    }
    $(`#${formId} input,select,textarea`).each(function () {
        var name = $(this).attr('name');
        if (name != null) {
            if ($(this).attr('type') == 'checkbox') {
                formData.append(name, $(this).is(':checked'));
            }
            else if ($(this).attr('type') == 'file') {
                var files = this.files;
                if (files.length > 0) {
                    for (var i = 0; i < files.length; i++) {
                        formData.append(name + "[" + i + "]", files[i]);
                    }
                }
            }
            else if ($(this).hasClass("ckeditor")) {
                var value = CKEDITOR.instances[name].getData();
                formData.append(name, value);
            }
            else {
                formData.append(name, $(this).val());
            }
        }
    });
    return formData;
}

function appnedFiles(formData, inputId) {
    var fileExist = document.getElementById(inputId);
    if (!fileExist) return;
    var files = document.getElementById(inputId).files;
    if (files.length > 0) {
        for (var i = 0; i < files.length; i++) {
            formData.append(inputId + "[" + i + "]", files[i]);
        }
    }
}

function appendObject(formData, obj, propName) {
    Object.keys(obj).forEach(key => {
        var propValue = obj[key];
        if (propValue != null) {
            if (Array.isArray(propValue)) {
                appendList(formData, propValue, propName ? propName + "." + key : key);
            } else if (typeof propValue == "object") {
                appendObject(formData, propValue, propName ? propName + "." + key : key);
            } else {
                formData.append(propName ? propName + "." + key : key, obj[key]);
            }
        }
    });
}

function appendList(formData, list, propName) {
    var index = 0;
    for (var item of list) {
        if (Array.isArray(item)) {
            appendList(formData, list, propName + "[" + index + "]");
        } else if (typeof item == "object") {
            appendObject(formData, item, propName + "[" + index + "]");
        } else {
            formData.append(propName + "[" + index + "]", item);
        }
        index++;
    }
}