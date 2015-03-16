using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LCore;
using LCore.Dynamic;
using System.IO;

namespace L_Tool
	{
	public partial class LTool : Form
		{
		private const string Default_CodeRoot = @"C:\Users\Ben\Desktop\RedKnuckles2\L\L\";
		private const string Default_CodeDynamicFolder = @"C:\Users\Ben\Desktop\RedKnuckles2\L\L\Dynamic Code\CodeExplode\";

		public LTool()
			{
			InitializeComponent();

			LoadOptions();
			}

		private void button1_Click(object sender, EventArgs e)
			{
			SaveOptions();

			CodeExploder Test = new CodeExploder(CodeRoot, CodeDynamicFolder);
			Test.BackupAllExplodeFiles();
			String s = Test.ExplodeAllTypes();
			MessageBox.Show(s.Count('\n') + " Lines Generated");
			Application.Exit();
			}

		private void button2_Click(object sender, EventArgs e)
			{
			SaveOptions();

			CodeExploder Test = new CodeExploder(CodeRoot, CodeDynamicFolder);
			Test.BackupAllExplodeFiles();
			}


		public RegistryHandler Registry = new RegistryHandler("LTool", Microsoft.Win32.Registry.CurrentUser);

		public string CodeRoot
			{
			get
				{
				return (String)(Registry.Load("CodeRoot", RegistryHandler.ObjType.String) ?? Default_CodeRoot);
				}
			set
				{
				Registry.Save("CodeRoot", value);
				}
			}

		public string CodeDynamicFolder
			{
			get
				{
				return (String)(Registry.Load("CodeDynamicFolder", RegistryHandler.ObjType.String) ?? Default_CodeDynamicFolder);
				}
			set
				{
				Registry.Save("CodeDynamicFolder", value);
				}
			}

		private void LoadOptions()
			{
			this.textBox1.Text = CodeRoot;
			this.textBox2.Text = CodeDynamicFolder;
			}
		private void SaveOptions()
			{
			CodeRoot = this.textBox1.Text;
			CodeDynamicFolder = this.textBox2.Text;
			}

		private void button3_Click(object sender, EventArgs e)
			{
			folderBrowserDialog1.ShowDialog();

			if (Directory.Exists(folderBrowserDialog1.SelectedPath))
				{
				this.textBox1.Text = folderBrowserDialog1.SelectedPath;
				}
			}

		private void button4_Click(object sender, EventArgs e)
			{
			folderBrowserDialog1.ShowDialog();

			if (Directory.Exists(folderBrowserDialog1.SelectedPath))
				{
				this.textBox2.Text = folderBrowserDialog1.SelectedPath;
				}
			}
		}
	}
