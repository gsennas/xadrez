using System;
using System.Collections.Generic;
using System.Text;

namespace xadrez.tabuleiro
{
    class TabuleiroExeption: Exception
    {
        public TabuleiroExeption (string msg) : base(msg)
        {

        }
    }
}
