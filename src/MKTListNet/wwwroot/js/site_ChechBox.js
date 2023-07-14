function GetCheckBoxes(data_Tag) {
    var tag = 'input[type="checkbox"][' + data_Tag + ']'
    return document.querySelectorAll(tag);
}

function checkAll(checkbox) {
    var checkboxes = GetCheckBoxes("data-check_n");

    // Check all checkboxes, except self was clicked.
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i] !== checkbox) {
            checkboxes[i].checked = checkbox.checked;
        }
    }
}

