$('#estoque-table').DataTable({
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/fornecedor/estoque/obterItensOrcamentoAtual',
        dataSrc: ''
    },
    processing: true,
    columns: [
        {data: 'material'},
        {data: 'quantidade'},
        {data: 'valor'}
    ],
});