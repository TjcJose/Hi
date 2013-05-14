using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Hi.Common;
namespace Hi.Client.BaseForm
{
    public partial class BaseFormEdit : Hi.UserControlEx.UcOpacityForm
    {
        /// <summary>
        /// 子窗口调用委托事件
        /// </summary>
        protected Hi.Client.BaseForm.BaseFormList.DoRefreshHandler _DoRefresh;
        /// <summary>
        /// 表字段主键值
        /// </summary>
        public string IdValue { get; set; }
        /// <summary>
        /// 提示内容
        /// </summary>
        protected string MsgStr { get; set; }

        [BrowsableAttribute(true)]
        public enum Mask { None, 日期, 浮点数, 数字, 字母, 邮箱, 汉字, Ip地址, 身份证 };
        private Mask m_mask = Mask.None;

        public Mask Masked
        {
            get { return m_mask; }
            set
            {
                m_mask = value;
                this.Text = "";
            }
        }

        public BaseFormEdit()
        {
            InitializeComponent();
            //if(EnumType.Mask != EnumType.Mask.None)
            //    m_mask = Masked;

        }
        /// <summary>
        /// 设置保存操作按钮enable属性
        /// </summary>
        /// <param name="form_name"></param>
        protected void SetModulePurview(string form_name)
        {
            try
            {
                //去掉Frm
                string module_code = form_name.Substring(3, form_name.Length - 3);
                if (module_code.ToLower().IndexOf("edit") > -1)
                    module_code = module_code.Substring(0, module_code.Length - 4);

                char[] mychar = MenuClass.GetPurviewCharArray(AppSetting.SysOption.Purview, module_code);
                if (mychar.Length <=2)
                {
                    this.btnAddAndSave.Enabled = false;
                    this.btnSave.Enabled = false;
                    return;
                }
                this.btnAddAndSave.Enabled = (mychar[0] == 'Y' ? true : false);
                this.btnSave.Enabled = (mychar[1] == 'Y' ? true : false);
                this.btnPrint.Enabled = (mychar[3] == 'Y' ? true : false);
            }
            catch (Exception ex)
            {
                Error.ErrorMsg(ex);
            }
        }

        #region  编辑事件
        private void BaseFormEdit_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(IdValue))
            {
                if (this.btnSave.Visible == true && this.btnAddAndSave.Visible == true)
                    this.btnAddAndSave.Visible = false;
            }

            Detail();
        }
        //关闭
        protected virtual void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        //保存并新增
        private void btnAddAndSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        //保存并关闭
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                this.Close();
            }
        }
        //获取信息
        protected virtual void Detail()
        {

        }
        //保存
        protected virtual bool Save()
        {
            return false;
        }
        #endregion

        #region 控件常用事件
        public void ClearTextBox()
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is TextBox)
                {
                    if (this.Controls[i].Enabled == true)
                        this.Controls[i].Text = "";
                }
            }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            //if (m.Msg == WM_PAINT)
            //{
            //    WmPaint(ref m);
            //}
        }

        private void WmPaint(ref Message m, Color tipColor, string tip)
        {
            Rectangle rectangle = new Rectangle(0, 0, Width, Height);
            using (Graphics graphics = Graphics.FromHwnd(base.Handle))
            {
                if (Text.Length == 0
                   && !string.IsNullOrEmpty(tip)
                   && !Focused)
                {
                    TextFormatFlags format =
                    TextFormatFlags.EndEllipsis |
                    TextFormatFlags.VerticalCenter;
                    if (RightToLeft == RightToLeft.Yes)
                    {
                        format |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
                    }

                    TextRenderer.DrawText(
                        graphics,
                        tip,
                        Font,
                        base.ClientRectangle,
                        tipColor,
                          format);
                }
            }
        }




        public void Control_Enter(object sender)
        {
            System.Windows.Forms.Control ctrl = sender as System.Windows.Forms.Control;

            ctrl.BackColor = System.Drawing.Color.FromArgb(0xC0, 0xFF, 0xC0);
            ctrl.ForeColor = System.Drawing.Color.Red;

            if (ctrl is System.Windows.Forms.ComboBox)
            {
                ((System.Windows.Forms.ComboBox)ctrl).DroppedDown = true;
            }
            else if (ctrl is System.Windows.Forms.TextBox)
            {
                ((System.Windows.Forms.TextBox)ctrl).SelectAll();
            }
        }

        public void Control_Leave(object sender)
        {
            System.Windows.Forms.Control ctrl = sender as System.Windows.Forms.Control;

            ctrl.BackColor = System.Drawing.Color.White;
            ctrl.ForeColor = System.Drawing.Color.Black;
        }
        protected void TextBox_Enter(object sender, EventArgs e)
        {
            Control_Enter(sender);
        }

        protected void TextBox_Leave(object sender, EventArgs e)
        {
            Control_Leave(sender);
        }
        private void BaseFormEdit_Enter(object sender, EventArgs e)
        {
            Control_Enter(sender);
        }

        private void BaseFormEdit_Leave(object sender, EventArgs e)
        {
            Control_Leave(sender);
        }
        #endregion


        #region 常用字符串验证方法
        private void OnCheckedInput(object sender, KeyPressEventArgs e, Mask mask)
        {
            TextBox sd = (TextBox)sender;
            switch (mask)
            {
                case Mask.日期:
                    if (!Utils.IsDateTime(sd.Text))
                    {
                        errorProvider1.SetError(this, "日期无效; yyyy-mm-dd");
                        sd.Text = "";
                    }
                    else
                    {
                        this.errorProvider1.SetError(this, "");
                    }
                    break;

                case Mask.浮点数:
                    //if (!(((e.KeyChar >= (char)48) && (e.KeyChar <= (char)57)) || (e.KeyChar == (char)13) || (e.KeyChar == (char)8) || (e.KeyChar == (char)110) || (e.KeyChar == (char)190)))
                    //{

                    //    if (e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
                    //    {
                    //        this.errorProvider1.SetError(this, "");
                    //        e.Handled = true;
                    //    }
                    //}
                    //else
                    //{
                    //    errorProvider1.SetError(this, "浮点数无效");
                    //    e.Handled = false;
                    //}
                    if (!Char.IsNumber(e.KeyChar) && !Char.IsPunctuation(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    else if (Char.IsPunctuation(e.KeyChar))
                    {
                        if (e.KeyChar == '.')
                        {
                            if (sd.Text.LastIndexOf('.') != -1)
                            {
                                e.Handled = true;
                            }
                        }
                        else if (e.KeyChar == '-')
                        {
                            if (sd.Text.IndexOf('.') == 0)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }

                    break;

                case Mask.数字:
                    //if (!(Char.IsNumber(e.KeyChar) || e.KeyChar == '\b'))
                    //{
                    //    e.Handled = true;
                    //    errorProvider1.SetError(this, "数字无效");
                    //}
                    //else
                    //{
                    //    sd.Text = "";
                    //    this.errorProvider1.SetError(this, "");
                    //}
                    if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                        this.errorProvider1.SetError(this, "数字无效");
                    }



                    break;
                case Mask.汉字:
                    if (!Utils.IsHasCHZN(sd.Text))
                    {
                        errorProvider1.SetError(this, "格式:名称只能是汉字组合!");
                        sd.Text = "";
                    }
                    else
                    {
                        this.errorProvider1.SetError(this, "");
                    }
                    break;
            }
        }
        protected void TextBox_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnCheckedInput(sender, e, Mask.数字);
        }
        protected void TextBox_Float_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnCheckedInput(sender, e, Mask.浮点数);
        }
        protected void TextBox_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnCheckedInput(sender, e, Mask.日期);
        }
        protected void TextBox_Letter_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnCheckedInput(sender, e, Mask.字母);
        }
        protected void Txt_Email_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnCheckedInput(sender, e, Mask.邮箱);
        }
        protected void Txt_Chinese_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnCheckedInput(sender, e, Mask.汉字);
        }
        #endregion

    }
}