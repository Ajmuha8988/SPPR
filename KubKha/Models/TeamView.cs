using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KubKha.Models
{
    public class TeamView
    {
        public int ID { get; set; }
        private string Login, Password;
        private int IDteam, Score;
        private string Name, Money, Description;
        public string login
        {
            get { return Login; }
            set { Login = value; }
        }
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
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
        public string description
        {
            get { return Description; }
            set { Description = value; }
        }
        public int score
        {
            get { return Score; }
            set { Score = value; }
        }
        public TeamView() { }
        public TeamView(string Name, int IDteam, string Description, string Money, string Login, int Score)
        {
            this.Name = Name;
            this.IDteam = IDteam;
            this.Description = Description;
            this.Money = Money;
            this.Login = Login;
            this.Score = Score;
        }
        public override string ToString()
        {
            return Login + Score + Name + IDteam + Description + Money;
        }
    }
}
