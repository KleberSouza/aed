using System;

namespace ListaEncadeadaSimples
{
    // Classe para representar um nó da lista
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

    public class ListaEncadeada
    {
        private No cabeca;
        private int quantidade;

        // Construtor
        public ListaEncadeada()
        {
            cabeca = null;
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
            
            // O próximo do novo nó será a antiga cabeça
            novoNo.Proximo = cabeca;
            
            // O novo nó se torna a nova cabeça
            cabeca = novoNo;
            
            quantidade++;
        }

        // Método para inserir no final da lista
        public void InserirNoFinal(int valor)
        {
            No novoNo = new No(valor);
            
            // Se a lista estiver vazia, o novo nó será a cabeça
            if (EstaVazia())
            {
                cabeca = novoNo;
            }
            else
            {
                // Percorre até o último nó
                No atual = cabeca;
                while (atual.Proximo != null)
                {
                    atual = atual.Proximo;
                }
                
                // Adiciona o novo nó após o último
                atual.Proximo = novoNo;
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
            
            // Percorre até a posição anterior onde deseja inserir
            No anterior = cabeca;
            for (int i = 0; i < posicao - 1; i++)
            {
                anterior = anterior.Proximo;
            }
            
            // Insere o novo nó na posição desejada
            novoNo.Proximo = anterior.Proximo;
            anterior.Proximo = novoNo;
            
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
            
            // Atualiza a cabeça para o próximo nó
            cabeca = cabeca.Proximo;
            
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
            
            // Se a lista tem apenas um elemento
            if (cabeca.Proximo == null)
            {
                int valorRemovido = cabeca.Valor;
                cabeca = null;
                quantidade--;
                return valorRemovido;
            }
            
            // Percorre até o penúltimo nó
            No atual = cabeca;
            while (atual.Proximo.Proximo != null)
            {
                atual = atual.Proximo;
            }
            
            // Obtém o valor do último nó
            int valor = atual.Proximo.Valor;
            
            // Remove o último nó
            atual.Proximo = null;
            
            quantidade--;
            return valor;
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
            
            // Percorre até a posição anterior à desejada
            No anterior = cabeca;
            for (int i = 0; i < posicao - 1; i++)
            {
                anterior = anterior.Proximo;
            }
            
            // Obtém o valor do nó a ser removido
            int valorRemovido = anterior.Proximo.Valor;
            
            // Remove o nó da posição desejada
            anterior.Proximo = anterior.Proximo.Proximo;
            
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

        // Método para imprimir os elementos da lista
        public void Imprimir()
        {
            if (EstaVazia())
            {
                Console.WriteLine("Lista vazia!");
                return;
            }

            Console.WriteLine("Elementos da lista:");
            No atual = cabeca;
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
            ListaEncadeada lista = new ListaEncadeada();
            
            // Inserir elementos
            Console.WriteLine("Inserindo elementos:");
            lista.InserirNoInicio(30);
            lista.InserirNoInicio(20);
            lista.InserirNoInicio(10);
            lista.InserirNoFinal(40);
            lista.InserirNoFinal(50);
            
            // Imprimir a lista
            lista.Imprimir();
            Console.WriteLine($"Tamanho da lista: {lista.Tamanho()}");
            
            // Inserir em posição específica
            Console.WriteLine("\nInserindo 35 na posição 3:");
            lista.InserirNaPosicao(35, 3);
            lista.Imprimir();
            
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
            lista.Imprimir();
            Console.WriteLine($"Tamanho da lista: {lista.Tamanho()}");
        }
    }
}