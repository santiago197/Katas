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

    [Theory]
    [InlineData(-500, "14/01/2012", 2500)]
    [InlineData(2000, "13/01/2012", 3000)]
    [InlineData(1000, "10/01/2012", 1000)]
    public void Si_Cliente_Solicita_Extracto_Debe_Retornar_Movimientos(int amount, string date, int balance)
    {
        //Arrange
        var account = new AccountService();
        var expectedOutput = $@"Date     || Amount || Balance
        {date} || {amount}   || {balance}";
        //Act
        var extract = account.printStatement(amount, date, balance);
        //Assert
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

    public string printStatement(int amount, string date, int balance)
    {
        var expectedOutput = $@"Date     || Amount || Balance
        {date} || {amount}   || {balance}";
        
        return expectedOutput;
    }
}