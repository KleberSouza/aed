# 🧱 Unidade 4: Tipos Abstratos de Dados Lineares e Flexíveis

<img src="../.github/assets/data-structures.png" alt="Tipos Abstratos de Dados" width="200" align="right"/>

## 📘 Introdução

Tipos Abstratos de Dados (TADs) são modelos teóricos que definem o comportamento de estruturas de dados com base em suas operações e propriedades, sem se preocupar com a implementação.

Nesta unidade, estudamos os **TADs Lineares** e **Flexíveis**, que armazenam coleções de elementos com acesso sequencial ou baseado em regras específicas.

---

## 📐 TADs Lineares

Os **TADs Lineares** são implementados usando **estruturas baseadas em vetores**, ou seja, o tamanho da coleção é definido previamente e o acesso aos elementos é feito por índice.

| Estrutura | Características | Link |
|-----------|------------------|------|
| Lista Sequencial | Elementos organizados em sequência, acesso por posição | [Ver Código](../4-TiposDeDados/Lineares/ListaSequencial/) |
| Pilha Sequencial | Estrutura LIFO (último a entrar, primeiro a sair) baseada em vetor | [Ver Código](../4-TiposDeDados/Lineares/PilhaSequencial/) |
| Fila Sequencial | Estrutura FIFO (primeiro a entrar, primeiro a sair) baseada em vetor | [Ver Código](../4-TiposDeDados/Lineares/FilaSequencial/) |

---

## 🔗 TADs Flexíveis

Os **TADs Flexíveis** são implementados usando **estruturas encadeadas**, que alocam memória dinamicamente conforme a necessidade, permitindo o crescimento dinâmico da coleção.

| Estrutura | Características | Link |
|-----------|------------------|------|
| Lista Encadeada | Elementos conectados por ponteiros; inserções/remoções eficientes | [Ver Código](../4-TiposDeDados/Flexiveis/ListaEncadeada/) |
| Pilha Encadeada | Implementação dinâmica da estrutura LIFO | [Ver Código](../4-TiposDeDados/Flexiveis/PilhaEncadeada/) |
| Fila Encadeada | Implementação dinâmica da estrutura FIFO | [Ver Código](../4-TiposDeDados/Flexiveis/FilaEncadeada/) |

---

## 🧠 Conceitos-Chave

| Conceito | Descrição |
|---------|-----------|
| **LIFO** (Last-In First-Out) | Último elemento inserido é o primeiro a ser removido (Pilha) |
| **FIFO** (First-In First-Out) | Primeiro elemento inserido é o primeiro a ser removido (Fila) |
| **Lista** | Coleção ordenada de elementos com acesso sequencial ou por posição |
| **Encadeamento** | Ligação entre elementos por ponteiros ou referências |
| **Alocação Estática** | Espaço definido previamente, uso de vetores |
| **Alocação Dinâmica** | Espaço alocado em tempo de execução, uso de ponteiros |

---

## 🧪 Exercícios Propostos

| Exercício | Descrição | Dificuldade | Link |
|-----------|-----------|-------------|------|
| Exercício 1 | Implemente uma lista sequencial com inserção e remoção | Fácil | [Ver Exercício](../4-TiposDeDados/Exercicios/Lista1.md#exercicio-1) |
| Exercício 2 | Desenvolva uma pilha sequencial com operações push e pop | Fácil | [Ver Exercício](../4-TiposDeDados/Exercicios/Lista1.md#exercicio-2) |
| Exercício 3 | Implemente uma fila circular sequencial | Médio | [Ver Exercício](../4-TiposDeDados/Exercicios/Lista1.md#exercicio-3) |
| Exercício 4 | Implemente uma lista encadeada simples | Médio | [Ver Exercício](../4-TiposDeDados/Exercicios/Lista2.md#exercicio-1) |
| Exercício 5 | Implemente uma pilha encadeada com tratamento de erro de pilha vazia | Médio | [Ver Exercício](../4-TiposDeDados/Exercicios/Lista2.md#exercicio-2) |
| Exercício 6 | Implemente uma fila encadeada com operações de inserção e remoção | Médio | [Ver Exercício](../4-TiposDeDados/Exercicios/Lista2.md#exercicio-3) |

---

## 🛠 Comparativo

| Estrutura | Tipo | Complexidade de Inserção | Complexidade de Remoção | Uso de Memória |
|-----------|------|---------------------------|---------------------------|----------------|
| Lista Sequencial | Linear | O(n) | O(n) | Estática |
| Lista Encadeada | Flexível | O(1) (início) | O(1) (início) | Dinâmica |
| Pilha Sequencial | Linear | O(1) | O(1) | Estática |
| Pilha Encadeada | Flexível | O(1) | O(1) | Dinâmica |
| Fila Sequencial | Linear | O(1) (fila circular) | O(1) | Estática |
| Fila Encadeada | Flexível | O(1) | O(1) | Dinâmica |

---

## 📚 Recursos Adicionais

- [Visualização interativa de Pilhas, Filas e Listas](https://visualgo.net/en/list)
- [Tipos Abstratos de Dados em C#](https://learn.microsoft.com/pt-br/dotnet/standard/collections/)
- [Artigo: Estruturas de Dados Lineares vs Dinâmicas](https://www.geeksforgeeks.org/data-structures/)
- [Vídeo: Pilhas, Filas e Listas Encadeadas](https://www.youtube.com/watch?v=09_LlHjoEiY)

---

[🔙 Voltar para a página principal](../README.md)
