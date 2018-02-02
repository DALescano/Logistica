/*--------------------------------------------------------------------------------------------------------- 
RESIZE WINDOW SCROLL
**//*---------------------------------------------------------------------------------------------------- */

$(function (bodyResize) {
    $(window).resize(function () {
        $('.main-content').css("height", $(window).innerHeight() - 110);
    });
    $(window).trigger('resize');
});

/*--------------------------------------------------------------------------------------------------------- 
FUNCIONES
**//*---------------------------------------------------------------------------------------------------- */

var fixedTab = function(){

	$('.main-content').scroll(function(){

		var MenuFixed = $('.main-content').scrollTop();

		if(MenuFixed  > 55) {	
            $('.left-tabs').addClass('fixed-left-tab');
        }

        if (MenuFixed < 55) {
            $('.left-tabs').removeClass('fixed-left-tab');
        };

	});

};

var tipoCampo = function(){
    var selectedScheme = 'Select';
    
    $('#campo-form').change(function(){
        $('div.campo-mostrar-form').removeClass(selectedScheme).addClass($(this).val());
        selectedScheme = $(this).val();
    });
};


$(function(){  
	
});

