# Exercícios de Pilha Linear Estática com Vetores

Bem-vindo(a) a esta página de exercícios sobre Pilha Linear Estática com Vetores em C#! Para cada exercício, tente desenvolver sua solução antes de verificar a resposta.

## Exercício 1: Implementação básica de uma Pilha Linear Estática

Implemente uma classe `PilhaEstatica` que utilize um vetor para armazenar elementos inteiros, com as operações básicas: push (inserir no topo), pop (remover do topo), peek (consultar o topo sem remover), isEmpty (verificar se está vazia) e isFull (verificar se está cheia).

<details>
  <summary>Ver solução</summary>
  
```csharp
public class PilhaEstatica
{
    private int[] elementos;
    private int topo;
    
    public PilhaEstatica(int capacidade)
    {
        elementos = new int[capacidade];
        topo = -1; // Pilha vazia
    }
    
    public bool Push(int elemento)
    {
        // Verifica se a pilha está cheia
        if (IsFull())
            return false;
        
        topo++;
        elementos[topo] = elemento;
        return true;
    }
    
    public int Pop()
    {
        // Verifica se a pilha está vazia
        if (IsEmpty())
            throw new InvalidOperationException("A pilha está vazia");
        
        int elemento = elementos[topo];
        topo--;
        return elemento;
    }
    
    public int Peek()
    {
        // Verifica se a pilha está vazia
        if (IsEmpty())
            throw new InvalidOperationException("A pilha está vazia");
        
        return elementos[topo];
    }
    
    public bool IsEmpty()
    {
        return topo == -1;
    }
    
    public bool IsFull()
    {
        return topo == elementos.Length - 1;
    }
    
    public int Size()
    {
        return topo + 1;
    }
}
```

Esta implementação básica utiliza um vetor para armazenar os elementos e um índice `topo` para controlar a posição do último elemento inserido. As operações seguem o princípio LIFO (Last In, First Out) característico das pilhas.
</details>

## Exercício 2: Pilha de tipos genéricos

Modifique a implementação anterior para criar uma `PilhaEstaticaGenerica<T>` que possa armazenar elementos de qualquer tipo.

<details>
  <summary>Ver solução</summary>
  
```csharp
public class PilhaEstaticaGenerica<T>
{
    private T[] elementos;
    private int topo;
    
    public PilhaEstaticaGenerica(int capacidade)
    {
        elementos = new T[capacidade];
        topo = -1; // Pilha vazia
    }
    
    public bool Push(T elemento)
    {
        // Verifica se a pilha está cheia
        if (IsFull())
            return false;
        
        topo++;
        elementos[topo] = elemento;
        return true;
    }
    
    public T Pop()
    {
        // Verifica se a pilha está vazia
        if (IsEmpty())
            throw new InvalidOperationException("A pilha está vazia");
        
        T elemento = elementos[topo];
        topo--;
        return elemento;
    }
    
    public T Peek()
    {
        // Verifica se a pilha está vazia
        if (IsEmpty())
            throw new InvalidOperationException("A pilha está vazia");
        
        return elementos[topo];
    }
    
    public bool IsEmpty()
    {
        return topo == -1;
    }
    
    public bool IsFull()
    {
        return topo == elementos.Length - 1;
    }
    
    public int Size()
    {
        return topo + 1;
    }
}
```

Usando generics (tipos genéricos), criamos uma pilha que funciona com qualquer tipo de dados. Isso torna a estrutura muito mais flexível e reutilizável em diferentes contextos.
</details>

## Exercício 3: Verificação de sequência de parênteses balanceados

Implemente uma função que utilize a pilha para verificar se uma expressão matemática tem os parênteses balanceados (cada parêntese aberto deve ter um fechado correspondente).

<details>
  <summary>Ver solução</summary>
  
```csharp
public static bool VerificarParentesesBalanceados(string expressao)
{
    PilhaEstatica pilha = new PilhaEstatica(expressao.Length);
    
    foreach (char caractere in expressao)
    {
        if (caractere == '(')
        {
            // Empilha o parêntese aberto
            pilha.Push(1); // O valor não importa, apenas indicando um parêntese
        }
        else if (caractere == ')')
        {
            // Se encontrar um parêntese fechado sem correspondente aberto
            if (pilha.IsEmpty())
                return false;
                
            // Remove o parêntese aberto correspondente
            pilha.Pop();
        }
    }
    
    // A pilha deve estar vazia se todos os parênteses estiverem balanceados
    return pilha.IsEmpty();
}
```

Esta função verifica se os parênteses em uma expressão estão balanceados. A ideia é empilhar cada parêntese aberto e desempilhar quando encontrar um fechado. Se a pilha estiver vazia ao final, todos os parênteses têm um par correspondente.
</details>

## Exercício 4: Expansão para múltiplos tipos de parênteses

Expanda o exercício anterior para verificar expressões com múltiplos tipos de parênteses: (), [], {}.

<details>
  <summary>Ver solução</summary>
  
```csharp
public static bool VerificarMultiplosParentesesBalanceados(string expressao)
{
    PilhaEstaticaGenerica<char> pilha = new PilhaEstaticaGenerica<char>(expressao.Length);
    
    foreach (char caractere in expressao)
    {
        if (caractere == '(' || caractere == '[' || caractere == '{')
        {
            // Empilha o parêntese/colchete/chave aberto
            pilha.Push(caractere);
        }
        else if (caractere == ')' || caractere == ']' || caractere == '}')
        {
            // Se encontrar um fechamento sem correspondente
            if (pilha.IsEmpty())
                return false;
                
            char topo = pilha.Pop();
            
            // Verifica se o fechamento corresponde ao último aberto
            if ((caractere == ')' && topo != '(') ||
                (caractere == ']' && topo != '[') ||
                (caractere == '}' && topo != '{'))
            {
                return false;
            }
        }
    }
    
    // A pilha deve estar vazia se todos os parênteses estiverem balanceados
    return pilha.IsEmpty();
}
```

Esta versão expandida verifica múltiplos tipos de delimitadores - parênteses, colchetes e chaves. Além de verificar se cada símbolo é fechado, também verifica se o fechamento corresponde ao tipo correto de abertura.
</details>

## Exercício 5: Avaliação de expressão pós-fixa (notação polonesa reversa)

Implemente uma função que avalie uma expressão pós-fixa usando uma pilha. Na notação pós-fixa, os operadores vêm após os operandos (ex: "23+" equivale a "2+3").

<details>
  <summary>Ver solução</summary>
  
```csharp
public static int AvaliarExpressaoPosFixa(string expressao)
{
    PilhaEstatica pilha = new PilhaEstatica(expressao.Length);
    
    foreach (char token in expressao)
    {
        // Se for um dígito, empilha seu valor numérico
        if (char.IsDigit(token))
        {
            pilha.Push(token - '0'); // Converte char para int
        }
        // Se for um operador, desempilha operandos, aplica o operador e empilha o resultado
        else if (token == '+' || token == '-' || token == '*' || token == '/')
        {
            // Precisa de pelo menos dois operandos
            if (pilha.Size() < 2)
                throw new InvalidOperationException("Expressão inválida");
                
            int operando2 = pilha.Pop();
            int operando1 = pilha.Pop();
            
            switch (token)
            {
                case '+':
                    pilha.Push(operando1 + operando2);
                    break;
                case '-':
                    pilha.Push(operando1 - operando2);
                    break;
                case '*':
                    pilha.Push(operando1 * operando2);
                    break;
                case '/':
                    if (operando2 == 0)
                        throw new DivideByZeroException("Divisão por zero");
                    pilha.Push(operando1 / operando2);
                    break;
            }
        }
    }
    
    // O resultado final deve ser o único valor na pilha
    if (pilha.Size() != 1)
        throw new InvalidOperationException("Expressão inválida");
        
    return pilha.Pop();
}
```

Este algoritmo avalia expressões em notação pós-fixa (ou RPN - Reverse Polish Notation). A notação pós-fixa elimina a necessidade de parênteses e tem a vantagem de ser facilmente processada por computadores usando uma pilha.
</details>

## Exercício 6: Conversão de expressão infixa para pós-fixa

Implemente uma função que converta uma expressão infixa (normal, como "2+3") para a notação pós-fixa ("23+").

<details>
  <summary>Ver solução</summary>
  
```csharp
public static string ConverterInfixaParaPosFixa(string expressaoInfixa)
{
    PilhaEstaticaGenerica<char> pilha = new PilhaEstaticaGenerica<char>(expressaoInfixa.Length);
    string expressaoPosFixa = "";
    
    // Define a precedência dos operadores
    Dictionary<char, int> precedencia = new Dictionary<char, int>
    {
        {'+', 1},
        {'-', 1},
        {'*', 2},
        {'/', 2},
        {'^', 3}
    };
    
    foreach (char token in expressaoInfixa)
    {
        // Se for um operando (letra ou dígito), adiciona à saída
        if (char.IsLetterOrDigit(token))
        {
            expressaoPosFixa += token;
        }
        // Se for um parêntese aberto, empilha
        else if (token == '(')
        {
            pilha.Push(token);
        }
        // Se for um parêntese fechado, desempilha até encontrar o parêntese aberto correspondente
        else if (token == ')')
        {
            while (!pilha.IsEmpty() && pilha.Peek() != '(')
            {
                expressaoPosFixa += pilha.Pop();
            }
            
            // Remove o parêntese aberto da pilha
            if (!pilha.IsEmpty() && pilha.Peek() == '(')
                pilha.Pop();
        }
        // Se for um operador
        else if (precedencia.ContainsKey(token))
        {
            // Desempilha operadores com precedência maior ou igual
            while (!pilha.IsEmpty() && pilha.Peek() != '(' && 
                  precedencia.ContainsKey(pilha.Peek()) && 
                  precedencia[pilha.Peek()] >= precedencia[token])
            {
                expressaoPosFixa += pilha.Pop();
            }
            
            // Empilha o operador atual
            pilha.Push(token);
        }
    }
    
    // Desempilha quaisquer operadores restantes
    while (!pilha.IsEmpty())
    {
        expressaoPosFixa += pilha.Pop();
    }
    
    return expressaoPosFixa;
}
```

Este algoritmo usa uma pilha para converter expressões da notação infixa (convencional) para a notação pós-fixa. A conversão considera a precedência dos operadores e o uso de parênteses para determinar a ordem de avaliação.
</details>

## Exercício 7: Implementação de histórico de navegação

Implemente uma classe `HistoricoNavegacao` que simule o histórico de um navegador web, com funcionalidades para adicionar páginas e voltar (como os botões avançar/voltar de um navegador).

<details>
  <summary>Ver solução</summary>
  
```csharp
public class HistoricoNavegacao
{
    private PilhaEstaticaGenerica<string> paginasAnteriores;
    private PilhaEstaticaGenerica<string> paginasPosteriores;
    private string paginaAtual;
    
    public HistoricoNavegacao(int capacidade)
    {
        paginasAnteriores = new PilhaEstaticaGenerica<string>(capacidade);
        paginasPosteriores = new PilhaEstaticaGenerica<string>(capacidade);
        paginaAtual = null;
    }
    
    public void Navegar(string url)
    {
        // Se já temos uma página atual, adicionamos ao histórico
        if (paginaAtual != null)
        {
            paginasAnteriores.Push(paginaAtual);
        }
        
        // Limpamos o histórico de páginas posteriores
        while (!paginasPosteriores.IsEmpty())
        {
            paginasPosteriores.Pop();
        }
        
        paginaAtual = url;
    }
    
    public string Voltar()
    {
        if (paginasAnteriores.IsEmpty())
            return null; // Não há para onde voltar
            
        // Salvamos a página atual na pilha de páginas posteriores
        paginasPosteriores.Push(paginaAtual);
        
        // Voltamos para a página anterior
        paginaAtual = paginasAnteriores.Pop();
        
        return paginaAtual;
    }
    
    public string Avancar()
    {
        if (paginasPosteriores.IsEmpty())
            return null; // Não há para onde avançar
            
        // Salvamos a página atual na pilha de páginas anteriores
        paginasAnteriores.Push(paginaAtual);
        
        // Avançamos para a próxima página
        paginaAtual = paginasPosteriores.Pop();
        
        return paginaAtual;
    }
    
    public string PaginaAtual()
    {
        return paginaAtual;
    }
    
    public bool PodeVoltar()
    {
        return !paginasAnteriores.IsEmpty();
    }
    
    public bool PodeAvancar()
    {
        return !paginasPosteriores.IsEmpty();
    }
}
```

Esta implementação usa duas pilhas para simular o comportamento de navegação de um navegador web: uma para o histórico de páginas anteriores (botão "Voltar") e outra para o histórico de páginas posteriores (botão "Avançar").
</details>

## Exercício 8: Validação de código com blocos

Implemente uma função que verifique se um código fonte em C# tem todos os blocos de código (delimitados por chaves) balanceados.

<details>
  <summary>Ver solução</summary>
  
```csharp
public static bool ValidarBlocosCodigoBalanceados(string codigoFonte)
{
    PilhaEstaticaGenerica<int> pilha = new PilhaEstaticaGenerica<int>(codigoFonte.Length);
    bool dentroDeString = false;
    bool dentroDeComentarioLinha = false;
    bool dentroDeComentarioBloco = false;
    
    for (int i = 0; i < codigoFonte.Length; i++)
    {
        char atual = codigoFonte[i];
        
        // Verifica se estamos em um literal de string (ignora chaves dentro de strings)
        if (atual == '"' && i > 0 && codigoFonte[i - 1] != '\\' && !dentroDeComentarioLinha && !dentroDeComentarioBloco)
        {
            dentroDeString = !dentroDeString;
            continue;
        }
        
        // Verifica se estamos em um comentário de linha
        if (atual == '/' && i + 1 < codigoFonte.Length && codigoFonte[i + 1] == '/' && !dentroDeString && !dentroDeComentarioBloco)
        {
            dentroDeComentarioLinha = true;
            continue;
        }
        
        // Verifica se é fim de linha (termina comentário de linha)
        if ((atual == '\n' || atual == '\r') && dentroDeComentarioLinha)
        {
            dentroDeComentarioLinha = false;
            continue;
        }
        
        // Verifica início de comentário de bloco
        if (atual == '/' && i + 1 < codigoFonte.Length && codigoFonte[i + 1] == '*' && !dentroDeString && !dentroDeComentarioLinha)
        {
            dentroDeComentarioBloco = true;
            i++; // Pula o próximo caractere '*'
            continue;
        }
        
        // Verifica fim de comentário de bloco
        if (atual == '*' && i + 1 < codigoFonte.Length && codigoFonte[i + 1] == '/' && dentroDeComentarioBloco)
        {
            dentroDeComentarioBloco = false;
            i++; // Pula o próximo caractere '/'
            continue;
        }
        
        // Ignora caracteres dentro de strings ou comentários
        if (dentroDeString || dentroDeComentarioLinha || dentroDeComentarioBloco)
            continue;
        
        // Processa chaves para verificar blocos de código
        if (atual == '{')
        {
            pilha.Push(i); // Guarda a posição da chave aberta
        }
        else if (atual == '}')
        {
            if (pilha.IsEmpty())
                return false; // Chave fechada sem correspondente aberta
            
            pilha.Pop();
        }
    }
    
    // Verifica se todas as chaves foram fechadas
    return pilha.IsEmpty();
}
```

Esta função analisa um código fonte em C# e verifica se todos os blocos delimitados por chaves estão corretamente balanceados. Ela lida com casos especiais como chaves dentro de strings e comentários, que não devem ser consideradas na validação.
</details>

## Exercício 9: Implementação de desfazer/refazer (undo/redo)

Implemente uma classe `EditorTexto` que simule as funcionalidades de desfazer (undo) e refazer (redo) de um editor de texto.

<details>
  <summary>Ver solução</summary>
  
```csharp
public class EditorTexto
{
    private string textoAtual;
    private PilhaEstaticaGenerica<string> historicoDesfazer;
    private PilhaEstaticaGenerica<string> historicoRefazer;
    
    public EditorTexto(int capacidadeHistorico)
    {
        textoAtual = "";
        historicoDesfazer = new PilhaEstaticaGenerica<string>(capacidadeHistorico);
        historicoRefazer = new PilhaEstaticaGenerica<string>(capacidadeHistorico);
    }
    
    public string ObterTextoAtual()
    {
        return textoAtual;
    }
    
    public void AdicionarTexto(string texto)
    {
        // Salva o estado atual antes da modificação
        historicoDesfazer.Push(textoAtual);
        
        // Limpa o histórico de refazer
        LimparHistoricoRefazer();
        
        // Adiciona o novo texto
        textoAtual += texto;
    }
    
    public void SubstituirTexto(string novoTexto)
    {
        // Salva o estado atual antes da modificação
        historicoDesfazer.Push(textoAtual);
        
        // Limpa o histórico de refazer
        LimparHistoricoRefazer();
        
        // Substitui o texto atual
        textoAtual = novoTexto;
    }
    
    public bool PodeDesfazer()
    {
        return !historicoDesfazer.IsEmpty();
    }
    
    public string Desfazer()
    {
        if (!PodeDesfazer())
            return textoAtual;
        
        // Salva o estado atual para poder refazer depois
        historicoRefazer.Push(textoAtual);
        
        // Restaura o estado anterior
        textoAtual = historicoDesfazer.Pop();
        
        return textoAtual;
    }
    
    public bool PodeRefazer()
    {
        return !historicoRefazer.IsEmpty();
    }
    
    public string Refazer()
    {
        if (!PodeRefazer())
            return textoAtual;
        
        // Salva o estado atual para poder desfazer novamente
        historicoDesfazer.Push(textoAtual);
        
        // Restaura o estado que foi desfeito
        textoAtual = historicoRefazer.Pop();
        
        return textoAtual;
    }
    
    private void LimparHistoricoRefazer()
    {
        while (!historicoRefazer.IsEmpty())
        {
            historicoRefazer.Pop();
        }
    }
}
```

Esta implementação usa duas pilhas para gerenciar o histórico de edições em um editor de texto, permitindo as funcionalidades de desfazer (undo) e refazer (redo) operações. Sempre que o texto é modificado, a versão anterior é salva na pilha de desfazer.
</details>

## Exercício 10: Algoritmo de caminho em labirinto (backtracking)

Implemente um algoritmo que use uma pilha para encontrar um caminho em um labirinto representado por uma matriz, onde 0 representa um caminho livre e 1 representa uma parede.

<details>
  <summary>Ver solução</summary>
  
```csharp
public class Posicao
{
    public int Linha { get; set; }
    public int Coluna { get; set; }
    
    public Posicao(int linha, int coluna)
    {
        Linha = linha;
        Coluna = coluna;
    }
}

public static List<Posicao> EncontrarCaminhoLabirinto(int[,] labirinto, Posicao inicio, Posicao fim)
{
    int linhas = labirinto.GetLength(0);
    int colunas = labirinto.GetLength(1);
    
    // Matriz para marcar células já visitadas
    bool[,] visitado = new bool[linhas, colunas];
    
    // Pilha para armazenar o caminho atual
    PilhaEstaticaGenerica<Posicao> pilha = new PilhaEstaticaGenerica<Posicao>(linhas * colunas);
    
    // Direções possíveis: cima, direita, baixo, esquerda
    int[] dx = { -1, 0, 1, 0 };
    int[] dy = { 0, 1, 0, -1 };
    
    // Começa pelo ponto inicial
    pilha.Push(inicio);
    visitado[inicio.Linha, inicio.Coluna] = true;
    
    // Continua até a pilha ficar vazia ou encontrar o destino
    while (!pilha.IsEmpty())
    {
        Posicao atual = pilha.Peek();
        
        // Verifica se chegamos ao destino
        if (atual.Linha == fim.Linha && atual.Coluna == fim.Coluna)
        {
            // Constrói o caminho a partir da pilha
            List<Posicao> caminho = new List<Posicao>();
            while (!pilha.IsEmpty())
            {
                caminho.Add(pilha.Pop());
            }
            caminho.Reverse(); // Inverte para obter o caminho do início ao fim
            return caminho;
        }
        
        bool encontrouCaminho = false;
        
        // Tenta mover para uma direção válida
        for (int i = 0; i < 4; i++)
        {
            int novaLinha = atual.Linha + dx[i];
            int novaColuna = atual.Coluna + dy[i];
            
            // Verifica se a posição é válida, não é uma parede e não foi visitada
            if (novaLinha >= 0 && novaLinha < linhas && 
                novaColuna >= 0 && novaColuna < colunas && 
                labirinto[novaLinha, novaColuna] == 0 && 
                !visitado[novaLinha, novaColuna])
            {
                // Marca como visitada e adiciona à pilha
                visitado[novaLinha, novaColuna] = true;
                pilha.Push(new Posicao(novaLinha, novaColuna));
                encontrouCaminho = true;
                break;
            }
        }
        
        // Se não encontrar caminho a partir da posição atual, faz backtracking
        if (!encontrouCaminho)
        {
            pilha.Pop();
        }
    }
    
    // Se chegou aqui, não há caminho
    return null;
}
```

Este algoritmo usa uma pilha para implementar um algoritmo de busca em profundidade (DFS) com backtracking para encontrar um caminho em um labirinto. A pilha armazena o caminho atual, e quando um beco sem saída é encontrado, o algoritmo faz backtracking (desempilha) e tenta um caminho alternativo.
</details>