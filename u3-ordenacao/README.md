# 🧮 Unidade 3: Ordenação Interna

## 🔍 Introdução

**Ordenação Interna** refere-se a algoritmos de ordenação onde todos os dados cabem na memória principal (RAM). Esses algoritmos são fundamentais em ciência da computação, pois muitos problemas exigem dados ordenados como etapa intermediária.

O objetivo principal é reorganizar os elementos de uma coleção (como um vetor ou lista) em uma ordem específica — geralmente crescente ou decrescente.

---

## 🔢 Algoritmos Clássicos de Ordenação

Nesta unidade, estudamos os principais algoritmos de ordenação, desde os mais simples até os mais eficientes. Cada algoritmo possui características específicas quanto à complexidade, estabilidade e uso de memória.

| Algoritmo | Descrição | Estável | Complexidade Média | Link |
|-----------|-----------|---------|---------------------|------|
| Bubble Sort | Compara e troca pares adjacentes até ordenar | Sim | O(n²) | [Ver Código](../3-OrdenacaoInterna/Exemplos/BubbleSort/) |
| Selection Sort | Encontra o menor elemento e coloca na posição correta | Não | O(n²) | [Ver Código](../3-OrdenacaoInterna/Exemplos/SelectionSort/) |
| Insertion Sort | Insere cada elemento na posição correta de forma incremental | Sim | O(n²) | [Ver Código](../3-OrdenacaoInterna/Exemplos/InsertionSort/) |
| Shell Sort | Variante do Insertion com saltos | Não | O(n log² n) | [Ver Código](../3-OrdenacaoInterna/Exemplos/ShellSort/) |
| Merge Sort | Divide e conquista, ordena e mescla sublistas | Sim | O(n log n) | [Ver Código](../3-OrdenacaoInterna/Exemplos/MergeSort/) |
| Quick Sort | Escolhe um pivô e particiona o vetor em torno dele | Não | O(n log n) | [Ver Código](../3-OrdenacaoInterna/Exemplos/QuickSort/) |
| Heap Sort | Utiliza uma estrutura de heap para ordenar | Não | O(n log n) | [Ver Código](../3-OrdenacaoInterna/Exemplos/HeapSort/) |
| Counting Sort | Ordenação baseada em contagem, eficiente para inteiros pequenos | Sim | O(n + k) | [Ver Código](../3-OrdenacaoInterna/Exemplos/CountingSort/) |

---

## 🧩 Exercícios Propostos

| Exercício | Descrição | Dificuldade | Link |
|-----------|-----------|-------------|------|
| Exercício 1 | Implemente e analise o Bubble Sort | Fácil | [Ver Exercício](../3-OrdenacaoInterna/Exercicios/Lista1.md#exercicio-1) |
| Exercício 2 | Compare Selection Sort e Insertion Sort | Fácil | [Ver Exercício](../3-OrdenacaoInterna/Exercicios/Lista1.md#exercicio-2) |
| Exercício 3 | Aplique QuickSort em uma lista de strings | Médio | [Ver Exercício](../3-OrdenacaoInterna/Exercicios/Lista1.md#exercicio-3) |
| Exercício 4 | Analise o tempo de execução do MergeSort com vetores grandes | Médio | [Ver Exercício](../3-OrdenacaoInterna/Exercicios/Lista1.md#exercicio-4) |
| Exercício 5 | Aplique o Counting Sort para ordenar idades entre 0 e 120 | Médio | [Ver Exercício](../3-OrdenacaoInterna/Exercicios/Lista1.md#exercicio-5) |
| Exercício 6 | Estude o HeapSort e sua relação com estrutura de heap | Difícil | [Ver Exercício](../3-OrdenacaoInterna/Exercicios/Lista1.md#exercicio-6) |

---

## 🧠 Conceitos-Chave

| Conceito | Descrição |
|---------|-----------|
| **Estabilidade** | Algoritmo mantém a ordem relativa de elementos iguais |
| **Complexidade de Tempo** | Quantidade de operações em relação ao tamanho da entrada `n` |
| **In-Place** | Algoritmo que não usa espaço adicional significativo |
| **Divide and Conquer** | Técnica de dividir, resolver e combinar (ex: MergeSort, QuickSort) |
| **Particionamento** | Processo de reorganizar elementos em relação a um pivô |

---

## 📊 Comparativo de Algoritmos

| Algoritmo | Tempo Médio | Tempo Pior Caso | Espaço | Estável |
|-----------|-------------|------------------|--------|---------|
| Bubble Sort | O(n²) | O(n²) | O(1) | Sim |
| Selection Sort | O(n²) | O(n²) | O(1) | Não |
| Insertion Sort | O(n²) | O(n²) | O(1) | Sim |
| Shell Sort | O(n log² n) | Depende do gap | O(1) | Não |
| Merge Sort | O(n log n) | O(n log n) | O(n) | Sim |
| Quick Sort | O(n log n) | O(n²) | O(log n) | Não |
| Heap Sort | O(n log n) | O(n log n) | O(1) | Não |
| Counting Sort | O(n + k) | O(n + k) | O(n + k) | Sim |

---

## 📚 Recursos Adicionais

- [Visualização de algoritmos de ordenação (Sorting Visualizer)](https://visualgo.net/en/sorting)
- [Artigo sobre algoritmos de ordenação](https://www.geeksforgeeks.org/sorting-algorithms/)
- [Big-O de algoritmos de ordenação](https://www.bigocheatsheet.com/)

---

[🔙 Voltar para a página principal](../README.md)
