using System;
using System.Collections.Generic;
using System.Text;
using xadrez.tabuleiro;

namespace xadrez.Xadrez
{
    class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }
        public override string ToString()
        {
            return "B";
        }
    }
}