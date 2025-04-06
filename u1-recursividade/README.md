# 📘 Unidade 1: Algoritmos Recursivos

## 🧠 Introdução

A **recursão** é uma técnica poderosa onde uma função resolve um problema chamando a si mesma com uma versão reduzida do problema original. É especialmente útil quando o problema tem uma estrutura naturalmente **divisível**, como árvores, listas ou sequências.

### 🔁 Dois componentes fundamentais definem a recursão:

1. **Caso Base**: é a condição de parada da função, que impede chamadas infinitas.
2. **Caso Recursivo**: é onde a função chama a si mesma para resolver um problema menor.

### 📌 Quando usar recursão?

- Estruturas hierárquicas: como **árvores**, **pastas**, **grafos**
- Algoritmos de **divisão e conquista**: como **Merge Sort** e **Quick Sort**
- Problemas matemáticos clássicos: **fatorial**, **sequência de Fibonacci**
- Exploração de possibilidades: **backtracking**, **permutações**, **torres de Hanói**

---

## 🧪 Exemplos de Implementação em C#

A seguir, alguns algoritmos recursivos clássicos implementados em C#:

| ✅ Algoritmo | 📄 Descrição | 🔗 Link |
|-------------|-------------|--------|
| **Fatorial** | Calcula o fatorial de um número n (n!) | [Ver Código](../1-AlgoritmosRecursivos/Exemplos/Fatorial/) |
| **Fibonacci** | Gera a sequência de Fibonacci até o n-ésimo termo | [Ver Código](../1-AlgoritmosRecursivos/Exemplos/Fibonacci/) |
| **Torres de Hanói** | Resolve o problema das torres com n discos | [Ver Código](../1-AlgoritmosRecursivos/Exemplos/TorresHanoi/) |
| **Busca Binária Recursiva** | Versão recursiva do algoritmo de busca binária | [Ver Código](../1-AlgoritmosRecursivos/Exemplos/BuscaBinariaRecursiva/) |

---

## 🧩 Exercícios Propostos

Coloque em prática os conceitos com os exercícios abaixo:

| 💡 Exercício | 📝 Descrição | 🎯 Dificuldade | 🔗 Link |
|-------------|-------------|---------------|--------|
| 1 | Soma dos n primeiros números naturais | Fácil | [Ver Exercício](../1-AlgoritmosRecursivos/Exercicios/Lista1.md#exercicio-1) |
| 2 | Potência de um número (x^n) recursivamente | Fácil | [Ver Exercício](../1-AlgoritmosRecursivos/Exercicios/Lista1.md#exercicio-2) |
| 3 | Verificar se uma string é um palíndromo | Médio | [Ver Exercício](../1-AlgoritmosRecursivos/Exercicios/Lista1.md#exercicio-3) |
| 4 | Calcular o MDC com o algoritmo de Euclides | Médio | [Ver Exercício](../1-AlgoritmosRecursivos/Exercicios/Lista1.md#exercicio-4) |
| 5 | Gerar todas as permutações de uma string | Difícil | [Ver Exercício](../1-AlgoritmosRecursivos/Exercicios/Lista2.md#exercicio-1) |
| 6 | Caminho do cavalo no xadrez (backtracking) | Difícil | [Ver Exercício](../1-AlgoritmosRecursivos/Exercicios/Lista2.md#exercicio-2) |

---

## 🧠 Conceitos-Chave Detalhados

| Conceito | Explicação |
|---------|-----------|
| **Pilha de Execução** | Cada chamada recursiva é empilhada na memória; por isso, recursão consome mais memória que a iteração em muitos casos. |
| **Recursão vs Iteração** | Recursão é mais legível e elegante em muitos casos, mas pode ser menos eficiente em termos de tempo e espaço. |
| **Recursão de Cauda** (*Tail Recursion*) | Quando a chamada recursiva é a última operação. Pode ser otimizada pelo compilador, reduzindo o uso da pilha. |
| **Memoização** | Técnica que armazena os resultados de chamadas anteriores para evitar recomputações desnecessárias. Muito útil em problemas como Fibonacci. |

---

## 📊 Análise de Complexidade

| Algoritmo | ⏱️ Tempo | 🧠 Espaço | 💬 Observações |
|-----------|---------|----------|----------------|
| **Fatorial** | O(n) | O(n) | Uma chamada para cada número até 1 |
| **Fibonacci (ingênuo)** | O(2^n) | O(n) | Exponencial — extremamente ineficiente |
| **Fibonacci (memoizado)** | O(n) | O(n) | Cada valor é calculado apenas uma vez |
| **Torres de Hanói** | O(2^n) | O(n) | Crescimento exponencial com o número de discos |
| **Busca Binária** | O(log n) | O(log n) | Boa performance para grandes volumes de dados ordenados |

---

## 📚 Recursos Adicionais

- 🎲 [Visualização Interativa da Recursão](https://visualgo.net/en/recursion)
- 📘 [Documentação Oficial - Recursão em C#](https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/concepts/recursion)
- 📖 [Artigo: Entendendo Recursão - GeeksForGeeks](https://www.geeksforgeeks.org/recursion/)
- 🎥 [Vídeo: Recursão Explicada com Animações](https://www.youtube.com/watch?v=KEEKn7Me-ms)

---

📎 [⬅ Voltar para a Página Principal](../README.md)
