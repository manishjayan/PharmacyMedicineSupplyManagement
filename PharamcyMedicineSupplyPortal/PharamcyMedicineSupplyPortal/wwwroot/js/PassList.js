$(document).ready(function () {
    $("#btnAddRecords").click(function () {
        AddMedicineDemand();
    });

    $("#btnSaveData").click(function () {
        SaveMedicineRecords();
    });
});

function AddMedicineDemand() {
    var MedicineDemand = "<tr><td>" + $("#txtMedicine").val() + "</td><td>" + $("#txtCount").val() + "</td></tr>";
    $("#medi-table").last().append(MedicineDemand);
    $("#txtMedicine").val("");
    $("#txtCount").val("");
}
function SaveMedicineRecords() {
    var listOfMedicine = new Array();
    $("#medi-table").find("tr:gt(0)").each(function () {
        var Medicine = $(this).find("td:eq(0)").text();
        var Count = $(this).find("td:eq(1)").text();


        var MedicineDemand = {};
        MedicineDemand.Medicine = Medicine;
        MedicineDemand.DemandCount = Count;
        listOfMedicine.push(MedicineDemand);

    });
    $.ajax({
        async: true,
        type: "POST",
        dataType: "Text",
        /*contentType: "application/json; charset = utf-8",*/
        url: "/MedicineSupply/InputDemand",
        data: { "listOfMedicine": listOfMedicine },
        //success: function (listofMedicine) {
            
        //},
        //error: function () {
        //    alert("Enter Correct Data");
        //}
        success: function (res) {

            alert("Generated Successfully");

            $("#resultList").html(res);
        },
        error: function () {
            alert("Enter Correct Data");
        }

    });

}