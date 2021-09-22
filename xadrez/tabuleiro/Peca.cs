using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez.tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; set; }
        public int QrMovimento { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Posicao posicao, Cor cor,  Tabuleiro tabuleiro)
        {
            Posicao = posicao;
            Cor = cor;
            QrMovimento = 0;
            Tabuleiro = tabuleiro;
        }
    }
}
