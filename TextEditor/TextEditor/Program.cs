using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    internal class Program
    {
        static void ExibirTexto(string arquivo)
        {
            try
            {
                string line = "";
                StreamReader sr = new StreamReader(arquivo);
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Mensagem: " + "Arquivo esta em branco ou não existe");
            }
            Console.ReadKey();
        }

        static void GravarTexto(string arquivo,string texto,bool incrementar)
        {
            try
            {
                StreamWriter sr = new StreamWriter(arquivo, incrementar);
                sr.WriteLine(texto);
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.ReadKey();
            }
        }
        static int ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("Editor de texto");
            Console.WriteLine("Abrir/criar um arquivo (1)");
            Console.WriteLine("Exibir texto do arquivo (2)");
            Console.WriteLine("Criar um arquivo com um novo texto (3)");
            Console.WriteLine("Adicionar um novo texto no arquivo (4)");
            Console.WriteLine("Sair (5)");

            Console.Write("Opção: ");
            int op = Convert.ToInt32(Console.ReadLine());
            return op;
        }
        static void Main(string[] args)
        {
            int op = 0; //menu
            string arquivo = ""; //arquivo texto
            string texto = "";
            while (op !=5)
            {
                op = ExibirMenu();
                Console.Clear();
                //Abrir o arquivo
                switch (op)
                {
                    case 1:
                        Console.Write("Informe o nome do arquivo: ");
                        arquivo = Console.ReadLine();
                        break;
                    case 2:
                        ExibirTexto(arquivo);
                        break;
                    case 3:
                        Console.Write("Informe o texto: ");
                        texto = Console.ReadLine();
                        GravarTexto(arquivo, texto, false);
                        ExibirTexto(arquivo);
                        break;
                    case 4:
                        Console.Write("Informe o texto: ");
                        texto = Console.ReadLine();
                        GravarTexto(arquivo, texto, true);
                        ExibirTexto(arquivo);
                        break;
                }
            }
        }
    }
}
