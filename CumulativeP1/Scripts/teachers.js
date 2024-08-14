// AJAX for teacher Add can go in here!
// This file is connected to the project via Shared/_Layout.cshtml
// it doen't work even I added http:// at the beginning

function AddTeacher() {

	//goal: send a request which looks like this:
	//POST : http://localhost:61978/api/TeacherData/AddTeacher
	//with POST data of fname, lname employeeNum, hire date, salary, etc.

	var URL = "http://localhost:61978/api/TeacherData/AddTeacher/";

	var rq = new XMLHttpRequest();
	// where is this request sent to?
	// is the method GET or POST?
	// what should we do with the response?
	var TeacherFname = document.getElementById('TeacherFname').value;
	var TeacherLname = document.getElementById('TeacherLname').value;
	var EmployeeNumber = document.getElementById('EmployeeNumber').value;
	var TeacherSalary = document.getElementById('TeacherSalary').value;
	var TeacherHireDate = document.getElementById('TeacherHireDate').value;

	var TeacherData = {
		"TeacherFname": TeacherFname,
		"TeacherLname": TeacherLname,
		"TeacherSalary": TeacherSalary,
		"EmployeeNumber": EmployeeNumber,
		"TeacherHireDate": TeacherHireDate
	};

	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		//ready state should be 4 AND status should be 200
		if (rq.readyState == 4 && rq.status == 200) {
			//request is successful and the request is finished

			//nothing to render, the method returns nothing.
			console.log(TeacherData);

		}

	}
	//POST information sent through the .send() method
	rq.send(JSON.stringify(TeacherData));

}


// Updated on 0814 copied from my previous error version: delete all validation and error track.
function UpdateTeacher(TeacherId) {


	//goal: send a request which looks like this:
	//POST : http://localhost:61978/api/TeacherData/EditTeacher/{id}
	//with POST data of teacherfname, teacherlname, employeenumber, salary and hiredate

	var URL = "http://localhost:61978/api/TeacherData/EditTeacher/" + TeacherId;

	var rq = new XMLHttpRequest();
	// where is this request sent to?
	// is the method GET or POST?
	// what should we do with the response?

	var TeacherFname = document.getElementById('TeacherFname').value;
	var TeacherLname = document.getElementById('TeacherLname').value;
	var EmployeeNumber = document.getElementById('EmployeeNumber').value;
	var TeacherSalary = document.getElementById('TeacherSalary').value;
	var TeacherHireDate = document.getElementById('TeacherHireDate').value;

	var TeacherData = {
		"TeacherFname": TeacherFname,
		"TeacherLname": TeacherLname,
		"TeacherSalary": TeacherSalary,
		"EmployeeNumber": EmployeeNumber,
		"TeacherHireDate": TeacherHireDate
	};

	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		//ready state should be 4 AND status should be 200
		if (rq.readyState == 4 && rq.status == 200) {
			//request is successful and the request is finished

			//nothing to render, the method returns nothing.


		}

	}
	//POST information sent through the .send() method
	rq.send(JSON.stringify(TeacherData));

}


// Updated on 0814 copied from my previous error version: delete all validation and error track.
// it partly works with the correct result link to SHOW page, just the inner HTML shows "null" for all of the teachers' names.

//The actual List Teachers Method.
function ListTeachers(SearchKey) {

	var URL = "http://localhost:61978/api/TeacherData/ListTeachers/" + SearchKey;

	// api link works well

	var rq = new XMLHttpRequest();
	rq.open("GET", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		//ready state should be 4 AND status should be 200
		if (rq.readyState == 4 && rq.status == 200) {
			//request is successful and the request is finished


			var teachers = JSON.parse(rq.responseText);
			console.log(teachers);
			// ->  all "null"
			// <example> null(with underline) null(with underline);

			var listteachers = document.getElementById("listteachers");
			listteachers.innerHTML = "";

			//renders content for each teacher pulled from the API call
			for (var i = 0; i < teachers.length; i++) {
				var row = document.createElement("div");
				row.classList = "listitem row";
				var col = document.createElement("col");
				col.classList = "col-md-12";
				var link = document.createElement("a");
				// row, col and links are added successfully in the browser.

				link.href = "/Teacher/Show/" + teachers[i].TeacherId;
				// links work well.
				
				link.innerHTML = teachers[i].TeacherFname + " " + teachers[i].TeacherLname;

				console.log(teachers[i].TeacherFname);
				console.log(teachers[i].TeacherLname);
				// all "null"

				col.appendChild(link);
				row.appendChild(col);
				listteachers.appendChild(row);

			}
		}

	}
	//POST information sent through the .send() method
	rq.send();
}



// try on 0814    ---------  seems works well

// This function attaches a timer object to the input window.
// When the timer expires (300ms), the search executes.
// Prevents a search on each key up for fast typers.
function _ListTeachers(d) {

	if (d.timer) clearTimeout(d.timer);
	d.timer = setTimeout(function () { ListTeachers(d.value); }, 300);
}
