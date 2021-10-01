using System;
using System.Collections.Generic;
using System.Text;
using xadrez.tabuleiro;
using xadrez.Xadrez;

namespace xadrez
{
    class Tela
    {
        public static void ImprimirPartida (PartidaXadrez partida)
        {
            ImprimirTabuleiro(partida.tab);
            Console.WriteLine();
            ImprimirPecaCaturada(partida);
            Console.WriteLine();
            Console.WriteLine("Turno"+partida.Turno);
            if (!partida.Terminada)
            {

                Console.WriteLine("Vez das:" + partida.JogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("Xeque");
                }
            }
            else 
            {
                Console.WriteLine("XequeMate!");
                Console.WriteLine(partida.JogadorAtual+" Venceram!!!!");
            }

        }
        public static void ImprimirPecaCaturada(PartidaXadrez partida)
        {
            Console.WriteLine("Pecas Capturadas");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Brancas));
            
            Console.Write("\nPretas: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Pretas));
            Console.ForegroundColor = aux;

        }
        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    ImprimirPeca(tab.Peca(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");

        }
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOrignal = Console.BackgroundColor;
            ConsoleColor fundoAlterdo = ConsoleColor.DarkGray;
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (posicoesPossiveis[i,j])
                    {
                        Console.BackgroundColor = fundoAlterdo;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOrignal;
                    }
                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOrignal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOrignal;
        }
        public static void ImprimirPeca(Peca peca) //cor da peca
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {

                if (peca.Cor == Cor.Brancas)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;

                }
                Console.Write(" ");
            }
        }
       public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        }
    } 

