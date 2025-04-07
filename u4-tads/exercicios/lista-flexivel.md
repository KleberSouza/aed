# Exercícios de Lista Encadeada Simples com Referência em C# 

Bem-vindo(a) a esta página de exercícios sobre Lista Encadeada Simples com Referência em C#! Para cada exercício, tente desenvolver sua solução antes de verificar a resposta.

## Exercício 1: Implementação básica de uma Lista Encadeada Simples

**Objetivo**: Implementar uma classe básica de Lista Encadeada Simples usando referências (ponteiros) em C#.

**Descrição**: Crie uma classe `ListaEncadeadaSimples` que armazene números inteiros usando nós encadeados. A classe deve usar referências para conectar os nós, com cada nó apontando para o próximo.

**Requisitos**:
- Crie uma classe interna `No` que contenha um valor inteiro e uma referência para o próximo nó
- Implemente os seguintes métodos:
  * `AdicionarNoFinal(int valor)`: adiciona um valor no final da lista
  * `RemoverDoInicio()`: remove e retorna o valor do início da lista
  * `ObterValorNaPosicao(int posicao)`: retorna o valor na posição especificada
  * `EstaVazia()`: verifica se a lista está vazia
  * `Tamanho()`: retorna a quantidade de elementos na lista

<details>
  <summary>Ver solução</summary>
  
```csharp
public class ListaEncadeadaSimples
{
    private class No
    {
        public int Valor { get; set; }
        public No Proximo { get; set; }
        
        public No(int valor)
        {
            Valor = valor;
            Proximo = null;
        }
    }
    
    private No cabeca;
    private No cauda;
    private int quantidade;
    
    public ListaEncadeadaSimples()
    {
        cabeca = null;
        cauda = null;
        quantidade = 0;
    }
    
    public void AdicionarNoFinal(int valor)
    {
        No novoNo = new No(valor);
        
        // Se a lista estiver vazia, o novo nó será tanto a cabeça quanto a cauda
        if (EstaVazia())
        {
            cabeca = novoNo;
            cauda = novoNo;
        }
        else
        {
            // Adiciona o novo nó no final da lista
            cauda.Proximo = novoNo;
            cauda = novoNo;
        }
        
        quantidade++;
    }
    
    public int RemoverDoInicio()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A lista está vazia");
        
        int valor = cabeca.Valor;
        
        // Move a cabeça para o próximo nó
        cabeca = cabeca.Proximo;
        
        // Se a lista ficar vazia, atualizamos também a cauda
        if (cabeca == null)
            cauda = null;
        
        quantidade--;
        return valor;
    }
    
    public int ObterValorNaPosicao(int posicao)
    {
        if (posicao < 0 || posicao >= quantidade)
            throw new ArgumentOutOfRangeException(nameof(posicao), "Posição inválida");
        
        No atual = cabeca;
        for (int i = 0; i < posicao; i++)
        {
            atual = atual.Proximo;
        }
        
        return atual.Valor;
    }
    
    public bool EstaVazia()
    {
        return cabeca == null;
    }
    
    public int Tamanho()
    {
        return quantidade;
    }
}
```

Esta implementação utiliza uma estrutura de nós encadeados para criar uma lista encadeada simples. Cada nó contém um valor inteiro e uma referência para o próximo nó. A classe mantém referências para a cabeça (primeiro nó) e a cauda (último nó) da lista, permitindo operações eficientes de adição no final e remoção do início. A variável `quantidade` permite obter o tamanho da lista em tempo constante.
</details>

## Exercício 2: Adicionar métodos para manipulação da Lista Encadeada Simples

**Objetivo**: Expandir a implementação básica da Lista Encadeada Simples com métodos adicionais para manipulação.

**Descrição**: Adicione os seguintes métodos à classe `ListaEncadeadaSimples`:

**Requisitos**:
- Implemente os seguintes métodos:
  * `AdicionarNoInicio(int valor)`: adiciona um valor no início da lista
  * `RemoverDoFinal()`: remove e retorna o valor do final da lista
  * `Contem(int valor)`: verifica se a lista contém o valor especificado
  * `ExibirElementos()`: exibe todos os elementos da lista

<details>
  <summary>Ver solução</summary>
  
```csharp
public void AdicionarNoInicio(int valor)
{
    No novoNo = new No(valor);
    
    // Se a lista estiver vazia, o novo nó será tanto a cabeça quanto a cauda
    if (EstaVazia())
    {
        cabeca = novoNo;
        cauda = novoNo;
    }
    else
    {
        // O novo nó aponta para a cabeça atual
        novoNo.Proximo = cabeca;
        
        // A cabeça passa a ser o novo nó
        cabeca = novoNo;
    }
    
    quantidade++;
}

public int RemoverDoFinal()
{
    if (EstaVazia())
        throw new InvalidOperationException("A lista está vazia");
    
    int valor = cauda.Valor;
    
    // Se só tiver um elemento, a lista ficará vazia
    if (cabeca == cauda)
    {
        cabeca = null;
        cauda = null;
    }
    else
    {
        // Precisamos encontrar o penúltimo nó
        No atual = cabeca;
        while (atual.Proximo != cauda)
        {
            atual = atual.Proximo;
        }
        
        // O penúltimo nó agora será a cauda
        atual.Proximo = null;
        cauda = atual;
    }
    
    quantidade--;
    return valor;
}

public bool Contem(int valor)
{
    No atual = cabeca;
    
    while (atual != null)
    {
        if (atual.Valor == valor)
            return true;
            
        atual = atual.Proximo;
    }
    
    return false;
}

public void ExibirElementos()
{
    if (EstaVazia())
    {
        Console.WriteLine("A lista está vazia.");
        return;
    }
    
    Console.Write("Elementos da lista: ");
    
    No atual = cabeca;
    while (atual != null)
    {
        Console.Write(atual.Valor);
        atual = atual.Proximo;
        
        if (atual != null)
            Console.Write(" -> ");
    }
    
    Console.WriteLine();
}
```

Esta solução amplia a funcionalidade da lista encadeada simples. O método `AdicionarNoInicio` permite adicionar um elemento no início da lista em tempo constante. O método `RemoverDoFinal` remove o último elemento, mas precisa percorrer a lista para encontrar o penúltimo nó, resultando em tempo linear. O método `Contem` verifica se um valor específico está presente na lista, e `ExibirElementos` mostra todos os elementos da lista, utilizando uma seta para indicar a direção das referências.
</details>

## Exercício 3: Implementar métodos para inserção e remoção em posições específicas

**Objetivo**: Adicionar métodos que permitam inserir e remover elementos em posições específicas da lista.

**Descrição**: Adicione os seguintes métodos à classe `ListaEncadeadaSimples`:

**Requisitos**:
- Implemente os seguintes métodos:
  * `InserirNaPosicao(int valor, int posicao)`: insere um valor na posição especificada
  * `RemoverDaPosicao(int posicao)`: remove e retorna o valor da posição especificada

<details>
  <summary>Ver solução</summary>
  
```csharp
public void InserirNaPosicao(int valor, int posicao)
{
    // Validação da posição
    if (posicao < 0 || posicao > quantidade)
        throw new ArgumentOutOfRangeException(nameof(posicao), "Posição inválida");
    
    // Casos especiais: inserção no início ou no final
    if (posicao == 0)
    {
        AdicionarNoInicio(valor);
        return;
    }
    
    if (posicao == quantidade)
    {
        AdicionarNoFinal(valor);
        return;
    }
    
    // Criação do novo nó
    No novoNo = new No(valor);
    
    // Encontra o nó anterior à posição desejada
    No anterior = cabeca;
    for (int i = 0; i < posicao - 1; i++)
    {
        anterior = anterior.Proximo;
    }
    
    // Insere o novo nó
    novoNo.Proximo = anterior.Proximo;
    anterior.Proximo = novoNo;
    
    quantidade++;
}

public int RemoverDaPosicao(int posicao)
{
    // Validação da posição
    if (posicao < 0 || posicao >= quantidade)
        throw new ArgumentOutOfRangeException(nameof(posicao), "Posição inválida");
    
    // Casos especiais: remoção do início ou do final
    if (posicao == 0)
    {
        return RemoverDoInicio();
    }
    
    if (posicao == quantidade - 1)
    {
        return RemoverDoFinal();
    }
    
    // Encontra o nó anterior ao que será removido
    No anterior = cabeca;
    for (int i = 0; i < posicao - 1; i++)
    {
        anterior = anterior.Proximo;
    }
    
    // O nó a ser removido é o próximo do anterior
    No remover = anterior.Proximo;
    int valor = remover.Valor;
    
    // Remove o nó ajustando a referência
    anterior.Proximo = remover.Proximo;
    
    quantidade--;
    return valor;
}
```

Esta solução implementa métodos para inserir e remover elementos em posições específicas da lista encadeada. Para inserir um elemento, primeiro localizamos o nó anterior à posição desejada, depois ajustamos as referências para incluir o novo nó. Para remover, seguimos um processo similar: localizamos o nó anterior, depois ajustamos sua referência para "pular" o nó a ser removido. Ambos os métodos tratam casos especiais (início e fim da lista) chamando os métodos específicos já implementados.
</details>

## Exercício 4: Implementar um método para inverter a Lista Encadeada Simples

**Objetivo**: Adicionar um método que inverta a ordem dos elementos na lista.

**Descrição**: Implemente um método `Inverter()` na classe `ListaEncadeadaSimples` que inverta a ordem dos elementos da lista.

**Requisitos**:
- A lista deve manter sua estrutura (cabeça e cauda) após a inversão
- O método deve funcionar corretamente para listas vazias ou com apenas um elemento
- A inversão deve ser feita in-place, sem criar uma nova lista

<details>
  <summary>Ver solução</summary>
  
```csharp
public void Inverter()
{
    if (EstaVazia() || quantidade == 1)
        return; // Não há o que inverter
    
    No anterior = null;
    No atual = cabeca;
    No proximo = null;
    
    // A cauda será a cabeça atual
    cauda = cabeca;
    
    // Percorre a lista invertendo as referências
    while (atual != null)
    {
        // Salva o próximo nó
        proximo = atual.Proximo;
        
        // Inverte a referência para o próximo nó
        atual.Proximo = anterior;
        
        // Avança para o próximo nó
        anterior = atual;
        atual = proximo;
    }
    
    // A cabeça será o último nó visitado (anterior)
    cabeca = anterior;
}
```

Esta solução inverte a lista encadeada simples in-place, ou seja, sem criar uma nova lista. A ideia principal é percorrer a lista e, para cada nó, inverter sua referência para que aponte para o nó anterior em vez do próximo. Precisamos manter três referências durante o processo: para o nó atual, o próximo e o anterior. Também atualizamos as referências da cabeça e da cauda da lista. Antes da inversão, a cabeça aponta para o primeiro elemento e a cauda para o último; após a inversão, esses papéis são trocados.
</details>


## Exercício 5: Implementar um método para ordenar a Lista Encadeada Simples

**Objetivo**: Adicionar um método que ordene os elementos da lista em ordem crescente.

**Descrição**: Implemente um método `Ordenar()` na classe `ListaEncadeadaSimples` que ordene os elementos da lista em ordem crescente.

**Requisitos**:
- A ordenação deve ser feita in-place, sem criar uma nova lista
- Após a ordenação, o menor elemento deve estar no início da lista
- O método deve funcionar corretamente para listas vazias ou com apenas um elemento

<details>
  <summary>Ver solução</summary>
  
```csharp
public void Ordenar()
{
    if (EstaVazia() || quantidade == 1)
        return; // Não há o que ordenar
    
    // Implementação do algoritmo de ordenação BubbleSort para lista encadeada
    bool trocaRealizada;
    
    for (int i = 0; i < quantidade - 1; i++)
    {
        trocaRealizada = false;
        No atual = cabeca;
        No proximo = cabeca.Proximo;
        
        for (int j = 0; j < quantidade - i - 1; j++)
        {
            // Se o valor atual for maior que o próximo, troca os valores
            if (atual.Valor > proximo.Valor)
            {
                int temp = atual.Valor;
                atual.Valor = proximo.Valor;
                proximo.Valor = temp;
                
                trocaRealizada = true;
            }
            
            atual = atual.Proximo;
            proximo = proximo.Proximo;
        }
        
        // Se não houve troca nesta passagem, a lista já está ordenada
        if (!trocaRealizada)
            break;
    }
}
```

Esta solução implementa o algoritmo de ordenação Bubble Sort para uma lista encadeada. Em vez de reordenar os nós (o que seria mais complexo), trocamos os valores entre os nós. O algoritmo faz várias passagens pela lista, comparando pares de elementos adjacentes e trocando-os se estiverem na ordem errada. Se em alguma passagem completa não houver nenhuma troca, significa que a lista já está ordenada e podemos parar. Este algoritmo é simples de implementar, mas não é o mais eficiente para listas grandes (complexidade de tempo O(n²)).
</details>

## Exercício 6: Implementar um método para remover elementos duplicados da Lista Encadeada Simples

**Objetivo**: Adicionar um método que remova todos os elementos duplicados da lista, mantendo apenas a primeira ocorrência de cada valor.

**Descrição**: Implemente um método `RemoverDuplicados()` na classe `ListaEncadeadaSimples` que percorra a lista e remova todos os valores duplicados, mantendo apenas a primeira ocorrência de cada valor.

**Requisitos**:
- Após a execução, a lista deve conter apenas valores únicos
- A ordem relativa dos elementos deve ser preservada
- O método deve funcionar corretamente para listas vazias ou com apenas um elemento

<details>
  <summary>Ver solução</summary>
  
```csharp
public void RemoverDuplicados()
{
    if (EstaVazia() || quantidade == 1)
        return; // Não há duplicados para remover
    
    // Utilizamos um HashSet para rastrear valores já vistos
    HashSet<int> valoresVistos = new HashSet<int>();
    
    No atual = cabeca;
    No anterior = null;
    
    while (atual != null)
    {
        // Verifica se o valor já foi visto
        if (valoresVistos.Contains(atual.Valor))
        {
            // Remove o nó atual
            anterior.Proximo = atual.Proximo;
            
            // Se o nó removido era a cauda, atualiza a cauda
            if (atual == cauda)
                cauda = anterior;
                
            quantidade--;
        }
        else
        {
            // Valor novo, adiciona ao conjunto de valores vistos
            valoresVistos.Add(atual.Valor);
            anterior = atual;
        }
        
        atual = anterior.Proximo;
    }
}
```

Esta solução utiliza um HashSet para rastrear os valores já vistos na lista. Enquanto percorremos a lista, se encontrarmos um valor que já está no HashSet, removemos o nó atual ajustando a referência do nó anterior. Se o valor ainda não foi visto, o adicionamos ao HashSet e continuamos. Essa abordagem tem complexidade de tempo O(n) e complexidade de espaço O(n), onde n é o número de elementos na lista. É mais eficiente que uma abordagem de força bruta (que teria complexidade O(n²)) em termos de tempo, mas usa memória adicional para o HashSet.
</details>


## Exercício 7: Implementação básica de uma Lista Encadeada Dupla

**Objetivo**: Implementar uma classe básica de Lista Encadeada Dupla usando referências (ponteiros) em C#.

**Descrição**: Crie uma classe `ListaEncadeadaDupla` que armazene números inteiros usando nós encadeados. A classe deve usar referências para conectar os nós, com cada nó apontando para o próximo e para o anterior.

**Requisitos**:
- Crie uma classe interna `No` que contenha um valor inteiro, uma referência para o próximo nó e uma referência para o nó anterior
- Implemente os seguintes métodos:
  * `AdicionarNoFinal(int valor)`: adiciona um valor no final da lista
  * `AdicionarNoInicio(int valor)`: adiciona um valor no início da lista
  * `RemoverDoInicio()`: remove e retorna o valor do início da lista
  * `RemoverDoFinal()`: remove e retorna o valor do final da lista
  * `EstaVazia()`: verifica se a lista está vazia
  * `Tamanho()`: retorna a quantidade de elementos na lista

<details>
  <summary>Ver solução</summary>
  
```csharp
public class ListaEncadeadaDupla
{
    private class No
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
    
    private No cabeca;
    private No cauda;
    private int quantidade;
    
    public ListaEncadeadaDupla()
    {
        cabeca = null;
        cauda = null;
        quantidade = 0;
    }
    
    public void AdicionarNoFinal(int valor)
    {
        No novoNo = new No(valor);
        
        // Se a lista estiver vazia, o novo nó será tanto a cabeça quanto a cauda
        if (EstaVazia())
        {
            cabeca = novoNo;
            cauda = novoNo;
        }
        else
        {
            // Adiciona o novo nó no final da lista
            cauda.Proximo = novoNo;
            novoNo.Anterior = cauda;
            cauda = novoNo;
        }
        
        quantidade++;
    }
    
    public void AdicionarNoInicio(int valor)
    {
        No novoNo = new No(valor);
        
        // Se a lista estiver vazia, o novo nó será tanto a cabeça quanto a cauda
        if (EstaVazia())
        {
            cabeca = novoNo;
            cauda = novoNo;
        }
        else
        {
            // Adiciona o novo nó no início da lista
            novoNo.Proximo = cabeca;
            cabeca.Anterior = novoNo;
            cabeca = novoNo;
        }
        
        quantidade++;
    }
    
    public int RemoverDoInicio()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A lista está vazia");
        
        int valor = cabeca.Valor;
        
        // Se só tiver um elemento, a lista ficará vazia
        if (cabeca == cauda)
        {
            cabeca = null;
            cauda = null;
        }
        else
        {
            cabeca = cabeca.Proximo;
            cabeca.Anterior = null;
        }
        
        quantidade--;
        return valor;
    }
    
    public int RemoverDoFinal()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A lista está vazia");
        
        int valor = cauda.Valor;
        
        // Se só tiver um elemento, a lista ficará vazia
        if (cabeca == cauda)
        {
            cabeca = null;
            cauda = null;
        }
        else
        {
            cauda = cauda.Anterior;
            cauda.Proximo = null;
        }
        
        quantidade--;
        return valor;
    }
    
    public bool EstaVazia()
    {
        return cabeca == null;
    }
    
    public int Tamanho()
    {
        return quantidade;
    }
}
```

Esta implementação utiliza uma estrutura de nós duplamente encadeados para criar uma lista encadeada dupla. Cada nó contém um valor inteiro, uma referência para o próximo nó e uma referência para o nó anterior. A classe mantém referências para a cabeça (primeiro nó) e a cauda (último nó) da lista, permitindo operações eficientes de adição e remoção tanto no início quanto no final da lista em tempo constante O(1).
</details>

## Exercício 8: Adicionar métodos para acesso e manipulação da Lista Encadeada Dupla

**Objetivo**: Expandir a implementação básica da Lista Encadeada Dupla com métodos adicionais para acesso e manipulação.

**Descrição**: Adicione os seguintes métodos à classe `ListaEncadeadaDupla`:

**Requisitos**:
- Implemente os seguintes métodos:
  * `ObterValorNaPosicao(int posicao)`: retorna o valor na posição especificada
  * `Contem(int valor)`: verifica se a lista contém o valor especificado
  * `ExibirElementos()`: exibe todos os elementos da lista do início para o fim
  * `ExibirElementosReverso()`: exibe todos os elementos da lista do fim para o início

<details>
  <summary>Ver solução</summary>
  
```csharp
public int ObterValorNaPosicao(int posicao)
{
    if (posicao < 0 || posicao >= quantidade)
        throw new ArgumentOutOfRangeException(nameof(posicao), "Posição inválida");
    
    // Decidimos se começamos da cabeça ou da cauda para otimizar a busca
    if (posicao < quantidade / 2)
    {
        // Se a posição estiver na primeira metade, começamos da cabeça
        No atual = cabeca;
        for (int i = 0; i < posicao; i++)
        {
            atual = atual.Proximo;
        }
        return atual.Valor;
    }
    else
    {
        // Se a posição estiver na segunda metade, começamos da cauda
        No atual = cauda;
        for (int i = quantidade - 1; i > posicao; i--)
        {
            atual = atual.Anterior;
        }
        return atual.Valor;
    }
}

public bool Contem(int valor)
{
    No atual = cabeca;
    
    while (atual != null)
    {
        if (atual.Valor == valor)
            return true;
            
        atual = atual.Proximo;
    }
    
    return false;
}

public void ExibirElementos()
{
    if (EstaVazia())
    {
        Console.WriteLine("A lista está vazia.");
        return;
    }
    
    Console.Write("Elementos da lista (início -> fim): ");
    
    No atual = cabeca;
    while (atual != null)
    {
        Console.Write(atual.Valor);
        atual = atual.Proximo;
        
        if (atual != null)
            Console.Write(" <-> ");
    }
    
    Console.WriteLine();
}

public void ExibirElementosReverso()
{
    if (EstaVazia())
    {
        Console.WriteLine("A lista está vazia.");
        return;
    }
    
    Console.Write("Elementos da lista (fim -> início): ");
    
    No atual = cauda;
    while (atual != null)
    {
        Console.Write(atual.Valor);
        atual = atual.Anterior;
        
        if (atual != null)
            Console.Write(" <-> ");
    }
    
    Console.WriteLine();
}
```

Esta solução implementa métodos adicionais para a lista encadeada dupla. O método `ObterValorNaPosicao` é otimizado para começar a busca da cabeça ou da cauda, dependendo de qual está mais próxima da posição desejada, reduzindo pela metade o tempo de busca no pior caso. O método `Contem` verifica se um valor específico existe na lista. Os métodos `ExibirElementos` e `ExibirElementosReverso` mostram os elementos da lista do início para o fim e do fim para o início, respectivamente, destacando a natureza bidirecional da lista encadeada dupla com o símbolo "<->".
</details>


## Exercício 9: Implementar métodos para inserção e remoção em posições específicas

**Objetivo**: Adicionar métodos que permitam inserir e remover elementos em posições específicas da lista encadeada dupla.

**Descrição**: Adicione os seguintes métodos à classe `ListaEncadeadaDupla`:

**Requisitos**:
- Implemente os seguintes métodos:
  * `InserirNaPosicao(int valor, int posicao)`: insere um valor na posição especificada
  * `RemoverDaPosicao(int posicao)`: remove e retorna o valor da posição especificada

<details>
  <summary>Ver solução</summary>
  
```csharp
public void InserirNaPosicao(int valor, int posicao)
{
    // Validação da posição
    if (posicao < 0 || posicao > quantidade)
        throw new ArgumentOutOfRangeException(nameof(posicao), "Posição inválida");
    
    // Casos especiais: inserção no início ou no final
    if (posicao == 0)
    {
        AdicionarNoInicio(valor);
        return;
    }
    
    if (posicao == quantidade)
    {
        AdicionarNoFinal(valor);
        return;
    }
    
    // Criação do novo nó
    No novoNo = new No(valor);
    
    // Decidimos se começamos a busca pela cabeça ou pela cauda para otimizar
    No atual;
    
    if (posicao < quantidade / 2)
    {
        // Se a posição estiver na primeira metade, começamos da cabeça
        atual = cabeca;
        for (int i = 0; i < posicao; i++)
        {
            atual = atual.Proximo;
        }
    }
    else
    {
        // Se a posição estiver na segunda metade, começamos da cauda
        atual = cauda;
        for (int i = quantidade - 1; i > posicao; i--)
        {
            atual = atual.Anterior;
        }
    }
    
    // O nó anterior ao atual será o nó anterior ao novo nó
    No anterior = atual.Anterior;
    
    // Ajustamos as referências para inserir o novo nó
    novoNo.Anterior = anterior;
    novoNo.Proximo = atual;
    anterior.Proximo = novoNo;
    atual.Anterior = novoNo;
    
    quantidade++;
}

public int RemoverDaPosicao(int posicao)
{
    // Validação da posição
    if (posicao < 0 || posicao >= quantidade)
        throw new ArgumentOutOfRangeException(nameof(posicao), "Posição inválida");
    
    // Casos especiais: remoção do início ou do final
    if (posicao == 0)
    {
        return RemoverDoInicio();
    }
    
    if (posicao == quantidade - 1)
    {
        return RemoverDoFinal();
    }
    
    // Encontramos o nó a ser removido
    No atual;
    
    if (posicao < quantidade / 2)
    {
        // Se a posição estiver na primeira metade, começamos da cabeça
        atual = cabeca;
        for (int i = 0; i < posicao; i++)
        {
            atual = atual.Proximo;
        }
    }
    else
    {
        // Se a posição estiver na segunda metade, começamos da cauda
        atual = cauda;
        for (int i = quantidade - 1; i > posicao; i--)
        {
            atual = atual.Anterior;
        }
    }
    
    // Obtém o valor a ser retornado
    int valor = atual.Valor;
    
    // Ajusta as referências para remover o nó
    atual.Anterior.Proximo = atual.Proximo;
    atual.Proximo.Anterior = atual.Anterior;
    
    quantidade--;
    return valor;
}
```

Esta solução implementa métodos para inserir e remover elementos em posições específicas da lista encadeada dupla. Ambos os métodos são otimizados para começar a busca pela cabeça ou pela cauda, dependendo de qual está mais próxima da posição desejada, reduzindo pela metade o tempo de busca no pior caso. Os casos especiais (inserção/remoção no início ou no final) são tratados utilizando os métodos já implementados. Para posições intermediárias, ajustamos as referências dos nós anterior e próximo para incluir ou remover o nó desejado.
</details>

## Exercício 10: Implementar um método para inverter a Lista Encadeada Dupla

**Objetivo**: Adicionar um método que inverta a ordem dos elementos na lista.

**Descrição**: Implemente um método `Inverter()` na classe `ListaEncadeadaDupla` que inverta a ordem dos elementos da lista.

**Requisitos**:
- A lista deve manter sua estrutura (cabeça e cauda) após a inversão
- O método deve funcionar corretamente para listas vazias ou com apenas um elemento
- A inversão deve ser feita in-place, sem criar uma nova lista

<details>
  <summary>Ver solução</summary>
  
```csharp
public void Inverter()
{
    if (EstaVazia() || quantidade == 1)
        return; // Não há o que inverter
    
    No atual = cabeca;
    No temp = null;
    
    // Percorre a lista trocando as referências próximo e anterior de cada nó
    while (atual != null)
    {
        // Salva o próximo nó
        temp = atual.Proximo;
        
        // Inverte as referências do nó atual
        atual.Proximo = atual.Anterior;
        atual.Anterior = temp;
        
        // Avança para o próximo nó (que agora é o anterior)
        atual = temp;
    }
    
    // Troca a cabeça e a cauda da lista
    temp = cabeca;
    cabeca = cauda;
    cauda = temp;
}
```

Esta solução inverte a lista encadeada dupla in-place, ou seja, sem criar uma nova lista. A ideia principal é percorrer a lista e, para cada nó, trocar suas referências próximo e anterior. Após percorrer todos os nós, trocamos a cabeça e a cauda da lista. Esta abordagem é mais simples e eficiente em uma lista encadeada dupla em comparação com uma lista encadeada simples, pois cada nó já tem referências tanto para o próximo quanto para o anterior.
</details>


## Exercício 11: Implementar um método para ordenar a Lista Encadeada Dupla

**Objetivo**: Adicionar um método que ordene os elementos da lista em ordem crescente.

**Descrição**: Implemente um método `Ordenar()` na classe `ListaEncadeadaDupla` que ordene os elementos da lista em ordem crescente.

**Requisitos**:
- A ordenação deve ser feita in-place, sem criar uma nova lista
- Após a ordenação, o menor elemento deve estar no início da lista
- O método deve funcionar corretamente para listas vazias ou com apenas um elemento

<details>
  <summary>Ver solução</summary>
  
```csharp
public void Ordenar()
{
    if (EstaVazia() || quantidade == 1)
        return; // Não há o que ordenar
    
    // Implementação do algoritmo de ordenação BubbleSort para lista encadeada dupla
    bool trocaRealizada = true;
    
    while (trocaRealizada)
    {
        trocaRealizada = false;
        No atual = cabeca;
        
        while (atual != null && atual.Proximo != null)
        {
            // Se o valor atual for maior que o próximo, troca os valores
            if (atual.Valor > atual.Proximo.Valor)
            {
                int temp = atual.Valor;
                atual.Valor = atual.Proximo.Valor;
                atual.Proximo.Valor = temp;
                
                trocaRealizada = true;
            }
            
            atual = atual.Proximo;
        }
        
        // Se não houve troca nesta passagem, a lista já está ordenada
        if (!trocaRealizada)
            break;
    }
}
```

Esta solução implementa o algoritmo de ordenação Bubble Sort para uma lista encadeada dupla. Em vez de reordenar os nós (o que seria mais complexo), trocamos os valores entre os nós. O algoritmo faz várias passagens pela lista, comparando pares de elementos adjacentes e trocando-os se estiverem na ordem errada. Se em alguma passagem completa não houver nenhuma troca, significa que a lista já está ordenada e podemos parar. Este algoritmo é simples de implementar, mas não é o mais eficiente para listas grandes (complexidade de tempo O(n²)).
</details>

## Exercício 12: Implementar uma Lista Encadeada Dupla Genérica

**Objetivo**: Modificar a implementação da Lista Encadeada Dupla para utilizar tipos genéricos.

**Descrição**: Crie uma classe `ListaEncadeadaDuplaGenerica<T>` que possa armazenar elementos de qualquer tipo, mantendo a mesma funcionalidade da lista encadeada dupla básica.

**Requisitos**:
- A classe deve usar generics para permitir armazenar elementos de qualquer tipo
- Implemente os mesmos métodos da lista encadeada dupla básica
- Adicione tratamento adequado para valores nulos e comparações entre tipos genéricos

<details>
  <summary>Ver solução</summary>
  
```csharp
public class ListaEncadeadaDuplaGenerica<T>
{
    private class No
    {
        public T Valor { get; set; }
        public No Proximo { get; set; }
        public No Anterior { get; set; }
        
        public No(T valor)
        {
            Valor = valor;
            Proximo = null;
            Anterior = null;
        }
    }
    
    private No cabeca;
    private No cauda;
    private int quantidade;
    
    public ListaEncadeadaDuplaGenerica()
    {
        cabeca = null;
        cauda = null;
        quantidade = 0;
    }
    
    public void AdicionarNoFinal(T valor)
    {
        No novoNo = new No(valor);
        
        if (EstaVazia())
        {
            cabeca = novoNo;
            cauda = novoNo;
        }
        else
        {
            cauda.Proximo = novoNo;
            novoNo.Anterior = cauda;
            cauda = novoNo;
        }
        
        quantidade++;
    }
    
    public void AdicionarNoInicio(T valor)
    {
        No novoNo = new No(valor);
        
        if (EstaVazia())
        {
            cabeca = novoNo;
            cauda = novoNo;
        }
        else
        {
            novoNo.Proximo = cabeca;
            cabeca.Anterior = novoNo;
            cabeca = novoNo;
        }
        
        quantidade++;
    }
    
    public T RemoverDoInicio()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A lista está vazia");
        
        T valor = cabeca.Valor;
        
        if (cabeca == cauda)
        {
            cabeca = null;
            cauda = null;
        }
        else
        {
            cabeca = cabeca.Proximo;
            cabeca.Anterior = null;
        }
        
        quantidade--;
        return valor;
    }
    
    public T RemoverDoFinal()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A lista está vazia");
        
        T valor = cauda.Valor;
        
        if (cabeca == cauda)
        {
            cabeca = null;
            cauda = null;
        }
        else
        {
            cauda = cauda.Anterior;
            cauda.Proximo = null;
        }
        
        quantidade--;
        return valor;
    }
    
    public bool EstaVazia()
    {
        return cabeca == null;
    }
    
    public int Tamanho()
    {
        return quantidade;
    }
    
    public T ObterValorNaPosicao(int posicao)
    {
        if (posicao < 0 || posicao >= quantidade)
            throw new ArgumentOutOfRangeException(nameof(posicao), "Posição inválida");
        
        if (posicao < quantidade / 2)
        {
            No atual = cabeca;
            for (int i = 0; i < posicao; i++)
            {
                atual = atual.Proximo;
            }
            return atual.Valor;
        }
        else
        {
            No atual = cauda;
            for (int i = quantidade - 1; i > posicao; i--)
            {
                atual = atual.Anterior;
            }
            return atual.Valor;
        }
    }
    
    public bool Contem(T valor)
    {
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;
        No atual = cabeca;
        
        while (atual != null)
        {
            if (comparer.Equals(atual.Valor, valor))
                return true;
                
            atual = atual.Proximo;
        }
        
        return false;
    }
    
    public void ExibirElementos()
    {
        if (EstaVazia())
        {
            Console.WriteLine("A lista está vazia.");
            return;
        }
        
        Console.Write("Elementos da lista (início -> fim): ");
        
        No atual = cabeca;
        while (atual != null)
        {
            Console.Write(atual.Valor);
            atual = atual.Proximo;
            
            if (atual != null)
                Console.Write(" <-> ");
        }
        
        Console.WriteLine();
    }
    
    public void ExibirElementosReverso()
    {
        if (EstaVazia())
        {
            Console.WriteLine("A lista está vazia.");
            return;
        }
        
        Console.Write("Elementos da lista (fim -> início): ");
        
        No atual = cauda;
        while (atual != null)
        {
            Console.Write(atual.Valor);
            atual = atual.Anterior;
            
            if (atual != null)
                Console.Write(" <-> ");
        }
        
        Console.WriteLine();
    }
}
```

Esta implementação genérica permite que a lista encadeada dupla armazene elementos de qualquer tipo. A principal diferença para a versão com inteiros é o uso do tipo genérico `T` para os valores e a utilização de `EqualityComparer<T>.Default` para comparações seguras entre tipos genéricos, incluindo possíveis valores nulos. Todos os métodos da versão básica são adaptados para trabalhar com tipos genéricos, mantendo a mesma funcionalidade e eficiência.
</details>


## Exercício 13: Implementar uma Lista Circular Duplamente Encadeada

**Objetivo**: Modificar a implementação da Lista Encadeada Dupla para criar uma lista circular, onde o último nó aponta de volta para o primeiro e o primeiro aponta para o último.

**Descrição**: Crie uma classe `ListaCircularDupla` baseada na Lista Encadeada Dupla, mas com as modificações necessárias para torná-la circular.

**Requisitos**:
- O último nó da lista deve apontar para o primeiro, e o primeiro deve apontar para o último
- Implemente os mesmos métodos básicos da lista encadeada dupla
- Adapte os métodos existentes para lidar com a natureza circular da lista

<details>
  <summary>Ver solução</summary>
  
```csharp
public class ListaCircularDupla
{
    private class No
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
    
    private No cabeca;
    private int quantidade;
    
    public ListaCircularDupla()
    {
        cabeca = null;
        quantidade = 0;
    }
    
    public void AdicionarNoFinal(int valor)
    {
        No novoNo = new No(valor);
        
        // Se a lista estiver vazia, o novo nó aponta para si mesmo
        if (EstaVazia())
        {
            cabeca = novoNo;
            novoNo.Proximo = novoNo;
            novoNo.Anterior = novoNo;
        }
        else
        {
            // O novo nó será inserido entre a cabeça e seu anterior (último nó)
            No ultimo = cabeca.Anterior;
            
            novoNo.Proximo = cabeca;
            novoNo.Anterior = ultimo;
            
            ultimo.Proximo = novoNo;
            cabeca.Anterior = novoNo;
        }
        
        quantidade++;
    }
    
    public void AdicionarNoInicio(int valor)
    {
        // Adicionamos no final e depois ajustamos a cabeça
        AdicionarNoFinal(valor);
        cabeca = cabeca.Anterior;
    }
    
    public int RemoverDoInicio()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A lista está vazia");
        
        int valor = cabeca.Valor;
        
        // Se só tiver um elemento, a lista ficará vazia
        if (quantidade == 1)
        {
            cabeca = null;
        }
        else
        {
            No segundo = cabeca.Proximo;
            No ultimo = cabeca.Anterior;
            
            segundo.Anterior = ultimo;
            ultimo.Proximo = segundo;
            
            cabeca = segundo;
        }
        
        quantidade--;
        return valor;
    }
    
    public int RemoverDoFinal()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A lista está vazia");
        
        No ultimo = cabeca.Anterior;
        int valor = ultimo.Valor;
        
        // Se só tiver um elemento, a lista ficará vazia
        if (quantidade == 1)
        {
            cabeca = null;
        }
        else
        {
            No penultimo = ultimo.Anterior;
            
            penultimo.Proximo = cabeca;
            cabeca.Anterior = penultimo;
        }
        
        quantidade--;
        return valor;
    }
    
    public bool EstaVazia()
    {
        return cabeca == null;
    }
    
    public int Tamanho()
    {
        return quantidade;
    }
    
    public int ObterValorNaPosicao(int posicao)
    {
        if (posicao < 0 || posicao >= quantidade)
            throw new ArgumentOutOfRangeException(nameof(posicao), "Posição inválida");
        
        No atual = cabeca;
        for (int i = 0; i < posicao; i++)
        {
            atual = atual.Proximo;
        }
        
        return atual.Valor;
    }
    
    public void ExibirElementos()
    {
        if (EstaVazia())
        {
            Console.WriteLine("A lista está vazia.");
            return;
        }
        
        Console.Write("Elementos da lista circular: ");
        
        No atual = cabeca;
        int contador = 0;
        
        // Percorre a lista uma vez (até voltarmos à cabeça ou atingirmos o limite)
        do
        {
            Console.Write(atual.Valor);
            atual = atual.Proximo;
            contador++;
            
            if (contador < quantidade)
                Console.Write(" <-> ");
        } while (atual != cabeca && contador < quantidade);
        
        Console.WriteLine(" (circular)");
    }
}
```

Esta implementação cria uma lista circular duplamente encadeada, onde o último nó aponta de volta para o primeiro e o primeiro aponta para o último. A principal diferença em relação à lista encadeada dupla convencional é como lidamos com as referências ao adicionar e remover elementos. Para uma lista circular, não precisamos manter uma referência explícita para a cauda, pois podemos acessá-la através de `cabeca.Anterior`. Os métodos são adaptados para lidar com a natureza circular da lista, especialmente o método `ExibirElementos()`, que precisa ser cuidadoso para não entrar em um loop infinito ao percorrer a lista.
</details>

## Exercício 14: Implementar um método para mesclar duas Listas Encadeadas Duplas

**Objetivo**: Adicionar um método que mescle duas listas encadeadas duplas ordenadas em uma única lista ordenada.

**Descrição**: Implemente um método estático `Mesclar` na classe `ListaEncadeadaDupla` que receba duas listas encadeadas duplas ordenadas e retorne uma nova lista contendo todos os elementos das duas listas, mantendo a ordenação.

**Requisitos**:
- O método deve ter a assinatura: `public static ListaEncadeadaDupla Mesclar(ListaEncadeadaDupla lista1, ListaEncadeadaDupla lista2)`
- As listas originais não devem ser modificadas
- A nova lista deve conter todos os elementos das duas listas, ordenados
- O método deve funcionar corretamente mesmo se uma ou ambas as listas estiverem vazias

<details>
  <summary>Ver solução</summary>
  
```csharp
public static ListaEncadeadaDupla Mesclar(ListaEncadeadaDupla lista1, ListaEncadeadaDupla lista2)
{
    // Criamos uma nova lista para armazenar o resultado
    ListaEncadeadaDupla resultado = new ListaEncadeadaDupla();
    
    // Criamos cópias das listas originais para não modificá-las
    ListaEncadeadaDupla copia1 = ClonarLista(lista1);
    ListaEncadeadaDupla copia2 = ClonarLista(lista2);
    
    // Enquanto ambas as listas tiverem elementos
    while (!copia1.EstaVazia() && !copia2.EstaVazia())
    {
        // Comparamos os elementos do início de cada lista
        int valor1 = copia1.ObterValorNaPosicao(0);
        int valor2 = copia2.ObterValorNaPosicao(0);
        
        // Adicionamos o menor à lista de resultado
        if (valor1 <= valor2)
        {
            resultado.AdicionarNoFinal(copia1.RemoverDoInicio());
        }
        else
        {
            resultado.AdicionarNoFinal(copia2.RemoverDoInicio());
        }
    }
    
    // Adicionamos os elementos restantes da primeira lista
    while (!copia1.EstaVazia())
    {
        resultado.AdicionarNoFinal(copia1.RemoverDoInicio());
    }
    
    // Adicionamos os elementos restantes da segunda lista
    while (!copia2.EstaVazia())
    {
        resultado.AdicionarNoFinal(copia2.RemoverDoInicio());
    }
    
    return resultado;
}

// Método auxiliar para clonar uma lista
private static ListaEncadeadaDupla ClonarLista(ListaEncadeadaDupla original)
{
    ListaEncadeadaDupla copia = new ListaEncadeadaDupla();
    
    for (int i = 0; i < original.Tamanho(); i++)
    {
        copia.AdicionarNoFinal(original.ObterValorNaPosicao(i));
    }
    
    return copia;
}
```

Esta solução implementa o algoritmo de mesclagem (merge) de duas listas ordenadas. Primeiro, criamos cópias das listas originais para não modificá-las. Em seguida, comparamos os elementos do início de cada lista e adicionamos o menor deles à lista de resultado. Continuamos esse processo até que uma das listas fique vazia. Depois, adicionamos os elementos restantes da outra lista. O resultado é uma nova lista contendo todos os elementos das duas listas, mantendo a ordenação. Este algoritmo tem complexidade de tempo O(n+m), onde n e m são os tamanhos das duas listas.
</details>