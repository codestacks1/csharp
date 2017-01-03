using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;
using Xiaowen.Office.Excel.Models;
using System.IO;

namespace Xiaowen.Office.Excel
{
    public class ExcelExport
    {
        public void Export(string path)
        {
            DisplayInExcel(AddAccount());
        }

        private void DisplayInExcel(IEnumerable<Account> accounts)
        {
            try
            {
                var excelApp = new excel.Application();
                //excelApp.Visible = true;

                string path = Environment.CurrentDirectory;
                
                excelApp.Workbooks.Open("");
                excel._Worksheet workSheet = (excel.Worksheet)excelApp.ActiveSheet;

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
                Console.WriteLine(ex.Message);
                Console.Read();
            }
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
