using System;

namespace CriptografiaMatrizRefatorado
{
    internal class Matriz
    {
        private int[,] matriz;
        private int[,] matrizCriptografada;
        private int[,] chave = new int[2, 2] { { 0, 0 }, { 0, 0 } };
        private int[,] chaveDecode = new int[2, 2] { { 0, 0 }, { 0, 0 } };

        /// <summary>
        /// Inicializa uma matriz com 2 linhas e um número especificado de colunas.
        /// </summary>
        /// <param name="tamanho">Número de colunas da matriz.</param>
        public Matriz(int tamanho)
        {
            matriz = new int[2, tamanho];
        }

        /// <summary>
        /// Inicializa a matriz com os valores fornecidos.
        /// </summary>
        /// <param name="Matriz">Matriz de valores inteiros.</param>
        public Matriz(int[,] Matriz)
        {
            this.matriz = new int[2, Matriz.GetLength(1)];
            SetMatriz(Matriz);
        }

        /// <summary>
        /// Inicializa a matriz e define a chave usada para criptografia e descriptografia.
        /// </summary>
        /// <param name="Matriz">Matriz de valores inteiros.</param>
        /// <param name="Chave">Matriz 2x2 usada como chave para criptografia.</param>
        public Matriz(int[,] Matriz, int[,] Chave)
        {
            this.matriz = new int[2, Matriz.GetLength(1)];
            SetMatriz(Matriz);
            SetChave(Chave);
        }

        /// <summary>
        /// Define a matriz principal da classe.
        /// </summary>
        /// <param name="Matriz">A nova matriz a ser definida.</param>
        public void SetMatriz(int[,] Matriz)
        {
            this.matriz = Matriz;
        }

        /// <summary> 
        /// Define a matriz criptografada.
        /// </summary>
        /// <param name="MatrizCriptografada">Matriz resultante do processo de codificação.</param>
        public void SetMatrizCriptografada(int[,] MatrizCriptografada)
        {
            this.matrizCriptografada = MatrizCriptografada;
        }

        /// <summary>
        /// Define a chave de criptografia e gera automaticamente a chave de descriptografia.
        /// </summary>
        /// <param name="Chave">Matriz 2x2 usada para codificação.</param>
        public void SetChave(int[,] Chave)
        {
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                {
                    this.chave[i, j] = Chave[i, j];
                    this.chaveDecode[i, j] = (i == j) ? Chave[1 - i, 1 - j] : -Chave[i, j];
                }
        }

        /// <summary>
        /// Retorna a matriz de chave para criptografia.
        /// </summary>
        /// <returns>Matriz 2x2 usada para criptografia.</returns>
        private int[,] GetChave()
        {
            return this.chave;
        }

        /// <summary>
        /// Retorna a matriz criptografada.
        /// </summary>
        /// <returns>Matriz resultante da codificação.</returns>
        public int[,] GetMatrizCriptografada()
        {
            return this.matrizCriptografada;
        }

        /// <summary>
        /// Executa o processo de criptografia.
        /// </summary>
        /// <returns>Matriz criptografada.</returns>
        public int[,] Criptografar()
        {
            int[,] resultado = new int[2, matriz.GetLength(1)];
            int[,] chave = GetChave();
            for (int i = 0; i < resultado.GetLength(0); i++)
                for (int j = 0; j < resultado.GetLength(1); j++)
                {
                    int soma = 0;
                    for (int k = 0; k < 2; k++)
                        soma += chave[i, k] * matriz[k, j];
                    resultado[i, j] = soma;
                }
            this.SetMatrizCriptografada(resultado);
            return resultado;
        }

        /// <summary>
        /// Executa o processo de descriptografia.
        /// </summary>
        /// <returns>Matriz original antes da criptografia.</returns>
        public int[,] Descriptografar()
        {
            int[,] resultado = new int[2, this.matrizCriptografada.GetLength(1)];
            for (int i = 0; i < resultado.GetLength(0); i++)
                for (int j = 0; j < resultado.GetLength(1); j++)
                {
                    int soma = 0;
                    for (int k = 0; k < 2; k++)
                        soma += chaveDecode[i, k] * matrizCriptografada[k, j];
                    resultado[i, j] = soma;
                }
            SetMatriz(resultado);
            return resultado;
        }

        /// <summary>
        /// Retorna a letra correspondente a um número, baseado em um mapeamento fixo do alfabeto e caracteres especiais.
        /// </summary>
        /// <param name="Elemento">Índice do caractere no alfabeto mapeado.</param>
        /// <returns>Letra correspondente ao índice informado.</returns>
        /// <exception cref="Exception">Lança exceção se o número estiver fora do intervalo permitido (0 a 30).</exception>
        private string ObterLetra(int Elemento)
        {
            if (Elemento < 0 || Elemento > 30)
                throw new Exception("Out range");

            string resultado = "";
            string[] alfabeto = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "!", "?", " ", ".", "," };

            for (int i = 0; i < Elemento; i++)
                resultado = alfabeto[Elemento - 1];

            return resultado.ToString();
        }

        /// <summary>
        /// Converte os valores da matriz em uma frase.
        /// </summary>
        /// <returns>Frase correspondente à matriz de números.</returns>
        public string ObterFrase()
        {
            string resultado = "";
            foreach (var item in this.matriz)
                resultado += this.ObterLetra(item);
            return resultado;
        }
    }
}
