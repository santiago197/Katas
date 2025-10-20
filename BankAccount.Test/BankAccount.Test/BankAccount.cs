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

    [Fact]
    public void Si_Cliente_Hace_Retiro_Debe_Retornar_El_Valor_Retirado(int amount)
    {
        var account = new AccountService();

        var result = account.withdraw(amount);

        result.Should().Be(amount);
    }
}

public class AccountService
{
    public object deposit(int amount)
    {
        return amount;
    }
}