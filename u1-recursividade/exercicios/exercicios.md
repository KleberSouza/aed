# Exercícios 

Bem-vindo(a) a esta página de exercícios sobre algoritmos recursivas! Para cada exercício, tente desenvolver sua solução antes de verificar a resposta. 

## Exercício 1: Fatorial de um número

Crie uma função recursiva que calcule o fatorial de um número n.
Lembre-se que:
- 0! = 1
- n! = n × (n-1)!

<details>
  <summary>Ver solução</summary>
  
```csharp
public static int Fatorial(int n)
{
    // Caso base
    if (n == 0)
        return 1;
    
    // Chamada recursiva
    return n * Fatorial(n - 1);
}
```

A função verifica primeiro o caso base (0! = 1) e, para qualquer outro valor, faz a chamada recursiva multiplicando n pelo fatorial de (n-1).
</details>

## Exercício 2: Sequência de Fibonacci

Implemente uma função recursiva que retorne o n-ésimo termo da sequência de Fibonacci.
Lembre-se que:
- Fib(0) = 0
- Fib(1) = 1
- Fib(n) = Fib(n-1) + Fib(n-2) para n > 1

<details>
  <summary>Ver solução</summary>
  
```csharp
public static int Fibonacci(int n)
{
    // Casos base
    if (n == 0)
        return 0;
    if (n == 1)
        return 1;
    
    // Chamada recursiva
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

// Versão otimizada com memoização
public static int FibonacciOtimizado(int n, Dictionary<int, int> memo = null)
{
    if (memo == null)
        memo = new Dictionary<int, int>();
        
    if (memo.ContainsKey(n))
        return memo[n];
        
    int resultado;
    
    if (n == 0)
        resultado = 0;
    else if (n == 1)
        resultado = 1;
    else
        resultado = FibonacciOtimizado(n - 1, memo) + FibonacciOtimizado(n - 2, memo);
    
    memo[n] = resultado;
    return resultado;
}
```

A primeira solução é a implementação direta da definição recursiva. A segunda versão usa memoização para evitar recálculos, tornando-a muito mais eficiente para valores grandes de n.
</details>

## Exercício 3: Soma dos elementos de um array

Desenvolva uma função recursiva que calcule a soma de todos os elementos em um array de inteiros.

<details>
  <summary>Ver solução</summary>
  
```csharp
public static int SomaArray(int[] array, int indice = 0)
{
    // Caso base: chegamos ao final do array
    if (indice >= array.Length)
        return 0;
    
    // Chamada recursiva: elemento atual + soma do resto do array
    return array[indice] + SomaArray(array, indice + 1);
}
```

A função soma o elemento atual com a soma recursiva dos elementos restantes, utilizando um índice para controlar a posição atual no array.
</details>

## Exercício 4: Máximo Divisor Comum (MDC)

Crie uma função recursiva que calcule o MDC de dois números inteiros positivos usando o algoritmo de Euclides.
O algoritmo de Euclides se baseia na seguinte propriedade:
- MDC(a, b) = MDC(b, a % b) se b ≠ 0
- MDC(a, 0) = a

<details>
  <summary>Ver solução</summary>
  
```csharp
public static int MDC(int a, int b)
{
    // Caso base
    if (b == 0)
        return a;
    
    // Chamada recursiva usando o resto da divisão
    return MDC(b, a % b);
}
```

Esta implementação aplica diretamente o algoritmo de Euclides. Quando b se torna zero, significa que encontramos o MDC.
</details>

## Exercício 5: Torre de Hanoi

Implemente uma função recursiva que resolva o problema da Torre de Hanoi e imprima os movimentos necessários para transferir n discos da torre de origem para a torre de destino, usando uma torre auxiliar.

<details>
  <summary>Ver solução</summary>
  
```csharp
public static void TorreDeHanoi(int n, string origem, string destino, string auxiliar)
{
    // Caso base: apenas um disco para mover
    if (n == 1)
    {
        Console.WriteLine($"Mova o disco 1 da torre {origem} para a torre {destino}");
        return;
    }
    
    // Mova (n-1) discos da origem para a torre auxiliar
    TorreDeHanoi(n - 1, origem, auxiliar, destino);
    
    // Mova o disco n da origem para o destino
    Console.WriteLine($"Mova o disco {n} da torre {origem} para a torre {destino}");
    
    // Mova (n-1) discos da torre auxiliar para o destino
    TorreDeHanoi(n - 1, auxiliar, destino, origem);
}
```

A solução usa a estratégia de dividir o problema em três partes:
1. Mover (n-1) discos da torre de origem para a auxiliar
2. Mover o disco maior (n) da origem para o destino
3. Mover os (n-1) discos da torre auxiliar para a destino
</details>

## Exercício 6: Inverter uma string

Escreva uma função recursiva que inverta uma string.

<details>
  <summary>Ver solução</summary>
  
```csharp
public static string InverterString(string texto)
{
    // Caso base: string vazia ou com apenas um caractere
    if (string.IsNullOrEmpty(texto) || texto.Length == 1)
        return texto;
    
    // Chamada recursiva: último caractere + inversão do restante da string
    return texto[texto.Length - 1] + InverterString(texto.Substring(0, texto.Length - 1));
}

// Versão alternativa usando índices
public static string InverterStringAlternativa(string texto, int indice = 0)
{
    // Caso base: chegamos ao final da string
    if (indice >= texto.Length)
        return string.Empty;
    
    // Chamada recursiva: inversão do restante + caractere atual
    return InverterStringAlternativa(texto, indice + 1) + texto[indice];
}
```

A primeira solução concatena o último caractere da string com a inversão do restante. A segunda versão utiliza um índice e faz a inversão concatenando o restante da string com o caractere atual.
</details>

## Exercício 7: Verificar se um número é palíndromo

Implemente uma função recursiva que verifique se um número inteiro é um palíndromo (ou seja, se é igual quando lido da esquerda para a direita e da direita para a esquerda).

<details>
  <summary>Ver solução</summary>
  
```csharp
public static bool EhPalindromo(int numero)
{
    // Converte para string para facilitar o acesso aos dígitos
    string numeroStr = numero.ToString();
    return EhPalindromoString(numeroStr, 0, numeroStr.Length - 1);
}

private static bool EhPalindromoString(string texto, int inicio, int fim)
{
    // Caso base: verificamos todos os caracteres ou chegamos ao meio da string
    if (inicio >= fim)
        return true;
    
    // Se os caracteres nas posições equivalentes forem diferentes, não é palíndromo
    if (texto[inicio] != texto[fim])
        return false;
    
    // Chamada recursiva para verificar o próximo par de caracteres
    return EhPalindromoString(texto, inicio + 1, fim - 1);
}
```

A solução converte o número para string e então usa uma função auxiliar recursiva que compara pares de caracteres nas posições correspondentes, começando nas extremidades e avançando para o centro.
</details>

## Exercício 8: Potência de um número

Desenvolva uma função recursiva que calcule a potência de um número (x^n) onde n é um inteiro não negativo.

<details>
  <summary>Ver solução</summary>
  
```csharp
public static double Potencia(double x, int n)
{
    // Caso base: qualquer número elevado a 0 é 1
    if (n == 0)
        return 1;
    
    // Caso base: para expoente 1, retorna o próprio número
    if (n == 1)
        return x;
    
    // Otimização para potências pares
    if (n % 2 == 0)
    {
        double metade = Potencia(x, n / 2);
        return metade * metade;
    }
    
    // Para potências ímpares: x * x^(n-1)
    return x * Potencia(x, n - 1);
}
```

A solução utiliza a propriedade de que x^n = x^(n/2) * x^(n/2) para expoentes pares, reduzindo o número de chamadas recursivas e tornando o algoritmo mais eficiente.
</details>

## Exercício 9: Contagem de dígitos

Crie uma função recursiva que conte quantos dígitos existem em um número inteiro positivo.

<details>
  <summary>Ver solução</summary>
  
```csharp
public static int ContarDigitos(int numero)
{
    // Lidando com números negativos
    if (numero < 0)
        return ContarDigitos(-numero);
    
    // Caso base: números de 0 a 9 têm apenas um dígito
    if (numero < 10)
        return 1;
    
    // Chamada recursiva: remova o último dígito e conte o restante
    return 1 + ContarDigitos(numero / 10);
}
```

A cada chamada recursiva, dividimos o número por 10 (removendo o último dígito) e somamos 1 ao contador. O caso base é quando chegamos a um número com apenas um dígito.
</details>

## Exercício 10: Busca binária recursiva

Implemente uma função recursiva que realize uma busca binária em um array ordenado e retorne o índice do elemento procurado (ou -1 se não encontrado).

<details>
  <summary>Ver solução</summary>
  
```csharp
public static int BuscaBinaria(int[] array, int elemento, int inicio, int fim)
{
    // Caso base: elemento não encontrado
    if (inicio > fim)
        return -1;
    
    // Calcula o índice do meio
    int meio = inicio + (fim - inicio) / 2;
    
    // Caso base: elemento encontrado
    if (array[meio] == elemento)
        return meio;
    
    // Se o elemento estiver à esquerda do meio
    if (array[meio] > elemento)
        return BuscaBinaria(array, elemento, inicio, meio - 1);
    
    // Se o elemento estiver à direita do meio
    return BuscaBinaria(array, elemento, meio + 1, fim);
}

// Método auxiliar para facilitar a chamada inicial
public static int BuscaBinaria(int[] array, int elemento)
{
    return BuscaBinaria(array, elemento, 0, array.Length - 1);
}
```

A busca binária divide repetidamente o array ao meio e verifica em qual metade está o elemento procurado, reduzindo o espaço de busca pela metade a cada chamada recursiva.
</details>