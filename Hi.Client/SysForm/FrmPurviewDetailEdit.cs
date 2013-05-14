/*
------------------------------------------------------------------------------------------
 代码提供 ： 51编程-代码器
 作    者 ： 梁孙祥
       QQ ： 88130278
   EMail  ： LiangSunXiang@139.com
 官 方 网 ： www.51program.net
 个人博客 ： blog.csdn.net/liangsx
 温馨提示 ： 试用版本，附加版权内容。但不影响正常使用,请通过购买注册屏蔽此信息，谢谢！
 注册方法 ： 详情请访问官方网或来信咨询
-------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------------
 项目名称 ： Vs2008+Winfrom+工厂模式架构
 功能描述 ：
 创建信息 ：[开发员][版本][备注][日期]
            [Administrator][V1.0][51编程-代码器自动生成][2011-5-3 9:16:45]
 修改信息 ：(1)[开发员][V1.1][备注][日期]
            (2)[开发员][V1.2][备注][日期]
--------------------------------------------------------------------------------------------------

*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using Hi.Common;

namespace Hi.Client
{
    public partial class FrmPurviewDetailEdit : Hi.Client.BaseForm.BaseFormEdit
    {
        private Hi.BLL.User userBll = new Hi.BLL.User();//HiBLL.HiInstanceBLL().UserBLL();
        private Hi.Model.BasUser _UserModel=null;
        private string _ModuleCode;
        private string _UserId;
        private string _ParentCode;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="doRefresh"></param>
        public FrmPurviewDetailEdit(string user_id,string module_code,string module_name)
        {
            InitializeComponent();
            this.listView1.Dock = DockStyle.Fill;
            this.pnlWorkSpace.Controls.Add(this.listView1);
            this._ModuleCode = module_code;
            this._UserId = user_id;
            this.Text = "设置“"+module_name+"”操作权限";
        }
        private void FrmPurviewDetailEdit_Load(object sender, EventArgs e)
        {
            GetUserInfo();
            SetModulePurview(this.Name);

            DetailInfo();
            this.btnAddAndSave.Enabled = true;
        }

        private void GetUserInfo()
        {
           _UserModel  = new Model.BasUser();
           int tmpId = 0;
           int.TryParse(this._UserId, out tmpId);
           _UserModel = userBll.Detail(tmpId.ToString());
           if (_ModuleCode != null)
               this.lblUserInfo.Text = "设置“" + _UserModel.RealName + "”权限";
        }
       
        /// <summary>
        /// 重写获取详细事件
        /// </summary>
        private  void DetailInfo()
        {
            if (this._ModuleCode.ToLower() == "hiorderprophase")
            {
                _ParentCode = ModuleData.ParamParentCode.P06.ToString(); 
            }else
                _ParentCode = ModuleData.ParamParentCode.P07.ToString();
            if (_UserModel == null)
            {
                this.btnAddAndSave.Enabled = false;
                return ;
            }
           
             ListViewData();

        }
        private void ListViewData( )
        {
            if (ModuleData.ParamDataSet == null || ModuleData.ParamDataSet.Tables.Count == 0)
                return;
            this.listView1.BeginUpdate();

            this.listView1.Items.Clear();

            ListViewItem item = null;
            string child_code;
            foreach (DataRow dr in ModuleData.ParamDataSet.Tables[0].Select(" pcode='" + _ParentCode + "'", "sort"))
            {
                item = new ListViewItem();
                child_code = dr["code"].ToString().Trim();
                item.SubItems.Add(child_code);
                item.SubItems.Add(dr["title"].ToString().Trim());
                //if (ModuleData.IsExstsPurview(_UserModel.PurviewDetail,_ParentCode, child_code))
                //    item.Checked = true;
                
                listView1.Items.Add(item);
            }

            listView1.EndUpdate();

        }
        /// <summary>
        /// 重写保存事件
        /// </summary>
        /// <returns></returns>
        protected override bool Save()
        {
           
            return this.SavePurview(_UserId,"purview_detail");
           
        }
        private  bool SavePurview(string user_id, string module_code)
        {
            bool blFlag = false;
            try
            {
                ListViewItem item = null;
                string strPurview = "";
                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    item = this.listView1.Items[i];
                    if (item.Checked)
                        strPurview += item.SubItems[1].Text + "$";
                }
                if (string.IsNullOrEmpty(strPurview))
                    return false;
                strPurview = strPurview.Remove(strPurview.Length - 1);
                strPurview =_ParentCode+"|"+strPurview;

                string tmpPurview = IsExitsParentCode();
                if (!string.IsNullOrEmpty(tmpPurview))
                    strPurview = strPurview + "," + tmpPurview;

                blFlag = userBll.UpdatePurview(user_id, module_code, strPurview);
                if (blFlag)
                {
                    if (AppSetting.SysOption.UserId == user_id)
                        AppSetting.SysOption.PurviewDetail = strPurview;
                    MsgBox.ShowInformation("保存成功！");
                }
                else
                    MsgBox.ShowInformation("保存失败!");
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex.Message);
                Error.ErrorMsg(ex);

            }
            return blFlag;
        }
        private string IsExitsParentCode()
        {
            if (this._UserModel == null)
                return "";
            if (string.IsNullOrEmpty(this._UserModel.PurviewDetail))
                return "";
            string tmpPurviewDetail="" ;
            if (_UserModel.PurviewDetail.IndexOf(this._ParentCode) > -1)
            {
                string[] myarry = _UserModel.PurviewDetail.Split(',');
                for (int i = 0; i < myarry.Length; i++)
                {
                    if (myarry[i].IndexOf(this._ParentCode) == -1)
                    {
                        tmpPurviewDetail += myarry[i] + ",";
                    }
                }
                if (string.IsNullOrEmpty(tmpPurviewDetail))
                    return "";
                tmpPurviewDetail = tmpPurviewDetail.Remove(tmpPurviewDetail.Length - 1);

            }
            else
                tmpPurviewDetail = this._UserModel.PurviewDetail;
            return tmpPurviewDetail;
        }
       
    }
}