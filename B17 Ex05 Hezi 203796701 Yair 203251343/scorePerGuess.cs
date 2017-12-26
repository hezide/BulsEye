using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public struct sScorePerGuess
    {
        public ushort m_bul;
        public ushort m_hit;

        public sScorePerGuess(ushort i_bul, ushort i_hit)
        {
            m_bul = i_bul;
            m_hit = i_hit;
        }
    }
}
