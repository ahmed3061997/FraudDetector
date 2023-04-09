function showToast(header, message, type = 'primary', delay = 3500, autohide = true, animation = 'fadeInRight', placement = 'top-right') {
    var isRtl = document.documentElement.lang == 'ar';
    var placements = {
        'top': 'top-0 start-50 translate-middle-x',
        'top-left': 'top-0 start-0',
        'top-right': 'top-0 end-0',
        'center': 'top-50 start-50 translate-middle',
        'center-left': 'top-50 start-0 translate-middle-y',
        'center-right': 'top-50 end-0 translate-middle-y',
        'bottom': 'bottom-0 start-50 translate-middle-x',
        'bottom-left': 'bottom-0 start-0',
        'bottom-right': 'bottom-0 end-0'
    };

    var icons = {
        'primary': 'bx-bell',
        'info': 'bx-bell',
        'danger': 'bx-error',
        'warning': 'bx-error',
        'success': 'bx-check-circle',
    };

    var toastContainer = `<div class="toast-container bs-toast toast-placement-ex m-4 ${placements[placement]}"></div>`;

    var toast = `<div class="bs-toast toast m-4 fade animate__animated animate__faster animate__${isRtl ? animation.replace('Right', 'Left') : animation} bg-${type}" role="alert">
                     <div class="toast-header">
                         <i class="bx ${icons[type]} me-2"></i>
                         <div class="me-auto fw-semibold">${header}</div>
                         <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
                     </div>
                     <div class="toast-body">
                         ${message}
                     </div>
                 </div>`;

    var container = $('.toast-container');
    if (container.length == 0) {
        $(document.body).prepend(toastContainer);
        container = $('.toast-container');
    }
    container.append(toast);

    $('.toast:last')
        .on('hidden.bs.toast', function (e) {
            $(e.currentTarget).remove();
            if ($('.toast').length == 0)
                $('.toast-container').remove();
        })
        .toast({ autohide: autohide, delay: delay })
        .toast('show');
}