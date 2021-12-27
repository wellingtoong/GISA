function BuscaCep() {
    $(document).ready(function () {

        function limpa_formulario_cep() {
            // Limpa valores do formulário de cep.
            $("#EnderecoViewModel_Cep").val("");
            $("#EnderecoViewModel_Logradouro").val("");
            $("#EnderecoViewModel_Numero").val("");
            $("#EnderecoViewModel_Bairro").val("");
            $("#EnderecoViewModel_Municipio").val("");
            $("#EnderecoViewModel_Estado").val("");
        }

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
                                limpa_formulario_cep();
                                //alert("CEP não encontrado.");
                            }
                        });
                } //end if.
                else {
                    //cep é inválido.
                    limpa_formulario_cep();
                    //alert("Formato de CEP inválido.");
                }
            } //end if.
            else {
                //cep sem valor, limpa formulário.
                limpa_formulario_cep();
            }
        });
    });
}

$(document).ready(function () {
    $("#msg_box").fadeOut(2500);
});