namespace CursoOnline.Dominio.Cursos
{
    public class Curso
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
        public double Valor { get; private set; }

        public Curso(string _Nome, string _Descricao, double _CargaHoraria, PublicoAlvo _PublicoAlvo, double _Valor)
        {
            if (string.IsNullOrEmpty(_Nome))
            {
                throw new ArgumentException("Nome inválido");
            }
            if (_CargaHoraria < 1)
            {
                throw new ArgumentException("Carga horária inválida");
            }
            if (_Valor < 1)
            {
                throw new ArgumentException("Valor inválido");
            }
            Nome = _Nome;
            Descricao = _Descricao;
            CargaHoraria = _CargaHoraria;
            PublicoAlvo = _PublicoAlvo;
            Valor = _Valor;

        }


    }



}