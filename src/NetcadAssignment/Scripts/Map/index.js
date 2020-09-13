//# sourceURL=Index.js
if (window.Index_Loaded == null) {
    var map;
    var index = {
        init: function () {
            index.loadFormData();
        },
        loadFormData: function () {
            mapControl.init()
        }
    }
    window.Index_Loaded = true;
};