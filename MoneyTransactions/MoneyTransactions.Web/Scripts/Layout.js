$(window).on('load', function () {
    // 1. first load for sell and buy    

    $.ajax({
        // edit to add steve's suggestion.
        //url: "/ControllerName/ActionName",
        url: '/Home/UpdateMoney',
        type: 'get',
        data: { moneyType: "Bitcoin" },
        success: function (data) {
            // your data could be a View or Json or what ever you returned in your action method 
            // parse your data here            
            $("#forSell").html(numberWithCommas(data));
            // for buy substract some money            
            data = data - 1321275;
            $("#forBuy").html(numberWithCommas(data));
        },
        error: function (response, textStatus) {
            console.log(response);
            console.log(textStatus);
        }
    });
});

function MoneyBitcoin() {
    // scenario
    // get action from controller to get db from there
    // and load here    
    var bitcoina = document.getElementById("bitcoinalink").innerHTML;

    $.ajax({
        // edit to add steve's suggestion.
        //url: "/ControllerName/ActionName",
        url: '/Home/UpdateMoney',
        type: 'get',
        data: { moneyType: bitcoina },
        success: function (data) {
            // your data could be a View or Json or what ever you returned in your action method 
            // parse your data here            
            $("#forSell").html(numberWithCommas(data));
            // for buy substract some money            
            data = data - 1321275;
            $("#forBuy").html(numberWithCommas(data));
        },
        error: function (response, textStatus) {
            console.log(response);
            console.log(textStatus);
        }
    });
}

function MoneyEthereum() {
    // scenario
    // get action from controller to get db from there
    // and load here        
    var ethereuma = document.getElementById("ethereumalink").innerHTML;

    $.ajax({
        // edit to add steve's suggestion.
        //url: "/ControllerName/ActionName",
        url: '/Home/UpdateMoney',
        type: 'get',
        data: { moneyType: ethereuma },
        success: function (data) {
            // your data could be a View or Json or what ever you returned in your action method 
            // parse your data here            
            $("#forSell").html(numberWithCommas(data));

            // ubstract
            data = data - 120394;
            $("#forBuy").html(numberWithCommas(data));
        },
        error: function (response, textStatus) {
            console.log(response);
            console.log(textStatus);
        }
    });
}


function MoneyRipple() {
    // scenario
    // get action from controller to get db from there
    // and load here       

    var ripplea = document.getElementById("ripplealink").innerHTML;

    $.ajax({
        // edit to add steve's suggestion.
        //url: "/ControllerName/ActionName",
        url: '/Home/UpdateMoney',
        type: 'get',
        data: { moneyType: ripplea },
        success: function (data) {
            // your data could be a View or Json or what ever you returned in your action method 
            // parse your data here            
            $("#forSell").html(numberWithCommas(data));
            data = data - 129;
            $("#forBuy").html(numberWithCommas(data));
        },
        error: function (response, textStatus) {
            console.log(response);
            console.log(textStatus);
        }
    });
}

function GetMoneyForCreateSellAd() {

    var e = document.getElementById("select_coin");
    var strUser = e.options[e.selectedIndex].value;

    $.ajax({
        // edit to add steve's suggestion.
        //url: "/ControllerName/ActionName",
        url: '/Home/UpdateMoney',
        type: 'get',
        data: { moneyType: strUser },
        success: function (data) {
            // filled data
            var coin = document.getElementById("sell_price_ad");
            coin.value = numberWithCommas(data);
        },
        error: function (response, textStatus) {
            console.log(response);
            console.log(textStatus);
        }
    });
}


function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}

function Selladselectedcoin(your_coin) {
    // scenairio
    // select: bitcoin -> show money of bitcoin
    // select : ethereum -> show money of ehthereum

    var selectBox = document.getElementById("select_coin");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;

    $.ajax({
        // edit to add steve's suggestion.
        //url: "/ControllerName/ActionName",
        url: '/Home/UpdateMoney',
        type: 'get',
        data: { moneyType: selectedValue.toString() },
        success: function (data) {
            // filled data
            var coin = document.getElementById("sell_price_ad");
            coin.value = numberWithCommas(data);
        },
        error: function (response, textStatus) {
            console.log(response);
            console.log(textStatus);
        }
    });
}