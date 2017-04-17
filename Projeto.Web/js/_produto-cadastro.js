//função para enviar os dados da página para o controller..
function enviarDados() {

    //resgatar o valor de cada campo da página..
    //JSON (JavaScript Object Notation)
    var model = {
        Nome: $("#nome").val(),
        Preco: $("#preco").val(),
        Quantidade: $("#quantidade").val(),
        Categoria: $("#categoria").val()
    };

    //requisição AJAX ao controller..
    $.ajax({
        type: "POST", //requisição do tipo HTTP POST
        url: "/Produto/CadastrarProduto", //controller/action
        data: model, //dados enviados para o controller..
        success: function (msg) {

            //exibir mensagem
            $("#mensagem").html(msg);

            //limpar os campos..
            $(".form-control").val("");
        },
        error: function (e) {
            //exibir mensagem de erro..
            $("#mensagem").html("Erro: " + e.status);
        }
    });
}

//criando os eventos do jquery..
//o primeiro evento do jquery sempre é o ready (página carregada..)
$(document).ready(function () {

    //criando um evento para quando o botão for clicado..
    $("#botaocadastro").click(function () {
        enviarDados(); //executando a função..
    });
});