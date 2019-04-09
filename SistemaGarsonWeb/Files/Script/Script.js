$(".ModalCadastrar").click(function () {
    var url = $(this).attr("data-url");
    $('.modal-content').load("/"+ url +"/Cadastrar/");
});
$(".ModalEditar").click(function () {
    var url = $(this).attr("data-url");
    $('.modal-content').load("/"+ url);
});
$(".ModalDeletar").click(function () {
    var url = $(this).attr("data-url");
    $('.modal-content').load("/" + url);
});