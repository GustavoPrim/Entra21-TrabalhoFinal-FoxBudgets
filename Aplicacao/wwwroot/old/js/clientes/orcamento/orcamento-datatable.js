$('#orcamento-table').DataTable({
    language: {
        url: 'https://raw.githubusercontent.com/DataTables/Plugins/master/i18n/pt-BR.json'
    },
    ajax: {
        url: '/material/obterTodos',
        dataSrc: ''
    },
    processing: true,
    columns: [
        {
            //class: 'text-center',
            //data: null,
            //width: '10%',
            //render: function (data, type, pet) {
            //    if(pet.caminhoArquivo !== ''){
            //        return `<img class="img-pet" src="/Uploads/Pets/${pet.caminhoArquivo}" alt="dog"/>`;
            //    }

            //    return `<img class="img-pet" src="/images/pet.png" alt="dog"/>`;
            //}
        },
        {data: 'material.material'},
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