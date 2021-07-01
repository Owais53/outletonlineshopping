using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ecommerceOutletShop
{
    public class Ecomm : Connect
   {
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public bool isAdmin { get; set; }
        public string Code { get; set; }
        public string OldPass { get; set; }

        public void CreateSignUp(Ecomm obj)
        {
            OpenConection();
            InsertSignUP("Insert into tblecommLogin(UserName,Password,Email,FullName,isAdmin) values(@Name,@pass,@email,@fullname,@isAdmin)", obj.Username, obj.Password, obj.Email,obj.FullName,obj.isAdmin);
            CloseConnection();
        }
        public DataTable SignIn(Ecomm obj)
        {
            OpenConection();
            DataTable dt =SelectSignin("Select * from tblecommLogin where UserName=@Name and Password=@pass and isAdmin='False'", obj.Username, obj.Password);
            CloseConnection();
            return dt;
           
        }
        public void ChangePassword(Ecomm obj)
        {
            OpenConection();
            UpdatePassword("Update tblecommLogin set Password=@Pass where LoginId=@Id and isAdmin='False'", obj.Password, obj.LoginId);
            CloseConnection();
        }
        public DataTable CheckOldPass(Ecomm obj)
        {
            OpenConection();
            DataTable dt = CheckOldPass("Select * from tblecommLogin where UserName=@Username and Password=@pass and isAdmin='False'", obj.Username, obj.OldPass);
            CloseConnection();
            return dt;

        }
        public DataTable CheckUser(Ecomm obj)
        {
            OpenConection();
            DataTable dt = SelectUser("Select * from tblecommLogin where UserName=@Name", obj.Username);
            CloseConnection();
            return dt;

        }
        public DataTable GetAllProd()
        {
            OpenConection();
            DataTable dt = GetallProducts("procBindAllProducts");
            CloseConnection();
            return dt;

        }
        public DataTable GetProductViewImages(int Id)
        {
            OpenConection();
            DataTable dt = GetProductImages("select * from tblProductImages where PID=@PID",Id);
            CloseConnection();
            return dt;

        }
        public DataTable CheckCode(Ecomm obj)
        {
            OpenConection();
            DataTable dt = CheckCode("Select * from tblCode where Code=@Code", obj.Code);
            CloseConnection();
            return dt;

        }
        public DataTable GetloginId(Ecomm obj)
        {
            OpenConection();
            DataTable dt = GetLoginId("Select LoginId from tblecommLogin where Email=@email and isAdmin='False'", obj.Email);
            CloseConnection();
            return dt;

        }
        public DataTable ForgotPass(Ecomm obj)
        {
            OpenConection();
            DataTable dt = ResetPassbymail("Select * from tblecommLogin where Email=@email and isAdmin='False'", obj.Email);
            CloseConnection();
            return dt;

        }
    }
}