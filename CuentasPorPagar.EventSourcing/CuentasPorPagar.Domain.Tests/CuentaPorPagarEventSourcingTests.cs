using AwesomeAssertions;
using CuentasPorPagar.EventSourcing;

namespace CuentasPorPagar.Domain.Tests;

public class CuentaPorPagarEventSourcingTests
{
    [Fact]
    public void DadoUnaCuentaPorPagarcuandoRegistroUnaFacturaDebeEmitirEventoFacturaRegistrada()
    {
        //Arrange
        var cuenta = new CuentaPorPagar();
        //Act
        cuenta.RegistrarFactura(100);
        // Assert // /Después de ejecutar el comando, debe existir exactamente un evento FacturaRegistrada con monto 100
        var evento = cuenta.GetUncommittedEvents()
            .Single();

        evento.Should().BeOfType<FacturaRegistrada>();
        ((FacturaRegistrada)evento).Monto.Should().Be(100);
    }

    [Fact]
    public void CuandoAprueboUnaCuentaConFactura_Debe_EmitirEventoCuentaAprobada()
    {
        //Arrange
        var cuenta = new CuentaPorPagar();
        cuenta.RegistrarFactura(100);

        //Act
        cuenta.Aprobar();

        cuenta.GetUncommittedEvents()
            .Should()
            .Contain(e => e is CuentaAprobada);
    }

    [Fact]
    public void CuandoAprueboUnaCuentaSinFactura_Debe_LanzarExcepcionYNoEmitirCuentaAprobada()
    {
        //Arrange
        var cuenta = new CuentaPorPagar();
        //Act
        Action caller = () => cuenta.Aprobar();
        
        caller.Should().ThrowExactly<InvalidOperationException>().WithMessage("No se puede aprobar una cuenta sin factura registrada.");
        
        cuenta.GetUncommittedEvents().Should().BeEmpty();
    }
}