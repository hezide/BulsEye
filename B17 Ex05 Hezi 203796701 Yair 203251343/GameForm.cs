using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Project1
{
    public class GameForm : Form
    {
        private List<GuessBlock> m_blockCollection;
        private ComputerGuessBlock m_computerGuessBlock;
        private Game m_gameObject;

        public GameForm(int i_numOfBlocks, List<Color> i_computerGuessColor, Game i_gameObject)
        {
            m_gameObject = i_gameObject;
            this.AutoSize = true;
            this.Text = "Bulls Eye";
            this.CenterToScreen();

            m_blockCollection = new List<GuessBlock>();
            m_computerGuessBlock = new ComputerGuessBlock(i_computerGuessColor, 20, 20);
            foreach (Button btn in m_computerGuessBlock.VisibleComputerGuess)
            {
                this.Controls.Add(btn);
            }

            int YOfBlock = 100; ///it's the Y of the first block, the rest are set according to it

            for (int i = 0; i < i_numOfBlocks; i++)
            {
                GuessBlock blockToAdd = new GuessBlock(20, YOfBlock);
                AddSingleBlockToForm(blockToAdd);
                blockToAdd.ConfirmSelectionButton.Name = i.ToString();
                m_blockCollection.Add(blockToAdd);
                YOfBlock += blockToAdd.PickColorButtons[0].Height + 10;
            }
            this.EnableBlock(0);
        }

        private void AddSingleBlockToForm(GuessBlock i_blockToAdd)
        {
            foreach (Button buttonToAdd in i_blockToAdd.PickColorButtons)
            {
                this.Controls.Add(buttonToAdd);
            }

            foreach (Button buttonToAdd in i_blockToAdd.UserSelectionButtons)
            {
                this.Controls.Add(buttonToAdd);
            }

            this.Controls.Add(i_blockToAdd.ConfirmSelectionButton);
            i_blockToAdd.ConfirmSelectionButton.Click += ConfirmSelectionButton_Click;
        }

        private void ConfirmSelectionButton_Click(object sender, EventArgs e)
        {
            int indexOfBlock = int.Parse((sender as Button).Name);
            List<Button> buttonsToCheck = m_blockCollection[indexOfBlock].PickColorButtons; /// the buttons of the same block
            List<int> intColorsOfTHeButtons = ConvertColorsOfTheButtonsToInt(buttonsToCheck);
            sScorePerGuess score = m_gameObject.AnalyzeScore(intColorsOfTHeButtons);
            m_blockCollection[indexOfBlock].ChangeSmallerButtonsAccordingToTheScore(score);
            (sender as Button).Enabled = false;

            foreach(Button btn in buttonsToCheck)
            {
                btn.Enabled = false;
            }

            if(score.m_bul == 4)
            {
                RevieleComputerGuess();
            }
            this.EnableBlock(indexOfBlock + 1);
        }

        private void RevieleComputerGuess()
        {
            m_computerGuessBlock.Reviele();
            ///disable all buttons
            foreach(GuessBlock block in m_blockCollection)
            {
                foreach(Button btn in block.PickColorButtons)
                {
                    btn.Enabled = false;
                }

                foreach (Button btn in block.UserSelectionButtons)
                {
                    btn.Enabled = false;
                }

                block.ConfirmSelectionButton.Enabled = false;
            }
        }

        private List<int> ConvertColorsOfTheButtonsToInt(List<Button> i_buttonsToCheck)
        {
            List<int> o_res = new List<int>();
            foreach(Button btn in i_buttonsToCheck)
            {
                int intOfEnumColor = (int)Enum.Parse(typeof(UI.ePossibleColors), btn.BackColor.Name);
                o_res.Add(intOfEnumColor);
            }

            return o_res;
        }

        public void EnableBlock(int i_blockToEnable)
        {
            if (i_blockToEnable < m_blockCollection.Capacity)
            {
                foreach (Button btn in m_blockCollection[i_blockToEnable].PickColorButtons)
                {
                    btn.Enabled = true;
                }
            }
        }
    }
}
