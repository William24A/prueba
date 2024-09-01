using Xunit;
using MisPruebas;

public class ProgramTest
{
    [Fact]
    public void Suma()
    {
        Pruebas prueb = new Pruebas("William");

        var result = prueb.Suma(2,3);

        Assert.Equal(5,result);
    } 

}