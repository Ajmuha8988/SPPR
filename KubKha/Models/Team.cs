using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubKha.Models
{
    public class Team
    {
        public int ID { get; set; }
        private int IDteam;
        private string Name, Money, Description;
        public int idteam
        {
            get { return IDteam; }
            set { IDteam = value; }
        }
        public string money
        {
            get { return Money; }
            set { Money = value; }
        }
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public string description
        {
            get { return Description; }
            set { Description = value; }
        }
        public Team() { }
        public Team(string Name, int IDteam, string Money, string Description)
        {
            this.Name = Name;
            this.IDteam = IDteam;
            this.Money = Money;
            this.Description = Description;
        }
        public override string ToString()
        {
            return Name + IDteam + Money + Description;
        }
    }
}
