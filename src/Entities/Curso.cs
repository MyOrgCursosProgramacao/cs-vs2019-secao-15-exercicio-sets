using System;
using System.Collections.Generic;
using System.Text;

namespace src.Entities
{
    class Curso : IComparable
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public SortedSet<Aluno> Alunos { get; private set; }
        public Instrutor Instrutor { get; private set; }

        public Curso(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Alunos = new SortedSet<Aluno>();
            Instrutor = null;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public void SetInstrutor(Instrutor instrutor)
        {
            Instrutor = instrutor;
        }

        public void AddAluno(Aluno aluno)
        {
            Alunos.Add(aluno);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Curso))
            {
                throw new ArgumentException("O argumento não é do tipo Curso");
            }
            Curso outro = obj as Curso;
            return Id.CompareTo(outro.Id);
        }

        public void ConsultaCurso()
        {
            Console.WriteLine($"Curso: {Id}, {Nome}");
            if (Instrutor != null)
            {
                Console.WriteLine($"Instrutor: {Instrutor.Id}, {Instrutor.Nome}");
            }
            Console.WriteLine($"Alunos cadastrados: {Alunos.Count}");
            foreach(Aluno aluno in Alunos)
            {
                Console.WriteLine($"\t{aluno.Id}, {aluno.Nome}");
            }
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
