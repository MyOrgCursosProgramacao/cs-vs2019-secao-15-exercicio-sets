using System.Collections.Generic;

namespace src.Entities
{
    class Aluno : Usuario
    {
        public SortedSet<Curso> Cursos { get; private set; }

        public Aluno() : base()
        {
        }

        public Aluno(int id, string nome) : base(id, nome)
        {
           Cursos = new SortedSet<Curso>();
        }

        public void AddCurso(Curso curso)
        {
            Cursos.Add(curso);
        }

        public void ConsultaAluno()
        {
            System.Console.WriteLine($"Aluno: {Id}, {Nome}");
            System.Console.WriteLine($"Cursos matriculados: {Cursos.Count}");
            foreach(Curso curso in Cursos)
            {
                System.Console.WriteLine($"\t{curso.Id}, {curso.Nome}");
            }
        }
    }
}
