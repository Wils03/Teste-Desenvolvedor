# README
Este README fornece uma visão geral clara dos desafios, explica as soluções e orienta sobre como executar o código.

## Desafios Resolvidos

Este repositório contém soluções para uma série de desafios de programação. As soluções foram implementadas em C# e cobrem os seguintes desafios:

1. **Cálculo de Soma com Loop**
2. **Verificação de Número na Sequência de Fibonacci**
3. **Análise de Faturamento Diário**
4. **Cálculo de Percentual de Faturamento por Estado**
5. **Inversão de String**

### Desafios

#### 1. Cálculo de Soma com Loop

**Descrição:** 
Dado o código que utiliza um loop para calcular a soma dos números inteiros de 1 até um valor definido, o objetivo é determinar o valor final da variável `SOMA` após o processamento.
```csharp
using Newtonsoft.Json;
using Teste_Desenvolvedor.Models;
static void Main(){
    Desafio desafio = new Desafio();
    desafio.SomaPorFor(); //Possivel dessa maneira ou
    desafio.SomaPorWhile(); // dessa maneira
};
public class Desafio
{
        int indice = 13;
        public void SomaPorFor(){
            int soma = 0;
            for (int k = 0 ; k < indice; k++){
                soma += k;    
            };
            Console.WriteLine($"A soma dos número resltou em {soma}.");
        }
        public void SomaPorWhile(){
            int k = 0, soma =0;
            while ( k < indice){
                soma += k;
                k++;
            };
            Console.WriteLine($"A soma dos número resltou em {soma}.");
        }
}
```
**Solução:** 
O código calcula a soma dos números inteiros de 1 até 13. O valor final de `SOMA` é 91.

#### 2. Verificação de Número na Sequência de Fibonacci

**Descrição:** 
Escreva um programa que determine se um número informado pertence à sequência de Fibonacci, que começa com 0 e 1, e onde cada número subsequente é a soma dos dois anteriores.
````csharp
static void Main(){
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
};

public class Desafio{
  public bool Fibonacci( int numero){
            int numAnterior = 0, numSequencia = 1;
            if (numero < 0){
                throw new Exception("Numero inválido. Menor que zero");
            };
            while (numSequencia <= numero){
                if (numSequencia == numero){
                    return true;
                };
                int numeroTemp = numAnterior;
                numAnterior = numSequencia;
                numSequencia = numeroTemp + numAnterior;
            };
            return false;
  }
};
````
**Solução:**
O programa calcula a sequência de Fibonacci até que o número informado seja encontrado ou até que o número exceda o valor informado. Ele verifica se o número está na sequência e retorna uma mensagem confirmando se é um número da sequência ou não.

#### 3. Análise de Faturamento Diário

**Descrição:** 
Dado um vetor com o faturamento diário de uma distribuidora, o programa deve calcular:
- O menor valor de faturamento ocorrido em um dia do mês.
- O maior valor de faturamento ocorrido em um dia do mês.
- O número de dias no mês em que o valor de faturamento diário foi superior à média mensal.
**Importante:** 
Utilizar JSON ou XML como fonte de dados e ignorar dias sem faturamento no cálculo da média.

````csharp
static void Main(){
  string conteudoArquivo = File.ReadAllText("/Teste Desenvolvedor/Arquivos/dados.json");
  List<DesafioFaturamento> faturamento = JsonConvert.DeserializeObject<List<DesafioFaturamento>>(conteudoArquivo);

  //Selecionando a propriedade Valor da Classe de Faturamento que contenham valor acima de 0.
  var valoresFaturamento = faturamento.Where(f => f.Valor > 0).Select(f => f.Valor).ToList();
  if (valoresFaturamento.Count == 0){
    Console.WriteLine("Nenhum faturamento encontrado");
    return;
  }

  //Buscando o menor e o maior valor faturado e o dia
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
};

public class DesafioFaturamento
{
  public int Dia { get; set; }
  public decimal Valor { get; set; }
};
````
**Solução:**
O programa analisa os dados de faturamento, calcula a média mensal e determina o menor e maior valor de faturamento, além de contar o número de dias com faturamento acima da média.

#### 4. Cálculo de Percentual de Faturamento por Estado

**Descrição:** 
Dado o valor de faturamento mensal de uma distribuidora detalhado por estado, o programa deve calcular o percentual de representação que cada estado teve dentro do valor total mensal da distribuidora.
**Dados:**
- SP – R$67.836,43
- RJ – R$36.678,66
- MG – R$29.229,88
- ES – R$27.165,48
- Outros – R$19.849,53
````csharp
static void Main(){
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
  };

  static decimal CalcularPorcentagem ( decimal total, decimal parte){
    if(total <= 0){
        throw new ArgumentException("Total não pode ser igual a 0");
    }
    return (parte / total) * 100;
  };
};

public class FaturamentoEstados{
  public string Estado { get; set; }
  public decimal Valor { get; set; }

  public FaturamentoEstados(string estado, decimal valor)
  {
   Estado = estado;
   Valor = valor;
  }
};
````
**Solução:**
O programa calcula o percentual de faturamento de cada estado em relação ao total mensal, fornecendo o percentual de contribuição de cada estado para o faturamento total.

#### 5. Inversão de String

**Descrição:** 
Escreva um programa que inverta os caracteres de uma string.
**Importante:**
A string pode ser informada através de qualquer entrada ou pode ser previamente definida. É necessário evitar o uso de funções prontas como `reverse`.
````csharp
static void Main(){
  //DESAFIO 5
  Console.WriteLine ("\nDigite uma palavra para ser invertida:");
  string palavraInserida = Console.ReadLine ();
  string palavraInvertida = InverterPalvara(palavraInserida);
  Console.WriteLine (palavraInvertida);

  static string InverterPalvara (string pal){
    if (pal == null){
        throw new ArgumentException("Entrada Inválida. Voce não digitou nada."+ pal);
    };
    char [] lista = new char[pal.Length];
    for (int i = 0; i < pal.Length; i++){
        lista[i] = pal[pal.Length - 1 - i];
    };
    string str = new string(lista);
    if ( pal == str){
        Console.WriteLine($"A palavra {pal} é um palindromo.");
    };
    return str;
  };
};
````
**Solução:**
O programa reverte a string manualmente, construindo a string invertida sem utilizar métodos prontos para inversão.
--------------------------------------
### Como Executar os Códigos

1. Clone o repositório para sua máquina local:
```sh
git clone https://github.com/Wils03/Teste-Desenvolvedor.git
```
2. Navegue até o diretório do projeto:
````sh
cd Teste-Desenvolvedor
````
3. Compile e execute os programas usando o comando dotnet run para cada desafio:
````sh
dotnet run
````

Sinta-se à vontade para explorar o código, fazer melhorias ou contribuir com novos desafios!

## Contato
Para mais informações ou feedback, sinta-se à vontade para entrar em contato pelo LinkedIn: [Wilson Lemos](https://www.linkedin.com/in/wil-lemos)


