using System;
using System.IO;

namespace EditorDeTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            short opcao;

            Console.Clear();
            Console.WriteLine("O que deseja fazer? ");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            opcao = short.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;
                case 1: 
                    Abrir();
                    break;
                case 2: 
                    Criar();
                    break;
                default: 
                    Menu();
                    break;
            }

            static void Abrir()
            {
                Console.Clear();
                Console.WriteLine("Qual caminho do arquivo?");
                string caminho = Console.ReadLine();

                using (var file = new StreamReader(caminho))
                {
                    string text = file.ReadToEnd();
                    Console.WriteLine(text);
                }
                Console.WriteLine("");
                Console.ReadLine();
                Menu();

            }

            static void Criar()
            {
                Console.Clear();
                Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
                Console.WriteLine("-----------------------------");
                string texto = "";

                do
                {
                    texto += Console.ReadLine();
                    texto += Environment.NewLine;
                }
                while (Console.ReadKey().Key != ConsoleKey.Escape);

                Salvar(texto);
            }

            static void Salvar(string texto)
            {
                Console.Clear();
                Console.WriteLine("Qual caminho para salvar o arquivo??");
                var caminho = Console.ReadLine();

                //metodo USING para abrir e fechar objeto
                using (var file = new StreamWriter(caminho))
                {
                    file.Write(texto);
                }
                Console.WriteLine($"Arquivo {caminho} salvo com sucesso!!");
                Console.ReadLine();
                Menu();
            }
        }
    }
}
