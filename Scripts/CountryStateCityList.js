$(document).ready(function () {
    //Country
    $("#CountryId").change(function () {
        var countryId = $(this).val();
        if (countryId == "") {
            var select = $("#StateId");
            select.empty();
            select.append($('<option/>', {
                value: 0,
                text: "Select State"
            }));

            var select = $("#CityId");
            select.empty();
            select.append($('<option/>', {
                value: 0,
                text: "Select City"
            }));
        }
        else {
            $.ajax({
                type: "GET",
                url: "/Register/LoadStateByCountryId",
                data: { countryId: countryId },
                dataType: "json",
                contentType: 'application/json; charset=utf-8',
                success: function (data) {
                    var select = $("#StateId");
                    select.empty();
                    select.append($('<option/>', {
                        value: 0,
                        text: "Select State"
                    }));
                    $.each(data, function (index, item) {
                        select.append($('<option/>', {
                            value: item.Value,
                            text: item.Text
                        }));
                    });
                },
                error: function () {
                    alert("Error while inserting data");
                }
            });
        }
    })


    //State
    $("#StateId").change(function () {
        var stateId = $(this).val();
        //alert(stateId);
        $.ajax({
            type: "GET",
            url: "/Register/LoadCityByStateId",
            data: { stateId: stateId },
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                var select = $("#CityId");
                select.empty();
                select.append($('<option />', {
                    value: 0,
                    text: "Select City"
                }));
                $.each(data, function (index, item) {
                    select.append($('<option/>', {
                        value: item.Value,
                        text: item.Text
                    }));
                });
            },
            error: function () {
                alert("Error while inserting data");
            }
        });
    })
})

