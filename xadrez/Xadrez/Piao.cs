using System;
using System.Collections.Generic;
using System.Text;
using xadrez.tabuleiro;

namespace xadrez.Xadrez
{
    class Piao : Peca
    {
        private PartidaXadrez Partida;
        public Piao(Cor cor, Tabuleiro tabuleiro, PartidaXadrez partida) : base(cor, tabuleiro)
        {
            Partida = partida;
        }
        public override string ToString()
        {
            return "P";
        }
        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p.Cor != Cor;
        }
        private bool Livre(Posicao pos)
        {

            return Tabuleiro.Peca(pos) == null;
        }
        private bool PodeMover(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }
        public override bool[,] MovimentoPossivel()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Brancas)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos)&&QtMovimento==0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna -1);
                if (Tabuleiro.PosicaoValilda(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValilda(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //EnPassant
                if (Posicao.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValilda(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.Peca(esquerda) == Partida.VuneravemEnPassant)
                    {
                        mat[esquerda.Linha-1, esquerda.Coluna] = true ;
                    }
                }
                Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValilda(direita) && ExisteInimigo(direita) && Tabuleiro.Peca(direita) == Partida.VuneravemEnPassant)
                {
                    mat[direita.Linha-1, direita.Coluna] = true;
                }
               
            }
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                if (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos) && QtMovimento == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
               
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValilda(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValilda(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //EnPassant
                if (Posicao.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    if (Tabuleiro.PosicaoValilda(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.Peca(esquerda) == Partida.VuneravemEnPassant)
                    {
                        mat[esquerda.Linha+1, esquerda.Coluna] = true;
                    }
                }
                Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValilda(direita) && ExisteInimigo(direita) && Tabuleiro.Peca(direita) == Partida.VuneravemEnPassant)
                {
                    mat[direita.Linha+1, direita.Coluna] = true;
                }

            }
           
            return mat;
        }
    }

}
