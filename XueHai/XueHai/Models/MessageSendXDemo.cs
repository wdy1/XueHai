using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Submail.Lib;
using Submail.AppConfig;

namespace XueHai.Models
{
    public class MessageSendXDemo
    {
        public void SendMessage(string phone, string YZM)
        {
            IAppConfig appConfig = new MessageConfig("14197", "dfba0d6c87ccebc7eb8bcf446f559627");
            MessageXSend messageXSend = new MessageXSend(appConfig);
            messageXSend.AddTo(phone);
            messageXSend.SetProject("4yL5b2");
            messageXSend.AddVar("code", YZM);
            string returnMessage = string.Empty;
            if (messageXSend.XSend(out returnMessage) == false)
            {
                Console.WriteLine(returnMessage);
            }
        }

        public void SendMessageVoucher(string phone, string ShopPhone, string ShopName, string OrderNumber, string OrderCode, int? OrderNum = 0)
        {
            IAppConfig appConfig = new MessageConfig("14197", "dfba0d6c87ccebc7eb8bcf446f559627");
            MessageXSend messageXSend = new MessageXSend(appConfig);
            messageXSend.AddTo(phone);
            messageXSend.SetProject("rrWyz3");
            messageXSend.AddVar("shopname", ShopName);
            messageXSend.AddVar("num", OrderNum.ToString());
            messageXSend.AddVar("shopphone", ShopPhone);
            messageXSend.AddVar("ordernumber", OrderNumber);
            messageXSend.AddVar("ordercode", OrderCode);
            string returnMessage = string.Empty;
            if (messageXSend.XSend(out returnMessage) == false)
            {
                Console.WriteLine(returnMessage);
            }
        }

        //随机生成订单凭证码
        public string Voucher()
        {
            Random rm = new Random();
            string Voucher = "XueHai";
            for (int i = 0; i < 10; i++)
            {
                int k = rm.Next(0, 10);
                Voucher += k.ToString();
            }
            return Voucher;
        }


        //随机生成6位验证码
        public string random_6()
        {
            Random rm = new Random();
            string Yzm = "";
            for (int i = 0; i < 6; i++)
            {
                int k = rm.Next(0, 10);
                Yzm += k.ToString();
            }
            return Yzm;
        }
    }
}