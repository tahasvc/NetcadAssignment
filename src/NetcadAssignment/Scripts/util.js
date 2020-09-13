function util() {
}
util.ajax = {

    /**
    * Sends a request to the related method and responds callback to the related method
    * @public
    * @param {string} controller the name of the controller to send the request to
    * @param {string} method the name of the method to send the request to
    * @param {Function} callback method to be redirected after result
    * @param {boolean} async snyc-async type
    */
    request: function (controller, method, callback, async) {
        $.ajax({
            type: "POST",
            url: "/" + controller + "/" + method,
            async: async,
            contentType: false,
            processData: false,
            success: function (result) {
                if (callback) {
                    callback(result);
                }
            }
        });
    }
};
util.guid = {

    /**
    * Returns a guid value
    * @public
    */
    createGuid: function () {
        var hexa4 = function () {
            return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
        };
        return (hexa4() + hexa4() + "-" + hexa4() + "-" + hexa4() + "-" + hexa4() + "-" + hexa4() + hexa4() + hexa4()).toUpperCase();
    }
}