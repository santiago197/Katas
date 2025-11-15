using System.Text;
using AwesomeAssertions;

namespace WordWrap.Tests;

public class WordWrapTests
{
    private static int _caracter;
    private static bool _limiteColumna;

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
        if (string.IsNullOrEmpty(text) || col <= 0)
            return text;

        var sb = new StringBuilder();
        int indice = 0;

        while (indice < text.Length)
        {
            int remaining = text.Length - indice;
            if (remaining <= col)
            {
                sb.Append(text.Substring(indice));
                break;
            }

            int end = indice + col;
            int ultimoEspacio = text.LastIndexOf(' ', end - 1, col);

            if (ultimoEspacio > indice)
            {
                sb.Append(text.Substring(indice, ultimoEspacio - indice));
                sb.Append('\n');
                indice = ultimoEspacio + 1;
            }
            else
            {
                sb.Append(text.Substring(indice, col));
                sb.Append('\n');
                indice += col;
            }
        }

        return sb.ToString();
    }
}