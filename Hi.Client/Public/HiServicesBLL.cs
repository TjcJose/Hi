using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.IO;
using System.Collections;
using System.Web.Services.Protocols;

using Hi.Common;
namespace Hi.Pure
{
    public class HiServicesBLL
    {
       
        #region 连接Services方法
        private static HostServices.HiServicesSoapClient bll = new HostServices.HiServicesSoapClient();
        
        /// <summary>
        ///测试服务器 
        /// </summary>
        /// <returns></returns>
        public static string Test()
        {
            return bll.TextServices();
        }
        /// <summary>
        /// 用户有效验证
        /// </summary>
        /// <returns></returns>
        public static bool CheckInvalidUser()
        {
            HostServices.AuthHeader auth = new HostServices.AuthHeader();
            auth.UserCode = SysConfig.GetUser.UserCode;
            auth.Password = Hi.Common.MD5.MD5Encrypt(SysConfig.GetUser.Password);
            
            return bll.IsInvalidUser(auth);
          
        }
        #region 列表、总数、新增、修改、删除等方法
        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strXml"></param>
        /// <returns></returns>
        public static int TotalCount(string strXml)
        {
            Error.ErrorMsg("TotalCount:\r\n"+strXml);//测试字符串
            string strResult = bll.DataAccess2String(strXml);
            XmlDocument doc = XmlDoc.StringToXml(XmlDoc.NodeNameString("xml",strResult));
            int totalCount = Utils.StrToInt(XmlDoc.SelectNodeValue(doc, "xml/count"));
            return totalCount;
        }
        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <param name="strXml"></param>
        /// <returns></returns>
        public static DataSet List(string strXml)
        {
            //先验证
            if (!CheckInvalidUser())
            {
                return null;
            }
            Error.ErrorMsg("List:\r\n" + strXml);//测试字符串
            DataSet ds = bll.DataAccess2DataSet(strXml);
            return ds;
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="index"></param>
        /// <param name="strXml"></param>
        /// <param name="strResult"></param>
        /// <returns></returns>
        public static bool Add(string strXml,string codeName, out string strResult)
        {
            return DoAction(strXml, codeName, "Add", out strResult);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="index"></param>
        /// <param name="strXml"></param>
        /// <param name="strResult"></param>
        /// <returns></returns>
        public static bool Update(string strXml,string codeName, out string strResult)
        {
            return DoAction(strXml,codeName, "Update", out strResult);
        }
        /// <summary>
        /// 验证唯一性
        /// </summary>
        /// <param name="index"></param>
        /// <param name="strXml"></param>
        /// <param name="strResult"></param>
        /// <returns></returns>
        public static bool Exists(string strXml, string codeName, out string strResult)
        {
            return DoAction(strXml, codeName, "Exists", out strResult);
        }
        /// <summary>
        /// 删除所选记录数
        /// </summary>
        /// <param name="index"></param>
        /// <param name="strXml"></param>
        /// <param name="strResult"></param>
        /// <returns></returns>
        public static bool Delete( string strXml,string codeName, out string strResult)
        {
            return DoAction(strXml, codeName, "Delete", out strResult);
        }
        private static bool DoAction(string strXml,string codeName, string actionName, out string strResult)
        {
            //先验证
            if (!CheckInvalidUser())
            {
                strResult = "无效用户";
                return false;
            }
            string strXmlTemp = string.Empty;
            strXmlTemp += XmlDoc.NodeNameString("action", actionName);
            strXmlTemp += XmlDoc.NodeNameString("code", codeName);
            strXmlTemp += strXml;

            string xmlResult = bll.DataAccess2String(strXmlTemp);
            XmlDocument doc = XmlDoc.StringToXml("<xml>"+xmlResult+"</xml>");
            string actionResult = XmlDoc.GetNodeAttributesValue(doc, "xml/result");
            strResult = XmlDoc.SelectNodeValue(doc, "xml/result");

            if (((int)ActionResult.Success).ToString() == actionResult)
            {
                return true;
            }
            else if (((int)ActionResult.Exists).ToString() == actionResult)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        /// <summary>
        /// 获取一行数据中一个字段值--此方法仅字段映射模块中使用
        /// </summary>
        /// <param name="strXml"></param>
        /// <returns></returns>
        public static string GetDataScalarToStr(string strXml)
        {
            string strResult = bll.DataAccess2String(strXml);
            XmlDocument doc = XmlDoc.StringToXml(strResult);
            string str = XmlDoc.SelectNodeValue(doc, "result");
            return str;
        }
        #endregion 


        public static bool DoLogin(string usercode,string password,out string strResult)
        {
           
            StringBuilder strb = new StringBuilder();
            strb.Append(XmlDoc.NodeNameString("code", "Check"));
            strb.Append(XmlDoc.NodeNameString("action", "Logion"));
            strb.Append(XmlDoc.NodeNameString("usercode", usercode));
            strb.Append(XmlDoc.NodeNameString("password", password));

            string xmlResult = bll.DataAccess2String(strb.ToString());
            XmlDocument doc = XmlDoc.StringToXml(XmlDoc.NodeNameString("xml",xmlResult));
            //分析结果
            string tempResult = string.Empty;
            tempResult =   XmlDoc.GetNodeAttributesValue(doc, "/xml/result");
            strResult = XmlDoc.SelectNodeValue(doc, "xml/result");
            strResult = (string.IsNullOrEmpty(strResult) == true ? xmlResult : strResult);
            //登陆成功
            if (ActionResult.Success.ToString() == tempResult)
            {
                //SysConfig.GetUser.LoginTime = XmlDoc.SelectNodeValue(doc, "xml/logintime");
                //SysConfig.GetUser.UserId= XmlDoc.SelectNodeValue(doc, "xml/userid");
                AppSetting.SysOption.UserCode = XmlDoc.SelectNodeValue(doc, "xml/usercode");
                AppSetting.SysOption.UserName = XmlDoc.SelectNodeValue(doc, "xml/username");
                //SysConfig.GetUser.Password = password;// XmlDoc.SelectNodeValue(doc, "xml/pwd");
                //SysConfig.GetUser.UserType = XmlDoc.SelectNodeValue(doc, "xml/usertype");

                //SysConfig.GetUser.RoleName = XmlDoc.SelectNodeValue(doc, "xml/rolename");
                //SysConfig.GetUser.UserRoleType = XmlDoc.SelectNodeValue(doc, "xml/roletype");
                
                AppSetting.SysOption.OrgId = XmlDoc.SelectNodeValue(doc, "xml/orgid");
                AppSetting.SysOption.OrgName = XmlDoc.SelectNodeValue(doc, "xml/orgname");

               
                Hi.Common.AppSetting.Save();
                
                return true;
            }
            else
            {
                return false;
            }
           
        }
        //获取服务器上的二进制数据，如照片
        public static byte[] GetBytes(string strxml,string person_id,string planperson_id)
        {
           return bll.DataAccessBytes(strxml, person_id,planperson_id);
        }

        //批量上传
        public static string DoUpload(DataSet ds, string strXml)
        {
            return bll.DataAccess(ds, strXml);
        }
        //上传文件
        public static string DoUploadFile(string srcFile, string source_file)
        {
            try
            {
                string strXml = XmlDoc.NodeNameString("source_file", source_file);
                FileStream srcStream = new FileStream(srcFile, FileMode.Open, FileAccess.Read);
                int length = (int)srcStream.Length;
                //产生字节数组对象

                byte[] bytes = new byte[length];
                //读取文件，将数据放入字节数组中

                srcStream.Read(bytes, 0, length);
                return bll.UploadFile(bytes, strXml);
            }
            catch (Exception ex)
            {
                Error.ErrorMsg("上传源文件异常：" + ex.Message);
                return "";
            }
        }

        public enum ActionResult
        {
            Success,//0
            Error,//1
            Exists //2
        }
        #endregion
    }
}
