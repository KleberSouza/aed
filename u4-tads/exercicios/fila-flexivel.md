# Exercícios de Fila Dinâmica com Referência em C#

Bem-vindo(a) a esta página de exercícios sobre Fila Dinâmica com Referência em C#! Para cada exercício, tente desenvolver sua solução antes de verificar a resposta.

## Exercício 1: Implementação básica de uma Fila Dinâmica

**Objetivo**: Implementar uma classe básica de Fila Dinâmica usando referências (ponteiros) em C#.

**Descrição**: Crie uma classe `FilaDinamica` que armazene números inteiros usando nós encadeados. A classe deve implementar o comportamento FIFO (First In, First Out) e utilizar referências para conectar os nós.

**Requisitos**:
- Crie uma classe interna `No` que contenha um valor inteiro e uma referência para o próximo nó
- Implemente os seguintes métodos:
  * `Enfileirar(int valor)`: adiciona um valor no final da fila
  * `Desenfileirar()`: remove e retorna o valor do início da fila
  * `VerInicio()`: retorna o valor do início sem removê-lo
  * `EstaVazia()`: verifica se a fila está vazia
  * `Tamanho()`: retorna a quantidade de elementos na fila

<details>
  <summary>Ver solução</summary>
  
```csharp
public class FilaDinamica
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
    
    private No inicio;
    private No fim;
    private int quantidade;
    
    public FilaDinamica()
    {
        inicio = null;
        fim = null;
        quantidade = 0;
    }
    
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
            // Adiciona o novo nó no final da fila
            fim.Proximo = novoNo;
            fim = novoNo;
        }
        
        quantidade++;
    }
    
    public int Desenfileirar()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A fila está vazia");
        
        int valor = inicio.Valor;
        
        // Move o ponteiro de início para o próximo nó
        inicio = inicio.Proximo;
        
        // Se removermos o último elemento, atualizamos também o ponteiro de fim
        if (inicio == null)
            fim = null;
        
        quantidade--;
        return valor;
    }
    
    public int VerInicio()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A fila está vazia");
        
        return inicio.Valor;
    }
    
    public bool EstaVazia()
    {
        return inicio == null;
    }
    
    public int Tamanho()
    {
        return quantidade;
    }
}
```

Esta implementação usa uma estrutura de nós encadeados para criar uma fila dinâmica. Cada nó contém um valor inteiro e uma referência para o próximo nó na fila. A classe mantém referências para o início e o fim da fila, permitindo operações eficientes de enfileiramento e desenfileiramento. Ao contrário da fila estática circular, a fila dinâmica não tem uma capacidade máxima pré-definida e pode crescer conforme necessário.
</details>

## Exercício 2: Implementar um método para exibir os elementos da Fila Dinâmica

**Objetivo**: Adicionar um método que permita visualizar todos os elementos da fila sem modificá-la.

**Descrição**: Implemente um método `ExibirElementos()` na classe `FilaDinamica` que imprima todos os elementos da fila na ordem em que seriam desenfileirados, sem alterar o estado da fila.

**Requisitos**:
- O método não deve modificar a estrutura da fila
- Os elementos devem ser exibidos na ordem correta (do início para o fim)
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
    
    // Percorre a fila a partir do início, seguindo as referências
    No atual = inicio;
    while (atual != null)
    {
        Console.Write(atual.Valor);
        atual = atual.Proximo;
        
        // Adiciona um separador entre os elementos, exceto para o último
        if (atual != null)
            Console.Write(", ");
    }
    
    Console.WriteLine();
}
```

Esta solução percorre todos os nós da fila a partir do início, seguindo as referências para os próximos nós, e exibe seus valores. Como estamos apenas lendo os valores sem alterar as referências, a estrutura da fila permanece intacta. A verificação de fila vazia no início garante que tratamos esse caso especial adequadamente.
</details>

## Exercício 3: Implementar uma Fila Dinâmica Genérica

**Objetivo**: Modificar a implementação básica da Fila Dinâmica para utilizar tipos genéricos.

**Descrição**: Crie uma classe `FilaDinamicaGenerica<T>` que possa armazenar elementos de qualquer tipo, mantendo a mesma funcionalidade da fila dinâmica básica.

**Requisitos**:
- A classe deve usar generics para permitir armazenar elementos de qualquer tipo
- Implemente os mesmos métodos da fila dinâmica básica: `Enfileirar`, `Desenfileirar`, `VerInicio`, etc.
- Adicione tratamento adequado para valores nulos

<details>
  <summary>Ver solução</summary>
  
```csharp
public class FilaDinamicaGenerica<T>
{
    private class No
    {
        public T Valor { get; set; }
        public No Proximo { get; set; }
        
        public No(T valor)
        {
            Valor = valor;
            Proximo = null;
        }
    }
    
    private No inicio;
    private No fim;
    private int quantidade;
    
    public FilaDinamicaGenerica()
    {
        inicio = null;
        fim = null;
        quantidade = 0;
    }
    
    public void Enfileirar(T valor)
    {
        No novoNo = new No(valor);
        
        if (EstaVazia())
        {
            inicio = novoNo;
            fim = novoNo;
        }
        else
        {
            fim.Proximo = novoNo;
            fim = novoNo;
        }
        
        quantidade++;
    }
    
    public T Desenfileirar()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A fila está vazia");
        
        T valor = inicio.Valor;
        inicio = inicio.Proximo;
        
        if (inicio == null)
            fim = null;
        
        quantidade--;
        return valor;
    }
    
    public T VerInicio()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A fila está vazia");
        
        return inicio.Valor;
    }
    
    public bool EstaVazia()
    {
        return inicio == null;
    }
    
    public int Tamanho()
    {
        return quantidade;
    }
    
    public void ExibirElementos()
    {
        if (EstaVazia())
        {
            Console.WriteLine("A fila está vazia.");
            return;
        }
        
        Console.Write("Elementos da fila: ");
        
        No atual = inicio;
        while (atual != null)
        {
            Console.Write(atual.Valor);
            atual = atual.Proximo;
            
            if (atual != null)
                Console.Write(", ");
        }
        
        Console.WriteLine();
    }
    
    // Método adicional para verificar se contém um elemento específico
    public bool Contem(T valor)
    {
        if (EstaVazia())
            return false;
        
        No atual = inicio;
        
        // Utilizamos o EqualityComparer para comparação segura entre tipos genéricos
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;
        
        while (atual != null)
        {
            if (comparer.Equals(atual.Valor, valor))
                return true;
                
            atual = atual.Proximo;
        }
        
        return false;
    }
}
```

Esta implementação genérica permite que a fila dinâmica armazene elementos de qualquer tipo. A principal diferença para a versão com inteiros é o uso do tipo genérico `T` para os valores. Além disso, adicionamos um método `Contem` que utiliza o `EqualityComparer<T>` para comparações seguras entre tipos genéricos, incluindo possíveis valores nulos.
</details>

## Exercício 4: Implementar um método para inverter a ordem dos elementos na Fila Dinâmica

**Objetivo**: Adicionar um método que inverta a ordem dos elementos na fila.

**Descrição**: Implemente um método `Inverter()` na classe `FilaDinamica` que inverta a ordem dos elementos na fila.

**Requisitos**:
- A fila deve manter sua estrutura (início e fim) após a inversão
- Após a inversão, o primeiro elemento a entrar deve ser o último a sair
- O método deve funcionar corretamente para filas vazias ou com apenas um elemento

<details>
  <summary>Ver solução</summary>
  
```csharp
public void Inverter()
{
    if (EstaVazia() || Tamanho() == 1)
        return; // Não há o que inverter
    
    // Usamos uma pilha como estrutura auxiliar para inverter a ordem
    Stack<int> pilha = new Stack<int>();
    
    // Desenfileiramos todos os elementos e empilhamos (invertendo a ordem)
    while (!EstaVazia())
    {
        pilha.Push(Desenfileirar());
    }
    
    // Reconstituímos a fila usando os elementos da pilha
    while (pilha.Count > 0)
    {
        Enfileirar(pilha.Pop());
    }
}
```

Esta solução utiliza uma pilha como estrutura auxiliar para inverter a ordem dos elementos. Primeiro, todos os elementos são removidos da fila e empilhados - isso inverte a ordem, devido à característica LIFO (Last In, First Out) da pilha. Em seguida, os elementos são desempilhados e enfileirados novamente, resultando em uma fila com os elementos na ordem inversa da original.
</details>

## Exercício 5: Implementar um método para clonar uma Fila Dinâmica

**Objetivo**: Criar um método que produza uma cópia exata da fila atual.

**Descrição**: Implemente um método `Clonar()` na classe `FilaDinamica` que retorne uma nova fila com os mesmos elementos da fila original, na mesma ordem.

**Requisitos**:
- A nova fila deve ser uma cópia profunda, não apenas uma referência
- As alterações na fila clonada não devem afetar a fila original
- A ordem dos elementos deve ser preservada

<details>
  <summary>Ver solução</summary>
  
```csharp
public FilaDinamica Clonar()
{
    FilaDinamica novaFila = new FilaDinamica();
    
    if (EstaVazia())
        return novaFila;
    
    // Usamos uma fila temporária para ajudar na clonagem
    FilaDinamica filaTemp = new FilaDinamica();
    
    // Desenfileiramos da fila original, enfileiramos na nova fila e na temporária
    while (!EstaVazia())
    {
        int valor = Desenfileirar();
        novaFila.Enfileirar(valor);
        filaTemp.Enfileirar(valor);
    }
    
    // Restauramos a fila original
    while (!filaTemp.EstaVazia())
    {
        Enfileirar(filaTemp.Desenfileirar());
    }
    
    return novaFila;
}
```

Esta solução cria uma nova fila e transfere todos os elementos da fila original para ela, usando uma fila temporária como intermediária para preservar a fila original. Primeiro, desenfileiramos todos os elementos da fila original e os enfileiramos tanto na nova fila quanto na fila temporária. Em seguida, restauramos a fila original usando os elementos da fila temporária. O resultado é uma nova fila que contém os mesmos elementos na mesma ordem que a fila original.
</details>

## Exercício 6: Combinar duas Filas Dinâmicas

**Objetivo**: Implementar um método para combinar duas filas dinâmicas em uma única fila.

**Descrição**: Crie um método estático `Combinar` na classe `FilaDinamica` que receba duas filas dinâmicas e retorne uma nova fila contendo todos os elementos das duas filas, mantendo a ordem original. Os elementos da primeira fila devem vir antes dos elementos da segunda fila.

**Requisitos**:
- O método deve ter a assinatura: `public static FilaDinamica Combinar(FilaDinamica fila1, FilaDinamica fila2)`
- As filas originais não devem ser modificadas
- A nova fila deve conter primeiro todos os elementos da fila1, seguidos pelos elementos da fila2

<details>
  <summary>Ver solução</summary>
  
```csharp
public static FilaDinamica Combinar(FilaDinamica fila1, FilaDinamica fila2)
{
    FilaDinamica filaResultado = new FilaDinamica();
    
    // Clonamos ambas as filas para não modificá-las
    FilaDinamica cloneFila1 = fila1.Clonar();
    FilaDinamica cloneFila2 = fila2.Clonar();
    
    // Adicionamos os elementos da primeira fila
    while (!cloneFila1.EstaVazia())
    {
        filaResultado.Enfileirar(cloneFila1.Desenfileirar());
    }
    
    // Adicionamos os elementos da segunda fila
    while (!cloneFila2.EstaVazia())
    {
        filaResultado.Enfileirar(cloneFila2.Desenfileirar());
    }
    
    return filaResultado;
}
```

Esta solução cria uma nova fila e adiciona a ela todos os elementos da primeira fila, seguidos por todos os elementos da segunda fila. Para preservar as filas originais, usamos o método `Clonar()` implementado no exercício anterior para criar cópias das filas antes de desenfileirar seus elementos. O resultado é uma nova fila que contém todos os elementos na ordem desejada.
</details>

## Exercício 7: Implementar um método para remover elementos específicos da Fila Dinâmica

**Objetivo**: Adicionar um método que permita remover todas as ocorrências de um valor específico da fila.

**Descrição**: Implemente um método `RemoverTodos(int valor)` na classe `FilaDinamica` que remova todas as ocorrências do valor especificado da fila, mantendo a ordem relativa dos elementos restantes.

**Requisitos**:
- O método deve remover todas as ocorrências do valor especificado
- Os elementos restantes devem manter sua ordem relativa
- O método deve retornar o número de elementos removidos

<details>
  <summary>Ver solução</summary>
  
```csharp
public int RemoverTodos(int valor)
{
    if (EstaVazia())
        return 0;
    
    int elementosRemovidos = 0;
    FilaDinamica filaTemp = new FilaDinamica();
    
    // Percorremos a fila original
    while (!EstaVazia())
    {
        int valorAtual = Desenfileirar();
        
        // Se o valor for diferente do que queremos remover, colocamos na fila temporária
        if (valorAtual != valor)
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

Esta solução percorre todos os elementos da fila original, transferindo para uma fila temporária apenas os elementos que não correspondem ao valor a ser removido. Em seguida, a fila original é reconstituída com os elementos da fila temporária. O método retorna o número de elementos que foram removidos. A vantagem de usar uma fila dinâmica aqui é que não precisamos nos preocupar com limites de capacidade.
</details>

## Exercício 8: Verificar se duas Filas Dinâmicas são iguais

**Objetivo**: Implementar um método para verificar se duas filas dinâmicas contêm exatamente os mesmos elementos na mesma ordem.

**Descrição**: Crie um método estático `SaoIguais` na classe `FilaDinamica` que compare duas filas dinâmicas e retorne `true` se elas contiverem os mesmos elementos na mesma ordem, e `false` caso contrário.

**Requisitos**:
- O método deve ter a assinatura: `public static bool SaoIguais(FilaDinamica fila1, FilaDinamica fila2)`
- As filas originais não devem ser modificadas após a comparação
- Retornar `false` se as filas tiverem tamanhos diferentes

<details>
  <summary>Ver solução</summary>
  
```csharp
public static bool SaoIguais(FilaDinamica fila1, FilaDinamica fila2)
{
    // Verificação rápida: se os tamanhos são diferentes, as filas não são iguais
    if (fila1.Tamanho() != fila2.Tamanho())
        return false;
    
    // Se ambas estão vazias, são iguais
    if (fila1.EstaVazia() && fila2.EstaVazia())
        return true;
    
    // Criamos cópias das filas para não modificar as originais
    FilaDinamica copia1 = fila1.Clonar();
    FilaDinamica copia2 = fila2.Clonar();
    
    bool saoIguais = true;
    
    // Comparamos elemento por elemento
    while (!copia1.EstaVazia())
    {
        int valor1 = copia1.Desenfileirar();
        int valor2 = copia2.Desenfileirar();
        
        if (valor1 != valor2)
        {
            saoIguais = false;
            break;
        }
    }
    
    return saoIguais;
}
```

Esta solução verifica inicialmente se os tamanhos das filas são iguais, pois filas de tamanhos diferentes não podem ser iguais. Se os tamanhos forem iguais, criamos cópias das filas originais para não modificá-las. Em seguida, comparamos elemento por elemento, desenfileirando de ambas as filas ao mesmo tempo. Se algum par de elementos correspondentes for diferente, as filas não são iguais.
</details>

## Exercício 9: Implementar um método para intercalar os elementos de duas Filas Dinâmicas

**Objetivo**: Criar um método que combine duas filas, alternando seus elementos.

**Descrição**: Implemente um método estático `Intercalar` na classe `FilaDinamica` que receba duas filas e retorne uma nova fila com os elementos intercalados. Por exemplo, ao intercalar [1, 2, 3] e [A, B, C], o resultado deve ser [1, A, 2, B, 3, C].

**Requisitos**:
- O método deve ter a assinatura: `public static FilaDinamica Intercalar(FilaDinamica fila1, FilaDinamica fila2)`
- As filas originais não devem ser modificadas
- Se uma fila for maior que a outra, os elementos excedentes devem ser adicionados ao final da fila resultante

<details>
  <summary>Ver solução</summary>
  
```csharp
public static FilaDinamica Intercalar(FilaDinamica fila1, FilaDinamica fila2)
{
    FilaDinamica filaResultado = new FilaDinamica();
    
    // Clonamos ambas as filas para não modificá-las
    FilaDinamica cloneFila1 = fila1.Clonar();
    FilaDinamica cloneFila2 = fila2.Clonar();
    
    // Enquanto ambas as filas tiverem elementos, intercalamos
    while (!cloneFila1.EstaVazia() && !cloneFila2.EstaVazia())
    {
        filaResultado.Enfileirar(cloneFila1.Desenfileirar());
        filaResultado.Enfileirar(cloneFila2.Desenfileirar());
    }
    
    // Se a primeira fila ainda tiver elementos, adicionamos ao final
    while (!cloneFila1.EstaVazia())
    {
        filaResultado.Enfileirar(cloneFila1.Desenfileirar());
    }
    
    // Se a segunda fila ainda tiver elementos, adicionamos ao final
    while (!cloneFila2.EstaVazia())
    {
        filaResultado.Enfileirar(cloneFila2.Desenfileirar());
    }
    
    return filaResultado;
}
```

Esta solução cria uma nova fila e adiciona a ela os elementos das duas filas originais de forma intercalada. Primeiro, desenfileiramos um elemento de cada fila alternadamente enquanto ambas tiverem elementos. Em seguida, se alguma das filas ainda tiver elementos restantes, adicionamos todos eles ao final da fila resultante. Para preservar as filas originais, usamos cópias delas durante o processo.
</details>

## Exercício 10: Implementar uma Fila com dois níveis de prioridade

**Objetivo**: Criar uma variação da Fila Dinâmica que suporte dois níveis de prioridade para seus elementos.

**Descrição**: Implemente uma classe `FilaPrioridade` que funcione como uma fila com dois níveis de prioridade: alta e normal. Os elementos com prioridade alta devem ser desenfileirados antes dos elementos com prioridade normal, mesmo se tiverem sido adicionados posteriormente.

**Requisitos**:
- Crie uma classe `FilaPrioridade` com duas filas internas: uma para elementos de alta prioridade e outra para elementos de prioridade normal
- Implemente os seguintes métodos:
  * `Enfileirar(int valor, bool altaPrioridade)`: adiciona um valor à fila de alta prioridade ou normal
  * `Desenfileirar()`: remove e retorna o valor do início da fila, priorizando os elementos de alta prioridade
  * `VerInicio()`: retorna o próximo valor a ser desenfileirado sem removê-lo
  * `EstaVazia()`: verifica se ambas as filas estão vazias
  * `Tamanho()`: retorna a quantidade total de elementos em ambas as filas

<details>
  <summary>Ver solução</summary>
  
```csharp
public class FilaPrioridade
{
    private FilaDinamica filaAltaPrioridade;
    private FilaDinamica filaNormal;
    
    public FilaPrioridade()
    {
        filaAltaPrioridade = new FilaDinamica();
        filaNormal = new FilaDinamica();
    }
    
    public void Enfileirar(int valor, bool altaPrioridade)
    {
        if (altaPrioridade)
        {
            filaAltaPrioridade.Enfileirar(valor);
        }
        else
        {
            filaNormal.Enfileirar(valor);
        }
    }
    
    public int Desenfileirar()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A fila está vazia");
        
        // Prioriza elementos da fila de alta prioridade
        if (!filaAltaPrioridade.EstaVazia())
        {
            return filaAltaPrioridade.Desenfileirar();
        }
        else
        {
            return filaNormal.Desenfileirar();
        }
    }
    
    public int VerInicio()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A fila está vazia");
        
        // Prioriza elementos da fila de alta prioridade
        if (!filaAltaPrioridade.EstaVazia())
        {
            return filaAltaPrioridade.VerInicio();
        }
        else
        {
            return filaNormal.VerInicio();
        }
    }
    
    public bool EstaVazia()
    {
        return filaAltaPrioridade.EstaVazia() && filaNormal.EstaVazia();
    }
    
    public int Tamanho()
    {
        return filaAltaPrioridade.Tamanho() + filaNormal.Tamanho();
    }
    
    public void ExibirElementos()
    {
        if (EstaVazia())
        {
            Console.WriteLine("A fila está vazia.");
            return;
        }
        
        Console.WriteLine("Elementos da fila (Alta Prioridade primeiro):");
        
        if (!filaAltaPrioridade.EstaVazia())
        {
            Console.Write("Alta Prioridade: ");
            filaAltaPrioridade.ExibirElementos();
        }
        else
        {
            Console.WriteLine("Alta Prioridade: Vazia");
        }
        
        if (!filaNormal.EstaVazia())
        {
            Console.Write("Prioridade Normal: ");
            filaNormal.ExibirElementos();
        }
        else
        {
            Console.WriteLine("Prioridade Normal: Vazia");
        }
    }
}
```

Esta implementação cria uma fila com dois níveis de prioridade utilizando duas filas dinâmicas separadas: uma para elementos de alta prioridade e outra para elementos de prioridade normal. Ao desenfileirar ou consultar o próximo elemento, a fila verifica primeiro se há elementos na fila de alta prioridade; se houver, esses elementos são processados antes de qualquer elemento da fila normal. O método `ExibirElementos()` mostra os elementos das duas filas separadamente, para facilitar a visualização da estrutura.
</details>