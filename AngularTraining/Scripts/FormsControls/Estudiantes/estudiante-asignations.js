
function filterItems(listIn, listOut, setReturn, treturn) {
    var value = listIn.value;
    var opt, sel = listOut;
    if (value == '0') {
        restoreOptions(sel);
    }
    else {
        for (var i = sel.options.length - 1; i >= 0; i--) {
            opt = sel.options[i];
            if (opt.value != value) {
                opt.style.display = 'none';
            }
            if (opt.value == value) {
                opt.style.display = 'block';
            }
            sel.options[0].style.display = 'block';
        }
        var optSelectId = listIn.selectedIndex;
        var optSelectText = listIn.options[optSelectId].text;
        var optSelectVal = listIn.options[optSelectId].value;
        setReturn.value = treturn ? optSelectText : optSelectVal;
    }
}

function restoreOptions(el) {
    var opt, sel = el;
    for (var i = sel.options.length - 1; i >= 0; i--) {
        opt = sel.options[i];
        opt.style.display = 'block';
    }
}