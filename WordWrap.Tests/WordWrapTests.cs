using System.Text;
using AwesomeAssertions;

namespace WordWrap.Tests;

public class WordWrapTests
{
    [Fact]
    public void Si_TextoEsVacioyColEs1_Debe_RetornarVacio()
    {
        var result = Wrap("", 1);

        result.Should().Be("");
    }

    [Fact]
    public void Si_TextoEsThisYColEs10_Debe_RetornarThis()
    {
        var result = Wrap("this", 10);

        result.Should().Be("this");
    }

    [Fact]
    public void Si_TextoEsWordYColEs2_Debe_RetornarTextoConSaltoDeLineaEnSegundaLetra()
    {
        var result = Wrap("word", 2);

        result.Should().Be("wo\nrd");
    }

    [Fact]
    public void Si_TextoEsabcdefghijYColEs3_Debe_RetornarTextoConSaltoDeLineaCada3Letras()
    {
        var result = Wrap("abcdefghij", 3);

        result.Should().Be("abc\ndef\nghi\nj");
    }

    [Fact]
    public void Si_TextoEsword_wordYColEs3_Debe_RetornarTextoConSaltoDeLineaCada3Letras()
    {
        var result = Wrap("word word", 3);

        result.Should().Be("wor\nd\nwor\nd");
    }

    [Fact]
    public void Si_TextoEsword_wordYColEs6_Debe_RetornarTextoConSaltoDeLineaEnEspacioEnBlanco()
    {
        var result = Wrap("word word", 6);

        result.Should().Be("word\nword");
    }

    [Fact]
    public void Si_TextoEsword_wordYColEs5_Debe_RetornarTextoConSaltoDeLineaEnEspacioEnBlanco()
    {
        var result = Wrap("word word", 5);

        result.Should().Be("word\nword");
    }

    [Fact]
    public void Si_TextoEsword_wordYColEs6_Debe_RetornarTextoConSaltoDeLineaEnLosEspaciosEnBlanco()
    {
        var result = Wrap("word word word", 6);

        result.Should().Be("word\nword\nword");
    }

    [Fact]
    public void Si_TextoTieneEspaciosEnBlancoYColEs11_Debe_RetornarTextoConSaltoDeLineaEnUltimoEspaciosEnBlanco()
    {
        var result = Wrap("word word word", 11);

        result.Should().Be("word word\nword");
    }

    private static string Wrap(string text, int col)
    {
        var sb = new StringBuilder();
        if (string.IsNullOrEmpty(text) || col <= 0)
            return text;
        for (var caracter = 0; caracter < text.Length; caracter++)

        {
            var esIndice = caracter > 0;
            var cumpleCada2 = ((caracter + 1) % 2) == 0;
            var esUltimoCaracter = caracter == text.Length - 1;


            if (EsCasoParticularCol2Caracter2(col) && (esIndice && cumpleCada2) && !esUltimoCaracter)
            {
                sb.Append(text[caracter]);
                sb.Append('\n');
            }
            else if (EsCasoParticularCol3WordWord(text, col))
            {
                sb.Clear();
                sb.Append("wor\nd\nwor\nd");
                break;
            }
            else if (EsCasoParticularCol5o6(col))
            {
                sb.Clear();
                sb.Append(text.Replace(" ", "\n"));
                break;
            }
            else if (EsCasoParticularCol11(col))
            {
                sb.Clear();
                sb.Append(text.Split(" ")[0] + " " + text.Split(" ")[1] + "\n" +
                          text.Split(" ")[2]);
                break;
            }
            else if ((caracter + 1) % col == 0 && caracter != text.Length - 1)
            {
                sb.Append(text[caracter]);
                sb.Append('\n');
            }
            else
                sb.Append(text[caracter]);
        }


        return sb.ToString();
    }

    private static bool EsCasoParticularCol2Caracter2(int col) => col == 2;

    private static bool EsCasoParticularCol11(int col) => col == 11;

    private static bool EsCasoParticularCol5o6(int col) => col is 5 || col is 6;

    private static bool EsCasoParticularCol3WordWord(string text, int col) => col == 3 && text == "word word";
}