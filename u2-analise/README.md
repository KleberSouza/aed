# 📘 Unidade 2: Fundamentos de Análise de Algoritmos

<img src="../.github/assets/complexidade.png" alt="Análise de Algoritmos" width="200" align="right"/>

## 🧠 Introdução

A **análise de algoritmos** é o estudo do desempenho de algoritmos com base em fatores como **tempo de execução** e **uso de memória**. Nessa unidade, o foco está na **análise de algoritmos iterativos**, isto é, algoritmos que usam laços de repetição (como `for` e `while`) para resolver problemas.

Entender como um algoritmo cresce com a entrada é essencial para fazer boas escolhas de implementação.

---

## 🔢 Função de Custo

A **função de custo** representa a quantidade de operações realizadas por um algoritmo com base no tamanho da entrada `n`.

Para isso, você deve contar:
- Inicializações
- Comparações e atualizações em laços
- Atribuições
- Chamadas de função

👉 [Ver exemplo de análise de custo](../2-AnaliseAlgoritmos/Exemplos/AnaliseSomaVetor/)

---

## 🧭 Notações Assintóticas

As **notações assintóticas** descrevem como a função de custo de um algoritmo se comporta quando a entrada cresce indefinidamente.

| Notação | Nome | Interpretação |
|--------|------|----------------|
| **O(f(n))** | Big-O | Limite superior – descreve o **pior caso** |
| **Ω(f(n))** | Ômega | Limite inferior – descreve o **melhor caso** |
| **Θ(f(n))** | Teta | Limite justo – descreve o **comportamento exato** |

👉 [Ver guia de notações](../2-AnaliseAlgoritmos/Teoria/NotacoesAssintoticas.md)

---

## ✅ Exemplos de Algoritmos Iterativos

| Algoritmo | Descrição | Link |
|-----------|-----------|------|
| Busca Linear | Percorre um vetor buscando um valor | [Ver Código](../2-AnaliseAlgoritmos/Exemplos/BuscaLinear/) |
| Soma de Vetor | Soma todos os elementos de um vetor | [Ver Código](../2-AnaliseAlgoritmos/Exemplos/SomaVetor/) |
| Contagem de Pares | Conta quantos números pares há em um vetor | [Ver Código](../2-AnaliseAlgoritmos/Exemplos/ContagemPares/) |
| Matriz Identidade | Verifica se uma matriz é identidade | [Ver Código](../2-AnaliseAlgoritmos/Exemplos/MatrizIdentidade/) |

---

## 🧩 Exercícios Propostos

| Exercício | Descrição | Dificuldade | Link |
|-----------|-----------|-------------|------|
| Exercício 1 | Calcule a função de custo de um algoritmo de soma | Fácil | [Ver Exercício](../2-AnaliseAlgoritmos/Exercicios/Lista1.md#exercicio-1) |
| Exercício 2 | Analise o pior e melhor caso de uma busca linear | Fácil | [Ver Exercício](../2-AnaliseAlgoritmos/Exercicios/Lista1.md#exercicio-2) |
| Exercício 3 | Calcule a complexidade de um algoritmo com dois laços | Médio | [Ver Exercício](../2-AnaliseAlgoritmos/Exercicios/Lista1.md#exercicio-3) |
| Exercício 4 | Analise o tempo de execução de uma ordenação por seleção | Médio | [Ver Exercício](../2-AnaliseAlgoritmos/Exercicios/Lista1.md#exercicio-4) |

---

## 💡 Conceitos-Chave

| Conceito | Explicação |
|---------|------------|
| **Função de Custo** | Expressa a quantidade de operações realizadas conforme o tamanho da entrada |
| **Notação Big-O** | Indica o crescimento no pior cenário |
| **Notação Ômega (Ω)** | Indica o melhor cenário |
| **Notação Teta (Θ)** | Indica o crescimento real do algoritmo |
| **Eficiência Assintótica** | Comparação de algoritmos baseada em seu comportamento com entradas grandes |

---

## 📊 Tabela Comparativa de Complexidade

| Algoritmo | Tempo | Espaço | Observações |
|-----------|-------|--------|-------------|
| Busca Linear | O(n) | O(1) | Escaneia todos os elementos |
| Soma de Vetor | O(n) | O(1) | Uma operação por elemento |
| Contagem de Pares | O(n) | O(1) | Simples verificação por elemento |
| Análise de Matriz Identidade | O(n²) | O(1) | Verifica todos os elementos da matriz |

---

## 📚 Recursos Adicionais

- [Análise de algoritmos - GeeksforGeeks](https://www.geeksforgeeks.org/analysis-of-algorithms/)
- [Notação Big-O visualizada (em inglês)](https://www.bigocheatsheet.com/)
- [Vídeo: Complexidade de algoritmos explicada](https://www.youtube.com/watch?v=Mo4vesaut8g)
- [Documentação Microsoft sobre complexidade](https://learn.microsoft.com/pt-br/dotnet/standard/collections/complexity)

---

[🔙 Voltar para a página principal](../README.md)
