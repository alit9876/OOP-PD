﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMS_22final.BL
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
        public void  setinsurances(int insurance)
        {
            this.insurances = insurance;
        }
        public int getterinsurances()
        {
            return insurances;
        }
        public void setdurationins(int durations)
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
    }
}
