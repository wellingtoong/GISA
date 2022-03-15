var app = {}

app.eventos = {

    init: () => {

        console.log('App init')

        /*$("#msg_box").fadeOut(2500);*/

        setTimeout(() => {
            app.metodos.initializeTooltip();
        }, 3000)

    }

}

app.metodos = {

    // cria um novo guid
    newGuid: () => { return '{00000000-0000-0000-0000-000000000000}' },

    // seta um localstorage
    setLocalStorage: (local, data) => {
        window.localStorage.removeItem(local);
        window.localStorage.setItem(local, JSON.stringify(data));
    },

    // pega um localstorage
    getLocalStorage: (local) => {
        return JSON.parse(window.localStorage.getItem(local));
    },

    // permite apenas números
    onlynumber: (evt) => {
        var theEvent = evt || window.event;
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);

        var regex = /^[0-9.]+$/;
        if (!regex.test(key)) {
            theEvent.returnValue = false;
            if (theEvent.preventDefault) theEvent.preventDefault();
        }
    },

    // inicializa tooltips
    initializeTooltip: () => {
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
        tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl)
        })
    },

    // formata data padrão Pt-BR dd/MM/yyyy
    formataDataBR: (data) => {

        var data = new Date(data);
        return data.toLocaleDateString('pt-BR', { timeZone: 'UTC' });

    },

    // inicializa a validação do formulário
    initValidateForm: (validate = "False") => {

        if (validate == "" || validate == null || validate == undefined) return;

        if (validate == "True") {
            // Fetch all the forms we want to apply custom Bootstrap validation styles to
            var forms = document.querySelectorAll('.needs-validation')

            // Loop over them and prevent submission
            Array.prototype.slice.call(forms)
                .forEach(function (form) {
                    form.addEventListener('submit', function (event) {
                        if (!form.checkValidity()) {
                            event.preventDefault()
                            event.stopPropagation()
                        }

                        form.classList.add('was-validated')
                    }, false)
                })
        }
    },

    // busca ceps
    buscarCep: () => {
        //Quando o campo cep perde o foco.
        $("#EnderecoViewModel_Cep").blur(function () {

            //Nova variável "cep" somente com dígitos.
            var cep = $(this).val().replace(/\D/g, '');

            //Verifica se campo cep possui valor informado.
            if (cep != "") {

                //Expressão regular para validar o CEP.
                var validacep = /^[0-9]{8}$/;

                //Valida o formato do CEP.
                if (validacep.test(cep)) {

                    //Preenche os campos com "..." enquanto consulta webservice.
                    $("#EnderecoViewModel_Logradouro").val("...");
                    $("#EnderecoViewModel_Bairro").val("...");
                    $("#EnderecoViewModel_Municipio").val("...");
                    $("#EnderecoViewModel_Estado").val("...");

                    //Consulta o webservice viacep.com.br/
                    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?",
                        function (dados) {

                            if (!("erro" in dados)) {
                                //Atualiza os campos com os valores da consulta.
                                $("#EnderecoViewModel_Logradouro").val(dados.logradouro);
                                $("#EnderecoViewModel_Bairro").val(dados.bairro);
                                $("#EnderecoViewModel_Municipio").val(dados.localidade);
                                $("#EnderecoViewModel_Estado").val(dados.uf);
                            } //end if.
                            else {
                                //CEP pesquisado não foi encontrado.
                                app.metodos.limpaFormularioCep();
                                //alert("CEP não encontrado.");
                            }
                        });
                } //end if.
                else {
                    //cep é inválido.
                    app.metodos.limpaFormularioCep();
                    //alert("Formato de CEP inválido.");
                }
            } //end if.
            else {
                //cep sem valor, limpa formulário.
                app.metodos.limpaFormularioCep();
            }
        });
    },

    // limpa formulário de endereços
    limpaFormularioCep: () => {
        // Limpa valores do formulário de cep.
        $("#EnderecoViewModel_Cep").val("");
        $("#EnderecoViewModel_Logradouro").val("");
        $("#EnderecoViewModel_Numero").val("");
        $("#EnderecoViewModel_Bairro").val("");
        $("#EnderecoViewModel_Municipio").val("");
        $("#EnderecoViewModel_Estado").val("");
    },

    // centraliza as chamadas de get
    get: (url, callbackSuccess, callbackError) => {

        try {

            $.ajax({
                url: url,
                method: 'GET',
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                success: (response) => callbackSuccess(response),
                error: (xhr, ajaxOptions, error) => {

                    callbackError(xhr, ajaxOptions, error)
                }
            });

        }
        catch (ex) {
            return callbackError(null, null, ex);
        }

    },

    // centraliza as chamadas de post
    post: (url, dados, callbackSuccess, callbackError) => {

        try {

            $.ajax({
                url: url,
                method: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                data: dados,
                success: (response) => callbackSuccess(response),
                error: (xhr, ajaxOptions, error) => {

                    callbackError(xhr, ajaxOptions, error)
                }
            });

        }
        catch (ex) {
            return callbackError(null, null, ex);
        }

    },

    // centraliza as chamadas de put
    put: (url, dados, callbackSuccess, callbackError) => {

        try {
            if (app.metodos.validaToken()) {

                $.ajax({
                    url: url,
                    method: 'PUT',
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    data: dados,
                    success: (response) => callbackSuccess(response),
                    error: (xhr, ajaxOptions, error) => {

                        callbackError(xhr, ajaxOptions, error)
                    }
                });

            }
        }
        catch (ex) {
            return callbackError(null, null, ex);
        }

    },
}