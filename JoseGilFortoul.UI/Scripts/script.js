$(document).ready(function () {
    $("#padreRepresentante").click(function () {
        $("#formPadre").css("display", "none")
        $("#formMadre").css("display", "")
    });

    $("#madreRepresentante").click(function () {
        $("#formMadre").css("display", "none");
        $("#formPadre").css("display", "");
    });

    $(".rbAlumno").click(function () {
        $("#seleccionPago").css("display", "");
        console.log($("input[name=seleccionarAlumno]:checked").val());
        $("#idAlumno").val($("input[name=seleccionarAlumno]:checked").val());
    });

    $("#padre").click(function () {
        $("#representanteForm").css("display", "none");
    });

    $("#madre").click(function () {
        $("#representanteForm").css("display", "none");
    });

    $("#otro").click(function () {
        $("#representanteForm").css("display", "");
    });

    $("#ddlConceptoPago").change(function () {
        if ($("#ddlConceptoPago option:selected").text() == "Mensualidad") {
            $("#seleccionMes").css("display", "");
        }
        else {
            $("#seleccionMes").css("display", "none");
        }
    });
})