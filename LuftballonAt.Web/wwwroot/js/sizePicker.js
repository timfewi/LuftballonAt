function updateSizeLabel(value) {
    let sizeText = 'Alle Größen'; // Standardtext
    switch (value) {
        case '1':
            sizeText = 'Alle Größen';
            break;
        case '2':
            sizeText = 'Small';
            break;
        case '3':
            sizeText = 'Medium';
            break;
        case '4':
            sizeText = 'Large';
            break;
    }
    document.getElementById('sizeLabel').innerText = sizeText;