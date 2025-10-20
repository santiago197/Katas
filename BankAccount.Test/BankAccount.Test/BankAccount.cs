namespace BankAccount.Test;

public class BankAccount
{
    [Fact]
    public void Si_Cliente_Hace_Deposito_De_1000_Debe_Retornar_1000()
    {
        //Arrange
        var account = new BankAccount();
        var deposit = 1000;
        
        //Act
        var result = account.deposit();
        //Assert
        Assert.Should().Be(1000);
    }
}