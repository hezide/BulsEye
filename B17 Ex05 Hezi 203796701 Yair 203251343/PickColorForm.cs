using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Project1
{
    public class PickColorForm : Form
    {
        private List<Button> m_ColorButtonList;

        public enum PossibleColors
        {
            Purple, Red, LightGreen, LightBlue, Blue, Yellow, Brown, White
        }

        private Color m_pickedColor;

        private TableLayoutPanel m_colorButtonTable;

        public Color PickedColor
        {
            get { return m_pickedColor; }
        }

        public PickColorForm()
        {
            m_ColorButtonList = new List<Button>();
            CreateButtonsAndInsertToList();
            /*form properties*/
            this.Text = "Pick a Color:";
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.CenterToScreen();
            /*end of form properties*/

            m_colorButtonTable = new TableLayoutPanel();
            m_colorButtonTable.ColumnCount = 4;
            m_colorButtonTable.RowCount = ((m_ColorButtonList.Capacity - 1) / 4) + 1;
            m_colorButtonTable.AutoSize = true;
            foreach (Button button in m_ColorButtonList)
            {
                m_colorButtonTable.Controls.Add(button);
            }

            this.Controls.Add(m_colorButtonTable);
        }

        private void CreateButtonsAndInsertToList()
        {
            ///iterate all the colors
            foreach (PossibleColors color in Enum.GetValues(typeof(PossibleColors)))
            {
                Button buttonToAdd = new Button();
                buttonToAdd.BackColor = Color.FromName(color.ToString());
                buttonToAdd.Click += ButtonToAdd_Click;
                buttonToAdd.Size = new Size(50, 50);
                m_ColorButtonList.Add(buttonToAdd);
            }
        }

        private void ButtonToAdd_Click(object sender, EventArgs e)
        {
            m_pickedColor = (sender as Button).BackColor;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
