$('#orcamentoItem').select2({
    ajax: {
        url: '/cliente/material/obterTodosSelect2',
        dataType: 'json',
        processResults: (data) => ({ results: data})
    }
});