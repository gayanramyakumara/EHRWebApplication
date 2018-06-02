using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace SAL
{
    public static class ServiceHelper
    {
        public static ServiceResponseBE GetPOSTResponse(Uri uri, string data)
        {
            ServiceResponseBE respMsg = new ServiceResponseBE();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

                request.Method = "POST";
                request.ContentType = "application/json;charset=utf-8";

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                byte[] bytes = encoding.GetBytes(data);

                request.ContentLength = bytes.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    // Send the data.
                    requestStream.Write(bytes, 0, bytes.Length);
                }

                request.BeginGetResponse((x) =>
                {
                    using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(x))
                    {
                        respMsg.HttpStatusCode = response.StatusCode;
                        Stream responseStream = response.GetResponseStream();
                        StreamReader sr = new StreamReader(responseStream);
                        respMsg.ResponseMessage = sr.ReadToEnd();
                    }
                }, null);
            }
            catch (Exception ex)
            {
                respMsg.Error = ex.Message;
            }
            return respMsg;
        }
    }
}
