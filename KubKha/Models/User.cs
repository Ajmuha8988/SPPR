using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubKha.Models
{
    public class User
    {
        public int ID { get; set; }
        private int IDt, Score;
        private string Login, Password, Lastname, Firstname, Patronymic;
        public string login
        {
            get { return Login; }
            set { Login = value; }
        }
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }
        public string lastname
        {
            get { return Lastname; }
            set { Lastname = value; }
        }
        public string firstname
        {
            get { return Firstname; }
            set { Firstname = value; }
        }
        public string patronymic
        {
            get { return Patronymic; }
            set { Patronymic = value; }
        }
        public int idt
        {
            get { return IDt; }
            set { IDt = value; }
        }
        public int score
        {
            get { return Score; }
            set { Score = value; }
        }
        public User() { }
        public User(string Login, string Password, string Lastname, string Firstname, string Patronymic, int IDt, int Score)
        {
            this.Login = Login;
            this.Password = Password;
            this.Lastname = Lastname;
            this.Firstname = Firstname;
            this.Patronymic = Patronymic;
            this.IDt = IDt;
            this.Score = Score;
        }
        public override string ToString()
        {
            return Login;
        }
    }
}
