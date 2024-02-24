

function clickColor(hexColor, top, left) {
    let hiddenInput = document.getElementById('selectedColor');
    if (hiddenInput) {
        hiddenInput.value = hexColor;
    }

    let selectedHexagon = document.getElementById('selectedHexagon');
    selectedHexagon.style.visibility = 'visible';
    selectedHexagon.style.top = top + 'px';
    selectedHexagon.style.left = left + 'px';
    selectedHexagon.style.height = '21px';
    selectedHexagon.style.width = '21px';
    selectedHexagon.style.position = 'relative';

    selectedHexagon.style.backgroundImage = 'url(/images/img_selectedcolor.gif)'

}

function mouseOverColor(hexColor) {
    let preview = document.getElementById('colorPreview');
    preview.style.visibility = 'visible';
    preview.style.backgroundColor = hexColor;
}

function mouseOutMap() {
    let preview = document.getElementById('colorPreview');
    preview.style.visibility = 'hidden';
}
