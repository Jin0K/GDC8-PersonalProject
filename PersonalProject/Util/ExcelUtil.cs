using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using Excel = Microsoft.Office.Interop.Excel;

    //class ExcelUtil
    //{
    //    public static void ReleaseObject(object obj)
    //    {
    //        try
    //        {
    //            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
    //            obj = null;
    //        }
    //        catch (Exception ex)
    //        {
    //            obj = null;
    //            MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
    //        }
    //        finally
    //        {
    //            GC.Collect();
    //        }
    //    }

    //    public static dynamic GetCellValue(Excel.Range cell)
    //    {
    //        return cell.Value2;
    //    }

    //    public static bool ExportExcelToList<T>(List<T> dataList, string saveFileName, string exceptColumns)
    //    {
    //        try
    //        {
    //            Excel.Application xlApp = new Excel.Application();
    //            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
    //            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    //            //xlWorkSheet.Name = dt.TableName;

    //            //List VO의 속성명 엑셀의 첫번째 행에 추가(1번행)
    //            int columnIndex = 0;
    //            foreach (PropertyInfo prop in typeof(T).GetProperties())
    //            {
    //                if (!exceptColumns.Contains(prop.Name))
    //                {
    //                    columnIndex++;
    //                    xlWorkSheet.Cells[1, columnIndex] = prop.Name;
    //                }
    //            }

    //            //List VO의 건수만큼 컬럼별로 셀에 추가(2번행)
    //            for (int r = 0; r < dataList.Count; r++)
    //            {
    //                columnIndex = 0;
    //                foreach (PropertyInfo prop in typeof(T).GetProperties())
    //                {
    //                    if (!exceptColumns.Contains(prop.Name))
    //                    {
    //                        columnIndex++;
    //                        if (prop.GetValue(dataList[r], null) != null)
    //                        {
    //                            xlWorkSheet.Cells[r + 2, columnIndex] = prop.GetValue(dataList[r], null).ToString();
    //                        }
    //                    }
    //                }
    //            }

    //            xlWorkSheet.Columns.AutoFit();
    //            //엑셀컬럼의 너비가 데이터길이에 따라서 자동조정

    //            xlWorkBook.SaveAs(saveFileName, Excel.XlFileFormat.xlWorkbookNormal);
    //            xlWorkBook.Close(true);
    //            xlApp.Quit();

    //            ReleaseObject(xlWorkSheet);
    //            ReleaseObject(xlWorkBook);
    //            ReleaseObject(xlApp);

    //            return true;
    //        }
    //        catch (Exception err)
    //        {
    //            MessageBox.Show(err.Message);
    //            return false;
    //        }
    //    }

    //    /// <summary>
    //    /// 데이터 바인딩된 데이터 그리드 뷰 상태로 엑셀에 출력하기
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="dataList">데이터 그리드 뷰 데이터 소스 리스트타입으로 형변환</param>
    //    /// <param name="saveFileName">SaveFileDialog FileName속성, 경로+파일명+확장자</param>
    //    /// <param name="exceptColumns">제외할 프로퍼티명 리스트 타입으로 주기</param>
    //    /// <param name="pairs">DataGridViewUtil.GetDataGridViewPropName() 메서드에 출력할 dgv 매개변수로 주기</param>
    //    /// <returns></returns>
    //    public static bool ExportExcelToList<T>(List<T> dataList, string saveFileName, List<string> exceptColumns = default(List<string>), Dictionary<string, string> pairs = default(Dictionary<string, string>))
    //    {
    //        if(exceptColumns == null)
    //        {
    //            exceptColumns = new List<string>() { "" };
    //        }

    //        if (pairs == null)
    //        {
    //            pairs = new Dictionary<string, string>() { [""]="" };
    //        }

    //        try
    //        {
    //            Excel.Application xlApp = new Excel.Application();
    //            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
    //            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    //            //xlWorkSheet.Name = dt.TableName;

    //            //List VO의 속성명 엑셀의 첫번째 행에 추가(1번행)
    //            int columnIndex = 0;
    //            foreach (PropertyInfo prop in typeof(T).GetProperties())
    //            {
    //                if (!exceptColumns.Contains(prop.Name, StringComparer.OrdinalIgnoreCase) && pairs.ContainsKey(prop.Name))
    //                {
    //                    columnIndex++;

    //                    if(pairs.ContainsKey(prop.Name))
    //                        xlWorkSheet.Cells[1, columnIndex] = pairs[prop.Name];
    //                    //else
    //                    //    xlWorkSheet.Cells[1, columnIndex] = prop.Name;
    //                }
    //            }

    //            //List VO의 건수만큼 컬럼별로 셀에 추가(2번행)
    //            for (int r = 0; r < dataList.Count; r++)
    //            {
    //                columnIndex = 0;
    //                foreach (PropertyInfo prop in typeof(T).GetProperties())
    //                {
    //                    if (!exceptColumns.Contains(prop.Name, StringComparer.OrdinalIgnoreCase) && pairs.ContainsKey(prop.Name))
    //                    {
    //                        columnIndex++;
    //                        if (prop.GetValue(dataList[r], null) != null)
    //                        {
    //                            xlWorkSheet.Cells[r + 2, columnIndex] = prop.GetValue(dataList[r], null).ToString();
    //                        }
    //                    }
    //                }
    //            }

    //            xlWorkSheet.Columns.AutoFit();
    //            //엑셀컬럼의 너비가 데이터길이에 따라서 자동조정


    //            if (System.IO.Path.GetExtension(saveFileName) == ".xls")
    //            {
    //                xlWorkBook.SaveAs(saveFileName, Excel.XlFileFormat.xlWorkbookNormal);
    //            }
    //            else
    //            {
    //                xlWorkBook.SaveCopyAs(saveFileName);
    //                xlWorkBook.Saved = true;
    //            }
                
    //            xlWorkBook.Close(true);
    //            xlApp.Quit();

    //            ReleaseObject(xlWorkSheet);
    //            ReleaseObject(xlWorkBook);
    //            ReleaseObject(xlApp);

    //            return true;
    //        }
    //        catch (Exception err)
    //        {
    //            MessageBox.Show(err.Message);
    //            return false;
    //        }
    //    }


    //    /// <summary>
    //    /// 데이터 바인딩된 데이터 그리드 뷰 상태로 엑셀에 출력하기
    //    /// </summary>
    //    /// <typeparam name="T"></typeparam>
    //    /// <param name="dataList">데이터 그리드 뷰 데이터 소스 리스트타입으로 형변환</param>
    //    /// <param name="saveFileName">SaveFileDialog FileName속성, 경로+파일명+확장자</param>
    //    /// <param name="exceptColumns">제외할 프로퍼티명 리스트 타입으로 주기</param>
    //    /// <param name="pairs">DataGridViewUtil.GetDataGridViewPropName() 메서드에 출력할 dgv 매개변수로 주기</param>
    //    /// <returns></returns>
    //    public static bool ExportExcelToList<T>(List<T> dataList, string saveFileName, Dictionary<string, string> pairs = default(Dictionary<string, string>), params string[] exceptColumns)
    //    {
    //        if (pairs == null)
    //        {
    //            pairs = new Dictionary<string, string>() { [""] = "" };
    //        }

    //        try
    //        {
    //            Excel.Application xlApp = new Excel.Application();
    //            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
    //            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    //            //xlWorkSheet.Name = dt.TableName;

    //            //List VO의 속성명 엑셀의 첫번째 행에 추가(1번행)
    //            int columnIndex = 0;
    //            foreach (PropertyInfo prop in typeof(T).GetProperties())
    //            {
    //                if (!exceptColumns.Contains(prop.Name, StringComparer.OrdinalIgnoreCase) && pairs.ContainsKey(prop.Name))
    //                {
    //                    columnIndex++;

    //                    if (pairs.ContainsKey(prop.Name))
    //                        xlWorkSheet.Cells[1, columnIndex] = pairs[prop.Name];
    //                    //else
    //                    //    xlWorkSheet.Cells[1, columnIndex] = prop.Name;
    //                }
    //            }

    //            //List VO의 건수만큼 컬럼별로 셀에 추가(2번행)
    //            for (int r = 0; r < dataList.Count; r++)
    //            {
    //                columnIndex = 0;
    //                foreach (PropertyInfo prop in typeof(T).GetProperties())
    //                {
    //                    if (!exceptColumns.Contains(prop.Name, StringComparer.OrdinalIgnoreCase) && pairs.ContainsKey(prop.Name))
    //                    {
    //                        columnIndex++;
    //                        if (prop.GetValue(dataList[r], null) != null)
    //                        {
    //                            xlWorkSheet.Cells[r + 2, columnIndex] = prop.GetValue(dataList[r], null).ToString();
    //                        }
    //                    }
    //                }
    //            }

    //            xlWorkSheet.Columns.AutoFit();
    //            //엑셀컬럼의 너비가 데이터길이에 따라서 자동조정


    //            if (System.IO.Path.GetExtension(saveFileName) == ".xls")
    //            {
    //                xlWorkBook.SaveAs(saveFileName, Excel.XlFileFormat.xlWorkbookNormal);
    //            }
    //            else
    //            {
    //                xlWorkBook.SaveCopyAs(saveFileName);
    //                xlWorkBook.Saved = true;
    //            }

    //            xlWorkBook.Close(true);
    //            xlApp.Quit();

    //            ReleaseObject(xlWorkSheet);
    //            ReleaseObject(xlWorkBook);
    //            ReleaseObject(xlApp);

    //            return true;
    //        }
    //        catch (Exception err)
    //        {
    //            MessageBox.Show(err.Message);
    //            return false;
    //        }
    //    }




    //    /// <summary>
    //    /// 발주서 양식에 맞춰 입력하기
    //    /// </summary>
    //    /// <param name="xlWorkSheet"></param>
    //    /// <param name="orderToVendor"></param>
    //    /// <returns></returns>
    //    public static Excel.Worksheet PrintOrderFormTemplateOnWorksheet(Excel.Worksheet xlWorkSheet, OrderToVendorVO orderToVendor)
    //    {
    //        OrderVO order = orderToVendor.OrderM;
    //        List<OrderDetailVO> details = orderToVendor.OrderD;

    //        //OrderToVendorService otvServ = new OrderToVendorService();
    //        //Company company = otvServ.GetCompanyDetail(order.COM_No);

    //        //외주처(Company)
    //        xlWorkSheet.Cells[13, 5] = order.COM_Name; //상호
    //        xlWorkSheet.Cells[15, 5] = order.COM_Tel; //전화번호

    //        //발주처(Team1)
    //        xlWorkSheet.Cells[14, 14] = "02-1111-1111"; //전화번호
    //        xlWorkSheet.Cells[15, 14] = "02-1111-1111"; //팩스번호
    //        xlWorkSheet.Cells[16, 14] = "team1@gudi.com"; //이메일

    //        //Order
    //        xlWorkSheet.Cells[14, 5] = order.ORDER_No; //등록번호
    //        xlWorkSheet.Cells[16, 5] = order.Period_Date.ToShortDateString(); //납기요청
    //        xlWorkSheet.Cells[17, 8] = xlWorkSheet.Cells[17, 14] = order.ORDER_Price.ToString("#,##0"); //총액, 합계 금액

    //        //OrderDetail
    //        for (int i = 0; i < details.Count; i++)
    //        {
    //            xlWorkSheet.Cells[20 + i, 2] = details[i].ORDER_Detail; //주문상세번호
    //            xlWorkSheet.Cells[20 + i, 3] = details[i].MT_Name; //품명
    //            xlWorkSheet.Cells[20 + i, 6] = details[i].MT_Min_Order; //규격
    //            xlWorkSheet.Cells[20 + i, 8] = details[i].Unit_Name; //단위
    //            xlWorkSheet.Cells[20 + i, 10] = details[i].ORDER_Qty; //수량
    //            if (details[i].ORDER_Qty > 0)
    //                xlWorkSheet.Cells[20 + i, 12] = (details[i].ORDER_Price / details[i].ORDER_Qty); //단가
    //            xlWorkSheet.Cells[20 + i, 14] = details[i].ORDER_Price; //금액
    //        }

    //        return xlWorkSheet;
    //    }


    //    public static Excel.Worksheet PrintTradingStatementTemplateOnWorksheet(Excel.Worksheet xlWorkSheet, int storeNum)
    //    {
    //        //OrderVO order = orderToVendor.OrderM;
    //        //List<OrderDetailVO> details = orderToVendor.OrderD;

    //        StoreService Serv = new StoreService();
    //        StoreExcelExportVO info = Serv.GetStoreDetail(storeNum);
    //        Company company = info.Company;
    //        StoreInfoDetailVO storeInfo = info.Store;

    //        //공급받는자
    //        xlWorkSheet.Cells[4, 7] = "Team1"; //상호
    //        xlWorkSheet.Cells[6, 7] = "서울특별시 금천구 가산동 가산디지털2로 115 대륭테크노타운3차"; //사업장 주소
    //        xlWorkSheet.Cells[8, 7] = "02-2108-5900"; //전화번호
    //        //xlWorkSheet.Cells[10, 7] = order.COM_Tel; //합계 금액(자동계산)

    //        //공급자
    //        xlWorkSheet.Cells[4, 22] = company.Com_License; //등록번호 Com_License
    //        xlWorkSheet.Cells[6, 22] = storeInfo.COM_Name; //상호(법인명)
    //        //xlWorkSheet.Cells[6, 30] = ; //이름
    //        xlWorkSheet.Cells[8, 22] = $"({company.Com_Addr_Zip}){company.Com_Addr_Street1} {company.Com_Addr_Street2}"; //사업장주소
    //        xlWorkSheet.Cells[10, 22] = company.Com_Tel; //전화
    //        xlWorkSheet.Cells[10, 30] = company.Com_Email; //팩스

    //        //하단
    //        //xlWorkSheet.Cells[25, 8] = ; //인수자
    //        //xlWorkSheet.Cells[25, 17] = ; //납품자
    //        //xlWorkSheet.Cells[25, 28] = ; //미수금

    //        //Detail
    //        //for (int i = 0; i < storeInfo..Count; i++)
    //        //{
    //        xlWorkSheet.Cells[13, 2] = storeInfo.STORE_Date.ToString("yy"); //년
    //        xlWorkSheet.Cells[13, 3] = storeInfo.STORE_Date.ToString("MM"); //월
    //        xlWorkSheet.Cells[13, 4] = storeInfo.STORE_Date.ToString("dd"); //일
    //        xlWorkSheet.Cells[13, 5] = storeInfo.MT_Name; //품목
    //        xlWorkSheet.Cells[13, 13] = storeInfo.COM_MTR_Name.Substring(storeInfo.MT_Name.Length).Replace("(","").Replace(")",""); //규격
    //        xlWorkSheet.Cells[13, 18] = storeInfo.STORE_Qty; //수량
    //        xlWorkSheet.Cells[13, 22] = storeInfo.MT_Price; //단가
               
    //        //}

    //        return xlWorkSheet;
    //    }



    //}

