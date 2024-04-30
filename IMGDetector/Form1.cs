using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace IMGDetector
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //listView1.Columns.Add("No", 10, HorizontalAlignment.Left);
            //listView1.Columns.Add("Image Source", 30, HorizontalAlignment.Left);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();  // Clear previous items

            // Load the HTML from the TextBox
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(textBox1.Text);

            // Use HtmlAgilityPack to find all <img> elements
            var images = htmlDoc.DocumentNode.SelectNodes("//img[@src]");

            if (images != null)
            {
                //MessageBox.Show(images.Count().ToString());
                int count = 1;
                foreach (var img in images)
                {
                    // Extract the src attribute
                    string src = img.GetAttributeValue("src", string.Empty);
                    //MessageBox.Show(src.Substring(0, 30));
                    string[] itemStr = new string[] { (count++).ToString() , src.Split(',').Count() == 2 ? src.Split(',')[1] : "NO DATA", src.Split(',').Count() == 2 ? src.Split(',')[1].Length.ToString() : "NO DATA" };
                    // Add the src to the ListView
                    ListViewItem item = new ListViewItem(itemStr);
                    
                    listView1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("No <img> tags found!");
            }
        }
    }
}
