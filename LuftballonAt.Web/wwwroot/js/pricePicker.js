document.getElementById('minPriceInput').addEventListener('change', validatePriceRange);
document.getElementById('maxPriceInput').addEventListener('change', validatePriceRange);

function validatePriceRange() {
    var minPrice = document.getElementById('minPriceInput').value;
    var maxPrice = document.getElementById('maxPriceInput').value;

    if (parseInt(minPrice) > parseInt(maxPrice)) {
        alert('Der Mindestpreis darf nicht höher sein als der Höchstpreis.');
        // Setze den Wert zurück oder mache weitere Anpassungen nach Bedarf
    }
}