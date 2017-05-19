
function addState() {

    if (!$("#form_state_add").valid())
    {
        return false;
    }
    else {
        $.ajax({
            type: 'POST',
            url: BasePath + "Admin/_State/",
            data: $('#form_state_add').serialize(),
            async: false,
            success: function (data) {
                //alert(data.id)
                //if (data.id > 0)
                //{
                //    $("#btnText").html("Update")
                //}
                //else {
                //    $("#btnText").html("Add")
                //}
                //$("#Name").val('');
                //$(".btn-default").css('background-color', '#fff');
                //$(".btn-default").css('border-color', '#ccc');
                //$(".btn-default").css('color', '#333');
                refreshStateList();
                refreshAddUpdateState();
            },
            error: function (request, error)
            {
                alert("Oops! something went wrong!")
            }
        });

    }


}

function editState(id) {
    $.ajax({
        type: 'GET',
        url: BasePath + "Admin/_State/",
        data: {
            id: id
        },
        async: false,
        success: function (data) {
            $('#div_state_add').html(data);
        },
        error: function (request, error) {
            alert("Oops! something went wrong!")
        }
    });
}


function deleteState(id) {

    $.ajax({
        type: 'GET',
        url: BasePath + "Admin/StateDelete/",
        data: {
            id: id
        },
        async: false,
        success: function (data) {
            refreshStateList();
            refreshAddUpdateState();
            // $('#div_country_add').html(data);
        },
        error: function (request, error) {
            alert("Oops! something went wrong!")
        }
    });
}

function changeStateStatus(id, status) {

    $.ajax({
        type: 'GET',
        url: BasePath + "Admin/StateChangeStatus/",
        data:
            {
                id: id, status: status
            },
        async: false,
        success: function (data)
        {
            refreshStateList();
            refreshAddUpdateState();
            // $('#div_country_add').html(data);
        },
        error: function (request, error) {
            alert("Oops! something went wrong!")
        }
    });
}

function refreshStateList() {
   
    $.ajax({
        type: 'GET',
        url: BasePath + "Admin/_StateList",
        success: function (data)
        {
            $('#div_state_list').html(data);
        },
        error: function (request, error) {
            alert("Oops! something went wrong!")
        }
    });
}

function refreshAddUpdateState() {

    $.ajax({
        type: 'GET',
        url: BasePath + "Admin/_State",
        success: function (data)
        {
            $('#div_state_add').html(data);
        },
        error: function (request, error) {
            alert("Oops! something went wrong!")
        }
    });
}
