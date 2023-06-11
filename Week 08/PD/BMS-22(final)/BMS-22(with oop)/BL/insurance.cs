using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMS_22_with_oop_.UI;
using BMS_22_with_oop_.DL;

namespace BMS_22_with_oop_.BL
{
    class insurance
    {
        private int insurances;
        private int durations;
        private string installments;
        public insurance(int insurance, int dur, string installment)
        {
            this.installments = installment;
            this.insurances = insurance;
            this.durations = dur;
        }
        public insurance()
        {

        }
        public void setinsurances(int insurance)
        {
            this.insurances = insurance;
        }
        public int getterinsurances()
        {
            return insurances;
        }
        public void setdurations(int durations)
        {
            this.durations = durations;
        }
        public int getterdurations()
        {
            return durations;
        }
        public void setinstallments(string installment)
        {
            this.installments = installment;
        }
        public string getterinstallments()
        {
            return installments;
        }
        public void applyforinsurance(insurance obj)
        {
            insurances = (obj.insurances);
            durations = (obj.durations);
            installments = (obj.installments);
        }
    }
}
