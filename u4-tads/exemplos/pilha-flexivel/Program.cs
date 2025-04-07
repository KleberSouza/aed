using System;

namespace PilhaDinamica
{
    // Classe para representar um nó da pilha
    public class No
    {
        public int Valor { get; set; }
        public No Proximo { get; set; }

        public No(int valor)
        {
            Valor = valor;
            Proximo = null;
        }
    }

    public class PilhaDinamica
    {
        private No topo;
        private int quantidade;

        // Construtor
        public PilhaDinamica()
        {
            topo = null;
            quantidade = 0;
        }

        // Método para verificar se a pilha está vazia
        public bool EstaVazia()
        {
            return topo == null;
        }

        // Método para empilhar um elemento (push)
        public void Empilhar(int valor)
        {
            No novoNo = new No(valor);
            
            // O próximo do novo nó será o antigo topo
            novoNo.Proximo = topo;
            
            // O novo nó se torna o novo topo
            topo = novoNo;
            
            quantidade++;
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

            // Obtém o valor do nó do topo
            int valorRemovido = topo.Valor;

            // Atualiza o topo para o próximo nó
            topo = topo.Proximo;

            quantidade--;
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

            return topo.Valor;
        }

        // Método para retornar o tamanho atual da pilha
        public int Tamanho()
        {
            return quantidade;
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
            No atual = topo;
            int posicao = 0;

            while (atual != null)
            {
                Console.WriteLine($"[{posicao}] => {atual.Valor}");
                atual = atual.Proximo;
                posicao++;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo de uso
            PilhaDinamica pilha = new PilhaDinamica();
            
            // Empilhar elementos
            Console.WriteLine("Empilhando elementos:");
            pilha.Empilhar(10);
            pilha.Empilhar(20);
            pilha.Empilhar(30);
            pilha.Empilhar(40);
            pilha.Empilhar(50);
            
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
            
            // Adicionar mais elementos
            Console.WriteLine("\nAdicionando mais elementos:");
            pilha.Empilhar(60);
            pilha.Empilhar(70);
            
            // Imprimir a pilha final
            Console.WriteLine("\nPilha final:");
            pilha.Imprimir();
            Console.WriteLine($"Tamanho da pilha: {pilha.Tamanho()}");
            
            // Esvaziar a pilha
            Console.WriteLine("\nEsvaziando a pilha:");
            while (!pilha.EstaVazia())
            {
                Console.WriteLine($"Removendo: {pilha.Desempilhar()}");
            }
            
            // Verificar se está vazia
            Console.WriteLine($"\nA pilha está vazia? {pilha.EstaVazia()}");
        }
    }
}