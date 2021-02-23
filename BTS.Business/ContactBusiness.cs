using System.Collections.Generic;
using System.Linq;
using BTS.Data.Repositories;
using BTS.Entities;

namespace BTS.Business
{
    public partial class ContactBusiness
    {
        public static List<Contact> GetAll()
        {
            ContactRepository Obj = new ContactRepository();
            List<Contact> lstResult = Obj.GetAll().ToList();
            return lstResult;
        }
        public static List<Contact> GetActiveList()
        {
            ContactRepository Obj = new ContactRepository();
            List<Contact> lstResult = Obj.GetActiveList().ToList();
            return lstResult;
        }
        public static Contact GetByCode(int Code)
        {
            ContactRepository Obj = new ContactRepository();
            Contact Result = Obj.GetByCode(Code);
            return Result;
        }
        public static int Insert(Contact _Obj)
        {
            ContactRepository Obj = new ContactRepository();
            return Obj.Insert(_Obj);
        }
        public static void Update(Contact _Obj)
        {
            ContactRepository Obj = new ContactRepository();
            Obj.Update(_Obj);
        }
        public static bool Delete(int Code)
        {
            ContactRepository Obj = new ContactRepository();
            Obj.Delete(Code);
            return true;
        }
    }
}
