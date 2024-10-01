using System;
using System.Drawing;
using System.Windows.Forms;

namespace Лаба_11_Drag_Drop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            panel37.BackColor = Color.MediumAquamarine;
            panel38.BackColor = Color.Navy;
            panel39.BackColor = Color.SkyBlue;
            panel40.BackColor = Color.DarkOrange;
            panel41.BackColor = Color.DarkRed;
            panel42.BackColor = Color.LimeGreen;

            Panel[] panelsMain = new Panel[]
            {
                panel1, panel2, panel3, panel4, panel5, panel6,
                panel7, panel8, panel9, panel10, panel11, panel12,
                panel13, panel14, panel15, panel16, panel17, panel18,
                panel19, panel20, panel21, panel22, panel23, panel24,
                panel25, panel26, panel27, panel28, panel29, panel30,
                panel31, panel32, panel33, panel34, panel35, panel36
            };

            Panel[] panelsPalette = new Panel[]
            {
                panel37, panel38, panel39, panel40, panel41, panel42
            };

            for (int i = 0; i < 36; i++)
            {
                panelsMain[i].AllowDrop = true;
                panelsMain[i].DragEnter += new DragEventHandler(Panel_DragEnter);
                panelsMain[i].DragDrop += new DragEventHandler(Panel_DragDrop);
            }

            for (int i = 0; i < 6; i++)
            {
                panelsPalette[i].MouseDown += new MouseEventHandler(Panel_MouseDown);
                panelsPalette[i].AllowDrop = false;
                panelsPalette[i].DragEnter += new DragEventHandler(Panel_DragEnter);
                panelsPalette[i].DragDrop += new DragEventHandler(Panel_DragDrop);
            }
        }
        #region Button click action
        private void button1_Click(object sender, EventArgs e)
        {
            Clear_Panel();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Clear_Panel();
            Panel[] panels = new Panel[]
            {
                panel43, panel44, panel48, panel47, panel46, panel45,
                panel53, panel52, panel51, panel54, panel50, panel49,
                panel59, panel58, panel57, panel60, panel56, panel55,
                panel77, panel76, panel75, panel78, panel74, panel73,
                panel71, panel70, panel69, panel72, panel68, panel67,
                panel65, panel64, panel63, panel66, panel62, panel61
            };

            var random = new Random();
            for (int i = 0, l = panels.Length; i < l; i++)
            {
                int a = random.Next(1, 7);
                switch (a)
                {
                    case 1:
                        panels[i].BackColor = Color.MediumAquamarine;
                        break;
                    case 2:
                        panels[i].BackColor = Color.Navy;
                        break;
                    case 3:
                        panels[i].BackColor = Color.SkyBlue;
                        break;
                    case 4:
                        panels[i].BackColor = Color.DarkOrange;
                        break;
                    case 5:
                        panels[i].BackColor = Color.DarkRed;
                        break;
                    case 6:
                        panels[i].BackColor = Color.LimeGreen;
                        break;
                }
            }
        }
        #endregion
        #region Drug&Drop
        private void Panel_DragDrop(object sender, DragEventArgs e)
        {
            Panel[] panelsMain = new Panel[]
            {
                panel1, panel2, panel3, panel4, panel5, panel6,
                panel7, panel8, panel9, panel10, panel11, panel12,
                panel13, panel14, panel15, panel16, panel17, panel18,
                panel19, panel20, panel21, panel22, panel23, panel24,
                panel25, panel26, panel27, panel28, panel29, panel30,
                panel31, panel32, panel33, panel34, panel35, panel36
            };

            Panel[] panelsPicture = new Panel[]
            {
                panel43, panel44, panel45, panel46, panel47, panel48,
                panel49, panel50, panel51, panel52, panel53, panel54,
                panel55, panel56, panel57, panel58, panel59, panel60,
                panel61, panel62, panel63, panel64, panel65, panel66,
                panel67, panel68, panel69, panel70, panel71, panel72,
                panel73, panel74, panel75, panel76, panel77, panel78
            };

            Panel toPanel = sender as Panel;
            Panel fromPanel = e.Data.GetData(typeof(Panel)) as Panel;

            for (int i = 0; i < 36; i++)
            {
                if (toPanel.Name == panelsMain[i].Name)
                {
                    if (fromPanel.BackColor == panelsPicture[i].BackColor)
                    {
                        toPanel.BackColor = fromPanel.BackColor;
                    }
                }
            }
        }
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                DoDragDrop(panel, DragDropEffects.Move);
            }
        }
        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Panel)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        #endregion
        private void Clear_Panel() 
        {
            Panel[] panelsMain = new Panel[]
            {
                panel1, panel6, panel5, panel4, panel3, panel2,
                panel8, panel9, panel10, panel11, panel12, panel7,
                panel14, panel15, panel16, panel17, panel18, panel13,
                panel20, panel21, panel22, panel23, panel24, panel19,
                panel26, panel27, panel28, panel29, panel30, panel25,
                panel32, panel33, panel34, panel35, panel36, panel31,
                panel43, panel44, panel45, panel46, panel47, panel48,
                panel49, panel50, panel51, panel52, panel53, panel54,
                panel55, panel56, panel57, panel58, panel59, panel60,
                panel61, panel62, panel63, panel64, panel65, panel66,
                panel67, panel68, panel69, panel70, panel71, panel72,
                panel73, panel74, panel75, panel76, panel77, panel78
            };

            foreach (Panel panel in panelsMain)
            {
                panel.Controls.Clear();
                panel.BackColor = SystemColors.ControlDark;
            }

        }
    }
}
