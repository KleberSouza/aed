using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite um número inteiro para calcular o n-ésimo termo de Fibonacci: ");
        int n = int.Parse(Console.ReadLine());

        int resultado = Fibonacci(n);
        Console.WriteLine($"F({n}) = {resultado}");
    }

    static int Fibonacci(int n)
    {
        if (n == 0)
            return 0;

        if (n == 1)
            return 1;

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}
