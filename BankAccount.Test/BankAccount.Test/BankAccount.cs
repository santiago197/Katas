using FluentAssertions;

namespace BankAccount.Test;

public class BankAccount
{
    [Theory]
    [InlineData(1000)]
    [InlineData(2000)]
    public void Si_Cliente_Hace_Deposito_Debe_Retornar_El_Valor_Depositadp(int amount)
    {
        var account = new AccountService();


        var result = account.deposit(amount);

        result.Should().Be(amount);
    }

    [Theory]
    [InlineData(500)]
    public void Si_Cliente_Hace_Retiro_Debe_Retornar_El_Valor_Retirado(int amount)
    {
        var account = new AccountService();

        var result = account.withdraw(amount);

        result.Should().Be(amount);
    }

    [Fact]
    public void Si_Cliente_Solicita_Extracto_Debe_Retornar_Movimientos()
    {
        var account = new AccountService();
        var expectedOutput = 
            @"Date       || Amount || Balance
            14/01/2012 || -500   || 2500
            13/01/2012 || 2000   || 3000
            10/01/2012 || 1000   || 1000";

        var extract = account.printStatement();

        extract.Should().Be(expectedOutput);
    }
}

public class AccountService
{
    public object deposit(int amount)
    {
        return amount;
    }

    public object withdraw(int amount)
    {
        return amount;
    }
}