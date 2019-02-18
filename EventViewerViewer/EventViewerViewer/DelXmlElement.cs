using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace EventViewerViewer
{
    public partial class DelXmlElement : Form
    {
        public string docName { get; set; }
        public DelXmlElement()
        {
            InitializeComponent();
        }

        private void DelXmlElement_Load(object sender, EventArgs e)
        {
            dgv_xml.DataSource = XmlDataList();
            Gridview();
        }
        public  void Display()
        {
            dgv_xml.DataSource = XmlDataList();
            Gridview();
        }
        private void btn_Delele_Click(object sender, EventArgs e)
        {
            if (dgv_xml.RowCount < 1) return;
            int Cvalindex = dgv_xml.CurrentCell.RowIndex;
            XDocument xDoc = XDocument.Load(docName);
            XDocument strXML = XDocument.Parse(xDoc.Document.ToString());
            strXML.Element("Fillter").Elements().ElementAt(Cvalindex).Remove();
            strXML.Save(docName);
            dgv_xml.DataSource = XmlDataList();

        }
        private List<XMLData> XmlDataList()
        {
            List<XMLData> objdata = new List<XMLData>();
            XDocument xDoc = XDocument.Load(docName);
            var element = (from o in xDoc.Element("Fillter").Elements() select o);
            foreach (XElement objex in element)
            {
                var dt = new XMLData();
                dt.ColName = objex.Name.ToString();
                dt.Values = objex.Value;
                objdata.Add(dt);
            }
            return objdata;
        }

        private void dgv_xml_DataSourceChanged(object sender, EventArgs e)
        {
            dgv_xml.CausesValidation = false;
            //初期選択をなくす
            dgv_xml.CurrentCell = null;

        }
        public void Gridview()
        {

            //幅
            dgv_xml.Columns[0].Width = 70;
            dgv_xml.Columns[1].Width = 120;
            //初期選択をなくす
            dgv_xml.CurrentCell = null;
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("除外内容をすべて削除します、よろしいですか？", "注意", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel) return;


            var xDoc = XDocument.Load(docName);
            XElement element = xDoc.Element("Fillter");
            element.RemoveAll();
            xDoc.Save(docName);
            dgv_xml.DataSource = XmlDataList();
            //XmlDocument xmlDoc = new XmlDocument();
            //using (FileStream stream = new FileStream(documentPath(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            //{

            //    xmlDoc.Load(stream);
            //    XmlElement rootelement = xmlDoc.DocumentElement;
            //    rootelement.RemoveAll();

            //    xmlDoc.Save(documentPath());

            //    stream.Close();
            //}
        }
    }
    public class XMLData
    {
        public string ColName { get; set; }
        public string Values { get; set; }
    }
}
