using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

using Hi.Common;
namespace Hi.Client
{
    /// <summary>
    /// 系统权限设置
    /// 菜单编码Sys开头，不显示
    /// </summary>
    public partial class FrmAdmin : Form
    {
        private DataSet _DsUser;
        private TreeNode _CurrentTreeNode;
       
        public FrmAdmin()
        {
            InitializeComponent();
           
            SysUser();
            string strXml = AppSetting.MyResourceManager.GetObject("menu").ToString();
             InitMenu(strXml);
            //Hi.Common.MenuClass.IListMemu = MenuClass.InitMenu(strXml);
            //BindAllData2Dgv(Hi.Common.MenuClass.IListMemu);
             this.btnSave.Enabled = false;
        }
        #region 系统菜单
        
        /// <summary>
        /// 读取XML菜单数据集
        /// </summary>
        /// <param name="xmlFile"></param>
        /// <returns></returns>
        private  List<MenuProperty> InitMenu(string strXml)
        {
            
            XmlDocument xmlDoc = new XmlDocument();
            List<MenuProperty> imenu = new List<MenuProperty>();
            //载入文件，错误返回
            try
            {
                xmlDoc.LoadXml(strXml);
                XPathNavigator navigator = xmlDoc.CreateNavigator();
                XPathNodeIterator nodeIterator = navigator.Select("xml/row");
                //解析XPathNodeIterator下的内容
                ParseMenu(nodeIterator, imenu);
                BindAllData2Dgv(imenu);
                Hi.Common.MenuClass.IListMemu = imenu;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return imenu;
        }
        private void ParseMenu(XPathNodeIterator nodeIterator, List<MenuProperty> IMenu)
        {
            while (nodeIterator.MoveNext())
            {
                string module_code = nodeIterator.Current.GetAttribute("module_code", "");
                if (module_code.ToLower() == "sys09") continue;
                    
                   
                //新建Feed对应的Channel
                MenuProperty menuChannel = new MenuProperty();
                //menuChannel.ModuleId = nodeIterator.Current.GetAttribute("module_id", "");
                //menuChannel.ModuleFather = nodeIterator.Current.GetAttribute("module_father", "");
                menuChannel.ModuleCode = module_code;
                menuChannel.ModuleName = nodeIterator.Current.GetAttribute("module_name", "").Replace("＆", "&");//特殊处理快捷键 ;
                menuChannel.ModuleUrl = nodeIterator.Current.GetAttribute("module_url", "");
                //menuChannel.ModuleGrade = nodeIterator.Current.GetAttribute("module_grade", "");
                menuChannel.ModuleImage = nodeIterator.Current.GetAttribute("image", "");
                menuChannel.ModuleShort = nodeIterator.Current.GetAttribute("module_short", "");
                menuChannel.ModuleTarget = nodeIterator.Current.GetAttribute("module_target", "");
                menuChannel.ModuleQuanxian = nodeIterator.Current.GetAttribute("module_quanxuan", "");
                
                if (!string.IsNullOrEmpty(menuChannel.ModuleName))
                {
                    if(module_code.ToLower().IndexOf("sys")==-1)
                        IMenu.Add(menuChannel);
                    XPathNodeIterator childNodeIterator = nodeIterator.Current.SelectChildren("row", "");
                    ParseMenu(childNodeIterator, IMenu);
                }

            }//end while
        }
        #endregion 

        #region 用户
        private void SysUser()
        {

            Dictionary<string, string> dict = new Dictionary<string, string>();
            _DsUser = Hi.IBLL.HiInstanceBll.UserBll().List(dict, 1, 1000, "");
            if (_DsUser == null || _DsUser.Tables[0].Rows.Count == 0)
                return;
            TreeNode child;
            TreeNode parent = new TreeNode();
            parent.Tag = 0;
            parent.Text = "系统用户";
            

            foreach (DataRow dr in _DsUser.Tables[0].Rows)
            {
                child = new TreeNode();
                child.Tag = dr["userid"].ToString();
                child.Name = dr["usercode"].ToString();
                child.Text = dr["realname"].ToString() + "[" + dr["orgname"].ToString().Trim() + "]";
                
                parent.Nodes.Add(child);
            }
            Application.DoEvents();
            this.tvMenu.Nodes.Add(parent);
            parent.ExpandAll();
        }

        #endregion

        private void BindAllData2Dgv(List<MenuProperty> list)
        {
            //填充数据后，需重置DataGridView滚动条
            int index = 0;
           foreach(MenuProperty menu in list)
            {
                ucdgv.Rows.Add(); //DataGridView在录入数据之前，需要首先增加自己的行的数量   
  
                //将dataRow的单元格数组数据一一填充到DataGridViewRow的Cell中   
                 ucdgv.Rows[index ].Cells[1].Value = menu.ModuleName;
                 ucdgv.Rows[index].Cells[0].Value = menu.ModuleCode;
                //隔行变颜色
                if (index % 2 == 0)
                {
                    ucdgv.Rows[index ].DefaultCellStyle.BackColor = Hi.Common.AppSetting.SkinStyle.RowColor;
                }
                index++;
            }
            ucdgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            ucdgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            for (int i = 2; i < 7; i++)
                AddCheckBox2Header(i);
        }
        #region 在datagridview的列头上设置一个checkbox方法
        /// <summary>
        /// 在datagridview的列头上设置一个checkbox
        /// </summary>
        private void AddCheckBox2Header(int i)
        {
            Hi.UserControlEx.UcDataGridViewClass.DataGridViewCheckboxHeaderCell chk = new Hi.UserControlEx.UcDataGridViewClass.DataGridViewCheckboxHeaderCell();
            chk.OnCheckBoxClicked += new Hi.UserControlEx.UcDataGridViewClass.DataGridViewCheckBoxHeaderEventHander(chk_OnCheckBoxClicked);

            //第一列为DataGridViewCheckBoxColumn
            DataGridViewCheckBoxColumn checkboxCol = this.ucdgv.Columns[i] as DataGridViewCheckBoxColumn;
            checkboxCol.HeaderCell = chk;
            //checkboxCol.HeaderCell.Value = string.Empty;//消除列头checkbox旁出现的文字 
            
        }
        /// <summary>
        /// 单击事件
        /// </summary>
        private void chk_OnCheckBoxClicked(object sender, Hi.UserControlEx.UcDataGridViewClass.DataGridViewCheckBoxHeaderEventArgs e)
        {
            foreach (DataGridViewRow dgvRow in this.ucdgv.Rows)
            {
                if (e.CheckedState)
                {
                    dgvRow.Cells[e.ColumnsIndex].Value = true;
                    this.ucdgv.Rows[dgvRow.Index].Selected = true;
                }
                else
                {
                    dgvRow.Cells[e.ColumnsIndex].Value = false;
                    this.ucdgv.Rows[dgvRow.Index].Selected = false;
                }

            }
        }
        /// <summary>
        /// 选择单选框事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            if (e.ColumnIndex == -1 || e.ColumnIndex == 0 || e.ColumnIndex == 1)
                return;
            if (_CurrentTreeNode == null)
                return;
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)ucdgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if ((bool)chk.FormattedValue)
            {
                chk.Value = false;
                this.ucdgv.Rows[e.RowIndex].Selected = false;
                //this.ucOrderProcess1.Visible = false;
            }
            else
            {
                chk.Value = true;
                this.ucdgv.Rows[e.RowIndex].Selected = true;
            }
            if (e.ColumnIndex == 3)
            {
                string bidcode = ucdgv.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString();
                string module_code = ucdgv.Rows[e.RowIndex].Cells[0].EditedFormattedValue.ToString();
                string module_name = ucdgv.Rows[e.RowIndex].Cells[1].EditedFormattedValue.ToString();
                if (module_code.ToLower() == "hiorderprophase" || module_code.ToLower() == "hiorderprocess")
                {
                    FrmPurviewDetailEdit f = new FrmPurviewDetailEdit(_CurrentTreeNode.Tag.ToString(), module_code.ToLower(), module_name);

                    f.ShowDialog();
                }
            }
        }
       
        #endregion 

        private void ucdgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y, this.ucdgv.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                this.ucdgv.RowHeadersDefaultCellStyle.Font, rectangle,
                this.ucdgv.RowHeadersDefaultCellStyle.ForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
             try
            {
            string tmpPurview=string.Empty,strPurview=string.Empty;
            string module_code;
            for (int i = 0; i < this.ucdgv.Rows.Count; i++)
            {
                module_code = Convert.ToString(this.ucdgv.Rows[i].Cells[0].EditedFormattedValue.ToString());
                tmpPurview ="";
                for(int ii=2;ii<7;ii++)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)this.ucdgv.Rows[i].Cells[ii];
                    
                    if ((bool)chk.FormattedValue)
                        tmpPurview += "Y";
                    else
                        tmpPurview += "N";
                }
                //一个模块没有操作权限，不设置
                if (tmpPurview!="NNNNN")
                   strPurview +=module_code + "|"+tmpPurview+",";
                
            }
            if (!string.IsNullOrEmpty(strPurview))
                strPurview = strPurview.Remove(strPurview.Length - 1);


            bool blFlag = Hi.IBLL.HiInstanceBll.UserBll().UpdatePurview(_CurrentTreeNode.Tag.ToString(), strPurview);
            if (blFlag)
            {
                if (AppSetting.SysOption.UserId == _CurrentTreeNode.Tag.ToString())
                    AppSetting.SysOption.Purview = strPurview;
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
        }

        private void tvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                _CurrentTreeNode = this.tvMenu.SelectedNode;
                if (_CurrentTreeNode.Level == 1)
                {
                    this.btnSave.Enabled = false;
                    Hi.Model.BasUser model = Hi.IBLL.HiInstanceBll.UserBll().Detail(_CurrentTreeNode.Name);
                    this.lblInfo.Text = "正在设置“" + _CurrentTreeNode .Text+ "”操作权限.";
                    SetPurview(model.Purview);
                    this.btnSave.Enabled = true;
                    
                }
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex.Message);
                Error.ErrorMsg(ex);
            }
        }
        /// <summary>
        /// 显示一个用户所有权限
        /// </summary>
        /// <param name="strPurview"></param>
        private void SetPurview(string strPurview)
        {
            for (int i = 0; i < this.ucdgv.Rows.Count; i++)
            {
                for (int ii = 0; ii < 5; ii++)
                {
                    this.ucdgv.Rows[i].Cells[ii + 2].Value = false;
                }
            }
               
             if (string.IsNullOrEmpty(strPurview))
                return;
           
            string module_code;
            
            for (int i = 0; i < this.ucdgv.Rows.Count; i++)
            {
                module_code = Convert.ToString(this.ucdgv.Rows[i].Cells[0].EditedFormattedValue.ToString());
                char[] tmpChar = MenuClass.GetPurviewCharArray(strPurview,module_code);

                for (int ii = 0; ii < tmpChar.Length; ii++)
                {
                    this.ucdgv.Rows[i].Cells[ii+2].Value=tmpChar[ii]=='Y'?true:false;
                }
               
            }
        }
       
    }
}
