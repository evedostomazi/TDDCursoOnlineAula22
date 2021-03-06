using CursoOnline.Dominio.Cursos;

namespace CursoOnline.Dominio.Teste.Cursos
{
    public interface ICursoRepositorio
    {
        void Adicionar(Curso curso);

        void Atualizar(Curso curso);
        Curso ObterPeloNome(string nome);
    }
}
