$(document).ready(function () {

    $(document).on("change", "#selectedManager", function () {
        var selectedValue = $('#selectedManager').find(":selected").val();

        $.ajax({
            url: '/Employee/LoadEmployeesAjax',
            type: 'POST',
            //async:false,
            data: { managerId: selectedValue},
            //contentType: 'application/json',
            success: function (data) {
                var tbl = $('#tblEmployee > tbody');
                tbl.empty();
                tbl.append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(textStatus);
            }
        });
    });

//    $(document).on("click", ".btn-save", function () {
//        var employeeId = $('#EmployeeId');

//        $.ajax({
//            url: '/Employee/ValidateEmployee',
//            type: 'POST',
//            //async:false,
//            data: { employeeId: employeeId.val()},
//            //contentType: 'application/json',
//            success: function (data) {
//                if (data) {
//                    alert('Employee Id already existed, please enter another!');
//                    return false;
//                }
//            },
//            error: function (jqXHR, textStatus, errorThrown) {
//                alert(textStatus);
//            }
//        });
//    });
})