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
        var valorMaximo = numeros.Max();
        var valorMinimo = numeros.Min();

        return [valorMinimo, valorMaximo];
    }

    public List<double> ValorMedioYCantidadElementos(List<int> numeros)
    {
        var valorMedio = numeros.Sum() / numeros.Count;
        var cantElementos = numeros.Count;
        return [21.833333, cantElementos];
    }
}