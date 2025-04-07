# 📚 TAD - Pilha Dinâmica usando Referência em C#

## 📝 Descrição

A **Pilha Dinâmica** é uma implementação eficiente de uma estrutura de dados do tipo pilha usando referências (ponteiros). Segue o princípio LIFO (Last In, First Out), onde o último elemento inserido é o primeiro a ser removido. A abordagem com referências permite um crescimento dinâmico da estrutura, superando as limitações de tamanho fixo encontradas em implementações baseadas em vetores.

Esta estrutura é ideal para cenários onde é necessário manter um controle de sequência invertida, como gerenciamento de chamadas de funções, avaliação de expressões, algoritmos de backtracking e outras situações que necessitam de processamento na ordem inversa da inserção, sem um limite predefinido.

---

## 🧠 Conceitos Envolvidos

- Armazenamento encadeado com nós referenciados
- Princípio LIFO (Last In, First Out)
- Gerenciamento de referência para o topo da pilha
- Operações básicas: empilhar (push), desempilhar (pop), consultar topo (peek)
- Alocação dinâmica de memória
- Gerenciamento automático de memória (garbage collection)

---

## 💡 Aplicações

- Gerenciamento de chamadas de funções e procedimentos
- Avaliação de expressões matemáticas (notação polonesa)
- Verificação de sintaxe em compiladores
- Algoritmos de backtracking e recursão
- Navegação em histórico (undo/redo)
- Simulação de processos em ordem inversa

---

## ⚙️ Operações Comuns

| Operação           | Descrição                                      | Complexidade |
|--------------------|-----------------------------------------------|--------------|
| Push (Empilhar)    | Adiciona um elemento ao topo da pilha         | O(1)         |
| Pop (Desempilhar)  | Remove o elemento do topo da pilha            | O(1)         |
| Peek (Topo)        | Consulta o elemento do topo sem removê-lo     | O(1)         |
| IsEmpty (Vazia)    | Verifica se a pilha está vazia                | O(1)         |
| Count (Tamanho)    | Retorna o número de elementos na pilha        | O(1)*        |

\* Requer manutenção de um contador durante as operações

---

## 📊 Visualização da Pilha Dinâmica

### Estado Inicial (vazia)
```
Topo: null
```

### Após empilhar A, B, C
```
   Topo
    ↓
┌───┐
│ C │
└───┘
  ↓
┌───┐
│ B │
└───┘
  ↓
┌───┐
│ A │
└───┘
  ↓
 null
```

### Após desempilhar um elemento
```
   Topo
    ↓
┌───┐
│ B │
└───┘
  ↓
┌───┐
│ A │
└───┘
  ↓
 null
```

### Após mais operações (empilhar D, E)
```
   Topo
    ↓
┌───┐
│ E │
└───┘
  ↓
┌───┐
│ D │
└───┘
  ↓
┌───┐
│ B │
└───┘
  ↓
┌───┐
│ A │
└───┘
  ↓
 null
```

---

## 🔍 Complexidade

| Aspecto     | Complexidade | Descrição                                      |
|-------------|--------------|------------------------------------------------|
| Espaço      | O(n)         | Proporcional ao número de elementos na pilha   |
| Push        | O(1)         | Operação de tempo constante                    |
| Pop         | O(1)         | Operação de tempo constante                    |
| Peek        | O(1)         | Operação de tempo constante                    |

---

## 🔄 Como Funciona a Pilha Dinâmica

A implementação com referências utiliza uma estrutura de nós encadeados:

1. **Nó da Pilha**:
   - Contém o valor do elemento (`T valor`)
   - Referência para o nó abaixo (`No<T> abaixo`)

2. **Estrutura da Pilha**:
   - Referência para o nó do topo (`No<T> topo`)
   - Contador de elementos (opcional) (`int contador`)

3. **Operações**:
   - **Push**: Cria um novo nó e o coloca no topo
   - **Pop**: Remove a referência ao nó do topo
   - **Peek**: Acessa o valor do nó do topo sem removê-lo

Esta abordagem permite que a pilha cresça dinamicamente conforme necessário, limitada apenas pela memória disponível no sistema.

---

## ✅ Vantagens da Implementação Dinâmica

1. **Tamanho Flexível**: Cresce e diminui conforme necessário
2. **Sem Desperdício de Memória**: Aloca apenas o necessário para os elementos presentes
3. **Sem Limitação Predefinida**: Não requer definição prévia de capacidade máxima
4. **Simplicidade de Gerenciamento**: Não necessita de verificações de overflow ou realocações

---

## ⚠️ Considerações

1. **Overhead de Memória**: Cada nó requer espaço adicional para armazenar a referência
2. **Garbage Collection**: Em C#, a liberação de memória é automática, mas pode causar pausas
3. **Localidade de Referência**: Elementos podem estar dispersos na memória, potencialmente afetando o desempenho de cache

---

## 🔄 Alternativas

Dependendo do caso de uso, considere:

- **Implementação com Vetor**: Mais eficiente em memória quando o tamanho máximo é conhecido
- **Uso de Coleções Nativas**: `Stack<T>` do namespace `System.Collections.Generic`
- **Implementações Thread-Safe**: `ConcurrentStack<T>` para cenários multithreading
- **Pilha com Capacidade Inicial**: Utilizando uma abordagem híbrida com vetor inicial e expansão dinâmica

---

## 📚 Referências

- Cormen, T. H. et al. **Algoritmos: Teoria e Prática**. 3ª edição.
- Pereira, S. L. **Estruturas de Dados em C#: Uma Abordagem Didática**.
- Documentação Microsoft: [Stack\<T\> Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.stack-1)
- Documentação Microsoft: [ConcurrentStack\<T\> Class](https://docs.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentstack-1)

---

## ▶️ Código

📄 [`Pilha Dinâmica`](./Program.cs)

---

[🔙 Voltar para Tipo Abstrado de Dados Lineares e Flexíveis](../../README.md)