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
            [Administrator][V1.0][51编程-代码器自动生成][2011-4-25 15:36:47]
 修改信息 ：(1)[开发员][V1.1][备注][日期]
            (2)[开发员][V1.2][备注][日期]
--------------------------------------------------------------------------------------------------

*/
using System;

namespace Hi.Model
{
 /// <summary>
    /// bas_log 实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class BasLog
    {
        //构造函数
        public BasLog() { }
		  /// <summary>
  /// 
  /// </summary>
public long Logid{get;set;}
  /// <summary>
  /// 
  /// </summary>
public int Logtype{get;set;}
  /// <summary>
  /// 
  /// </summary>
public DateTime Logtime{get;set;}
  /// <summary>
  /// 
  /// </summary>
public string Username{get;set;}
  /// <summary>
  /// 
  /// </summary>
public string Userip{get;set;}
  /// <summary>
  /// 
  /// </summary>
public string Logcontent{get;set;}
  /// <summary>
  /// 
  /// </summary>
public string Scriptname{get;set;}
  /// <summary>
  /// 
  /// </summary>
public string Poststring{get;set;}

	}
}

