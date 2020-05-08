/*
 * Creator: Robert Holmes
 * Created: 04/29/2020
 * Approver: Jaeho Kim
 * 
 * Helps populate forms for the checkout process
 * Updater: 
 * Updated: 
 * Update: 
 */

$(document).ready(function () {

    var statesCollection = {
        "AL": "Alabama",
        "AK": "Alaska",
        "AS": "American Samoa",
        "AZ": "Arizona",
        "AR": "Arkansas",
        "CA": "California",
        "CO": "Colorado",
        "CT": "Connecticut",
        "DE": "Delaware",
        "DC": "District Of Columbia",
        "FM": "Federated States Of Micronesia",
        "FL": "Florida",
        "GA": "Georgia",
        "GU": "Guam",
        "HI": "Hawaii",
        "ID": "Idaho",
        "IL": "Illinois",
        "IN": "Indiana",
        "IA": "Iowa",
        "KS": "Kansas",
        "KY": "Kentucky",
        "LA": "Louisiana",
        "ME": "Maine",
        "MH": "Marshall Islands",
        "MD": "Maryland",
        "MA": "Massachusetts",
        "MI": "Michigan",
        "MN": "Minnesota",
        "MS": "Mississippi",
        "MO": "Missouri",
        "MT": "Montana",
        "NE": "Nebraska",
        "NV": "Nevada",
        "NH": "New Hampshire",
        "NJ": "New Jersey",
        "NM": "New Mexico",
        "NY": "New York",
        "NC": "North Carolina",
        "ND": "North Dakota",
        "MP": "Northern Mariana Islands",
        "OH": "Ohio",
        "OK": "Oklahoma",
        "OR": "Oregon",
        "PW": "Palau",
        "PA": "Pennsylvania",
        "PR": "Puerto Rico",
        "RI": "Rhode Island",
        "SC": "South Carolina",
        "SD": "South Dakota",
        "TN": "Tennessee",
        "TX": "Texas",
        "UT": "Utah",
        "VT": "Vermont",
        "VI": "Virgin Islands",
        "VA": "Virginia",
        "WA": "Washington",
        "WV": "West Virginia",
        "WI": "Wisconsin",
        "WY": "Wyoming"
    };

    // keys in this map should match ISO 3166-1 alpha-2
    var countryCollection = {
        "US": "United States"
    }

    fillSelect(statesCollection, document.getElementById('BillingState'));
    fillSelect(statesCollection, document.getElementById('ShippingState'));
    fillSelect(countryCollection, document.getElementById('BillingCountry'));
    fillSelect(countryCollection, document.getElementById('ShippingCountry'));

    function fillSelect(collection, element) {
        for (key in collection) {
            element.options[element.options.length] = new Option(collection[key], key);
        }
    };

    $('#separateShippingInfo').change(function () {
        if ($(this).is(":checked")) {
            $("#shippingInfo").slideDown();
            $("#shippingInfo.form-input").removeClass("ignore");
        } else {
            $("#shippingInfo").slideUp();
            $("#shippingInfo.form-input").addClass("ignore");
        }
    });

    $(".phone").inputmask("(999) 999-9999");

    $("#payment-form").validate({
        rules: {
            ignore: ".ignore"
        }
    });

    $("#btnSubmit").click(function () {
        $("#payment-form").submit();
    });
});