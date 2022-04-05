
function Excelexport(id, sheetname) {
    var wb = XLSX.utils.table_to_book(document.getElementById(id), { sheet: sheetname, raw: true });
    var d = new Date();
    var today = d.getFullYear() + d.getMonth() + d.getDate() + d.getHours() + d.getMinutes() + d.getSeconds();

    XLSX.writeFile(wb, today + "_PAPERPOP.xlsx")
}

function Test(msg) {
    alert(msg);
}

function TestJquery() {
    $(function () {
        var tempTable = $("#testExportId").html();
        $("#testExportId .excludeExport").remove();
        $("#testExportId").html(tempTable);
    })
}

function RemoveTag() {
    var tempTable = $("#testExportId").html();
    $("#testExportId .excludeExport").remove();

    Excelexport("testExportId", "1");

    $("#testExportId").html(tempTable);
    
}

document.qu