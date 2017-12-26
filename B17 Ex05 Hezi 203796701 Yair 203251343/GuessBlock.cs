using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Project1
{
    public class GuessBlock
    {
        private List<Button> m_pickColorButtons; 
        private List<Button> m_userSelectionButtons;
        private Button m_ConfirmSelection;
        private PickColorForm m_colorForm;

        public List<Button> PickColorButtons
        {
            get { return m_pickColorButtons; }
        }

        public List<Button> UserSelectionButtons
        {
            get { return m_userSelectionButtons; }
        }

        public Button ConfirmSelectionButton
        {
            get { return m_ConfirmSelection; }
        }

        public GuessBlock(int i_X, int i_Y)///this block receives a starting location and according to it sets the buttons
        {
            Create4ButtonsForSelction(i_X, i_Y);
            CreateConfirmSelectionButton();
            Create4ButtonsShowingSelection();
        }

        private void Create4ButtonsForSelction(int i_X, int i_Y)
        {
            m_pickColorButtons = new List<Button>();
            Button buttonToadd = new Button();

            buttonToadd.Enabled = false;///////////////////////////

            buttonToadd.Location = new Point(i_X, i_Y);
            buttonToadd.Size = new Size(50, 50);
            buttonToadd.Click += ButtonToadd_Click;
            m_pickColorButtons.Add(buttonToadd);

            for (int i = 1; i < 4; i++)
            {
                buttonToadd = new Button();
                buttonToadd.Enabled = false;///////////////////////////
                buttonToadd.Left = m_pickColorButtons[i - 1].Location.X + m_pickColorButtons[i - 1].Size.Width + 10; 
                buttonToadd.Top = m_pickColorButtons[i - 1].Location.Y;
                buttonToadd.Size = m_pickColorButtons[i - 1].Size;
                buttonToadd.Click += ButtonToadd_Click;
                m_pickColorButtons.Add(buttonToadd);
            }
        }

        private void ButtonToadd_Click(object sender, EventArgs e)///open color dialog and pick a color for the button
        {
            bool allButtonsColored = true;
            m_colorForm = new PickColorForm();
            m_colorForm.ShowDialog();
            if(m_colorForm.DialogResult == DialogResult.OK)
            {
                (sender as Button).BackColor = m_colorForm.PickedColor;
            }

            foreach(Button btn in m_pickColorButtons)
            {
                if (btn.BackColor.Name == "Control")
                {
                    allButtonsColored = false;
                }
            }

            if (allButtonsColored)
            {
                m_ConfirmSelection.Enabled = true;
            }
        }

        private void Create4ButtonsShowingSelection()
        {
            m_userSelectionButtons = new List<Button>();
            /*TOP LEFT BUTTON*/
            Button buttonToadd = new Button();
            buttonToadd.Enabled = false;
            Point firstButtonLocation = new Point(m_ConfirmSelection.Location.X + m_ConfirmSelection.Width + 10, m_ConfirmSelection.Location.Y - 10);
            buttonToadd.Location = firstButtonLocation;
            buttonToadd.Size = new Size(15, 15);

            m_userSelectionButtons.Add(buttonToadd);

            /*TOP RIGHT BUTTON*/
            buttonToadd = new Button();
            buttonToadd.Enabled = false;
            buttonToadd.Left = firstButtonLocation.X + m_userSelectionButtons[0].Size.Width + 5;
            buttonToadd.Top = m_userSelectionButtons[0].Location.Y;
            buttonToadd.Size = m_userSelectionButtons[0].Size;
            m_userSelectionButtons.Add(buttonToadd);

            /*BOTTOM LEFT BUTTON*/
            buttonToadd = new Button();
            buttonToadd.Enabled = false;
            buttonToadd.Left = UserSelectionButtons[0].Left;
            buttonToadd.Top = m_userSelectionButtons[0].Top + m_userSelectionButtons[0].Height + 5;
            buttonToadd.Size = m_userSelectionButtons[0].Size;
            m_userSelectionButtons.Add(buttonToadd);

            /*BOTTOM RIGHT BUTTON*/
            buttonToadd = new Button();
            buttonToadd.Enabled = false;
            buttonToadd.Left = UserSelectionButtons[2].Left + UserSelectionButtons[2].Width + 5;
            buttonToadd.Top = m_userSelectionButtons[2].Top;
            buttonToadd.Size = m_userSelectionButtons[2].Size;
            m_userSelectionButtons.Add(buttonToadd);
        }

        internal void ChangeSmallerButtonsAccordingToTheScore(sScorePerGuess i_score)
        {
            int indexToChange = 0;
            for (int i = 0; i < i_score.m_bul; i++) 
            {
                m_userSelectionButtons[indexToChange].BackColor = Color.Black;
                indexToChange++;
            }

            for (int i = 0; i < i_score.m_hit; i++) 
            {
                m_userSelectionButtons[indexToChange].BackColor = Color.Yellow;
                indexToChange++;
            }
        }

        private void CreateConfirmSelectionButton()
        {
            m_ConfirmSelection = new Button();
            m_ConfirmSelection.Text = "-->>";
            m_ConfirmSelection.Enabled = false;
            int lastButtonIndex = m_pickColorButtons.Count;
            int lastButtonWidth = m_pickColorButtons[lastButtonIndex - 1].Width;
            int lastButtonX = m_pickColorButtons[lastButtonIndex - 1].Location.X;
            int lastButtonY = m_pickColorButtons[lastButtonIndex - 1].Location.Y;

            m_ConfirmSelection.Location = new Point(lastButtonX + lastButtonWidth + 10, lastButtonY + 15);
            m_ConfirmSelection.Size = new Size(m_pickColorButtons[lastButtonIndex - 1].Width, 20);
        }
    }
}
