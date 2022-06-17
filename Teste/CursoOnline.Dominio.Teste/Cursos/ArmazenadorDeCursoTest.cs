using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.Dominio.Teste._Builder;
using CursoOnline.Dominio.Teste._Util;
using Moq;

namespace CursoOnline.Dominio.Teste.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        private readonly CursoDto _cursoDto;
        private readonly Mock<ICursoRepositorio> _cursoRepositorioMock;
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;

        public ArmazenadorDeCursoTest()
        {
            var oFake = new Faker();
            _cursoDto = new CursoDto
            {
                Nome = oFake.Random.Word(),
                Descricao = oFake.Lorem.Paragraph(),
                CargaHoraria = oFake.Random.Double(0.01, 1000),
                PublicoAlvo = "Estudante",
                Valor = 950
            };
            _cursoRepositorioMock = new Mock<ICursoRepositorio>();
            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            _armazenadorDeCurso.Armazenar(_cursoDto);
            //cursoRepositorioMock.Verify(x => x.Adicionar(It.IsAny<Curso>()));
            _cursoRepositorioMock.Verify(x => x.Adicionar(
                It.Is<Curso>(
                    x => x.Nome == _cursoDto.Nome &&
                    x.Descricao == _cursoDto.Descricao
                    )));
        }

        [Fact]
        public void NaoDeveAdicionarComPublicoAlvoInvalido()
        {
            var publicoAlvoInvalido = "Médico";
            _cursoDto.PublicoAlvo = publicoAlvoInvalido;
            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto))
            .ComMensagem("Publico Alvo inválido");
        }

        [Fact]
        public void NaoDeveAdicionarCursoComNomeIgualDeOutroSalvo()
        {
            var cursoJaSalvo = CursoBuilder.Novo().ComNome(_cursoDto.Nome).Build();
            _cursoRepositorioMock.Setup(x => x.ObterPeloNome(_cursoDto.Nome)).Returns(cursoJaSalvo);
            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDto))
            .ComMensagem("Nome do curso já consta no banco de dados");
        }
    }
}
