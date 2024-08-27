<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
=======
﻿using PersonalProject;
using System;
using System.Collections.Generic;
using System.Drawing;
>>>>>>> a1f384a (COMMIT 1)
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

<<<<<<< HEAD
namespace PersonalProject
{
=======

>>>>>>> a1f384a (COMMIT 1)
    public class DataGridViewUtil
    {
        public static void SetInitGridView(DataGridView dgv)
        {
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // 특정 cell 하나를 클릭해도, 줄 전체가 선택
            dgv.AllowUserToAddRows = false;  //맨 마지막 줄에 * 표시된 빈 줄 생성 방지
            dgv.AutoGenerateColumns = false; //DataSource를 바인딩해도 자동으로 컬럼이 추가되지 않는다. 수동컬럼추가해서 생성하겠다
        }

        //문자열(가변인 문자열) => 왼쪽정렬 : (기본값)
        //문자열(고정인 문자열) => 가운데정렬
        //숫자 => 수량, 재고량, 금액, 합계금액 등 => 오른쪽정렬
<<<<<<< HEAD
        public static void AddGridTextColumn(DataGridView dgv, 
            string headerText, 
            string propertyName, 
            DataGridViewContentAlignment align=DataGridViewContentAlignment.MiddleLeft, 
            int colWidth=100,
            bool visibility=true)
=======
        public static void AddGridTextColumn(DataGridView dgv,
            string headerText,
            string propertyName,
            DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft,
            int colWidth = 100,
            bool visibility = true,
            bool frozen=false)
>>>>>>> a1f384a (COMMIT 1)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.Name = propertyName;
            col.HeaderText = headerText;
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.DataPropertyName = propertyName;
            col.DefaultCellStyle.Alignment = align;
            col.Width = colWidth;
            col.Visible = visibility;
<<<<<<< HEAD
=======
            col.Frozen = frozen;
>>>>>>> a1f384a (COMMIT 1)
            col.ReadOnly = true; //그리드뷰에서 데이터수정불가
            dgv.Columns.Add(col);
        }

<<<<<<< HEAD
        public static QandA QandAOfCellIndex(DataGridView dv, int index)
        {
            QandA qa = new QandA()
            {
                ContactNumber = Convert.ToInt32(dv["CONTACT_NUMBER", index].Value),
                CustomerID = dv["CUSTOMER_ID", index].Value.ToString(),
                ProductCode = Convert.ToInt32(dv["PRODUCT_CODE", index].Value),
                ProductName = dv["PRODUCT_NAME", index].Value.ToString(),
                QuestionType = dv["QUESTION_TYPE", index].Value.ToString(),
                Title = dv["TITLE", index].Value.ToString(),
                Contents = dv["CONTENTS", index].Value.ToString(),
                Secret = Convert.ToBoolean(dv["SECRET", index].Value),
                Hits = Convert.ToInt32(dv["HITS", index].Value),
                RegistDateTime = Convert.ToDateTime(dv["REGIST_DATETIME", index].Value),
                BrandID = dv["BRAND_ID", index].Value.ToString()
            };
            if(! string.IsNullOrWhiteSpace(dv["ANSWER", index].Value.ToString().Trim()))
               qa.Answer = dv["ANSWER", index].Value.ToString();
            if (! string.IsNullOrWhiteSpace(dv["ANSWER_DATETIME", index].Value.ToString().Trim()))
                qa.AnswerDateTime = Convert.ToDateTime(dv["ANSWER_DATETIME", index].Value);
                
            
            return qa;
        }


        //public static Review ReviewOfCellIndex(DataGridView dv, int index)
        //{
        //    Review qa = new Review()
        //    {
        //        ContactNumber = Convert.ToInt32(dv["CONTACT_NUMBER", index].Value),
        //        CustomerID = dv["CUSTOMER_ID", index].Value.ToString(),
        //        ProductCode = Convert.ToInt32(dv["PRODUCT_CODE", index].Value),
        //        ProductName = dv["PRODUCT_NAME", index].Value.ToString(),
        //        QuestionType = dv["QUESTION_TYPE", index].Value.ToString(),
        //        Title = dv["TITLE", index].Value.ToString(),
        //        Contents = dv["CONTENTS", index].Value.ToString(),
        //        Secret = Convert.ToBoolean(dv["SECRET", index].Value),
        //        Hits = Convert.ToInt32(dv["HITS", index].Value),
        //        RegistDateTime = Convert.ToDateTime(dv["REGIST_DATETIME", index].Value),
        //        BrandID = dv["BRAND_ID", index].Value.ToString()
        //    };
        //    if (!string.IsNullOrWhiteSpace(dv["ANSWER", index].Value.ToString().Trim()))
        //        qa.Answer = dv["ANSWER", index].Value.ToString();
        //    if (!string.IsNullOrWhiteSpace(dv["ANSWER_DATETIME", index].Value.ToString().Trim()))
        //        qa.AnswerDateTime = Convert.ToDateTime(dv["ANSWER_DATETIME", index].Value);


        //    return qa;
        //}
    }
}
=======
        public static void AddGridCheckBoxColumn(DataGridView dgv, out CheckBox chkHeader,
            string headerText="",
            DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleCenter,
            int colWidth = 28,
            bool visibility = true,
            bool frozen = false)
        {
            chkHeader = null;
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                col.HeaderText = headerText;
            col.Name = "CheckBox";
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col.DefaultCellStyle.Alignment = align;
            col.Width = colWidth;
            col.Visible = visibility;
            col.Frozen = frozen;
            dgv.Columns.Add(col);

            if (string.IsNullOrWhiteSpace(headerText))
            {
                Point temp = dgv.GetCellDisplayRectangle(0, -1, true).Location;
                chkHeader = new CheckBox();
                chkHeader.Location = new Point(temp.X + 7, temp.Y + 3);
                chkHeader.Size = new Size(16, 16);
                chkHeader.BackColor = Color.White;
                dgv.Controls.Add(chkHeader);
            }
        }

        public static T GetInstancesFromRow<T>(DataGridViewRow value)
        {
            Func<DataGridViewRow, T> GetTFromRow = (row) =>
            {
                try
                {
                    T prod = Activator.CreateInstance<T>();
                    foreach (System.Reflection.PropertyInfo prop in prod.GetType().GetProperties())
                    {
                        //프로퍼티는 존재하는데, reader안에 조회된 컬럼이 없는 경우
                        //reader에 조회된 컬럼은 있는데, 프로퍼티는 정의되지 않은 경우
                        try
                        {
                            //System.Diagnostics.Debug.WriteLine($"{prop.Name} : {row.Cells[prop.Name].Value}");
                            System.Reflection.PropertyInfo propertyInfo = prod.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(prod, Convert.ChangeType(row.Cells[prop.Name].Value, propertyInfo.PropertyType), null);
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine($"예외발생-1 : {err.Message}");
                            System.Diagnostics.Debug.WriteLine($"예외발생-2 : {prop.Name}");
                            continue;
                        }
                    }
                    return prod;
                }
                catch (Exception err)
                {
                    System.Diagnostics.Debug.WriteLine(err.Message);
                    throw;
                }
            };

            T result = default(T);

            result = GetTFromRow(value);

            return result;
        }
        public static List<T> GetInstancesFromRows<T>(DataGridViewRowCollection rows)
        {
            Func<DataGridViewRow, T> GetTFromRow = (row) =>
            {
                try
                {
                    T prod = Activator.CreateInstance<T>();
                    foreach (System.Reflection.PropertyInfo prop in prod.GetType().GetProperties())
                    {
                        //프로퍼티는 존재하는데, reader안에 조회된 컬럼이 없는 경우
                        //reader에 조회된 컬럼은 있는데, 프로퍼티는 정의되지 않은 경우
                        try
                        {
                            //System.Diagnostics.Debug.WriteLine($"{prop.Name} : {row.Cells[prop.Name].Value}");
                            System.Reflection.PropertyInfo propertyInfo = prod.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(prod, Convert.ChangeType(row.Cells[prop.Name].Value, propertyInfo.PropertyType), null);
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine($"예외발생-1 : {err.Message}");
                            System.Diagnostics.Debug.WriteLine($"예외발생-2 : {prop.Name}");
                            continue;
                        }
                    }
                    return prod;
                }
                catch (Exception err)
                {
                    System.Diagnostics.Debug.WriteLine(err.Message);
                    throw;
                }
            };

            List<T> result = new List<T>();

            foreach (DataGridViewRow row in rows)
            {
                result.Add(GetTFromRow(row));
            }

            if (result != null && result.Count > 0) return result;
            else return null;
        }

        /// <summary>
        /// 데이터그리드 뷰에 보이는 Key : 프로퍼티명, Value : 컬럼명(header text) 반환
        /// </summary>
        /// <param name="dgv"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetDataGridViewPropName(DataGridView dgv)
        {
            Dictionary<string, string> pairs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var column in dgv.Columns)
            {
                if(column is DataGridViewTextBoxColumn col && col.Visible)
                { 
                    pairs.Add(col.Name, col.HeaderText);
                }
            }

            return pairs;
        }

    public static QandA QandAOfCellIndex(GudiDataGridview gudiDataGridview1, int rowIndex)
    {
        throw new NotImplementedException();
    }
}

>>>>>>> a1f384a (COMMIT 1)
