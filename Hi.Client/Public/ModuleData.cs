using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Windows.Forms;

using Hi.Common;
namespace Hi.Client
{
    public class ModuleData
    {
        public enum ParamParentCode
        {
            /// <summary>
            /// //商品单位
            /// </summary>
            P01,
            /// <summary>
            /// //套系栏目
            /// </summary>
            P02,
            //套系分类
            P03,
            /// <summary>
            /// //顾客来源
            /// </summary>
            P04,
            //顾客状态
            P05,
            //拍前沟通
            P06,
            //后期进度明显
            P07,
            //取件内容
            P08,
            /// <summary>
            /// //付款类型
            /// </summary>
            P09,
            //订单状态
            P10
        }

        #region 系统参数
        public static DataSet ParamDataSet { get; set; }
        /// <summary>
        /// 系统参数
        /// </summary>
        public static void InitParamDataSet()
        {
            Hi.BLL.SysAdmin bll =new Hi.BLL.SysAdmin();// new Hi.BLL.SysAdmin();
            ParamDataSet = bll.ParamList(0);

        }
       
       
        /// <summary>
        /// 针对Ctrls.CbbItem获取comboBox选项值
        /// i=1 获取value
        /// i=2 获取name
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string GetSelectComboBoxValue(ComboBox cmb, int i)
        {
            string strValue = "";
            if (cmb.SelectedIndex > -1)
            {
                switch (i)
                {
                    case 1://value
                        strValue = ((Ctrls.CbbItem)cmb.SelectedItem).Value.Trim();
                        break;
                    case 2://value
                        strValue = ((Ctrls.CbbItem)cmb.SelectedItem).Name.Trim();
                        break;
                }
            }
            return strValue;
        }
        /// <summary>
        /// 针对Ctrls.CbbItem获取comboBox选项值
        /// i=1 根据value设置selectIndex
        /// i=2 获取name设置selectIndex
        /// </summary>
        /// <param name="cmb"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static void SetComboBoxSelectedIndex(ComboBox cmb, int i, string strValue)
        {

            if (cmb.Items.Count == 0)
                return;
            Ctrls.CbbItem item;
            for (int index = 0; index < cmb.Items.Count; index++)
            {
                item = (Ctrls.CbbItem)cmb.Items[index];
                if (i == 1)
                {
                    if (item.Value == strValue)
                    {
                        cmb.SelectedIndex = index;
                        break;
                    }
                }
                if (i == 2)
                {
                    if (item.Name.Trim().ToLower() == strValue.Trim().ToLower())
                    {
                        cmb.SelectedIndex = index;
                        break;
                    }
                }

            }

        }
        public static void BindComboBox(ComboBox cmb, ParamParentCode parentCode)
        {
            if (ParamDataSet == null || ParamDataSet.Tables[0].Rows.Count == 0)
            {
                InitParamDataSet();
            }
            cmb.Items.Clear();
            Ctrls.CbbItem item;
            DataRow[] rows = ParamDataSet.Tables[0].Select(" pcode='" + parentCode.ToString() + "'");
            foreach (DataRow dr in rows)
            {
                item = new Ctrls.CbbItem();
                item.Text = dr["title"].ToString().Trim();
                item.Value = dr["code"].ToString().Trim();
                item.Name = dr["code"].ToString().Trim();
                cmb.Items.Add(item);
            }

        }
        public static void BindComboBox(ComboBox cmb, DataRow[] rows)
        {
            if (ParamDataSet == null || ParamDataSet.Tables[0].Rows.Count == 0)
            {
                InitParamDataSet();
            }
            cmb.Items.Clear();
            Ctrls.CbbItem item;
            foreach (DataRow dr in rows)
            {
                item = new Ctrls.CbbItem();
                item.Text = dr["title"].ToString().Trim();
                item.Value = dr["id"].ToString().Trim();
                item.Name = dr["code"].ToString().Trim();
                cmb.Items.Add(item);
            }

        }
        #region 自动保存部分系统参数
        public static void ExistsParam(ComboBox cmb, ParamParentCode parent, string title)
        {
            bool tmpExists = false;
            try
            {
                Ctrls.CbbItem item;

                for (int index = 0; index < cmb.Items.Count; index++)
                {
                    item = (Ctrls.CbbItem)cmb.Items[index];

                    if (item.Text.Trim().ToLower() == title.ToLower().Trim())
                    {
                        tmpExists = true;
                        break;
                    }
                }//end for
                //不存在，新增
                if (!tmpExists)
                {
                    AddParam(cmb, parent, title);
                }
            }
            catch (Exception ex)
            {
                Error.ErrorMsg(ex);
            }

        }
        private static void AddParam(ComboBox cmb, ParamParentCode parent, string title)
        {
            try
            {
                Hi.BLL.SysAdmin bll =new Hi.BLL.SysAdmin();
                DataRow[] rows = ParamDataSet.Tables[0].Select(" pcode='" + parent.ToString() + "'", "code desc");
                int count = rows.Length;
                int tmpCount = count;
                string pid = "", code = "";
                foreach (DataRow dr in rows)//降次排序，取第一条记录，循环一次退出
                {
                    code = dr["code"].ToString();
                    pid = dr["parent_id"].ToString();
                    int.TryParse(code, out tmpCount);
                    break;
                }
                if (count == tmpCount)
                    tmpCount++;
                Hi.Model.BasParam model = new Model.BasParam();
                model.Code = tmpCount.ToString();
                model.ParentId = pid;
                model.Title = title;
                model.EnableFlag = "1";

                bool blFlag = bll.ParamAdd(model);
                if (blFlag)
                {
                    Ctrls.CbbItem item = new Ctrls.CbbItem();
                    item.Text = title;
                    item.Name = model.Code;
                    item.Value = model.Code;
                    cmb.Items.Insert(0, item);
                    InitParamDataSet();
                }
            }
            catch { }
        }
        #endregion
        #endregion

        #region 系统用户
        /// <summary>
        /// 获取所有用户列表
        /// </summary>
        /// <returns></returns>
        public static DataSet GetUserList()
        {
            DataSet ds = new DataSet();
            Dictionary<string,string> dict = new Dictionary<string,string>() ;
            Hi.BLL.User bll = new BLL.User();
            ds = bll.List(dict, 1, 100,"");
            return ds;
        }
        public static void UserToComboBox(ComboBox cmb)
        {
            int selectindex = -1, count = 0;
            DataSet ds = GetUserList();
            if (ds == null || ds.Tables.Count == 0)
            {
                return;
            }
            cmb.Items.Clear();
            Ctrls.CbbItem item;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                item = new Ctrls.CbbItem();
                item.Text = dr["realname"].ToString().Trim();
                item.Value = dr["userid"].ToString().Trim();
                item.Name = dr["usercode"].ToString().Trim();
                cmb.Items.Add(item);

                if (item.Value == AppSetting.SysOption.UserId)
                    selectindex = count;
                count++;
            }
            if (cmb.Items.Count > 0 && cmb.Items.Count > selectindex)
                cmb.SelectedIndex = selectindex;
        }

        public static void UserToComboBox(ComboBox cmb, out int intSelectIndex)
        {
            int selectindex = -1, count = 0;
            intSelectIndex = selectindex;
            DataSet ds = GetUserList();
            if (ds == null || ds.Tables.Count == 0)
            {
                return;
            }
            cmb.Items.Clear();
            Ctrls.CbbItem item;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                item = new Ctrls.CbbItem();
                item.Text = dr["realname"].ToString().Trim();
                item.Value = dr["userid"].ToString().Trim();
                item.Name = dr["usercode"].ToString().Trim();
                cmb.Items.Add(item);
                count++;
                if (item.Value == AppSetting.SysOption.UserId)
                    selectindex = count;
            }
            intSelectIndex = selectindex;
        }
        public static void UserToComboBox(ComboBox cmb, DataSet ds)
        {
            if (ds == null || ds.Tables[0].Rows.Count == 0)
            {
                return;
            }
            cmb.Items.Clear();
            Ctrls.CbbItem item;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                item = new Ctrls.CbbItem();
                item.Text = dr["realname"].ToString().Trim();
                item.Value = dr["userid"].ToString().Trim();
                item.Name = dr["usercode"].ToString().Trim();
                cmb.Items.Add(item);
            }
        }
        #endregion 
    }
}
