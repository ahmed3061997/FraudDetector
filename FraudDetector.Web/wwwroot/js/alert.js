function showAlert(type, title, message, okBtn, cancelBtn, okFunc, cancelFunc) {

    if (type == 'danger') {
        $('#AlertPopup i').attr('class', 'bx bx-x-circle text-danger mb-3');
        $('#AlertPopup button:first').attr('class', 'btn btn-danger');
    }
    else if (type == 'info') {
        $('#AlertPopup i').attr('class', 'bx bx-info-circle text-primary mb-3');
        $('#AlertPopup button:first').attr('class', 'btn btn-primary');
    }
    else if (type == 'warning') {
        $('#AlertPopup i').attr('class', 'bx bx-error-circle text-warning mb-3');
        $('#AlertPopup button:first').attr('class', 'btn btn-warning');
    }
    else {
        return;
    }

    $('#AlertPopup h4').text(title);
    $('#AlertPopup p').text(message);

    if (okBtn) {
        $('#AlertPopup button:first')
            .text(okBtn)
            .on('click', function () {
                okFunc && okFunc();
                $(this).off('click');
                $('#AlertPopup').modal('hide');
            });
    } else {
        $('#AlertPopup button:first').addClass('d-none');
    }

    if (cancelBtn) {
        $('#AlertPopup .modal-footer button:last')
            .text(cancelBtn)
            .on('click', function () {
                cancelFunc && cancelFunc();
                $(this).off('click');
                $('#AlertPopup').modal('hide');
            });
    } else {
        $('#AlertPopup .modal-footer button:last').addClass('d-none');
    }

    $('#AlertPopup')
        .modal({
            backdrop: 'static',
            keyboard: false
        })
        .modal('show');
}