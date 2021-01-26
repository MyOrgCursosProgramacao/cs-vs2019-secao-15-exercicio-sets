using src.Entities;
using System;
using System.Collections.Generic;

namespace src.Services
{
    class ServicosCadastros
    {
        public static void NovoAluno(SortedSet<Aluno> alunos, SortedSet<Instrutor> instrutores, SortedSet<Curso> cursos)
        {
            Console.Write("Digite a id do aluno: ");
            int id = int.Parse(Console.ReadLine());
            bool novo = true;
            foreach (Aluno aluno in alunos)
            {
                if (id == aluno.Id)
                {
                    Console.WriteLine($"Já existe um aluno com id {id}");
                    Console.ReadLine();
                    novo = false;
                }
            }
            if (novo)
            {
                Console.Write("Nome do aluno: ");
                string nome = Console.ReadLine();
                Aluno aluno = new Aluno(id, nome);
                alunos.Add(aluno);
                char resposta = 's';
                while (resposta == 's')
                {
                    Console.Write("Deseja matricular o aluno nos cursos disponíveis (s/n)? ");
                    resposta = Console.ReadLine()[0];
                    if (resposta == 's')
                    {
                        Console.WriteLine("Cursos disponíveis");
                        foreach (Curso curso in cursos)
                        {
                            Console.WriteLine($"\t{curso.Id}, {curso.Nome}");
                        }
                        Console.Write("Digite a id do curso desejado: ");
                        int idMatricula = int.Parse(Console.ReadLine());
                        bool matricula = false;
                        foreach (Curso curso in cursos)
                        {
                            if (idMatricula == curso.Id)
                            {
                                aluno.AddCurso(curso);
                                matricula = true;
                            }
                        }
                        if (!matricula)
                        {
                            Console.WriteLine("Curso inexistente");
                        }
                        else
                        {
                            aluno.ConsultaAluno();
                        }
                    }
                }
            }
        }

        public static void EditarAluno(SortedSet<Aluno> alunos, SortedSet<Instrutor> instrutores, SortedSet<Curso> cursos)
        {
            Console.WriteLine($"{alunos.Count} alunos cadastrados:");
            Console.WriteLine();
            foreach (Aluno aluno in alunos)
            {
                aluno.ConsultaAluno();
                Console.WriteLine();
            }
            Console.Write("Id do aluno: ");
            int id = int.Parse(Console.ReadLine());
            bool novo = false;
            foreach (Aluno aluno in alunos)
            {
                if (id == aluno.Id)
                {
                    novo = true;
                    Console.Write("Digite o nome do aluno: ");
                    aluno.SetNome(Console.ReadLine());
                    Console.Write("Deseja matricular o aluno nos cursos disponíveis (s/n)? ");
                    char resposta = Console.ReadLine()[0];
                    if (resposta == 's')
                    {
                        Console.WriteLine("Cursos disponíveis");
                        foreach (Curso curso in cursos)
                        {
                            Console.WriteLine($"\t{curso.Id}, {curso.Nome}");
                        }
                        Console.Write("Digite a id do curso desejado: ");
                        int idMatricula = int.Parse(Console.ReadLine());
                        bool matricula = false;
                        foreach (Curso curso in cursos)
                        {
                            if (idMatricula == curso.Id)
                            {
                                aluno.AddCurso(curso);
                                matricula = true;
                            }
                        }
                        if (!matricula)
                        {
                            Console.WriteLine("Curso inexistente");
                        }
                        else
                        {
                            aluno.ConsultaAluno();
                        }
                    }
                }
            }
            if (!novo)
            {
                Console.WriteLine("Não existe aluno com essa Id.");
                Console.WriteLine();
            }
        }

        public static void RemoverAluno(SortedSet<Aluno> alunos, SortedSet<Instrutor> instrutores, SortedSet<Curso> cursos)
        {
            Console.Write("Digite a id do aluno: ");
            int id = int.Parse(Console.ReadLine());
            bool removido = false;
            Aluno remAluno = new Aluno();
            foreach (Aluno aluno in alunos)
            {
                if (id == aluno.Id)
                {
                    remAluno = aluno;
                    removido = true;
                }
            }
            if (removido)
            {
                Console.WriteLine($"Aluno {remAluno.Id}, {remAluno.Nome} removido.");
                foreach (Curso curso in cursos)
                {
                    if (curso.Alunos.Contains(remAluno))
                    {
                        curso.Alunos.Remove(remAluno);
                    }
                }
                alunos.Remove(remAluno);
            }
            else
            {
                Console.WriteLine("Id inexistente.");
            }
        }


        public static void NovoInstrutor(SortedSet<Aluno> alunos, SortedSet<Instrutor> instrutores, SortedSet<Curso> cursos)
        {
            Console.Write("Digite a id do instrutor: ");
            int id = int.Parse(Console.ReadLine());
            bool novo = true;
            foreach (Instrutor instrutor in instrutores)
            {
                if (id == instrutor.Id)
                {
                    Console.WriteLine($"Já existe um instrutor com id {id}");
                    Console.ReadLine();
                    novo = false;
                }
            }
            if (novo)
            {
                Console.Write("Nome do instrutor: ");
                string nome = Console.ReadLine();
                Instrutor instrutor = new Instrutor(id, nome);
                instrutores.Add(instrutor);
                char resposta = 's';
                while (resposta == 's')
                {
                    Console.Write("Deseja inscrever o instrutor em algum curso (s/n)? ");
                    resposta = Console.ReadLine()[0];
                    if (resposta == 's')
                    {
                        Console.WriteLine("Cursos disponíveis");
                        foreach (Curso curso in cursos)
                        {
                            Console.WriteLine($"\t{curso.Id}, {curso.Nome}");
                        }
                        Console.Write("Digite a id do curso desejado: ");
                        int idMatricula = int.Parse(Console.ReadLine());
                        bool matricula = false;
                        foreach (Curso curso in cursos)
                        {
                            if (idMatricula == curso.Id)
                            {
                                instrutor.AddCursoMinistrado(curso);
                                curso.SetInstrutor(instrutor);
                                matricula = true;
                            }
                        }
                        if (!matricula)
                        {
                            Console.WriteLine("Curso inexistente");
                        }
                        else
                        {
                            instrutor.ConsultaInstrutor();
                        }
                    }
                }
            }
        }

        public static void EditarInstrutor(SortedSet<Aluno> alunos, SortedSet<Instrutor> instrutores, SortedSet<Curso> cursos)
        {
            Console.WriteLine($"{instrutores.Count} instrutores cadastrados:");
            Console.WriteLine();
            foreach (Instrutor instrutor in instrutores)
            {
                instrutor.ConsultaInstrutor();
                Console.WriteLine();
            }
            Console.Write("Id do instrutor: ");
            int id = int.Parse(Console.ReadLine());
            bool novo = false;
            foreach (Instrutor instrutor in instrutores)
            {
                if (id == instrutor.Id)
                {
                    novo = true;
                    Console.Write("Digite o nome do instrutor: ");
                    instrutor.SetNome(Console.ReadLine());
                    Console.Write("Deseja inscrever o instrutor nos cursos disponíveis (s/n)? ");
                    char resposta = Console.ReadLine()[0];
                    if (resposta == 's')
                    {
                        Console.WriteLine("Cursos disponíveis");
                        foreach (Curso curso in cursos)
                        {
                            Console.WriteLine($"\t{curso.Id}, {curso.Nome}");
                        }
                        Console.Write("Digite a id do curso desejado: ");
                        int idMatricula = int.Parse(Console.ReadLine());
                        bool matricula = false;
                        foreach (Curso curso in cursos)
                        {
                            if (idMatricula == curso.Id)
                            {
                                instrutor.AddCursoMinistrado(curso);
                                curso.SetInstrutor(instrutor);
                                matricula = true;
                            }
                        }
                        if (!matricula)
                        {
                            Console.WriteLine("Curso inexistente");
                        }
                        else
                        {
                            instrutor.ConsultaInstrutor();
                        }
                    }
                }
            }
            if (!novo)
            {
                Console.WriteLine("Não existe instrutor com essa Id.");
                Console.WriteLine();
            }
        }

        public static void RemoverInstrutor(SortedSet<Aluno> alunos, SortedSet<Instrutor> instrutores, SortedSet<Curso> cursos)
        {
            Console.Write("Digite a id do instrutor: ");
            int id = int.Parse(Console.ReadLine());
            bool removido = false;
            Instrutor remInstrutor = new Instrutor();
            foreach (Instrutor instrutor in instrutores)
            {
                if (id == instrutor.Id)
                {
                    remInstrutor = instrutor;
                    removido = true;
                }
            }
            if (removido)
            {
                Console.WriteLine($"Aluno {remInstrutor.Id}, {remInstrutor.Nome} removido.");
                foreach (Curso curso in cursos)
                {
                    if (curso.Instrutor == remInstrutor)
                    {
                        curso.SetInstrutor(null);
                    }
                }
                instrutores.Remove(remInstrutor);
            }
            else
            {
                Console.WriteLine("Id inexistente.");
            }
        }

        internal static void ConsultarInstrutor(SortedSet<Aluno> alunos, SortedSet<Instrutor> instrutores, SortedSet<Curso> cursos)
        {
            Console.WriteLine($"{instrutores.Count} instrutores cadastrados:");
            Console.WriteLine();
            foreach (Instrutor instrutor in instrutores)
            {
                instrutor.ConsultaInstrutor();
                Console.WriteLine();
            }
            Console.Write("Id do instrutor: ");
            int id = int.Parse(Console.ReadLine());
            bool existe = false;
            foreach (Instrutor instrutor in instrutores)
            {
                if (id == instrutor.Id)
                {
                    existe = true;

                    Console.Clear();
                    Console.WriteLine();
                    instrutor.ConsultaInstrutor();
                    SortedSet<Aluno> alunosInstrutor = new SortedSet<Aluno>();
                    foreach(Curso curso in instrutor.CursosMinistrados)
                    {
                        alunosInstrutor.UnionWith(curso.Alunos);
                    }
                    Console.WriteLine($"O instrutor {instrutor.Nome} tem {alunosInstrutor.Count} alunos.");
                    foreach (Aluno x in alunosInstrutor)
                    {
                        Console.WriteLine($"{x.Id}, {x.Nome}");
                    }
                }
            }
            if (!existe)
            {
                Console.WriteLine("Não existe instrutor com essa Id.");
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public static void NovoCurso(SortedSet<Aluno> alunos, SortedSet<Instrutor> instrutores, SortedSet<Curso> cursos)
        {
            Console.Write("Digite a id do curso: ");
            int id = int.Parse(Console.ReadLine());
            bool novo = true;
            foreach (Curso curso in cursos)
            {
                if (id == curso.Id)
                {
                    Console.WriteLine($"Já existe um curso com id {id}");
                    Console.ReadLine();
                    novo = false;
                }
            }
            if (novo)
            {
                Console.Write("Nome do curso: ");
                string nome = Console.ReadLine();
                Curso curso = new Curso(id, nome);
                cursos.Add(curso);
                char resposta = 's';
                while (resposta == 's')
                {
                    Console.Write("Deseja inscrever um instrutor nesse curso (s/n)? ");
                    resposta = Console.ReadLine()[0];
                    if (resposta == 's')
                    {
                        Console.WriteLine("Instrutores disponíveis");
                        foreach (Instrutor instrutor in instrutores)
                        {
                            Console.WriteLine($"\t{instrutor.Id}, {instrutor.Nome}");
                        }
                        Console.Write("Digite a id do instrutor: ");
                        int idMatricula = int.Parse(Console.ReadLine());
                        bool matricula = false;
                        foreach (Instrutor instrutor in instrutores)
                        {
                            if (idMatricula == instrutor.Id)
                            {
                                instrutor.AddCursoMinistrado(curso);
                                curso.SetInstrutor(instrutor);
                                matricula = true;
                            }
                        }
                        if (!matricula)
                        {
                            Console.WriteLine("Instrutor inexistente");
                        }
                        else
                        {
                            curso.ConsultaCurso();
                        }
                    }
                }
            }
        }
    }
}
