using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace outletonlineshopping
{
    public class User : Connection
   {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public string Code { get; set; }
        public string OldPass { get; set; }
        public string Email { get; set; }

        public DataTable SignIn(User obj)
        {
            OpenConection();
            DataTable dt = SelectSignin("Select * from tblecommLogin where Email=@Email and Password=@pass and isAdmin='True'", obj.Username, obj.Pass);
            CloseConnection();
            return dt;

        }
        public void UpdateSecurityCode(User obj)
        {
            OpenConection();
            UpdateSecurityCode("Update tblCode set Code=@Code where Id=1", obj.Code);
            CloseConnection();
        }
        public void ChangePassword(User obj)
        {
            OpenConection();
            UpdatePassword("Update tblecommLogin set Password=@Pass where LoginId=@Id and isAdmin='True'", obj.Pass,obj.Id);
            CloseConnection();
        }
        public DataTable CheckOldPass(User obj)
        {
            OpenConection();
            DataTable dt = CheckOldPass("Select * from tblecommLogin where UserName=@Username and Password=@pass and isAdmin='True'", obj.Username, obj.OldPass);
            CloseConnection();
            return dt;

        }
        public DataTable GetloginId(User obj)
        {
            OpenConection();
            DataTable dt = GetLoginId("Select LoginId from tblecommLogin where Email=@email and isAdmin='True'", obj.Email);
            CloseConnection();
            return dt;

        }
        public DataTable ForgotPass(User obj)
        {
            OpenConection();
            DataTable dt = ResetPass("Select * from tblecommLogin where Email=@email and isAdmin='True'", obj.Email);
            CloseConnection();
            return dt;

        }
    }
}