# Exercícios de Lista Linear Estática com Vetores

Bem-vindo(a) a esta página de exercícios sobre Lista Linear Estática com Vetores em C#! Para cada exercício, tente desenvolver sua solução antes de verificar a resposta.

## Exercício 1: Implementação básica de uma Lista Linear Estática

Implemente uma classe `ListaEstatica` que utilize um vetor para armazenar elementos inteiros, com as operações básicas: inserir no final, obter elemento por índice, tamanho atual e capacidade máxima.

<details>
  <summary>Ver solução</summary>
  
```csharp
public class ListaEstatica
{
    private int[] elementos;
    private int tamanho;
    
    public ListaEstatica(int capacidade)
    {
        elementos = new int[capacidade];
        tamanho = 0;
    }
    
    public bool Inserir(int elemento)
    {
        // Verifica se a lista está cheia
        if (tamanho >= elementos.Length)
            return false;
        
        elementos[tamanho] = elemento;
        tamanho++;
        return true;
    }
    
    public int ObterElemento(int indice)
    {
        // Verifica se o índice é válido
        if (indice < 0 || indice >= tamanho)
            throw new IndexOutOfRangeException("Índice inválido");
        
        return elementos[indice];
    }
    
    public int Tamanho()
    {
        return tamanho;
    }
    
    public int Capacidade()
    {
        return elementos.Length;
    }
}
```

Esta implementação básica fornece uma estrutura de lista estática com controle de tamanho atual e capacidade máxima. O método `Inserir` adiciona elementos ao final da lista, enquanto `ObterElemento` recupera valores por índice.
</details>

## Exercício 2: Inserção em posição específica

Adicione à classe `ListaEstatica` um método para inserir um elemento em uma posição específica, deslocando os elementos seguintes.

<details>
  <summary>Ver solução</summary>
  
```csharp
public bool InserirEm(int elemento, int posicao)
{
    // Verifica se a posição é válida
    if (posicao < 0 || posicao > tamanho)
        return false;
        
    // Verifica se a lista está cheia
    if (tamanho >= elementos.Length)
        return false;
    
    // Desloca os elementos seguintes para abrir espaço
    for (int i = tamanho; i > posicao; i--)
    {
        elementos[i] = elementos[i - 1];
    }
    
    // Insere o elemento na posição desejada
    elementos[posicao] = elemento;
    tamanho++;
    return true;
}
```

Este método permite inserir um elemento em qualquer posição válida da lista, deslocando todos os elementos à direita da posição para abrir espaço. A operação tem complexidade O(n) no pior caso.
</details>

## Exercício 3: Remoção de elementos

Implemente na classe `ListaEstatica` um método para remover um elemento por índice, deslocando os elementos restantes para preencher o espaço vazio.

<details>
  <summary>Ver solução</summary>
  
```csharp
public bool RemoverEm(int posicao)
{
    // Verifica se a posição é válida
    if (posicao < 0 || posicao >= tamanho)
        return false;
    
    // Desloca os elementos para preencher o espaço vazio
    for (int i = posicao; i < tamanho - 1; i++)
    {
        elementos[i] = elementos[i + 1];
    }
    
    // Reduz o tamanho da lista
    tamanho--;
    return true;
}
```

Este método remove um elemento de uma posição específica e reorganiza os elementos restantes para manter a lista contígua. A operação tem complexidade O(n) no pior caso.
</details>

## Exercício 4: Busca de elementos

Adicione métodos à classe `ListaEstatica` para buscar a primeira ocorrência de um elemento e verificar se um elemento existe na lista.

<details>
  <summary>Ver solução</summary>
  
```csharp
public int BuscarElemento(int elemento)
{
    // Busca sequencial pelo elemento
    for (int i = 0; i < tamanho; i++)
    {
        if (elementos[i] == elemento)
            return i;
    }
    
    // Retorna -1 se o elemento não for encontrado
    return -1;
}

public bool Contem(int elemento)
{
    return BuscarElemento(elemento) != -1;
}
```

O método `BuscarElemento` realiza uma busca sequencial na lista e retorna o índice da primeira ocorrência do elemento ou -1 se não encontrado. O método `Contem` simplifica a verificação de existência de um elemento na lista.
</details>

## Exercício 5: Ordenação da lista

Implemente um método para ordenar os elementos da lista utilizando o algoritmo de ordenação de sua preferência (por exemplo, Bubble Sort).

<details>
  <summary>Ver solução</summary>
  
```csharp
public void Ordenar()
{
    // Implementação do Bubble Sort
    for (int i = 0; i < tamanho - 1; i++)
    {
        for (int j = 0; j < tamanho - i - 1; j++)
        {
            if (elementos[j] > elementos[j + 1])
            {
                // Troca os elementos
                int temp = elementos[j];
                elementos[j] = elementos[j + 1];
                elementos[j + 1] = temp;
            }
        }
    }
}
```

Este método ordena os elementos da lista usando o algoritmo Bubble Sort, que compara elementos adjacentes e os troca se estiverem na ordem errada. Embora não seja o algoritmo mais eficiente, é simples de implementar e entender.
</details>

## Exercício 6: Redimensionamento da lista

Implemente uma função de redimensionamento que permita aumentar a capacidade da lista quando ela estiver cheia.

<details>
  <summary>Ver solução</summary>
  
```csharp
private bool Redimensionar(int novaCapacidade)
{
    // Verifica se a nova capacidade é válida
    if (novaCapacidade <= tamanho)
        return false;
    
    // Cria um novo array com a nova capacidade
    int[] novoArray = new int[novaCapacidade];
    
    // Copia os elementos do array antigo para o novo
    for (int i = 0; i < tamanho; i++)
    {
        novoArray[i] = elementos[i];
    }
    
    // Substitui o array antigo pelo novo
    elementos = novoArray;
    return true;
}

public bool InserirComRedimensionamento(int elemento)
{
    // Se a lista estiver cheia, redimensiona
    if (tamanho >= elementos.Length)
    {
        bool redimensionado = Redimensionar(elementos.Length * 2);
        if (!redimensionado)
            return false;
    }
    
    // Insere o elemento
    elementos[tamanho] = elemento;
    tamanho++;
    return true;
}
```

Este método permite aumentar dinamicamente a capacidade da lista quando necessário, criando um novo array maior e copiando os elementos. Isso torna a lista mais flexível, embora ainda tenha um limite máximo determinado pela memória disponível.
</details>

## Exercício 7: Implementação de uma lista genérica

Modifique a implementação para criar uma `ListaEstaticaGenerica<T>` que possa armazenar elementos de qualquer tipo.

<details>
  <summary>Ver solução</summary>
  
```csharp
public class ListaEstaticaGenerica<T>
{
    private T[] elementos;
    private int tamanho;
    
    public ListaEstaticaGenerica(int capacidade)
    {
        elementos = new T[capacidade];
        tamanho = 0;
    }
    
    public bool Inserir(T elemento)
    {
        if (tamanho >= elementos.Length)
            return false;
        
        elementos[tamanho] = elemento;
        tamanho++;
        return true;
    }
    
    public T ObterElemento(int indice)
    {
        if (indice < 0 || indice >= tamanho)
            throw new IndexOutOfRangeException("Índice inválido");
        
        return elementos[indice];
    }
    
    public bool InserirEm(T elemento, int posicao)
    {
        if (posicao < 0 || posicao > tamanho)
            return false;
            
        if (tamanho >= elementos.Length)
            return false;
        
        for (int i = tamanho; i > posicao; i--)
        {
            elementos[i] = elementos[i - 1];
        }
        
        elementos[posicao] = elemento;
        tamanho++;
        return true;
    }
    
    public int BuscarElemento(T elemento)
    {
        for (int i = 0; i < tamanho; i++)
        {
            if (EqualityComparer<T>.Default.Equals(elementos[i], elemento))
                return i;
        }
        
        return -1;
    }
    
    public int Tamanho()
    {
        return tamanho;
    }
}
```

Usando generics (tipos genéricos), podemos criar uma lista que funciona com qualquer tipo de dados. Note o uso de `EqualityComparer<T>.Default.Equals` para comparar elementos de forma segura, independentemente do tipo.
</details>

## Exercício 8: Combinação de listas

Implemente um método na classe `ListaEstatica` que combine o conteúdo de duas listas em uma nova lista.

<details>
  <summary>Ver solução</summary>
  
```csharp
public static ListaEstatica Combinar(ListaEstatica lista1, ListaEstatica lista2)
{
    // Cria uma nova lista com capacidade para armazenar todos os elementos
    ListaEstatica novaLista = new ListaEstatica(lista1.Tamanho() + lista2.Tamanho());
    
    // Adiciona os elementos da primeira lista
    for (int i = 0; i < lista1.Tamanho(); i++)
    {
        novaLista.Inserir(lista1.ObterElemento(i));
    }
    
    // Adiciona os elementos da segunda lista
    for (int i = 0; i < lista2.Tamanho(); i++)
    {
        novaLista.Inserir(lista2.ObterElemento(i));
    }
    
    return novaLista;
}
```

Este método cria uma nova lista que contém todos os elementos das duas listas fornecidas, preservando a ordem dos elementos. É um método estático que pode ser chamado como `ListaEstatica.Combinar(lista1, lista2)`.
</details>

## Exercício 9: Remoção de duplicatas

Implemente um método que remova elementos duplicados da lista, mantendo apenas a primeira ocorrência de cada valor.

<details>
  <summary>Ver solução</summary>
  
```csharp
public void RemoverDuplicatas()
{
    // Lista para armazenar temporariamente os elementos únicos
    ListaEstatica listaUnica = new ListaEstatica(tamanho);
    
    // Adiciona apenas elementos que ainda não estão na lista única
    for (int i = 0; i < tamanho; i++)
    {
        int elemento = elementos[i];
        if (!listaUnica.Contem(elemento))
        {
            listaUnica.Inserir(elemento);
        }
    }
    
    // Atualiza a lista original com os elementos únicos
    elementos = new int[elementos.Length];
    tamanho = listaUnica.Tamanho();
    
    for (int i = 0; i < tamanho; i++)
    {
        elementos[i] = listaUnica.ObterElemento(i);
    }
}
```

Este método remove elementos duplicados da lista, mantendo apenas a primeira ocorrência de cada valor. A implementação cria uma lista temporária para armazenar elementos únicos e depois atualiza a lista original.
</details>

## Exercício 10: Implementação de uma pilha utilizando lista estática

Implemente uma classe `PilhaEstatica` que utilize a `ListaEstatica` como estrutura de armazenamento e ofereça operações como push, pop e peek.

<details>
  <summary>Ver solução</summary>
  
```csharp
public class PilhaEstatica
{
    private ListaEstatica lista;
    
    public PilhaEstatica(int capacidade)
    {
        lista = new ListaEstatica(capacidade);
    }
    
    public bool Push(int elemento)
    {
        return lista.Inserir(elemento);
    }
    
    public int Pop()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A pilha está vazia");
        
        int ultimaPosicao = lista.Tamanho() - 1;
        int elemento = lista.ObterElemento(ultimaPosicao);
        lista.RemoverEm(ultimaPosicao);
        return elemento;
    }
    
    public int Peek()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A pilha está vazia");
        
        return lista.ObterElemento(lista.Tamanho() - 1);
    }
    
    public bool EstaVazia()
    {
        return lista.Tamanho() == 0;
    }
    
    public int Tamanho()
    {
        return lista.Tamanho();
    }
}
```

Esta implementação de pilha (estrutura LIFO - Last In, First Out) utiliza a `ListaEstatica` como estrutura de armazenamento subjacente. As operações `Push`, `Pop` e `Peek` seguem a semântica padrão de uma pilha.
</details>