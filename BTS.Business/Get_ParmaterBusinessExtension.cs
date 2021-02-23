using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTS.Entities;
using BTS.Data.Repositories;

using System.Drawing;
using System.IO;
using System.Net;
using System.Web;
using System.ServiceModel;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Net.Security;
using XmlRpc;
using Newtonsoft.Json;
using System.Collections;
using System;


namespace BTS.Business
{
    public partial class Get_ParmaterBusiness
    {
        public static Get_Parmater_Odoo GetAll_Parmater()
        {
            try
            {
                // Fahmy upload git
                string Url = Confgration_Odoo._Domain_URL, db = Confgration_Odoo._DataBaseName, pass = Confgration_Odoo._Password, user = Confgration_Odoo._UserName;
                XmlRpcClient client = new XmlRpcClient();
                client.Url = Url;
                client.Path = "common";
                // LOGIN

                XmlRpcRequest requestLogin = new XmlRpcRequest("authenticate");
                requestLogin.AddParams(db, user, pass, XmlRpcParameter.EmptyStruct());
                XmlRpcResponse responseLogin = client.Execute(requestLogin);

                client.Path = "object";
                XmlRpcRequest requestSearch = new XmlRpcRequest("execute_kw");
                requestSearch.AddParams(db, responseLogin.GetInt(), pass, "account.voucher", "get_parmater",
                    XmlRpcParameter.AsArray(
                    ),
                    XmlRpcParameter.AsStruct(
                    )
                );
                XmlRpcResponse responseSearch = client.Execute(requestSearch);
                object _obj = responseSearch.GetObject();
                IEnumerable enumerable = _obj as IEnumerable;
                 Get_Parmater_Odoo _odoo = new Get_Parmater_Odoo();
                if (enumerable != null)
                {
                   
                    foreach (object element in enumerable)
                    {
                        string output = JsonConvert.SerializeObject(element);

                        if(output.Contains("partners"))
                        {
                            Partners objResponse = JsonConvert.DeserializeObject<Partners>(output);
                            _odoo.partners = new List<_Partners>(); 
                            _odoo.partners=objResponse.value;
                        }
                        if (output.Contains("route"))
                        {
                            Route objResponse = JsonConvert.DeserializeObject<Route>(output);
                            _odoo.route = new List<_Route>();
                            _odoo.route=objResponse.value;
                        }

                        if (output.Contains("state_collect"))
                        {
                            //object objResponse = JsonConvert.DeserializeObject<object>(output);
                            //string[] arr = ((IEnumerable)objResponse).Cast<object>()
                            //.Select(x => x.ToString())
                            //.ToArray();

                            _odoo.state_collect = new List<_State_collect>();
                            _State_collect _add = new _State_collect();
                            _add.id = "1";
                            _add.name = "Number/Filter";
                            _odoo.state_collect.Add(_add);
                            _add = new _State_collect();

                            _add.id = "2";
                            _add.name = "شحنه";
                            _odoo.state_collect.Add(_add);
                        }
                        if (output.Contains("currency"))
                        {
                            _odoo.currency = new List<_Currency>();
                            _Currency _add = new _Currency();
                            _add.name = "sr";
                            _odoo.currency.Add(_add);

                            //_add = new _Currency();
                            //_add.name = "SR";
                            //_odoo.currency.Add(_add);

                            _add = new _Currency();
                            _add.name = "egp";
                            _odoo.currency.Add(_add);

                            //_add = new _Currency();
                            //_add.name = "EGP";
                            //_odoo.currency.Add(_add);

                            _add = new _Currency();
                            _add.name = "usd";
                            _odoo.currency.Add(_add);

                            //_add = new _Currency();
                            //_add.name = "USD";
                            //_odoo.currency.Add(_add);

                            _add = new _Currency();
                            _add.name = "eur";
                            _odoo.currency.Add(_add);

                            //_add = new _Currency();
                            //_add.name = "EUR";
                            //_odoo.currency.Add(_add);
                        }
                        if (output.Contains("banks"))
                        {
                            Banks objResponse = JsonConvert.DeserializeObject<Banks>(output);
                            _odoo.banks= new List<_Banks>();
                            _odoo.banks=objResponse.value;
                        }
                        if (output.Contains("journals"))
                        {
                            Journals objResponse = JsonConvert.DeserializeObject<Journals>(output);
                            _odoo.journals = new List<_Journals>();
                            _odoo.journals=objResponse.value;
                        }
                    }
                }
                else
                {
                    return null;

                }
                return _odoo;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static List<Companies> GetAll_Companies(int main_customer_id)
        {
            try
            {
                string Url = Confgration_Odoo._Domain_URL, db = Confgration_Odoo._DataBaseName, pass = Confgration_Odoo._Password, user = Confgration_Odoo._UserName;
                XmlRpcClient client = new XmlRpcClient();
                client.Url = Url;
                client.Path = "common";
                // LOGIN

                XmlRpcRequest requestLogin = new XmlRpcRequest("authenticate");
                requestLogin.AddParams(db, user, pass, XmlRpcParameter.EmptyStruct());
                XmlRpcResponse responseLogin = client.Execute(requestLogin);

              
                client.Path = "object";
                XmlRpcRequest requestSearch = new XmlRpcRequest("execute_kw");
                requestSearch.AddParams(db, responseLogin.GetInt(), pass, "res.partner", "search_read",
                    XmlRpcParameter.AsArray(
                        XmlRpcParameter.AsArray(
                            XmlRpcParameter.AsArray("is_second_level", "=", true),
                            XmlRpcParameter.AsArray("parent_id", "=", main_customer_id)
                        )
                    ),
                    XmlRpcParameter.AsStruct(
                        XmlRpcParameter.AsMember("fields", XmlRpcParameter.AsArray("id", "name"))
                    // ,XmlRpcParameter.AsMember("limit", 2)
                    )
                );
                XmlRpcResponse responseSearch = client.Execute(requestSearch);
                object _obj = responseSearch.GetObject();
                string output = JsonConvert.SerializeObject(_obj);
                List<Companies> Obj = JsonConvert.DeserializeObject<List<Companies>>(output);

                return Obj;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static List<Companies> GetAll_Branches(int second_company_id)
        {
            try
            {
                string Url = Confgration_Odoo._Domain_URL, db = Confgration_Odoo._DataBaseName, pass = Confgration_Odoo._Password, user = Confgration_Odoo._UserName;
                XmlRpcClient client = new XmlRpcClient();
                client.Url = Url;
                client.Path = "common";
                // LOGIN

                XmlRpcRequest requestLogin = new XmlRpcRequest("authenticate");
                requestLogin.AddParams(db, user, pass, XmlRpcParameter.EmptyStruct());
                XmlRpcResponse responseLogin = client.Execute(requestLogin);


                client.Path = "object";
                XmlRpcRequest requestSearch = new XmlRpcRequest("execute_kw");
                requestSearch.AddParams(db, responseLogin.GetInt(), pass, "res.partner", "search_read",
                    XmlRpcParameter.AsArray(
                        XmlRpcParameter.AsArray(
                            XmlRpcParameter.AsArray("parent_id", "=", second_company_id)
                        )
                    ),
                    XmlRpcParameter.AsStruct(
                        XmlRpcParameter.AsMember("fields", XmlRpcParameter.AsArray("id", "name"))
                    // ,XmlRpcParameter.AsMember("limit", 2)
                    )
                );
                XmlRpcResponse responseSearch = client.Execute(requestSearch);
                object _obj = responseSearch.GetObject();
                string output = JsonConvert.SerializeObject(_obj);
                List<Companies> Obj = JsonConvert.DeserializeObject<List<Companies>>(output);

                return Obj;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public static List<ReadPayment> Read_Payment(int UserID)
        {
            try
            {
               // string today = "2021-01-03";

                string today = DateTime.Now.Date.ToString("yyyy-MM-dd");
                string Url = Confgration_Odoo._Domain_URL, db = Confgration_Odoo._DataBaseName, pass = Confgration_Odoo._Password, user = Confgration_Odoo._UserName;
                XmlRpcClient client = new XmlRpcClient();
                client.Url = Url;
                client.Path = "common";
                // LOGIN

                XmlRpcRequest requestLogin = new XmlRpcRequest("authenticate");
                requestLogin.AddParams(db, user, pass, XmlRpcParameter.EmptyStruct());
                XmlRpcResponse responseLogin = client.Execute(requestLogin);
                object obj = responseLogin.GetObject();

               


                client.Path = "object";
                XmlRpcRequest requestSearch = new XmlRpcRequest("execute_kw");
                requestSearch.AddParams(db, responseLogin.GetInt(), pass, "account.voucher", "search_read",
                    XmlRpcParameter.AsArray(
                        XmlRpcParameter.AsArray(
                            XmlRpcParameter.AsArray("date", "=", today)
                        , XmlRpcParameter.AsArray("create_uid", "=", UserID)
                        )
                    ),
                    XmlRpcParameter.AsStruct(
                          XmlRpcParameter.AsMember("fields", XmlRpcParameter.AsArray("state", "date", "partner_id", "second_company_id", "parent_id", "journal_id", "state_collect", "currency", "reference", "amount", "is_check", "route_id", "check_num", "check_date", "num_of_envelope", "check_id", "notes"))
                    // ,XmlRpcParameter.AsMember("limit", 2)
                    )
                );
                XmlRpcResponse responseSearch = client.Execute(requestSearch);
                object _obj = responseSearch.GetObject();
                string output = JsonConvert.SerializeObject(_obj);
                List<ReadPayment_Odoo> Obj = JsonConvert.DeserializeObject<List<ReadPayment_Odoo>>(output);
                List<ReadPayment> LtsPayment = new List<ReadPayment>();
                ReadPayment _Add;
                string[] arr;
                foreach (var item in Obj)
                {
                    _Add = new ReadPayment();
                    _Add.state = item.state;
                    _Add.date = item.date;
                    _Add.id = item.id;

                    if (item.partner_id!=null && item.partner_id.ToString()!= "False")
                    {
                        arr = ((IEnumerable)item.partner_id).Cast<object>()
                         .Select(x => x.ToString())
                         .ToArray();
                        _Add.partner_id = int.Parse(arr[0]);
                        _Add.partner_Name = arr[1];
                    }
                    else
                    {
                        _Add.partner_id = 0;
                        _Add.partner_Name ="";
                    }


                    if (item.second_company_id != null && item.second_company_id.ToString() != "False")
                    {
                        arr = ((IEnumerable)item.second_company_id).Cast<object>()
                        .Select(x => x.ToString())
                        .ToArray();

                        
                        _Add.second_company_id = int.Parse(arr[0]);
                        int index1 = arr[1].IndexOf(',', 1);
                        if(index1>0)
                        { 
                            string[] SplitName = arr[1].Split(',');
                           _Add.second_company_Name = SplitName[1];
                        }
                        else

                        _Add.second_company_Name = arr[1];
                    }
                    else
                    {
                        _Add.second_company_id = 0;
                        _Add.second_company_Name ="";
                    }

                    if (item.parent_id != null && item.parent_id.ToString() != "False")
                    {
                        arr = ((IEnumerable)item.parent_id).Cast<object>()
                       .Select(x => x.ToString())
                       .ToArray();
                        _Add.parent_id = int.Parse(arr[0]);
                        int index1 = arr[1].IndexOf(',', 1);
                        if (index1 > 0)
                        {
                            string[] SplitName = arr[1].Split(',');
                            _Add.parent_Name = SplitName[1];
                        }
                        else
                        {
                            _Add.parent_Name = arr[1];
                        }
                    }
                    else
                    {
                        _Add.parent_id =0;
                        _Add.parent_Name ="";
                    }

                    if (item.journal_id != null && item.journal_id.ToString() != "False")
                    {
                        arr = ((IEnumerable)item.journal_id).Cast<object>()
                    .Select(x => x.ToString())
                    .ToArray();
                        _Add.journal_id = int.Parse(arr[0]);
                        _Add.journal_Name = arr[1];
                    }
                    else
                    {
                        _Add.journal_id = 0;
                        _Add.journal_Name ="";
                    }
                    _Add.state_collect = item.state_collect;
                    _Add.currency = item.currency;
                    _Add.reference = item.reference;
                    _Add.amount = item.amount;
                    _Add.is_check = item.is_check;

                    if (item.route_id != null && item.route_id.ToString() != "False")
                    {
                        arr = ((IEnumerable)item.route_id).Cast<object>()
                  .Select(x => x.ToString())
                  .ToArray();
                        _Add.route_id = int.Parse(arr[0]);
                        _Add.route_Name = arr[1];
                    }
                    else
                    {
                        _Add.route_id = 0;
                        _Add.route_Name ="";
                    }
                    _Add.check_num = item.check_num;
                    _Add.check_date = item.check_date;

                    _Add.num_of_envelope = item.num_of_envelope;

                    if (item.check_id != null && item.check_id.ToString() != "False")
                    {
                        arr = ((IEnumerable)item.check_id).Cast<object>()
                  .Select(x => x.ToString())
                  .ToArray();
                        _Add.BankID = int.Parse(arr[0]);
                        _Add.BankName = arr[1];
                    }
                    else
                    {
                        _Add.BankID = 0;
                        _Add.BankName = "";
                    }
                    _Add.notes = item.notes;

                    LtsPayment.Add(_Add);
                }
                return LtsPayment;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static string Create_payment_api(string UserName, string PassWord, 
            int partner_id, int second_company_id, int parent_id, int journal_id,
            string state_collect, string currency, string reference,
          double amount, int is_check, int route_id, int two_hundred, int one_hundred, int fifty
            , int twenty, int ten, int five, int one, int half_one, int quarter_one,int num_of_envelope
            , int check_id, int check_num,string check_date)
        {
            try
            {

                string[] parameters = check_date.Split(new char[] { '&' });


                Confgration_Odoo._Password = PassWord;
                Confgration_Odoo._UserName = UserName;

                string Url = Confgration_Odoo._Domain_URL, db = Confgration_Odoo._DataBaseName, pass = Confgration_Odoo._Password, user = Confgration_Odoo._UserName;
                XmlRpcClient client = new XmlRpcClient();
                client.Url = Url;
                client.Path = "common";
                // LOGIN

                XmlRpcRequest requestLogin = new XmlRpcRequest("authenticate");
                requestLogin.AddParams(db, user, pass, XmlRpcParameter.EmptyStruct());
                XmlRpcResponse responseLogin = client.Execute(requestLogin);

                client.Path = "object";
                XmlRpcRequest requestCreate = new XmlRpcRequest("execute_kw");
                requestCreate.AddParams(db, responseLogin.GetInt(), pass, "account.voucher", "create_payment_api",
                       XmlRpcParameter.AsArray(
                    ),
                     XmlRpcParameter.AsStruct(
                         XmlRpcParameter.AsMember("partner_id", partner_id)
                     , XmlRpcParameter.AsMember("second_company_id", second_company_id)
                     , XmlRpcParameter.AsMember("parent_id", parent_id)
                     , XmlRpcParameter.AsMember("journal_id", journal_id)
                     , XmlRpcParameter.AsMember("state_collect", state_collect)
                     , XmlRpcParameter.AsMember("currency", currency)
                     , XmlRpcParameter.AsMember("reference", reference)
                     , XmlRpcParameter.AsMember("amount", amount)
                     , XmlRpcParameter.AsMember("is_check", is_check)
                     , XmlRpcParameter.AsMember("route_id", route_id)
                     , XmlRpcParameter.AsMember("two_hundred", two_hundred)
                     , XmlRpcParameter.AsMember("one_hundred", one_hundred)
                     , XmlRpcParameter.AsMember("fifty", fifty)
                     , XmlRpcParameter.AsMember("twenty", twenty)
                     , XmlRpcParameter.AsMember("ten", ten)
                     , XmlRpcParameter.AsMember("five", five)
                     , XmlRpcParameter.AsMember("one", one)
                     , XmlRpcParameter.AsMember("half_one", half_one)
                     , XmlRpcParameter.AsMember("quarter_one", quarter_one)
                     , XmlRpcParameter.AsMember("num_of_envelope", num_of_envelope)
                     , XmlRpcParameter.AsMember("check_id", check_id)
                     , XmlRpcParameter.AsMember("check_num", check_num)
                    , XmlRpcParameter.AsMember("check_date", parameters[0])
                    , XmlRpcParameter.AsMember("notes", parameters[1])
                //, XmlRpcParameter.AsMember("check_date", check_date)
                //, XmlRpcParameter.AsMember("notes", notes)
                ));
                XmlRpcResponse responseCreate = client.Execute(requestCreate);
                return responseCreate.GetString();


            }
            catch (Exception e)
            {
                return "";
            }
        }


        public static void UploadPicture(HttpPostedFile postedImage)
        {
            //List<Contact> contact = GetByUserName(contactCode.ToString());

            var filePath = HttpContext.Current.Server.MapPath("~/Print_Receipt/" + postedImage.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault());

            postedImage.SaveAs(filePath);

            //contact[0].PhotoURL = filePath;
            //Update(contact[0]);
        }
     

    }
}
