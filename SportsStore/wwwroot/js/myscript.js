var selected = new Set();

function selectRow(sender) {
    $(sender).toggleClass('background-color-row selected');

    if (selected.has(sender.childNodes[1].childNodes[1].value)) {
        selected.delete(sender.childNodes[1].childNodes[1].value)
    } else {
        selected.add(sender.childNodes[1].childNodes[1].value);
    }
    displayButton();
}

function displayButton() {
    if ((selected.size > 0) && (selected.size < 2)) {
        $('button#btn-selected').removeClass('selected-hidden');
    } else if (selected.size < 1) {
        $('button#btn-selected').addClass('selected-hidden');
    }
}

function deleteSelectedItems() {
    $.ajax({
        type: "POST",
        url: "/Product/DeleteSelected/",
        data: { ids: Array.from(selected) },
        traditional: true,
        dataType: 'html',
        success: function (data) {
            console.log('success', arguments);
            window.document.write(data);
        },
        error: function () {
            console.log('error', arguments);
        }
    });
}

function updateSelectedItems() {
    $.ajax({
        type: "GET",
        url: "/Product/UpdateSelected/",
        data: { ids: Array.from(selected) },
        dataType: 'html',
        traditional: true,
        success: function (data) {
            console.log('success', arguments);
            window.history.replaceState(data, "Update Products", "/Product/UpdateSelected");
            window.document.write(data);
        },
        error: function () {
            console.log('error', arguments);
        }
    });
}