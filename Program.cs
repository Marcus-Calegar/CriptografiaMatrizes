using System;

namespace CriptografiaMatrizRefatorado
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string frases = "";
            int[,] chave = new int[2, 2];
            int indice;
            Console.WriteLine("1 - Descriptografar matriz\n2 - Criptografar matriz\n3 - Para sair do programa");
            indice = int.Parse(Console.ReadLine());
            while (true)
            {
                Console.Clear();
                if (indice == 1)
                {
                    frases = "";
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            Console.WriteLine("Chave de criptografia:");
                            Console.Write(frases);
                            chave[i, j] = int.Parse(Console.ReadLine());
                            frases += chave[i, j].ToString() + " ";
                            Console.Clear();
                        }
                        frases += "\n";
                    }

                    frases = "";
                    Console.Write("Numero de Colunas da matriz criptografada: ");
                    int colunas = int.Parse(Console.ReadLine());
                    int[,] criptografado = new int[2, colunas];
                    Console.Clear();

                    Console.WriteLine("Matriz criptografada:");
                    for (int i = 0; i < criptografado.GetLength(0); i++)
                    {
                        for (int j = 0; j < criptografado.GetLength(1); j++)
                        {
                            Console.Write(frases);
                            criptografado[i, j] = int.Parse(Console.ReadLine());
                            frases += criptografado[i, j].ToString() + " ";
                            Console.Clear();
                        }
                        frases += "\n";
                    }
                    Matriz matriz = new Matriz(colunas);
                    matriz.SetChave(chave);
                    matriz.SetMatrizCriptografada(criptografado);
                    int[,] original = matriz.Descriptografar();
                    frases = "Matriz criptografada:\n";
                    for (int i = 0; i < criptografado.GetLength(0); i++)
                    {
                        for (int j = 0; j < criptografado.GetLength(1); j++)
                            frases += criptografado[i, j] + " ";
                        frases += "\n";
                    }
                    frases += "Matriz descriptografada:\n";
                    for (int i = 0; i < original.GetLength(0); i++)
                    {
                        for (int j = 0; j < original.GetLength(1); j++)
                            frases += original[i, j] + " ";
                        frases += "\n";
                    }
                    frases += "Frase: " + matriz.ObterFrase();
                    Console.WriteLine(frases);
                    Console.ReadKey();
                }
                else if (indice == 2)
                {
                    frases = "";
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            Console.WriteLine("Chave de criptografia:");
                            Console.Write(frases);
                            chave[i, j] = int.Parse(Console.ReadLine());
                            frases += chave[i, j].ToString() + " ";
                            Console.Clear();
                        }
                        frases += "\n";
                    }

                    frases = "";
                    Console.Write("Numero de Colunas da matriz descriptografada: ");
                    int colunas = int.Parse(Console.ReadLine());
                    int[,] descriptografada = new int[2, colunas];
                    Console.Clear();

                    Console.WriteLine("Matriz descriptografada:");
                    for (int i = 0; i < descriptografada.GetLength(0); i++)
                    {
                        for (int j = 0; j < descriptografada.GetLength(1); j++)
                        {
                            Console.Write(frases);
                            descriptografada[i, j] = int.Parse(Console.ReadLine());
                            frases += descriptografada[i, j].ToString() + " ";
                            Console.Clear();
                        }
                        frases += "\n";
                    }
                    Matriz matriz = new Matriz(colunas);
                    matriz.SetChave(chave);
                    matriz.SetMatriz(descriptografada);
                    int[,] criptografada = matriz.Criptografar();
                    frases = "Matriz descriptografada:\n";
                    for (int i = 0; i < descriptografada.GetLength(0); i++)
                    {
                        for (int j = 0; j < descriptografada.GetLength(1); j++)
                            frases += descriptografada[i, j] + " ";
                        frases += "\n";
                    }
                    frases += "Matriz criptografada:\n";
                    for (int i = 0; i < criptografada.GetLength(0); i++)
                    {
                        for (int j = 0; j < criptografada.GetLength(1); j++)
                            frases += criptografada[i, j] + " ";
                        frases += "\n";
                    }
                    frases += "Frase: " + matriz.ObterFrase();
                    Console.WriteLine(frases);
                    Console.ReadKey();
                }
                else
                {
                    break;
                }
                Console.WriteLine("1 - Descriptografar matriz\n2 - Criptografar matriz\n3 - Para sair do programa");
                indice = int.Parse(Console.ReadLine());
            }
        }
    }
}
