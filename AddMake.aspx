<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin.Master" CodeBehind="AddMake.aspx.vb" Inherits="CarsRental.Make" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div>
 
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
      <table class="center">
            
                  
          <tr>
                <td colspan="2"><h2>Make Form</h2></td>
            </tr>
           <tr>
                <td style="visibility:hidden">Make Id:</td>
                <td>
                    <asp:TextBox ID="txtMakeId" runat="server" visible="false" />
                </td>
            </tr>

          <tr>
              <td>Make Name</td>
              <td>
                    <asp:DropDownList runat="server" ID="make">
                            <asp:ListItem Value="-1" Text="Select one" Selected="True"></asp:ListItem>
                       
                        
                    </asp:DropDownList> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="make" ForeColor="Red" InitialValue="-1" ErrorMessage="Please select a Type" ValidationGroup ="Register2" ></asp:RequiredFieldValidator>
                
              </td>
          </tr>

         <%-- <tr>
              <td>Make Name</td>
              <td>
                  <asp:TextBox ID="make1" runat="server"></asp:TextBox>
              </td>
          </tr>--%>

          <tr>
              <td>
                  Image
              </td>
              <td>
                  
                      <asp:FileUpload ID="FileUpload2" runat="server" /> <asp:Button ID="Upload" runat="server" Text="Upload" />     


                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFile" runat="server" ControlToValidate="fileupload2" ForeColor="Red"  ErrorMessage="Please upload an Image" ValidationGroup ="Register2" ></asp:RequiredFieldValidator>
                  
              </td>
          </tr>
  
         
         <%-- <tr>
                <td colspan="2"> 
                    <asp:Button ID ="txtButton" runat="server" Text="Register" ValidationGroup="Register2" />
                    &nbsp;&nbsp;
                    <asp:Button ID ="txtClear" runat="server" Text="Clear" CausesValidation="False" />

                </td> 
            </tr>--%>
           
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
     
      <asp:GridView ID="gvModelDtl" DataKeyNames="MakesId" AutoGenerateColumns="false"
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
                <asp:TemplateField HeaderText="Make Name">
                    <ItemTemplate>
                        <asp:Label ID="lblmake" Text='<%#Eval("MakeName") %>'
                        runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="image" ImageUrl='<%#Eval("Image") %>'
                        runat="server" Width="50px" Height="50px" />
                    </ItemTemplate>
                </asp:TemplateField>
              
               
            </Columns>
        </asp:GridView>

  </div>
</asp:Content>
