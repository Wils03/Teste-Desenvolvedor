// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using Teste_Desenvolvedor.Models;

Desafio desafio = new Desafio();

//DESAFIO 1
desafio.SomaPorFor(); //Possivel dessa maneira ou
desafio.SomaPorWhile(); // dessa maneira

//DESAFIO 2
Console.WriteLine("Digite um número para verificar se pertence a sequencia de  Fibonacci:");
int numero = Convert.ToInt32(Console.ReadLine());
bool pertence = desafio.Fibonacci(numero);
try
{
    if (pertence)
    {
        Console.WriteLine("O numero informado pertence a sequencia de Fibonacci. \n");
    }
    else
    {
        Console.WriteLine("O numero informado NÃO pertence a sequencia de Fibonacci.\n");
    };
}catch (FormatException ex)
{
    Console.WriteLine($"{ex.Message}\n Entrada inválida.");
};

//DESAFIO 3
string conteudoArquivo = File.ReadAllText("/Teste Desenvolvedor/Arquivos/dados.json");
List<DesafioFaturamento> faturamento = JsonConvert.DeserializeObject<List<DesafioFaturamento>>(conteudoArquivo);

//Selecionando a propriedade Valor da Classe de Faturamento que contenham valor acima de 0.
var valoresFaturamento = faturamento.Where(f => f.Valor > 0)
.Select(f => f.Valor).ToList();
if (valoresFaturamento.Count == 0){
    Console.WriteLine("Nenhum faturamento encontrado");
    return;
}

//Calculando o menor e o maior valor faturado
decimal maiorFaturamento = valoresFaturamento.Max();
int diaMaiorFaturamento = faturamento.Find( f => f.Valor == maiorFaturamento).Dia;

decimal menorFaturamento = valoresFaturamento.Min();
int diaMenorFaturamento = faturamento.Find( f => f.Valor == menorFaturamento).Dia;

//Calcula média de faturamento
decimal mediaMes = valoresFaturamento.Average();
int diasAcimaDaMedia = valoresFaturamento.Count( valor => valor >= mediaMes);

//Imprimindo
Console.WriteLine($"O menor valor de faturamento ocorreu no dia {diaMenorFaturamento}, com  valor de {menorFaturamento.ToString("C")}.");
Console.WriteLine($"O maior valor de faturamento ocorreu no dia {diaMaiorFaturamento}, com valor de {maiorFaturamento.ToString("C")}.");
Console.WriteLine($"Número de dias com faturamento superior à média mensal: {diasAcimaDaMedia} dias.\n");

//DESAFIO 4
var estados = new List<FaturamentoEstados>();

estados.Add(new FaturamentoEstados ("SP", 67836.43M));
estados.Add(new FaturamentoEstados ("RJ", 36678.66M));
estados.Add(new FaturamentoEstados ("MG", 29229.88M));
estados.Add(new FaturamentoEstados ("ES", 27165.38M));
estados.Add(new FaturamentoEstados ("Outros", 19849.53M));

decimal totalFaturamentoEstados = estados.Sum( v => v.Valor);
foreach (var estado in estados){
    decimal porcentagem = CalcularPorcentagem (totalFaturamentoEstados, estado.Valor);
    Console.WriteLine($"A porcentagem do estado de {estado.Estado} é de {porcentagem.ToString("F2")}%.");
}

static decimal CalcularPorcentagem ( decimal total, decimal parte){
    if(total <= 0){
        throw new ArgumentException("Total não pode ser igual a 0");
    }
    return (parte / total) * 100;
}

//DESAFIO 5
Console.WriteLine ("\nDigite uma palavra para ser invertida:");
string palavraInserida = Console.ReadLine ();
string palavraInvertida = InverterPalvara(palavraInserida);
Console.WriteLine (palavraInvertida);

static string InverterPalvara (string pal){
    if (pal == null){
        throw new ArgumentException("Entrada Inválida. Voce não digitou nada."+ pal);
    }
    char [] lista = new char[pal.Length];
    for (int i = 0; i < pal.Length; i++){
        lista[i] = pal[pal.Length - 1 - i];
    }
    string str = new string(lista);
    if ( pal == str){
        Console.WriteLine($"A palavra {pal} é um palindromo.");
    };
    return str;
}