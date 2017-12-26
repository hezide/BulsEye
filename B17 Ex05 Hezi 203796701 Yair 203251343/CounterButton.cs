using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public class CounterButton : Button
    {
        private ushort m_count;
        private ushort m_upperRange;
        private ushort m_LowerRange;
        private string m_infoText;

        public CounterButton(string i_text, ushort i_upperRange, ushort i_lowerRange)
        {
            m_upperRange = i_upperRange;
            m_LowerRange = i_lowerRange;
            m_count = m_LowerRange;
            m_infoText = i_text;
            this.Text = m_infoText + m_count.ToString();
            this.Click += IncreaseGuessesButton_Click;
        }

        public ushort count
        {
            get { return m_count; }
        }

        private void IncreaseGuessesButton_Click(object sender, EventArgs e)
        {
            m_count++;
            if(m_count > m_upperRange)
            {
                m_count = m_LowerRange;
            }

            this.Text = m_infoText + m_count.ToString();
        }
    }
}
