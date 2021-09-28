using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez.tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int QtMovimento { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca( Cor cor,  Tabuleiro tabuleiro)
        {
            Posicao = null;
            Cor = cor;
            QtMovimento = 0;
            Tabuleiro = tabuleiro;
        }
        public void InQtMovimentos()
        {
            QtMovimento++;
        }
        public bool ExistemovimentoPossivel()
        {
            bool[,] mat = MovimentoPossivel();
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j<Tabuleiro.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                    
                }
            }
            return false;
        }
        public bool  PodeMoverPara(Posicao pos)
        {
            return MovimentoPossivel()[pos.Linha,pos.Coluna];
        }
        public abstract bool[,] MovimentoPossivel();
        
    }
}
