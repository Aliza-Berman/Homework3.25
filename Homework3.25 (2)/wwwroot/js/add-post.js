$(() => {
    $(".form-control").on('keyup', function () {
        ensureFormValidity();
    });

    function ensureFormValidity() {
        const isValid = isFormValid();
        $("#submit-button").prop('disabled', !isValid);
    }

    function isFormValid() {
        const title = $("#title").val();
        const blogContent = $("#post").val();
       
        return title && blogContent;
    }
});