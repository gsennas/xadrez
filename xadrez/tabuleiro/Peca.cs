using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez.tabuleiro
{
    class Peca
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
        
    }
}
