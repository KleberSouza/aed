# 🧱 Unidade 4: Tipos Abstratos de Dados Lineares e Flexíveis

## 📘 Introdução

Tipos Abstratos de Dados (TADs) são modelos teóricos que definem o comportamento de estruturas de dados com base em suas operações e propriedades, sem se preocupar com a implementação.

Nesta unidade, estudamos os **TADs Lineares** e **Flexíveis**, que armazenam coleções de elementos com acesso sequencial ou baseado em regras específicas.

---

## 📐 TADs Lineares

Os **TADs Lineares** são implementados usando **estruturas baseadas em vetores**, ou seja, o tamanho da coleção é definido previamente e o acesso aos elementos é feito por índice.

| Estrutura | Características | Link |
|-----------|------------------|------|
| Lista Sequencial | Elementos organizados em sequência, acesso por posição | [Ver Código](./exemplos/lista-linear/README.md) |
| Pilha Sequencial | Estrutura LIFO (último a entrar, primeiro a sair) baseada em vetor | [Ver Código](./exemplos/pilha-linear/README.md) |
| Fila Sequencial | Estrutura FIFO (primeiro a entrar, primeiro a sair) baseada em vetor | [Ver Código](./exemplos/fila-linear/README.md) |

---

## 🔗 TADs Flexíveis

Os **TADs Flexíveis** são implementados usando **estruturas encadeadas**, que alocam memória dinamicamente conforme a necessidade, permitindo o crescimento dinâmico da coleção.

| Estrutura | Características | Link |
|-----------|------------------|------|
| Fila Encadeada | Implementação dinâmica da estrutura FIFO | [Ver Código](./exemplos/fila-flexivel/README.md) |
| Pilha Encadeada | Implementação dinâmica da estrutura LIFO | [Ver Código](./exemplos/pilha-flexivel/README.md) |
| Lista Encadeada Simples | Elementos conectados por ponteiros; inserções/remoções eficientes | [Ver Código](./exemplos/lista-flexivel/README.md) |
| Lista Encadeada Dupla | Elementos conectados por ponteiros; inserções/remoções eficientes | [Ver Código](./exemplos/lista-flexivel-dupla/README.md) |

---

## 🧠 Conceitos-Chave

| Conceito | Descrição |
|---------|-----------|
| **Lista** | Coleção ordenada de elementos com acesso sequencial ou por posição |
| **LIFO** (Last-In First-Out) | Último elemento inserido é o primeiro a ser removido (Pilha) |
| **FIFO** (First-In First-Out) | Primeiro elemento inserido é o primeiro a ser removido (Fila) |
| **Encadeamento** | Ligação entre elementos por ponteiros ou referências |
| **Alocação Estática** | Espaço definido previamente, uso de vetores |
| **Alocação Dinâmica** | Espaço alocado em tempo de execução, uso de ponteiros ou referências |

---

## 🧪 Exercícios Propostos

| Exercício | Link |
|-----------|------|
|Lista Linear|[Exercícios](./exercicios/lista-linear.md)|
|Pilha Linear|[Exercícios](./exercicios/pilha-linear.md)|
|Fila Circular Linear|[Exercícios](./exercicios/fila-linear.md)|
|Fila Flexível|[Exercícios](./exercicios/fila-flexivel.md)|
|Pilha Flexível|[Exercícios](./exercicios/pilha-flexivel.md)|
|Lista Flexível|[Exercícios](./exercicios/lista-flexivel.md)|
---

## 🛠 Comparativo

| Estrutura | Tipo | Complexidade de Inserção | Complexidade de Remoção | Uso de Memória |
|-----------|------|---------------------------|---------------------------|----------------|
| Lista Sequencial | Linear | O(n) (início) - O(1) (fim) | O(n) (início) - O(1) (fim) | Estática |
| Lista Encadeada | Flexível | O(1) | O(1)  | Dinâmica |
| Pilha Sequencial | Linear | O(1) | O(1) | Estática |
| Pilha Encadeada | Flexível | O(1) | O(1) | Dinâmica |
| Fila Circular Sequencial | Linear | O(1)  | O(1) | Estática |
| Fila Encadeada | Flexível | O(1) | O(1) | Dinâmica |

---

## 📚 Recursos Adicionais

- [Visualização interativa de Pilhas, Filas e Listas](https://visualgo.net/en/list)
- [Tipos Abstratos de Dados em C#](https://learn.microsoft.com/pt-br/dotnet/standard/collections/)
- [Artigo: Estruturas de Dados Lineares vs Dinâmicas](https://www.geeksforgeeks.org/data-structures/)

---

[🔙 Voltar para a página principal](../README.md)
