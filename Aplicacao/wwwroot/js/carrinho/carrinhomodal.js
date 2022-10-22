let PreencherModal = (id) => {
    fetch('/client/item/obterPorId?id=' + id, {
        method: 'GET',
    })
        .then((response) => {
            return response.json();
        })
        .then((data) => {
            console.log(data);

            document.getElementById("item-escolhido-id").value = data.id
            document.getElementById("item-escolhido-nome").innerText = data.nome
            document.getElementById("item-escolhido-valor").innerText = data.valor
            document.getElementById("item-escolhido-imagem").src = "/uploads/produtos/" + data.imagem;
            $("#produtoPedidoModal").modal('show');
        })
        .catch((error) => {
            toaster.error("Não foi possível carregar as informações do produto")
            console.log(error);
        });

} 