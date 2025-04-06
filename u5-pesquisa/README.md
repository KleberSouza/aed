# 🧭 Unidade 5: Pesquisa em Memória Principal

<img src="../.github/assets/searching.png" alt="Pesquisa em Estruturas" width="220" align="right"/>

## 📘 Introdução

A **pesquisa em memória principal** envolve a busca de elementos dentro de estruturas de dados que estão diretamente carregadas na RAM. A eficiência da pesquisa depende da organização dos dados, e nesta unidade exploramos as principais estruturas que otimizam essa tarefa.

Algumas estruturas comuns para pesquisa eficiente incluem:
- Árvores Binárias de Busca (BST)
- Árvores AVL (balanceadas)
- Tabelas Hash
- Dicionários

Essas estruturas oferecem diferentes **tempos de busca**, inserção e remoção, variando entre desempenho linear, logarítmico ou constante.

---

## 🌳 Estruturas de Pesquisa

| Estrutura | Descrição | Link |
|----------|------------|------|
| Árvore Binária de Busca (BST) | Estrutura hierárquica onde os elementos menores ficam à esquerda e os maiores à direita | [Ver Código](../5-Pesquisa/ArvoreBinaria/) |
| Árvore AVL | Variante balanceada da BST, garante altura logarítmica com rotações automáticas | [Ver Código](../5-Pesquisa/ArvoreAVL/) |
| Tabela Hash | Usa uma função de dispersão (hash) para mapear chaves a índices em uma tabela | [Ver Código](../5-Pesquisa/TabelaHash/) |
| Dicionário | Estrutura que armazena pares chave/valor com operações otimizadas de busca | [Ver Código](../5-Pesquisa/Dicionario/) |

---

## 🧠 Conceitos-Chave

| Conceito | Descrição |
|---------|-----------|
| **BST (Binary Search Tree)** | Estrutura de árvore binária com propriedade de ordenação que permite busca eficiente |
| **AVL Tree** | BST auto-balanceada que garante operações em tempo logarítmico |
| **Hashing** | Técnica que transforma uma chave em um índice de array |
| **Função de Hash** | Função que gera um índice a partir de uma chave para uso em tabela hash |
| **Colisão** | Quando duas chaves diferentes geram o mesmo índice em uma tabela hash |
| **Encadeamento Separado / Endereçamento Aberto** | Estratégias para resolver colisões em tabelas hash |
| **Dicionário** | Interface abstrata que permite armazenar e recuperar valores por chave |

---

## 🔍 Comparativo entre Estruturas

| Estrutura | Tempo de Busca | Tempo de Inserção | Uso de Memória | Observações |
|----------|----------------|-------------------|----------------|-------------|
| BST (balanceada) | O(log n) | O(log n) | Média | Pode ficar desbalanceada se não for AVL |
| AVL | O(log n) | O(log n) | Média | Mantém equilíbrio com rotações |
| Tabela Hash | O(1) (média) | O(1) (média) | Alta | Depende de boa função hash |
| Dicionário (implementado com Hash) | O(1) (média) | O(1) (média) | Alta | Baseado em tabela hash internamente |

---

## 🧪 Exercícios Propostos

| Exercício | Descrição | Dificuldade | Link |
|-----------|-----------|-------------|------|
| Exercício 1 | Implemente uma árvore binária de busca com inserção e busca | Médio | [Ver Exercício](../5-Pesquisa/Exercicios/Lista1.md#exercicio-1) |
| Exercício 2 | Implemente uma árvore AVL com inserção balanceada | Difícil | [Ver Exercício](../5-Pesquisa/Exercicios/Lista1.md#exercicio-2) |
| Exercício 3 | Crie uma tabela hash com tratamento de colisão por encadeamento | Médio | [Ver Exercício](../5-Pesquisa/Exercicios/Lista1.md#exercicio-3) |
| Exercício 4 | Crie um dicionário que permita adicionar, remover e buscar por chave | Fácil | [Ver Exercício](../5-Pesquisa/Exercicios/Lista1.md#exercicio-4) |

---

## 📚 Recursos Adicionais

- [Visualização de Árvores BST e AVL](https://visualgo.net/en/bst)
- [Visualização de Hash Table](https://www.cs.usfca.edu/~galles/visualization/OpenHash.html)
- [Documentação: Dicionário em C#](https://learn.microsoft.com/pt-br/dotnet/api/system.collections.generic.dictionary-2)
- [GeeksforGeeks: Árvores e Hash Tables](https://www.geeksforgeeks.org/data-structures/)
- [Vídeo: Pesquisa em Estruturas de Dados](https://www.youtube.com/watch?v=shs0KM3wKv8)

---

[🔙 Voltar para a página principal](../README.md)
