<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin.Master" CodeBehind="AddModel.aspx.vb" Inherits="CarsRental.AddModel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
        <table>
       <tr>
                <td style="visibility:hidden">ModelId</td>
                <td>
                    <asp:DropDownList ID="ModelId" runat="server" Visible="false"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Model Name</td>
                <td>
                    <asp:TextBox ID="txtModelName" runat="server"></asp:TextBox>
 
                </td>
            </tr>
               <tr>
                <td>Image</td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" /> <asp:Button ID="Upload" runat="server" Text="Upload" />
                </td>
            </tr>
            <tr>
                <td>Make Name</td>
                <td>
                    <asp:DropDownList ID="ddlMake" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Type Name</td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click"
                    Text="Insert" ValidationGroup="vgAdd" />
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click"
                    Text="Update" ValidationGroup="vgAdd" />
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click"                    
                    OnClientClick="return confirm('Are you sure you want to delete this record?')"
                    Text="Delete" ValidationGroup="vgAdd" />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click"
                    Text="Cancel" CausesValidation="false" />
                </td>
            </tr>
        </table>
        <br />
        <asp:GridView ID="gvModelDtl" DataKeyNames="ModelId" AutoGenerateColumns="false"
        OnSelectedIndexChanged="gvSubDetails_SelectedIndexChanged" Width="500" runat="server">
            <HeaderStyle BackColor="#9a9a9a" ForeColor="White" Font-Bold="true" Height="30" />
            <AlternatingRowStyle BackColor="#f5f5f5" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnSelect" runat="server" CommandName="Select"
                        Text="Select" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Model_name">
                    <ItemTemplate>
                        <asp:Label ID="lblmodel_name" Text='<%#Eval("ModelName") %>'
                        runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="image" ImageUrl='<%#Eval("Images") %>'
                        runat="server" Width="50px" Height="50px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Make Name">
                    <ItemTemplate>
                        <asp:Label ID="lblMake" Text='<%#Eval("MakeName") %>'
                        runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type Name">
                    <ItemTemplate>
                        <asp:Label ID="lblType" Text='<%#Eval("TypesName") %>'
                        runat="server"  />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
