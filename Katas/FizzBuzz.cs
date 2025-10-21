namespace Katas;

public static class FizzBuzz
{
    public static string Calcular(int numero)
    {
        string? resultado = null;
        if (numero.EsMultiploDe3())
            resultado += "Fizz";
        if (numero.EsMultiploDe5())
            resultado += "Buzz";
        return resultado ?? numero.ToString();
    }
    
    private static bool EsMultiploDe5(this int numero) => numero.EsMultiploDe(5);

    private static bool EsMultiploDe(this int numero, int dividendo) => numero % dividendo == 0;

    private static bool EsMultiploDe3(this int numero) => numero.EsMultiploDe(3);
}