function Modalpopup(url, title, icon) {
    ShowLoadingPanel();
    icon = typeof icon !== 'undefined' ? icon : 'fa-info-circle';
    $.get(url)
        .done(function (response) {
            var icontag = '<i class="fa ' + icon + ' fa-fw" aria-hidden="true"></i>&nbsp;';
            $("#modaltitle").html(icontag + title);
            $("#modalbody").html(response);
            $('#modalcontent').modal({ backdrop: 'static', keyboard: true, show: true });
            HideLoadingPanel();
        });
}

function LargeModalpopup(url, title, icon) {
    ShowLoadingPanel();
    icon = typeof icon !== 'undefined' ? icon : 'fa-info-circle';
    $.get(url)
        .done(function (response) {
            var icontag = '<i class="fa ' + icon + ' fa-fw" aria-hidden="true"></i>&nbsp;';
            $("#modaltitle-lg").html(icontag + title);
            $("#modalbody-lg").html(response);
            $('#modalcontent-lg').modal({ backdrop: 'static', keyboard: true, show: true });
            HideLoadingPanel();
        });
}

function ExtraLargeModalpopup(url, title, icon) {
    ShowLoadingPanel();
    icon = typeof icon !== 'undefined' ? icon : 'fa-info-circle';

    $.get(url)
        .done(function (response) {
            var icontag = '<i class="fa ' + icon + ' fa-fw" aria-hidden="true"></i>&nbsp;';
            $("#modaltitle-xl").html(icontag + title);
            $("#modalbody-xl").html(response);
            $('#modalcontent-xl').modal({ backdrop: 'static', keyboard: true, show: true });
            HideLoadingPanel();
        });
}

function SmallModalpopup(url, title, icon) {
    ShowLoadingPanel();
    icon = typeof icon !== 'undefined' ? icon : 'fa-info-circle';

    $.get(url)
        .done(function (response) {
            var icontag = '<i class="fa ' + icon + ' fa-fw" aria-hidden="true"></i>&nbsp;';
            $("#modaltitle-sm").html(icontag + title);
            $("#modalbody-sm").html(response);
            $('#modalcontent-sm').modal({ backdrop: 'static', keyboard: true, show: true });
            HideLoadingPanel();
        });
}

function ShowLoadingPanel() {
    $('#div-loading-panel').show();
}

function HideLoadingPanel() {
    $('#div-loading-panel').hide();
}

function ShowErrorMessage(message) {
    $('.msgerrorbody').html(message).fadeIn('fast');
    $('.msgerrorbody').delay(3000).fadeOut('slow');
}

function ShowSuccessMessage(message) {
    $('.msgsuccessbody').html(message).fadeIn('fast');
    $('.msgsuccessbody').delay(3000).fadeOut('slow');
}

function ShowWarningMessage(message) {
    $('.msgwarningbody').html(message).fadeIn('fast');
    $('.msgwarningbody').delay(3000).fadeOut('slow');
}

function ShowInfoMessage(message) {
    $('.msginfobody').html(message).fadeIn('fast');
    $('.msginfobody').delay(3000).fadeOut('slow');
}

function Create(form, url, button) {
    var valid = ValidateForm(form);

    if (valid) {
        ShowLoadingPanel();
        $(button).prop('disabled', true);
        $.ajax({
            type: "POST",
            url: url,
            data: $(form).serialize(),
            success: function (data) {
                if (data.success) {
                    $("[id^='modalcontent']").modal('hide');
                    if (data.adminSection) {
                        UpdateAdminSection();
                    }
                    else {
                        UpdateAppSection(data.sectionId, data.businessId);
                    }
                }
                else {
                    $(button).prop('disabled', false);
                }
            },
            complete: function () {
                HideLoadingPanel();
            }
        });
    }
}

function Save(form, url, button) {
    var valid = ValidateForm(form);

    if (valid) {
        $(button).prop('disabled', true);
        ShowLoadingPanel();

        $.ajax({
            type: "POST",
            url: url,
            data: $(form).serialize(),
            success: function (data) {
                if (data.success) {
                    $("[id^='modalcontent']").modal('hide');
                    if (data.adminSection) {
                        UpdateAdminSection();
                    }
                    else {
                        UpdateAppSection(data.sectionId, data.businessId);
                    }
                }
                else {
                    $(button).prop('disabled', false);
                }
            },
            complete: function () {
                HideLoadingPanel();
            }
        });
    }
}

function Delete(form, url, button) {
    $(button).prop('disabled', true);
    ShowLoadingPanel();

    $.ajax({
        type: "POST",
        url: url,
        data: $(form).serialize(),
        success: function (data) {
            if (data.success) {
                $("[id^='modalcontent']").modal('hide');
                if (data.adminSection) {
                    UpdateAdminSection();
                }
                else {
                    UpdateAppSection(data.sectionId, data.businessId, data.itemId);
                }
            }
            else {
                $(button).prop('disabled', false);
            }
        },
        complete: function () {
            HideLoadingPanel();
        }
    });
}

function RequiredFields() {
    $(".form-control").blur(function () {
        $(this).closest('.form-group').removeClass('has-error');
    });
}

function ValidateForm(form) {
    var valid = true;

    //Validating required fields
    $(form).find('select, textarea, input').each(function (i, field) {
        //console.log(field.name + ", " + field.value);
        if ($('#' + field.id).prop('required')) {
            if (!$('#' + field.id).val()) {
                $('#' + field.id).closest('.form-group').addClass('has-error');
                valid = false;
            }
        }
    });

    return valid;
}

function HideDiv(divName, opt) {
    if (opt === true) {
        $("#" + divName).css("visibility", "hidden");
        $("#" + divName).toggle(false);
    }
    if (opt === false) {
        $("#" + divName).css("visibility", "visible");
        $("#" + divName).toggle(true);
    }
}

function NonEditableFields() {
    $('#LocationName').prop('readonly', true);
    $('#CensusCode').prop('readonly', true);
    $('#Zoning').prop('readonly', true);
    $('#SpecialControlArea').prop('readonly', true);
    $('#WaterCourseNearBy').prop('readonly', true);
    $('#LocalNaturalArea').prop('readonly', true);
    $('#LotArea').prop('readonly', true);
    $('#BuildFeeServiceLevy').prop('readonly', true);
    $('#BuildFeedTrainingFund').prop('readonly', true);
    $('#BuildFeeAppType').prop('readonly', true);
    $('#FeesTotal').prop('readonly', true);
}