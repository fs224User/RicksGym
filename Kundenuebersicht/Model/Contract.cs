using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kundenuebersicht.Model
{
    public class Contract
    {
        private Guid contractNumber;
        private string contracttyp;
        private double amount;
        private DateTime startDate;

        public Contract(string contract, double amount, DateTime startDate)
        {
            this.contractNumber = Guid.NewGuid();
            this.contracttyp = contracttyp;
            this.amount = amount;
            this.startDate = startDate;
        }

        public Guid ContractNumber { get => contractNumber; set => contractNumber = value; }
        public string Contracttyp { get => contracttyp; set => contracttyp = value; }
        public double Amount { get => amount; set => amount = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }

        public override string ToString()
        {
            string[] date = this.startDate.ToString().Split(' ');
            return $"{this.contracttyp} \n{this.amount}€ \n{date[0]} ";
        }
    }
}
