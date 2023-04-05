/* BEGIN EXTERNAL SOURCE */

    function layTongSoLuongSP() {
        $.ajax({
            type: 'POST',
            url: "/**********************************************/",
           
            success: function (result) {
                $("#totalCart").html(result.tsl);
            }
        });
    }
    layTongSoLuongSP();

/* END EXTERNAL SOURCE */
