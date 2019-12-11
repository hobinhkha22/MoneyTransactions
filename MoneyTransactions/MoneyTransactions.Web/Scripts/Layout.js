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
            $("#showcoin").html(selectedValue.toString().toUpperCase());
            coin.value = numberWithCommas(data);
        },
        error: function (response, textStatus) {
            console.log(response);
            console.log(textStatus);
        }
    });

    // find wallet and fill data
    $.ajax({
        // edit to add steve's suggestion.
        //url: "/ControllerName/ActionName",
        url: '/Home/FindWallet',
        type: 'get',
        data: { moneyType: selectedValue },
        success: function (data) {
            // fill bitcoin address
            var coinaddress = document.getElementById("diachivimoney");
            coinaddress.value = data;

        },
        error: function (response, textStatus) {
            console.log(response);
            console.log(textStatus);
        }
    });
}


function BuyAdSelectedCoin() {
    // scenairio
    // select: bitcoin -> show money of bitcoin
    // select : ethereum -> show money of ehthereum

    var selectBox = document.getElementById("select_buy_coin");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;

    $.ajax({
        // edit to add steve's suggestion.
        //url: "/ControllerName/ActionName",
        url: '/Home/UpdateMoney',
        type: 'get',
        data: { moneyType: selectedValue.toString() },
        success: function (data) {
            // filled data
            var coin = document.getElementById("buy_price_ad");
            $("#buyshowcoin").html(selectedValue.toString().toUpperCase());
            coin.value = numberWithCommas(data);
        },
        error: function (response, textStatus) {
            console.log(response);
            console.log(textStatus);
        }
    });

    // find wallet and fill data
    $.ajax({
        // edit to add steve's suggestion.
        //url: "/ControllerName/ActionName",
        url: '/Home/FindWallet',
        type: 'get',
        data: { moneyType: selectedValue },
        success: function (data) {
            // fill bitcoin address
            var coinaddress = document.getElementById("diachivimoneybuy");
            coinaddress.value = data;

        },
        error: function (response, textStatus) {
            console.log(response);
            console.log(textStatus);
        }
    });
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

function UserInputQuicktrade() {

    // sleep
    sleep(1000);

    // getdata
    var getDataSoLuongMoney = document.getElementById("soLuongMoney").value;
    console.log(getDataSoLuongMoney);
    var show = document.getElementById("showPageForMuaTu");
    show.innerHTML = "";

    $.ajax({
        // edit to add steve's suggestion.
        //url: "/ControllerName/ActionName",
        url: '/Home/GetListOrder',
        type: 'post',
        data: { amountSearch: getDataSoLuongMoney },
        success: function (data) {
            // fill bitcoin address                       
            //console.log(JSON.parse(data));
            if ($.trim(data)) {
                var array = JSON.parse(data);
                array.forEach(function (object) {
                    //console.log(object.OrderID);
                    console.log(object);
                    console.log(JSON.parse(data));                    
                    show.innerHTML += "<div style='margin-bottom: 5px;'>" +
                        "<div class='row' style='background-color:#e6e6e6;padding-top: 25px; margin: 0 auto;'>" +
                        "<div class='col-sm-10'>" +
                        "<p>Tài khoản: " + object.Wallet.Account.UserName + "</p>" +
                        "<p>Giá: " + object.Price + "</p>" +
                        "<p>Số lượng: " + object.Amount + " </p>" +
                        "</div>" +
                        "<div class='col-sm-2'>" +
                        //"@Html.ActionLink('Mua ngay', 'Details', 'Account', null, htmlAttributes: new { @class = 'btn btn-danger' })" +
                        "<a href='/Account/Details?walletID=" + object.Amount + "&amount=" + object.Price + "' class='btn btn-danger'>Mua ngay</a>" +
                        "</div>" +
                        "</div>" +
                        "</div>";
                });
            }
        },
        error: function (response, textStatus) {
            console.log(response);
            console.log(textStatus);
        }
    });
}

function UserInputQuicktradeForSell() {

    // sleep
    sleep(1000);

    // getdata
    var getDataSoLuongMoney = document.getElementById("soLuongMoneySellFor").value;
    console.log(getDataSoLuongMoney);
    var show = document.getElementById("showforSellFor");
    show.innerHTML = "";

    $.ajax({
        // edit to add steve's suggestion.
        //url: "/ControllerName/ActionName",
        url: '/Home/GetListOrder',
        type: 'post',
        data: { amountSearch: getDataSoLuongMoney },
        success: function (data) {
            // fill bitcoin address                       
            //console.log(JSON.parse(data));
            if ($.trim(data)) {
                var array = JSON.parse(data);
                array.forEach(function (object) {
                    //console.log(object.OrderID);
                    console.log(object);
                    console.log(JSON.parse(data));
                    show.innerHTML += "<div style='margin-bottom: 5px;'>" +
                        "<div class='row' style='background-color:#e6e6e6;padding-top: 25px; margin: 0 auto;'>" +
                        "<div class='col-sm-10'>" +
                        "<p>Tài khoản: " + object.Wallet.Account.UserName + "</p>" +
                        "<p>Số lượng: " + object.Amount + " </p>" +
                        "</div>" +
                        "<div class='col-sm-2'>" +
                        "<a href='/Account/Details?walletID=" + object.Amount + "&amount=" + object.Price + "' class='btn btn-success'>Bán ngay</a>" +
                        "</div>" +
                        "</div>" +
                        "</div>";
                });
            }
        },
        error: function (response, textStatus) {
            console.log(response);
            console.log(textStatus);
        }
    });
}

