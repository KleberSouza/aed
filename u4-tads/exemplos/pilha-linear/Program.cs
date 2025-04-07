using System;

namespace PilhaEstatica
{
    public class Pilha
    {
        private int[] elementos;
        private int tamanhoMaximo;
        private int topo;

        // Construtor
        public Pilha(int tamanhoMaximo)
        {
            this.tamanhoMaximo = tamanhoMaximo;
            this.elementos = new int[tamanhoMaximo];
            this.topo = -1; // Indica pilha vazia
        }

        // Método para verificar se a pilha está vazia
        public bool EstaVazia()
        {
            return topo == -1;
        }

        // Método para verificar se a pilha está cheia
        public bool EstaCheia()
        {
            return topo == tamanhoMaximo - 1;
        }

        // Método para empilhar um elemento (push)
        public bool Empilhar(int valor)
        {
            // Verifica se a pilha está cheia
            if (EstaCheia())
            {
                Console.WriteLine("Erro: Pilha cheia!");
                return false;
            }

            // Incrementa o topo e insere o novo elemento
            topo++;
            elementos[topo] = valor;
            return true;
        }

        // Método para desempilhar um elemento (pop)
        public int Desempilhar()
        {
            // Verifica se a pilha está vazia
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Pilha vazia!");
                return -1; // Valor de erro
            }

            // Obtém o elemento do topo e decrementa o topo
            int valorRemovido = elementos[topo];
            topo--;
            return valorRemovido;
        }

        // Método para consultar o elemento do topo sem removê-lo (peek)
        public int Topo()
        {
            // Verifica se a pilha está vazia
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Pilha vazia!");
                return -1; // Valor de erro
            }

            return elementos[topo];
        }

        // Método para retornar o tamanho atual da pilha
        public int Tamanho()
        {
            return topo + 1;
        }

        // Método para imprimir os elementos da pilha (do topo para a base)
        public void Imprimir()
        {
            if (EstaVazia())
            {
                Console.WriteLine("Pilha vazia!");
                return;
            }

            Console.WriteLine("Elementos da pilha (do topo para a base):");
            for (int i = topo; i >= 0; i--)
            {
                Console.WriteLine($"[{i}] => {elementos[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo de uso
            Pilha pilha = new Pilha(5);
            
            // Empilhar elementos
            Console.WriteLine("Empilhando elementos:");
            pilha.Empilhar(10);
            pilha.Empilhar(20);
            pilha.Empilhar(30);
            pilha.Empilhar(40);
            
            // Imprimir a pilha
            pilha.Imprimir();
            Console.WriteLine($"Tamanho da pilha: {pilha.Tamanho()}");
            Console.WriteLine($"Elemento do topo: {pilha.Topo()}");
            
            // Desempilhar elementos
            Console.WriteLine("\nDesempilhando elementos:");
            Console.WriteLine($"Elemento removido: {pilha.Desempilhar()}");
            Console.WriteLine($"Elemento removido: {pilha.Desempilhar()}");
            
            // Imprimir a pilha após desempilhar
            Console.WriteLine("\nApós desempilhar:");
            pilha.Imprimir();
            Console.WriteLine($"Tamanho da pilha: {pilha.Tamanho()}");
            Console.WriteLine($"Elemento do topo: {pilha.Topo()}");
            
            // Tentar empilhar além do limite
            Console.WriteLine("\nTentando empilhar além do limite:");
            pilha.Empilhar(50);
            pilha.Empilhar(60);
            pilha.Empilhar(70);
            pilha.Empilhar(80); // Deve gerar erro
            
            // Imprimir a pilha final
            Console.WriteLine("\nPilha final:");
            pilha.Imprimir();
        }
    }
}