let adicionarItem = () => {
    let item = document.getElementById("estoqueItem").value;
    let quantidade = document.getElementById("estoqueQuantidade").value;
    let valor = document.getElementById("estoqueValor").value;

    let dados = new FormData();
    dados.append("item", item);
    dados.append("quantidade", quantidade)
    dados.append("valor", valor)
    debugger;   

    fetch('/fornecedores/estoque/adicionarProduto', {
        method: 'POST',
        body: dados
    })
        .then((data) => {
            debugger;
            console.log(data);

            $('#estoque-table').DataTable().ajax.reload();
            return;

        })
        .catch((error) => {
            debugger;
            toastr.error("Não foi possível adionar o item ao orçamento");
            console.log(error);
        });
}

document.getElementById("botao-adicionar-item")
    .addEventListener("click", adicionarItem);