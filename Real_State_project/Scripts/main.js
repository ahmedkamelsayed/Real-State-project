$(function () {
    
    'use strict';
    
    var navbar = $('.navbar');
    var carousel = $('.carousel');
    $(window).scroll(function (){
        
        if ($(window).scrollTop() >= carousel.height())
        {
            navbar.addClass('scrolled');
        } else {
            
            navbar.removeClass('scrolled');
        }
        
    });
    
    // change tabs selected
    $('.tab-switch li').click(function () {
        
        $(this).addClass('selected').siblings().removeClass('selected');
        
        $('.tabs .tabs-content div').hide();
          
        $('.' + $(this).data('class')).fadeIn(1000);
            
 
    });
    
});


// popup show and hidden
var TheLogin = document.getElementById("loginButton");
var TheRegister = document.getElementById("registerButton");

function Openlogin() { TheLogin.style.transform = "scale(1)" }
function Openregister() { TheRegister.style.transform = "scale(1)" }

function Closelogin() { TheLogin.style.transform = "scale(0)" }
function Closeregister() { TheRegister.style.transform = "scale(0)" }


// OpenAddForm in admin page popup

var addform = document.getElementById("MyDiv");

function OpenAddForm()
{
    addform.style.transform = "scale(1)";
    addform.style.top = "10px";
}

function closeAddForm()
{
    addform.style.transform = "scale(0)"
    addform.style.top = "-400px";
}