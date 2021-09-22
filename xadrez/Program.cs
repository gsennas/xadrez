using System;
using xadrez.tabuleiro;
using xadrez.Xadrez;

namespace xadrez
{
    class Program
    {
        static void Main(string[] args)
        {

            PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            Console.WriteLine( pos);
            Console.WriteLine(pos.toPosicao());
            
            /*try
            {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);// instanciar matriz = null em todos os elementos
                tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new Posicao(0, 9));
                tabuleiro.ColocarPeca(new Rei(Cor.Preta, tabuleiro), new Posicao(0, 4));
                tabuleiro.ColocarPeca(new Torre(Cor.Preta, tabuleiro), new Posicao(1, 3));
                tabuleiro.ColocarPeca(new Rei(Cor.Preta, tabuleiro), new Posicao(2, 4));

                Tela.ImprimirTabuleiro(tabuleiro);

            }
            catch (TabuleiroExeption e)
            {
                Console.WriteLine(e.Message);
            }*/
            }


    }
}
