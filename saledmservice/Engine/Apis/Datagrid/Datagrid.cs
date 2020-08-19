using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Request;
using Ado;
using Model;
using Core.Util;
using Model.Request.Datagrid;
using Model.Response;

namespace saledmservice.Engine.Apis.Datagrid
{
    public class Datagrid : Base<DatagridReq>
    {
        protected override void ExecuteChild(DatagridReq dataReq, ResponseAPI dataRes)
        {


            var res = new List<Model.Response.Datagrid.DatagridRes>();

            var roles = Ado.Mssql.View.Datagrid.GetInstant().Search(dataReq);







            foreach (var x in roles)
            {
                var tmp = new Model.Response.Datagrid.DatagridRes();

                tmp.code = x.code;

                tmp.col1string = x.col1string;
                tmp.col1int = x.col1int;
                tmp.col1float = x.col1float;
                tmp.col1datetime = x.col1datetime;

                tmp.col2string = x.col2string;
                tmp.col2int = x.col2int;
                tmp.col2float = x.col2float;
                tmp.col2datetime = x.col2datetime;

                tmp.col3string = x.col3string;
                tmp.col3int = x.col3int;
                tmp.col3float = x.col3float;
                tmp.col3datetime = x.col3datetime;


                tmp.col4string = x.col4string;
                tmp.col4int = x.col4int;
                tmp.col4float = x.col4float;
                tmp.col4datetime = x.col4datetime;


                tmp.col5string = x.col5string;
                tmp.col5int = x.col5int;
                tmp.col5float = x.col5float;
                tmp.col5datetime = x.col5datetime;


                tmp.col6string = x.col6string;
                tmp.col6int = x.col6int;
                tmp.col6float = x.col6float;
                tmp.col6datetime = x.col6datetime;

                tmp.col7string = x.col7string;
                tmp.col7int = x.col7int;
                tmp.col7float = x.col7float;
                tmp.col7datetime = x.col7datetime;

                tmp.col8string = x.col8string;
                tmp.col8int = x.col8int;
                tmp.col8float = x.col8float;
                tmp.col8datetime = x.col8datetime;


                tmp.col9string = x.col9string;
                tmp.col9int = x.col9int;
                tmp.col9float = x.col9float;
                tmp.col9datetime = x.col9datetime;

                tmp.col10string = x.col10string;
                tmp.col10int = x.col10int;
                tmp.col10float = x.col10float;
                tmp.col10datetime = x.col10datetime;


                tmp.col11string = x.col11string;
                tmp.col11int = x.col11int;
                tmp.col11float = x.col11float;
                tmp.col11datetime = x.col11datetime;

                tmp.col12string = x.col12string;
                tmp.col12int = x.col12int;
                tmp.col12float = x.col12float;
                tmp.col12datetime = x.col12datetime;

                tmp.col13string = x.col13string;
                tmp.col13int = x.col13int;
                tmp.col13float = x.col13float;
                tmp.col13datetime = x.col13datetime;

                tmp.col14string = x.col14string;
                tmp.col14int = x.col14int;
                tmp.col14float = x.col14float;
                tmp.col14datetime = x.col14datetime;


                tmp.col15string = x.col15string;
                tmp.col15int = x.col15int;
                tmp.col15float = x.col15float;
                tmp.col15datetime = x.col15datetime;


                tmp.coldescstring = x.coldescstring;

                res.Add(tmp);

            }


            dataRes.data = res;


        }
    }
}
