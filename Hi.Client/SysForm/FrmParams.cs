using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Hi.Common;
namespace Hi.Client
{
    public partial class FrmParams : Form
    {
       
        private string IdValue = "";
        private DataSet _DsParam;
        private TreeNode _CurTreeNode;
        public FrmParams()
        {
            InitializeComponent();
            TreeViewData();
            Ctrls.CbbItem item = new Ctrls.CbbItem();
            item.Name = "0";
            item.Text = "";
            item.Value = "0";
            this.cmbParent.Items.Insert(0,item);
            this.lblInfo.Text = "请在技术员的指导下进行修改、删除";
        }
  
        #region Treeview
        /// <summary>
        /// 系统参数数据集
        /// </summary>
        private void TreeViewData()
        {
            this.treeView1.Nodes.Clear();
            Dictionary<string, string> dict = new Dictionary<string, string>();

            _DsParam = Hi.IBLL.HiInstanceBLL.SysAdminBLL().ParamList(dict, 1, 1000, "");
           
            TreeNode parent = new TreeNode();
            parent.Tag = 0;
            parent.Text = "系统参数";
            parent.Name = "PCode";
            DataSet2Feed(_DsParam, parent, "0");
            Application.DoEvents();
            this.treeView1.Nodes.Add(parent);
            parent.Expand();
            //this.treeView1.ExpandAll();
        }
     
        /// <summary>
        /// 递归绑定到TreeView
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private void DataSet2Feed(DataSet ds, TreeNode parent,string parentid)
        {
            TreeNode child ;
            string parent_id = "", id = "",code="";
            DataRow[] myDataRow = ds.Tables[0].Select(" parent_id=" + parentid+" ");
            foreach (DataRow dr in myDataRow)
            {
                parent_id = dr["parent_id"].ToString();
                id = dr["id"].ToString();
                code = dr["code"].ToString().Trim();
                child = new TreeNode();
                child.Tag  = dr["id"];
                child.Name = dr["code"].ToString();
                child.Text = dr["title"].ToString() + "[" + code + "]";
               
                if ( parent_id == "0")
                {
                    ParentComboBox(child);
                    DataSet2Feed(ds, child, id);
                }
                Application.DoEvents();
                parent.Nodes.Add(child);
                
            } 
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = this.treeView1.SelectedNode;
            switch (node.Level)
            {
                case 0:
                    return;
                case 1:
                    this.cmbParent.SelectedIndex = -1;
                    break;

            }
            _CurTreeNode = node;

            GetDetail(node.Tag.ToString());
        }
       
        #endregion 
        /// <summary>
        /// 大类ComboBox
        /// </summary>
        private void ParentComboBox(TreeNode child)
        {
            Ctrls.CbbItem item = new Ctrls.CbbItem();
            item.Name = child.Name;
            item.Text = child.Text;
            item.Value = child.Tag.ToString();
            this.cmbParent.Items.Insert(0,item);
        }


        #region 新增、修改、删除
        /// <summary>
        /// 重写获取详细事件
        /// </summary>
        
        private Hi.Model.BasParam SetDetail()
        {
            Hi.Model.BasParam model = new Hi.Model.BasParam();
            model.Id = this.IdValue;
            model.Title = this.txtName.Text.Trim();
            model.Code = this.txtCode.Text.Trim();
            model.EnableFlag = this.rdo2.Checked ? "2" : (this.rdo1.Checked?"1":"0");
           
            if (this.cmbParent.SelectedIndex > -1)
            {
                Ctrls.CbbItem item = (Ctrls.CbbItem)this.cmbParent.SelectedItem;
                model.ParentId = item.Value;
                model.Grade = "2";
            }
            else
            {
                model.ParentId = "0";
                model.Grade = "1";
            }
           
            return model;
        }
        private void GetDetail(string id)
        {
            if (string.IsNullOrEmpty(id))
                return;
            foreach (DataRow dr in _DsParam.Tables[0].Select(" id=" + id))
            {
                this.IdValue = id;
                this.txtCode.Text = dr["code"].ToString().Trim();
                this.txtName.Text = dr["title"].ToString().Trim();
                this.txtSort.Text = dr["sort"].ToString().Trim();
                if (dr["enable_flag"].ToString().Trim() == "2")
                {
                    this.rdo2.Checked = true;
                    //this.rdo1.Checked = false;
                    //this.rdo0.Checked = false;
                    this.groupBox1.Enabled = false;
                    this.btnDel.Enabled = false;

                }
                else if (dr["enable_flag"].ToString().Trim() == "1")
                {
                    this.rdo2.Checked = false;
                    this.rdo1.Checked = true;
                    this.rdo0.Checked = false;
                    this.groupBox1.Enabled = true;
                    this.btnDel.Enabled = true;
                }
                else
                {
                    this.rdo2.Checked = false;
                    this.rdo1.Checked = false;
                    this.rdo0.Checked = true;
                    this.groupBox1.Enabled = true;
                    this.btnDel.Enabled = true;
                }
                this.txtCode.Enabled = this.groupBox1.Enabled;
                ModuleData.SetComboBoxSelectedIndex(this.cmbParent, 1, dr["parent_id"].ToString().Trim());

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Hi.Client.SysForm.FrmTrail frmtrail = new SysForm.FrmTrail();
            //frmtrail.Show();
            Save();
        }
        /// <summary>
        /// 保存事件
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            bool blResult = false;
            string strMsg = "";
            if (!CheckedInput())
                return blResult;

            if (string.IsNullOrEmpty(this.IdValue))
            {
                blResult = Hi.IBLL.HiInstanceBLL.SysAdminBLL().ParamAdd(SetDetail());
                strMsg = "新增";
            }
            else
            {
                 blResult = Hi.IBLL.HiInstanceBLL.SysAdminBLL().ParamUpdate(SetDetail());
                strMsg = "修改";
            }
            if (blResult)
            {
                MsgBox.ShowInformation( strMsg+"成功!");
                ModuleData.InitParamDataSet();
                TreeViewData();
            }
            else
            {
                MsgBox.ShowInformation(strMsg + "失败!");
            }
            return blResult;
        }
        /// <summary>
        /// 验证方法
        /// </summary>
        /// <returns></returns>
        private bool CheckedInput()
        {
            if (string.IsNullOrEmpty(this.txtName.Text))
            {
                MsgBox.ShowInformation("请输入参数名称");
                this.txtName.Focus();
                return false;
            }
            return true;
        }
        //清空输入框
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.IdValue = "";
            this.txtCode.Text = "";
            this.txtName.Text = "";
            this.txtSort.Text = "";
            this.txtCode.Enabled = true;
            this.groupBox1.Enabled = true;
            this.btnDel.Enabled = false;
            this.rdo1.Checked = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.IdValue))
                return;
            if (this._CurTreeNode == null)
                return;
            if (this._CurTreeNode.Nodes.Count > 0)
            {
                MsgBox.ShowInformation("请先从子选项内容开始删除！");
                return;
            }
            bool blFlag = Hi.IBLL.HiInstanceBLL.SysAdminBLL().ParamDelete(this.IdValue);
            if (blFlag)
            {
                this.treeView1.Nodes.Remove(_CurTreeNode);
                ModuleData.InitParamDataSet();
            }
        }

        #endregion 
 
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeViewData();
            if (this._CurTreeNode == null)
                return;

            if (this._CurTreeNode.Level == 2)
            {
                this._CurTreeNode.Parent.Expand();
            }
            else if (this._CurTreeNode.Level == 1)
                this._CurTreeNode.Expand();
        }

        private void FrmParams_Load(object sender, EventArgs e)
        {

        }
    }
}
