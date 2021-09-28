using System;
using System.Collections.Generic;
using System.Text;
using xadrez.tabuleiro;

namespace xadrez.Xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Brancas;
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
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }
        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Brancas)
            {
                JogadorAtual = Cor.Pretas;
            }
            else JogadorAtual = Cor.Brancas;
        }
        public void ValidarPosicaoOrigem (Posicao pos)
        {
            if (tab.Peca(pos)==null)
            {
                throw new TabuleiroExeption("Nao existe peca na posicao de origem!");
            }
            if (JogadorAtual != tab.Peca(pos).Cor)
            {
                throw new TabuleiroExeption( "Vez das" + JogadorAtual);
            }
            if (!tab.Peca(pos).ExistemovimentoPossivel())
            {
                throw new TabuleiroExeption("Nao ha movimentos possivies para peca escolhida!");
            }
        }
        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroExeption("Destino Invalido!");
            }
        }
        
        
            private void ColocarPecas()
        {
            tab.ColocarPeca(new Torre(Cor.Brancas, tab), new PosicaoXadrez('c', 1).toPosicao());
            tab.ColocarPeca(new Torre(Cor.Brancas, tab), new PosicaoXadrez('c', 2).toPosicao());
            tab.ColocarPeca(new Torre(Cor.Brancas, tab), new PosicaoXadrez('d', 2).toPosicao());
            tab.ColocarPeca(new Torre(Cor.Brancas, tab), new PosicaoXadrez('e', 1).toPosicao());
            tab.ColocarPeca(new Torre(Cor.Brancas, tab), new PosicaoXadrez('e',2).toPosicao());
            tab.ColocarPeca(new Rei(Cor.Brancas, tab), new PosicaoXadrez('d', 1).toPosicao());

            tab.ColocarPeca(new Torre(Cor.Pretas, tab), new PosicaoXadrez('c', 7).toPosicao());
            tab.ColocarPeca(new Torre(Cor.Pretas, tab), new PosicaoXadrez('c', 8).toPosicao());
            tab.ColocarPeca(new Torre(Cor.Pretas, tab), new PosicaoXadrez('d', 7).toPosicao());
            tab.ColocarPeca(new Torre(Cor.Pretas, tab), new PosicaoXadrez('e', 8).toPosicao());
            tab.ColocarPeca(new Torre(Cor.Pretas, tab), new PosicaoXadrez('e', 7).toPosicao());
            tab.ColocarPeca(new Rei(Cor.Pretas, tab), new PosicaoXadrez('d', 8).toPosicao());
        }

    }
}
