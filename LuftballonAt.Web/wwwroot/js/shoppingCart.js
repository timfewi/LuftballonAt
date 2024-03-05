$(document).ready(function () {
    updateCartItemCount();


    function getCartToken() {
        let cartToken = Cookies.get('CartToken');
        if (!cartToken) {
            cartToken = generateUUID();
            Cookies.set('CartToken', cartToken);
        }
        return cartToken;
    }

    function generateUUID() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0,
                v = c === 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }



    function updateCartItemCount() {
        const cartToken = getCartToken();
        $.ajax({
            url: '/api/ShoppingCart/GetCartItemCount',
            type: 'GET',
            data: { cartToken: cartToken },
            contentType: 'application/json',
            success: function (response) {
                $('#cartItemCount').text(response.count);
            },
            error: function (error) {
                console.log("Fehler beim Abrufen der Warenkorb-Anzahl", error);
            }
        });
    }


    function addItemToCart(productId, quantity) {
        const cartToken = getCartToken();
        $.ajax({
            url: '/api/ShoppingCart/AddItem',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ productId, quantity, cartToken: cartToken }),
            success: function () {
                console.log("Artikel erfolgreich hinzugefügt");
                toastr.success("Artikel erfolgreich hinzugefügt");
                updateCartItemCount();
            },
            error: function (error) {
                console.error("Fehler beim Hinzufügen des Artikels", error);
            }
        });
    }


    function updateCartItemQuantity(cartItemId, newQuantity) {
        const cartToken = getCartToken();
        $.ajax({
            url: '/api/ShoppingCart/UpdateQuantity',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ cartItemId, newQuantity, cartToken }),
            success: function () {
                console.log("Artikelmenge erfolgreich aktualisiert");
                updateCartItemCount();
            },
            error: function (error) {
                console.error("Fehler beim Aktualisieren der Artikelmenge", error);
            }
        });
    }

    function removeCartItem(cartItemId) {
        const cartToken = getCartToken();
        $.ajax({
            url: '/api/ShoppingCart/RemoveItem',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ cartItemId, cartToken }),
            success: function () {
                console.log("Artikel erfolgreich entfernt");
                updateCartItemCount();
            },
            error: function (error) {
                console.error("Fehler beim Entfernen des Artikels", error);
            }
        });
    }


    function clearCart() {
        const cartToken = getCartToken();
        $.ajax({
            url: '/api/ShoppingCart/ClearCart',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ cartToken }),
            success: function () {
                console.log("Warenkorb erfolgreich geleert");
                updateCartItemCount();
            },
            error: function (error) {
                console.error("Fehler beim Leeren des Warenkorbs", error);
            }
        });
    }


    // Event-Handler
    $(".add-to-cart").click(function (event) {
        event.preventDefault();
        var productId = $(this).data("product-id");
        var quantity = 1; // Die gewählte Menge könnte auch dynamisch sein
        addItemToCart(productId, quantity);
    });

    $(".update-quantity").click(function () {
        var cartItemId = $(this).data("cart-item-id");
        var newQuantity = $(this).siblings(".quantity").val(); // Stelle sicher, dass dies die korrekte Methode ist, um die neue Menge zu erhalten
        updateCartItemQuantity(cartItemId, newQuantity);
    });

    $(".remove-item").click(function () {
        var cartItemId = $(this).data("cart-item-id");
        removeCartItem(cartItemId);
    });

    $(".clear-cart").click(function () {
        clearCart();
    });


});