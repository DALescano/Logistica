ns('Pe.GMD.UI.Web.Common.Resources')
Pe.GMD.UI.Web.Common.Resources.LabelInformation = 'Información';
Pe.GMD.UI.Web.Common.Resources.LabelAceptConfirmation = 'Aceptar';
Pe.GMD.UI.Web.Common.Resources.LabelCancelConfirmation = 'Cancelar';
Pe.GMD.UI.Web.Common.Resources.LabelWarning = 'Advertencia';

/// Copyright (c) 2015.
/// All rights reserved.
/// <summary>
/// Controlador de Mensajes
/// </summary>
/// <remarks>
/// Creacion: 	GMD(CERS) 20150107 <br />
/// </remarks>
ns('Pe.GMD.UI.Web.Components.Message');
Pe.GMD.UI.Web.Components.Message = function (opts) {
    this.init(opts);
};

Pe.GMD.UI.Web.Components.Message.prototype = {
    init: function (opts) {
        this._privateFunction.createMessage.apply(this, [opts]);
        ResultConfirm = false;
    },

    //Information: function (opts) {
    //    opts.dialogClass = 'message-dialog-information';
    //    opts.position = { my: "right top", at: "right top", of: window };
    //    opts.title = opts.title ? opts.title : Pe.GMD.UI.Web.Common.Resources.LabelInformation;
    //    opts.title = '<strong>' + opts.title + ' : </strong>'
    //    opts.message = opts.title + opts.message;
    //    opts.message = '<div class="alert alert-success">' + opts.message + '</div>';
    //    opts.modal = false;
    //    opts.minWidth = 550;
    //    opts.minHeight = 60;
    //    this._privateFunction.show.apply(this, [opts]);
    //    if (this.divDialog) {
    //        var me = this;
    //        this.informationTimeOut = setTimeout(function () {
    //            //me.divDialog.close();
    //        }, 2500);
    //    }
    //},

    Information: function (opts) {
        var title = (opts.title == undefined || opts.title == null ? Pe.Stracon.SGSA.Presentacion.Base.TituloResource.EtiquetaTituloInformacion : opts.title);
        var message = (opts.message == undefined || opts.message == null ? Pe.Stracon.SGSA.Presentacion.Base.MensajeResource.SeGuardoInformacionExito : opts.message);

        var modal = BootstrapDialog.show({
            showCloseButton: false,
            type: BootstrapDialog.TYPE_INFO,
            title: '<h4 class="modal-title"><i></i>' + title + '</h4>',
            size: BootstrapDialog.SIZE_SHORT,
            message: '<div class="cont-critico"><span class="img-item-exito"></span><span class="texto-item">' + message + '</span></div></div>'
        });
        setTimeout(function () {
            modal.close();
        }, 1800);
    },

    InformationFormularioDetalle: function (opts) {
        var title = (opts.title == undefined || opts.title == null ? Pe.Stracon.SGSA.Presentacion.Base.TituloResource.EtiquetaTituloInformacion : opts.title)
        var message = (opts.message == undefined || opts.message == null ? Pe.Stracon.SGSA.Presentacion.Base.MensajeResource.SeGuardoInformacionExito : opts.message)

        var modal = BootstrapDialog.show({
            title: '<h4 class="modal-title"><i></i>' + title + '</h4>',
            size: BootstrapDialog.SIZE_LARGE,
            message: '<div class="cont-critico"><span class="img-item-exito"></span><span class="texto-item">' + message + '</span></div></div>',
            //buttons: [{
            //    label: Pe.Stracon.SGSA.Presentacion.Base.GenericoResource.BotonAceptar,
            //    cssClass: 'btn-cancelar-form',
            //    action: function (dialogItself) {
            //        dialogItself.close();
            //    }
            //}]
        });
        setTimeout(function () {
            modal.close();
        }, 1800);
    },

    InformationCustom: function (opts) {
        var me = this;
        opts.dialogClass = 'message-dialog-informationCustom';
        opts.position = { my: "right top", at: "right top", of: window };
        opts.title = opts.title ? opts.title : Pe.GMD.UI.Web.Common.Resources.LabelInformation;
        opts.title = '<strong>' + opts.title + ' : </strong>'
        opts.message = opts.title + opts.message;
        opts.message = '<div class="alert alert-success">' + opts.message + '</div>';
        opts.modal = true;
        opts.minWidth = 550;
        opts.minHeight = 60;
        opts.buttons = [{
            text: opts.textConfirmar ? opts.textConfirmar : Pe.GMD.UI.Web.Common.Resources.LabelAceptConfirmation,
            'class': 'ui-button-Confirmar',
            click: function () {
                if (me.divDialog) {
                    me.divDialog.close();
                }
            }
        }
        ];
        this._privateFunction.show.apply(this, [opts]);
    },
    ResultConfirm: false,
    Confirmation: function (opts) {
        var title = (opts.title == undefined || opts.title == null ? Pe.Stracon.SGSA.Presentacion.Base.TituloResource.TituloConfirmarGuardar : opts.title);
        var message = (opts.message == undefined || opts.message == null ? Pe.Stracon.SGSA.Presentacion.Base.MensajeResource.ConfirmacionGuardar : opts.message);
        var indicadorModal = (opts.indicadorModal == undefined || opts.indicadorModal == null ? true : opts.indicadorModal);

        BootstrapDialog.show({
            title: '<h4 class="modal-title"><i></i>' + title + '</h4>',
            size: BootstrapDialog.SIZE_LARGE,
            message: '<div class="cont-critico"><span class="img-item-exito"></span><span class="texto-item">' + message + '</span></div></div>',
            buttons: [{
                label: Pe.Stracon.SGSA.Presentacion.Base.GenericoResource.EtiquetaNo,
                cssClass: 'btn-cancelar-form',
                action: function (dialogItself) {
                    if (opts.onCancelDialog != undefined && opts.onCancelDialog != null && opts.onCancelDialog != '') {
                        opts.onCancelDialog();
                    }
                    dialogItself.close();
                }
            },
            {
                label: Pe.Stracon.SGSA.Presentacion.Base.GenericoResource.EtiquetaSiGrabar,
                cssClass: 'btn-guardar-form',
                action: function (dialogItself) {
                    //setTimeout(function () {
                    if (opts.onConfirm) {
                        opts.onConfirm(true);
                    }
                    if (opts.onAccept) {
                        opts.onAccept();
                    }
                    ////}, 100);
                    //if (indicadorModal) {
                    //    BootstrapDialog.closeAll();
                    //}
                    //else {
                    dialogItself.close();
                    // }
                }
            }]
        });
    },

    Delete: function (opts) {
        BootstrapDialog.show({
            title: '<h4 class="modal-title"><i></i>' + Pe.Stracon.SGSA.Presentacion.Base.TituloResource.EtiquetaTituloEliminar + '</h4>',
            size: BootstrapDialog.SIZE_LARGE,
            message: '<div class="cont-critico"><span class="img-item-eliminar"></span><span class="texto-item">' + Pe.Stracon.SGSA.Presentacion.Base.MensajeResource.ConfirmacionEliminacion + '  </span></div></div>',
            buttons: [{
                label: Pe.Stracon.SGSA.Presentacion.Base.GenericoResource.EtiquetaNo,
                cssClass: 'btn-cancelar-form',
                action: function (dialogItself) {
                    dialogItself.close();
                }
            },
            {
                label: Pe.Stracon.SGSA.Presentacion.Base.GenericoResource.EtiquetaSiEliminar,
                cssClass: 'btn-guardar-form',
                action: function (dialogItself) {
                    //setTimeout(function () {
                    if (opts.onConfirm) {
                        opts.onConfirm(true);
                    }
                    if (opts.onAccept) {
                        opts.onAccept();
                    }
                    //}, 100);
                    dialogItself.close();
                    //BootstrapDialog.closeAll();
                }
            }]
        });
    },

    //Warning: function (opts) {
    //    opts.dialogClass = 'message-dialog-warning';
    //    opts.title = opts.title ? opts.title : Pe.GMD.UI.Web.Common.Resources.LabelWarning;
    //    opts.message = '<div class="alert alert-warning">' + opts.message + '</div>';
    //    this._privateFunction.show.apply(this, [opts]);
    //},

    Warning: function (opts) {
        var title = (opts.title == undefined || opts.title == null ? Pe.Stracon.SGSA.Presentacion.Base.TituloResource.EtiquetaTituloAdvertencia : opts.title)
        var message = (opts.message == undefined || opts.message == null ? Pe.Stracon.SGSA.Presentacion.Base.MensajeResource.EtiquetaMensajeAdvertencia : opts.message)

        BootstrapDialog.show({
            title: '<h4 class="modal-title"><i></i>' + title + '</h4>',
            size: BootstrapDialog.SIZE_LARGE,
            message: '<div class="cont-critico"><span class="img-item-critico"></span><span class="texto-item">' + message + '</span></div></div>',
            buttons: [{
                label: Pe.Stracon.SGSA.Presentacion.Base.GenericoResource.BotonAceptar,
                cssClass: 'btn-cancelar-form',
                action: function (dialogItself) {
                    if (opts.callbackClose != undefined || opts.callbackClose != null)
                        opts.callbackClose();
                    dialogItself.close();
                }
            }]
        });
    },

    Error: function (opts) {
        var title = (opts.title == undefined || opts.title == null ? Pe.Stracon.SGSA.Presentacion.Base.TituloResource.EtiquetaTituloEliminar : opts.title)
        var message = (opts.message == undefined || opts.message == null ? Pe.Stracon.SGSA.Presentacion.Base.MensajeResource.EtiquetaMensajeAdvertencia : opts.message)
        BootstrapDialog.show({
            title: '<h4 class="modal-title"><i></i>' + title + '</h4>',
            size: BootstrapDialog.SIZE_LARGE,
            message: '<div class="cont-critico"><span class="img-item-critico"></span><span class="texto-item">' + message + '</span></div></div>',
            buttons: [{
                label: Pe.Stracon.SGSA.Presentacion.Base.GenericoResource.BotonAceptar,
                cssClass: 'btn-cancelar-form',
                action: function (dialogItself) {
                    if (opts.callbackClose != undefined || opts.callbackClose != null)
                        opts.callbackClose();
                    dialogItself.close();
                }
            }]
        });
        /*opts.dialogClass = 'message-dialog-error';
        opts.title = opts.title ? opts.title : 'Error';
        opts.message = '<div class="alert alert-danger">' + opts.message + '</div>';
        this._privateFunction.show.apply(this, [opts]);*/
    },

    setMessage: function (message) {
        this.divDialog.setContent(message);
    },

    onClose: null,

    destroy: function () {
        if (this.divDialog) {
            this.divDialog.destroy();
        }
    },
    _privateFunction: {
        createMessage: function (opts) {
            var me = this;
            this.divDialog = new Pe.GMD.UI.Web.Components.Dialog({
                closeOnEscape: false,
                close: function (event, ui) { if (me.onClose && me.onClose != null) { me.onClose(event, ui); } },
                resizable: false,
                closeText: "Close",
                width: 300
            });
            this.divDialog.setClass('message-dialog-confirmation');
        },
        show: function (opts) {
            if (this.divDialog) {
                if (this.informationTimeOut) {
                    clearTimeout(this.informationTimeOut);
                }
                //opts.position = opts.position ? opts.position : { my: "center", at: "center", of: window };
                opts.modal = opts.modal == false ? opts.modal : true;
                //this.divDialog.setPosition(opts.position);
                //this.divDialog.close();
                //this.onClose = opts.onClose ? opts.onClose : null;
                //this.divDialog.setTitle(opts.title);
                //this.setMessage(opts.message);
                //this.divDialog.setButtons(opts.buttons);
                //this.divDialog.setClass(opts.dialogClass);
                //this.divDialog.setModal(opts.modal);
                //this.divDialog.setMinWidth(opts.minWidth);
                //this.divDialog.setMinHeight(opts.minHeight);
                //this.divDialog.open();
            }
        }
    }
};
