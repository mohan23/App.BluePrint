(function () {
    /* MESSAGE **************************************************/
    //Defines Message API, not implements it

    abp.message = abp.message || {};

    abp.message.info = function (message, title) {
        abp.utils.showUIMessage('info', title, message);
    };

    abp.message.warn = function (message, title) {
        abp.utils.showUIMessage('warn', title, message);
    };

    abp.message.error = function (message, title) {
        abp.utils.showUIMessage('danger', title, message);
    };

    abp.message.confirm = function (message, titleOrCallback, callback) {
        abp.log.warn('abp.message.confirm is not implemented!');

        if (titleOrCallback && !(typeof titleOrCallback == 'string')) {
            callback = titleOrCallback;
        }

        var result = confirm(message);
        callback && callback(result);
    };

    /* UI *******************************************************/

    abp.ui = abp.ui || {};

    /* UI BLOCK */
    //Defines UI Block API, not implements it

    abp.ui.block = function (elm) {
        abp.utils.showProgress();
    };

    abp.ui.unblock = function (elm) {
        abp.utils.hideProgress();
    };

    /* UI BUSY */
    //Defines UI Busy API, not implements it

    abp.ui.setBusy = function (elm, optionsOrPromise) {
        optionsOrPromise.block = true;
        abp.ui.block(elm);
    };

    abp.ui.clearBusy = function (elm) {
        abp.ui.unblock(elm);
    };

    /* UI Custom Methods to js Alert Message and Progressing info */
    abp.utils.showUIMessage = function (atype, atitle, amessage) {
        var $alertCont = angular.element($('#alertContainer')).scope();
        if ($alertCont != undefined) {
            var msg = amessage;
            $alertCont.hideProgressToast();
            if (typeof amessage == "object")
                msg = amessage.message + ". " + atitle;
            $alertCont.showAlert(atype, atitle, amessage);
        }
    };

    abp.utils.clearAlert = function () {
        var $alertCont = angular.element($('#alertContainer')).scope();
        if ($alertCont != undefined) {
            $alertCont.hideAlert();
        }
    }

    abp.utils.showProgress = function () {
        var $alertCont = angular.element($('#alertContainer')).scope();
        if ($alertCont != undefined) {
            if ($alertCont != undefined) {
                $alertCont.hideAlert();
                $alertCont.showProgressToast();
            }
        }
    };

    abp.utils.hideProgress = function () {
        var $alertCont = angular.element($('#alertContainer')).scope();
        if ($alertCont != undefined) {
            $alertCont.hideProgressToast();
        }
    };
})();