using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Classe com Métodos de Validação de CNPJ
/// </summary>
public class CNPJ
{
    /// <summary>
    /// Construtor da Classe para formatação de Dígitos
    /// </summary>
    /// <param name="digitos">Dígitos do CNPJ</param>
    /// <exception cref="ArgumentException"></exception>
    public CNPJ(string digitos)
    {
        //Verificação do Formato do CNPJ Inserido
        digitos = digitos.Replace(".", "").Replace("/", "").Replace("-", "").Trim();
        if (String.IsNullOrEmpty(digitos))
            throw new ArgumentException("O CNPJ não pode ser vazio.");
        if (digitos.Length != 14)
            throw new ArgumentException("O CNPJ deve possuir todos os 14 dígitos.");
        if (!long.TryParse(digitos, out long digitosFormatados))
            throw new ArgumentException("O CNPJ deve ser composto somente por dígitos númericos.");

        //Guardar os Dígitos do CNPJ
        this.Digitos = digitos;
    }

    /// <summary>
    /// Propriedade que guarda todos os Dígitos do CNPJ
    /// </summary>
    public string Digitos { get; set; }

    /// <summary>
    /// Método que retorna a validade do Documento CNPJ
    /// </summary>
    /// <returns>Retorna a Validade do Documento</returns>
    public bool Validar()
    {
        //Caso haja somente números iguais, retornar que é Falso o Documento
        if (this.Digitos == new string(Convert.ToChar(this.Digitos.Substring(0, 1)), 14))
            return false;

        //Gerar o CNPJ Válido e Padrão
        int digitoVerificador1 = GerarDigitoVerificador(this.Digitos.Substring(0, 12));
        int digitoVerificador2 = GerarDigitoVerificador(this.Digitos.Substring(0, 12) + digitoVerificador1);
        string CNPJReal = Digitos.Substring(0, 12) + digitoVerificador1.ToString() + digitoVerificador2.ToString();

        //Enviar resposta da Validação
        return this.Digitos == CNPJReal ? true : false;
    }

    //Método que realiza os cálculos para gerar os Dígitos Verificadores
    private int GerarDigitoVerificador(string digitos)
    {
        //Calcular as Multiplicações de cada Dígito do CNPJ
        int soma = 0;
        int multiplicador = digitos.Length - 7;
        for (int indice = 0; indice < digitos.Length; indice++)
        {
            soma += int.Parse(digitos.Substring(indice, 1)) * multiplicador;
            multiplicador--;
            if (multiplicador == 1)
                multiplicador = 9;
        }

        //Retornar o Dígito Validador
        int resto = soma % 11;
        if (resto > 1)
            return 11 - resto;
        else
            return 0;
    }
}