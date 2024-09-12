using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Desenvolvedor.Models
{
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

        public bool Fibonacci( int numero){
            int numAnterior = 0, numSequencia = 1;
            if (numero < 0){
                throw new Exception("Numero inválido. Menor que zero");
            }
            while (numSequencia <= numero){
                if (numSequencia == numero){
                    return true;
                }
                int numeroTemp = numAnterior;
                numAnterior = numSequencia;
                numSequencia = numeroTemp + numAnterior;
            }
            return false;
        }
    }
}