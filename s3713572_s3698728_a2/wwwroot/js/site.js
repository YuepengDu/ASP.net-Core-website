// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})


$(function () {
	var scroll_offset = $("#transaction-account-content").offset();
	$(window).scroll(function () {
		var scrolltop = $(this).scrollTop();	
		if (scrolltop >= scroll_offset.top) {	
			$(".scrollSite").show();
		} else {
			$(".scrollSite").hide();
		}
	});
	$(".trigger-button-transaction-account").click(function () {
		$("html,body").animate({ scrollTop: scroll_offset.top }, 500);
	});
});

$(function () {
	var scroll_offset = $("#saving-account-content").offset();
	$(window).scroll(function () {
		var scrolltop = $(this).scrollTop();
		if (scrolltop >= scroll_offset.top) {
			$(".scrollSite").show();
		} else {
			$(".scrollSite").hide();
		}
	});
	$(".trigger-button-saving-account").click(function () {
		$("html,body").animate({ scrollTop: scroll_offset.top }, 500);
	});
});

$(function () {
	var scroll_offset = $("#credit-account-content").offset();
	$(window).scroll(function () {
		var scrolltop = $(this).scrollTop();
		if (scrolltop >= scroll_offset.top) {
			$(".scrollSite").show();
		} else {
			$(".scrollSite").hide();
		}
	});
	$(".trigger-button-credit-card").click(function () {
		$("html,body").animate({ scrollTop: scroll_offset.top }, 500);
	});
});