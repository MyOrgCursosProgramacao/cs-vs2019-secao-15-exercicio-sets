using src.Services;
using System;
using System.Collections.Generic;

namespace src.Entities
{
    class Tela
    {
        public static bool MenuPrincipal(SortedSet<Aluno> alunos, SortedSet<Instrutor> instrutores, SortedSet<Curso> cursos)
        {
            bool loop = true;

            Console.WriteLine("Menu de opções:");
            Console.WriteLine();
            Console.WriteLine("\t1) Consultar alunos");
            Console.WriteLine("\t2) Consultar instrutores");
            Console.WriteLine("\t3) Consultar cursos");
            Console.WriteLine("\t0) Sair");
            Console.WriteLine();

            Console.Write("Digite a opção: ");


            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Console.WriteLine();
                    MenuAlunos(alunos, instrutores, cursos);
                    break;

                case 2:
                    Console.WriteLine();
                    MenuInstrutores(alunos, instrutores, cursos);
                    break;

                case 3:
                    Console.WriteLine();
                    MenuCursos(alunos, instrutores, cursos);
                    break;

                case 0:
                    Console.WriteLine("Sair!");
                    loop = false;
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Opção inválida");
                    Console.ReadKey();
                    break;
            }
            return loop;
        }

        public static void MenuAlunos(SortedSet<Aluno> alunos, SortedSet<Instrutor> instrutores, SortedSet<Curso> cursos)
        {
            Console.WriteLine($"{alunos.Count} alunos cadastrados:");
            Console.WriteLine();
            foreach (Aluno aluno in alunos)
            {
                aluno.ConsultaAluno();
                Console.WriteLine();
            }

            bool voltar = false;

            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"Alunos matriculados: {alunos.Count}");
                Console.WriteLine();
                foreach (Aluno aluno in alunos)
                {
                    Console.WriteLine($"{aluno.Id}, {aluno.Nome}");
                }
                Console.WriteLine();
                Console.WriteLine("Menu de opções:");
                Console.WriteLine();
                Console.WriteLine("\t1) Adicionar aluno");
                Console.WriteLine("\t2) Editar aluno");
                Console.WriteLine("\t3) Remover aluno");
                Console.WriteLine("\t0) Voltar");
                Console.WriteLine();

                Console.Write("Digite a opção: ");


                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine();
                        ServicosCadastros.NovoAluno(alunos, instrutores, cursos);
                        break;
                    case 2:
                        ServicosCadastros.EditarAluno(alunos, instrutores, cursos);
                        break;
                    case 3:
                        ServicosCadastros.RemoverAluno(alunos, instrutores, cursos);
                        break;
                    case 0:
                        voltar = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public static void MenuInstrutores(SortedSet<Aluno> alunos, SortedSet<Instrutor> instrutores, SortedSet<Curso> cursos)
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"{instrutores.Count} instrutores cadastrados.");
                Console.WriteLine();
                foreach (Instrutor instrutor in instrutores)
                {
                    Console.WriteLine($"{instrutor.Id}, {instrutor.Nome}");
                }
                Console.WriteLine();
                Console.WriteLine("Menu de opções:");
                Console.WriteLine();
                Console.WriteLine("\t1) Adicionar instrutor");
                Console.WriteLine("\t2) Editar instrutor");
                Console.WriteLine("\t3) Remover instrutor");
                Console.WriteLine("\t4) Consultar instrutor");
                Console.WriteLine("\t0) Voltar");
                Console.WriteLine();

                Console.Write("Digite a opção: ");


                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine();
                        ServicosCadastros.NovoInstrutor(alunos, instrutores, cursos);
                        break;
                    case 2:
                        ServicosCadastros.EditarInstrutor(alunos, instrutores, cursos);
                        break;
                    case 3:
                        ServicosCadastros.RemoverInstrutor(alunos, instrutores, cursos);
                        break;
                    case 4:
                        ServicosCadastros.ConsultarInstrutor(alunos, instrutores, cursos);
                        break;
                    case 0:
                        voltar = true;
                        break;
                    default:
                        break;
                }
            }
        }

        public static void MenuCursos(SortedSet<Aluno> alunos, SortedSet<Instrutor> instrutores, SortedSet<Curso> cursos)
        {
            bool voltar = false;
            while (!voltar)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"{cursos.Count} cursos cadastrados.");
                Console.WriteLine();
                foreach (Curso curso in cursos)
                {
                    Console.WriteLine($"{curso.Id}, {curso.Nome}");
                }
                Console.WriteLine();
                Console.WriteLine("Menu de opções:");
                Console.WriteLine();
                Console.WriteLine("\t1) Adicionar curso");
                Console.WriteLine("\t2) Editar curso");
                Console.WriteLine("\t3) Remover curso");
                Console.WriteLine("\t4) Consultar curso");
                Console.WriteLine("\t0) Voltar");
                Console.WriteLine();

                Console.Write("Digite a opção: ");

                int opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine();
                        ServicosCadastros.NovoCurso(alunos, instrutores, cursos);
                        break;
                    case 0:
                        voltar = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
