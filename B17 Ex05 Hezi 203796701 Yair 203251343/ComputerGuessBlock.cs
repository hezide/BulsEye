using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Project1
{
    public class ComputerGuessBlock
    {
        private List<Button> m_VisibleComputerGuess;
        private List<Color> m_ComputerGuessColors;

        public ComputerGuessBlock(List<Color> i_ColorsToAdd, int i_x, int i_y)
        {
            m_ComputerGuessColors = i_ColorsToAdd;
            CreateVisibleComputerButtons(i_x, i_y);
        }

        public List<Button> VisibleComputerGuess
        {
            get { return m_VisibleComputerGuess; }
        }

        public void CreateVisibleComputerButtons(int i_x, int i_y)
        {
            m_VisibleComputerGuess = new List<Button>();
            Button buttonToadd = new Button();
            buttonToadd.Enabled = false;
            buttonToadd.BackColor = Color.Black;
            buttonToadd.Location = new Point(i_x, i_y);
            buttonToadd.Size = new Size(50, 50);
            m_VisibleComputerGuess.Add(buttonToadd);

            for (int i = 1; i < 4; i++)
            {
                buttonToadd = new Button();
                buttonToadd.Enabled = false;
                buttonToadd.BackColor = Color.Black;
                buttonToadd.Left = m_VisibleComputerGuess[i - 1].Location.X + m_VisibleComputerGuess[i - 1].Size.Width + 10;
                buttonToadd.Top = m_VisibleComputerGuess[i - 1].Location.Y;
                buttonToadd.Size = m_VisibleComputerGuess[i - 1].Size;
                m_VisibleComputerGuess.Add(buttonToadd);
            }
        }

        public void Reviele()
        {
            int i = 0;
            foreach(Button btn in m_VisibleComputerGuess)
            {
                btn.BackColor = m_ComputerGuessColors[i];
                i++;
            }
        }
    }
}
