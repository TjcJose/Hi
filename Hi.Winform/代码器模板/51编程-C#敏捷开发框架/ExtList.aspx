<%@ Page Language="C#" AutoEventWireup="true" Inherits="Hi.Web.PageExt.Modules_$ClassName$" Codebehind="$ClassName$ExtList.aspx.cs" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link type="text/css" href="../css/main.css" rel="Stylesheet" />
    <ext:ResourcePlaceHolder ID="ResourcePlaceHolder1" runat="server" />

    <script type="text/javascript" src="../js/utils.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager runat="server" />
   
    <ext:Store ID="Store1" runat="server" OnRefreshData="Store1_RefreshData" >
        <Reader>
            <ext:JsonReader IDProperty="ID">
                <Fields>
                    $RecordField$
                   
                </Fields>
            </ext:JsonReader>
        </Reader>
        <Proxy>
            <ext:PageProxy>
            </ext:PageProxy>
        </Proxy>
    </ext:Store>
    <ext:Viewport ID="ViewPort1" runat="server">
        <Items>
            <ext:BorderLayout ID="BorderLayout1" runat="server">
                <Center MarginsSummary="0 0 0 0">
                    <ext:GridPanel ID="GridPanel1" Frame="true" runat="server" AutoWidth="true" StoreID="Store1">
                        <TopBar>
                            <ext:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <ext:Button ID="btnAdd" runat="server" Text="新增" Icon="Add">
                                        <Listeners>
                                            <Click Handler="#{winDetail}.show();" />
                                        </Listeners>
                                    </ext:Button>
                                    
                                    <ext:Button ID="btnDelete" runat="server" Icon="Delete" Text="删除">
                                        <DirectEvents>
                                            <Click OnEvent="btnDelete_Click">
                                                <Confirmation Title="提示" ConfirmRequest="true" Message="确定要删除吗？" />
                                                <ExtraParams>
                                                    <ext:Parameter Name="Values" Value="Ext.encode(#{GridPanel1}.getRowsValues({selectedOnly : true}))"
                                                        Mode="Raw" />
                                                </ExtraParams>
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:ToolbarFill></ext:ToolbarFill>
                                   
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <ColumnModel runat="server">
                            <Columns>
                               $Column$
                               
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server"  />
                        </SelectionModel>
                        <LoadMask ShowMask="true" Msg="数据加载中..." />
                        
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolBar1" runat="server" StoreID="Store1" DisplayInfo="false"
                                >
                                <Items>
                                    <ext:Label ID="Label1" runat="server" Text="每页显示:" />
                                    <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                    <%--自定义页大小--%>
                                    <ext:ComboBox ID="cmbPageSize" runat="server" Width="80">
                                        <Items/>
                                           
                                        <SelectedItem Value="20" />
                                        <Listeners>
                                            <Select Handler="#{PagingToolBar1}.pageSize = parseInt(this.getValue()); #{PagingToolBar1}.doLoad();" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:PagingToolbar>
                        </BottomBar>
                    </ext:GridPanel>
                </Center>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
	 <ext:Window ID="winDetail" runat="server" IconCls="icon-user" Modal="true" Title="编辑"
        Hidden="true" Width="480" Height="460">
        <Content>
            <ext:FormPanel ID="FormPanel1" runat="server" MonitorValid="true" Padding="10" AutoWidth="true"
                Height="430" ButtonAlign="center">
                <Items>
                    <ext:Panel ID="Panel3" runat="server" Border="false" Header="false" Layout="Form"
                        LabelSeparator="：" LabelWidth="70">
                        <Items>
                            $TextField$
                            <ext:Hidden ID="hdfId" runat="server" DataIndex="$KeyName$" />
                        </Items>
                    </ext:Panel>
                </Items>
                <Buttons>
                    <ext:Button ID="btnAddAndSave" runat="server" Text="新增保存" Icon="Add">
                        <Listeners>
                            <Click Handler="if (!#{FormPanel1}.getForm().isValid()){return false;};" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnAddAndSave_Click" />
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnSave" runat="server" Text="修改保存" Icon="Disk">
                        <Listeners>
                            <Click Handler="if (!#{FormPanel1}.getForm().isValid()){return false;};" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnSave_Click" />
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnClose" runat="server" Text="关闭" Icon="Cancel">
                        <Listeners>
                            <Click Handler="#{winDetail}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Content>
    </ext:Window>
    </form>
</body>
</html>
