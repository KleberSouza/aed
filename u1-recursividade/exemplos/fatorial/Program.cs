using System;

class Program
{
    static void Main()
    {
        Console.Write("Digite um número inteiro para calcular o fatorial: ");
        int n = int.Parse(Console.ReadLine());

        long resultado = Fatorial(n);
        Console.WriteLine($"{n}! = {resultado}");
    }

    static long Fatorial(int n)
    {
        if (n == 0)
            return 1;

        return n * Fatorial(n - 1);
    }
}
