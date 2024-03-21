$(document).ready(function () {
    partsmodel.initialize();
});

var partsmodel = {

    initialize() {
        this.bindEvents();
    },

    bindEvents: function () {
        partsmodel.filterable = $("#partsTable").dataTable({
            ajax: {
                "url": "/Parts/GetParts",
                "type": "POST",
                "dataSrc": "dataList",
                "data": function (d) {
                    
                }
            },
            columns: [
                "data": "partsid",

            ]

        })
    }
}