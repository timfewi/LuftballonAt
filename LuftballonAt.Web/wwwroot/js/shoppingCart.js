$(document).ready(function () {
    var cartToken = initializeCartToken();
    getCartItemCount(cartToken);
    function generateUUID() {
        var d = new Date().getTime();
        var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = (d + Math.random() * 16) % 16 | 0;
            d = Math.floor(d / 16);
            return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
        return uuid;
    }

    function initializeCartToken() {
        let cartToken = localStorage.getItem('cartToken');
        if (!cartToken) {
            cartToken = generateUUID();
            localStorage.setItem('cartToken', cartToken);
        }
        $('#cartToken').val(cartToken);
    }




    function addItemToCart(productId, quantity, cartToken, callback) {
        $.ajax({
            url: '/api/ShoppingCart/AddItem',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ productId: productId, quantity: quantity, cartToken: cartToken }),
            success: function (response) {
                console.log("Artikel erfolgreich hinzugefügt", response);
                if (callback) callback();
            },
            error: function (error) {
                console.error("Fehler beim Hinzufügen des Artikels", error);
            }
        });
    }


    function updateCartItemQuantity(cartItemId, newQuantity) {
        $.ajax({
            url: '/api/ShoppingCart/UpdateQuantity',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ cartItemId: cartItemId, newQuantity: newQuantity }),
            success: function (response) {
                console.log("Artikelmenge erfolgreich aktualisiert", response);
                // Aktualisiere die Warenkorb-Anzeige hier
            },
            error: function (error) {
                console.error("Fehler beim Aktualisieren der Artikelmenge", error);
            }
        });
    }
    function removeCartItem(cartItemId, cartToken) {
        $.ajax({
            url: '/api/ShoppingCart/RemoveItem',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ productId: cartItemId, cartToken: cartToken }),
            success: function (response) {
                console.log("Artikel erfolgreich entfernt", response);
                // Aktualisiere die Warenkorb-Anzeige hier
            },
            error: function (error) {
                console.error("Fehler beim Entfernen des Artikels", error);
            }
        });
    }
    function clearCart(cartToken) {
        $.ajax({
            url: '/api/ShoppingCart/ClearCart',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ cartToken: cartToken }),
            success: function (response) {
                console.log("Warenkorb erfolgreich geleert", response);
                // Aktualisiere die Warenkorb-Anzeige hier
            },
            error: function (error) {
                console.error("Fehler beim Leeren des Warenkorbs", error);
            }
        });
    }



    function updateDisplay() {
        $.ajax({
            url: '/api/ShoppingCart/GetCart',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(cartToken),
            success: function (response) {
                console.log("Warenkorb erfolgreich abgerufen", response);
                // Aktualisiere die Warenkorb-Anzeige hier
            },
            error: function (error) {
                console.error("Fehler beim Abrufen des Warenkorbs", error);
            }
        });
    }

    function getCartItemCount(cartToken) {
        $.ajax({
            url: '/api/ShoppingCart/GetCartItemCount',
            type: 'GET',
            data: { cartToken: cartToken },
            success: function (response) {
                $("#cartItemCount").text(response.count);
            },
            error: function (xhr) {
                console.error("Error response:", xhr.responseJSON);
            }
        });
    }





    // Event-Listener für "In den Warenkorb" Buttons
    $(".add-to-cart").click(function (event) {
        event.preventDefault();
        var productId = $(this).data("product-id");
        var quantity = 1; // oder die gewählte Menge
        var cartToken = localStorage.getItem('cartToken') || initializeCartToken();
        addItemToCart(productId, quantity, cartToken, function () {
            getCartItemCount(cartToken);
        });
    });

    // Event-Listener für "Menge aktualisieren" Buttons
    $(".update-quantity").click(function () {
        var cartItemId = $(this).data("cart-item-id");
        var newQuantity = $(this).siblings(".quantity").val();
        updateCartItemQuantity(cartItemId, newQuantity);
    });

    // Event-Listener für "Artikel entfernen" Buttons
    $(".remove-item").click(function () {
        var cartItemId = $(this).data("cart-item-id");
        var cartToken = $("#cartToken").val();
        removeCartItem(cartItemId, cartToken);
    });

    // Event-Listener für "Warenkorb leeren" Button
    $(".clear-cart").click(function () {
        var cartToken = $("#cartToken").val();
        clearCart(cartToken);
    });

});