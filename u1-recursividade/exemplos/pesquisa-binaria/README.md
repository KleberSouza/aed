# 🔍 Exemplo: Busca Binária Recursiva


## 📝 Descrição

A **Busca Binária** é um algoritmo eficiente para localizar um elemento em um vetor **ordenado**.  
A ideia principal é **dividir para conquistar**: a cada passo, o vetor é reduzido pela metade.

Na versão **recursiva**, o algoritmo chama a si mesmo com um intervalo reduzido até encontrar o valor ou encerrar a busca.

---

## 🧠 Conceitos Envolvidos

- **Divisão do problema ao meio**
- **Caso base**: intervalo inválido ou elemento encontrado
- **Caso recursivo**: chamada com metade esquerda ou direita
- **Eficiência com vetores ordenados**

---

## 💡 Complexidade

| Operação    | Complexidade de Tempo | Complexidade de Espaço | Observações                       |
|-------------|------------------------|-------------------------|-----------------------------------|
| Melhor caso | O(1)                   | O(log n)                | Elemento está no meio do vetor    |
| Pior caso   | O(log n)               | O(log n)                | Depende da profundidade da recursão |

---

## ▶️ Código

O código de exemplo está disponível em: 

📁 [`Pesquisa Binária`](./Program.cs)

```csharp
    static int BuscaBinaria(int[] vetor, int inicio, int fim, int alvo)
    {
        if (inicio > fim)
            return -1;

        int meio = (inicio + fim) / 2;

        if (vetor[meio] == alvo)
            return meio;
        else if (alvo < vetor[meio])
            return BuscaBinaria(vetor, inicio, meio - 1, alvo);
        else
            return BuscaBinaria(vetor, meio + 1, fim, alvo);
    }
```


---

## 🧪 Experimente

Você pode testar com valores como:

- `n = 5 → resultado = Elemento encontrado no índice 2`
- `n = 7 → resultado = Elemento encontrado no índice 3`
- `n = 20 → resultado = Elemento não encontrado`

---

[🔙 Voltar para Algoritmos Recursivos](../../README.md)

