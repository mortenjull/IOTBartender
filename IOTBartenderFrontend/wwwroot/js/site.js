(function () {
    'use strict'

    // Replace with feather icons.
    feather.replace();

    var $loading = $('#loadingOverlay').hide();

    $(document).ajaxStart(function () {
        $loading.show();
        console.log('rr');
    }).ajaxStop(function () {
            $loading.hide();
    });
})();