let adicionarItem = () => {
    let item = document.getElementById("estoqueItem").value;
    let quantidade = document.getElementById("estoqueQuantidade").value;
    let valor = document.getElementById("estoqueValor").value;

    let dados = new FormData();
    dados.append("item", item);
    dados.append("quantidade", quantidade)
    dados.append("valor", valor)
    debugger;   

    fetch('/fornecedor/estoque/adicionarProduto', {
        method: 'POST',
        body: dados
    })
        .then((data) => {
            console.log(data);

            $('#estoque-table').DataTable().ajax.reload();
            toastr.success("Item adicionado com sucesso");
           

        })
        .catch((error) => {
            debugger;
            toastr.error("Não foi possível adionar o item ao estoque");
            console.log(error);
        });
}

document.getElementById("botao-adicionar-item")
    .addEventListener("click", adicionarItem);