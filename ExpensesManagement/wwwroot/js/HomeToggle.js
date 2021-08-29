$(document).ready(function () {
    // MANAGE DEPOSIT INTERACTIONS
    $("#depositBtn").click(function () {
        $("#depositText").hide();

        $("#depositPart").fadeIn();
    });

    $(document).on("click", "#depositCancelBtn", function () {
        $("#depositPart").hide();

        $("#depositText").fadeIn();
    });

    // MANAGE WITHDRAW INTERACTIONS
    $("#withdrawBtn").click(function () {
        $("#withdrawText").hide();

        $("#withdrawPart").fadeIn();
    });

    $(document).on("click", "#withdrawCancelBtn", function () {
        $("#withdrawPart").hide();

        $("#withdrawText").fadeIn();
    });
});