namespace CursoOnline.Dominio.Teste
{
    public class MeuPrimeiroTeste
    {
        [Fact(DisplayName = "V1IgualV2")]
        public void V1IgualV2()
        {
            //Arrange (Organização)
            int v1 = 1;
            int v2 = 2;
           
            //Act (Ação)
            v2 = v1;

            //Assert (Acerto)
            Assert.Equal(v1, v2);
        }

        [Fact(DisplayName = "V1DiferenteV2")]
        public void V1DiferenteV2()
        {
            //Arrange
            int v1 = 1;
            int v2 = 1;

            //Act
            v2 = 5;

            //Assert
            Assert.False(v1 == v2);
        }
    }
}