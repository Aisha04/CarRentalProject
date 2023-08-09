<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin.Master" CodeBehind="Model.aspx.vb" Inherits="CarsRental.Model" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div>
        <fieldset>
             <asp:Label ID="lblMsg" runat="server"></asp:Label>
        <table class="center">
            <tr>
                <td colspan="2"><h2>Model Form</h2></td>
            </tr>
            <tr>
                <td>Model Name</td>
                <td>
                     <asp:TextBox ID="model" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ControlToValidate="model" ForeColor="Red" ErrorMessage="Model Name is Required" ValidationGroup="Register1" ></asp:RequiredFieldValidator>
                       

                </td>
                </tr>
            <tr>
              <td>
                  Images
              </td>
              <td>
                  <asp:FileUpload ID="fileUpload2" runat="server" />
                         


                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorFile" runat="server" ControlToValidate="fileupload2" ForeColor="Red"  ErrorMessage="Please upload a picture" ValidationGroup ="Register2" ></asp:RequiredFieldValidator>
                  
              </td>
          </tr>
            <tr>
                <td>Make Name</td>
                <td>
                      <asp:DropDownList runat="server" ID="Make">
                          
                        </asp:DropDownList> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorMake" runat="server" ControlToValidate="make" ForeColor="Red" InitialValue="-1" ErrorMessage="Please select a Make" ValidationGroup ="Register1" ></asp:RequiredFieldValidator>
                </td>
            </tr>
           
                 
                     <tr>
                <td colspan="2">
                    <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" ValidationGroup="Register1" Text="Insert" />
                    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" ValidationGroup="Register1" Text="Update" />
                    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" ValidationGroup="Register1" OnClientClick="return confirm('Are you sure you want to delete this record?')" Text="Delete"  />
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CausesValidation="false" />
                </td>
            </tr>

            
             <tr>
                <td colspan="2"> <asp:label ID ="lblStatus" runat="server" /></td> 
            </tr>
        </table>
         </fieldset>

           <asp:GridView ID="gvSubDetails" DataKeyNames="ModelId" AutoGenerateColumns="false" OnSelectedIndexChanged="gvSubDetails_SelectedIndexChanged" Width="500" runat="server">
            <HeaderStyle BackColor="#9a9a9a" ForeColor="White" Font-Bold="true" Height="30" />
            <AlternatingRowStyle BackColor="#f5f5f5" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnSelect" runat="server" CommandName="Select"
                        Text="Select" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ModelName">
                    <ItemTemplate>
                        <asp:Label ID="model" Text='<%#Eval("ModelName") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Images">
                    <ItemTemplate>
                        <asp:Label ID="fileUpload2" Text='<%#Eval("Images") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Make">
                    <ItemTemplate>
                        <asp:Label ID="make" Text='<%#Eval("MakeName") %>' runat="server"  />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
