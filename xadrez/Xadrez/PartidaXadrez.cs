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
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool xeque { get; private set; }
        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Brancas;
            Terminada = false;
            xeque = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
         
        }

        public Peca ExecutaMovimento(Posicao Origem, Posicao Destino)
        {
            Peca p = tab.RetirarPeca(Origem);
            p.InQtMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(Destino);
            tab.ColocarPeca(p, Destino);
            if(pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }
        public void DesfazoMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.RetirarPeca(destino);
            p.DecQtMovimentos();
            if (pecaCapturada != null)
            {
                tab.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            tab.ColocarPeca(p, origem);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaemCheque(JogadorAtual))
            {
                DesfazoMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroExeption("Voce nao pode se colocar em Xeque");
            }
            if (EstaemCheque(Adversaria(JogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }
            if (TestaXequeMate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }
           
            
        }
        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Brancas)
            {
                JogadorAtual = Cor.Pretas;
            }
            else JogadorAtual = Cor.Brancas;
        }
        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach ( Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Peca> PecasemJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
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
            if (!tab.Peca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroExeption("Destino Invalido!");
            }
        }
    
        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Brancas)
            {
                return Cor.Pretas;
            }
            else
            {
                return Cor.Brancas;
            }
        }       
        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasemJogo(cor))
            {
                if ( x is Rei)
                {
                    return x;
                }
                
            }
            return null;
        }
        public bool EstaemCheque(Cor cor)
        {
            Peca R = Rei(cor);
            if (R == null)
            {
                throw new TabuleiroExeption("Nao existe Rei no Tabuleiro");
            }
            foreach(Peca x in PecasemJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentoPossivel();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            } 
            return false;

        }
        public bool TestaXequeMate(Cor cor)
        {
            if (!EstaemCheque(cor))
            {
                return false;
            }
            foreach(Peca x in PecasemJogo(cor))
            {
                bool[,] mat = x.MovimentoPossivel();

                for (int i=0; i<tab.Linhas;i++)
                {
                        for (int j = 0; j < tab.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool TesteXeque = EstaemCheque(cor);
                            DesfazoMovimento(origem, destino, pecaCapturada);
                            if (!TesteXeque)
                            {
                                return false;

                            }
                        }
                    }

                }

            }
            return true;

        }
            public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            Pecas.Add(peca);
        }
        private void ColocarPecas()
        {
            ColocarNovaPeca('a', 1, new Torre(Cor.Brancas, tab));
            ColocarNovaPeca('h', 1, new Torre(Cor.Brancas, tab));
            ColocarNovaPeca('b', 1, new Cavalo(Cor.Brancas, tab));
            ColocarNovaPeca('g', 1, new Cavalo(Cor.Brancas, tab));
            ColocarNovaPeca('c', 1, new Bispo(Cor.Brancas, tab));
            ColocarNovaPeca('f', 1, new Bispo(Cor.Brancas, tab));
            ColocarNovaPeca('d', 1, new Rei(Cor.Brancas, tab));
            ColocarNovaPeca('e', 1, new Dama(Cor.Brancas, tab));
            ColocarNovaPeca('a', 2, new Piao(Cor.Brancas, tab));
            ColocarNovaPeca('b', 2, new Piao(Cor.Brancas, tab));
            ColocarNovaPeca('c', 2, new Piao(Cor.Brancas, tab));
            ColocarNovaPeca('d', 2, new Piao(Cor.Brancas, tab));
            ColocarNovaPeca('e', 2, new Piao(Cor.Brancas, tab));
            ColocarNovaPeca('f', 2, new Piao(Cor.Brancas, tab));
            ColocarNovaPeca('g', 2, new Piao(Cor.Brancas, tab));
            ColocarNovaPeca('h', 2, new Piao(Cor.Brancas, tab));

            ColocarNovaPeca('a', 8, new Torre(Cor.Pretas, tab));
            ColocarNovaPeca('h', 8, new Torre(Cor.Pretas, tab));
            ColocarNovaPeca('b', 8, new Cavalo(Cor.Pretas, tab));
            ColocarNovaPeca('g', 8, new Cavalo(Cor.Pretas, tab));
            ColocarNovaPeca('c', 8, new Bispo(Cor.Pretas, tab));
            ColocarNovaPeca('f', 8, new Bispo(Cor.Pretas, tab));
            ColocarNovaPeca('d', 8, new Rei(Cor.Pretas, tab));
            ColocarNovaPeca('e', 8, new Dama(Cor.Pretas, tab));
            ColocarNovaPeca('a', 7, new Piao(Cor.Pretas, tab));
            ColocarNovaPeca('b', 7, new Piao(Cor.Pretas, tab));
            ColocarNovaPeca('c', 7, new Piao(Cor.Pretas, tab));
            ColocarNovaPeca('d', 7, new Piao(Cor.Pretas, tab));
            ColocarNovaPeca('e', 7, new Piao(Cor.Pretas, tab));
            ColocarNovaPeca('f', 7, new Piao(Cor.Pretas, tab));
            ColocarNovaPeca('g', 7, new Piao(Cor.Pretas, tab));
            ColocarNovaPeca('h', 7, new Piao(Cor.Pretas, tab));
        }

    }
}
