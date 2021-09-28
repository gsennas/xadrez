using System;
using System.Collections.Generic;
using System.Text;
using xadrez.tabuleiro;

namespace xadrez.Xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }
        public override string ToString()
        {
            return "R";
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
            return mat;
        }
    }

}
