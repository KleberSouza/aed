# 📚 TAD - Lista Encadeada Simples usando Referência em C#

## 📝 Descrição

A **Lista Encadeada Simples** é uma estrutura de dados dinâmica que consiste em uma sequência de nós, onde cada nó contém um valor e uma referência para o próximo nó da sequência. Diferente de arrays e vetores, a lista encadeada simples não requer alocação contígua de memória, permitindo crescimento dinâmico e eficiente gerenciamento de memória.

Esta estrutura é ideal para cenários onde é necessário inserções e remoções frequentes em posições arbitrárias, com tamanho variável da coleção. Diferente das pilhas e filas, a lista encadeada permite acesso a qualquer elemento, embora esse acesso seja sequencial (necessitando percorrer nós anteriores).

---

## 🧠 Conceitos Envolvidos

- Armazenamento encadeado com nós referenciados unidirecionalmente
- Acesso sequencial aos elementos
- Referência para o início da lista (cabeça/head)
- Operações básicas: inserir, remover, buscar
- Manipulação de referências (ponteiros)
- Alocação dinâmica de memória
- Gerenciamento automático de memória (garbage collection)

---

## 💡 Aplicações

- Implementação de outras estruturas de dados (pilhas, filas, listas duplamente encadeadas)
- Coleções de tamanho dinâmico
- Gerenciamento de memória em sistemas
- Algoritmos de manipulação de polinômios
- Listas de adjacência em grafos
- Implementação de hash tables com encadeamento

---

## ⚙️ Operações Comuns

| Operação           | Descrição                                      | Complexidade |
|--------------------|-----------------------------------------------|--------------|
| AddFirst           | Adiciona um elemento no início da lista       | O(1)         |
| AddLast            | Adiciona um elemento no final da lista        | O(n)*        |
| AddAfter           | Adiciona após um nó específico               | O(1)**       |
| RemoveFirst        | Remove o elemento do início da lista          | O(1)         |
| RemoveLast         | Remove o elemento do final da lista           | O(n)         |
| Remove             | Remove um elemento específico                 | O(n)         |
| Find               | Busca um elemento na lista                    | O(n)         |
| GetCount           | Retorna o número de elementos na lista        | O(1)***      |

\* O(1) se mantiver referência para o último nó  
\** Requer referência ao nó anterior  
\*** O(1) se mantiver um contador durante as operações

---

## 📊 Visualização da Lista Encadeada Simples

### Estado Inicial (vazia)
```
Head: null
```

### Após adicionar elementos A, B, C
```
   Head
    ↓
┌───┬───┐    ┌───┬───┐    ┌───┬───┐
│ A │ ●─┼───>│ B │ ●─┼───>│ C │ / │
└───┴───┘    └───┴───┘    └───┴───┘
```

### Após inserir X entre A e B
```
   Head
    ↓
┌───┬───┐    ┌───┬───┐    ┌───┬───┐    ┌───┬───┐
│ A │ ●─┼───>│ X │ ●─┼───>│ B │ ●─┼───>│ C │ / │
└───┴───┘    └───┴───┘    └───┴───┘    └───┴───┘
```

### Após remover o elemento B
```
   Head
    ↓
┌───┬───┐    ┌───┬───┐    ┌───┬───┐
│ A │ ●─┼───>│ X │ ●─┼───>│ C │ / │
└───┴───┘    └───┴───┘    └───┴───┘
```

---

## 🔍 Complexidade

| Aspecto          | Complexidade | Descrição                                      |
|------------------|--------------|------------------------------------------------|
| Espaço           | O(n)         | Proporcional ao número de elementos           |
| Acesso           | O(n)         | Necessita percorrer a lista sequencialmente    |
| Inserção início  | O(1)         | Operação de tempo constante                    |
| Inserção meio    | O(n)         | Requer localizar o ponto de inserção          |
| Inserção fim     | O(n)         | Requer percorrer toda a lista*                |
| Remoção início   | O(1)         | Operação de tempo constante                    |
| Remoção meio/fim | O(n)         | Requer localizar o elemento                   |

\* O(1) se mantiver referência para o último nó

---

## 🔄 Como Funciona a Lista Encadeada Simples

A implementação com referências utiliza uma estrutura de nós encadeados unidirecionalmente:

1. **Nó da Lista**:
   - Contém o valor do elemento (`T valor`)
   - Referência para o próximo nó (`No<T> proximo`)

2. **Estrutura da Lista**:
   - Referência para o primeiro nó (`No<T> head`)
   - Contador de elementos (opcional) (`int contador`)
   - Referência para o último nó (opcional) (`No<T> tail`)

3. **Operações Principais**:
   - **AddFirst**: Cria um novo nó e o conecta como nova cabeça da lista
   - **AddLast**: Percorre a lista até o final e conecta o novo nó
   - **AddAfter**: Insere um novo nó após um nó específico
   - **Remove**: Encontra o nó anterior ao nó a ser removido e ajusta as referências

Esta abordagem permite flexibilidade no tamanho da lista, limitada apenas pela memória disponível no sistema.

---

## ✅ Vantagens da Lista Encadeada Simples

1. **Tamanho Dinâmico**: Cresce e diminui conforme necessário
2. **Inserção Eficiente**: Inserção no início em O(1)
3. **Sem Realocação**: Não requer realocação ou movimentação de elementos
4. **Gerenciamento de Memória**: Aloca apenas o espaço necessário para os elementos

---

## ⚠️ Limitações e Considerações

1. **Acesso Sequencial**: Não permite acesso direto por índice (como em arrays)
2. **Overhead de Memória**: Cada nó requer espaço adicional para armazenar a referência
3. **Overhead de Busca**: Percorrer a lista para buscar elementos específicos
4. **Sentido Único**: Não permite navegação reversa (do final para o início)
5. **Localidade de Referência**: Elementos dispersos na memória, afetando cache

---

## 🌟 Otimizações Comuns

1. **Referência Tail**: Manter referência para o último nó (facilita operações de fim de lista)
2. **Contador de Elementos**: Manter uma contagem atualizada de elementos
3. **Nós Sentinela**: Utilizar nós especiais no início/fim para simplificar bordas
4. **Cache de Nós**: Reutilizar nós previamente alocados para reduzir alocações

---

## 🔄 Alternativas

Dependendo do caso de uso, considere:

- **Lista Duplamente Encadeada**: Quando navegação bidirecional é necessária
- **Lista Circular**: Para aplicações cíclicas
- **Uso de Coleções Nativas**: `LinkedList<T>` do namespace `System.Collections.Generic`
- **ArrayList**: Combina vantagens de arrays e listas para alguns casos de uso

---

## 📚 Referências

- Cormen, T. H. et al. **Algoritmos: Teoria e Prática**. 3ª edição.
- Pereira, S. L. **Estruturas de Dados em C#: Uma Abordagem Didática**.
- Documentação Microsoft: [LinkedList\<T\> Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1)
- Documentação Microsoft: [List\<T\> Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)

---

## ▶️ Código

📄 [`Lista Encadeada Simples`](./Program.cs)

---

[🔙 Voltar para Tipo Abstrato de Dados Lineares e Flexíveis](../../README.md)