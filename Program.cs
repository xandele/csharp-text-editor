using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que você deseja fazer?");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());
            switch(option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Open(); break;
                case 2: Edit(); break;
                default: Menu(); break;
            }
        }

        static void Open() 
        {
            Console.Clear();
            Console.WriteLine("Qual caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Edit()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("----------------");
            string text = "";

            do 
            {
                text += Console.ReadLine(); // aqui acontece uma quebra de linha no final da leitura
                text += Environment.NewLine; // e aqui ele cria uma nova linha
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape); // Console.ReadKey().Key aqui estamos dizendo que ele pode continuar rodando independente da tecla digitada, mas quando apertar a tecla ESC ele ativara o comando seguinte ConsoleKey.Escape (é a tecla ESC) fazendo com que saia da tela do texto

            Save(text);
        }

        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using(var file = new StreamWriter(path))
            {
                file.WriteLine(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu();
        }
    }
}