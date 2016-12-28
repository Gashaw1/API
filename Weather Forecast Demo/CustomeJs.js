var userInput = '';
var dF = '°F';

$(document).ready(function () {
    var el = document.getElementById("th1");
    //default city on page load first time
    userInput = "Atlanta";
    funWeatherCast(userInput);
    $("#Button1").click(function () {
        userInput = $('#txtInput').val();
        funWeatherCast(userInput);
    });
    function funWeatherCast(datas) {
        $.ajax(
          {
              url: 'http://api.openweathermap.org/data/2.5/forecast/daily? &mode=json&units=imperial&cnt=7&appid=" api key gose here"',
              data: { q: userInput },
              dataType: 'json',
              success: function (data) {
                  if (data.cod == "404") {
                      el.style.color = "Red";
                      el.innerHTML = "Invalid Request!";
                  }
                  else {
                      el.style.color = "Green";
                      // el.style.textDecorationUnderline = true;
                      el.innerHTML = data.city.country;
                      CreateRowColumn(data);
                  }
              }
          });
    }
});
//Create rows and column
function CreateRowColumn(data)
 {

    var tableRow;
    var leftCell, rightCell;
    var i = 0;
    var myTable = document.getElementById("table1");

    //Clear innerHTML from table1
    if(myTable.innerHTML != " ")
    {
       myTable.innerHTML = " ";
    }
    // var tableRow = myTable.insertRow(i);
    for (i = 0; i < data.list.length; i++)
    {
        var temps = data.list[i].temp;
        var weathers = data.list[i].weather;

        var imgIcon =  weathers[0].icon;
        var day = temps.day;
        var min = temps.min;
        var max = temps.max;
        var night = temps.night;
        var eve = temps.eve;
        var morn = temps.morn;


        tableRow = myTable.insertRow(0);
        rightCell= tableRow.insertCell(0);
        leftCell = tableRow.insertCell(0);

        leftCell.innerHTML = "DAy : " + day + " </br>MIN : " + min + "</br>MAX : " +
        max + "</br>NIGHT : " + night + "</br> EVE : " + eve + "</br>MORN : " + morn;


        rightCell.innerHTML = '<img src="http://openweathermap.org/img/w/' + imgIcon + '.png">' + '\xa0' + 'F';
    }
}
