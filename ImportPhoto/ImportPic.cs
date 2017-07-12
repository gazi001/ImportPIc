using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;
using System.Net;


namespace ImportPhoto
{
    public partial class ImportPic : Form
    {
        
        string OrderCode;
        public ImportPic()
        {
            InitializeComponent();
            LoadListView();
            this.FormClosed += (sender, e) =>
            {
                Application.Exit();
                System.Diagnostics.Process pro = System.Diagnostics.Process.GetCurrentProcess();
                pro.Kill();
            };
        }
        public ImportPic(string[] args)
        {
            InitializeComponent();
            LoadListView();
           
            this.OrderCode = args[0].ToString().Substring(5);
           //MessageBox.Show(this.OrderCode);
            this.FormClosed += (sender, e) =>
            {
                Application.Exit();
                System.Diagnostics.Process pro = System.Diagnostics.Process.GetCurrentProcess();
                pro.Kill();
                
            };
        }
        /// <summary>
        /// 初始化上传列表
        /// </summary>
        void LoadListView()
        {
            listView1.View = View.Details;
            listView1.CheckBoxes = true;
            listView1.GridLines = true;
            listView1.Columns.Add("文件名", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("文件大小", 50, HorizontalAlignment.Center);
            listView1.Columns.Add("文件路径", 100, HorizontalAlignment.Center);
            listView1.Columns.Add("状态", 50, HorizontalAlignment.Center);
        }
        public delegate void DeleFile(int position);
        //public void Pro(int copy)
        //{

        //    if (this.progressBarEx1.InvokeRequired)
        //    {
        //        this.progressBarEx1.Invoke(new DeleFile(Pro), new object[] { copy });
        //        return;
        //    }
        //    foreach (ListViewItem lvi in listView1.CheckedItems)
        //    {
        //        string total = lvi.SubItems[1].Text;
        //        int pro = (int)((float)copy / long.Parse(total) * 100);
        //        if (pro <= progressBarEx1.Maximum)
        //        {
        //            progressBarEx1.Value = pro;
        //            progressBarEx1.Text = label1.Text.Split('：')[0].ToString() + Environment.NewLine + string.Format("上传进度:{0}%", pro) + Environment.NewLine + string.Format("已上传文件数：{0}/{1}", label1.Text.Split('：')[1].ToString(), label1.Text.Split('：')[2].ToString());

        //        }
        //    }

        //}
        /// <summary>
        /// 存储目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(fbd.SelectedPath + "\\" + OrderCode) == false)//如果不存在就创建file文件夹
                {
                    Directory.CreateDirectory(fbd.SelectedPath + "\\" + OrderCode);
                }
                textBox1.Text = fbd.SelectedPath+"\\"+OrderCode;
            }
        }
        /// <summary>
        /// 选择图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoosePhotoes_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in ofd.FileNames)
                {
                    FileInfo fi = new FileInfo(filename);
                    ListViewItem lvi = new ListViewItem(Path.GetFileNameWithoutExtension(filename));
                    lvi.Tag = filename;
                    //lvi.SubItems.Add(fi.Length.ToString());
                    lvi.SubItems.Add((fi.Length / (1024 * 1024)).ToString() + "M");
                    lvi.SubItems.Add(Path.GetDirectoryName(filename));
                    lvi.SubItems.Add("未导入");
                    listView1.Items.Add(lvi);
                }

            }

        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Equals(""))
            {
                MessageBox.Show("请先选择存储目录..!");
            }
            else
            {

                if (listView1.Items.Count > 0)
                {
                    int j = 0;
                    string count = listView1.CheckedItems.Count.ToString();
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        try
                        {
                            if (listView1.Items[i].Checked)
                            {
                                j++;
                                string fileName = Path.GetFileName(listView1.Items[i].Tag.ToString());
                                label1.Text = string.Format("正在上传文件:[{0}]", listView1.Items[i].Text) + "：" + j.ToString() + "/" + count;
                                System.IO.File.Copy(listView1.Items[i].Tag.ToString(), Path.Combine(textBox1.Text, fileName), true);
                                var result = SavePath(fileName, Path.Combine(textBox1.Text, fileName), OrderCode);
                                if (result == "ok")
                                {
                                    listView1.Items[i].Checked = false;
                                    listView1.Items[i].SubItems[3].Text = "导入成功";
                                }
                                if (result == "exist")
                                {
                                    MessageBox.Show(fileName + "已存在!");
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("出现错误请重新保存~");
                            
                        }
                       
                    }
                    MessageBox.Show("上传成功!");
                }
                else
                {
                    return;
                }
            }     
        }
        public string SavePath(string fileName, string path, string ordercode)
        {
            string strURL = "http://localhost:15964/ashx/image/SaveImagePath.ashx";

            var request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            
            string param = "filename=" + fileName + "&path=" + Path.Combine(textBox1.Text, fileName) + "&ordercode=" + OrderCode;
            ASCIIEncoding encoding = new ASCIIEncoding();
            
            byte[] data = encoding.GetBytes(param);
            request.ContentLength = data.Length;
            System.IO.Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            var response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.StreamReader streamReader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string responseText = streamReader.ReadToEnd();
            streamReader.Close();

            return responseText;
 
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelPhotoes_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.CheckedItems)
            {
                lvi.Remove();
            }
        }
    }

}
