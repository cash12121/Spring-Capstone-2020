/*
 * Creator: Robert Holmes
 * Created: 04/29/2020
 * Approver: Jaeho Kim
 * 
 * Utilzes Stripe Elements and other functionality to create and process payments.
 * Updater:
 * Updated: 
 * Update: 
 */
var stripe = Stripe(publicKey);
var elements = stripe.elements();

$(document).ready(function () {
    var style = {
        base: {
            color: '#32325d',
            fontFamily: '"Helvetica Neue", Helvetica, sans-serif',
            fontSmoothing: 'antialiased',
            fontSize: '16px',
            '::placeholder': {
                color: '#aab7c4'
            }
        },
        invalid: {
            color: '#fa755a',
            iconColor: '#fa755a'
        }
    };

    var card = elements.create('card', { style: style });
    card.mount('#card-element');

    card.addEventListener('change', function (event) {
        var displayError = document.getElementById('card-errors');
        if (event.error) {
            displayError.textContent = event.error.message;
        } else {
            displayError.textContent = '';
        }
    });

    var form = document.getElementById('payment-form');
    form.addEventListener('submit', function (ev) {
        ev.preventDefault();
        stripe.confirmCardPayment(clientSecret, {
            payment_method: {
                card: card,
                billing_details: {
                    name: billingName,
                    phone: billingPhone,
                    email: customerEmail,
                    address: {
                        city: billingCity,
                        country: billingCountry,
                        line1: billingAddressLine1,
                        line2: billingAddressLine2,
                        state: billingState
                    }
                }
            }
        }).then(function (result) {
            if (result.error) {
                var displayError = document.getElementById('card-errors');
                displayError.textContent = event.error.message;
            }
            else {
                if (result.paymentIntent.status === "succeeded") {
                    var stripeChargeID = result.paymentIntent.id;
                    $('#payment-form').append("<input type='hidden' name='stripeChargeID' value='" + stripeChargeID + "' />");
                    form.submit();
                }
            }
            
        });

});
});
