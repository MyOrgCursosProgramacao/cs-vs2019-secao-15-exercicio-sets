using System;
using System.Collections.Generic;
using System.Text;

namespace src.Entities
{
    class Curso
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public SortedSet<Aluno> Alunos { get; private set; }
        public Instrutor Instrutor { get; private set; }

        public Curso(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Alunos = null;
            Instrutor = null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Id + ", " + Nome);
            if (Instrutor != null)
            {
                sb.AppendLine("Instrutor: " + Instrutor);
            }
            if (Alunos != null)
            {
                sb.AppendLine("Alunos matriculados");
                foreach (Usuario aluno in Alunos)
                {
                    sb.AppendLine(aluno.ToString());
                }
            }

            return sb.ToString();
        }
    }
}
