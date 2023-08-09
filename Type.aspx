<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin.Master" CodeBehind="Type.aspx.vb" Inherits="CarsRental.Type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
         <asp:Label ID="lblMsg" runat="server"></asp:Label>
  
      <table class="center" >
            <tr>
                <td colspan="2"><h2>Types Form</h2></td>
            </tr>
          <tr>
              <td>Types Name</td>
              <td>
                    <asp:TextBox ID="TName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TName" ForeColor="Red" ErrorMessage="Types Name is Required" ValidationGroup="Register2" ></asp:RequiredFieldValidator>
              </td>
          </tr>
              
           <tr>
                <td>Make Name</td>
                <td>
                    <asp:DropDownList ID="ddlMake1" runat="server"></asp:DropDownList>
                </td>
            </tr>
        
                       
               <tr>
                <td colspan="2"> <asp:label ID ="lblStatus" runat="server" /></td> 
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
          
         <asp:GridView ID="gvModelDtl" DataKeyNames="Id" AutoGenerateColumns="false"
        OnSelectedIndexChanged="gvSubDetails_SelectedIndexChanged" Width="500" runat="server">
            <HeaderStyle BackColor="#9a9a9a" ForeColor="White" Font-Bold="true" Height="30" />
            <AlternatingRowStyle BackColor="#f5f5f5" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnSelect" runat="server" CommandName="Select" Text="Select"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type Name">
                    <ItemTemplate>
                        <asp:Label ID="lbltype" Text='<%#Eval("TypesName") %>'
                        runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                  
               <%-- <asp:TemplateField HeaderText="Make Name">
                    <ItemTemplate>
                      <asp:Label ID="lblmake2" Text='<%#Eval("MakeName") %>'
                        runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>--%>
                
                      <asp:TemplateField HeaderText="MakeName">
          <ItemTemplate>
                           
              <asp:Label runat="server" ID="lblmake2" Text='<%# Eval("MakeName")%>' />
          </ItemTemplate>
      </asp:TemplateField>


            </Columns>
        </asp:GridView>

  </div>
</asp:Content>
