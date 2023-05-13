using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_22_bl_dl_ul_.BL
{
    class other
    {
    }
    class insurance
    {
        public int insurances;
        public int durations;
        public string installments;
        public insurance(int insurance, int dur, string installment)
        {
            this.installments = installment;
            this.insurances = insurance;
            this.durations = dur;
        }
        public insurance()
        {

        }
        public static void applyforinsurance(insurance obj, data s)
        {
            s.Idata.insurances = obj.insurances;
            s.Idata.durations = obj.durations;
            s.Idata.installments = obj.installments;
        }
    }
    class loan
    {
        public int loans;
        public string issueloans;
        public string limitloans;
        public loan(int loan, string issue, string limit)
        {
            this.loans = loan;
            this.issueloans = issue;
            this.limitloans = limit;
        }
        public loan()
        {

        }
        public static string applyforloan(data linput, data s)
        {
            string valid = "false";
            if (linput.names == s.names && linput.passwords == s.passwords && linput.accountnumbers == s.accountnumbers)
            {
                valid = "true";
            }
            return valid;
        }
        public static void saveloandetails(loan obj, data s, ref int bankbalance)
        {
            s.ldata.loans = obj.loans;
            s.ldata.issueloans = obj.issueloans;
            s.ldata.limitloans = obj.limitloans;
            bankbalance = bankbalance - obj.loans;
        }
        public static void returnloan(int returnloan,data s)
        {
            s.balances = s.balances - returnloan;
            s.ldata.loans = s.ldata.loans - returnloan;
        }
    }
    class freeze
    {
        public string status;
        public int fdurations;
        public freeze(string status, int dur)
        {
            this.status = status;
            this.fdurations = dur;
        }
        public freeze()
        {

        }
        public string freezestatus()
        {
            string sat;
            sat = status;
            return sat;
        }
        public static bool unfreezeaccount(data obj, List<data> s)
        {
            bool ischeck = false;
            for (int index = 1; index < s.Count; index++)
            {
                if (s[index].names == obj.names && s[index].accountnumbers == obj.accountnumbers)
                {
                    s[index].fdata.status = "UnFreeze";
                    ischeck = true;
                    break;
                }
            }
            return ischeck;
        }
    }
}
