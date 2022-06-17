using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.Teste._Builder;
using CursoOnline.Dominio.Teste._Util;
using ExpectedObjects;
using Xunit.Abstractions;

namespace CursoOnline.Dominio.Teste.CursosTeste
{
    public class CursoTeste : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private string _nome;
        private double _cargaHoraria;
        private PublicoAlvo _publicoAlvo;
        private double _valor;
        private string _descricao;

        public CursoTeste(ITestOutputHelper output)
        {
            _output = output;
            _output.WriteLine("Construtor sendo executado");
            var oFaker = new Faker();

            _nome = oFaker.Random.Word();
            _cargaHoraria = oFaker.Random.Double(50, 1000);
            _publicoAlvo = PublicoAlvo.Estudante;
            _valor = oFaker.Random.Double(0.01, 1000);
            _descricao = oFaker.Lorem.Paragraph();
        }

        public void Dispose()
        {
            _output.WriteLine("Dispose sendo executado");
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Nome = _nome,
                CargaHoraria = _cargaHoraria,
                PublicoAlvo = _publicoAlvo,
                Valor = _valor,
                Descricao = _descricao
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);
            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TheoryNaoDeveCursoTerUmNomeVazioNulo(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                 CursoBuilder.Novo().ComNome(nomeInvalido).Build())
                 .ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQueUm(double cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(() =>
                     CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build())
                 .ComMensagem("Carga horária inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        [InlineData(-100)]
        public void NaoDeveCursoTerUmValorMenorQueUm(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(() =>
                     CursoBuilder.Novo().ComValor(valorInvalido).Build())
                 .ComMensagem("Valor inválido");
        }


    }
}
