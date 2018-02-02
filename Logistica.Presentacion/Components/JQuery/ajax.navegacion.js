/* @TheDiegaso */ /*DAGC*/

$.ajaxSetup({
    beforeSend: function () {
        $('body').addClass('loading');
    },
    complete: function () {
        $('body').removeClass('loading');
    }
});

var navSlide = function(){
    
};

navSlide.prototype = {
  selectores : function(){
  this.$html = $('html'),
        this.$wrap = $('.view-wrap'),
        this.$btnAjx = $('.nav_ajx');
        this.eventAjx();
    },
    eventAjx : function(){
    var that = this;
    this.$html.on('click','.nav_ajx',function(event){
    event.preventDefault();
    var url = $(this).attr('href'),
              $el = $(this);
    if(!url || url == '' || url == '#'){
    alert("Ingrese Ruta");
    }else{
            if(!$el.hasClass('btn_inner')){
              that.$btnAjx.removeClass('active');
            }          
            $el.addClass('active');
            that.navAjx(url,function(){
                $('.main-content').animate({
                    scrollTop: 0
                }, 400);
            });
          }  
    })
    },
    navAjx : function(url, callback){ 
        var that = this; 
        $.ajax({
          url : url,
          success:function(data){    
            that.$wrap.empty();
            that.$wrap.html(data);
            if (typeof callback == 'function') { callback(); }
          }
        });  
    },
    init : function(){
    this.selectores();
    }
}

var navSlide = new navSlide();

$(function(){
    navSlide.init();
    navSlide.navAjx('../Views/listado_records.html');
});



