using System;
using System.Collections.Generic;
using System.Text;
using xadrez.tabuleiro;

namespace xadrez.Xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Cor cor, Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }
        public override string ToString()
        {
            return "C";
        }
    }
}
