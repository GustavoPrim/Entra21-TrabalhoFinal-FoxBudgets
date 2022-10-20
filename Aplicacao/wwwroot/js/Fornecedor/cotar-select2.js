$('#estoqueItem').select2({
    ajax: {
        url: '/fornecedor/material/obterTodosSelect2',
        dataType: 'json',
        processResults: (data) => ({ results: data})
    }
});