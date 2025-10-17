using FluentAssertions;

namespace CalculateStats.Test;

public class CalculateStats
{
    [Fact]
    public void Si_Recibe_Secuencia_De_Numeros_Debe_Retornar_El_Valor_Minimo_y_Maximo()
    {
        //Arrange
        var calcular = new Calcular();
        List<int> numeros = [1, 3, 9];
        
        //Act 
        var resultado = calcular.ValorMaximoyMinimo(numeros);
        //Assert
        resultado.Should().BeEquivalentTo([1, 9]);
    }
}

public class Calcular
{
    public int[] ValorMaximoyMinimo(List<int> numeros)
    {
        var valorMaximo = numeros.Max();
        var valorMinimo = numeros.Min();
        
        return [valorMinimo, valorMaximo];
    }
}