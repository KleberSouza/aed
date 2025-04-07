using System;

namespace ListaEncadeadaDupla
{
    // Classe para representar um nó da lista duplamente encadeada
    public class No
    {
        public int Valor { get; set; }
        public No Proximo { get; set; }
        public No Anterior { get; set; }

        public No(int valor)
        {
            Valor = valor;
            Proximo = null;
            Anterior = null;
        }
    }

    public class ListaEncadeadaDupla
    {
        private No cabeca;
        private No cauda;
        private int quantidade;

        // Construtor
        public ListaEncadeadaDupla()
        {
            cabeca = null;
            cauda = null;
            quantidade = 0;
        }

        // Método para verificar se a lista está vazia
        public bool EstaVazia()
        {
            return cabeca == null;
        }

        // Método para inserir no início da lista
        public void InserirNoInicio(int valor)
        {
            No novoNo = new No(valor);
            
            if (EstaVazia())
            {
                cabeca = novoNo;
                cauda = novoNo;
            }
            else
            {
                // Conecta o novo nó com a antiga cabeça
                novoNo.Proximo = cabeca;
                cabeca.Anterior = novoNo;
                
                // Atualiza a cabeça
                cabeca = novoNo;
            }
            
            quantidade++;
        }

        // Método para inserir no final da lista
        public void InserirNoFinal(int valor)
        {
            No novoNo = new No(valor);
            
            if (EstaVazia())
            {
                cabeca = novoNo;
                cauda = novoNo;
            }
            else
            {
                // Conecta o novo nó com a antiga cauda
                novoNo.Anterior = cauda;
                cauda.Proximo = novoNo;
                
                // Atualiza a cauda
                cauda = novoNo;
            }
            
            quantidade++;
        }

        // Método para inserir em uma posição específica
        public bool InserirNaPosicao(int valor, int posicao)
        {
            // Verifica se a posição é válida
            if (posicao < 0 || posicao > quantidade)
            {
                Console.WriteLine("Erro: Posição inválida!");
                return false;
            }
            
            // Se a posição for 0, insere no início
            if (posicao == 0)
            {
                InserirNoInicio(valor);
                return true;
            }
            
            // Se a posição for igual ao tamanho, insere no final
            if (posicao == quantidade)
            {
                InserirNoFinal(valor);
                return true;
            }
            
            // Cria o novo nó
            No novoNo = new No(valor);
            
            // Decide se começa a percorrer do início ou do fim (otimização)
            if (posicao <= quantidade / 2)
            {
                // Percorre do início até a posição
                No atual = cabeca;
                for (int i = 0; i < posicao; i++)
                {
                    atual = atual.Proximo;
                }
                
                No anterior = atual.Anterior;
                
                // Faz as conexões
                novoNo.Anterior = anterior;
                novoNo.Proximo = atual;
                anterior.Proximo = novoNo;
                atual.Anterior = novoNo;
            }
            else
            {
                // Percorre do fim até a posição
                No atual = cauda;
                for (int i = quantidade - 1; i > posicao; i--)
                {
                    atual = atual.Anterior;
                }
                
                No proximo = atual;
                No anterior = atual.Anterior;
                
                // Faz as conexões
                novoNo.Anterior = anterior;
                novoNo.Proximo = proximo;
                anterior.Proximo = novoNo;
                proximo.Anterior = novoNo;
            }
            
            quantidade++;
            return true;
        }

        // Método para remover do início da lista
        public int RemoverDoInicio()
        {
            // Verifica se a lista está vazia
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Lista vazia!");
                return -1; // Valor de erro
            }
            
            // Obtém o valor da cabeça
            int valorRemovido = cabeca.Valor;
            
            // Se a lista tem apenas um elemento
            if (cabeca == cauda)
            {
                cabeca = null;
                cauda = null;
            }
            else
            {
                // Atualiza a cabeça
                cabeca = cabeca.Proximo;
                cabeca.Anterior = null;
            }
            
            quantidade--;
            return valorRemovido;
        }

        // Método para remover do final da lista
        public int RemoverDoFinal()
        {
            // Verifica se a lista está vazia
            if (EstaVazia())
            {
                Console.WriteLine("Erro: Lista vazia!");
                return -1; // Valor de erro
            }
            
            // Obtém o valor da cauda
            int valorRemovido = cauda.Valor;
            
            // Se a lista tem apenas um elemento
            if (cabeca == cauda)
            {
                cabeca = null;
                cauda = null;
            }
            else
            {
                // Atualiza a cauda
                cauda = cauda.Anterior;
                cauda.Proximo = null;
            }
            
            quantidade--;
            return valorRemovido;
        }

        // Método para remover de uma posição específica
        public int RemoverDaPosicao(int posicao)
        {
            // Verifica se a posição é válida
            if (posicao < 0 || posicao >= quantidade)
            {
                Console.WriteLine("Erro: Posição inválida!");
                return -1; // Valor de erro
            }
            
            // Se a posição for 0, remove do início
            if (posicao == 0)
            {
                return RemoverDoInicio();
            }
            
            // Se a posição for a última, remove do final
            if (posicao == quantidade - 1)
            {
                return RemoverDoFinal();
            }
            
            No noRemover;
            
            // Decide se começa a percorrer do início ou do fim (otimização)
            if (posicao <= quantidade / 2)
            {
                // Percorre do início até a posição
                noRemover = cabeca;
                for (int i = 0; i < posicao; i++)
                {
                    noRemover = noRemover.Proximo;
                }
            }
            else
            {
                // Percorre do fim até a posição
                noRemover = cauda;
                for (int i = quantidade - 1; i > posicao; i--)
                {
                    noRemover = noRemover.Anterior;
                }
            }
            
            // Obtém o valor do nó a ser removido
            int valorRemovido = noRemover.Valor;
            
            // Atualiza as referências para remover o nó
            noRemover.Anterior.Proximo = noRemover.Proximo;
            noRemover.Proximo.Anterior = noRemover.Anterior;
            
            quantidade--;
            return valorRemovido;
        }

        // Método para buscar um elemento na lista
        public int BuscarPosicao(int valor)
        {
            if (EstaVazia())
            {
                return -1; // Não encontrado
            }
            
            No atual = cabeca;
            int posicao = 0;
            
            while (atual != null)
            {
                if (atual.Valor == valor)
                {
                    return posicao;
                }
                
                atual = atual.Proximo;
                posicao++;
            }
            
            return -1; // Não encontrado
        }

        // Método para retornar o tamanho atual da lista
        public int Tamanho()
        {
            return quantidade;
        }

        // Método para imprimir os elementos da lista do início para o fim
        public void ImprimirDoInicio()
        {
            if (EstaVazia())
            {
                Console.WriteLine("Lista vazia!");
                return;
            }

            Console.WriteLine("Elementos da lista (do início para o fim):");
            No atual = cabeca;
            int posicao = 0;

            while (atual != null)
            {
                Console.WriteLine($"[{posicao}] => {atual.Valor}");
                atual = atual.Proximo;
                posicao++;
            }
        }

        // Método para imprimir os elementos da lista do fim para o início
        public void ImprimirDoFim()
        {
            if (EstaVazia())
            {
                Console.WriteLine("Lista vazia!");
                return;
            }

            Console.WriteLine("Elementos da lista (do fim para o início):");
            No atual = cauda;
            int posicao = quantidade - 1;

            while (atual != null)
            {
                Console.WriteLine($"[{posicao}] => {atual.Valor}");
                atual = atual.Anterior;
                posicao--;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo de uso
            ListaEncadeadaDupla lista = new ListaEncadeadaDupla();
            
            // Inserir elementos
            Console.WriteLine("Inserindo elementos:");
            lista.InserirNoInicio(30);
            lista.InserirNoInicio(20);
            lista.InserirNoInicio(10);
            lista.InserirNoFinal(40);
            lista.InserirNoFinal(50);
            
            // Imprimir a lista nos dois sentidos
            lista.ImprimirDoInicio();
            Console.WriteLine();
            lista.ImprimirDoFim();
            Console.WriteLine($"Tamanho da lista: {lista.Tamanho()}");
            
            // Inserir em posição específica
            Console.WriteLine("\nInserindo 35 na posição 3:");
            lista.InserirNaPosicao(35, 3);
            lista.ImprimirDoInicio();
            
            // Buscar elemento
            int valorBusca = 35;
            int posicao = lista.BuscarPosicao(valorBusca);
            Console.WriteLine($"\nO valor {valorBusca} está na posição: {posicao}");
            
            // Remover elementos
            Console.WriteLine("\nRemovendo elementos:");
            Console.WriteLine($"Removido do início: {lista.RemoverDoInicio()}");
            Console.WriteLine($"Removido do final: {lista.RemoverDoFinal()}");
            Console.WriteLine($"Removido da posição 2: {lista.RemoverDaPosicao(2)}");
            
            // Imprimir a lista final
            Console.WriteLine("\nLista final:");
            lista.ImprimirDoInicio();
            Console.WriteLine($"Tamanho da lista: {lista.Tamanho()}");
        }
    }
}