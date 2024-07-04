using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kundenuebersicht.Model
{
    public class CustomerList
    {
        private List<Customer> liste;
        public CustomerList()
        {
            liste = new List<Customer>();
        }

        public void Add(Customer kunden)
        {
            liste.Add(kunden);
        }

        public void Delete(Customer kunde)
        {
            foreach (var item in liste)
            {
                if (item.MemberID == kunde.MemberID)
                {
                    liste.Remove(item);
                }
            }
        }

        public void Change(Customer kunde)
        {
            foreach (var item in liste)
            {
                if (item.MemberID == kunde.MemberID)
                {
                    // Anpassungen
                }
            }
        }
    }
}
