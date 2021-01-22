using System.Collections.Generic;

namespace src.Entities
{
    class Aluno : Usuario
    {
        public List<Curso> Cursos { get; private set; }

        public Aluno(int id, string nome) : base(id, nome)
        {
        }
    }
}
