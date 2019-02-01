﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Reflection;


namespace EventViewerViewer
{

    public partial class Form1 : Form
    {
        #region public
        //public List<string> ALLS { get; set; }
        //public List<string> ALLC { get; set; }
        public string ALLS { get; set; }
        public string ALLC { get; set; }
        public string FcheckT { get; set; }
        public string FSourT { get; set; }
        public string FSourEX { get; set; }
        public string CCB { get; set; }
        public string UserCB { get; set; }
        public string UEX { get; set; }
        public string PCNtext { get; set; }
        public string FPCEX { get; set; }
        public string Eventtext { get; set; }
        public Fillter Fil = null;
        public DataGridView GridIn { get; set; }


        public static readonly string FolderPath = "./Fillter";
        private string documentPath()
        {
            var strobj = CB_FName.Text;
            if (strobj == "")
            {
                strobj = "XMLFile";
            }
            return string.Format("./Fillter/{0}.xml", strobj);
        }
        public void ComboItems()
        {
            //イベントログ配列を取得する
            System.Diagnostics.EventLog[] evlogs = System.Diagnostics.EventLog.GetEventLogs();

            //コンボボックス1のリストと初期値
            foreach (System.Diagnostics.EventLog log in evlogs)
            {
                //ログの表示名称を取得し、リストボックスに表示する
                comboBox1.Items.Add(log.Log);
            }
            this.comboBox1.SelectedIndex = 0;
            //コンボボックス2のリストと初期値
            var Levellist = new string[] { "ALL", "Information", "Error", "Warning", "FailureAudit", "SuccessAudit" };
            this.comboBox2.Items.AddRange(Levellist);
            this.comboBox2.SelectedIndex = 0;
            ReadFList();
        }
        #endregion
        #region Event
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboItems();
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            EventlogAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Fil == null)
            {
                Fil = new Fillter();
                Fil.FALLS = ALLS;
                Fil.FALLC = ALLC;
            }
            if (Fil.ShowDialog(this) == DialogResult.OK)
            {
                ReloadF(Fil);
            }
        }
        private void XMLBtn_Click(object sender, EventArgs e)
        {
            //XMLファイルの場所指定------------------------------------------------------------------------------------------
            XmlDocument xmlDoc = new XmlDocument();
            using (FileStream stream = new FileStream(string.Format(documentPath(), CB_FName.Text), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {


                XmlDocument doc = new XmlDocument();

                //reader.Schemas.Add(null, schemaPath);
                XmlValidatingReader reader = new XmlValidatingReader(new XmlTextReader(stream));
                reader.ValidationType = ValidationType.Schema;
                doc.Load(reader);
                var WeventID = checkcol(doc, "EventID");
                var WLevel = checkcol(doc, "Level");
                var WSource = checkcol(doc, "Source");
                var WCategory = checkcol(doc, "Category");
                var WUserName = checkcol(doc, "UserName");
                var WMachineName = checkcol(doc, "MachineName");

                // stream.Close();
                List<string> list = new List<string>() { WeventID, WLevel, WSource, WCategory, WUserName, WMachineName };
                OutF(list);

                //----------------------------------------------------------------------------------------------------------------

            }
        }

        private void outbtn_Click(object sender, EventArgs e)
        {
            if (dgView.RowCount == 0) return;
            try
            {
                CreateXML();
                string Cvalues = Convert.ToString(dgView.CurrentCell.Value); //セルの値
                var ColName = Convert.ToString(dgView.Columns[dgView.CurrentCell.ColumnIndex].HeaderCell.Value);//列名取得

                XmlDocument xmlDoc = new XmlDocument();

                // XmlDocumentオブジェクトを作成
                using (FileStream stream = new FileStream(string.Format(documentPath(), CB_FName.Text), FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {


                    xmlDoc.Load(stream);

                    XmlElement xmlRoot = xmlDoc.DocumentElement;
                    // <TEL></TEL>タグ作成用
                    XmlElement xmlTel;
                    // <TEL>タグの値作成用
                    XmlText xmlValue;

                    // <TEL></TEL>タグを作成
                    xmlTel = xmlDoc.CreateElement(ColName);
                    // <TEL>タグの中身（値）を作成
                    xmlValue = xmlDoc.CreateTextNode(Cvalues);

                    // <TEL>タグの中身（値）を<TEL>タグに追加します
                    xmlTel.AppendChild(xmlValue);
                    // ルートタグに<TEL>タグを追加します
                    xmlRoot.AppendChild(xmlTel);

                    stream.Close();
                }
                // ファイルに保存します
                xmlDoc.Save(documentPath());

            }
            catch (System.Xml.XmlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }


        private void Removebtn_Click(object sender, EventArgs e)
        {

            CreateXML();
            XmlDocument xmlDoc = new XmlDocument();
            using (FileStream stream = new FileStream(documentPath(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {

                xmlDoc.Load(stream);
                XmlElement rootelement = xmlDoc.DocumentElement;
                rootelement.RemoveAll();

                xmlDoc.Save(documentPath());

                stream.Close();
            }
            //リスト表示
            EventlogAll();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            using (FileAdd editForm = new FileAdd())
            {
                editForm.ShowDialog(this);
            }
            ReadFList();
        }
        private void dgView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex].Name == "Level")
            {
                string val = (string)e.Value;
                //セルの値により、背景色を変更する
                if (val == "Error")
                {
                    e.CellStyle.BackColor = Color.LightYellow;
                }
                else if (val == "Warning")
                {
                    e.CellStyle.BackColor = Color.Red;
                }
                else if (val == "Information")
                {
                    e.CellStyle.BackColor = Color.SkyBlue;
                }
            }
        }

        private void dgView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            using (Form2 editForm = new Form2())
            {
                //選択行
                var target = e.RowIndex;

                editForm.LogNameDate = comboBox1.Text;
                editForm.Row = target;
                editForm.GridIn = dgView;
                editForm.ShowDialog(this);
            }
        }
        #endregion
        #region watchView
        public void EventlogAll()
        {
            CreateXML();
            dgView.Columns.Clear();
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            System.Diagnostics.EventLog evLog = new System.Diagnostics.EventLog(comboBox1.Text);
            //List<string> ALLName = new List<string>();
            //List<string> CateName = new List<string>();

            //DateRowに１つづセットしていく
            //DatasetPatern(evLog);
            //Listにセットしていく
           ListDatePatern(evLog);
            // ForeachPatern(evLog);

            stopwatch.Stop();
            MessageBox.Show(stopwatch.ElapsedMilliseconds + "ms");
        }
        private void ReloadF(Fillter Fil)
        {
            dgView.Columns.Clear();
            //try
            //{
            System.Diagnostics.EventLog evLog = new System.Diagnostics.EventLog(comboBox1.Text);
            int iCnt = evLog.Entries.Count;

            DataSet ds = new DataSet();
            DataTable dt = LogTabel(ds);
            DataRow dr;

            

            //ビューの中身
            for (int i = iCnt - 1; i >= 0; i--)
            {
                //日付チェック
                if (checkDatetime(Fil, evLog, i) == false) { break; }
                //タイプチェック
                if (checkType(Fil, evLog, i) == false) { continue; }
                //ソースチェック
                if (checkSource(Fil, evLog, i) == false) { continue; }
                //カテゴリーチェック
                if (checkCate(Fil, evLog, i) == false) { continue; }
                //ユーザーチェック
                if (checkUser(Fil, evLog, i) == false) { continue; }
                //PC名チェック
                if (checkPC(Fil, evLog, i) == false) { continue; }
                //イベントチェック
                if (checkEvent(Fil, evLog, i) == false) { continue; }
                dr = dt.NewRow();
                GridValues(dr, evLog.Entries, i);
                dt.Rows.Add(dr);
            }

            dgView.DataSource = ds;
            dgView.DataMember = "Computer";
            if (dgView.RowCount != 0)
            {
                Gridview();
            }
            
            //}
            //catch(Exception e)
            //{
            //    MessageBox.Show(e.Message+e.StackTrace);
            //    return;
            //}
        }
        //list{ WeventID, WLevel, WSource, WCategory, WUserName, WMachineName }
        private void OutF(List<string> list)
        {
            dgView.Columns.Clear();
            try
            {
                System.Diagnostics.EventLog evLog = new System.Diagnostics.EventLog(comboBox1.Text);
                int iCnt = evLog.Entries.Count;
                Lbl_Rowcount.Text = "0";
                DataSet ds = new DataSet();
                DataRow dr;
                DataTable dt = LogTabel(ds);

                bool Viewchecker = true;
                //objectのDateTime値に変換する文字列
                var dt1 = dateTimePicker1.Value;

                //ビューの中身
                for (int i = iCnt - 1; i >= 0; i--)
                {
                    Viewchecker = true;
                    ///
                    if (evLog.Entries[i].TimeWritten <= dt1.Date)
                    {
                        break;
                    }
                    ///
                    if (list[0] == Convert.ToString(evLog.Entries[i].EventID))
                    {
                        continue;
                    }
                    else if (0 <= list[0].IndexOf(","))
                    {
                        for (int j = 0; j <= list[0].Split(',').LongLength - 1; j++)
                        {
                            if (list[0].Split(',')[j] == Convert.ToString(evLog.Entries[i].EventID))
                            {
                                Viewchecker = false;
                                break;
                            }
                        }
                        if (Viewchecker == false) { continue; }
                    }
                    ///Informationと0とが混在しているため

                    if (Convert.ToString(evLog.Entries[i].EntryType) == "0" && list[1] == "Information")
                    {
                        continue;
                    }
                    if (list[1] == Convert.ToString(evLog.Entries[i].EntryType))
                    {
                        continue;
                    }
                    else if (0 <= list[1].IndexOf(","))
                    {
                        for (int j = 0; j <= list[1].Split(',').LongLength - 1; j++)
                        {
                            if (list[1].Split(',')[j] == Convert.ToString(evLog.Entries[i].EntryType))
                            {
                                Viewchecker = false;
                                break;
                            }
                            else if (list[1].Split(',')[j] == "Information" && Convert.ToString(evLog.Entries[i].EntryType) == "0")
                            {
                                Viewchecker = false;
                                break;
                            }

                        }
                        if (Viewchecker == false) { continue; }
                    }

                    ///
                    if (list[2] == Convert.ToString(evLog.Entries[i].Source))
                    {
                        continue;
                    }
                    else if (0 <= list[2].IndexOf(","))
                    {
                        for (int j = 0; j <= list[2].Split(',').LongLength - 1; j++)
                        {
                            if (list[2].Split(',')[j] == Convert.ToString(evLog.Entries[i].Source))
                            {
                                Viewchecker = false;
                                break;
                            }
                        }
                        if (Viewchecker == false) { continue; }
                    }
                    ///
                    if (list[3] == Convert.ToString(evLog.Entries[i].Category))
                    {
                        continue;
                    }
                    else if (0 <= list[3].IndexOf(","))
                    {
                        for (int j = 0; j <= list[3].Split(',').LongLength - 1; j++)
                        {
                            if (list[3].Split(',')[j] == Convert.ToString(evLog.Entries[i].Category))
                            {
                                Viewchecker = false;
                                break;
                            }
                        }
                        if (Viewchecker == false) { continue; }
                    }
                    ///
                    if (list[4] == Convert.ToString(evLog.Entries[i].UserName))
                    {
                        continue;
                    }
                    else if (0 <= list[4].IndexOf(","))
                    {
                        for (int j = 0; j <= list[4].Split(',').LongLength - 1; j++)
                        {
                            if (list[4].Split(',')[j] == Convert.ToString(evLog.Entries[i].UserName))
                            {
                                Viewchecker = false;
                                break;
                            }
                        }
                        if (Viewchecker == false) { continue; }
                    }
                    ///
                    if (list[5] == Convert.ToString(evLog.Entries[i].MachineName))
                    {
                        continue;
                    }
                    else if (0 <= list[5].IndexOf(","))
                    {
                        for (int j = 0; j <= list[5].Split(',').LongLength - 1; j++)
                        {
                            if (list[5].Split(',')[j] == Convert.ToString(evLog.Entries[i].MachineName))
                            {
                                Viewchecker = false;
                                break;
                            }
                        }
                        if (Viewchecker == false) { continue; }
                    }

                    if (Viewchecker == true)
                    {
                        dr = dt.NewRow();
                        GridValues(dr, evLog.Entries, i);
                        dt.Rows.Add(dr);
                    }

                }
                dgView.DataSource = ds;
                dgView.DataMember = "Computer";

                Gridview();
            }
            catch
            {
                return;
            }
        }
        #endregion
        #region Viewchecker/Values
        private void GridValues(DataRow dr, EventLogEntryCollection evLog, int i)
        {
            dr["UserName"] = evLog[i].UserName;

            if (evLog[i].EntryType == 0) { dr["Level"] = "Information"; } else { dr["Level"] = evLog[i].EntryType; }
            dr["TimeWritten"] = evLog[i].TimeWritten;
            dr["Source"] = evLog[i].Source;
            //}
            dr["EventID"] = evLog[i].EventID;
            dr["Category"] = evLog[i].Category;
            //}
            dr["Message"] = evLog[i].Message;
            dr["MachineName"] = evLog[i].MachineName;
            if (evLog[i].UserName == "NT AUTHORITY\\SYSTEM")
            {
                dr["UserName"] = "SYSTEM";
            }
            else if (evLog[i].UserName == null)
            {
                dr["UserName"] = "N/A";
            }
            else
            {
                dr["UserName"] = evLog[i].UserName;
            }
        }
        private bool ALLEvent(EventLog evLog, int i)
        {
            if (this.comboBox2.Text == "ALL")
            {
                return true;
            }
            else if (this.comboBox2.Text == Convert.ToString(evLog.Entries[i].EntryType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool checkDatetime(Fillter Fil, EventLog evLog, int i)
        {
            //フィルダー時間の優先順位
            DateTime Largetime = new DateTime();
            DateTime tinytime = new DateTime();

            if (Fil.DatetimeFrom > Fil.DatetimeTo)
            {
                Largetime = Fil.DatetimeFrom;
                tinytime = Fil.DatetimeTo;
            }
            else
            {
                Largetime = Fil.DatetimeTo;
                tinytime = Fil.DatetimeFrom;
            }
            if (Convert.ToDateTime(evLog.Entries[i].TimeWritten.ToString("yyyy/MM/dd")) <= Convert.ToDateTime(Largetime.ToString("yyyy/MM/dd"))
            && (Convert.ToDateTime(evLog.Entries[i].TimeWritten.ToString("yyyy/MM/dd")) >= Convert.ToDateTime(tinytime.ToString("yyyy/MM/dd"))))
            {
                return true;
            }
            else
            {
                return false;

            }

        }
        private bool checkType(Fillter Fil, EventLog evLog, int i)
        {
            for (int j = 0; j < Fil.FcheckInfo.Length; j++)
            {
                if (Fil.FcheckInfo[j] == Convert.ToString(evLog.Entries[i].EntryType))
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }
        private bool checkSource(Fillter Fil, EventLog evLog, int i)
        {

            if (Fil.FSourEX == "True")
            {
                if ((Fil.FSourT != evLog.Entries[i].Source) || (Fil.FSourT == ""))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if ((Fil.FSourT == evLog.Entries[i].Source) || (Fil.FSourT == ""))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool checkCate(Fillter Fil, EventLog evLog, int i)
        {
            if ((Fil.CCB == evLog.Entries[i].Category) || (Fil.CCB == ""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool checkUser(Fillter Fil, EventLog evLog, int i)
        {
            //除外チェック
            if (Fil.UEX == "True")
            {
                if ((Fil.UserCB != evLog.Entries[i].UserName) || (Fil.UserCB == ""))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if ((Fil.UserCB == evLog.Entries[i].UserName) || (Fil.UserCB == ""))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        private bool checkPC(Fillter Fil, EventLog evLog, int i)
        {
            if (Fil.FPCEX == "True")
            {
                if ((Fil.PCNtext != evLog.Entries[i].MachineName) || (Fil.PCNtext == ""))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if ((Fil.PCNtext == evLog.Entries[i].MachineName) || (Fil.PCNtext == ""))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        private bool checkEvent(Fillter Fil, EventLog evLog, int i)

        {
            if (0 <= Fil.Eventtext.IndexOf(','))
            {
                string[] target = Fil.Eventtext.Split(',');
                var answer = "";
                for (int j = 0; j < target.LongLength; j++)
                {
                    if (target[j] == Convert.ToString(evLog.Entries[i].EventID))
                    {
                        answer += true;
                    }
                    else
                    {
                        answer += false;
                    }
                }
                if (0 <= answer.IndexOf("True"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if ((0 <= Fil.Eventtext.IndexOf('~')) || (0 <= Fil.Eventtext.IndexOf('～')))
            {
                var answer = "";
                var target = Fil.Eventtext.IndexOf('~') + Fil.Eventtext.IndexOf('～') + 1;
                string front = Fil.Eventtext.Substring(0, target);
                string back = Fil.Eventtext.Substring(1 + target);
                for (int j = Convert.ToInt16(front); j <= Convert.ToInt16(back); j++)
                {
                    if (j == evLog.Entries[i].EventID)
                    {
                        answer += true;
                    }
                    else
                    {
                        answer += false;
                    }
                }
                if (0 <= answer.IndexOf("True"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if ((Fil.Eventtext == "") || (Fil.Eventtext == Convert.ToString(evLog.Entries[i].EventID)))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private string checkcol(XmlDocument doc, string colName)
        {
            string strobj = "";
            if (doc.GetElementsByTagName(colName).Count == 1)
            {
                strobj = doc.GetElementsByTagName(colName)[0].InnerText;
            }
            else if ((doc.GetElementsByTagName(colName).Count > 1))
            {
                for (int i = 0; i <= doc.GetElementsByTagName(colName).Count - 1; i++)
                {

                    if (i == doc.GetElementsByTagName(colName).Count - 1)
                    {
                        strobj += doc.GetElementsByTagName(colName)[i].InnerText;
                    }
                    else
                    {
                        strobj += doc.GetElementsByTagName(colName)[i].InnerText + ",";
                    }
                }
            }
            return strobj;
        }
        private void CreateXML()
        {
            if (File.Exists(FolderPath) == false)
            {
                System.IO.Directory.CreateDirectory(FolderPath);
            }
            if (File.Exists(documentPath()) == false)
            {
                XmlDocument Xd = new XmlDocument();
                XmlDeclaration XDc = Xd.CreateXmlDeclaration("1.0", "utf-8", null);
                XmlElement root = Xd.CreateElement("Fillter");
                Xd.AppendChild(XDc);
                Xd.AppendChild(root);

                // ファイルに保存する
                Xd.Save(documentPath());
            }

        }
        private void ReadFList()
        {
            try
            {
                CB_FName.Items.Clear();
                //ファイルをすべて取得する
                //ワイルドカード"*"は、すべてのファイルを意味する
                string[] files = System.IO.Directory.GetFiles(
                   FolderPath, "*", System.IO.SearchOption.AllDirectories);
                for (int i = 0; i < files.Length; i++)
                {
                    CB_FName.Items.Add(System.IO.Path.GetFileNameWithoutExtension(files[i]));
                }
            }
            catch
            {

            }
          

        }
        private DataTable LogTabel(DataSet ds)
        {
            DataTable dt = ds.Tables.Add("Computer");
            dt.Columns.Add("Level");
            dt.Columns.Add("TimeWritten");
            dt.Columns.Add("Source");
            dt.Columns.Add("EventID");
            dt.Columns.Add("Category");
            dt.Columns.Add("Message");
            dt.Columns.Add("MachineName");
            dt.Columns.Add("UserName");
            return dt;
        }

        public void Gridview()
        {

            //幅
            dgView.Columns[0].Width = 80;
            dgView.Columns[1].Width = 115;
            dgView.Columns[2].Width = 200;
            dgView.Columns[3].Width = 80;
            dgView.Columns[4].Width = 80;
            //右寄せ
            dgView.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgView.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgView.Columns[5].Visible = false;
            dgView.Columns[6].Visible = false;
            dgView.Columns[7].Visible = false;
            if (dgView.RowCount > 0)
            {
                Lbl_Rowcount.Text = Convert.ToString(dgView.RowCount - 1);
            }
            else
            {
                Lbl_Rowcount.Text = "0";
            }
        }
        #endregion
        private  void DatasetPatern(EventLog evLog)
        {
            var ALLName = "";
            var CateName = "";
            int iCnt = evLog.Entries.Count;
            //DateTime値に変換する文字列
            var dt1 = dateTimePicker1.Value;
            DataSet ds = new DataSet();
            DataTable dt = LogTabel(ds);
            DataRow dr;
            for (int i = iCnt - 1; i >= 0; i--)
            {
                if (ALLEvent(evLog, i) == false) { continue; }
                if (evLog.Entries[i].TimeWritten <= dt1.Date)
                {
                    break;
                }
                else
                {
                    dr = dt.NewRow();
                    GridValues(dr, evLog.Entries, i);
                    dt.Rows.Add(dr);
                    //sourcename取得
                    if (0 > ALLName.IndexOf(evLog.Entries[i].Source))
                    {
                        ALLName += evLog.Entries[i].Source + ",";
                    }
                    //カテゴリー取得
                    if (0 > CateName.IndexOf(evLog.Entries[i].Category))
                    {
                        CateName += evLog.Entries[i].Category + ",";
                    }
                }
            }
            dgView.DataSource = ds;
            //dgView.DataSource = dttest;
            dgView.DataMember = "Computer";
            ALLS = ALLName;
            ALLC = CateName;
            Gridview();


        }
        private void ListDatePatern(EventLog evLog)
        {

            var ALLName = "";
            var CateName = "";
            int iCnt = evLog.Entries.Count;
            //DateTime値に変換する文字列
            var dt1 = dateTimePicker1.Value;
            List<ViewDate> dttest = new List<ViewDate>();

            for (int i = iCnt - 1; i >= 0; i--)
            {
                if (ALLEvent(evLog, i) == false) { continue; }
                if (evLog.Entries[i].TimeWritten <= dt1.Date)
                {
                    break;
                }
                else
                {
                    ViewDate tm = new ViewDate();
                    var objlog = evLog.Entries[i];
                    if (objlog.EntryType == 0) { tm.Level = "Information"; } else { tm.Level = evLog.Entries[i].EntryType.ToString(); }
                    tm.TimeWritten = objlog.TimeWritten;
                    tm.Source = objlog.Source;
                    tm.EventID = objlog.EventID;
                    tm.Category = objlog.Category;
                    tm.Message = objlog.Message;
                    tm.MachineName = objlog.MachineName;
                    if (objlog.UserName == "NT AUTHORITY\\SYSTEM")
                    {
                        tm.UserName = "SYSTEM";
                    }
                    else if (objlog.UserName == null)
                    {
                        tm.UserName = "N/A";
                    }
                    else
                    {
                        tm.UserName = objlog.UserName;
                    }
                    dttest.Add(tm);

                    //sourcename取得
                    if (0 > ALLName.IndexOf(objlog.Source))
                    {
                        ALLName += objlog.Source + ",";
                    }
                    //カテゴリー取得
                    if (0 > CateName.IndexOf(objlog.Category))
                    {
                        CateName += objlog.Category + ",";
                    }
                }
            }
            dgView.DataSource = dttest;
            ALLS = ALLName;
            ALLC = CateName;
            Gridview();
        }
        private void ForeachPatern(EventLog evLog)
        {
            var ALLName = "";
            var CateName = "";
            int iCnt = evLog.Entries.Count;
            //DateTime値に変換する文字列
            var dt1 = dateTimePicker1.Value;
            List<ViewDate> dttest = new List<ViewDate>();
            //foreach (EventLogEntry LogRow in evLog.Entries)
            //{
                //if (ALLEvent(evLog, i) == false) { continue; }
                //if (LogRow.TimeWritten <= dt1.Date)
                //{
                //    continue;
                //}
                //else
                //{
                    //test
                    //string[] item = new string[2];
                    //if (LogRow.EntryType == 0) { item[0] = "Information"; } else { item[0] = LogRow.EntryType.ToString(); }

                    ////item[1] = evLog.Entries[i].TimeWritten.ToString();
                    ////item[2] = evLog.Entries[i].Source;
                    ////item[3] = evLog.Entries[i].EventID.ToString();
                    ////item[4] = evLog.Entries[i].Category;
                    ////item[5] = evLog.Entries[i].Message;
                    ////item[6] = evLog.Entries[i].MachineName;
                    //if (LogRow.UserName == "NT AUTHORITY\\SYSTEM")
                    //{
                    //    item[1] = "SYSTEM";
                    //}
                    //else if (LogRow.UserName == null)
                    //{
                    //    item[1] = "N/A";
                    //}
                    //else
                    //{
                    //    item[1] = LogRow.UserName;
                    //}
                    //dttest.Add(new test(item[0], LogRow.TimeWritten, LogRow.Source, LogRow.EventID, LogRow.Category, LogRow.Message, LogRow.MachineName, item[1]));

                    //test

                    //sourcename取得
                    //if (0 > ALLName.IndexOf(LogRow.Source))
                    //{
                    //    ALLName += LogRow.Source + ",";
                    //}
                    ////カテゴリー取得
                    //if (0 > CateName.IndexOf(LogRow.Category))
                    //{
                    //    CateName += LogRow.Category + ",";
                    //}
                //}
            //}
            dgView.DataSource = evLog.Entries;
            ALLS = ALLName;
            ALLC = CateName;
            //Gridview();
        }
        //private void  test()
        //{
        //    this.dgView.AutoGenerateColumns = false;
        //    var col0 = new DataGridViewColumn();
        //    var col1 = new DataGridViewColumn();
        //    var col2 = new DataGridViewColumn();
        //    var col3 = new DataGridViewColumn();
        //    var col4 = new DataGridViewColumn();
        //    var col5 = new DataGridViewColumn();
        //    var col6 = new DataGridViewColumn();
        //    var col7 = new DataGridViewColumn();
        //    col0.Name = "level";
        //    col0.HeaderText = "Level";
        //    col0.DataPropertyName = "Level";
        //    col1.Name = "timeWritten";
        //    col1.HeaderText = "TimeWritten";
        //    col1.DataPropertyName = "TimeWritten";

        //    col2.Name = "source";
        //    col2.HeaderText = "Source";
        //    col2.DataPropertyName = "Source";
        //    col3.Name = "eventID";
        //    col3.HeaderText = "EventID";
        //    col3.DataPropertyName = "EventID";

        //    col4.Name = "category";
        //    col4.HeaderText = "Category";
        //    col4.DataPropertyName = "Category";
        //    col5.Name = "message";
        //    col5.HeaderText = "Message";
        //    col5.DataPropertyName = "Message";

        //    col6.Name = "machineName";
        //    col6.HeaderText = "MachineName";
        //    col6.DataPropertyName = "MachineName";
        //    col7.Name = "userName";
        //    col7.HeaderText = "UserName";
        //    col7.DataPropertyName = "UserName";
        //    dgView.Columns.Add(col0);
        //    dgView.Columns.Add(col1);
        //    dgView.Columns.Add(col2);
        //    dgView.Columns.Add(col3);
        //    dgView.Columns.Add(col4);
        //    dgView.Columns.Add(col5);
        //    dgView.Columns.Add(col6);
        //    dgView.Columns.Add(col7);

        //}


    }




}
public class ViewDate
{
    public string Level { get; set; }
    public DateTime TimeWritten { get; set; }
    public string Source { get; set; }
    public int EventID { get; set; }
    public string Category { get; set; }
    public string Message { get; set; }
    public string MachineName { get; set; }
    public string UserName { get; set; }
}



public class DataGridViewEx : DataGridView
{
    public DataGridViewEx()
    {
        this.DoubleBuffered = true;
    }
}