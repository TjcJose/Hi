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
	public partial class Frm$ClassName$Edit : Hi.Client.BaseForm.BaseFormEdit
    {
    	
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="doRefresh"></param>
    	public Frm$ClassName$Edit(Hi.Client.BaseForm.BaseFormList.DoRefreshHandler doRefresh)
        {
            InitializeComponent();
            this._DoRefresh = doRefresh;
        }
        
        /// <summary>
        /// 重写获取详细事件
        /// </summary>
        protected override void Detail()
        {
            if (string.IsNullOrEmpty(IdValue))
                return;
            Hi.Model.$ClassName$ model = new Hi.Model.$ClassName$();
            model = Hi.IBLL.HiInstanceBLL.$ClassName$BLL().Detail(IdValue);
            $GetDetail$
        }
        private Hi.Model.$ClassName$ SetDetail()
        {
        	Hi.Model.$ClassName$ model = new Hi.Model.$ClassName$();
            model.$KeyName$ = this.IdValue;
            $SetDetail$

            return model;
        }
        /// <summary>
        /// 重写保存事件
        /// </summary>
        /// <returns></returns>
        protected override bool Save()
        {
            bool blResult = false;
            if (!CheckedInput())
                return blResult;

            if (string.IsNullOrEmpty(this.IdValue))
            {
                blResult = Hi.IBLL.HiInstanceBLL.$ClassName$BLL().Add(SetDetail());
                this.MsgStr = "新增";
            }
            else
            {
                blResult = Hi.IBLL.HiInstanceBLL.$ClassName$BLL().Update(SetDetail());
                this.MsgStr = "修改";
            }
            if (blResult)
            {
                MsgBox.ShowInformation(this.MsgStr+"成功!");
                _DoRefresh();
            }
            else
            {
                MsgBox.ShowInformation(this.MsgStr + "失败!");
            }
            return blResult;
        }
        /// <summary>
        /// 验证方法
        /// </summary>
        /// <returns></returns>
        private bool CheckedInput()
        {
            /*if (string.IsNullOrEmpty(this.txtName.Text))
            {
                
                MsgBox.ShowInformation("请输入商品类别名称");
                this.txtName.Focus();
                return false;
            }*/
            return true;
        }
    }
}

