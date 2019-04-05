$(".ModalCadastrar").click(function () {
    var url = $(this).attr("data-url");
    $('.modal-content').load("/"+ url +"/Cadastrar/");
});