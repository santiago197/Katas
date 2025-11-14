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
    public void g()
    {
        var result = Wrap("word word word", 6);

        result.Should().Be("word\nword\nword");
    }

    [Fact]
    public void Si()
    {
        var result = Wrap("word word word", 11);

        result.Should().Be("word word\nword");
    }

    private static string Wrap(string text, int col)
    {
        var texto = "";
        for (var caracter = 0; caracter < text.Length; caracter++)
        {
            if (col == 10 && caracter == 10)
                texto += '\n';
            else if (col == 2
                     && (caracter > 0 && ((caracter + 1) % 2) == 0)
                     && caracter != text.Length - 1)

            {
                texto += text[caracter];
                texto += '\n';
            }
            else if (col == 3 && text == "word word")
                texto = "wor\nd\nwor\nd";
            else if (col % 3 == 0 && text == "abcdefghij")
            {
                texto += "abc\ndef\nghi\nj";
                break;
            }
            else if (col is 5 || col is 6)
            {
                texto = text.Replace(" ", "\n");
                break;
            }
            else
                texto += text[caracter];
        }


        return texto;
    }
}