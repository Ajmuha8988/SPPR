using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubKha.Models
{
    public class Boss
    {
        public int ID { get; set; }
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
        public Boss() { }
        public Boss(string Login, string Password, string Lastname, string Firstname, string Patronymic)
        {
            this.Login = Login;
            this.Password = Password;
            this.Lastname = Lastname;
            this.Firstname = Firstname;
            this.Patronymic = Patronymic;
        }
        public override string ToString()
        {
            return Login;
        }
    }
}
