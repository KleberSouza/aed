using System;

namespace FilaCircular
{
    public class FilaCircular
    {
        private int[] elementos;
        private int tamanhoMaximo;
        private int inicio;
        private int fim;
        private int quantidadeElementos;

        // Construtor
        public FilaCircular(int tamanhoMaximo)
        {
            this.tamanhoMaximo = tamanhoMaximo;
            this.elementos = new int[tamanhoMaximo];
            this.inicio = 0;
            this.fim = -1;
            this.quantidadeElementos = 0;
        }

        // Método para verificar se a fila está vazia
        public bool EstaVazia()
        {
            return quantidadeElementos == 0;
        }

        // Método para verificar se a fila está cheia
        public bool EstaCheia()
        {
            return quantidadeElementos == tamanhoMaximo;
        }

        // Método para enfileirar um elemento (enqueue)
        public bool Enfileirar(int valor)
        {
            // Verifica se a fila está cheia
            if (EstaCheia())
            {
                Console.WriteLine("Erro: Fila cheia!");
                return false;
            }

            // Avança o fim circularmente
            fim = (fim + 1) % tamanhoMaximo;
            elementos[fim] = valor;
            quantidadeElementos++;
            return true;
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

            // Obtém o elemento do início
            int valorRemovido = elementos[inicio];
            
            // Avança o início circularmente
            inicio = (inicio + 1) % tamanhoMaximo;
            quantidadeElementos--;
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

            return elementos[inicio];
        }

        // Método para retornar o tamanho atual da fila
        public int Tamanho()
        {
            return quantidadeElementos;
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
            int count = 0;
            int i = inicio;
            
            while (count < quantidadeElementos)
            {
                Console.WriteLine($"[{count}] => {elementos[i]}");
                i = (i + 1) % tamanhoMaximo;
                count++;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo de uso
            FilaCircular fila = new FilaCircular(5);
            
            // Enfileirar elementos
            Console.WriteLine("Enfileirando elementos:");
            fila.Enfileirar(10);
            fila.Enfileirar(20);
            fila.Enfileirar(30);
            fila.Enfileirar(40);
            
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
            
            // Demonstrando a característica circular: enfileirar mais itens
            Console.WriteLine("\nEnfileirando mais elementos (demonstrando circularidade):");
            fila.Enfileirar(50);
            fila.Enfileirar(60);
            fila.Enfileirar(70); // Este deve circular e usar o espaço dos desenfileirados
            
            // Imprimir a fila final
            Console.WriteLine("\nFila final:");
            fila.Imprimir();
            
            // Tentar enfileirar além do limite
            Console.WriteLine("\nTentando enfileirar além do limite:");
            fila.Enfileirar(80); // Deve gerar erro pois a fila está cheia
        }
    }
}