using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace outletonlineshopping
{
    public class Purchase:Connection
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }

        public DataTable CheckDuplicateVendor(string Vendor)
        {
            OpenConection();
            DataTable dt = CheckDuplicatVendor("Select * from tblVendor where VendorName=@VName", Vendor);
            CloseConnection();
            return dt;

        }
        public void CreateVendor(Purchase obj)
        {
            OpenConection();
            InsertVendors("Insert into tblVendor(VendorName,Email,ContactNo,Address) values(@VName,@Email,@Contact,@Address)", obj.VendorName,obj.Contact,obj.Address,obj.Email);
            CloseConnection();
        }
        public void UpdateVendor(Purchase obj)
        {
            OpenConection();
            UpdateVendors("Update tblVendor set VendorName=@VName,Email=@Email,ContactNo=@Contact,Address=@Address where VendorID=@VId",obj.VendorID,obj.VendorName, obj.Contact, obj.Address, obj.Email);
            CloseConnection();
        }

    }
}