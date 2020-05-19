$('body').on('click', "input[name = 'Delete']", function () {
    $('#AjaxLoader').show();
    var ClassForAdd = $(this).parent().parent().parent().parent().attr("id");

    if (ClassForAdd == "table-order-actual") {
        var methodName = 'RenderActualOrdersPartial';
        var className = '.actual-orders';
    }
    else if (ClassForAdd == "table-order-old") {
        var methodName = 'RenderOldOrdersPartial';
        var className = '.old-orders';
    }

    $.ajax({
        type: "POST",
        url: "/Admin/Delete",
        data: JSON.stringify({ id: $(this).attr("id"), elementsPerPage: $('#count-of-elements').val() }),
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        success: function () {
            reRenderThePartial(className, methodName);
            $('#AjaxLoader').hide();
        },
        error: function () {
            alert("При попытке удаления заказа возникла ошибка!");
            $('#AjaxLoader').hide();
        }
    });
});

$('body').on('click', "input[name = 'update']", function () {
    $('#AjaxLoader').show();
    var ClassForAdd = $(this).parent().parent().parent().parent().attr("class");

    if (ClassForAdd == "actual-orders") {
        var methodName = 'RenderActualOrdersPartial';
    }
    else if (ClassForAdd == "old-orders") {
        var methodName = 'RenderOldOrdersPartial';
    }

    reRenderThePartial("." + ClassForAdd, methodName);
});

$('body').on('click', "input[name = 'enterSearch']", function () {
    $('#AjaxLoader').show();
    var ClassForAdd = $(this).parent().parent().parent().parent().parent().attr("class");

    if (ClassForAdd == "actual-orders") {
        var finishedOrNot = false;
        var seachString = $('#search-Actual').val();
    }
    else if (ClassForAdd == "old-orders") {
        var finishedOrNot = true;
        var seachString = $('#search-Old').val();
    }

    if (seachString == "") {
        alert("Строка поиска пуста, введите данные для поиска!");
        $('#AjaxLoader').hide();
        return;
    }

    $.ajax({
        type: "POST",
        url: "/Admin/Search",
        data: JSON.stringify({ searchString: seachString, finishedOrNot: finishedOrNot }),
        contentType: "application/json; charset=utf-8",
        dataType: 'html',
        success: function (data) {
            $("." + ClassForAdd).html(data);
            $('#AjaxLoader').hide();
        },
        error: function () {
            alert("При попытке поиска заказа возникла ошибка или ничего не было найдено!");
            $('#AjaxLoader').hide();
        }
    });
});

$('body').on('click', "input[id = 'add-Actual']", function () {
    $('#AjaxLoader').show();
    $('.main-panel').hide();
    $('#addEdit').show();
    $('#AjaxLoader').hide();
});

$('body').on('click', "input[id = 'add-Old']", function () {
    $('#AjaxLoader').show();
    $('.main-panel').hide();
    $('#addEdit').show();
    $('#AjaxLoader').hide();
});

$('body').on('click', "input[name = 'Edit']", function () {
    $('#AjaxLoader').show();
    $('.main-panel').hide();

    $.ajax({
        type: "POST",
        url: "/Admin/Edit",
        data: JSON.stringify({ id: $(this).attr("id") }),
        contentType: "application/json; charset=utf-8",
        dataType: 'html',
        success: function (data) {
            $(".addEditContainer").html(data);
            $('#AjaxLoader').hide();
            $('#addEdit').show();
        },
        error: function () {
            alert("При попытке изменения заказа возникла ошибка или ничего не было найдено!");
            $('#AjaxLoader').hide();
        }
    });
});

$('body').on('click', "input[id = 'btnEditConfirm']", function () {
    $('#AjaxLoader').show();

    if ($('#OrderID').val() != 0) {
        $.ajax({
            type: "POST",
            url: "/Admin/EditConfirm",
            data: $('#addEditForm').serialize(),
            dataType: 'json',
            success: function (data) {
                $('#AjaxLoader').hide();
                $('#addEdit').hide();
                $('.main-panel').show();
                window.location.href = "/Admin/Index";
                //reRenderIndex();
                ClearAddEditParial();
            },
            error: function (data) {
                alert("При попытке изменения заказа возникла ошибка или ничего не было найдено!");
                $('#AjaxLoader').hide();
                $('#addEdit').hide();
                $('.main-panel').show();
            }
        });
    }
    else {
        $.ajax({
            type: "POST",
            url: "/Admin/Add",
            data: $('#addEditForm').serialize(),
            dataType: 'json',
            success: function (data) {
                $('#AjaxLoader').hide();
                $('#addEdit').hide();
                $('.main-panel').show();
                window.location.href = "/Admin/Index";
                //reRenderIndex();
                ClearAddEditParial();
            },
            error: function (data) {
                alert("При попытке добавления заказа возникла ошибка!");
                $('#AjaxLoader').hide();
                $('#addEdit').hide();
                $('.main-panel').show();
            }
        });
    }
});

$('body').on('click', "input[id = 'pagination-page']", function () {
    $('#AjaxLoader').show();

    var ClassForAdd = '.' + $(this).parent().parent().parent().parent().attr("class");

    var isFinished = false;

    if (ClassForAdd == ".actual-orders") {
        isFinished = false;
    }
    else if (ClassForAdd == ".old-orders") {
        isFinished = true;
    }

    $.ajax({
        url: '/Admin/PaginationLoad',
        type: "POST",
        data: { pageNumber: $(this).val(), elementsPerPage: parseInt($('#count-of-elements').val()), isFinished: isFinished },
        dataType: 'html',
        success: function (data) {
            $(ClassForAdd).html(data);
            $('#AjaxLoader').hide();
        },
        error: function (data) {
            alert("Ошибка при выводе таблицы заказов!");
            $('#AjaxLoader').hide();
        }
    });
});

function reRenderIndex() {
    $('#AjaxLoader').show();
    $.ajax({
        url: '/Admin/RenderIndex',
        type: "POST",
        data: { elementsPerPage: parseInt($('#count-of-elements').val()) },
        dataType: 'html',
        success: function (data) {
            $('.container.body-content').html(data);
            $('#AjaxLoader').hide();
        },
        error: function (data) {
            alert("Ошибка при выводе страницы!");
            $('#AjaxLoader').hide();
        }
    });
}

function reRenderThePartial($className, $methodName) {
    $.ajax({
        url: '/Admin/' + $methodName,
        type: "POST",
        data: { elementsPerPage: parseInt($('#count-of-elements').val()), pageNumber : 1 },
        dataType: 'html',
        success: function (data) {
            $($className).html(data);
            $('#AjaxLoader').hide();
        },
        error: function (data) {
            alert("Ошибка при выводе таблицы заказов!");
            $('#AjaxLoader').hide();
        }
    });
}

function ClearAddEditParial() {
    $('#OrderID').val("");
    $('#UserID').val("");
    $('#EmployeeID').val("");
    $('#RestaurantID').val("");
    $('#PizzaID').val("");
    $('#DataTimeOrder').val("");
    $('#Value').val("");
    $('#Comment').val("");
    $('#IsFinished').val(false);
}