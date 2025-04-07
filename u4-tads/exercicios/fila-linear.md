# Exercícios de Fila Estática Circular com Vetores em C# 

Bem-vindo(a) a esta página de exercícios sobre Fila Estática Circular com Vetores em C#! Para cada exercício, tente desenvolver sua solução antes de verificar a resposta.

## Exercício 1: Implementação básica de uma Fila Estática Circular

**Objetivo**: Implementar uma classe básica de Fila Estática Circular usando vetores em C#.

**Descrição**: Crie uma classe `FilaCircular` que armazene números inteiros usando um vetor. A classe deve implementar o comportamento FIFO (First In, First Out) e utilizar a abordagem circular para aproveitar todo o espaço do vetor.

**Implemente os seguintes métodos**:
- `Enfileirar(int elemento)`: adiciona um elemento no final da fila
- `Desenfileirar()`: remove e retorna o elemento do início da fila
- `VerInicio()`: retorna o elemento do início sem removê-lo
- `EstaVazia()`: verifica se a fila está vazia
- `EstaCheia()`: verifica se a fila está cheia
- `Tamanho()`: retorna a quantidade de elementos na fila

<details>
  <summary>Ver solução</summary>
  
```csharp
public class FilaCircular
{
    private int[] elementos;
    private int inicio;
    private int fim;
    private int quantidade;
    
    public FilaCircular(int capacidade)
    {
        elementos = new int[capacidade];
        inicio = 0;
        fim = -1;
        quantidade = 0;
    }
    
    public bool Enfileirar(int elemento)
    {
        if (EstaCheia())
            return false;
        
        fim = (fim + 1) % elementos.Length;
        elementos[fim] = elemento;
        quantidade++;
        return true;
    }
    
    public int Desenfileirar()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A fila está vazia");
        
        int elemento = elementos[inicio];
        inicio = (inicio + 1) % elementos.Length;
        quantidade--;
        return elemento;
    }
    
    public int VerInicio()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A fila está vazia");
        
        return elementos[inicio];
    }
    
    public bool EstaVazia()
    {
        return quantidade == 0;
    }
    
    public bool EstaCheia()
    {
        return quantidade == elementos.Length;
    }
    
    public int Tamanho()
    {
        return quantidade;
    }
}
```

Esta implementação utiliza um vetor para armazenar elementos e controla o início e fim da fila com índices que "circulam" pelo vetor. A variável `quantidade` é usada para controlar o número de elementos presentes na fila, facilitando as verificações de fila vazia e cheia.
</details>

## Exercício 2: Inverter uma Fila Circular

**Objetivo**: Implementar um método para inverter a ordem dos elementos em uma Fila Circular.

**Descrição**: Adicione um método `Inverter()` à classe `FilaCircular` que inverta a ordem dos elementos na fila. Por exemplo, se a fila contém [1, 2, 3, 4] (onde 1 é o início e 4 é o fim), após a inversão deve conter [4, 3, 2, 1].

**Requisitos**:
- Você pode usar uma estrutura auxiliar, como outra fila ou pilha.
- A fila deve manter sua capacidade original.
- Após a inversão, o primeiro elemento a entrar deve ser o último a sair.

<details>
  <summary>Ver solução</summary>
  
```csharp
public void Inverter()
{
    if (EstaVazia() || Tamanho() == 1)
        return; // Não há o que inverter
    
    // Utilizamos uma pilha para auxiliar na inversão
    Stack<int> pilhaAuxiliar = new Stack<int>(quantidade);
    
    // Desenfileiramos todos os elementos e empilhamos
    while (!EstaVazia())
    {
        pilhaAuxiliar.Push(Desenfileirar());
    }
    
    // Desempilhamos e enfileiramos de volta
    while (pilhaAuxiliar.Count > 0)
    {
        Enfileirar(pilhaAuxiliar.Pop());
    }
}
```

Esta solução utiliza uma pilha como estrutura auxiliar para inverter a ordem dos elementos. Ao desenfileirar os elementos e empilhá-los, e depois desempilhar e enfileirar de volta, obtemos a inversão da ordem dos elementos devido à característica LIFO (Last In, First Out) da pilha.
</details>


## Exercício 3: Combinar duas Filas Circulares

**Objetivo**: Implementar um método para combinar duas filas circulares em uma única fila.

**Descrição**: Crie um método estático `Combinar` na classe `FilaCircular` que receba duas filas circulares e retorne uma nova fila contendo todos os elementos das duas filas, mantendo a ordem original. Os elementos da primeira fila devem vir antes dos elementos da segunda fila.

**Requisitos**:
- O método deve ter a assinatura: `public static FilaCircular Combinar(FilaCircular fila1, FilaCircular fila2)`
- A capacidade da nova fila deve ser suficiente para armazenar todos os elementos
- As filas originais não devem ser modificadas

<details>
  <summary>Ver solução</summary>
  
```csharp
public static FilaCircular Combinar(FilaCircular fila1, FilaCircular fila2)
{
    // Criamos uma nova fila com capacidade suficiente para ambas as filas
    FilaCircular resultado = new FilaCircular(fila1.Tamanho() + fila2.Tamanho());
    
    // Criamos cópias das filas originais para não modificá-las
    FilaCircular copia1 = ClonarFila(fila1);
    FilaCircular copia2 = ClonarFila(fila2);
    
    // Primeiro adicionamos os elementos da fila1
    while (!copia1.EstaVazia())
    {
        resultado.Enfileirar(copia1.Desenfileirar());
    }
    
    // Depois adicionamos os elementos da fila2
    while (!copia2.EstaVazia())
    {
        resultado.Enfileirar(copia2.Desenfileirar());
    }
    
    return resultado;
}

// Método auxiliar para criar uma cópia de uma fila
private static FilaCircular ClonarFila(FilaCircular original)
{
    FilaCircular copia = new FilaCircular(original.Tamanho());
    FilaCircular temp = new FilaCircular(original.Tamanho());
    
    // Desenfileiramos da original e enfileiramos na temp
    while (!original.EstaVazia())
    {
        int elemento = original.Desenfileirar();
        temp.Enfileirar(elemento);
    }
    
    // Restauramos a fila original e criamos a cópia
    while (!temp.EstaVazia())
    {
        int elemento = temp.Desenfileirar();
        original.Enfileirar(elemento);
        copia.Enfileirar(elemento);
    }
    
    return copia;
}
```

Esta solução cria uma nova fila com capacidade suficiente para armazenar todos os elementos das duas filas originais. Para manter as filas originais intactas, primeiro criamos cópias delas usando um método auxiliar `ClonarFila`. Em seguida, enfileiramos primeiro todos os elementos da primeira fila e depois todos os elementos da segunda fila. O resultado é uma nova fila que contém todos os elementos na ordem desejada.
</details>

## Exercício 4: Verificar se duas Filas Circulares são iguais

**Objetivo**: Implementar um método para verificar se duas filas circulares contêm exatamente os mesmos elementos na mesma ordem.

**Descrição**: Crie um método estático `SaoIguais` na classe `FilaCircular` que compare duas filas circulares e retorne `true` se elas contiverem os mesmos elementos na mesma ordem, e `false` caso contrário.

**Requisitos**:
- O método deve ter a assinatura: `public static bool SaoIguais(FilaCircular fila1, FilaCircular fila2)`
- As filas originais não devem ser modificadas após a comparação
- Retornar `false` se as filas tiverem tamanhos diferentes

<details>
  <summary>Ver solução</summary>
  
```csharp
public static bool SaoIguais(FilaCircular fila1, FilaCircular fila2)
{
    // Verificação rápida: se os tamanhos são diferentes, as filas não são iguais
    if (fila1.Tamanho() != fila2.Tamanho())
        return false;
    
    // Se ambas estão vazias, são iguais
    if (fila1.EstaVazia() && fila2.EstaVazia())
        return true;
    
    // Criamos cópias das filas para não modificar as originais
    FilaCircular copia1 = ClonarFila(fila1);
    FilaCircular copia2 = ClonarFila(fila2);
    
    bool saoIguais = true;
    
    // Comparamos elemento por elemento
    while (!copia1.EstaVazia())
    {
        int elemento1 = copia1.Desenfileirar();
        int elemento2 = copia2.Desenfileirar();
        
        if (elemento1 != elemento2)
        {
            saoIguais = false;
            break;
        }
    }
    
    return saoIguais;
}

// Método auxiliar para criar uma cópia de uma fila (mesmo da solução anterior)
private static FilaCircular ClonarFila(FilaCircular original)
{
    FilaCircular copia = new FilaCircular(original.Tamanho());
    FilaCircular temp = new FilaCircular(original.Tamanho());
    
    // Desenfileiramos da original e enfileiramos na temp
    while (!original.EstaVazia())
    {
        int elemento = original.Desenfileirar();
        temp.Enfileirar(elemento);
    }
    
    // Restauramos a fila original e criamos a cópia
    while (!temp.EstaVazia())
    {
        int elemento = temp.Desenfileirar();
        original.Enfileirar(elemento);
        copia.Enfileirar(elemento);
    }
    
    return copia;
}
```

Esta solução verifica inicialmente se os tamanhos das filas são iguais, pois filas de tamanhos diferentes não podem ser iguais. Se os tamanhos forem iguais, criamos cópias das filas originais para não modificá-las. Em seguida, comparamos elemento por elemento, desenfileirando de ambas as filas ao mesmo tempo. Se algum par de elementos correspondentes for diferente, as filas não são iguais.
</details>


## Exercício 5: Implementar uma Fila Circular Genérica

**Objetivo**: Modificar a implementação básica da Fila Circular para utilizar tipos genéricos.

**Descrição**: Crie uma classe `FilaCircularGenerica<T>` que possa armazenar elementos de qualquer tipo, mantendo a mesma funcionalidade da fila circular básica.

**Requisitos**:
- A classe deve usar generics para permitir armazenar elementos de qualquer tipo
- Implemente os mesmos métodos da fila circular básica: `Enfileirar`, `Desenfileirar`, `VerInicio`, etc.
- Adicione tratamento adequado para valores nulos

<details>
  <summary>Ver solução</summary>
  
```csharp
public class FilaCircularGenerica<T>
{
    private T[] elementos;
    private int inicio;
    private int fim;
    private int quantidade;
    
    public FilaCircularGenerica(int capacidade)
    {
        if (capacidade <= 0)
            throw new ArgumentException("A capacidade deve ser maior que zero");
            
        elementos = new T[capacidade];
        inicio = 0;
        fim = -1;
        quantidade = 0;
    }
    
    public bool Enfileirar(T elemento)
    {
        if (EstaCheia())
            return false;
        
        fim = (fim + 1) % elementos.Length;
        elementos[fim] = elemento;
        quantidade++;
        return true;
    }
    
    public T Desenfileirar()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A fila está vazia");
        
        T elemento = elementos[inicio];
        elementos[inicio] = default(T); // Libera referência para coleta de lixo
        inicio = (inicio + 1) % elementos.Length;
        quantidade--;
        return elemento;
    }
    
    public T VerInicio()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A fila está vazia");
        
        return elementos[inicio];
    }
    
    public bool EstaVazia()
    {
        return quantidade == 0;
    }
    
    public bool EstaCheia()
    {
        return quantidade == elementos.Length;
    }
    
    public int Tamanho()
    {
        return quantidade;
    }
    
    public int Capacidade()
    {
        return elementos.Length;
    }
}
```

Esta implementação genérica permite que a fila circular armazene elementos de qualquer tipo. A principal diferença para a versão com inteiros é o uso do tipo genérico `T` e a atribuição de `default(T)` quando um elemento é removido, o que ajuda na liberação de memória para tipos por referência.
</details>

## Exercício 6: Implementar um método para exibir a fila circular

**Objetivo**: Adicionar um método que permita visualizar todos os elementos da fila sem modificá-la.

**Descrição**: Adicione um método `ExibirElementos()` à classe `FilaCircular` que imprima todos os elementos da fila na ordem em que seriam desenfileirados, sem alterá-la.

**Requisitos**:
- O método não deve modificar o estado da fila
- A ordem de exibição deve ser do início para o fim da fila
- Exiba uma mensagem apropriada se a fila estiver vazia

<details>
  <summary>Ver solução</summary>
  
```csharp
public void ExibirElementos()
{
    if (EstaVazia())
    {
        Console.WriteLine("A fila está vazia.");
        return;
    }
    
    Console.Write("Elementos da fila: ");
    
    // Salvamos o estado atual da fila
    int inicioAtual = inicio;
    int quantidadeElementos = quantidade;
    
    // Percorremos todos os elementos na ordem correta
    for (int i = 0; i < quantidadeElementos; i++)
    {
        int indice = (inicioAtual + i) % elementos.Length;
        Console.Write(elementos[indice]);
        
        // Adiciona separador entre os elementos, exceto para o último
        if (i < quantidadeElementos - 1)
            Console.Write(", ");
    }
    
    Console.WriteLine();
}
```

Esta solução exibe todos os elementos da fila sem modificá-la, percorrendo o vetor na ordem correta a partir do índice de início. Como a fila é circular, usamos o operador de módulo para garantir que os índices permaneçam dentro dos limites do vetor.

Alternativamente, poderíamos também usar uma fila temporária:

```csharp
public void ExibirElementosAlternativo()
{
    if (EstaVazia())
    {
        Console.WriteLine("A fila está vazia.");
        return;
    }
    
    Console.Write("Elementos da fila: ");
    
    // Criamos uma fila temporária para não alterar a original
    FilaCircular temp = new FilaCircular(Tamanho());
    StringBuilder saida = new StringBuilder();
    
    // Desenfileiramos cada elemento, exibimos e colocamos na fila temporária
    while (!EstaVazia())
    {
        int elemento = Desenfileirar();
        saida.Append(elemento);
        
        if (!EstaVazia())
            saida.Append(", ");
            
        temp.Enfileirar(elemento);
    }
    
    // Restauramos a fila original
    while (!temp.EstaVazia())
    {
        Enfileirar(temp.Desenfileirar());
    }
    
    Console.WriteLine(saida.ToString());
}
```

A segunda abordagem também preserva o estado da fila, mas é menos eficiente porque envolve operações de desenfileiramento e enfileiramento de todos os elementos.
</details>


## Exercício 7: Implementar redimensionamento da Fila Circular

**Objetivo**: Adicionar a capacidade de redimensionar dinamicamente a fila circular quando ela estiver cheia.

**Descrição**: Modifique a classe `FilaCircular` para incluir um método `Redimensionar()` que aumente a capacidade da fila quando ela estiver cheia.

**Requisitos**:
- Ao tentar enfileirar um elemento em uma fila cheia, a fila deve aumentar automaticamente sua capacidade
- A nova capacidade deve ser o dobro da capacidade atual
- Os elementos devem manter sua ordem original após o redimensionamento
- Atualize o método `Enfileirar()` para usar o redimensionamento

<details>
  <summary>Ver solução</summary>
  
```csharp
private void Redimensionar()
{
    int novaCapacidade = elementos.Length * 2;
    int[] novosElementos = new int[novaCapacidade];
    
    // Copiamos os elementos para o novo array, reorganizando-os de forma contígua
    for (int i = 0; i < quantidade; i++)
    {
        int indiceAntigo = (inicio + i) % elementos.Length;
        novosElementos[i] = elementos[indiceAntigo];
    }
    
    // Atualizamos a referência do array e os índices
    elementos = novosElementos;
    inicio = 0;
    fim = quantidade - 1;
}

// Versão atualizada do método Enfileirar
public bool Enfileirar(int elemento)
{
    // Se a fila estiver cheia, redimensionamos
    if (EstaCheia())
        Redimensionar();
    
    fim = (fim + 1) % elementos.Length;
    elementos[fim] = elemento;
    quantidade++;
    return true;
}
```

Esta solução implementa um método `Redimensionar()` que cria um novo array com o dobro da capacidade do atual e copia todos os elementos, reorganizando-os para que fiquem contíguos no novo array. O método `Enfileirar()` foi modificado para chamar `Redimensionar()` quando a fila estiver cheia, o que permite que a fila cresça dinamicamente.
</details>

## Exercício 8: Implementar um método para pesquisar um elemento na Fila Circular

**Objetivo**: Adicionar um método que permita verificar se um determinado elemento está presente na fila.

**Descrição**: Implemente um método `Contem(int elemento)` na classe `FilaCircular` que verifique se o elemento especificado existe na fila.

**Requisitos**:
- O método deve retornar `true` se o elemento estiver na fila, e `false` caso contrário
- A fila não deve ser modificada durante a pesquisa
- Implemente também um método `IndiceDe(int elemento)` que retorne a posição do elemento na fila (ou -1 se não encontrado)

<details>
  <summary>Ver solução</summary>
  
```csharp
public bool Contem(int elemento)
{
    if (EstaVazia())
        return false;
    
    for (int i = 0; i < quantidade; i++)
    {
        int indice = (inicio + i) % elementos.Length;
        if (elementos[indice] == elemento)
            return true;
    }
    
    return false;
}

public int IndiceDe(int elemento)
{
    if (EstaVazia())
        return -1;
    
    for (int i = 0; i < quantidade; i++)
    {
        int indice = (inicio + i) % elementos.Length;
        if (elementos[indice] == elemento)
            return i; // Retorna a posição lógica, não o índice físico no array
    }
    
    return -1; // Elemento não encontrado
}
```

Esta solução implementa dois métodos: `Contem()` verifica se um elemento específico está presente na fila, percorrendo-a do início ao fim, e `IndiceDe()` retorna a posição lógica do elemento na fila (onde 0 representa o início da fila). Ambos os métodos percorrem a fila sem modificá-la, usando o operador de módulo para lidar com a natureza circular do array.
</details>

## Exercício 9: Implementar um método para remover elementos específicos da Fila Circular

**Objetivo**: Adicionar um método que permita remover todas as ocorrências de um valor específico da fila.

**Descrição**: Implemente um método `RemoverTodos(int elemento)` na classe `FilaCircular` que remova todas as ocorrências do valor especificado da fila, mantendo a ordem relativa dos elementos restantes.

**Requisitos**:
- O método deve remover todas as ocorrências do elemento especificado
- Os elementos restantes devem manter sua ordem relativa
- O método deve retornar o número de elementos removidos

<details>
  <summary>Ver solução</summary>
  
```csharp
public int RemoverTodos(int elemento)
{
    if (EstaVazia())
        return 0;
    
    int elementosRemovidos = 0;
    FilaCircular filaTemp = new FilaCircular(elementos.Length);
    
    // Percorremos a fila original
    int tamanhoOriginal = quantidade;
    for (int i = 0; i < tamanhoOriginal; i++)
    {
        int valorAtual = Desenfileirar();
        
        // Se o valor for diferente do que queremos remover, colocamos na fila temporária
        if (valorAtual != elemento)
        {
            filaTemp.Enfileirar(valorAtual);
        }
        else
        {
            elementosRemovidos++;
        }
    }
    
    // Restauramos a fila com os elementos que permaneceram
    while (!filaTemp.EstaVazia())
    {
        Enfileirar(filaTemp.Desenfileirar());
    }
    
    return elementosRemovidos;
}
```

Esta solução percorre todos os elementos da fila original, transferindo para uma fila temporária apenas os elementos que não correspondem ao valor a ser removido. Em seguida, a fila original é reconstituída com os elementos da fila temporária. O método retorna o número de elementos que foram removidos.
</details>

## Exercício 10: Implementar um teste de palíndromo usando Fila Circular

**Objetivo**: Criar um método que verifique se uma sequência de elementos na fila forma um palíndromo.

**Descrição**: Implemente um método estático `EhPalindromo(FilaCircular fila)` que verifica se os elementos na fila formam um palíndromo (lê-se igual de trás para frente).

**Requisitos**:
- O método deve retornar `true` se os elementos formarem um palíndromo, e `false` caso contrário
- A fila original não deve ser modificada
- Considere que uma fila vazia ou com um único elemento é um palíndromo

<details>
  <summary>Ver solução</summary>
  
```csharp
public static bool EhPalindromo(FilaCircular fila)
{
    // Casos básicos: fila vazia ou com um único elemento é considerada palíndromo
    if (fila.EstaVazia() || fila.Tamanho() == 1)
        return true;
    
    // Criamos uma cópia da fila para não modificar a original
    FilaCircular filaCopia = new FilaCircular(fila.Tamanho());
    Stack<int> pilha = new Stack<int>(fila.Tamanho());
    
    // Primeiro copiamos todos os elementos para a pilha e para a fila temporária
    int tamanhoOriginal = fila.Tamanho();
    for (int i = 0; i < tamanhoOriginal; i++)
    {
        int elemento = fila.Desenfileirar();
        pilha.Push(elemento);
        filaCopia.Enfileirar(elemento);
        fila.Enfileirar(elemento); // Restaura a fila original
    }
    
    // Agora comparamos os elementos da fila temporária com os da pilha
    // Como a pilha inverte a ordem, se forem iguais, temos um palíndromo
    while (!filaCopia.EstaVazia())
    {
        int elementoFila = filaCopia.Desenfileirar();
        int elementoPilha = pilha.Pop();
        
        if (elementoFila != elementoPilha)
            return false;
    }
    
    return true;
}
```

Esta solução utiliza uma pilha como estrutura auxiliar para verificar se a sequência de elementos forma um palíndromo. Primeiro, copiamos todos os elementos da fila original para uma pilha (que inverte a ordem) e para uma fila temporária (que mantém a ordem). Em seguida, comparamos os elementos da fila temporária com os da pilha. Se todos forem iguais, a sequência é um palíndromo.
</details>