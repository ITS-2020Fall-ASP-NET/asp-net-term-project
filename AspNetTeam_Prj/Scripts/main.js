function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $("#img-preview").show();
            $('#img-preview').attr('src', e.target.result);
        }

        reader.readAsDataURL(input.files[0]);
        $("#img-path").val(input.files[0].name);
    }
}

$(document).ready(function () {
    $("#btn-select-img").click(function () {
        $("#imgInp").click();
    });
    $("#img-preview").hide();
    $("#imgInp").change(function () {
        readURL(this);
    });
});