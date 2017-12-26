using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Project1
{
    public class UI
    {
        public enum ePossibleColors
        {
            Purple, Red, LightGreen, LightBlue, Blue, Yellow, Brown, White
        }

        private FormNumOfGuesses m_guessPropmt;

        private Game m_gameObject;
        private GameForm m_gameForm;

        public UI()
        {
            m_gameObject = new Game();
            m_guessPropmt = new FormNumOfGuesses();
        }

        public void Run()
        {
            m_gameObject.Init();
            m_gameObject.NumOfAllowedGuesses = NumOfGuessesPrompt(); ///show the user number of guess form
            if (m_guessPropmt.DialogResult == DialogResult.OK)
            {
                List<Color> convertedColorList = new List<Color>();
                convertedColorList = ConvertIntGuessToColors(m_gameObject.ComputerGuess);
                m_gameForm = new GameForm(m_gameObject.NumOfAllowedGuesses, convertedColorList, m_gameObject);
                m_gameForm.ShowDialog();
            }
        }

        private List<Color> ConvertIntGuessToColors(List<int> i_computerGuess)
        {
            List<Color> o_res = new List<Color>();
            ePossibleColors ColorToAdd;

            foreach (int intToConvert in i_computerGuess)
            {
                ColorToAdd = (ePossibleColors)intToConvert;
                o_res.Add(Color.FromName(ColorToAdd.ToString()));
            }

            return o_res;
        }

        public ushort NumOfGuessesPrompt()
        {
            m_guessPropmt.ShowDialog();
            return m_guessPropmt.ChosenGuesses;
        }
    }
}
