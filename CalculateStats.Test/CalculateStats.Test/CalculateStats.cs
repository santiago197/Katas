using FluentAssertions;

namespace CalculateStats.Test;

public class CalculateStats
{
    [Fact]
    public void Si_Recibe_Secuencia_De_Numeros_Debe_Retornar_El_Valor_Minimo_y_Maximo()
    {
        //Arrange
        var calcular = new Calcular();
        var numeros = [1, 3, 9];
        
        //Act 
        var resultado = calcular.ValorMaximoyMinimo();
        //Assert
        resultado.Should().BeEqual(1, 9);
    }
}