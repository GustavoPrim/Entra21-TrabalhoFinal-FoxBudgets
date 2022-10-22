const mais = document.querySelector(".mais"),
    menos = document.querySelector(".menos"),
    qtd = document.querySelector(".qtd");

let quantidade = 1;

mais.addEventListener("click", () => {
    quantidade++;
    quantidade = (quantidade < 10) ? "0" + quantidade : quantidade;
    qtd.innerText = quantidade;
});

menos.addEventListener("click", () => {
    if (quantidade > 1) {
        quantidade--;
        quantidade = (quantidade < 10) ? "0" + quantidade : quantidade;
        qtd.innerText = quantidade;
    }
});

$('body').on('click', 'button.carrinho-adicionar-produto', (event) => {
    let element = event.target.tagName === 'I'
        ? event.target.parentElement
        : event.target;
    let id = element.getAttribute("data-id");
    PreencherModal(id);
});

let PreencherModal = (id) => {
    fetch('/client/produto/obterPorId?id=' + id, {
        method: 'GET',
    })
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            console.log(data);

            document.getElementById("produto-escolhido-id").value = data.id
            document.getElementById("produto-escolhido-nome").innerText = data.nome
            document.getElementById("produto-escolhido-valor").innerText = data.valor
            document.getElementById("produto-escolhido-imagem").src = "/uploads/produtos/" + data.imagem;
            $("#produtoPedidoModal").modal('show');
        })
        .catch((error) => {
            toaster.error("Não foi possível carregar as informações do produto")
            console.log(error);
        });

}

let produtoAdicionarNoPedido = () => {
    let produtoId = document.getElementById("produto-escolhido-id").value;
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
            toastr.error("Não foi possível finalizar seu pedido")
        });
}
let gerarPedido = () => {
    let produtoId = document.getElementById("listar-produtos-escolhidos").value;


}

document.getElementById("botao-finalizar-pedido")
    .addEventListener("click", produtoAdicionarNoPedido);
