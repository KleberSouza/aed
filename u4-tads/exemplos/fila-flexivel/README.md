# 📚 TAD - Fila Dinâmica usando Referência em C#

## 📝 Descrição

A **Fila Dinâmica** é uma implementação eficiente de uma estrutura de dados do tipo fila usando referências (ponteiros). Segue o princípio FIFO (First In, First Out), onde o primeiro elemento inserido é o primeiro a ser removido. A abordagem com referências permite um crescimento dinâmico da estrutura, superando as limitações de tamanho fixo encontradas em implementações baseadas em vetores.

Esta estrutura é ideal para cenários onde é necessário manter uma ordem de processamento sequencial com tamanho variável, como gerenciamento de requisições em sistemas distribuídos, processamento de eventos assíncronos, e outras situações que necessitam de processamento na ordem de chegada sem um limite predefinido.

---

## 🧠 Conceitos Envolvidos

- Armazenamento encadeado com nós referenciados
- Princípio FIFO (First In, First Out)
- Gerenciamento de referências para início e fim da fila
- Operações básicas: enfileirar (enqueue), desenfileirar (dequeue), consultar início (peek)
- Alocação dinâmica de memória
- Gerenciamento automático de memória (garbage collection)

---

## 💡 Aplicações

- Sistemas de processamento de eventos em tempo real
- Gerenciamento de requisições em aplicações web
- Implementação de algoritmos de busca em largura (BFS)
- Buffers dinâmicos em streaming de dados
- Sistemas de mensageria e filas de processamento
- Implementação de caches com capacidade flexível

---

## ⚙️ Operações Comuns

| Operação            | Descrição                                       | Complexidade |
|---------------------|------------------------------------------------|--------------|
| Enqueue (Enfileirar)| Adiciona um elemento ao final da fila          | O(1)         |
| Dequeue (Desenfileirar) | Remove o elemento do início da fila        | O(1)         |
| Peek (Primeiro)     | Consulta o primeiro elemento sem removê-lo     | O(1)         |
| IsEmpty (Vazia)     | Verifica se a fila está vazia                  | O(1)         |
| Count (Tamanho)     | Retorna o número de elementos na fila          | O(1)*        |

\* Requer manutenção de um contador durante as operações

---

## 📊 Visualização da Fila Dinâmica

### Estado Inicial (vazia)
```
Início: null
Fim: null
```

### Após enfileirar A, B, C
```
Início         Fim
  ↓             ↓
┌───┐   ┌───┐   ┌───┐
│ A │-->│ B │-->│ C │-->null
└───┘   └───┘   └───┘
```

### Após desenfileirar um elemento
```
      Início    Fim
        ↓        ↓
      ┌───┐    ┌───┐
null<-│ B │--->│ C │-->null
      └───┘    └───┘
```

### Após mais operações (enfileirar D, E)
```
      Início              Fim
        ↓                  ↓
      ┌───┐    ┌───┐    ┌───┐    ┌───┐
null<-│ B │--->│ C │--->│ D │--->│ E │-->null
      └───┘    └───┘    └───┘    └───┘
```

---

## 🔍 Complexidade

| Aspecto     | Complexidade | Descrição                                      |
|-------------|--------------|------------------------------------------------|
| Espaço      | O(n)         | Proporcional ao número de elementos na fila    |
| Enqueue     | O(1)         | Operação de tempo constante                    |
| Dequeue     | O(1)         | Operação de tempo constante                    |
| Peek        | O(1)         | Operação de tempo constante                    |

---

## 🔄 Como Funciona a Fila Dinâmica

A implementação com referências utiliza uma estrutura de nós encadeados:

1. **Nó da Fila**:
   - Contém o valor do elemento (`T valor`)
   - Referência para o próximo nó (`No<T> proximo`)

2. **Estrutura da Fila**:
   - Referência para o primeiro nó (`No<T> inicio`)
   - Referência para o último nó (`No<T> fim`)
   - Contador de elementos (opcional) (`int contador`)

3. **Operações**:
   - **Enfileirar**: Cria um novo nó no final da fila
   - **Desenfileirar**: Remove a referência ao primeiro nó
   - **Peek**: Acessa o valor do primeiro nó sem removê-lo

Esta abordagem permite que a fila cresça dinamicamente conforme necessário, limitada apenas pela memória disponível no sistema.

---

## ✅ Vantagens da Implementação Dinâmica

1. **Tamanho Flexível**: Cresce e diminui conforme necessário
2. **Sem Desperdício de Memória**: Aloca apenas o necessário para os elementos presentes
3. **Sem Limitação Predefinida**: Não requer definição prévia de capacidade máxima
4. **Simplicidade**: Não necessita de cálculos de índice ou gerenciamento circular

---

## ⚠️ Considerações

1. **Overhead de Memória**: Cada nó requer espaço adicional para armazenar a referência
2. **Garbage Collection**: Em C#, a liberação de memória é automática, mas pode causar pausas
3. **Localidade de Referência**: Elementos podem estar dispersos na memória, potencialmente afetando o desempenho de cache

---

## 🔄 Alternativas

Dependendo do caso de uso, considere:

- **Implementação Circular com Vetor**: Mais eficiente em memória quando o tamanho máximo é conhecido
- **Uso de Coleções Nativas**: `Queue<T>` do namespace `System.Collections.Generic`
- **Implementações Thread-Safe**: `ConcurrentQueue<T>` para cenários multithreading

---

## 📚 Referências

- Cormen, T. H. et al. **Algoritmos: Teoria e Prática**. 3ª edição.
- Pereira, S. L. **Estruturas de Dados em C#: Uma Abordagem Didática**.
- Documentação Microsoft: [Queue\<T\> Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1)
- Documentação Microsoft: [ConcurrentQueue\<T\> Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentqueue-1)

---
---

## ▶️ Código

📄 [`Fila Flexível`](./Program.cs)

---

[🔙 Voltar para Tipo Abstrado de Dados Lineares e Flexíveis](../../README.md)