# Bubble Sort (Versão Clássica)

O Bubble Sort é um dos algoritmos de ordenação mais simples. Seu funcionamento baseia-se na comparação e troca repetida de pares de elementos adjacentes, fazendo com que os elementos maiores "flutuem" gradualmente para o final da lista, como bolhas subindo na água.

## Algoritmo

### Descrição

1. Percorra toda a lista do início ao fim.
2. Compare cada par de elementos adjacentes.
3. Se eles estiverem na ordem errada (o primeiro elemento maior que o segundo), troque-os.
4. Repita os passos 1-3 n-1 vezes, onde n é o tamanho da lista.

### Pseudocódigo

```
ALGORITHM BubbleSort(A)
    FOR i = 0 TO length(A) - 2
        FOR j = 0 TO length(A) - 2
            IF A[j] > A[j+1]
                temp = A[j]
                A[j] = A[j+1]
                A[j+1] = temp
            END IF
        END FOR
    END FOR
END ALGORITHM
```

### Implementação em C#

```csharp
using System;

public class BubbleSort
{
    public static void Sort(int[] array)
    {
        int n = array.Length;
        
        // Loop externo controla o número de passagens
        for (int i = 0; i < n - 1; i++)
        {
            // Loop interno realiza as comparações e trocas
            for (int j = 0; j < n - 1; j++)
            {
                // Se o elemento atual for maior que o próximo
                if (array[j] > array[j + 1])
                {
                    // Troca os elementos
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
    
    // Método de demonstração
    public static void Example()
    {
        int[] array = { 64, 34, 25, 12, 22, 11, 90 };
        
        Console.WriteLine("Array original:");
        PrintArray(array);
        
        Sort(array);
        
        Console.WriteLine("\nArray ordenado:");
        PrintArray(array);
    }
    
    private static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}
```

### Passo a Passo Visual

Para visualizar o funcionamento do algoritmo, considere o seguinte exemplo com o array `[5, 1, 4, 2, 8]`:

**Primeira Passagem:**
- Comparação: `[5, 1]` → Troca → `[1, 5]`
- Comparação: `[5, 4]` → Troca → `[1, 4, 5]`
- Comparação: `[5, 2]` → Troca → `[1, 4, 2, 5]`
- Comparação: `[5, 8]` → Não troca → `[1, 4, 2, 5, 8]`

**Segunda Passagem:**
- Comparação: `[1, 4]` → Não troca → `[1, 4, 2, 5, 8]`
- Comparação: `[4, 2]` → Troca → `[1, 2, 4, 5, 8]`
- Comparação: `[4, 5]` → Não troca → `[1, 2, 4, 5, 8]`
- Comparação: `[5, 8]` → Não troca → `[1, 2, 4, 5, 8]`

E assim por diante até completar todas as passagens necessárias.

## Análise de Complexidade

### Número de Comparações

No algoritmo clássico do Bubble Sort:
- Cada passagem completa pela lista envolve `n-1` comparações
- São realizadas `n-1` passagens completas
- Total de comparações: (n-1) × (n-1) = (n-1)²

Portanto, o número de comparações é sempre:
- **Melhor caso:** (n-1)²
- **Caso médio:** (n-1)²
- **Pior caso:** (n-1)²

### Número de Trocas

O número de trocas varia de acordo com a ordenação inicial da lista:

- **Melhor caso (lista já ordenada):** 0 trocas
- **Pior caso (lista em ordem reversa):** Cada comparação resulta em uma troca, gerando (n-1)² trocas
- **Caso médio:** Aproximadamente (n-1)²/2 trocas

### Funções de Custo

Considerando que cada comparação e cada troca têm um custo constante (c₁ e c₂, respectivamente), podemos expressar as funções de custo como:

#### Melhor Caso (Lista já ordenada)
- Comparações: (n-1)² × c₁
- Trocas: 0 × c₂
- **Função de custo total:** T(n) = (n-1)² × c₁ = O(n²)

#### Pior Caso (Lista em ordem reversa)
- Comparações: (n-1)² × c₁
- Trocas: (n-1)² × c₂
- **Função de custo total:** T(n) = (n-1)² × (c₁ + c₂) = O(n²)

#### Caso Médio
- Comparações: (n-1)² × c₁
- Trocas: aproximadamente (n-1)²/2 × c₂
- **Função de custo total:** T(n) = (n-1)² × c₁ + (n-1)²/2 × c₂ = O(n²)

### Complexidade de Tempo e Espaço

| Complexidade | Descrição |
|--------------|-----------|
| Tempo (melhor caso) | O(n²) - mesmo para lista já ordenada |
| Tempo (caso médio) | O(n²) |
| Tempo (pior caso) | O(n²) - para lista em ordem reversa |
| Espaço | O(1) - ordenação in-place |

### Impacto do Tamanho da Entrada

Para ilustrar o impacto do tamanho da entrada (n) no desempenho, considere a seguinte tabela:

| Tamanho (n) | Comparações | Trocas (pior caso) | Trocas (melhor caso) |
|-------------|-------------|--------------------|-----------------------|
| 10          | 81          | 81                 | 0                     |
| 100         | 9,801       | 9,801              | 0                     |
| 1,000       | 998,001     | 998,001            | 0                     |
| 10,000      | 99,980,001  | 99,980,001         | 0                     |

Este crescimento quadrático torna o Bubble Sort impraticável para conjuntos de dados grandes.

### Comparação com Outros Algoritmos

| Algoritmo | Melhor Caso | Caso Médio | Pior Caso | Espaço | Estável |
|-----------|-------------|------------|-----------|--------|---------|
| Bubble Sort | O(n²) | O(n²) | O(n²) | O(1) | Sim |
| Insertion Sort | O(n) | O(n²) | O(n²) | O(1) | Sim |
| Selection Sort | O(n²) | O(n²) | O(n²) | O(1) | Não |
| Quick Sort | O(n log n) | O(n log n) | O(n²) | O(log n) | Não |
| Merge Sort | O(n log n) | O(n log n) | O(n log n) | O(n) | Sim |

## Exercícios

### Exercício 1: Implementação Básica

Implemente o algoritmo Bubble Sort em C# e teste-o com os seguintes arrays:
- `[64, 34, 25, 12, 22, 11, 90]`
- `[1, 2, 3, 4, 5]` (já ordenado)
- `[5, 4, 3, 2, 1]` (ordenado inversamente)

Conte manualmente o número de comparações e trocas para cada caso e compare com a análise teórica.

### Exercício 2: Bubble Sort Otimizado

Modifique o algoritmo Bubble Sort para incluir as seguintes otimizações:
1. Adicione uma flag para detectar se alguma troca foi realizada em uma passagem
2. Reduza o tamanho da lista a ser verificada a cada passagem

Compare o desempenho desta versão otimizada com a versão clássica.

### Exercício 3: Análise Experimental

Escreva um programa que:
1. Gere arrays aleatórios de tamanhos variados (10, 100, 1000, 10000)
2. Ordene cada array usando o Bubble Sort clássico e o otimizado
3. Meça e compare o tempo de execução de cada algoritmo
4. Construa um gráfico mostrando o crescimento do tempo de execução em função do tamanho do array

### Exercício 4: Casos Especiais

Analise o comportamento do Bubble Sort nos seguintes casos especiais:
1. Array com todos os elementos iguais
2. Array com apenas dois elementos fora de ordem
3. Array quase ordenado (apenas um elemento fora da posição)

Discuta como o desempenho do algoritmo varia em cada caso e se alguma otimização poderia melhorar significativamente o desempenho nesses cenários.

### Exercício 5: Implementação em Outras Linguagens

Implemente o Bubble Sort em pelo menos duas outras linguagens de programação (como Java, Python, JavaScript) e compare aspectos como:
1. Clareza do código
2. Facilidade de implementação
3. Desempenho (tempo de execução para arrays de mesmo tamanho)
4. Recursos específicos da linguagem que poderiam ser utilizados para otimizar o algoritmo