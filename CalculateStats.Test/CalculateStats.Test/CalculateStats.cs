using FluentAssertions;

namespace CalculateStats.Test;

public class CalculateStats
{
    [Fact]
    public void Si_Recibe_Secuencia_De_Numeros_Debe_Retornar_El_Valor_Minimo_y_Maximo()
    {
        //Arrange
        var calcular = new Calcular();
        List<int> numeros = [6, 9, 15, -2, 92, 11];

        //Act 
        var resultado = calcular.ValorMaximoyMinimo(numeros);
        //Assert
        resultado.Should().BeEquivalentTo([-2, 92]);
    }

    [Fact]
    public void Si_Recibe_Secuencia_De_Numeros_Debe_Retornar_El_Valor_Medio_Y_Numero_De_Elementos()
    {
        var calcular = new Calcular();
        List<int> numeros = [6, 9, 15, -2, 92, 11];
        var resultado = calcular.ValorMedioYCantidadElementos(numeros);
        resultado.Should().BeEquivalentTo([21.833333, 6]);
    }
}

public class Calcular
{
    public List<int> ValorMaximoyMinimo(List<int> numeros)
    {
        var valorMaximo = ValorMaximo(numeros);
        var valorMinimo = ValorMinimo(numeros);

        return [valorMinimo, valorMaximo];
    }

    private static int ValorMinimo(List<int> numeros)
    {
        var valorMinimo = numeros.Min();
        return valorMinimo;
    }

    private static int ValorMaximo(List<int> numeros)
    {
        var valorMaximo = numeros.Max();
        return valorMaximo;
    }

    public List<double> ValorMedioYCantidadElementos(List<int> numeros)
    {
        var valorMedio = ValorMedio(numeros);
        var cantElementos = CantElementos(numeros);
        return [valorMedio, cantElementos];
    }

    private static int CantElementos(List<int> numeros)
    {
        return numeros.Count;
    }

    private static double ValorMedio(List<int> numeros)
    {
        return Math.Round(numeros.Average(), 6);
    }
}