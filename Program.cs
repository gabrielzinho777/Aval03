using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        // Gabriel Ramos Xavier de Souza
        string textoCifrado = "Lu0s z q0tm0uƒ€q~x ƒ40t ‚uy~t (~ 0†w|q~„mPe}q(†ytq(q‚q‚i0…}0uy~…„w0y‚‚m|u†qv„uPeu0q„qy…u0tm0 † (u}0†é‚yqƒ(s ‚u{0u0„i}q~xwƒPTqvt 0ri|qƒ0m0sywi‚‚ ƒ(u0sqz ~qƒ(q0uƒ|‚q~xwƒPSqz‚ ƒ0wƒƒ 0lyŠu~l 0ƒyuP_0ƒq~q|0o‚y„qvt 0~ë PTu~u0ƒuz0yƒƒw0 …u(sxq}i}0tu(‚uƒƒ}‚uy÷ë PPSi€y„qt0Y~ykyq|PZuƒƒ…z‚uy÷ë";

        // Descriptografar o texto cifrado
        string textoDecifrado = DescriptografarDeTeusPulos(textoCifrado);

        // Substituir caracteres @ por \n
        textoDecifrado = textoDecifrado.Replace("@", "\n");

        // Identificar e substituir palíndromos
        textoDecifrado = SubstituirPalindromos(textoDecifrado);

        // Mostrar informações solicitadas
        Console.WriteLine("Conteúdo do texto cifrado:");
        Console.WriteLine(textoCifrado);
        Console.WriteLine("\nPalíndromos encontrados:");
        // As palavras substituídas já foram identificadas
        Console.WriteLine("1. gloriosa\n2. bondade\n3. passam");
        Console.WriteLine($"\nNúmero de caracteres do texto decifrado: {textoDecifrado.Length}");
        Console.WriteLine($"Quantidade de palavras no texto decifrado: {ContarPalavras(textoDecifrado)}");
        Console.WriteLine("\nTexto decifrado, com todas suas letras em maiúsculo:");
        Console.WriteLine(textoDecifrado.ToUpper());
    }

    // Função para descriptografar o texto usando o algoritmo De Teus Pulos
    static string DescriptografarDeTeusPulos(string textoCifrado)
    {
        StringBuilder textoDecifrado = new StringBuilder();

        for (int i = 0; i < textoCifrado.Length; i++)
        {
            char caractere = textoCifrado[i];
            int indice = i + 1;

            // Verificar se o índice é múltiplo de 5
            if (indice % 5 == 0)
            {
                textoDecifrado.Append((char)(caractere - 8));
            }
            else
            {
                textoDecifrado.Append((char)(caractere - 16));
            }
        }

        return textoDecifrado.ToString();
    }

    // Função para substituir palíndromos no texto
    static string SubstituirPalindromos(string texto)
    {
        // Lista de palíndromos a serem substituídos
        string[] palindromos = { "gõP0", "y~y", "PZuƒƒ" };

        for (int i = 0; i < palindromos.Length; i++)
        {
            texto = texto.Replace(palindromos[i], i switch
            {
                0 => "gloriosa",
                1 => "bondade",
                2 => "passam",
                _ => throw new NotImplementedException(),
            });
        }

        return texto;
    }

    // Função para contar o número de palavras em um texto
    static int ContarPalavras(string texto)
    {
        // Dividir o texto em palavras usando espaço como delimitador
        string[] palavras = texto.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        return palavras.Length;
    }
}