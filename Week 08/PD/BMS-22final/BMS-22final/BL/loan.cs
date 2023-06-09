using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_22final.BL
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
    }
}
