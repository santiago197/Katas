namespace MaquinasExpendedoras.Tests;

public abstract class Producto
{
    public abstract decimal Precio { get; }
    public sealed class CocaCola : Producto
    {
        public override decimal Precio => 100;
    }
    public sealed class Chips : Producto
    {
        public override decimal Precio => 50;
    }
    public sealed class Caramelo : Producto
    {
        public override decimal Precio => 65;
    }
    

    private Producto()
    {
        
    }
}