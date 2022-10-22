let AbrirCarrinho = (pedidoCarrinho) => {
    let id = pedidoCarrinho.getAttribute('data-id');
    let statusResponse = 0;

    fetch(/client/cardapio / carrinhoModal ? id = ${ id })
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