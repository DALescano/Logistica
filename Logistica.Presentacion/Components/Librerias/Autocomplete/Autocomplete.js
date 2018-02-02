/// <summary>
/// Controlador de progreso de carga o peticiones
/// </summary>
/// <remarks>
/// Creacion: 	MIGUEL LUNA 2015 11 13 <br />
/// </remarks>

function wflat(s) {
    s = s.toLowerCase();
    s = s.replace(/à|á|ä|â/i, "a");
    s = s.replace(/è|é|ë|ê/i, "e");
    s = s.replace(/ì|í|ï|î/i, "i");
    s = s.replace(/ò|ó|ö|ô/i, "o");
    s = s.replace(/ù|ú|ü|û/i, "u");
    return s;
}

ns('Pe.GMD.UI.Web.Components.Autocomplete');
Pe.GMD.UI.Web.Components.Autocomplete = function (opts) {
    this.init(opts);
};

Pe.GMD.UI.Web.Components.Autocomplete.prototype = {
    inputVal: null,
    input: null,
    type: null,
    ///url: null,
    source: null,
    valueField: null,
    descripcionField: null,
    selectCallback: null,

    init: function (opts) {
        this.inputVal = opts.inputVal ? opts.inputVal : null;
        this.input = opts.input ? opts.input : null;
        this.type = opts.type ? opts.type : "function";
        ///this.url = opts.url ? opts.url : null;
        this.source = opts.source ? opts.source : null;
        this.result = opts.result ? opts.result : "";
        this.data = opts.data ? opts.data : "";
        this.valueField = opts.valueField ? opts.valueField : null;
        this.descripcionField = opts.descripcionField ? opts.descripcionField : null;
        this.selectCallback = opts.selectCallback ? opts.selectCallback : null;

        this.input.data("SelectCallback", this.selectCallback);
        this.input.data("ValueField", this.valueField);
        this.input.data("DescripcionField", this.descripcionField);

        if (this.type == "function") {
            
            this.input.data("WebMethodPath", this.source);
            this.input.data("WebMethodData", this.data);
            this.source = function (request, response) {
                
                var WebMethod = $("#" + this.element[0].id).data("WebMethodPath");
                var WebMethodData = $("#" + this.element[0].id).data("WebMethodData");
                var DataValueField = $("#" + this.element[0].id).data("ValueField");
                var DataDescripcionField = $("#" + this.element[0].id).data("DescripcionField");
                $.ajax({
                    url: WebMethod,
                    data: WebMethodData(request.term),
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        if (eval(data.Result) != undefined) {
                            response($.map(eval(data.Result), function (item) {
                                
                                if (request.term != '') {
                                    eval("var pattern =/" + wflat(request.term.replace(/([.*+?\/^$|(){}\[\]])/mg, "\\$1")) + "+/ig");
                                    var that2 = wflat(DataDescripcionField == "" ? eval("item." + DataValueField).toString() : eval("item." + DataValueField).toString() + "-" + eval("item." + DataDescripcionField).toString());
                                    if (pattern.test(that2)) {
                                        return item;//{
                                        //value: eval("item." + DataValueField).toString(),
                                        //Descripcion: DataDescripcionField == "" ? "" : eval("item." + DataDescripcionField).toString(),
                                        //jquery: item
                                        //}
                                    }
                                    //else {
                                    //    return {
                                    //        value: "",
                                    //        Descripcion: "",
                                    //        jquery: ""
                                    //    }
                                    //}
                                }
                                else {
                                    return item;//{
                                    //value: eval("item." + DataValueField),
                                    //Descripcion: DataDescripcionField == "" ? "" : eval("item." + DataDescripcionField).toString(),
                                    //jquery: item
                                    //}
                                }
                            }))
                        }
                        //response($.map(data.Result, function (item) {
                        //    return {
                        //        label: item.NombreRazonSocial,
                        //        val: item.NombreRazonSocial,
                        //        att1: item.IdPersona
                        //    }
                        //}))
                    },
                    error: function (response) {
                        base.Controles.Mensaje.Warning({ message: response.responseText });
                    },
                    failure: function (response) {
                        base.Controles.Mensaje.Warning({ message: response.responseText });
                    }
                });
            }
        }

        this.input.autocomplete({
            inputVal: this.inputVal,
            source: this.source,
            Result: this.result,
            select: function (e, i) {
                var SelectCallback = $(this).data("SelectCallback");
                if (typeof SelectCallback == "function") {
                    setTimeout(function () {
                        SelectCallback.call(this, e, i);
                    }, 100)
                }
            },
            minLength: 1
        });
    },
    //Grivera. 04012015. Para buscar en el array
    //search: function (key, prop) {
    //    for (var li = 0; li < this.source.lenght; li++) {
    //        if (this.source[li][prop] === key) {
    //            return this.source[li];
    //        }
    //    }
    //}
};
