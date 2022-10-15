let adicionarItem = () => {
    let item = document.getElementById("campo-item").value;
    let quantidade = document.getElementById("campo-quantidade").value;

    let dados = new FormData();
    dados.append("item", item);
    dados.append("quantidade", quantidade)

    fetch('/cliente/cotacao/cotar', {
        method: 'POST',
        body: dados
    })
        .then((data) => {
            console.log(data);

            toastr.sucess("Item adicionado com sucesso");

            $('#tabela-itens').DataTable().ajax.reload();

            bootstrap.Modal.getInstance(
                document.getElementById('exampleModal')).hide();
        })
        .catch((error) => {
            toastr.error("Não foi possível adionar o item ao orçamento");
            console.log(error);
        });
}

document.getElementById("botao-adicionar-item")
    .addEventListener("click", adicionarItem);