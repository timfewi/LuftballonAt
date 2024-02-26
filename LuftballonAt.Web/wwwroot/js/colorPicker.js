

function clickColor(hexColor, top, left) {
    // Aktualisiere das versteckte Eingabefeld mit dem Hex-Wert der ausgewählten Farbe
    let hiddenInput = document.getElementById('selectedColor');
    if (hiddenInput) {
        hiddenInput.value = hexColor;
    }

    // Aktualisiere die Farbvorschau mit der ausgewählten Farbe
    let preview = document.getElementById('colorPreview');
    preview.style.visibility = 'visible';
    preview.style.backgroundColor = hexColor;

    // Aktualisiere das selectedHexagon div, um die ausgewählte Farbe anzuzeigen
    let selectedHexagon = document.getElementById('selectedHexagon');
    selectedHexagon.style.visibility = 'visible';
    selectedHexagon.style.backgroundColor = hexColor;
    // Hier kannst du die Position anpassen, falls notwendig
    selectedHexagon.style.top = 'auto';
    selectedHexagon.style.left = 'auto';
    // Entferne das Hintergrundbild, wenn du möchtest, dass nur die Farbe angezeigt wird
    selectedHexagon.style.backgroundImage = 'none';


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

