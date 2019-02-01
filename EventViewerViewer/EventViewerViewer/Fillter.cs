using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EventViewerViewer
{
    public partial class Fillter : Form
    {
        #region public
        //public List<string> FALLS { get; set; }
        //public List<string> FALLC { get; set; }
        public string FALLS { get; set; }
        public string FALLC { get; set; }
        public string[] FcheckInfo  { get; set; }
        public string FSourT { get; set; }
        public string FSourEX { get; set; }
        public string CCB { get; set; }
        public string UserCB { get; set; }
        public string UEX { get; set; }
        public string PCNtext { get; set; }
        public string FPCEX { get; set; }
        public string Eventtext { get; set; }
        public DateTime DatetimeFrom { get; set; }
        public DateTime DatetimeTo { get; set; }

        private string n_a = "N/A";
        

        #endregion
        #region Event
        public Fillter()
        {
            InitializeComponent();
        }
        private void Fillter_Load(object sender, EventArgs e)
        {
            ComboItems();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ONButtum_Click(object sender, EventArgs e)
        {
            FcheckInfo = new string[4] {"","","","" };
            //フィルターの中身取得
            if (this.CheckInfo.Checked == true) { FcheckInfo[0] = this.CheckInfo.Text; }
            if (this.CheckErr.Checked == true) { FcheckInfo[1] = this.CheckErr.Text; }
            if (this.CheckWar.Checked == true) { FcheckInfo[2] = this.CheckWar.Text; }
            if (this.CheckFail.Checked == true) { FcheckInfo[3] = this.CheckFail.Text; }
            if (this.CheckSuc.Checked == true) { FcheckInfo[4] = this.CheckSuc.Text; }
            FSourT = this.SourceCB.Text;
            FSourEX =Convert.ToString( this.SourceEX.Checked);
            CCB = this.CategoryCB.Text;
            if (this.UCB.Text == n_a)
            {
                UserCB = null;
            }
            else
            {
                UserCB = this.UCB.Text;
            }
            
            UEX = Convert.ToString( this.UserEX.Checked);
            PCNtext = this.PCName.Text;
            FPCEX = Convert.ToString(this.PCEX.Checked);
            Eventtext = this.EventName.Text;
            DatetimeFrom = Convert.ToDateTime(this.DateFrom.Text);
            DatetimeTo = Convert.ToDateTime(this.DateTo.Text);
            //}
            this.DialogResult = DialogResult.OK;
            //閉じる
            //this.Close();
            this.Hide();
        }
        #endregion
        #region data
        public void ComboItems()
        {
            if (this.UCB.Items.Count > 0)
            {
                this.UCB.Items.Clear();
                this.CategoryCB.Items.Clear();
                this.SourceCB.Items.Clear();
            }
            try
            {
                //大文字小文字を区別しない序数比較で並び替える
                StringComparer cmp = StringComparer.OrdinalIgnoreCase;
                //1度実行したら値が入る
                //ソース
                string[] sou = FALLS.Split(',');
                Array.Sort(sou, cmp);
                this.SourceCB.Items.AddRange(sou);
                //ソースコンボボックスのリストと初期値
                //this.SourceCB.Items.AddRange(FALLS.ToArray());
                //カテゴリー
                string[] cate = FALLC.Split(',');
                Array.Sort(cate, cmp);
                this.CategoryCB.Items.AddRange(cate);
                //ソースコンボボックスのリストと初期値
                //this.CategoryCB.Items.AddRange(FALLC.ToArray());
            }
            catch
            {
                //何もしなかった場合
            }

            var Ullist = new string[] {"","NT AUTHORITY\\SYSTEM", "N/A"};
            this.UCB.Items.AddRange(Ullist);
        }
        #endregion
    }
}
