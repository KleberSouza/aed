using System;

class Program
{
    static void Main()
    {
        int[] vetor = { 1, 3, 5, 7, 9, 11, 13, 15 };

        Console.Write("Digite o número que deseja buscar: ");
        int alvo = int.Parse(Console.ReadLine());

        int resultado = BuscaBinaria(vetor, 0, vetor.Length - 1, alvo);

        if (resultado != -1)
            Console.WriteLine($"Elemento encontrado no índice {resultado}");
        else
            Console.WriteLine("Elemento não encontrado");
    }

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
}