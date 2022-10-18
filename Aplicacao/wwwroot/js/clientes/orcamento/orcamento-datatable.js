$('#tabela-itens').DataTable({
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/material/obterTodos',
        dataSrc: ''
    },
    processing: true,
    columns: [
        {data: 'item'},
        {data: 'quantidade'},
        {
            data: null,
            width: '20%',
            render: function (data, type, material) {
                return `<button class='btn btn-primary pet-editar' data-id='${material.id}'>
                    <i class='fa-solid fa-pencil'></i> Editar
                </button>
                <button class='btn btn-outline-danger pet-apagar' data-id='${material.id}'>
                    <i class='fa-solid fa-trash'></i> Apagar
                </button>`;
            }
        }
    ],
});