/// <summary>
/// Controlador de progreso de carga o peticiones
/// </summary>
/// <remarks>
/// Creacion: 	EDGAR MELGAREJO 20140707 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.Calendar');
Pe.GMD.UI.Web.Components.Calendar = function (opts) {
    this.init(opts);
};

Pe.GMD.UI.Web.Components.Calendar.prototype = {

    inputFrom: null,
    inputTo: null,
    callbackTo: null,
    callbackFrom: null,
    init: function (opts) {
        this.inputFrom = opts.inputFrom ? opts.inputFrom : null;
        this.inputTo = opts.inputTo ? opts.inputTo : null;
        this.callbackTo = opts.callbackTo ? opts.callbackTo : null;
        this.callbackFrom = opts.callbackFrom ? opts.callbackFrom : null;
        var me = this;
        //this._privateFunction

        if (this.inputFrom && this.inputFrom != null) {
            var configFrom = {
                beforeShow: function (input, inst) {
                    inst.dpDiv.addClass('zIndexCalendar');
                },
                dateFormat: Pe.GMD.UI.Web.Formato.Fecha,
                onClose: function (selected) {
                    var result = Pe.GMD.UI.Web.Components.Util.ValidateBlurOnlyDate(this);
                    if (me.callbackFrom != null) {
                        me.callbackFrom(selected);
                    }
                    if (me.inputTo && me.inputTo != null) {
                        if (result) {
                            me.inputTo.datepicker('option', 'minDate', selected);
                        }
                        else {
                            me.inputTo.datepicker('option', 'minDate', null);
                        }
                    }
                }
            };
            if (opts.maxDateFrom && opts.maxDateFrom != null) {
                configFrom.maxDate = opts.maxDateFrom;
            }
            if (opts.minDateFrom && opts.minDateFrom != null) {
                configFrom.minDate = opts.minDateFrom;
            }
            this.inputFrom.datepicker(configFrom);
            this.inputFrom.bind("blur", function () {
                return Pe.GMD.UI.Web.Components.Util.ValidateBlurOnlyDate(this);
            });
            this.inputFrom.mask(Pe.GMD.UI.Web.Formato.FechaMascara);
            if (me.inputTo && me.inputTo != null) {
                this.inputFrom.change(function () {
                    if ($(this).val() == "" || $(this).val() == null) {
                        me.inputTo.datepicker('option', 'minDate', null);
                    }
                });
            }



        }



        if (this.inputTo && this.inputTo != null) {
            var configTo = {
                beforeShow: function (input, inst) {
                    inst.dpDiv.addClass('zIndexCalendar');
                },
                dateFormat: Pe.GMD.UI.Web.Formato.Fecha,
                onClose: function (selected) {
                    var result = Pe.GMD.UI.Web.Components.Util.ValidateBlurOnlyDate(this);
                    if (me.callbackTo != null) {
                        me.callbackTo(selected);
                    }
                    if (me.inputFrom && me.inputFrom != null) {
                        if (result) {
                            me.inputFrom.datepicker('option', 'maxDate', selected);
                        }
                        else {
                            me.inputFrom.datepicker('option', 'maxDate', null);
                        }
                    }
                }
            };
            if (opts.maxDateTo && opts.maxDateTo != null) {
                configTo.maxDate = opts.maxDateTo;
            }
            this.inputTo.datepicker(configTo);
            this.inputTo.bind("blur", function () {
                return Pe.GMD.UI.Web.Components.Util.ValidateBlurOnlyDate(this);
            });
            this.inputTo.mask(Pe.GMD.UI.Web.Formato.Fecha);
            if (me.inputFrom && me.inputFrom != null) {
                this.inputTo.change(function () {
                    if ($(this).val() == "" || $(this).val() == null) {
                        me.inputFrom.datepicker('option', 'maxDate', null);
                    }
                });
            }
        }

    },

    destroy: function () {
        if (this.inputFrom) {
            this.inputFrom.datepicker("destroy");
        }
        if (this.inputTo) {
            this.inputTo.datepicker("destroy");
        }
    },

    _privateFunction: {
        createDatePicker: function (input, reference) {
            if (input && input != null) {
                input.datepicker({
                    dateFormat: Pe.GMD.UI.Web.Formato.Fecha,
                    onClose: function (selected) {
                        if (reference && reference != null) {
                            reference.datepicker('option', 'minDate', selected);
                        }
                    }
                });
            }
        }
    }
};
