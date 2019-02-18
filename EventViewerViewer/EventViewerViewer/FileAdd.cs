using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace EventViewerViewer
{
    public partial class FileAdd : Form
    {
        public static readonly string FolderPath = "./Fillter/";
        public FileAdd()
        {
            InitializeComponent();
        }

        private void btn_Fadd_Click(object sender, EventArgs e)
        {
            if (txt_FName.Text == "")
            {
                this.Close();
                return;
            }

            if (File.Exists(FolderPath) == false)
            {
                System.IO.Directory.CreateDirectory(FolderPath);
            }

            var Filepath = FolderPath + txt_FName.Text+".xml";

            if (File.Exists(Filepath))
            {
                MessageBox.Show("すでに存在しています。");
            }
                else
            {
                //XMLファイル作成
                XmlDocument Xd = new XmlDocument();
                XmlDeclaration XDc = Xd.CreateXmlDeclaration("1.0", "utf-8", null);
                XmlElement root = Xd.CreateElement("Fillter");
                Xd.AppendChild(XDc);
                Xd.AppendChild(root);

                // ファイルに保存する
                Xd.Save(Filepath);
            }
            //閉じる
            this.Close();
        }
    }
}
