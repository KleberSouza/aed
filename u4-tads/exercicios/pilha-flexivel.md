# Exercícios de Pilha Dinâmica com Referência em C# 

Bem-vindo(a) a esta página de exercícios sobre Pilha Dinâmica com Referência em C#! Para cada exercício, tente desenvolver sua solução antes de verificar a resposta.

## Exercício 1: Implementação básica de uma Pilha Dinâmica

**Objetivo**: Implementar uma classe básica de Pilha Dinâmica usando referências (ponteiros) em C#.

**Descrição**: Crie uma classe `PilhaDinamica` que armazene números inteiros usando nós encadeados. A classe deve implementar o comportamento LIFO (Last In, First Out) e utilizar referências para conectar os nós.

**Requisitos**:
- Crie uma classe interna `No` que contenha um valor inteiro e uma referência para o próximo nó
- Implemente os seguintes métodos:
  * `Empilhar(int valor)`: adiciona um valor no topo da pilha
  * `Desempilhar()`: remove e retorna o valor do topo da pilha
  * `VerTopo()`: retorna o valor do topo sem removê-lo
  * `EstaVazia()`: verifica se a pilha está vazia
  * `Tamanho()`: retorna a quantidade de elementos na pilha

<details>
  <summary>Ver solução</summary>
  
```csharp
public class PilhaDinamica
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
    
    private No topo;
    private int quantidade;
    
    public PilhaDinamica()
    {
        topo = null;
        quantidade = 0;
    }
    
    public void Empilhar(int valor)
    {
        No novoNo = new No(valor);
        
        // O novo nó aponta para o topo atual
        novoNo.Proximo = topo;
        
        // O topo passa a ser o novo nó
        topo = novoNo;
        
        quantidade++;
    }
    
    public int Desempilhar()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A pilha está vazia");
        
        int valor = topo.Valor;
        
        // Move o ponteiro de topo para o próximo nó
        topo = topo.Proximo;
        
        quantidade--;
        return valor;
    }
    
    public int VerTopo()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A pilha está vazia");
        
        return topo.Valor;
    }
    
    public bool EstaVazia()
    {
        return topo == null;
    }
    
    public int Tamanho()
    {
        return quantidade;
    }
}
```

Esta implementação usa uma estrutura de nós encadeados para criar uma pilha dinâmica. Cada nó contém um valor inteiro e uma referência para o próximo nó na pilha. A classe mantém uma referência apenas para o topo da pilha, pois em uma pilha só precisamos acessar o elemento mais recentemente adicionado. Diferentemente da pilha estática, a pilha dinâmica não tem uma capacidade máxima pré-definida e pode crescer conforme necessário.
</details>

## Exercício 2: Implementar um método para exibir os elementos da Pilha Dinâmica

**Objetivo**: Adicionar um método que permita visualizar todos os elementos da pilha sem modificá-la.

**Descrição**: Implemente um método `ExibirElementos()` na classe `PilhaDinamica` que imprima todos os elementos da pilha na ordem do topo para a base, sem alterar o estado da pilha.

**Requisitos**:
- O método não deve modificar a estrutura da pilha
- Os elementos devem ser exibidos na ordem correta (do topo para a base)
- Exiba uma mensagem apropriada se a pilha estiver vazia

<details>
  <summary>Ver solução</summary>
  
```csharp
public void ExibirElementos()
{
    if (EstaVazia())
    {
        Console.WriteLine("A pilha está vazia.");
        return;
    }
    
    Console.Write("Elementos da pilha (topo -> base): ");
    
    // Usamos uma pilha auxiliar para exibir os elementos sem modificar a original
    PilhaDinamica pilhaAuxiliar = new PilhaDinamica();
    
    // Armazenamos os valores em uma lista enquanto os transferimos para a pilha auxiliar
    List<int> valores = new List<int>();
    
    // Desempilhamos, salvamos o valor e empilhamos na auxiliar
    while (!EstaVazia())
    {
        int valor = Desempilhar();
        valores.Add(valor);
        pilhaAuxiliar.Empilhar(valor);
    }
    
    // Exibimos os valores
    Console.WriteLine(string.Join(", ", valores));
    
    // Restauramos a pilha original
    while (!pilhaAuxiliar.EstaVazia())
    {
        Empilhar(pilhaAuxiliar.Desempilhar());
    }
}

// Método alternativo sem usar uma List
public void ExibirElementosAlternativo()
{
    if (EstaVazia())
    {
        Console.WriteLine("A pilha está vazia.");
        return;
    }
    
    Console.Write("Elementos da pilha (topo -> base): ");
    
    // Utilizamos variáveis para rastrear a pilha atual e a reconstruída
    PilhaDinamica pilhaAuxiliar = new PilhaDinamica();
    StringBuilder saida = new StringBuilder();
    bool primeiro = true;
    
    // Desempilhamos, exibimos o valor e empilhamos na auxiliar
    while (!EstaVazia())
    {
        int valor = Desempilhar();
        
        if (!primeiro)
            saida.Append(", ");
        else
            primeiro = false;
            
        saida.Append(valor);
        pilhaAuxiliar.Empilhar(valor);
    }
    
    Console.WriteLine(saida.ToString());
    
    // Restauramos a pilha original
    while (!pilhaAuxiliar.EstaVazia())
    {
        Empilhar(pilhaAuxiliar.Desempilhar());
    }
}
```

Esta solução utiliza uma pilha auxiliar para exibir os elementos sem perder a estrutura original da pilha. Primeiro, todos os elementos são desempilhados da pilha original e armazenados em uma lista enquanto são empilhados na pilha auxiliar. Em seguida, os valores são exibidos e a pilha original é reconstruída desempilhando os elementos da pilha auxiliar. Também é fornecida uma solução alternativa que não utiliza uma lista, construindo a string de saída diretamente.
</details>

## Exercício 3: Implementar uma Pilha Dinâmica Genérica

**Objetivo**: Modificar a implementação básica da Pilha Dinâmica para utilizar tipos genéricos.

**Descrição**: Crie uma classe `PilhaDinamicaGenerica<T>` que possa armazenar elementos de qualquer tipo, mantendo a mesma funcionalidade da pilha dinâmica básica.

**Requisitos**:
- A classe deve usar generics para permitir armazenar elementos de qualquer tipo
- Implemente os mesmos métodos da pilha dinâmica básica: `Empilhar`, `Desempilhar`, `VerTopo`, etc.
- Adicione tratamento adequado para valores nulos

<details>
  <summary>Ver solução</summary>
  
```csharp
public class PilhaDinamicaGenerica<T>
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
    
    private No topo;
    private int quantidade;
    
    public PilhaDinamicaGenerica()
    {
        topo = null;
        quantidade = 0;
    }
    
    public void Empilhar(T valor)
    {
        No novoNo = new No(valor);
        novoNo.Proximo = topo;
        topo = novoNo;
        quantidade++;
    }
    
    public T Desempilhar()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A pilha está vazia");
        
        T valor = topo.Valor;
        topo = topo.Proximo;
        quantidade--;
        return valor;
    }
    
    public T VerTopo()
    {
        if (EstaVazia())
            throw new InvalidOperationException("A pilha está vazia");
        
        return topo.Valor;
    }
    
    public bool EstaVazia()
    {
        return topo == null;
    }
    
    public int Tamanho()
    {
        return quantidade;
    }
    
    public void ExibirElementos()
    {
        if (EstaVazia())
        {
            Console.WriteLine("A pilha está vazia.");
            return;
        }
        
        Console.Write("Elementos da pilha (topo -> base): ");
        
        // Usamos uma pilha auxiliar para exibir os elementos sem modificar a original
        PilhaDinamicaGenerica<T> pilhaAuxiliar = new PilhaDinamicaGenerica<T>();
        List<T> valores = new List<T>();
        
        // Desempilhamos, salvamos o valor e empilhamos na auxiliar
        while (!EstaVazia())
        {
            T valor = Desempilhar();
            valores.Add(valor);
            pilhaAuxiliar.Empilhar(valor);
        }
        
        // Exibimos os valores
        Console.WriteLine(string.Join(", ", valores));
        
        // Restauramos a pilha original
        while (!pilhaAuxiliar.EstaVazia())
        {
            Empilhar(pilhaAuxiliar.Desempilhar());
        }
    }
    
    // Método adicional para verificar se contém um elemento específico
    public bool Contem(T valor)
    {
        if (EstaVazia())
            return false;
        
        // Usamos uma pilha auxiliar para não perder os elementos
        PilhaDinamicaGenerica<T> pilhaAuxiliar = new PilhaDinamicaGenerica<T>();
        bool encontrado = false;
        
        // Utilizamos o EqualityComparer para comparação segura entre tipos genéricos
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;
        
        // Percorremos os elementos da pilha
        while (!EstaVazia())
        {
            T valorAtual = Desempilhar();
            
            if (comparer.Equals(valorAtual, valor))
                encontrado = true;
                
            pilhaAuxiliar.Empilhar(valorAtual);
        }
        
        // Restauramos a pilha original
        while (!pilhaAuxiliar.EstaVazia())
        {
            Empilhar(pilhaAuxiliar.Desempilhar());
        }
        
        return encontrado;
    }
}
```

Esta implementação genérica permite que a pilha dinâmica armazene elementos de qualquer tipo. A principal diferença para a versão com inteiros é o uso do tipo genérico `T` para os valores. O método `Contem` adicional utiliza o `EqualityComparer<T>` para comparações seguras entre tipos genéricos, incluindo possíveis valores nulos.
</details>

## Exercício 4: Implementar um método para inverter a ordem dos elementos na Pilha Dinâmica

**Objetivo**: Adicionar um método que inverta a ordem dos elementos na pilha.

**Descrição**: Implemente um método `Inverter()` na classe `PilhaDinamica` que inverta a ordem dos elementos na pilha.

**Requisitos**:
- A pilha deve manter sua estrutura após a inversão
- Após a inversão, o elemento que estava no topo deve ficar na base e vice-versa
- O método deve funcionar corretamente para pilhas vazias ou com apenas um elemento

<details>
  <summary>Ver solução</summary>
  
```csharp
public void Inverter()
{
    if (EstaVazia() || Tamanho() == 1)
        return; // Não há o que inverter
    
    // Usamos uma fila como estrutura auxiliar para inverter a ordem
    Queue<int> fila = new Queue<int>();
    
    // Desempilhamos todos os elementos e os colocamos na fila
    while (!EstaVazia())
    {
        fila.Enqueue(Desempilhar());
    }
    
    // Desenfileiramos e empilhamos de volta
    // A fila mantém a ordem original, mas ao empilhar, invertemos
    while (fila.Count > 0)
    {
        Empilhar(fila.Dequeue());
    }
}
```

Esta solução utiliza uma fila como estrutura auxiliar para inverter a ordem dos elementos na pilha. Primeiro, todos os elementos são desempilhados da pilha e enfileirados na fila. Em seguida, os elementos são desenfileirados da fila e empilhados de volta na pilha. Como a fila preserva a ordem original (FIFO) e a pilha inverte a ordem (LIFO), o resultado final é uma pilha com os elementos na ordem inversa da original.
</details>

## Exercício 5: Implementar um método para verificar expressões com parênteses balanceados

**Objetivo**: Criar um método que utilize a Pilha Dinâmica para verificar se uma expressão possui parênteses balanceados.

**Descrição**: Implemente um método estático `VerificarParentesesBalanceados` na classe `PilhaDinamica` que receba uma string contendo uma expressão matemática e verifique se os parênteses estão corretamente balanceados.

**Requisitos**:
- O método deve ter a assinatura: `public static bool VerificarParentesesBalanceados(string expressao)`
- Deve verificar se cada parêntese aberto '(' possui um correspondente fechado ')'
- Deve verificar se os parênteses estão na ordem correta (não pode haver ')' antes de '(')
- Deve retornar true se os parênteses estiverem balanceados e false caso contrário

<details>
  <summary>Ver solução</summary>
  
```csharp
public static bool VerificarParentesesBalanceados(string expressao)
{
    if (string.IsNullOrEmpty(expressao))
        return true; // Uma expressão vazia é considerada balanceada
    
    PilhaDinamica pilha = new PilhaDinamica();
    
    foreach (char c in expressao)
    {
        if (c == '(')
        {
            // Quando encontramos um parêntese aberto, empilhamos
            pilha.Empilhar(1); // O valor não importa, apenas marcamos a presença
        }
        else if (c == ')')
        {
            // Quando encontramos um parêntese fechado, deve haver um aberto na pilha
            if (pilha.EstaVazia())
                return false; // Parêntese fechado sem um aberto correspondente
                
            pilha.Desempilhar();
        }
        // Ignoramos qualquer outro caractere
    }
    
    // Se a pilha estiver vazia, todos os parênteses foram balanceados
    return pilha.EstaVazia();
}

// Versão mais avançada que suporta múltiplos tipos de parênteses: (), [], {}
public static bool VerificarMultiplosParentesesBalanceados(string expressao)
{
    if (string.IsNullOrEmpty(expressao))
        return true;
    
    PilhaDinamicaGenerica<char> pilha = new PilhaDinamicaGenerica<char>();
    
    foreach (char c in expressao)
    {
        if (c == '(' || c == '[' || c == '{')
        {
            // Empilhamos o caractere de abertura
            pilha.Empilhar(c);
        }
        else if (c == ')' || c == ']' || c == '}')
        {
            // Verificamos se há um caractere de abertura correspondente
            if (pilha.EstaVazia())
                return false;
                
            char abertura = pilha.Desempilhar();
            
            // Verificamos se o fechamento corresponde à abertura
            if ((c == ')' && abertura != '(') ||
                (c == ']' && abertura != '[') ||
                (c == '}' && abertura != '{'))
            {
                return false;
            }
        }
    }
    
    return pilha.EstaVazia();
}
```

Esta solução utiliza uma pilha para rastrear parênteses abertos. Quando encontramos um parêntese aberto '(', empilhamos um marcador. Quando encontramos um parêntese fechado ')', verificamos se há um parêntese aberto correspondente na pilha (desempilhando). Se a expressão for válida, a pilha estará vazia no final. Também é fornecida uma versão mais avançada que suporta múltiplos tipos de parênteses (parênteses, colchetes e chaves).
</details>

## Exercício 6: Implementar um método para avaliar expressões em notação polonesa reversa (RPN)

**Objetivo**: Criar um método que utilize a Pilha Dinâmica para avaliar expressões matemáticas em notação polonesa reversa.

**Descrição**: Implemente um método estático `AvaliarExpressaoRPN` na classe `PilhaDinamica` que receba uma string contendo uma expressão em notação polonesa reversa (também conhecida como notação pós-fixa) e retorne o resultado da expressão.

**Requisitos**:
- O método deve ter a assinatura: `public static double AvaliarExpressaoRPN(string expressao)`
- Deve suportar operações básicas: adição (+), subtração (-), multiplicação (*) e divisão (/)
- Os operandos e operadores devem estar separados por espaços
- Deve lançar uma exceção se a expressão for inválida

<details>
  <summary>Ver solução</summary>
  
```csharp
public static double AvaliarExpressaoRPN(string expressao)
{
    if (string.IsNullOrEmpty(expressao))
        throw new ArgumentException("A expressão não pode ser vazia");
    
    PilhaDinamicaGenerica<double> pilha = new PilhaDinamicaGenerica<double>();
    string[] tokens = expressao.Split(' ');
    
    foreach (string token in tokens)
    {
        // Ignoramos espaços em branco
        if (string.IsNullOrWhiteSpace(token))
            continue;
        
        // Se for um operador, realizamos a operação com os dois operandos do topo
        if (token == "+" || token == "-" || token == "*" || token == "/")
        {
            // Precisamos de pelo menos dois operandos na pilha
            if (pilha.Tamanho() < 2)
                throw new InvalidOperationException("Expressão RPN inválida: operandos insuficientes para o operador " + token);
            
            double operando2 = pilha.Desempilhar();
            double operando1 = pilha.Desempilhar();
            
            switch (token)
            {
                case "+":
                    pilha.Empilhar(operando1 + operando2);
                    break;
                case "-":
                    pilha.Empilhar(operando1 - operando2);
                    break;
                case "*":
                    pilha.Empilhar(operando1 * operando2);
                    break;
                case "/":
                    if (operando2 == 0)
                        throw new DivideByZeroException("Divisão por zero");
                    pilha.Empilhar(operando1 / operando2);
                    break;
            }
        }
        else
        {
            // Se não for um operador, deve ser um número
            if (!double.TryParse(token, out double numero))
                throw new FormatException($"Token inválido: '{token}' não é um número ou operador válido");
                
            pilha.Empilhar(numero);
        }
    }
    
    // No final, deve haver exatamente um valor na pilha (o resultado)
    if (pilha.Tamanho() != 1)
        throw new InvalidOperationException("Expressão RPN inválida: operandos em excesso");
        
    return pilha.Desempilhar();
}
```

Esta solução utiliza uma pilha para avaliar uma expressão em notação polonesa reversa (RPN). Na notação RPN, os operadores vêm após seus operandos, o que facilita a avaliação usando uma pilha. Para cada token na expressão, se for um número, empilhamos. Se for um operador, desempilhamos os dois operandos superiores, aplicamos a operação e empilhamos o resultado. No final, o resultado da expressão estará no topo da pilha. A solução inclui validações para garantir que a expressão é válida.
</details>


## Exercício 7: Implementar um método para remover elementos específicos da Pilha Dinâmica

**Objetivo**: Adicionar um método que permita remover todas as ocorrências de um valor específico da pilha.

**Descrição**: Implemente um método `RemoverTodos(int valor)` na classe `PilhaDinamica` que remova todas as ocorrências do valor especificado da pilha, mantendo a ordem relativa dos elementos restantes.

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
    PilhaDinamica pilhaAuxiliar = new PilhaDinamica();
    
    // Desempilhamos todos os elementos
    while (!EstaVazia())
    {
        int valorAtual = Desempilhar();
        
        // Se o valor for diferente do que queremos remover, colocamos na pilha auxiliar
        if (valorAtual != valor)
        {
            pilhaAuxiliar.Empilhar(valorAtual);
        }
        else
        {
            elementosRemovidos++;
        }
    }
    
    // Restauramos a pilha original, mas sem os elementos removidos
    // Como estamos empilhando de volta da pilha auxiliar, a ordem será invertida
    // Por isso precisamos inverter a pilha auxiliar primeiro
    while (!pilhaAuxiliar.EstaVazia())
    {
        Empilhar(pilhaAuxiliar.Desempilhar());
    }
    
    return elementosRemovidos;
}
```

Esta solução utiliza uma pilha auxiliar para filtrar os elementos que não devem ser removidos. Primeiro, todos os elementos são desempilhados da pilha original e, se forem diferentes do valor a ser removido, são empilhados na pilha auxiliar. Em seguida, os elementos da pilha auxiliar são desempilhados e empilhados de volta na pilha original. Como desempilhar e empilhar inverte a ordem, a solução mantém a ordem relativa original dos elementos.
</details>

## Exercício 8: Implementar um método para ordenar uma Pilha Dinâmica

**Objetivo**: Adicionar um método que ordene os elementos da pilha em ordem crescente.

**Descrição**: Implemente um método `Ordenar()` na classe `PilhaDinamica` que ordene os elementos da pilha de forma que o menor elemento fique no topo e o maior elemento fique na base.

**Requisitos**:
- O método deve ordenar os elementos em ordem crescente (do menor para o maior)
- Após a ordenação, o menor elemento deve estar no topo da pilha
- O método deve funcionar corretamente para pilhas vazias ou com apenas um elemento

<details>
  <summary>Ver solução</summary>
  
```csharp
public void Ordenar()
{
    if (EstaVazia() || Tamanho() == 1)
        return; // Não há o que ordenar
    
    // Utilizamos uma pilha auxiliar para ordenar
    PilhaDinamica pilhaAuxiliar = new PilhaDinamica();
    
    while (!EstaVazia())
    {
        // Retiramos o elemento do topo da pilha original
        int temp = Desempilhar();
        
        // Movemos elementos da pilha auxiliar para a original até encontrar 
        // a posição correta para o elemento temp
        while (!pilhaAuxiliar.EstaVazia() && pilhaAuxiliar.VerTopo() < temp)
        {
            Empilhar(pilhaAuxiliar.Desempilhar());
        }
        
        // Colocamos o elemento temp na pilha auxiliar
        pilhaAuxiliar.Empilhar(temp);
    }
    
    // Transferimos todos os elementos da pilha auxiliar de volta para a pilha original
    while (!pilhaAuxiliar.EstaVazia())
    {
        Empilhar(pilhaAuxiliar.Desempilhar());
    }
}
```

Esta solução usa o algoritmo de ordenação por inserção adaptado para pilhas. Utilizamos uma pilha auxiliar para construir gradualmente uma versão ordenada da pilha original. Para cada elemento da pilha original, encontramos sua posição correta na pilha auxiliar, movendo elementos entre as pilhas conforme necessário. No final, todos os elementos estarão na pilha auxiliar em ordem crescente, e então os transferimos de volta para a pilha original, resultando em uma pilha ordenada com o menor elemento no topo.
</details>


## Exercício 9: Implementar um método para verificar se uma string é um palíndromo

**Objetivo**: Criar um método que utilize a Pilha Dinâmica para verificar se uma string é um palíndromo.

**Descrição**: Implemente um método estático `EhPalindromo` na classe `PilhaDinamica` que verifique se uma string é um palíndromo (lê-se igual de trás para frente, ignorando espaços e diferenças entre maiúsculas e minúsculas).

**Requisitos**:
- O método deve ter a assinatura: `public static bool EhPalindromo(string texto)`
- Deve ignorar espaços, pontuação e diferenças entre maiúsculas e minúsculas
- Deve retornar true se a string for um palíndromo e false caso contrário

<details>
  <summary>Ver solução</summary>
  
```csharp
public static bool EhPalindromo(string texto)
{
    if (string.IsNullOrEmpty(texto))
        return true; // Uma string vazia é considerada um palíndromo
    
    // Removemos espaços, pontuação e convertemos para minúsculas
    string textoLimpo = new string(texto.ToLower()
        .Where(c => char.IsLetterOrDigit(c))
        .ToArray());
    
    if (string.IsNullOrEmpty(textoLimpo))
        return true; // Se só havia espaços ou pontuação, consideramos um palíndromo
    
    // Usamos uma pilha para verificar se a string é um palíndromo
    PilhaDinamicaGenerica<char> pilha = new PilhaDinamicaGenerica<char>();
    
    // Empilhamos metade dos caracteres
    int metade = textoLimpo.Length / 2;
    for (int i = 0; i < metade; i++)
    {
        pilha.Empilhar(textoLimpo[i]);
    }
    
    // Pulamos o caractere do meio para strings de tamanho ímpar
    int inicio = textoLimpo.Length % 2 == 0 ? metade : metade + 1;
    
    // Comparamos a segunda metade com os caracteres desempilhados
    for (int i = inicio; i < textoLimpo.Length; i++)
    {
        char caracterPilha = pilha.Desempilhar();
        if (caracterPilha != textoLimpo[i])
            return false;
    }
    
    return true;
}
```

Esta solução utiliza uma pilha para verificar se uma string é um palíndromo. Primeiro, limpamos a string removendo espaços, pontuação e convertendo tudo para minúsculas. Em seguida, empilhamos a primeira metade dos caracteres. Depois, comparamos a segunda metade da string com os caracteres desempilhados - se forem iguais, a string é um palíndromo. Para strings de tamanho ímpar, pulamos o caractere do meio.
</details>

## Exercício 10: Implementar uma calculadora simples usando pilha

**Objetivo**: Criar uma classe `Calculadora` que utilize a Pilha Dinâmica para avaliar expressões matemáticas.

**Descrição**: Implemente uma classe `Calculadora` com um método `Calcular` que receba uma expressão matemática em formato de string e retorne o resultado da expressão.

**Requisitos**:
- A calculadora deve suportar as operações básicas: adição (+), subtração (-), multiplicação (*) e divisão (/)
- Deve respeitar a precedência dos operadores (multiplicação e divisão têm precedência sobre adição e subtração)
- Deve suportar o uso de parênteses para alterar a precedência
- Deve lançar uma exceção se a expressão for inválida

<details>
  <summary>Ver solução</summary>
  
```csharp
public class Calculadora
{
    public static double Calcular(string expressao)
    {
        if (string.IsNullOrEmpty(expressao))
            throw new ArgumentException("A expressão não pode ser vazia");
        
        // Pilhas para operandos e operadores
        PilhaDinamicaGenerica<double> pilhaValores = new PilhaDinamicaGenerica<double>();
        PilhaDinamicaGenerica<char> pilhaOperadores = new PilhaDinamicaGenerica<char>();
        
        for (int i = 0; i < expressao.Length; i++)
        {
            char c = expressao[i];
            
            // Ignoramos espaços
            if (c == ' ')
                continue;
            
            // Se for um dígito, lemos o número completo
            if (char.IsDigit(c) || c == '.')
            {
                string numeroStr = "";
                
                // Lemos o número completo (pode ter vários dígitos ou decimal)
                while (i < expressao.Length && (char.IsDigit(expressao[i]) || expressao[i] == '.'))
                {
                    numeroStr += expressao[i];
                    i++;
                }
                
                // Voltamos um índice, pois o loop principal também incrementa
                i--;
                
                // Convertemos para double e empilhamos
                if (double.TryParse(numeroStr, out double numero))
                {
                    pilhaValores.Empilhar(numero);
                }
                else
                {
                    throw new FormatException($"Número inválido: {numeroStr}");
                }
            }
            // Se for um parêntese aberto, empilhamos
            else if (c == '(')
            {
                pilhaOperadores.Empilhar(c);
            }
            // Se for um parêntese fechado, processamos tudo até o parêntese aberto correspondente
            else if (c == ')')
            {
                while (!pilhaOperadores.EstaVazia() && pilhaOperadores.VerTopo() != '(')
                {
                    ProcessarOperador(pilhaValores, pilhaOperadores);
                }
                
                // Removemos o parêntese aberto
                if (!pilhaOperadores.EstaVazia() && pilhaOperadores.VerTopo() == '(')
                {
                    pilhaOperadores.Desempilhar();
                }
                else
                {
                    throw new InvalidOperationException("Parênteses desbalanceados");
                }
            }
            // Se for um operador
            else if (c == '+' || c == '-' || c == '*' || c == '/')
            {
                // Enquanto houver operadores de maior ou igual precedência na pilha, processamos
                while (!pilhaOperadores.EstaVazia() && Precedencia(pilhaOperadores.VerTopo()) >= Precedencia(c))
                {
                    ProcessarOperador(pilhaValores, pilhaOperadores);
                }
                
                // Empilhamos o operador atual
                pilhaOperadores.Empilhar(c);
            }
            else
            {
                throw new InvalidOperationException($"Caractere inválido: {c}");
            }
        }
        
        // Processamos todos os operadores restantes
        while (!pilhaOperadores.EstaVazia())
        {
            ProcessarOperador(pilhaValores, pilhaOperadores);
        }
        
        // O resultado final deve estar no topo da pilha de valores
        if (pilhaValores.Tamanho() != 1)
            throw new InvalidOperationException("Expressão inválida");
            
        return pilhaValores.Desempilhar();
    }
    
    private static void ProcessarOperador(PilhaDinamicaGenerica<double> pilhaValores, PilhaDinamicaGenerica<char> pilhaOperadores)
    {
        if (pilhaValores.Tamanho() < 2)
            throw new InvalidOperationException("Expressão inválida: operandos insuficientes");
            
        char operador = pilhaOperadores.Desempilhar();
        
        // Os operandos estão na pilha ao contrário: o segundo operando está no topo
        double operando2 = pilhaValores.Desempilhar();
        double operando1 = pilhaValores.Desempilhar();
        
        switch (operador)
        {
            case '+':
                pilhaValores.Empilhar(operando1 + operando2);
                break;
            case '-':
                pilhaValores.Empilhar(operando1 - operando2);
                break;
            case '*':
                pilhaValores.Empilhar(operando1 * operando2);
                break;
            case '/':
                if (operando2 == 0)
                    throw new DivideByZeroException("Divisão por zero");
                pilhaValores.Empilhar(operando1 / operando2);
                break;
            default:
                throw new InvalidOperationException($"Operador desconhecido: {operador}");
        }
    }
    
    private static int Precedencia(char operador)
    {
        switch (operador)
        {
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
            default:
                return 0; // Para parênteses e outros caracteres
        }
    }
}
```

Esta solução implementa uma calculadora usando duas pilhas: uma para valores e outra para operadores. A ideia principal é: quando encontramos um número, empilhamos na pilha de valores; quando encontramos um operador, verificamos a precedência com os operadores já na pilha e processamos os de maior precedência antes de empilhar o novo operador. Os parênteses são tratados de forma especial - quando encontramos um parêntese fechado, processamos tudo até o parêntese aberto correspondente. No final, todos os operadores restantes são processados, e o resultado final fica no topo da pilha de valores.
</details>