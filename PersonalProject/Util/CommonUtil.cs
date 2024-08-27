<<<<<<< HEAD
﻿using System;
=======
﻿using PersonalProject;
using System;
>>>>>>> a1f384a (COMMIT 1)
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

<<<<<<< HEAD
namespace PersonalProject
{
    public class CommonUtil
    {
        public static void ComboBinding(ComboBox cbo, DataTable dt, string display, string value, bool blankItem = true, string blankText = "선택", bool isStringValue=false)
=======

public class CommonUtil
{
    static List<string> smallUnit = new List<string>() { "g", "mL", "cc" };
    static List<string> largeUnit = new List<string>() { "kg", "L" };

    //단위 변환시 곱해야할 값(Name)
    public static double UnitNameConversion(string originalUnitName, string unitNameToConvert)
    {
        double conversion = 1.0;

        if (originalUnitName != unitNameToConvert)
        {
            if (smallUnit.Contains(originalUnitName, StringComparer.OrdinalIgnoreCase) && largeUnit.Contains(unitNameToConvert, StringComparer.OrdinalIgnoreCase)) conversion = 0.001;
            else if (largeUnit.Contains(originalUnitName, StringComparer.OrdinalIgnoreCase) && smallUnit.Contains(unitNameToConvert, StringComparer.OrdinalIgnoreCase)) conversion = 1000;
        }

        //if (originalUnitName != unitNameToConvert)
        //{
        //    if (originalUnitName == "g" && unitNameToConvert == "kg") conversion = 0.001;
        //    else if (originalUnitName == "kg" && unitNameToConvert == "g") conversion = 1000;
        //}

        return conversion;
    }


    //단위 변환시 곱해야할 값(Code)
    public static double UnitCodeConversion(string originalUnitCode, string unitCodeToConvert)
    {
        double conversion = 1.0;

        if (originalUnitCode != unitCodeToConvert)
        {
            if (smallUnit.Contains(originalUnitCode, StringComparer.OrdinalIgnoreCase) && largeUnit.Contains(unitCodeToConvert, StringComparer.OrdinalIgnoreCase)) conversion = 0.001;
            else if (largeUnit.Contains(originalUnitCode, StringComparer.OrdinalIgnoreCase) && smallUnit.Contains(unitCodeToConvert, StringComparer.OrdinalIgnoreCase)) conversion = 1000;
        }

        //if (originalUnitCode != unitCodeToConvert)
        //{
        //    if (originalUnitCode == "U002" && unitCodeToConvert == "U001") conversion = 0.001;
        //    else if (originalUnitCode == "U001" && unitCodeToConvert == "U002") conversion = 1000;
        //}

        return conversion;
    }

    /// <summary>
    /// 단위 변환시 곱해야할 값 반환
    /// </summary>
    /// <param name="originalUnit"></param>
    /// <param name="unitToConvert"></param>
    /// <returns>단위 변환시 곱해야할 값</returns>
    public static double UnitConversion(string originalUnit, string unitToConvert)
    {
        double conversion = 1.0;

        if (originalUnit != unitToConvert)
        {
            if (originalUnit.Length == 4 && originalUnit.StartsWith("U"))
            {
                if (smallUnit.Contains(originalUnit, StringComparer.OrdinalIgnoreCase) && largeUnit.Contains(unitToConvert, StringComparer.OrdinalIgnoreCase)) conversion = 0.001;
                else if (largeUnit.Contains(originalUnit, StringComparer.OrdinalIgnoreCase) && smallUnit.Contains(unitToConvert, StringComparer.OrdinalIgnoreCase)) conversion = 1000;
            }
            else
            {
                if (smallUnit.Contains(originalUnit, StringComparer.OrdinalIgnoreCase) && largeUnit.Contains(unitToConvert, StringComparer.OrdinalIgnoreCase)) conversion = 0.001;
                else if (largeUnit.Contains(originalUnit, StringComparer.OrdinalIgnoreCase) && smallUnit.Contains(unitToConvert, StringComparer.OrdinalIgnoreCase)) conversion = 1000;
            }
        }

        //if (originalUnit.Length == 4)
        //{
        //    if (originalUnit != unitToConvert)
        //    {
        //        if (originalUnit == "U002" && unitToConvert == "U001") conversion = 0.001;
        //        else if (originalUnit == "U001" && unitToConvert == "U002") conversion = 1000;
        //    }

        //}
        //else
        //{
        //    if (originalUnit != unitToConvert)
        //    {
        //        if (originalUnit == "g" && unitToConvert == "kg") conversion = 0.001;
        //        else if (originalUnit == "kg" && unitToConvert == "g") conversion = 1000;
        //    }
        //}

        return conversion;
    }


    public static void ComboBinding(ComboBox cbo, DataTable dt, string display, string value, bool blankItem = true, string blankText = "선택", bool isStringValue=false)
>>>>>>> a1f384a (COMMIT 1)
        {

            if (blankItem)
            {
                DataRow dr1 = dt.NewRow();
                if(isStringValue)
                    dr1[value] = "";
                else
                    dr1[value] = 0;
                dr1[display] = blankText;
                dt.Rows.InsertAt(dr1, 0);
                dt.AcceptChanges();
            }

            //if (inputItem)
            //{
            //    DataRow dr2 = dt.NewRow();
            //    dr2[value] = "직접 입력";
            //    dr2[display] = "직접 입력";
            //    dt.Rows.Add(dr2);
            //    dt.AcceptChanges();
            //}



            DataView dv = new DataView(dt);
            cbo.DisplayMember = display;
            cbo.ValueMember = value;
            cbo.DataSource = dv;
        }

<<<<<<< HEAD


        public static void ComboBinding(ComboBox cbo, DataTable dt, string category, bool blankItem=true, string blankText="선택", bool inputItem=false)
=======
    //콤보박스 바인딩
    public static void ComboBinding(ComboBox cbo, List<CommonVO> list, string gubun, bool blankItem = true, string blankText = "")
    {
        var codeList = list.Where((item) => item.Category.Equals(gubun)).ToList();
        if (blankItem)
        {
            CommonVO blank = new CommonVO
            {
                Code = "",
                Name = blankText,
                Category = gubun
            };
            codeList.Insert(0, blank);
        }

        cbo.DisplayMember = "Name";
        cbo.ValueMember = "Code";
        cbo.DataSource = codeList;
    }

    

    public static void ComboBinding(ComboBox cbo, DataTable dt, string category, bool blankItem=true, string blankText="선택", bool inputItem=false)
>>>>>>> a1f384a (COMMIT 1)
        {
            if (blankItem)
            {
                DataRow dr1 = dt.NewRow();
                dr1["CCode"] = "";
                dr1["CName"] = blankText;
                dr1["Category"] = category;
                dt.Rows.InsertAt(dr1, 0);
                dt.AcceptChanges();
            }
            
            if (inputItem)
            {
                DataRow dr2 = dt.NewRow();
                dr2["CCode"] = "직접 입력";
                dr2["CName"] = "직접 입력";
                dr2["Category"] = category;
                dt.Rows.Add(dr2);
                dt.AcceptChanges();
            }

            DataView dv = new DataView(dt);
            dv.RowFilter = "Category = '" + category + "'";
            cbo.DisplayMember = "CNAME";
            cbo.ValueMember = "CCODE";
            cbo.DataSource = dv;
        }


<<<<<<< HEAD
        public static void MenuBinding(DataTable dt, ComboBox cbo, string category, string pcode, string display="전체")
=======
    //패널 위 컨트롤 초기화
    public static void ClearControls(Panel pnl)
    {
        foreach (Control ctrl in pnl.Controls)
        {
            if (ctrl is Label lbl)
                lbl.Text = "";
            else if (ctrl is TextBox txt)
                txt.Text = "";
            else if (ctrl is ComboBox cbo)
            {
                if (cbo.DataSource != null)
                {
                    cbo.SelectedIndex = 0;
                    if (cbo.SelectedValue.ToString().Length > 0)
                        cbo.SelectedIndex = -1;
                }
            }
            else if (ctrl is DateTimePicker dtp)
                dtp.Value = DateTime.Now;
            else if (ctrl is NumericUpDown nud)
                nud.Value = 0;
        }
    }

    public static void MenuBinding(DataTable dt, ComboBox cbo, string category, string pcode, string display="전체")
>>>>>>> a1f384a (COMMIT 1)
        {
            //DataTable dt = new DataTable();
            //MySqlConnection conn = new MySqlConnection(strConn);
            //string sql = "select Code, Name from commoncode where Category='M_TYPE' and PCode = @mtype";
            //MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            //da.SelectCommand.Parameters.AddWithValue("@mtype", mtype);

            //da.Fill(dt);
            //conn.Close();

            //DataTable에 Row를 추가하는 방법
            //DataRow dr = dt.NewRow();
            //dr["Code"] = "";
            //dr["Name"] = "선택";
            //dt.Rows.InsertAt(dr, 0);
            //dt.AcceptChanges(); //datatable의 변경내역을 반영 commit
            if (dt == null) return;
            //DataTable dtNew = new DataTable("dt");
            

            DataRow dr = dt.Rows[0];
            if (!string.IsNullOrWhiteSpace(dr["CCODE"].ToString()) || dr["CATEGORY"].ToString() != category) //) dt.Rows[0].IsNull("CCODE") || 
            {
                dr = dt.NewRow();

                dr["CCODE"] = "";
                dr["CNAME"] = display;
                dr["CATEGORY"] = category;
                dr["PCODE"] = pcode;
                dt.Rows.InsertAt(dr, 0);
                dt.AcceptChanges();

            }
            //Debug.WriteLine("확인");

            //Debug.WriteLine(dt.Rows[0]);
            //Debug.WriteLine(dt.Rows[0]["CCODE"]);
            //Debug.WriteLine(dt.Rows[0]["CNAME"]);
            //Debug.WriteLine(dt.Rows[0]["PCODE"]);

            DataView dv = new DataView(dt);
            if (string.IsNullOrWhiteSpace(pcode))
                dv.RowFilter = $"PCODE IS NULL and Category = '" + category + "'";
            else
                dv.RowFilter = $"PCODE='{pcode}'";
            ////DataRowView rowView = dv.AddNew()

            //// Change values in the DataRow.
            //rowView["CNAME"] = "전체";
            //rowView.EndEdit();

            cbo.DisplayMember = "CNAME";
            cbo.ValueMember = "CCODE";
            cbo.DataSource = dv;

            //bds.Filter = $"PCODE='{pcode}'";
            ////bds.AddNew();

            //cbo.DisplayMember = "CNAME";
            //cbo.ValueMember = "CCODE";
            //cbo.DataSource = bds;
        }

<<<<<<< HEAD
        public static void MtypeDataBinding(BindingSource bds, ComboBox cbo)
=======
    internal static void ComboBindingEmail(EmailUserControl email, PersonalProject.Brand currentBrand)
    {
        throw new NotImplementedException();
    }

    public static void MtypeDataBinding(BindingSource bds, ComboBox cbo)
>>>>>>> a1f384a (COMMIT 1)
        {
            //DataTable dt = new DataTable();
            //MySqlConnection conn = new MySqlConnection(strConn);
            //string sql = "select Code, Name from commoncode where Category='M_TYPE' and PCode is null";
            //MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            //da.Fill(dt);
            //conn.Close();

            ////DataTable에 Row를 추가하는 방법
            //DataRow dr = dt.NewRow();
            //dr["CCODE"] = "";
            //dr["CNAME"] = "선택";
            //dt.Rows.InsertAt(dr, 0);
            //dt.AcceptChanges(); //datatable의 변경내역을 반영 commit

            bds.Filter = "PCODE IS NULL";
            //bds.AddNew("선택");


            cbo.DisplayMember = "CNAME";
            cbo.ValueMember = "CCODE";
            cbo.DataSource = bds;
        }


<<<<<<< HEAD
        public static void SetTreeView(TreeView treeView ,DataTable dt)
=======
    public static void SetTreeView(TreeView treeView ,DataTable dt)
>>>>>>> a1f384a (COMMIT 1)
        {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();
            //TreeView treeView = new TreeView();
            //DataView dv = new DataView(dt);
            //int i=0;
            DataRow[] mains, middles, subs;
            mains = dt.Select($"PCODE IS NULL");
            int mainIndex = 0;
            //TreeNode mainNode, middleNode;

            //TreeNode rootNode = new TreeNode();
            //rootNode.Text = "전체";
            //rootNode.Name = mains[i]["CCODE"].ToString();
            //node0.Tag = mains[i]["CCODE"].ToString();

            treeView.Nodes.Add("전체");
            //List<TreeNode> mainTrees = new List<TreeNode>();

            //List<TreeNode> middleTrees = new List<TreeNode>();

            for (int i = 0; i < mains.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(mains[i]["CCODE"].ToString())) continue;

                TreeNode node0 = new TreeNode();
                node0.Text = mains[i]["CNAME"].ToString();
                node0.Name = mains[i]["CCODE"].ToString();
                node0.Tag = null;
                //node0.Tag = mains[i]["CCODE"].ToString();

                treeView.Nodes[0].Nodes.Add(node0);
                
                middles = dt.Select($"PCODE='{mains[i]["CCODE"]}'");
                //TreeNode[] middlesArray = new TreeNode[middles.Length];

                for (int j = 0; j < middles.Length; j++)
                {
                    if (string.IsNullOrWhiteSpace(middles[j]["CCODE"].ToString())) continue;

                    TreeNode node1 = new TreeNode();
                    node1.Text = middles[j]["CNAME"].ToString();
                    node1.Name = middles[j]["CCODE"].ToString();
                    node1.Tag = mains[i]["CCODE"].ToString();

                    treeView.Nodes[0].Nodes[mainIndex].Nodes.Add(node1);
                    //mainNode.Nodes.Add(middles[j]["CCODE"].ToString(), middles[j]["CNAME"].ToString());
                    //middlesArray[j] = new TreeNode(middles[j]["CNAME"].ToString());

                    //middleTrees.Add(middleNode);
                    subs = dt.Select($"PCODE='{middles[j]["CCODE"]}'");
                    //TreeNode[] subsArray = new TreeNode[subs.Length];

                    for (int k = 0; k < subs.Length; k++)
                    {
                        if (string.IsNullOrWhiteSpace(subs[k]["CCODE"].ToString())) continue;

                        TreeNode node2 = new TreeNode();
                        node2.Text = subs[k]["CNAME"].ToString();
                        node2.Name = subs[k]["CCODE"].ToString();
                        node2.Tag = middles[j]["CCODE"].ToString();

                        treeView.Nodes[0].Nodes[mainIndex].Nodes[j].Nodes.Add(node2);
                        //subsArray[k] = new TreeNode(subs[k]["CNAME"].ToString());

                        //middleNode.Nodes.Add(subs[j]["CCODE"].ToString(), subs[k]["CNAME"].ToString());
                    }
                    //midIndex++;
                    //treeView.Nodes.Add(middleTrees[j]);
                    //treeView.Nodes.Add(middleNode);
                    //TreeNode middleNode = new TreeNode(middles[j]["CNAME"].ToString(), subsArray);
                    //treeView.Nodes[i].Nodes.Add(middleNode);

                }
                mainIndex++;
                //TreeNode mainNode = new TreeNode(mains[i]["CNAME"].ToString(), middlesArray);
                //mainTrees.Add(mainNode);
                //treeView.Nodes.Add(mainNode);

                //TreeNode customerNode = new TreeNode(myCustomer.CustomerName,middlesArray);

                //treeView.Nodes[i].Nodes.Add(customerNode);
            }
            treeView.EndUpdate();
            // 모든 트리 노드를 보여준다
            treeView.ExpandAll();

            //return treeView;
        }

        public static void SendMail(string subject, string body, string to)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true; //SSL을 사용한다.
                client.UseDefaultCredentials = false; //시스템에 설정된 인증 정보를 사용하지 않는다.
<<<<<<< HEAD
                client.Credentials = new NetworkCredential("kimj02193", "gmail계정비밀번호");
=======
                client.Credentials = new NetworkCredential("kimj02193", "wlsdud!0707");
>>>>>>> a1f384a (COMMIT 1)
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage message = new MailMessage(from: new MailAddress("kimj02193@gmail.com"), new MailAddress(to));
                message.Subject = subject;
                message.Body = body;

                //message.SubjectEncoding = Encoding.UTF8;
                //message.BodyEncoding = Encoding.UTF8;

                client.Send(message);
            }
            catch(Exception err)
            {
                Debug.WriteLine(err);
            }
        }
        public static bool IsValidEmail(string email)
        {
            bool valid = Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
            return valid;
        }

        public static string CombineEmail(EmailUserControl email)
        {

            if (email.CboEmail.Text == "직접 입력")
                return string.Concat(email.TxtEmail1.Text, "@", email.TxtEmail2.Text);
            else
                return string.Concat(email.TxtEmail1.Text, "@", email.CboEmail.Text);
        }

        public static bool IsValidPassword(string password)
        {
            bool valid = Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\W]).{8,20}$");
            return valid;
        }

        public static string GetImagePath(string imagePath, string newImageName, string folderName, string ID)
        {
            //지정된 폴더로 파일을 복사
            string sPath = ConfigurationManager.AppSettings["uploadPath"] + $"{folderName}/{ID}/";
            string localFile = imagePath;
            string sExt = localFile.Substring(localFile.LastIndexOf("."));
            string newFileName = newImageName + sExt;
            string destFileName = sPath + newFileName;

            if (!Directory.Exists(sPath)) //디렉토리가 없다면 디렉토리를 생성
            {
                Directory.CreateDirectory(sPath);
            }
            File.Copy(localFile, destFileName, true); //파일을 복사

            return destFileName;

            //C:\Users\GD\Documents\WorkLog\Work_20211005HHmmssfff_1.log
            //writePath = C:\Users\GD\Documents\WorkLog
            //string fileName = Path.Combine(writePath, $"Work_{DateTime.Now.ToString("yyyyMMddHHmmssfff")}_{machineID}.log");

            //UpdateImageFile(brand.ID, destFileName);

        }

        public static void ComboBindingEmail(EmailUserControl email)
        {
            string[] category = { "이메일 주소" };

            CommonDAC dac = new CommonDAC();
            DataTable dt = dac.GetCommonCodes(category);

            ComboBinding(email.CboEmail, dt, "이메일 주소", inputItem: true);
            Debug.WriteLine(email.Email2);

        }


        public static void ComboBindingEmail(EmailUserControl email, Customer CustomerInfo)
        {
            string[] category = { "이메일 주소" };

            CommonDAC dac = new CommonDAC();
            DataTable dt = dac.GetCommonCodes(category);

            ComboBinding(email.CboEmail, dt, "이메일 주소", inputItem: true);
            Debug.WriteLine(email.Email2);

            
            if (CustomerInfo.Email2.Contains(".")) //email.CboEmail.Text == "직접 입력" || email.TxtEmail2.Text.Contains(".")
            {
                email.TxtEmail2.Visible = true;
                email.CboEmail.Location = new Point(296, 0);

                email.CboEmail.SelectedIndex = email.CboEmail.FindString("직접 입력");
                email.TxtEmail2.Text = email.Email2;

                email.TxtEmail2.Focus();
            }
            else
            {
                email.TxtEmail2.Visible = false;
                email.CboEmail.Location = email.TxtEmail2.Location;
                DataRow[] rows = dt.Select($"CCODE='{CustomerInfo.Email2}'");
                email.CboEmail.SelectedIndex = email.CboEmail.FindString(rows[0]["CNAME"].ToString());
                //email.Email2 = email.CboEmail.SelectedValue.ToString();
            }

        }


        public static void ComboBindingEmail(EmailUserControl email, Brand BrandInfo)
        {
            string[] category = { "이메일 주소" };

            CommonDAC dac = new CommonDAC();
            DataTable dt = dac.GetCommonCodes(category);

            ComboBinding(email.CboEmail, dt, "이메일 주소", inputItem: true);
            Debug.WriteLine(email.Email2);


            if (BrandInfo.Email2.Contains(".")) //email.CboEmail.Text == "직접 입력" || email.TxtEmail2.Text.Contains(".")
            {
                email.TxtEmail2.Visible = true;
                email.CboEmail.Location = new Point(296, 0);

                email.CboEmail.SelectedIndex = email.CboEmail.FindString("직접 입력");
                email.TxtEmail2.Text = email.Email2;

                email.TxtEmail2.Focus();
            }
            else
            {
                email.TxtEmail2.Visible = false;
                email.CboEmail.Location = email.TxtEmail2.Location;
                DataRow[] rows = dt.Select($"CCODE='{BrandInfo.Email2}'");
                email.CboEmail.SelectedIndex = email.CboEmail.FindString(rows[0]["CNAME"].ToString());
            }

        }

<<<<<<< HEAD
=======


>>>>>>> a1f384a (COMMIT 1)
        //public static void Email(EmailUserControl email, DataTable dt, Customer CustomerInfo)
        //{
            
        //    if (CustomerInfo.Email2.Contains(".")) //email.CboEmail.Text == "직접 입력" || email.TxtEmail2.Text.Contains(".")
        //    {
        //        email.TxtEmail2.Visible = true;
        //        email.CboEmail.Location = new Point(296, 0);

        //        email.CboEmail.SelectedIndex = email.CboEmail.FindString("직접 입력");
        //        email.TxtEmail2.Text = email.Email2;

        //        email.TxtEmail2.Focus();
        //    }
        //    else
        //    {
        //        email.TxtEmail2.Visible = false;
        //        email.CboEmail.Location = email.TxtEmail2.Location;
        //        DataRow[] rows = dt.Select($"CCODE='{CustomerInfo.Email2}'");
        //        email.CboEmail.SelectedIndex = email.CboEmail.FindString(rows[0]["CNAME"].ToString());
        //    }

        //}

<<<<<<< HEAD
    }
}
=======
}

>>>>>>> a1f384a (COMMIT 1)
