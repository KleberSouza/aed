# 🧪 Exemplo: Fatorial Recursivo

## 📝 Descrição

O cálculo do **fatorial** de um número natural `n` é um exemplo clássico de **recursão direta**. O fatorial é definido como:

n! = n × (n - 1) × (n - 2) × ... × 1

0! = 1 (caso base)


A abordagem recursiva consiste em dividir o problema em subproblemas menores, chamando a função de forma repetida até atingir o **caso base**.

---

## 🧠 Conceitos Envolvidos

- **Recursão Direta**
- **Caso Base**: Quando `n == 0`, retornamos 1.
- **Caso Recursivo**: `n * Fatorial(n - 1)`
- **Pilha de Execução**: Cada chamada é empilhada até atingir o caso base, depois desempilhada.

---

## 💡 Complexidade

| Métrica | Valor |
|--------|-------|
| Tempo  | O(n)  |
| Espaço | O(n)  (devido à pilha de chamadas recursivas) |

---

## ▶️ Código

O código de exemplo está disponível em: 

📁 [`Fatorial`](./Program.cs)

```csharp
static long Fatorial(int n)
{
    if (n == 0) return 1;
    return n * Fatorial(n - 1);
}
```


---

## 🧪 Experimente

Você pode testar com valores como:

- `n = 0 → resultado = 1`
- `n = 5 → resultado = 120`
- `n = 10 → resultado = 3628800`

---

[🔙 Voltar para Algoritmos Recursivos](../../README.md)
