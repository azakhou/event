using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EventViewerViewer
{

    public partial class Form2 : Form
    {
        #region public
        /* プロパティの設定 */
        public string eventIDDate { get; set; }
        public string LogNameDate { get; set; }
        public int Row { get; set; }
        public DataGridView GridIn { get; set; }
        #endregion
        #region Event
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Labletext(GridIn, Row);
            LableView();
            this.LogNameL.Text = LogNameDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EventL_Click(object sender, EventArgs e)
        {
            string url = "https://www.google.co.jp/search?q=%E3%82%A4%E3%83%99%E3%83%B3%E3%83%88%E3%83%93%E3%83%A5%E3%83%BC%E3%82%A2%E3%83%BC+ID" + eventIDDate;
            System.Diagnostics.Process.Start(url);
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            try
            {
                Labletext(GridIn, Row + 1);
                Row += 1;
                LableView();
            }
            catch
            {
                //何もしない
            }
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            try
            {
                Labletext(GridIn, Row - 1);
                Row -= 1;
                LableView();
            }
            catch
            {
                //何もしない
            }
        }
        #endregion
        #region Data
        private void Labletext(DataGridView GridIn, int Row)
        {
                this.LevelL.Text = Convert.ToString(GridIn[0, Row].Value);
                this.LogL.Text = Convert.ToString(GridIn[1, Row].Value);
                this.SousL.Text = Convert.ToString(GridIn[2, Row].Value);
                this.EventL.Text = Convert.ToString(GridIn[3, Row].Value);
                this.TaskL.Text = Convert.ToString(GridIn[4, Row].Value);
                this.MSBox.Text = Convert.ToString(GridIn[5, Row].Value);
                this.PCL.Text = Convert.ToString(GridIn[6, Row].Value);
                this.UL.Text = Convert.ToString(GridIn[7, Row].Value);
                eventIDDate = EventL.Text;

        }

        /// <summary>
        /// 表示変更
        /// </summary>
        private void LableView()
        {
            if(LevelL.Text == "Information")
            {
                LevelL.Text = "情報";
            }
            else if(LevelL.Text == "Error")
            {
                LevelL.Text = "エラー";
            }
            else if(LevelL.Text =="Warning")
            {
                LevelL.Text = "危険";
            }
            if (EventL.Text == "8300")
            {
                this.KeyL.Text = "(1)";
            }
            else if (EventL.Text == "8301")
            {
                this.KeyL.Text = "(2)";
            }
            else if (this.SousL.Text == "User Profile Service"
            || this.SousL.Text == "Winsrv"
            || this.SousL.Text == "RestartManager")
            {
                this.KeyL.Text = "";
            }
            else
            {
                this.KeyL.Text = "クラシック";
            }
            if(TaskL.Text == "(0)")
            {
                TaskL.Text = "なし";
            }
            if (EventL.Text == "8300" || EventL.Text == "8301")
            {
                this.OpeL.Text = "応答時間,Performance";
            }
            else if (this.SousL.Text == "User Profile Service"
         || this.SousL.Text == "Winsrv"
         || this.SousL.Text == "RestartManager"
         || this.SousL.Text == "CAPI2"
         || this.SousL.Text == "Search"
         || this.SousL.Text == "Software Protection Platform Service"
         || this.SousL.Text == "Property System"
         || this.SousL.Text == "EventSystem"
         || this.SousL.Text == "Microsoft-Windows-LoadPerf")
            {
                this.OpeL.Text = "情報";
            }
            else
            {
                this.OpeL.Text = "";
            }


        }
        #endregion
    }
}
