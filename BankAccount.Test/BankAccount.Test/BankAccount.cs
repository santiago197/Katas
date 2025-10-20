using FluentAssertions;

namespace BankAccount.Test;

public class BankAccount
{
    [Fact]
    public void Si_Cliente_Hace_Deposito_De_1000_Debe_Retornar_1000()
    {
        //Arrange
        var account = new AccountService();
        var deposit = 1000;
        
        //Act
        var result = account.deposit();
        //Assert
        result.Should().Be(1000);
    }
}

public class AccountService
{
    public object deposit()
    {
        return 1000;
    }
}