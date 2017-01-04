using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSExcel = Microsoft.Office.Interop.Excel;
using Xiaowen.Office.Excel.Models;
using System.IO;

namespace Xiaowen.Office.Excel
{
    public class ExcelExport
    {
        public string Export(string path)
        {
            return DisplayInExcel(AddAccount());
        }

        private string DisplayInExcel(IEnumerable<Account> accounts)
        {
            string err = string.Empty;
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                path += "templates\\account";
                
                var excelApp = new MSExcel.Application();
                //excelApp.Visible = true;

                //Environment 程序运行环境 \bin\Debug\
                //string path = Environment.CurrentDirectory;

                //excelApp.Workbooks.CheckOut(path);

                excelApp.Workbooks.Open(path);
                MSExcel._Worksheet workSheet = (MSExcel.Worksheet)excelApp.ActiveSheet;

                workSheet.Cells[1, "A"] = "ID Number";
                workSheet.Cells[1, "B"] = "Current Balance";

                int row = 1;
                foreach (var acct in accounts)
                {
                    row++;
                    workSheet.Cells[row, "A"] = acct.ID;
                    workSheet.Cells[row, "B"] = acct.Balance;
                }

                workSheet.Columns[1].AutoFit();
                workSheet.Columns[2].AutoFit();
                //((excel.Range)workSheet.Columns[1]).AutoFit(); 显示强制转换
                
            }
            catch (Exception ex)
            {
               return err = ex.Message;
            }
            return err;
        }

        private IEnumerable<Account> AddAccount()
        {
            var bankAccount = new List<Account>
            {
                new Account {
                    ID = 1000,
                    Balance = 526.99
                },
                new Account {
                    ID = 2000,
                    Balance = 876.99
                }
            };
            return bankAccount;
        }

    }
}
