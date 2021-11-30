// const SERVER = "http://localhost:59089/";
const SERVER = "http://172.16.193.234:17217/lab03/";

const CONTROLLER_DEFAULT_PATH = SERVER + 'api/students.json/';
const CONTROLLER_DEFAULT_XML_PATH = SERVER + 'api/students.xml/';

let pagesNumber = 0;
let StudentList = [];

let curOffset = 0;
let curLimit = 5;

let updateForm = $("#update-form");
let addForm = $("#add");
let searchForm = $("#search");

let isXml = () => $("#xml").prop("checked");

let testRequestParams;

function addStudentHandler() {

    addForm.find("button").on('click', () => {
        let requestParams;

        if (isXml()) {
            requestParams = {
                url: CONTROLLER_DEFAULT_XML_PATH,
                type: 'POST',
                headers: { 'Accept': 'application/xml' },
                data: addForm.serialize()
            };
        }

        else {
            requestParams = {
                url: CONTROLLER_DEFAULT_PATH,
                type: 'POST',
                headers: { 'Accept': 'application/json' },
                data: addForm.serialize()
            };
        }

        $.ajax(requestParams)
            .done((res) => {
                if (isXml()) { res = parser.parse(res).Root; }

                let studRes = 'Student ' + res.name + ' Successful! Student ID - #' + res.id;
                showAlert("Success", studRes);
            })

            .fail((jqXhr, textStatus, errorThrown) => {
                showAlert('Error', errorThrown);
            });
    });
}

function removeStudent(id) {
    let requestParams;

    if (isXml()) {
        requestParams = {
            url: (CONTROLLER_DEFAULT_XML_PATH + id),
            type: 'delete'
        };
    }
    else {
        requestParams = {
            url: (CONTROLLER_DEFAULT_PATH + id),
            type: 'delete'
        };
    }

    $.ajax(requestParams)
        .done((res) => {
            if (isXml()) { res = parser.parse(res).Root; }
            
            showAlert('Info', 'Student ' + res.name + ' deleted.');
            getAllStudents();
        })

        .fail((jqXhr, textStatus, errorThrown) => {
            showAlert('Error', errorThrown);
        });

}

function searchStudentsHandler() {

    searchForm.find("button").on('click', () => {
        searchStudents(false);
    });

}

function searchStudents(all) {
    let requestParams;

    if (isXml()) {
        requestParams = {
            url: `${CONTROLLER_DEFAULT_XML_PATH}?${searchForm.serialize()}`,
            type: 'get',
            headers: { 'Accept': 'application/xml' }
        };
    }
    else {
        requestParams = {
            url: `${CONTROLLER_DEFAULT_PATH}?${searchForm.serialize()}`,
            type: 'get',
            headers: { 'Accept': 'application/json' }
        };
    }

    $.ajax(requestParams)
        .done((res) => {
            if (isXml()) {
                res = parser.parse(new XMLSerializer().serializeToString(res.documentElement)).ArrayOfStudent.Student;
            }
            
            StudentList = res;
            updateStudentList(StudentList);
        })

        .fail((jqXhr, textStatus, errorThrown) => {
            showAlert('danger', errorThrown);
        });
}

function showAlert(type, text) {

    if (type == '' || type == undefined)
        type = 'Info';

    $('#alert-text').text(text);
    
    $('#alert').toggleClass('alert-' + type);

    $('#alert').fadeIn().delay(5500).fadeOut();
}

function updateStudentList(students) {

    $('#student-list > tbody').empty();

    for (let index in students) {

        let studRow;

        let stud = students[index];

        let removeBtn;
        let editBtn;

        let resLink = "";

        if ((typeof stud === "number") && isXml()) {

            editBtn = '<button onclick="showEditModal(' + 1 + ')" class="btn btn-info">Edit</button>';
            removeBtn = '<button onclick="removeStudent(' + students.id + ')" class="btn btn-danger">Remove' + '</button>';
           
            resLink = '<a href="'
                + students._links.self + '">student.xml/'
                + stud + '</a>';

            studRow = '<tr id="student-'
                + students.id + '"><td>'
                + (students.id == -1 ? "" : students.id) + '</td><td>'
                + students.name + '</td><td>'
                + students.phone + '</td><td>'
                + editBtn + ' ' + removeBtn + '</td><td>'
                + resLink + '</td><tr>';
        }

        else if (isXml() && (typeof stud === "object")) {

            editBtn = '<button onclick="showEditModal(' + index + ')" class="btn btn-info">Edit</button>';
            removeBtn = '<button onclick="removeStudent(' + stud.id + ')" class="btn btn-danger">Remove' + '</button>';

            resLink = '<a href="'
                + stud._links.self + '">student.xml/'
                + stud.id + '</a>';

            studRow = '<tr id="student-'
                + stud.id + '"><td>'
                + (stud.id == -1 ? "" : stud.id) + '</td><td>'
                + stud.name + '</td><td>'
                + stud.phone + '</td><td>'
                + editBtn + ' ' + removeBtn + '</td><td>'
                + resLink + '</td><tr>';
        }

        else {

            editBtn = '<button onclick="showEditModal(' + index + ')" class="btn btn-info">Edit</button>';
            removeBtn = '<button onclick="removeStudent(' + stud.id + ')" class="btn btn-danger">Remove'+ '</button>';

            resLink = '<a href="'
                + stud._links.self + '">student.json/'
                + stud.id + '</a>';

            studRow = '<tr id="student-'
                + stud.id + '"><td>'
                + (stud.id == -1 ? "" : stud.id) + '</td><td>'
                + stud.name + '</td><td>'
                + stud.phone + '</td><td>'
                + editBtn + ' ' + removeBtn + '</td><td>'
                + resLink + '</td><tr>';
        }

        $('#student-list > tbody').append(studRow);
    }
}

function updateStudent(studId) {
    let requestParams;

    if (isXml()) {
        requestParams = {
            url: CONTROLLER_DEFAULT_XML_PATH + studId,
            type: 'put',
            headers: { 'Accept': 'application/xml' },
            data: updateForm.serializeArray()
        };
    }
    else {
        requestParams = {
            url: CONTROLLER_DEFAULT_PATH + studId,
            type: 'put',
            headers: { 'Accept': 'application/json' },
            data: updateForm.serializeArray()
        };
    }

    $.ajax(requestParams)
        .done((res) => {
            if (isXml()) { res = parser.parse(res).Root; }

            let studRes = 'Student successfuly updated!' + res.id;
            showAlert("Success", studRes);
        })

        .fail((jqXhr, textStatus, errorThrown) => {
            showAlert('Error', errorThrown);
        });
}

function showEditModal(studIndex) {

    let student = StudentList[studIndex];

    $('#update-id').text(student.id);
    $('#update-form input[name="id"]').val(student.id);
    $('#update-form input[name="name"]').val(student.name);
    $('#update-form input[name="phone"]').val(student.phone);
    $('#update-modal').modal('toggle');

    updateForm.find("button").on('click', () => {
        updateStudent(student.id);
        $('#update-modal').modal('toggle');
    });

}


function offsetAndLimitOnChange() {

    curOffset = searchForm.find('input[name="offset"]').val();
    curLimit = searchForm.find('input[name="limit"]').val();

}

function initForms() {

    addStudentHandler();
    searchStudentsHandler();
    searchForm.find('input[name="offset"], input[name="limit"]')
        .on('change', offsetAndLimitOnChange);

    searchStudents(true);
}


(function () { initForms(); }) ();