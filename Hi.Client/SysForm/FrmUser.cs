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
            [Administrator][V1.0][51编程-代码器自动生成][2011-5-5 12:35:28]
 修改信息 ：(1)[开发员][V1.1][备注][日期]
            (2)[开发员][V1.2][备注][日期]
--------------------------------------------------------------------------------------------------

*/

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Hi.Common;

namespace Hi.Client
{
    public partial class FrmUser : Hi.Client.BaseForm.BaseFormList
    {
        
        public FrmUser()
        {
           
            this.pageDataGridViewEx1.ClearDataGridView();
            //DataGridViw标题
            this.pageDataGridViewEx1.IsShowCheckBox = -1;
            this.pageDataGridViewEx1.MyColumnName = "UserID,UserCode,Realname,orgname,sex_title,userTelephone,Email,Qq,Address,LoginTimes,LastLoginTime,remark";
            this.pageDataGridViewEx1.MyColumnTitle = "主键,用户名,真实姓名,所属部门,性别,联系电话,Email,Qq,地址,登录次数,最后登录时间,备注";
            this.pageDataGridViewEx1.SetDgvHeader();
            
            this.KeyName = "userid";
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
          
            this.pageDataGridViewEx1.SetNavButtonVisible(true, true, true, false, false);
            SetModulePurview(this.Name);
        }
       
       
        //绑定数据源
        protected override void  ListData()
        {
            try
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                //Hashtable dict = new Hashtable();
                int totalcount = Hi.IBLL.HiInstanceBLL.UserBLL().TotalCount(dict);
                this.pageDataGridViewEx1.TotalCount = totalcount;
                if (totalcount > 0)
                {
                    this.pageDataGridViewEx1.SetPageButton(true);

                    DataSet ds = Hi.IBLL.HiInstanceBLL.UserBLL().List(dict, this.pageDataGridViewEx1.CurrentPage, this.pageDataGridViewEx1.PageSize, "");

                    if (ds != null)
                    {
                        this.pageDataGridViewEx1.MyDataTable = ds.Tables[0];
                        this.pageDataGridViewEx1.BindingData(true);  
                    }
                    //主键，设不可见
                    this.pageDataGridViewEx1.ucdgv.Columns[this.KeyName].Visible = false;
                }
                else
                {
                    this.pageDataGridViewEx1.SetPageButton(false);
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex.Message);
                
                Error.ErrorMsg(ex);
            }
            
        }
       
        //双击行头打开编辑窗口
        protected override void DoDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DoEdit(null, null);
        }
        protected override void DoEdit(object sender, EventArgs e)
        {
            int rowIndex= this.pageDataGridViewEx1.ucdgv.CurrentRow.Index;
            string id = this.pageDataGridViewEx1.ucdgv.Rows[rowIndex].Cells[this.KeyName].EditedFormattedValue.ToString();//主键在第一列
            if (string.IsNullOrEmpty(id))
                return;
            ShowEditForm(id, "编辑");
            
        }
        protected override void DoAdd(object sender, EventArgs e)
        {
            ShowEditForm("", "新增");
        }
        private void ShowEditForm(string id,string action)
        {
            FrmUserEdit f = new FrmUserEdit(new DoRefreshHandler(this.DoQuery));
            f.IdValue = id;
	        f.ShowDialog();
	       
        }
       
        #region 所选删除
        protected override void DoDelete(object sender, EventArgs e)
        {
            
            string id=string.Empty;
            int selectCount = 0;
            DataGridView dgv = this.pageDataGridViewEx1.ucdgv;

            if (this.SelectCount() == 0)
                return;

            if (this.pageDataGridViewEx1.IsShowCheckBox > -1)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    //字段不为空且被选中
                    if (row.Cells["chkSelect"].EditedFormattedValue.ToString().Equals("True"))
                    {
                        selectCount++;
                        id += Convert.ToString(row.Cells[this.KeyName].Value) + ",";

                    }
                }
                id = id.Remove(id.Length - 1, 1);
            }
            else
            {
                int rowIndex = this.pageDataGridViewEx1.ucdgv.CurrentRow.Index;
                id = this.pageDataGridViewEx1.ucdgv.Rows[rowIndex].Cells[this.KeyName].EditedFormattedValue.ToString();//主键在第一列
                string usercode=this.pageDataGridViewEx1.ucdgv.Rows[rowIndex].Cells["UserCode"].EditedFormattedValue.ToString();//主键在第一列
                if (usercode.ToLower() == "admin")
                {
                    MsgBox.ShowInformation("系统用户不能删除!");
                    return;
                }
            }

            bool blFlag = Hi.IBLL.HiInstanceBLL.UserBLL().Delete(id);
            
            if (blFlag)
            {
                this.DoQuery();
            }
        }
        #endregion

        private void FrmUser_Load(object sender, EventArgs e)
        {

        }
    }
}




