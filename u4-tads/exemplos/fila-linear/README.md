# 📚 TAD - Fila Linear usando Vetores (Implementação Circular) em C#

## 📝 Descrição

A **Fila Circular** é uma implementação eficiente de uma estrutura de dados do tipo fila usando um vetor estático. Segue o princípio FIFO (First In, First Out), onde o primeiro elemento inserido é o primeiro a ser removido. A abordagem circular permite um melhor aproveitamento do espaço, reutilizando posições liberadas após operações de remoção.

Esta estrutura é ideal para cenários onde é necessário manter uma ordem de processamento sequencial, como gerenciamento de processos, impressões, requisições e outras situações que necessitam de processamento na ordem de chegada.

---

## 🧠 Conceitos Envolvidos

- Armazenamento sequencial com acesso controlado (apenas nas extremidades)
- Princípio FIFO (First In, First Out)
- Controle de início e fim da fila
- Operações básicas: enfileirar (enqueue), desenfileirar (dequeue), consultar início (peek)
- Gerenciamento de espaço com abordagem circular
- Manipulação de índices com aritmética modular

---

## 💡 Aplicações

- Agendamento de tarefas e processos
- Gerenciamento de filas de impressão
- Buffers de dados em comunicação
- Implementação de algoritmos de busca em largura (BFS)
- Sistemas de atendimento e escalonamento
- Cache de dados com política FIFO

---

## ⚙️ Operações Comuns

| Operação            | Descrição                                       | Complexidade |
|---------------------|------------------------------------------------|--------------|
| Enqueue (Enfileirar)| Adiciona um elemento ao final da fila          | O(1)         |
| Dequeue (Desenfileirar) | Remove o elemento do início da fila        | O(1)         |
| Peek (Primeiro)     | Consulta o primeiro elemento sem removê-lo     | O(1)         |
| IsEmpty (Vazia)     | Verifica se a fila está vazia                  | O(1)         |
| IsFull (Cheia)      | Verifica se a fila está cheia                  | O(1)         |

---

## 📊 Visualização da Fila Circular

### Estado Inicial (vazia)
```
      ┌───┬───┬───┬───┬───┐
      │   │   │   │   │   │
      └───┴───┴───┴───┴───┘
        ↑
    início/fim (-1)
```

### Após enfileirar A, B, C
```
      ┌───┬───┬───┬───┬───┐
      │ A │ B │ C │   │   │
      └───┴───┴───┴───┴───┘
        ↑       ↑
     início    fim
       (0)     (2)
```

### Após desenfileirar um elemento
```
      ┌───┬───┬───┬───┬───┐
      │   │ B │ C │   │   │
      └───┴───┴───┴───┴───┘
            ↑   ↑
         início fim
           (1)  (2)
```

### Estado circular (após várias operações)
```
      ┌───┬───┬───┬───┬───┐
      │ F │   │   │ D │ E │
      └───┴───┴───┴───┴───┘
        ↑           ↑
       fim        início
       (0)         (3)
```

---

## 🔍 Complexidade

| Aspecto     | Complexidade | Descrição                                      |
|-------------|--------------|------------------------------------------------|
| Espaço      | O(n)         | Proporção linear ao tamanho máximo definido    |
| Enqueue     | O(1)         | Operação de tempo constante                    |
| Dequeue     | O(1)         | Operação de tempo constante                    |
| Peek        | O(1)         | Operação de tempo constante                    |

---

## 🔄 Como Funciona a Fila Circular

A implementação circular utiliza aritmética modular para gerenciar os índices de início e fim da fila:

1. **Inicialização**: 
   - `inicio = -1` e `fim = -1` (fila vazia)

2. **Enfileirar**:
   - Se for o primeiro elemento: `inicio = 0` e `fim = 0`
   - Caso contrário: `fim = (fim + 1) % capacidade`

3. **Desenfileirar**:
   - Se restar apenas um elemento: `inicio = -1` e `fim = -1` (fila vazia novamente)
   - Caso contrário: `inicio = (inicio + 1) % capacidade`

4. **Verificação de Fila Cheia**:
   - A fila está cheia quando `(fim + 1) % capacidade == inicio`

Esta abordagem permite reutilizar posições vazias ao início do vetor, evitando o problema de "falsa fila cheia" que ocorreria em uma implementação linear simples.

---

## ⚠️ Limitações da Implementação Circular

1. **Tamanho Fixo**: Uma vez definida a capacidade, não é possível expandi-la
2. **Capacidade Efetiva**: Uma posição é sempre deixada vazia para distinguir entre fila cheia e fila vazia
3. **Complexidade de Implementação**: Ligeiramente mais complexa que a implementação linear

---

## 🔄 Alternativas

Para superar as limitações da implementação circular estática, considere:

- **Implementação Dinâmica**: Usando referências ou a classe `List<T>` do C#
- **Uso de Coleções Nativas**: `Queue<T>` do namespace `System.Collections.Generic`
- **Implementação com Lista Encadeada**: Elimina a necessidade de tamanho fixo

---

## 📚 Referências

- Cormen, T. H. et al. **Algoritmos: Teoria e Prática**. 3ª edição.
- Pereira, S. L. **Estruturas de Dados em C#: Uma Abordagem Didática**.
- Documentação Microsoft: [Queue\<T\> Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1)

---

## ▶️ Código

📄 [`Fila Linear`](./Program.cs)

---

[🔙 Voltar para Tipo Abstrado de Dados Lineares e Flexíveis](../../README.md)