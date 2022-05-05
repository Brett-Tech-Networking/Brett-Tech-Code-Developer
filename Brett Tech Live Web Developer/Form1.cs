using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.VisualStyles;
using FastColoredTextBoxNS;
using System.Security.Policy;
using Brett_Tech_Code_Developer;

namespace Brett_Tech_Live_Web_Developer
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        // Will store current opened file as a variable
        public string currentFile = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                documentMap1.Enabled = false;
                documentMap1.Visible = false;
                metroTabControl1.Dock = DockStyle.Fill;
            }
            catch { }
        }

        private void FastColoredTextBox1_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            webBrowser1.DocumentText = fastColoredTextBox1.Text;
        }

        private void New_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You want to delete current code?","new",MessageBoxButtons.YesNo)== DialogResult.Yes)
            {
                //delete all code
                fastColoredTextBox1.Clear();
                //set current file to nothing
                currentFile = null;
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (fastColoredTextBox1.Text == fastColoredTextBox1.Text)
            {
                if (MessageBox.Show("Do You want to delete current code?", "OPEN", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //open menu with file choosing
                    OpenFileDialog op = new OpenFileDialog();


                    //filter
                    op.Filter = "Any File|*.*|HTML File|*.html";
                    if (op.ShowDialog() == DialogResult.OK)
                    {
                        // Read selected file
                        StreamReader sr = new StreamReader(op.FileName);
                        // set current file to selected
                        currentFile = op.FileName;
                        // Read text set code editor
                        fastColoredTextBox1.Text = sr.ReadToEnd();
                        // Stop reading File
                        sr.Close();
                    }
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (currentFile!=null)
            {
                //write text to file
                StreamWriter sw = new StreamWriter(currentFile);
                sw.Write(fastColoredTextBox1.Text);
                sw.Close();
            }
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            //Save as 
            SaveFileDialog op = new SaveFileDialog();

            //filter
            op.Filter = "HTML File|*.html|Any File|*.*";
            if (op.ShowDialog() == DialogResult.OK)
            {
                // save selected file
                StreamWriter sr = new StreamWriter(op.FileName);
                // set current file to selected
                currentFile = op.FileName;
                // write code to file 
                sr.Write(fastColoredTextBox1.Text);
                // Stop reading File
                sr.Close();
            }
            }

        private void Exit_Click(object sender, EventArgs e)
        {           
            {
                if (MessageBox.Show("Do You want to delete current code? and Exit", "EXIT", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void Find_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowFindDialog();
        }

        private void Replace_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.ShowReplaceDialog();
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Undo();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Redo();
        }

        private void Website_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bretttechcoding.com/Projects/code-developer");
        }

        private void BlackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.BackColor = Color.Black;
        }


        private void Gray_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.BackColor = Color.LightGray;
        }

        private void SpringGreen_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.BackColor = Color.SpringGreen;
        }

        private void Turquoise_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.BackColor = Color.Turquoise;
        }

        private void SkyBlue_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.BackColor = Color.SkyBlue;
        }

        private void SandyBrown_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.BackColor = Color.SandyBrown;
        }

        private void PowderBlue_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.BackColor = Color.PowderBlue;
        }

        private void PlumPink_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.BackColor = Color.Plum;
        }

        private void MintCream_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.BackColor = Color.MintCream;
        }

        private void DefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.BackColor = Color.White;
        }

        private void HTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (HTML.Checked == true)
            {
                try
                {
                    // Enable HTML

                    webBrowser1.Visible = true;
                    fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML;

                    fastColoredTextBox1.Refresh();
                    Refresh();
                }
                catch
                {
                    //nothing
                }
                
            }
            else if (HTML.Checked == false)
            {
                // Disable HTML

                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
            }
        }

        private void CSharp_Click(object sender, EventArgs e)
        {
            if (cSharp.Checked == true)
            {
                webBrowser1.Visible = false;
                webBrowser1.Navigate("");
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
                fastColoredTextBox1.Refresh();
            }
            else if (cSharp.Checked==false)
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
            }
          

        }

        private void AutoCompleateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void BracketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void HeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = fastColoredTextBox1.Text.Insert(fastColoredTextBox1.SelectionStart, "<head>" + Environment.NewLine + Environment.NewLine + "</head>");
        }

        private void BodyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = fastColoredTextBox1.Text.Insert(fastColoredTextBox1.SelectionStart, "<body>" + Environment.NewLine + Environment.NewLine + "</body>");
        }

        private void H1Tag_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = fastColoredTextBox1.Text.Insert(fastColoredTextBox1.SelectionStart, "<h1>" + Environment.NewLine + Environment.NewLine + "</h1>");
        }

        private void H2Tag_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = fastColoredTextBox1.Text.Insert(fastColoredTextBox1.SelectionStart, "<h2>" + Environment.NewLine + Environment.NewLine + "</h2>");
        }

        private void H3Tag_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = fastColoredTextBox1.Text.Insert(fastColoredTextBox1.SelectionStart, "<h3>" + Environment.NewLine + Environment.NewLine + "</h3>");
        }

        private void PTag_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = fastColoredTextBox1.Text.Insert(fastColoredTextBox1.SelectionStart, "<p>" + Environment.NewLine + Environment.NewLine + "</p>");
        }

        private void CenterTag_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = fastColoredTextBox1.Text.Insert(fastColoredTextBox1.SelectionStart, "<center>" + Environment.NewLine + Environment.NewLine + "</center>");
        }

        private void CodingAssistantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.w3schools.com/");
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void VB_Click(object sender, EventArgs e)
        {
            if (VB.Checked == true)
            {
                webBrowser1.Visible = false;
                webBrowser1.Navigate("");
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.VB;
                fastColoredTextBox1.Refresh();
            }
            else if(VB.Checked == false)
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
            }
        }

        private void JS_Click(object sender, EventArgs e)
        {
            if (JS.Checked == true)
            {
                webBrowser1.Visible = false;
                webBrowser1.Navigate("");
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
                fastColoredTextBox1.Refresh();
            }
            else if (JS.Checked == false)
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
            }
        }

        private void XML_Click(object sender, EventArgs e)
        {
            if (XML.Checked == true)
            {
                webBrowser1.Visible = false;
                webBrowser1.Navigate("");
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.XML;
                fastColoredTextBox1.Refresh();
            }
            else if (XML.Checked == false)
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
            }
        }

        private void SQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SQL.Checked == true)
            {
                webBrowser1.Visible = false;
                webBrowser1.Navigate("");
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.SQL;
                fastColoredTextBox1.Refresh();
            }
            else if (SQL.Checked == false)
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
            }
        }

        private void PHP_Click(object sender, EventArgs e)
        {
            if (PHP.Checked == true)
            {
                webBrowser1.Visible = false;
                webBrowser1.Navigate("");
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
                fastColoredTextBox1.Refresh();
            }
            else if (PHP.Checked == false)
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
            }
        }

        private void Lua_Click(object sender, EventArgs e)
        {
            if (Lua.Checked == true)
            {
                webBrowser1.Visible = false;
                webBrowser1.Navigate("");
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua;
                fastColoredTextBox1.Refresh();
            }
            else if (Lua.Checked == false)
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
            }
        }

        private void Webpageblack_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = fastColoredTextBox1.Text.Insert(fastColoredTextBox1.SelectionStart, ("  <body style='background - color:black; '> "));

        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tp = new TabPage();
            int tc = (metroTabControl1.TabCount + 1);
            tp.Text = "Tab " + tc.ToString();
            metroTabControl1.TabPages.Add(tp);
            RichTextBox rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;
            tp.Controls.Add(rtb);

            return;
        }

        private void hideBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                splitContainer1.Panel2Collapsed = true;
            }
            catch
            {

            }
        }

        private void showLiveOutputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                splitContainer1.Panel2Collapsed = false;
            }
            catch
            {

            }

        }

        private void relaodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
                HTML.Checked = false;
                JS.Checked = false;
                cSharp.Checked = false;
                VB.Checked = false;
                XML.Checked = false;
                SQL.Checked = false;
                PHP.Checked = false;
                Lua.Checked = false;

                fastColoredTextBox1.Refresh();
                Refresh();
            }
            catch
            {
                //nothing
            }
        }
         

        private void newTabToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TabPage tp = new TabPage();
            int tc = (metroTabControl1.TabCount + 1);
            tp.Text = "Tab " + tc.ToString();
            metroTabControl1.TabPages.Add(tp);
       
        
            
            return;
        }

        private void fileExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select Your Path." })
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                    webBrowser1.Url = new Uri(fbd.SelectedPath);
              
             }
            
    }
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            
    }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Allows user too choose font

            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                fastColoredTextBox1.Font = fd.Font;
            }
        }

        private void hIdeDocMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                documentMap1.Enabled = false;
                documentMap1.Visible = false;
                metroTabControl1.Dock = DockStyle.Fill;
            }
            catch { }
        }

        private void showDocMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                documentMap1.Enabled = true;
                documentMap1.Visible = true;
                metroTabControl1.Dock = DockStyle.None;
            }
            catch { }
        }

        private void PowerShell_Clicked(object sender, EventArgs e)
        {
            if (PowerShell.Checked == true)
            {
                webBrowser1.Visible = false;
                webBrowser1.Navigate("");
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
                fastColoredTextBox1.Refresh();
            }
            else if (Lua.Checked == false)
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
            }
        }
    }
}
