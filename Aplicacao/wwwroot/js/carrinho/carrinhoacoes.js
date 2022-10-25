let AbrirCarrinho = (pedidoCarrinho) => {
    let id = pedidoCarrinho.getAttribute('data-id');
    let statusResponse = 0;

    fetch(`/client/cardapio/carrinhoModal?id=${id}`)
        .then((response) => {
            statusResponse = response.status;

            return response.json();
        })

        .then((data) => {
            if (statusResponse === 200) {
                document.getElementById('User_Name').value = data.user.name;
                let modal = .Modal(document.getElementById('pedidoCarrinho'), {});
                modal.show();
            })
        .catch((error) => console.log(error));
}

$("#pedidoCarrinho").on("click", function () { AbrirCarrinho(); });

let PreencherModalCarrinho = () => {
    fetch('/client/pedido/atual', {
        method: 'GET',
    })
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            data.forEach(function (item, index) {
                var itemHtml = `<div class="row">
                    <div class="col">
                        <div class="modal-body">
                            <img id="produto-escolhido-imagem" class="img-center img-fluid menu-img rounded-circle" alt="" src="/uploads/produtos/X-Burguer.png">
                        </div>
                    </div>
                    <div class="col">
                        <input type="hidden" id="produto-escolhido-id">
                        <b><span id="pedido-id-nome">${item.nome}</span></b>
                    </div>
                    <div class="col">
                        <b>Valor:</b>
                        <b>R$ <span id="produto-escolhido-valor"></span></b>
                    </div>
                </div>`
                document.getElementById("carrinho-produtos").innerHTML += itemHtml;
            });
            //document.getElementById("pedido-id").value = data.id
            //document.getElementById("produto-escolhido-nome").innerText = data.nome
            //document.getElementById("produto-escolhido-valor").innerText = data.valor
            //document.getElementById("produto-escolhido-imagem").src = "/uploads/produtos/" + data.imagem;
            $("#PedidoModal").modal('show');
        })
        .catch((error) => {
            toastr.error("Não foi possível carregar as informações dos produtos.")
            console.log(error);
        });

}

let produtoAdicionarNoPedido = () => {
    let produtoId = document.getElementById("produto-escolhido-id").value;
    //let quantidade = document.getElementById("quantidade").value;
    let quantidade = document.getElementById("quantidade").innerText;
    let dados = new FormData();
    dados.append("produtoId", produtoId);
    dados.append("quantidade", quantidade);
    console.log(dados);

    fetch('/client/cardapio/adicionarProduto', {
        method: 'POST',
        body: dados
    })
        .then((data) => {
            console.log(data);

            $("#produtoPedidoModal").modal('hide');

            toastr.success("Produto adicionado");

        })
        .catch((error) => {
            console.log(error);
            toastr.error("Não foi possível finalizar o seu pedido.")
        });
}
let gerarPedido = () => {
    let produtoId = document.getElementById("listar-produtos-escolhidos").value;


}
document.getElementById("botao-finalizar-pedido")
    .addEventListener("click", produtoAdicionarNoPedido);