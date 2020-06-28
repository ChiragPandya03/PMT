// JavaScript Document



$(document).ready(function(){
	
	$('[data-toggle="tooltip"]').tooltip();
	
	$('.navigationSection li a').click(function(){
		var getEleId = $(this).attr('data-taget');
		var offsetVal = $(getEleId).offset().top;
		
		$('.navigationSection li').removeClass('active');
		$(this).parent('li').addClass('active');
		$('html,body').animate({scrollTop:offsetVal - $('header').outerHeight()},1000);
	})
		
	$('.tabList li a').click(function(){
		var getContentId =  $(this).attr('data-content');
		
		$('.tabList li').removeClass('active');
		$('.tabContentSection .tabContent').hide();
		$(this).parent('li').addClass('active');
		$('.tabContentSection ' + '.'+getContentId).show();
	})
	
	$('.icon-navicon').click(function(){
		$('.icon-search').removeClass('active');
		$('.searchBox').hide();
		if($(this).hasClass('active')){
			$(this).removeClass('active');
			$('.navigationSection').hide();
			$('section,footer').removeClass('navOpen')
		}
		else{
			$(this).addClass('active');
			$('section,footer').addClass('navOpen')
			$('.navigationSection').show();
		}
	})
	
	$('.icon-search').click(function(){
		$('.icon-navicon').removeClass('active');
		$('.navigationSection').hide();
		if($(this).hasClass('active')){
			$(this).removeClass('active');
			$('.searchBox ').hide();
			$('section,footer').removeClass('navOpen')
		}
		else{
			$(this).addClass('active');
			$('section,footer').addClass('navOpen')
			$('.searchBox').show();
		}
	})
	
	$(document).on('click','.navOpen',function(){
		$('section,footer').removeClass('navOpen')
		$('.icon-navicon').removeClass('active');
		$('.navigationSection').hide();
		$('.icon-search').removeClass('active');
		$('.searchBox').hide();
	})
})