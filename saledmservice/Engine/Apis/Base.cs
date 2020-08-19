using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Model.Response;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using core.Util;
using Model.Enum;
using saledmservice.Constant;


namespace saledmservice.Engine.Apis
{
    public abstract class Base<TRequest>
    {
        protected string AccessToken { get; set; }
        protected string IPAddress { get; set; }
        protected string UserAgent { get; set; }

        //protected string HostBase { get; set; }

        protected string HostReq { get; set; }

        protected string Token { get; set; }

        protected string RecaptchaResponse { get; set; }

        protected string PermissionKey = "PUBLIC";
        protected bool AllowAnonymous = false;
        protected bool RecaptchaRequire = false;
        protected bool CheckVerify = false;

        //protected Model.Table.Mssql.sxsUser User { get; set; }

        protected int UserID { get; set; }

        protected abstract void ExecuteChild(TRequest dataReq, ResponseAPI dataRes);

        public dynamic ExecuteResponse(TRequest dataReq, int userID)
        {
            this.UserID = userID;
            ResponseAPI res = new ResponseAPI();
            this.ExecuteChild(dataReq, res);
            return res.data;
        }

        public ResponseAPI Execute(HttpContext context, dynamic dataReq = null)
        {
            ResponseAPI res = new ResponseAPI();

            StringValues HToken;
            context.Request.Headers.TryGetValue("Token", out HToken);
            Token = HToken.ToString();

            DateTime StartTime = DateTime.Now;
            string StackTraceMsg = string.Empty;
            try
            {
                StringValues HAccessToken;
                context.Request.Headers.TryGetValue("AccessToken", out HAccessToken);
                AccessToken = HAccessToken.ToString();

                StringValues HHostReq;
                context.Request.Headers.TryGetValue("Origin", out HHostReq);
                HostReq = HHostReq.ToString();

                //IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress = /*string.Join(',', heserver.AddressList.Select(x => x.ToString()).ToList());*/ context.Connection.RemoteIpAddress.ToString();

                //HostBase = context.Request.Headers.hos
                //HostBase = string.Concat(context.Request.Scheme, "://",  context.Request.Host.Value);

                StringValues HUserAgent;
                context.Request.Headers.TryGetValue("User-Agent", out HUserAgent);
                UserAgent = HUserAgent.ToString();

                StringValues HRecaptchaResponse;
                context.Request.Headers.TryGetValue("RecaptchaResponse", out HRecaptchaResponse);
                RecaptchaResponse = HRecaptchaResponse.ToString();

                if (!this.GetType().Name.Equals("OauthAccessTokenGet")) this.ValidatePermission();

                if (dataReq != null)
                {
                    try
                    {
                        dataReq = this.MappingRequest(dataReq);
                    }
                    catch (Exception)
                    {
                        dataReq = this.MappingRequestArr(dataReq);
                    }

                }

                this.ExecuteChild(dataReq, res);

                res.code = "S0001";
                res.message = "SUCCESS";
                res.status = "S";

            }
            catch (Exception ex)
            {
                StackTraceMsg = ex.StackTrace;
                //map error code, message
                ErrorCode error = EnumUtil.GetEnum<ErrorCode>(ex.Message);
                res.code = error.ToString();
                if (res.code == ErrorCode.U000.ToString())
                {
                    res.message = ex.Message;
                }
                else
                {
                    res.message = error.GetDescription();
                }

                res.status = "F";
            }
            finally
            {
              /*  Ado.Mssql.Table.APILog.GetInstant().Insert(new Model.Table.Mssql.sxlAPILog()
                {
                    Token = Token,
                    APIName = this.GetType().Name,
                    //RefID = this.Logger.RefID,
                    ServerName = Environment.MachineName,
                    StartDate = StartTime,
                    EndDate = DateTime.Now,
                    Status = res.status,
                    StatusMessage = res.message,
                    Input = this.GetType().Name.Equals("OauthLogin") ? "" : JsonConvert.SerializeObject(dataReq),
                    Output = JsonConvert.SerializeObject(res),
                    Remark = StackTraceMsg
                });
                */
            }
            return res;
        }

        private TRequest MappingRequest(dynamic dataReq)
        {
            string json = dataReq is string ? (string)dataReq : JsonConvert.SerializeObject(dataReq);
            return JsonConvert.DeserializeObject<TRequest>(json);
        }

        private List<TRequest> MappingRequestArr(dynamic dataReq)
        {
            string json = dataReq is string ? (string)dataReq : JsonConvert.SerializeObject(dataReq);
            return JsonConvert.DeserializeObject<List<TRequest>>(json);
        }

        private void ValidatePermission()
        {

            if (RecaptchaRequire)
            {
                /*if (!Recaptha.ReCaptchaPassed(RecaptchaResponse))
                {
                    throw new Exception(ErrorCode.V000.ToString());
                }
                */
            }

            // check access token
            //var accesskey = StaticValue.GetInstant().mdtAccessToken.Where(x => x.Code.Equals(AccessToken)).FirstOrDefault();
            //if (accesskey == null) { throw new Exception(ErrorCode.O000.ToString()); }

            // check token
            if (!AllowAnonymous)
            {
                /*var token =  StaticValue.GetInstant().sxtToken?.Where(x => x.Code.Equals(Token) && x.AccessToken_Code.Equals(AccessToken) && x.Type == Model.Enum.TokenType.LOGIN.GetValueString()).FirstOrDefault();

                if (token == null) { throw new Exception(ErrorCode.O000.ToString()); }
                if (token.Status != "A") { throw new Exception(ErrorCode.O001.ToString()); }
                if (token.ExpiryTime.ToLocalTime().Ticks < DateTime.Now.Ticks) { throw new Exception(ErrorCode.O002.ToString()); }

                // set user id
                UserID = token.User_ID;

                if (!PermissionKey.Equals("PUBLIC"))
                {
                    //if (!PermissionADO.GetInstant().CheckPermission(this.token, "C", this.PermissionKey).Any(x => x.Code == this.PermissionKey)) { throw new Exception(ErrorCode.P000.ToString()); }
                }
                */

            }

        }

    }

    
}
