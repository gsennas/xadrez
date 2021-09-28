using System;
using System.Collections.Generic;
using System.Text;
using xadrez.tabuleiro;

namespace xadrez.Xadrez
{
    class Torre : Peca
    {
        public Torre(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }
        public override string ToString()
        {
            return "T";
        }
        private bool PodeMover(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }
        public override bool[,] MovimentoPossivel()
        {
            bool[,] mat = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(Tabuleiro.Linhas, Tabuleiro.Colunas);
            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }
            //Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
                //Direita
                pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
                while (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                    if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                    {
                        break;
                    }
                    pos.Coluna = pos.Coluna + 1;
                }
                //ABaixo
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                while (Tabuleiro.PosicaoValilda(pos) && PodeMover(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                    if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                    {
                        break;
                    }
                    pos.Linha = pos.Linha + 1;
                }

            }
            return mat;
        }
    }
}

