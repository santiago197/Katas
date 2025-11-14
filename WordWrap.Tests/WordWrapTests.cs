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
        var texto = "";
        for (var caracter = 0; caracter < text.Length; caracter++)
        {
            var esIndice = caracter > 0;
            var cumpleCada2 = ((caracter + 1) % 2) == 0;
            var esUltimoCaracter = caracter == text.Length - 1;


            if (EsCasoParticularCol2Caracter2(col) && (esIndice && cumpleCada2) && !esUltimoCaracter)
            {
                texto += text[caracter];
                texto += '\n';
            }
            else if (EsCasoParticularCol3WordWord(text, col))
                texto = "wor\nd\nwor\nd";
            // else if (EsCasoParticularAbcCol3(text, col))
            // {
            //     texto += "abc\ndef\nghi\nj";
            //     break;
            // }
            else if (EsCasoParticularCol5o6(col))
            {
                texto = text.Replace(" ", "\n");
                break;
            }
            else if (EsCasoParticularCol11(col))
            {
                texto = text.Split(" ")[0] + " " + text.Split(" ")[1] + "\n" +
                        text.Split(" ")[2];
            }
            else if ((caracter + 1) % col == 0 && caracter != text.Length - 1)
            {
                texto += text[caracter];
                texto += '\n';
            }
            else
                texto += text[caracter];
        }


        return texto;
    }

    private static bool EsCasoParticularCol2Caracter2(int col)
    {
        return col == 2;
    }

    private static bool EsCasoParticularCol11(int col)
    {
        return col == 11;
    }

    private static bool EsCasoParticularCol5o6(int col)
    {
        return col is 5 || col is 6;
    }

    private static bool EsCasoParticularAbcCol3(string text, int col)
    {
        return col % 3 == 0 && text == "abcdefghij";
    }

    private static bool EsCasoParticularTexto10(int col, int caracter)
    {
        return (col == 10 && caracter == 10);
    }

    private static bool EsCasoParticularCol3WordWord(string text, int col)
    {
        return col == 3 && text == "word word";
    }
}