# 📚 TAD - Lista Encadeada Dupla usando Referência em C#

## 📝 Descrição

A **Lista Encadeada Dupla** é uma estrutura de dados dinâmica que consiste em uma sequência de nós, onde cada nó contém um valor e duas referências: uma para o próximo nó e outra para o nó anterior. Esta característica bidirepcional permite navegação eficiente em ambas as direções (do início para o fim e do fim para o início), superando a limitação unidirecional das listas encadeadas simples.

Esta estrutura é ideal para cenários onde é necessário navegar em ambos os sentidos, realizar inserções e remoções frequentes em posições arbitrárias, e manter uma coleção de tamanho variável com acesso eficiente tanto ao início quanto ao final da lista.

---

## 🧠 Conceitos Envolvidos

- Armazenamento encadeado com nós referenciados bidirecionalmente
- Acesso sequencial nos dois sentidos
- Referência para o início (cabeça/head) e fim (cauda/tail) da lista
- Operações básicas: inserir, remover, buscar em ambas as direções
- Manipulação de referências duplas (ponteiros)
- Alocação dinâmica de memória
- Gerenciamento automático de memória (garbage collection)

---

## 💡 Aplicações

- Histórico de navegação (avanço e retrocesso)
- Editores de texto (movimentação do cursor em ambas direções)
- Implementação de caches LRU (Least Recently Used)
- Sistemas de desfazer/refazer (undo/redo)
- Implementação de algoritmos de ordenação adaptáveis
- Estruturas de dados mais complexas como árvores B e derivadas
- Gerenciamento de memória avançado

---

## ⚙️ Operações Comuns

| Operação           | Descrição                                      | Complexidade |
|--------------------|-----------------------------------------------|--------------|
| AddFirst           | Adiciona um elemento no início da lista       | O(1)         |
| AddLast            | Adiciona um elemento no final da lista        | O(1)         |
| AddBefore          | Adiciona antes de um nó específico           | O(1)*        |
| AddAfter           | Adiciona após um nó específico               | O(1)*        |
| RemoveFirst        | Remove o elemento do início da lista          | O(1)         |
| RemoveLast         | Remove o elemento do final da lista           | O(1)         |
| Remove             | Remove um nó específico                       | O(1)*        |
| Find               | Busca um elemento na lista a partir do início | O(n)         |
| FindLast           | Busca um elemento na lista a partir do fim    | O(n)         |
| GetCount           | Retorna o número de elementos na lista        | O(1)**       |

\* Requer referência ao nó específico  
\** Requer manutenção de um contador durante as operações

---

## 📊 Visualização da Lista Encadeada Dupla

### Estado Inicial (vazia)
```
Head: null
Tail: null
```

### Após adicionar elementos A, B, C
```
   Head                                 Tail
    ↓                                    ↓
┌───┬───┬───┐    ┌───┬───┬───┐    ┌───┬───┬───┐
│ / │ A │ ●─┼───>│ ●─┼ B │ ●─┼───>│ ●─┼ C │ / │
└───┴───┴───┘    └───┴───┴───┘    └───┴───┴───┘
          <───────┘    <───────┘
```

### Após inserir X entre A e B
```
   Head                                                  Tail
    ↓                                                     ↓
┌───┬───┬───┐    ┌───┬───┬───┐    ┌───┬───┬───┐    ┌───┬───┬───┐
│ / │ A │ ●─┼───>│ ●─┼ X │ ●─┼───>│ ●─┼ B │ ●─┼───>│ ●─┼ C │ / │
└───┴───┴───┘    └───┴───┴───┘    └───┴───┴───┘    └───┴───┴───┘
          <───────┘    <───────┘    <───────┘
```

### Após remover o elemento B
```
   Head                                 Tail
    ↓                                    ↓
┌───┬───┬───┐    ┌───┬───┬───┐    ┌───┬───┬───┐
│ / │ A │ ●─┼───>│ ●─┼ X │ ●─┼───>│ ●─┼ C │ / │
└───┴───┴───┘    └───┴───┴───┘    └───┴───┴───┘
          <───────┘    <───────┘
```

---

## 🔍 Complexidade

| Aspecto          | Complexidade | Descrição                                      |
|------------------|--------------|------------------------------------------------|
| Espaço           | O(n)         | Proporcional ao número de elementos           |
| Acesso           | O(n)         | Acesso sequencial a partir de qualquer extremidade |
| Inserção início  | O(1)         | Operação de tempo constante                    |
| Inserção fim     | O(1)         | Operação de tempo constante                    |
| Inserção meio    | O(n)         | Requer localizar o ponto de inserção          |
| Remoção início   | O(1)         | Operação de tempo constante                    |
| Remoção fim      | O(1)         | Operação de tempo constante                    |
| Remoção meio     | O(n)         | Requer localizar o elemento                   |

---

## 🔄 Como Funciona a Lista Encadeada Dupla

A implementação com referências bidirecionais utiliza a seguinte estrutura:

1. **Nó da Lista**:
   - Contém o valor do elemento (`T valor`)
   - Referência para o próximo nó (`No<T> proximo`)
   - Referência para o nó anterior (`No<T> anterior`)

2. **Estrutura da Lista**:
   - Referência para o primeiro nó (`No<T> head`)
   - Referência para o último nó (`No<T> tail`)
   - Contador de elementos (opcional) (`int contador`)

3. **Operações Principais**:
   - **AddFirst**: Cria um novo nó com referência anterior null e conecta como nova cabeça
   - **AddLast**: Cria um novo nó com referência próxima null e conecta como nova cauda
   - **AddBefore/After**: Insere um novo nó antes/depois de um nó específico, ajustando as referências duplas
   - **Remove**: Ajusta as referências nos nós adjacentes para "pular" o nó removido

Esta implementação bidirepcional permite operações eficientes em ambas as extremidades da lista.

---

## ✅ Vantagens da Lista Encadeada Dupla

1. **Navegação Bidirecional**: Percurso eficiente em ambas direções
2. **Operações nas Extremidades**: Inserção e remoção O(1) em ambas as pontas
3. **Remoção Eficiente**: Remoção O(1) dado o nó a remover
4. **Inserção Contextual**: Inserção O(1) antes ou depois de um nó conhecido
5. **Flexibilidade**: Facilidade para implementar algoritmos que necessitam acesso bidirecional

---

## ⚠️ Limitações e Considerações

1. **Overhead de Memória**: Cada nó requer espaço para duas referências
2. **Complexidade de Implementação**: Maior complexidade para manter referências duplas consistentes
3. **Acesso Sequencial**: Não permite acesso direto por índice (como em arrays)
4. **Consumo de Memória**: Maior uso de memória comparado à lista encadeada simples
5. **Localidade de Referência**: Elementos dispersos na memória, afetando cache

---

## 🌟 Otimizações Comuns

1. **Nós Sentinela**: Utilizar nós especiais no início/fim para simplificar operações de borda
2. **Lista Circular**: Conectar o último nó ao primeiro e vice-versa para aplicações cíclicas
3. **Ponteiros de Acesso**: Manter referências temporárias para posições frequentemente acessadas
4. **Cache de Nós**: Reutilizar nós previamente alocados para reduzir alocações

---

## 🔄 Alternativas

Dependendo do caso de uso, considere:

- **Lista Encadeada Simples**: Quando a navegação é predominantemente unidirecional
- **Lista Circular**: Para aplicações cíclicas onde o final conecta ao início
- **Uso de Coleções Nativas**: `LinkedList<T>` do namespace `System.Collections.Generic`
- **Deque**: Quando o foco principal são operações nas extremidades
- **Skip List**: Para busca mais eficiente em listas ordenadas

---

## 📚 Referências

- Cormen, T. H. et al. **Algoritmos: Teoria e Prática**. 3ª edição.
- Pereira, S. L. **Estruturas de Dados em C#: Uma Abordagem Didática**.
- Documentação Microsoft: [LinkedList\<T\> Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlist-1)
- Documentação Microsoft: [LinkedListNode\<T\> Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.linkedlistnode-1)

---

## ▶️ Código

📄 [`Lista Encadeada Dupla`](./Program.cs)

---

[🔙 Voltar para Tipo Abstrato de Dados Lineares e Flexíveis](../../README.md)