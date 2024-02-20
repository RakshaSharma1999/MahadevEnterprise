using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;

namespace MahadevEnterprise.Method
{
    public class OrderClass
    {
        public int AddCustomerOrdor( string FirstName, string LastName, string Email ,string Mobile , string Address,int  ProductId , int Quantity, decimal TotalPrice)
        {

            General_New objg = new General_New();
            int Result = 0;

            NameValueCollection nv = new NameValueCollection();
            nv.Add("@FirstName",FirstName);
            nv.Add("@LastName",LastName);
            nv.Add("@Email", Email);
            nv.Add("@Mobile", Mobile);
            nv.Add("@Address",Address);
            nv.Add("@ProductId",ProductId.ToString());
            nv.Add("@Quantity",Quantity.ToString());
            nv.Add("@TotalPrice",TotalPrice.ToString());

            Result = objg.GetDataInsertORUpdate("SP_SETOrdorCustomer", nv);
            return Result;

        }

        public DataTable GetOrdor()
        {
            DataTable dt = new DataTable();
            string str = string.Empty;
            General_New objg= new General_New();
            NameValueCollection nv = new NameValueCollection();
            dt = objg.GetDataTable("SP_GETOrdorCustomer", nv);

            return dt;

        }

        public DataTable BindTax(int ProductId)
        {

            DataTable dt = new DataTable();
            string str = string.Empty;
            General objg=new General();

            str = "select Product.Price*OrderMaster.Quantity[tPrice],Product.ProductId from OrderMaster inner join Product on OrderMaster.ProductId=Product.ProductId where Product.ProductId='"+ProductId+"'";

            dt = objg.GetDatasetByCommand(str);
            return dt;
        }
    }
}