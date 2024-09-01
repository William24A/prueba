using Xunit;
using Tienda;

public class ProgramTest
{
    [Fact]
    public void Suma()
    {
        Pruebas prueb = new Pruebas("William");

        var result = prueb.Suma(2,3);

        Assert.Equal(4,result);
    } 

}