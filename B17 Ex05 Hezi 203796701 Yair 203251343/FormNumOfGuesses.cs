using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Project1
{
    public class FormNumOfGuesses : Form
    {
        private CounterButton m_IncreaseGuessesButton;
        private Button m_startGameButton;

        public FormNumOfGuesses()
        {
            this.CenterToScreen();
            this.Size = new System.Drawing.Size(350, 200);
            this.Text = "BullsEye";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitControls();
        }

        public ushort ChosenGuesses
        {
            get { return m_IncreaseGuessesButton.count; }
        }

        private void InitControls()
        {
            m_IncreaseGuessesButton = new CounterButton("Number of chances: ", 10, 4);
            m_IncreaseGuessesButton.Location = new Point(20, 10);
            m_IncreaseGuessesButton.Size = new Size(300, 30);

            this.Controls.Add(m_IncreaseGuessesButton);

            m_startGameButton = new Button();
            m_startGameButton.Text = "Start";
            m_startGameButton.Location = new Point(220, 120);
            m_startGameButton.Click += StartGameButton_Click;
            this.Controls.Add(m_startGameButton);
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
