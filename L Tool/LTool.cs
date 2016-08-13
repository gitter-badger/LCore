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
        private const string DefaultCodeRoot = @"D:\Dev\Singularity\L";
        private const string DefaultCodeDynamicFolder = @"D:\Dev\Singularity\L\Dynamic Code\CodeExplode";

        public LTool()
            {
            this.InitializeComponent();

            this.LoadOptions();
            }

        private void button1_Click(object Sender, EventArgs Event)
            {
            this.SaveOptions();

            var Test = new CodeExploder(this.CodeRoot, this.CodeDynamicFolder);
            Test.BackupAllExplodeFiles();
            string Str = Test.ExplodeAllTypes();
            MessageBox.Show($"{Str.Count(Obj: '\n')} Lines Generated");
            Application.Exit();
            }

        private void button2_Click(object Sender, EventArgs Event)
            {
            this.SaveOptions();

            var Test = new CodeExploder(this.CodeRoot, this.CodeDynamicFolder);
            Test.BackupAllExplodeFiles();
            }

        private void button3_Click(object Sender, EventArgs Event)
            {
            this.folderBrowserDialog1.ShowDialog();

            if (Directory.Exists(this.folderBrowserDialog1.SelectedPath))
                {
                this.textBox1.Text = this.folderBrowserDialog1.SelectedPath;
                }
            }

        private void button4_Click(object Sender, EventArgs Event)
            {
            this.folderBrowserDialog1.ShowDialog();

            if (Directory.Exists(this.folderBrowserDialog1.SelectedPath))
                {
                this.textBox2.Text = this.folderBrowserDialog1.SelectedPath;
                }
            }

        private void button5_Click(object Sender, EventArgs Event)
            {
            var Test = new CodeExploder(this.CodeRoot, CodeExplodeDir: null);

            string Str = !this.textBox4.Text.IsEmpty() ?
                Test.ExplodeAllTypes(Type => Type.Name.Contains(this.textBox4.Text)) :
                Test.ExplodeAllTypes();

            this.textBox3.Text = Str;
            }


        private readonly RegistryHelper _Registry = new RegistryHelper("LTool", Microsoft.Win32.Registry.CurrentUser);

        private string CodeRoot
            {
            get
                {
                return this._Registry.LoadString("CodeRoot") ?? DefaultCodeRoot;
                }
            set
                {
                this._Registry.Save("CodeRoot", value);
                }
            }

        private string CodeDynamicFolder
            {
            get
                {
                return this._Registry.LoadString("CodeDynamicFolder") ?? DefaultCodeDynamicFolder;
                }
            set
                {
                this._Registry.Save("CodeDynamicFolder", value);
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

        private void LTool_Load(object Sender, EventArgs Event)
            {

            }
        }
    }
