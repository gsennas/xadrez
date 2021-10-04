using System;
using System.Collections.Generic;
using System.Text;
using xadrez.tabuleiro;

namespace xadrez.Xadrez
{
    class Rei : Peca
    { private PartidaXadrez Partida;
        public Rei(Cor cor, Tabuleiro tabuleiro, PartidaXadrez partida) : base(cor, tabuleiro)
        {
            Partida = partida;
        }
        public override string ToString()
        {
            return "R";
        }
        private bool PodeMover(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != Cor;
        }
        private bool TesteTorreRoque (Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p is Torre && p.QtMovimento == 0 && p.Cor == Cor;
                  
        }
        public override bool[,] MovimentoPossivel()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);
            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos))
                    {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Diagonal alta Direita
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna+1);
            if (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Diagonal alta Esquerda
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna-1);
            if (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Esquerda
            pos.DefinirValores(Posicao.Linha , Posicao.Coluna-1);
            if (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna+1);
            if (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Diagonal baixa Direita
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna+1);
            if (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Diagonal baixa Esquerda
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //ABaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
           
            
            //#Roque
             
            if (QtMovimento == 0 && !Partida.xeque)
             { //roque pqueno
                 Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                 if (TesteTorreRoque(posT1))
                 {
                     Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                     Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                     if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null)
                     {
                         mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                     }
                 }
                 //roque grande
                 Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                 if (TesteTorreRoque(posT2))
                 {
                     Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                     Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                     Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);
                     if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null && Tabuleiro.Peca(p3) == null)
                     {
                         mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                     }
                 }

             }
            return mat;

        }



    }
    

}
