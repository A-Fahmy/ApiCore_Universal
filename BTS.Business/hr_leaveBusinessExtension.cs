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
    public partial class hr_leaveBusiness
    {
        public static List<hr_leave> GetAll_leaveByEmpId(int EmpID)
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
                requestSearch.AddParams(db, responseLogin.GetInt(), pass, "hr.leave", "search_read",
                    XmlRpcParameter.AsArray(
                        XmlRpcParameter.AsArray(
                            // XmlRpcParameter.AsArray("is_company", "=", true), XmlRpcRequest.AsArray("customer", "=", true)
                            XmlRpcParameter.AsArray("employee_id", "=", EmpID)
                        )
                    ),
                    XmlRpcParameter.AsStruct(
                        XmlRpcParameter.AsMember("fields", XmlRpcParameter.AsArray("holiday_status_id", "name", "state", "employee_id", "date_from", "date_to"))
                    // ,XmlRpcParameter.AsMember("limit", 2)
                    )
                );
                XmlRpcResponse responseSearch = client.Execute(requestSearch);
                object _obj = responseSearch.GetObject();
                string output = JsonConvert.SerializeObject(_obj);
                List<hr_leave_Odoo> Obj = JsonConvert.DeserializeObject<List<hr_leave_Odoo>>(output).Where(x => x.state == "confirm").ToList();
                List<hr_leave> Ltsleave = new List<hr_leave>();
                hr_leave _Add;
                foreach (var item in Obj)
                {
                    _Add = new hr_leave();

                    string[] arr = ((IEnumerable)item.employee_id).Cast<object>()
                           .Select(x => x.ToString())
                           .ToArray();
                    _Add.EmployeeID = int.Parse(arr[0]);
                    _Add.EmployeeName = arr[1];


                    arr = ((IEnumerable)item.holiday_status_id).Cast<object>()
                            .Select(x => x.ToString())
                            .ToArray();
                    _Add.TypeVactionID = int.Parse(arr[0]);
                    _Add.TypeVactionName = arr[1];

                    _Add.name = item.name;
                    _Add.state = item.state;
                    _Add.date_from = item.date_from;
                    _Add.date_to = item.date_to;
                    _Add.Description = item.name;
                    Ltsleave.Add(_Add);
                }

                return Ltsleave;
            }
            catch (Exception e)
            {
                return null;
            }
        }
      

        public static string check_holidays_date(int employee_id,string date_from,string date_to,int leave_type_id)
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
                XmlRpcRequest request_check_holidays_date = new XmlRpcRequest("execute_kw");
                request_check_holidays_date.AddParams(db, responseLogin.GetInt(), pass, "hr.leave", "check_holidays_date",
                    XmlRpcParameter.AsArray(
                    ),
                   XmlRpcParameter.AsStruct(
                       XmlRpcParameter.AsMember("employee_id", employee_id)
                      ,XmlRpcParameter.AsMember("date_from", date_from)
                     , XmlRpcParameter.AsMember("date_to", date_to)
                     , XmlRpcParameter.AsMember("leave_type_id", leave_type_id)
                ));
                XmlRpcResponse responseCheck_holidays_date = client.Execute(request_check_holidays_date);
                return responseCheck_holidays_date.GetString();

                    #region Old
                    //XmlRpcRequest requestLoginTest = new XmlRpcRequest("execute_kw");
                    //requestLogin.AddParams(db, user, pass,
                    //     XmlRpcParameter.AsStruct(
                    //       XmlRpcParameter.AsMember("employee_id", 5804)
                    //      , XmlRpcParameter.AsMember("date_from", "2020-09-05")
                    //     , XmlRpcParameter.AsMember("date_to", "2020-09-05")
                    //     , XmlRpcParameter.AsMember("leave_type_id", 1)
                    //    ));
                    //XmlRpcResponse responseLogintest = client.Execute(requestLoginTest);

                    ////-----------------------------------------------------------------------
                    //client.Path = "object";
                    //XmlRpcRequest requestCreate = new XmlRpcRequest("execute_kw");
                    //requestCreate.AddParams(db, responseLogin.GetInt(), pass, "hr.leave", "check_holidays_date",

                    //      XmlRpcParameter.AsArray(
                    //      XmlRpcParameter.AsStruct(
                    //      XmlRpcParameter.AsMember("employee_id", 5804)
                    //      , XmlRpcParameter.AsMember("date_from", "2020-09-05")
                    //     , XmlRpcParameter.AsMember("date_to", "2020-09-05")
                    //     , XmlRpcParameter.AsMember("leave_type_id", 1)

                    //    ))
                    //);
                    //XmlRpcResponse responseCreate = client.Execute(requestCreate);
                    ////------------------------------------------------------------------------
                    //client.Path = "object";
                    //XmlRpcRequest requestcheck_holidays = new XmlRpcRequest("execute_kw");
                    //requestcheck_holidays.AddParams(db, user, pass, "hr.leave", "check_holidays_date",
                    //     XmlRpcParameter.AsStruct(
                    //       XmlRpcParameter.AsMember("employee_id", 5804)
                    //      , XmlRpcParameter.AsMember("date_from", "2020-09-05")
                    //     , XmlRpcParameter.AsMember("date_to", "2020-09-05")
                    //     , XmlRpcParameter.AsMember("leave_type_id", 1)

                    //    ));
                    //XmlRpcResponse response_check_holidays = client.Execute(requestcheck_holidays);
                    #endregion
            }
            catch (Exception e)
            {
                return "";
            }
        }
        public static string Create_Leave(int employee_id, int number_of_days, string date_from, string date_to, string request_date_from,
            string request_date_to, int holiday_status_id)
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
                XmlRpcRequest requestCreate = new XmlRpcRequest("execute_kw");
                requestCreate.AddParams(db, responseLogin.GetInt(), pass, "hr.leave", "create",
                      XmlRpcParameter.AsArray(
                    
                   XmlRpcParameter.AsStruct(
                     XmlRpcParameter.AsMember("employee_id", employee_id)
                     ,XmlRpcParameter.AsMember("number_of_days", number_of_days)
                     , XmlRpcParameter.AsMember("date_from", date_from)
                     , XmlRpcParameter.AsMember("date_to", date_to)
                     , XmlRpcParameter.AsMember("request_date_from", date_from)
                     , XmlRpcParameter.AsMember("request_date_to", date_to)
                     , XmlRpcParameter.AsMember("holiday_status_id", holiday_status_id)
                     )
                ));
                XmlRpcResponse responseCreate = client.Execute(requestCreate);
                return responseCreate.GetString();

                
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
