using src.Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPasta = @"C:\Users\alvar\OneDrive\Workspaces\ws-vs2019\cs-vs2019-secao-15-exercicio-sets\io\";

            FileStream fsAlunos = null;
            StreamReader srAlunos = null;
            StreamWriter swAlunos = null;
            SortedSet<Aluno> alunos = new SortedSet<Aluno>();
            string inputAlunos = @"inputAlunos.txt";

            FileStream fsCursos = null;
            StreamReader srCursos = null;
            StreamWriter swCursos = null;
            SortedSet<Curso> cursos = new SortedSet<Curso>();
            string inputCursos = @"inputCursos.txt";

            FileStream fsInstrutores = null;
            StreamReader srInstrutores = null;
            StreamWriter swInstrutores = null;
            SortedSet<Instrutor> instrutores = new SortedSet<Instrutor>();
            string inputInstrutores = @"inputInstutores.txt";

            try
            {
                // Leitura dos alunos
                fsAlunos = new FileStream(inputPasta + inputAlunos, FileMode.OpenOrCreate);
                srAlunos = new StreamReader(fsAlunos);
                while (!srAlunos.EndOfStream)
                {
                    string[] linha = srAlunos.ReadLine().Split(',');
                    int id = int.Parse(linha[0]);
                    string nome = linha[1];
                    Aluno aluno = new Aluno(id, nome);

                    for (int i = 2; i < linha.Length; i++)
                    {
                        int cursoId = int.Parse(linha[i]);
                        aluno.AddCurso(new Curso(cursoId, "Temp"));
                    }
                    alunos.Add(aluno);
                }
                // Fim da leitura dos alunos

                // Leitura dos cursos
                fsCursos = new FileStream(inputPasta + inputCursos, FileMode.OpenOrCreate);
                srCursos = new StreamReader(fsCursos);
                while (!srCursos.EndOfStream)
                {
                    string[] linha = srCursos.ReadLine().Split(',');
                    int id = int.Parse(linha[0]);
                    string nome = linha[1];
                    int idInstrutor = int.Parse(linha[2]);
                    Curso curso = new Curso(id, nome);
                    for (int i = 3; i < linha.Length; i++)
                    {
                        int alunoId = int.Parse(linha[i]);
                        foreach (Aluno aluno in alunos)
                        {
                            if (alunoId == aluno.Id)
                            {
                                curso.AddAluno(new Aluno(aluno.Id, aluno.Nome));
                                foreach (Curso cursoX in aluno.Cursos)
                                {
                                    if (id == cursoX.Id)
                                    {
                                        cursoX.SetNome(nome);
                                    }
                                }
                            }
                        }
                    }
                    cursos.Add(curso);
                }
                // Fim da leitura dos cursos

                // Leitura dos instrutores
                fsInstrutores = new FileStream(inputPasta + inputInstrutores, FileMode.OpenOrCreate);
                srInstrutores = new StreamReader(fsInstrutores);
                while (!srInstrutores.EndOfStream)
                {
                    string[] linha = srInstrutores.ReadLine().Split(',');
                    int id = int.Parse(linha[0]);
                    string nome = linha[1];
                    Instrutor instrutor = new Instrutor(id, nome);

                    for (int i = 2; i < linha.Length; i++)
                    {
                        int cursoId = int.Parse(linha[i]);
                        foreach (Curso curso in cursos)
                        {
                            if (cursoId == curso.Id)
                            {
                                curso.SetInstrutor(instrutor);
                                instrutor.AddCursoMinistrado(curso);
                            }
                        }

                    }
                    instrutores.Add(instrutor);
                }
                // Fim da leitura dos instrutores
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                if (srAlunos != null) srAlunos.Close();

                if (srCursos != null) srCursos.Close();

                if (srInstrutores != null) srInstrutores.Close();
            }

            bool loop = true;
            while (loop)
            {
                //Console.Clear();
                Console.WriteLine("====  Seção 15: Exercícios sets  ====");
                Console.WriteLine();
                loop = Tela.MenuPrincipal(alunos, instrutores, cursos);
            }

            try
            {
                fsAlunos = new FileStream(inputPasta + inputAlunos, FileMode.Create);
                using (swAlunos = new StreamWriter(fsAlunos))
                {
                    foreach (Aluno aluno in alunos)
                    {
                        swAlunos.Write($"{aluno.Id},{aluno.Nome}");
                        foreach (Curso cursoAluno in aluno.Cursos)
                        {
                            swAlunos.Write($",{cursoAluno.Id}");
                        }
                        swAlunos.WriteLine();
                    }
                }

                fsInstrutores = new FileStream(inputPasta + inputInstrutores, FileMode.Create);
                using (swInstrutores = new StreamWriter(fsInstrutores))
                {
                    foreach (Instrutor instrutor in instrutores)
                    {
                        swInstrutores.Write($"{instrutor.Id},{instrutor.Nome}");
                        foreach (Curso cursoInstrutor in instrutor.CursosMinistrados)
                        {
                            swInstrutores.Write($",{cursoInstrutor.Id}");
                        }
                        swInstrutores.WriteLine();
                    }
                }

                fsCursos = new FileStream(inputPasta + inputCursos, FileMode.Create);
                using (swCursos = new StreamWriter(fsCursos))
                {
                    foreach (Curso curso in cursos)
                    {
                        swCursos.Write($"{curso.Id},{curso.Nome},{curso.Instrutor.Id}");
                        foreach (Aluno cursoAluno in curso.Alunos)
                        {
                            swCursos.Write($",{cursoAluno.Id}");
                        }
                        swCursos.WriteLine();
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                if (fsAlunos != null) fsAlunos.Close();
                if (swAlunos != null) swAlunos.Close();

                if (fsCursos != null) fsCursos.Close();
                if (swCursos != null) swCursos.Close();

                if (fsInstrutores != null) fsInstrutores.Close();
                if (swInstrutores != null) swInstrutores.Close();
            }


        }
    }
}
