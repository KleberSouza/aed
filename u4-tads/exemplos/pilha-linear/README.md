# 📚 TAD - Pilha Linear usando Vetores em C#

## 📝 Descrição

A **Pilha Linear** é uma estrutura de dados que segue o princípio LIFO (Last In, First Out), onde o último elemento inserido é o primeiro a ser removido. É implementada neste exemplo usando um vetor em C#, o que a torna uma implementação estática com tamanho pré-definido.

Esta estrutura é ideal para cenários onde a ordem de processamento inversa é importante, como em algoritmos de recursão, gerenciamento de chamadas de função, e verificação de expressões balanceadas.

---

## 🧠 Conceitos Envolvidos

- Armazenamento sequencial com acesso controlado (apenas pelo topo)
- Princípio LIFO (Last In, First Out)
- Controle de topo da pilha
- Operações básicas: empilhar (push), desempilhar (pop), consultar topo (peek)
- Gerenciamento de espaço e verificações de pilha cheia/vazia

---

## 💡 Aplicações

- Avaliação de expressões matemáticas
- Verificação de sintaxe (parênteses, chaves, colchetes)
- Implementação de algoritmos de backtracking
- Gerenciamento de chamadas de métodos (call stack)
- Desfazer/Refazer operações em editores

---

## ⚙️ Operações Comuns

| Operação       | Descrição                                       | Complexidade |
|----------------|------------------------------------------------|--------------|
| Push (Empilhar)| Adiciona um elemento ao topo da pilha          | O(1)         |
| Pop (Desempilhar) | Remove o elemento do topo da pilha          | O(1)         |
| Peek (Topo)    | Consulta o elemento do topo sem removê-lo      | O(1)         |
| IsEmpty (Vazia)| Verifica se a pilha está vazia                 | O(1)         |
| IsFull (Cheia) | Verifica se a pilha está cheia                 | O(1)         |

---

## 📊 Visualização da Pilha

```
      │   30   │ ◄── Topo (índice 2)
      │   20   │
      │   10   │
      └────────┘
```

Após desempilhar:

```
      │   10   │ ◄── Topo (índice 0)
      └────────┘
```

---

## 🔍 Complexidade

| Aspecto     | Complexidade | Descrição                                      |
|-------------|--------------|------------------------------------------------|
| Espaço      | O(n)         | Proporção linear ao tamanho máximo definido    |
| Push        | O(1)         | Operação de tempo constante                    |
| Pop         | O(1)         | Operação de tempo constante                    |
| Peek        | O(1)         | Operação de tempo constante                    |

---

## ⚠️ Limitações da Implementação Estática

1. **Tamanho Fixo**: Uma vez definida a capacidade, não é possível expandi-la
2. **Desperdício de Memória**: Se a pilha estiver vazia, o espaço alocado é desperdiçado
3. **Esgotamento de Capacidade**: Operações de empilhamento falham quando a capacidade é atingida

---

## 🔄 Alternativas

Para superar as limitações da implementação estática, considere:

- **Implementação Dinâmica**: Usando referências ou a classe `List<T>` do C#
- **Uso de Coleções Nativas**: `Stack<T>` do namespace `System.Collections.Generic`

---

## 📚 Referências

- Cormen, T. H. et al. **Algoritmos: Teoria e Prática**. 3ª edição.
- Pereira, S. L. **Estruturas de Dados em C#: Uma Abordagem Didática**.
- Documentação Microsoft: [Stack\<T\> Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1)

---

## ▶️ Código

📄 [`Pilha Linear`](./Program.cs)

---

[🔙 Voltar para Tipo Abstrado de Dados Lineares e Flexíveis](../../README.md)