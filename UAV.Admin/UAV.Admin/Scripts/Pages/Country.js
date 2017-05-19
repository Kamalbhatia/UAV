
function addCountry() {
   
    if (!$("#form_country_add").valid())
    {
        return false;
    }
    else {
        $.ajax({
            type: 'POST',
            url: BasePath + "Admin/_Country/",
            data: $('#form_country_add').serialize(),
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
                refreshCountyList();
                refreshAddUpdateCountry();
            },
            error: function (request, error)
            {
                alert("Oops! something went wrong!")
            }
        });

    }


}

function editCountry(id) {
    $.ajax({
        type: 'GET',
        url: BasePath + "Admin/_Country/",
        data: {
            id: id
        },
        async: false,
        success: function (data) {
            $('#div_country_add').html(data);
        },
        error: function (request, error) {
            alert("Oops! something went wrong!")
        }
    });
}


function deleteCountry(id) {

    $.ajax({
        type: 'GET',
        url: BasePath + "Admin/CountryDelete/",
        data: {
            id: id
        },
        async: false,
        success: function (data) {
            refreshCountyList();
            refreshAddUpdateCountry();
            // $('#div_country_add').html(data);
        },
        error: function (request, error) {
            alert("Oops! something went wrong!")
        }
    });
}

function changeCountryStatus(id, status) {

    $.ajax({
        type: 'GET',
        url: BasePath + "Admin/CountryChangeStatus/",
        data:
            {
                id: id, status: status
            },
        async: false,
        success: function (data) {
            refreshCountyList();
            refreshAddUpdateCountry();
            // $('#div_country_add').html(data);
        },
        error: function (request, error) {
            alert("Oops! something went wrong!")
        }
    });
}

function refreshCountyList() {
    $.ajax({
        type: 'GET',
        url: BasePath + "Admin/_CountryList",
        success: function (data) {
            $('#div_country_list').html(data);
        },
        error: function (request, error) {
            alert("Oops! something went wrong!")
        }
    });
}


function refreshAddUpdateCountry() {

    $.ajax({
        type: 'GET',
        url: BasePath + "Admin/_Country",
        success: function (data) {
            $('#div_country_add').html(data);
        },
        error: function (request, error) {
            alert("Oops! something went wrong!")
        }
    });
}