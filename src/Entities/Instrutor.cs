using System;
using System.Collections.Generic;

namespace src.Entities
{
    class Instrutor : Usuario
    {
        public SortedSet<Curso> CursosMinistrados { get; private set; }

        public Instrutor() : base()
        {
        }

        public Instrutor(int id, string nome) : base(id, nome)
        {
            CursosMinistrados = new SortedSet<Curso>();
        }

        public void AddCursoMinistrado(Curso curso)
        {
            CursosMinistrados.Add(curso);
        }

        public void ConsultaInstrutor()
        {
            Console.WriteLine($"Instrutor: {Id}, {Nome}");
            System.Console.WriteLine($"Ministrando {CursosMinistrados.Count} cursos");
            foreach(Curso curso in CursosMinistrados)
            {
                Console.WriteLine($"\t{curso.Id}, {curso.Nome}");
            }
        }
    }
}