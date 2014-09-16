$(document).ready(function () { 
    //get file size
    function GetFileSize(fileid) {
        try {
            var fileSize = 0;
     
                fileSize = $("#" + fileid)[0].files[0].size //size in kb
                fileSize = fileSize / 1048576; //size in mb
            
            return fileSize;
        }
        catch (e) {
            alert("Error is :" + e);
        }
    }



$("#btnSubmit").on("click", function () {
    if ($('#fileToUpload').val() == "") {
        $("#spanfile").html("Please upload file");
        return false;
    }
    else {
        return checkfile();
    }
});

    $("#btnDelete").on("click", function () {
        $.ajax({
            type: "POST",
            routeTemplate: "/api/championship/delete",
            success: function () { console.log("Bien") },
            error: function (mgs) { console.log("Malo") + mgs }
        })
       
    });


function checkfile() {
    
        var size = GetFileSize('fileToUpload');
        if (size > 10) {
            $("#spanfile").text("You can upload file up to 10 MB");
            return false;
        }
        else {
            $("#spanfile").text("");
        }
    
}

$(function () {
    $("#fileToUpload").change(function () {
        checkfile();
    });
});
});