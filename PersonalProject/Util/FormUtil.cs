using PersonalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


    public class FormUtil
    {
        /// <summary>
        /// MdiChild 폼 생성하는 내부 함수
        /// </summary>
        /// <param name="prgName">생성할 폼 클래스명</param>
        /// <param name="main">MdiParent로 줄 부모 폼(frmMain)</param>
        public static void OpenCreateForm(string prgName, frmMain main) //frmMain main
        {
            // 열려있는 폼들중에서 없으면 새로 만들어서 폼을 보여주고,
            // 이미 열려있는 폼이라면, 활성폼으로 만들어서 제일 앞으로 위치

            string appName = Assembly.GetEntryAssembly().GetName().Name;

            Type frmType = Type.GetType($"{appName}.{prgName}");
            //어셈블리명.클래스명

            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == frmType)
                {
                    form.Activate(); //Activate 이벤트
                    form.BringToFront();
                    form.WindowState = FormWindowState.Maximized;
                    return;
                }
            }

            Form frm = (Form)Activator.CreateInstance(frmType);
            frm.MdiParent = main;
            frm.WindowState = FormWindowState.Maximized;
            frm.MaximizeBox = false;
            frm.MinimizeBox = false;
            frm.ControlBox = false;
            frm.Show(); //Load->Activate 이벤트
        }
        
        /// <summary>
        /// 서브 폼 열기
        /// </summary>
        /// <param name="dest">Form이 표시될 Panel Control</param>
        /// <param name="childForm">출력될 Child Form</param>
        /// <param name="curForm">현재 출력되는 중인 Child Form</param>
        public static Form OpenForm(Panel dest, Form childForm, Form curForm, DockStyle dock = DockStyle.Fill)
        {
            if (curForm != null)
            {
                curForm.Close();
            }

            curForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = dock;

            dest.Controls.Add(childForm);
            dest.Tag = childForm;
            childForm.Show();

            return curForm;

        }
        //SubMenu 버튼 클릭 이벤트에서 인스턴스로 FormUtil 생성 후 해당 메서드 호출시 MdiChild 폼 생성
        public void SubMenu_Click(object sender, EventArgs e, frmMain main)
        {
            Button menu = (Button)sender;
            //frmMain main = new frmMain();
            //CommonUtil commonUtil = new CommonUtil();
            OpenCreateForm(menu.Tag.ToString(), main); 
        }

        public static void CloseForm(Form frm)
        {
            frm.Close();
            Form currentForm = Form.ActiveForm.ActiveMdiChild;
            if(currentForm != null)
                currentForm.WindowState = FormWindowState.Maximized;
        }
    }

