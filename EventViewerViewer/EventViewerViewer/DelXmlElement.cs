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
        }

        private void btn_Delele_Click(object sender, EventArgs e)
        {
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
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            var xDoc = XDocument.Load(docName);
            XElement element = xDoc.Element("Fillter");
            element.RemoveAll();
            xDoc.Save(docName);

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
