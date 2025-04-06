# 🧪 Exemplo: Fibonacci Recursivo

<img src="../../../.github/assets/fibonacci.png" alt="Fibonacci Recursivo" width="220" align="right"/>

## 📝 Descrição

A **sequência de Fibonacci** é uma sucessão numérica onde cada termo é a soma dos dois anteriores:

F(0) = 0, F(1) = 1

F(n) = F(n - 1) + F(n - 2), para n ≥ 2


Esse problema possui uma definição **recursiva natural**, ideal para demonstrar como a recursão funciona.

---

## 🧠 Conceitos Envolvidos

- **Recursão com múltiplas chamadas**
- **Caso base**: `n == 0` ou `n == 1`
- **Caso recursivo**: `F(n) = F(n - 1) + F(n - 2)`
- **Pilha de execução**: Várias chamadas simultâneas

---

## 💡 Complexidade

| Versão         | Tempo     | Espaço       | Observações                            |
|----------------|-----------|--------------|----------------------------------------|
| Recursiva pura | O(2ⁿ)     | O(n)         | Muito ineficiente para n > 30          |
| Otimizada (com memoização) | O(n) | O(n) | Reduz drasticamente o tempo de execução |

---

## ▶️ Código

O código de exemplo está disponível em: 

📁 [`Fibonacci`](./Program.cs)

```csharp
static int Fibonacci(int n)
{
    if (n == 0)
        return 0;

    if (n == 1)
        return 1;

    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
```

## 🧪 Experimente

Exemplos de chamada:

- `F(0) = 0`
- `F(1) = 1`
- `F(5) = 5`
- `F(10) = 55`

---

[🔙 Voltar para Algoritmos Recursivos](../../README.md)
