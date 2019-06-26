using Newtonsoft.Json;
using Submail.AppConfig;
using Submail.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Submail.Lib
{
    public class Mail : ISender
    {
        private const string API_SEND = "http://api.submail.cn/mail/send.json";
        private const string API_XSEND = "http://api.submail.cn/mail/xsend.json";
        private const string API_SUBSCRIBE = "http://api.submail.cn/addressbook/mail/subscribe.json";
        private const string API_UNSUBSCRIBE = "http://api.submail.cn/addressbook/mail/unsubscribe.json";

        private IAppConfig _appConfig;
        private HttpWebHelper _httpWebHelper;

        public Mail(IAppConfig appConfig)
        {
            this._appConfig = appConfig;
            this._httpWebHelper = new HttpWebHelper(_appConfig);
        }
          
        public bool Send(Dictionary<string, object> data, out string returnMessage)
        {
            string retrunJsonResult = _httpWebHelper.HttpPost(API_SEND, data);
            returnMessage = retrunJsonResult;
            return HttpWebHelper.CheckReturnJsonStatus(retrunJsonResult);
        }

        public bool XSend(Dictionary<string, object> data, out string returnMessage)
        {
            string retrunJsonResult = _httpWebHelper.HttpPost(API_XSEND, data);
            returnMessage = retrunJsonResult;
            return HttpWebHelper.CheckReturnJsonStatus(retrunJsonResult);
        }

        public bool Subscribe(Dictionary<string, object> data, out string returnMessage)
        {
            string retrunJsonResult = _httpWebHelper.HttpPost(API_SUBSCRIBE, data);
            returnMessage = retrunJsonResult;
            return HttpWebHelper.CheckReturnJsonStatus(retrunJsonResult);
        }

        public bool UnSubscribe(Dictionary<string, object> data, out string returnMessage)
        {
            string retrunJsonResult = _httpWebHelper.HttpPost(API_UNSUBSCRIBE, data);
            returnMessage = retrunJsonResult;
            return HttpWebHelper.CheckReturnJsonStatus(retrunJsonResult);
        }

        public bool MultiXSend(Dictionary<string, object> data, out string returnMessage)
        {
            throw new NotImplementedException();
        }

        public bool VoiceVerify(Dictionary<string, object> data, out string returnMessage)
        {
            throw new NotImplementedException();
        }
    }
}
