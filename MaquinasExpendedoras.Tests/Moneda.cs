namespace MaquinasExpendedoras.Tests;

public abstract class Moneda
{
    public abstract int Valor { get; }
    
    public sealed class Nickel : Moneda
    {
        public override int Valor => 5;
    }
    
    public sealed class Penny : Moneda
    {
        public override int Valor => 1;
    }
    
    public sealed class Quarter : Moneda
    {
        public override int Valor => 25;
    }
    public sealed class Dime : Moneda
    {
        public override int Valor => 10;
    }
    

    private Moneda()
    {
        
    }
}