$(document).ready(function () {
    updateCartItemCount();

    $(document).on('input', '.quantity', function () {
        var cartItemId = $(this).closest('tr').find('.remove-item').data("cart-item-id");
        var newQuantity = $(this).val();
        updateCartItemQuantity(cartItemId, newQuantity);
    });


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


    function updateCartItemQuantity(productId, newQuantity) {
        const cartToken = getCartToken();
        $.ajax({
            url: '/api/ShoppingCart/UpdateQuantity',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ ProductId: productId, Quantity: newQuantity, CartToken: cartToken }),
            success: function () {
                console.log("Artikelmenge erfolgreich aktualisiert");
                updateCartItemCount();
                location.reload();
            },
            error: function (error) {
                console.error("Fehler beim Aktualisieren der Artikelmenge", error);
            }
        });
    }


    function removeCartItem(cartItemId) {
        const cartToken = getCartToken();
        const quantity = $(`button[data-cart-item-id='${cartItemId}']`).closest('.input-group').find('.remove-quantity').val();
        $.ajax({
            url: '/api/ShoppingCart/RemoveItem',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify({ ProductId: cartItemId, Quantity: quantity, CartToken: cartToken }),
            success: function () {
                console.log("Artikel erfolgreich entfernt");
                updateCartItemCount();
                location.reload(); // Beachte: Das sofortige Neuladen könnte zu einer schlechten Benutzererfahrung führen, wenn es Alternativen gibt.
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
                location.reload();
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
        var quantity = parseInt($("#amount").val()) || 1;
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