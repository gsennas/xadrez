using System;
using System.Collections.Generic;
using System.Text;
using xadrez.tabuleiro;

namespace xadrez.Xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool Terminada { get; private set; }

        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.branca;
            ColocarPecas();
            Terminada = false;
        }

        public void ExecutaMovimento(Posicao Origem, Posicao Destino)
        {
            Peca p = tab.RetirarPeca(Origem);
            p.InQtMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(Destino);
            tab.ColocarPeca(p, Destino);
        }
        private void ColocarPecas()
        {
            tab.ColocarPeca(new Torre(Cor.branca, tab), new PosicaoXadrez('c', 1).toPosicao());
            tab.ColocarPeca(new Torre(Cor.branca, tab), new PosicaoXadrez('c', 2).toPosicao());
            tab.ColocarPeca(new Torre(Cor.branca, tab), new PosicaoXadrez('d', 2).toPosicao());
            tab.ColocarPeca(new Torre(Cor.branca, tab), new PosicaoXadrez('e', 1).toPosicao());
            tab.ColocarPeca(new Torre(Cor.branca, tab), new PosicaoXadrez('e',2).toPosicao());
            tab.ColocarPeca(new Rei(Cor.branca, tab), new PosicaoXadrez('d', 1).toPosicao());

            tab.ColocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('c', 7).toPosicao());
            tab.ColocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('c', 8).toPosicao());
            tab.ColocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('d', 7).toPosicao());
            tab.ColocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('e', 8).toPosicao());
            tab.ColocarPeca(new Torre(Cor.Preta, tab), new PosicaoXadrez('e', 7).toPosicao());
            tab.ColocarPeca(new Rei(Cor.Preta, tab), new PosicaoXadrez('d', 8).toPosicao());
        }

    }
}
