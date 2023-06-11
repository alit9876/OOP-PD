using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS_22_with_oop_.UI;
using BMS_22_with_oop_.DL;

namespace BMS_22_with_oop_.BL
{
    class loan
    {
        private int loans;
        private string issueloans;
        private string limitloans;
        public loan(int loan, string issue, string limit)
        {
            this.loans = loan;
            this.issueloans = issue;
            this.limitloans = limit;
        }
        public loan()
        {

        }
        public void setloans(int loans)
        {
            this.loans = loans;
        }
        public int getterloans()
        {
            return loans;
        }
        public void setissueloans(string issueloans)
        {
            this.issueloans = issueloans;
        }
        public string getterissueloans()
        {
            return issueloans;
        }
        public void setlimitloans(string limitloans)
        {
            this.limitloans = limitloans;
        }
        public string getterlimitloans()
        {
            return limitloans;
        }
        public  void providingloan(loan obj, ref int bankbalance)
        {
            loans = obj.loans;
            bankbalance = bankbalance - obj.loans;
            issueloans = (obj.issueloans);
            limitloans = (obj.limitloans);
        }
        
    }
}
