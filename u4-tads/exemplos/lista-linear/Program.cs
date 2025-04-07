using System;

namespace ListaLinearEstatica
{
    public class ListaEstatica
    {
        private int[] elementos;
        private int tamanhoMaximo;
        private int tamanhoAtual;

        // Construtor
        public ListaEstatica(int tamanhoMaximo)
        {
            this.tamanhoMaximo = tamanhoMaximo;
            this.elementos = new int[tamanhoMaximo];
            this.tamanhoAtual = 0;
        }

        // Método para inserir um elemento no início da lista
        public bool InserirNoInicio(int valor)
        {
            // Verifica se a lista está cheia
            if (tamanhoAtual == tamanhoMaximo)
            {
                Console.WriteLine("Erro: Lista cheia!");
                return false;
            }

            // Desloca todos os elementos para a direita
            for (int i = tamanhoAtual; i > 0; i--)
            {
                elementos[i] = elementos[i - 1];
            }

            // Insere o novo elemento no início
            elementos[0] = valor;
            tamanhoAtual++;
            return true;
        }

        // Método para inserir um elemento no final da lista
        public bool InserirNoFinal(int valor)
        {
            // Verifica se a lista está cheia
            if (tamanhoAtual == tamanhoMaximo)
            {
                Console.WriteLine("Erro: Lista cheia!");
                return false;
            }

            // Insere o novo elemento no final
            elementos[tamanhoAtual] = valor;
            tamanhoAtual++;
            return true;
        }

        // Método para remover um elemento do início da lista
        public bool RemoverDoInicio()
        {
            // Verifica se a lista está vazia
            if (tamanhoAtual == 0)
            {
                Console.WriteLine("Erro: Lista vazia!");
                return false;
            }

            // Desloca todos os elementos para a esquerda
            for (int i = 0; i < tamanhoAtual - 1; i++)
            {
                elementos[i] = elementos[i + 1];
            }

            tamanhoAtual--;
            return true;
        }

        // Método para remover um elemento do final da lista
        public bool RemoverDoFinal()
        {
            // Verifica se a lista está vazia
            if (tamanhoAtual == 0)
            {
                Console.WriteLine("Erro: Lista vazia!");
                return false;
            }

            // Simplesmente diminui o tamanho atual da lista
            tamanhoAtual--;
            return true;
        }
        
        // Método para inserir um elemento em uma posição específica
        public bool InserirNaPosicao(int valor, int posicao)
        {
            // Verifica se a posição é válida
            if (posicao < 0 || posicao > tamanhoAtual)
            {
                Console.WriteLine("Erro: Posição inválida!");
                return false;
            }
            
            // Verifica se a lista está cheia
            if (tamanhoAtual == tamanhoMaximo)
            {
                Console.WriteLine("Erro: Lista cheia!");
                return false;
            }
            
            // Desloca os elementos a partir da posição para a direita
            for (int i = tamanhoAtual; i > posicao; i--)
            {
                elementos[i] = elementos[i - 1];
            }
            
            // Insere o novo elemento na posição especificada
            elementos[posicao] = valor;
            tamanhoAtual++;
            return true;
        }
        
        // Método para remover um elemento de uma posição específica
        public bool RemoverDaPosicao(int posicao)
        {
            // Verifica se a posição é válida
            if (posicao < 0 || posicao >= tamanhoAtual)
            {
                Console.WriteLine("Erro: Posição inválida!");
                return false;
            }
            
            // Desloca os elementos após a posição para a esquerda
            for (int i = posicao; i < tamanhoAtual - 1; i++)
            {
                elementos[i] = elementos[i + 1];
            }
            
            tamanhoAtual--;
            return true;
        }

        // Método para retornar o tamanho atual da lista
        public int Tamanho()
        {
            return tamanhoAtual;
        }

        // Método para imprimir os elementos da lista
        public void Imprimir()
        {
            if (tamanhoAtual == 0)
            {
                Console.WriteLine("Lista vazia!");
                return;
            }

            Console.Write("Elementos da lista: ");
            for (int i = 0; i < tamanhoAtual; i++)
            {
                Console.Write(elementos[i]);
                if (i < tamanhoAtual - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo de uso
            ListaEstatica lista = new ListaEstatica(10);
            
            // Inserir elementos
            lista.InserirNoFinal(10);
            lista.InserirNoFinal(20);
            lista.InserirNoInicio(5);
            lista.InserirNoFinal(30);
            lista.InserirNoInicio(1);
            
            // Imprimir lista
            Console.WriteLine("Após inserções:");
            lista.Imprimir();
            Console.WriteLine($"Tamanho da lista: {lista.Tamanho()}");
            
            // Inserir em posição específica
            lista.InserirNaPosicao(15, 2);
            Console.WriteLine("\nApós inserir 15 na posição 2:");
            lista.Imprimir();
            
            // Remover elementos
            lista.RemoverDoInicio();
            lista.RemoverDoFinal();
            lista.RemoverDaPosicao(1);
            
            // Imprimir lista novamente
            Console.WriteLine("\nApós remoções:");
            lista.Imprimir();
            Console.WriteLine($"Tamanho da lista: {lista.Tamanho()}");
        }
    }
}