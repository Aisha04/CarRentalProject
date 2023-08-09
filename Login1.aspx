<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Client.Master" CodeBehind="Login1.aspx.vb" Inherits="CarsRental.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
     <div >
        
      <table style="background-color:dodgerblue; color:darkblue; width:750px; height:350px; text-align:center; margin-left:375px;">
       <tr>
           <td><h2>Welcome To Car Rental</h2></td>
       </tr>
            <tr>
                <td>
  UserName  <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox> <br />
                    </td>
            </tr>
            <tr>
                <td>
                       Password  <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox> <br />
                </td>
                </tr>
        
            <tr>
                <td >
                     <asp:Button ID="btnLogin" runat="server" Text="SignIn" style="background-color:darkcyan; color:black; font-size:15px; border-radius:12px; padding:12px 24px; "/>

                </td>
            </tr>
     
          <tr>
              <td>
                  <asp:Hyperlink ID="reg" runat="server" NavigateUrl="~/ResgistrationForm.aspx">Register Now</asp:Hyperlink>
              </td>
          </tr>
            </table>
           
            </div>



</asp:Content>
