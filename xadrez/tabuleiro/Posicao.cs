using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez.tabuleiro
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao()
        {
        }
        public void DefinirValores(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }
        public override string ToString()
        {
            return Linha + "," + Coluna;
        }
    }
}
