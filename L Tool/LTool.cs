using System;
using System.Windows.Forms;

using LCore.Dynamic;
using LCore.Tools;
using LCore.Extensions;
using System.IO;

namespace L_Tool
    {
    public partial class LTool : Form
        {
        private const string Default_CodeRoot = @"D:\Dev\Singularity\L";
        private const string Default_CodeDynamicFolder = @"D:\Dev\Singularity\L\Dynamic Code\CodeExplode";

        public LTool()
            {
            this.InitializeComponent();

            this.LoadOptions();
            }

        private void button1_Click(object sender, EventArgs e)
            {
            this.SaveOptions();

            CodeExploder Test = new CodeExploder(this.CodeRoot, this.CodeDynamicFolder);
            Test.BackupAllExplodeFiles();
            string s = Test.ExplodeAllTypes();
            MessageBox.Show($"{s.Count('\n')} Lines Generated");
            Application.Exit();
            }

        private void button2_Click(object sender, EventArgs e)
            {
            this.SaveOptions();

            CodeExploder Test = new CodeExploder(this.CodeRoot, this.CodeDynamicFolder);
            Test.BackupAllExplodeFiles();
            }


        private readonly RegistryHandler Registry = new RegistryHandler("LTool", Microsoft.Win32.Registry.CurrentUser);

        private string CodeRoot
            {
            get
                {
                return (string)(this.Registry.Load("CodeRoot", RegistryHandler.ObjType.String) ?? Default_CodeRoot);
                }
            set
                {
                this.Registry.Save("CodeRoot", value);
                }
            }

        private string CodeDynamicFolder
            {
            get
                {
                return (string)(this.Registry.Load("CodeDynamicFolder", RegistryHandler.ObjType.String) ?? Default_CodeDynamicFolder);
                }
            set
                {
                this.Registry.Save("CodeDynamicFolder", value);
                }
            }

        private void LoadOptions()
            {
            this.textBox1.Text = this.CodeRoot;
            this.textBox2.Text = this.CodeDynamicFolder;
            }
        private void SaveOptions()
            {
            this.CodeRoot = this.textBox1.Text;
            this.CodeDynamicFolder = this.textBox2.Text;
            }

        private void button3_Click(object sender, EventArgs e)
            {
            this.folderBrowserDialog1.ShowDialog();

            if (Directory.Exists(this.folderBrowserDialog1.SelectedPath))
                {
                this.textBox1.Text = this.folderBrowserDialog1.SelectedPath;
                }
            }

        private void button4_Click(object sender, EventArgs e)
            {
            this.folderBrowserDialog1.ShowDialog();

            if (Directory.Exists(this.folderBrowserDialog1.SelectedPath))
                {
                this.textBox2.Text = this.folderBrowserDialog1.SelectedPath;
                }
            }

        private void LTool_Load(object sender, EventArgs e)
            {

            }
        }
    }
