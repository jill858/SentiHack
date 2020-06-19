var url = "https://apis.sentient.io/microservices/utility/csvtojson/v1.0/getresults";
var apikey = "C0DD235378A94213B9BF";
var result[];
var fileInput = document.getElementById("csv"),

    readFile = function () {
        var reader = new FileReader();
        reader.onload = function () {
            document.getElementById('out').innerHTML = reader.result;
        };
        // start reading the file. When it is done, calls the onload event defined above.
        reader.readAsBinaryString(fileInput.files[0]);
    };

fileInput.addEventListener('change', readFile);

function upload(fileInput) {
    $.ajax({
        url: url,
        type: "get", //send it through get method
        data: {
            x- api - key: apikey,
        csvfile: fileInput
        },
        success: function (response) {
            console.log(response);
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
}