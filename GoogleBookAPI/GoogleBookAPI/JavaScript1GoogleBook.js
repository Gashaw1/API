
var Titles = '';
//Adding row to existing table
var tableRow;



function subSearch(Titles)
{  

    var tableSubS = document.getElementById("tblSubSearch");
    var tableNewRow = tableSubS.insertRow(0);
    var tableCell = tableNewRow.insertCell(0);
    tableCell.innerHTML = Titles;    
}

function DisplayData(Title, Subtitle, Author, Discription, BookImage, Isbn) {

    
    Titles = Title;
    subSearch(Titles);
    var bookTable = document.getElementById("tblBook");
    //add row on existing table
    tableRow = bookTable.insertRow(0);
    tableRow2 = bookTable.insertRow(1);
    //to make space between rows
    tableRow2.insertCell(0).innerHTML = "</br></br>";
    //add cell to that new row
    var leftCell = tableRow.insertCell(0);
    var rightCell = tableRow.insertCell(0);
    var imgCell = tableRow.insertCell(0);

    leftCell

    leftCell.innerHTML = "Title : " + Title + "</br>" + Subtitle + "</br>" + Isbn;

    rightCell.innerHTML = "Author : </br>" + Author;

    imgCell.innerHTML = '<img src=' + BookImage + '>' + "</br>";

    //Count the row everytime new row add
    // myRowCount(bookTable);
};
////Return number of rows
//function myRowCount(bookTable) {

//    $('#userSearch').val(Titles);

//}

////Auto event fire
//window.setInterval(function () {
//   $('#btnSearch').click();
//}, 1000000);

function funAjax(url) {

    $.ajax({

        url: url,
        //pass the return url
        success: function (url) {
            //first jason object hairarchy
            var myItem = url.items;

            ////Loop the document
            for (var index = 0; index < myItem.length; index++) {

                var volumes = myItem[index].volumeInfo;


                var Title = myItem[index].volumeInfo.title;
                var Subtitle = myItem[index].volumeInfo.subtitle;
                var Discription = myItem[index].volumeInfo.description;

                var imgLink = myItem[index].volumeInfo.imageLinks;
                var BookImage = "";
                if (imgLink != undefined) {
                    BookImage = myItem[index].volumeInfo.imageLinks.smallThumbnail;
                }

                var ISBN = myItem[index].volumeInfo.industryIdentifiers;
                var testAuthor = myItem[index].volumeInfo.authors;

                var Authors = "";

                var ISBNs = "";

                if (testAuthor != undefined) {
                    for (var i = 0; i < testAuthor.length; i++) {
                        Authors += myItem[index].volumeInfo.authors[i] + "</br>";
                    }
                }
                if (ISBN != undefined) {

                    for (var j = 0; j < ISBN.length; j++) {
                        var myType = myItem[index].volumeInfo.industryIdentifiers[j].type;
                        var myISBN = myItem[index].volumeInfo.industryIdentifiers[j].identifier;

                        ISBNs += myType + " : " + myISBN + "</br>";

                    }
                }
                //Bind to table
                DisplayData(Title, Subtitle, Authors, Discription, BookImage, ISBNs);
            }

        }

    });
}

//main function
function myFun() {
    //$('#btnSearch').click(function ()
    //{
    //    var breaks = "";
    //    //user input
    //    var mySearch = $('#userSearch').val();

    //    //API url
    //    var url = "https://www.googleapis.com/books/v1/volumes";

    //    url += '?' + $.param({
    //        'q': mySearch
    //    });


    //    //Clear the table
    //    if (mySearch == "")
    //    {
    //        document.getElementById("tblBook").innerHTML = "";
    //    }
    //    else {
    //        //call ajax fun
    //        funAjax(url);
    //    }

    //});

    //update fun
    $("#userSearch").keyup(function ()
    {
    

        //user input
        var mySearch = $('#userSearch').val();
        if (mySearch != "") {
            //API url
            var url = "https://www.googleapis.com/books/v1/volumes";
            //var url = "http://localhost:55051/api/Department";
            url += '?' + $.param({
                'q': mySearch
            });
            //call funAjax()
            funAjax(url);
        }
        else {
            document.getElementById("tblSubSearch").innerHTML = "";
            document.getElementById("tblBook").innerHTML = "";

        }


    });
};




