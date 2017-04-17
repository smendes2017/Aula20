//função para exibir os dados na janela model de exclusão..
function exibirDadosExclusao(model) {

    //exibir os dados nos elementos <span>
    $("#lblcodigo").html(model.IdProduto);
    $("#lblnome").html(model.Nome);
    $("#lblpreco").html(model.Preco);
    $("#lblquantidade").html(model.Quantidade);
    $("#lbltotal").html(model.Total);
    $("#lblcategoria").html(model.Categoria);
};

//função para excluir o produto..
function excluirProduto() {

    //requisição AJAX para o servidor..
    $.ajax({
        type: "POST",
        url: "/Produto/ExcluirProduto",
        data: "idProduto=" + $("#lblcodigo").html(),
        success: function (msg) {

            //exibir mensagem de sucesso..
            $("#mensagemexclusao").html(msg);

            //executar a consulta novamente..
            consultarProdutos();

            //desabilitar o botão de exclusão..
            $("#btnexclusao").prop("disabled", true);
        },
        error: function (e) {
            //exibir mensagem de erro..
            $("#mensagemexclusao").html("Erro: " + e.status);
        }
    });

}

//função para exibir os dados do produto na janela modal..
function exibirDadosEdicao(id) {
    //requisição ao controller..
    $.ajax({
        type: "POST", //requisição..
        url: "/Produto/ObterProdutoEdicao", //nome do método jsonresult
        data: "idProduto=" + id, //dados que o metodo recebe..
        success: function (model) {

            //exibir os dados nos campos..
            $("#txtcodigo").val(model.IdProduto);
            $("#txtnome").val(model.Nome);
            $("#txtpreco").val(model.Preco);
            $("#txtquantidade").val(model.Quantidade);
            $("#ddlcategoria").val(model.Categoria);
        },
        error: function (e) {
            $("#mensagemedicao").html("Erro: " + e.status);
        }
    });
};

//função para atualizar o produto..
function atualizarProduto() {

    var model = {
        IdProduto: $("#txtcodigo").val(),
        Nome: $("#txtnome").val(),
        Preco: $("#txtpreco").val(),
        Quantidade: $("#txtquantidade").val(),
        Categoria: $("#ddlcategoria").val()
    };

    //requisição AJAX ao controller..
    $.ajax({
        type: "POST", //requisição do tipo HTTP POST
        url: "/Produto/AtualizarProduto", //controller/action
        data: model, //dados enviados para o controller..
        success: function (msg) {

            //exibir mensagem
            $("#mensagemedicao").html(msg);

            consultarProdutos();
        },
        error: function (e) {
            //exibir mensagem de erro..
            $("#mensagemedicao").html("Erro: " + e.status);
        }
    });
};


//função para executar a consulta na classe de controle..
function consultarProdutos() {
    //requisição ajax para o /ProdutoController..
    $.ajax({
        type: "POST", //requisição..
        url: "/Produto/ConsultarProdutos", //controller/jsonresult
        data: {}, //vazio
        success: function (lista) {

            //quantidade de registros..
            $("#quantidadeprodutos").html(lista.length);

            //variavel para montar o conteudo da tabela..
            var conteudo = "";

            //foreach em jquery..
            $.each(lista, function (i, model) { //model -> cada linha da lista
                conteudo += "<tr>";
                conteudo += "<td>" + model.IdProduto + "</td>";
                conteudo += "<td>" + model.Nome + "</td>";
                conteudo += "<td>" + model.Preco + "</td>";
                conteudo += "<td>" + model.Quantidade + "</td>";
                conteudo += "<td>" + model.Total + "</td>";
                conteudo += "<td>" + model.Categoria + "</td>";

                conteudo += "<td>";

                conteudo += "<button onclick='exibirDadosEdicao(" + model.IdProduto + ")' data-toggle='modal' data-target='#janelaedicao' class='btn btn-primary btn-sm'>";
                conteudo += "Atualizar";
                conteudo += "</button>";

                conteudo += "&nbsp;"; //espaço..

                conteudo += "<button onclick='exibirDadosExclusao(" + JSON.stringify(model) + ")' data-toggle='modal' data-target='#janelaexclusao' class='btn btn-danger btn-sm'>";
                conteudo += "Excluir";
                conteudo += "</button>";

                conteudo += "</td>";

                conteudo += "</tr>";
            });

            //preencher a tabela..
            $("#tabela tbody").html(conteudo);
        },
        error: function (e) {
            $("#mensagem").html("Erro: " + e.status);
        }
    });
};

//executar a função..
$(document).ready(function () { //quando a página abrir..

    consultarProdutos(); //executando a função..

    //evento de edição..
    $("#btnedicao").click(function () {
        atualizarProduto();
    });

    //evento de exclusão..
    $("#btnexclusao").click(function () {
        excluirProduto();
    });

    //criando um evento para quando a modal for fechada..
    $("#janelaexclusao").on('hide.bs.modal', function () {
        $("#mensagemexclusao").html("");
        $("#btnexclusao").prop("disabled", false);
    });

    //criando um evento para quando a modal for fechada..
    $("#janelaedicao").on('hide.bs.modal', function () {
        $("#mensagemedicao").html("");
    });

    //formatação de moeda..
    $(".moeda").formatCurrency();

});