// It works! yeah!!!
function AjaxShowTeacher() {
    var TeacherId = document.getElementById("TeacherId").value;
    // alert("I'd like to show teachers!"); -> works well

    var url = "http://localhost:61978/api/TeacherData/FindTeacher/" + TeacherId;
    var rq = new XMLHttpRequest();

    rq.open("GET", url, true);
    rq.setRequestHeader("Content-Type", "application/json");
    rq.onreadystatechange = function () {
        if (rq.readyState == 4 && rq.status == 200) {
            var Teacher = JSON.parse(rq.responseText);

            console.log(Teacher.TeacherName);
            console.log(Teacher.EmployeeNumber);
            console.log(Teacher.TeacherHireDate);
            console.log(Teacher.TeacherSalary);

            document.getElementById("TeacherName").innerHTML = Teacher.TeacherName;
            document.getElementById("EmployeeNumber").innerHTML = Teacher.EmployeeNumber;
            document.getElementById("TeacherHireDate").innerHTML = Teacher.TeacherHireDate;
            document.getElementById("TeacherHireDate").innerHTML = Teacher.TeacherHireDate;

        }
    }

    rq.send();

}

