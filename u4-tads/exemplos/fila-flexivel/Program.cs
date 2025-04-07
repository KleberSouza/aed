using System;

namespace FilaDinamica
{
    // Classe para representar um nó da fila
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

    public class FilaDinamica
    {
        private No inicio;
        private No fim;
        private int quantidade;

        // Construtor
        public FilaDinamica()
        {
            inicio = null;
            fim = null;
            quantidade = 0;
        }

        // Método para verificar se a fila está vazia
        public bool EstaVazia()
        {
            return inicio == null;
        }

        // Método para enfileirar um elemento (enqueue)
        public void Enfileirar(int valor)
        {
            No novoNo = new No(valor);

            // Se a fila estiver vazia, o novo nó será tanto o início quanto o fim
            if (EstaVazia())
            {
                inicio = novoNo;
                fim = novoNo;
            }
            else
            {
                // Caso contrário, adiciona o novo nó no fim da fila
                fim.Proximo = novoNo;
                fim = novoNo;
            }

            quantidade++;
        }

        // Método para desenfileirar um elemento (dequeue)
        public int Desenfileirar()
        {
            // Verifica se a fila está vazia
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Fila vazia!");
                return -1; // Valor de erro
            }

            // Obtém o valor do nó do início
            int valorRemovido = inicio.Valor;

            // Atualiza o início para o próximo nó
            inicio = inicio.Proximo;

            // Se a fila ficar vazia, atualiza também o fim para null
            if (inicio == null)
            {
                fim = null;
            }

            quantidade--;
            return valorRemovido;
        }

        // Método para consultar o primeiro elemento sem removê-lo (peek)
        public int Primeiro()
        {
            // Verifica se a fila está vazia
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Fila vazia!");
                return -1; // Valor de erro
            }

            return inicio.Valor;
        }

        // Método para retornar o tamanho atual da fila
        public int Tamanho()
        {
            return quantidade;
        }

        // Método para imprimir os elementos da fila (do início para o fim)
        public void Imprimir()
        {
            if (EstaVazia())
            {
                Console.WriteLine("Fila vazia!");
                return;
            }

            Console.WriteLine("Elementos da fila (do início para o fim):");
            No atual = inicio;
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
            FilaDinamica fila = new FilaDinamica();
            
            // Enfileirar elementos
            Console.WriteLine("Enfileirando elementos:");
            fila.Enfileirar(10);
            fila.Enfileirar(20);
            fila.Enfileirar(30);
            fila.Enfileirar(40);
            fila.Enfileirar(50);
            
            // Imprimir a fila
            fila.Imprimir();
            Console.WriteLine($"Tamanho da fila: {fila.Tamanho()}");
            Console.WriteLine($"Primeiro elemento: {fila.Primeiro()}");
            
            // Desenfileirar elementos
            Console.WriteLine("\nDesenfileirando elementos:");
            Console.WriteLine($"Elemento removido: {fila.Desenfileirar()}");
            Console.WriteLine($"Elemento removido: {fila.Desenfileirar()}");
            
            // Imprimir a fila após desenfileirar
            Console.WriteLine("\nApós desenfileirar:");
            fila.Imprimir();
            Console.WriteLine($"Tamanho da fila: {fila.Tamanho()}");
            Console.WriteLine($"Primeiro elemento: {fila.Primeiro()}");
            
            // Adicionar mais elementos
            Console.WriteLine("\nAdicionando mais elementos:");
            fila.Enfileirar(60);
            fila.Enfileirar(70);
            fila.Enfileirar(80);
            
            // Imprimir a fila final
            Console.WriteLine("\nFila final:");
            fila.Imprimir();
            Console.WriteLine($"Tamanho da fila: {fila.Tamanho()}");
            
            // Esvaziar a fila
            Console.WriteLine("\nEsvaziando a fila:");
            while (!fila.EstaVazia())
            {
                Console.WriteLine($"Removendo: {fila.Desenfileirar()}");
            }
            
            // Verificar se está vazia
            Console.WriteLine($"\nA fila está vazia? {fila.EstaVazia()}");
        }
    }
}