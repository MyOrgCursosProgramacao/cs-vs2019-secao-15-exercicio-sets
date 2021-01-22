using System.Collections.Generic;

namespace src.Entities
{
    class Instrutor : Usuario
    {
        public List<Curso> CursosMinistrados { get; private set; }

        public Instrutor(int id, string nome) : base(id, nome)
        {
            CursosMinistrados = null;
        }

        public void AddCursoMinistrado(Curso curso)
        {
            CursosMinistrados.Add(curso);
        }
    }
}