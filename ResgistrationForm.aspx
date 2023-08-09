<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Client.Master" CodeBehind="ResgistrationForm.aspx.vb" Inherits="CarsRental.ResgistrationForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div >
           <fieldset>
            <table border="0" class="center1">
                 
                <tr>
                    <td colspan="2"><h2>User Registration</h2></td>
                </tr>
                <tr>
                    <td>
                        First Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtfirstName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="txtfirstName" ForeColor="Red" ErrorMessage="First Name is Required" ValidationGroup="Register" ></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                         Surname
                    </td>
                    <td>
                        <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSurname" ForeColor="Red" ErrorMessage="Surame is Required" ValidationGroup="Register" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                     <tr>
                    <td>
                         Phone Number
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ControlToValidate="txtPhone" ForeColor="Red" ErrorMessage="Phone Number is Required" ValidationGroup="Register" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic" ErrorMessage="Should contain 8 digit only" ControlToValidate="txtPhone" ForeColor ="Red" ValidationExpression="[0-9]{8}" ValidationGroup="Register"></asp:RegularExpressionValidator>

                        </td>
                </tr>
                     <tr>
                    <td>
                         Address
                    </td>
                    <td>
                        <asp:TextBox ID="txtAdd" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAdd" ForeColor="Red" ErrorMessage="Address is Required" ValidationGroup="Register" ></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                   <td>
                    Gender
                </td>
                    <td>
                <asp:RadioButton runat="server" ID="female" text="Female" Value="1" checked="True" GroupName ="Gender" RepeatDirection="Horizontal"  RepeatLayout="Flow"/>
                <asp:RadioButton runat="server" ID="male" text="Male" Value="2" GroupName="Gender" RepeatDirection="Horizontal"  RepeatLayout="Flow"/>
                <asp:RadioButton runat="server" ID="other" text="Other" Value="3" GroupName="Gender" RepeatDirection="Horizontal"  RepeatLayout="Flow"/>

                                                      
                                    <%-- <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Mele</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:RadioButtonList>--%>
         
                     
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" ControlToValidate="Gender" ForeColor="Red"  ErrorMessage="Please select a Gender" ValidationGroup ="Register" ></asp:RequiredFieldValidator>--%>
                     
                  </td>
                </tr>
               <tr>
                   <td>
                       Age
                   </td>
                   <td>
                   <asp:TextBox ID="txtAge"  runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ControlToValidate="txtAge"  Display="Dynamic"  ID="RequiredFieldValidator4" runat="server" ErrorMessage="Age is Required" ForeColor="Red" ValidationGroup="Register"></asp:RequiredFieldValidator>
                    <asp:RangeValidator Display="Dynamic" ID="RangeValidatorAge"  SetFocusOnError="true" MaximumValue="100" MinimumValue ="18" Type="Integer" ControlToValidate="txtAge" ForeColor="Red" runat="server" ErrorMessage="Age must be between 18 and 100"></asp:RangeValidator>
                    <asp:CompareValidator ID="CompareValidatorAge"  Display="Dynamic" SetFocusOnError="true" Operator="DataTypeCheck" ControlToValidate="txtAge" Type="Integer" ForeColor="Red" runat="server" ErrorMessage="Must Be age an integer"></asp:CompareValidator>


                </td>

               </tr>
                 <tr>
                <td>
                     Email
                 </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail"  ForeColor="Red" ControlToValidate="txtEmail" Display="Dynamic" runat="server" ErrorMessage="Email is Required" ValidationGroup="Register"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail"  runat="server" Display="Dynamic" ErrorMessage="Invalid Email" ControlToValidate="txtEmail" ForeColor ="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Register"></asp:RegularExpressionValidator>

                </td>
            </tr>
                <tr>
                   <td>
                    Role
                </td>
                    <td>
                        <asp:RadioButton runat="server" ID="Arole" Text="Admin" Value="1"  Checked="True" GroupName="role" RepeatDirection="Horizontal"  RepeatLayout="Flow"/>
                        <asp:RadioButton runat="server" ID="Crole" Text="Client" Value="2" GroupName="role" RepeatDirection="Horizontal"  RepeatLayout="Flow"/>
                          
                         
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="role" ForeColor="Red" InitialValue="-1" ErrorMessage="Please select a Status" ValidationGroup ="Register" ></asp:RequiredFieldValidator>--%>
                   </td>
                </tr>
                  <tr>
                    <td>
                         License Number
                    </td>
                    <td>
                        <asp:TextBox ID="license" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" ControlToValidate="license" ForeColor="Red" ErrorMessage="License Number is Required" ValidationGroup="Register" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ErrorMessage="Should contain 8 digit only" ControlToValidate="license" ForeColor ="Red" ValidationExpression="[0-9]{8}" ValidationGroup="Register"></asp:RegularExpressionValidator>

                        </td>
                </tr>
            <tr>
                <td>User Name</td>
                <td>
                    <asp:TextBox ID="txtNewUser" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="txtNewUser"
                     runat="server" ErrorMessage="UserName is Required" ValidationGroup="Register"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtNewPassword" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ForeColor="Red" ControlToValidate="txtNewPassword" runat="server" ErrorMessage="Password is Required" ValidationGroup="Register"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Confirm Password</td>
                <td><asp:TextBox ID="txtConfirm" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorConfirm" ForeColor="Red" ControlToValidate="txtConfirm" runat="server" Display="Dynamic" ErrorMessage="confirm password is Required" ValidationGroup="Register"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidatorPassword"  SetFocusOnError="true" Type="String" Display="Dynamic" ForeColor="Red" ControlToValidate="txtConfirm" runat="server" ControlToCompare="txtNewPassword" Operator="Equal" ErrorMessage="Password and Confirm Password is not Matching" ValidationGroup="Register"></asp:CompareValidator>
                </td>
            </tr>
                <tr>
                <td colspan="2"> <asp:label ID ="lblStatus" runat="server" /></td> 
            </tr>


                  <tr>
                <td colspan="2"> 
                    <asp:Button ID ="txtButton" runat="server" Text="Register" ValidationGroup="Register" />
                    &nbsp;&nbsp;
                    <asp:Button ID ="txtClear" runat="server" Text="Clear" CausesValidation="False" />

                </td> 
            </tr>


                 
                
            </table>
          
</fieldset> 
    
   </div>
     <asp:AdRotator id="AdRotator1" runat="server" Target="_blank" AdvertisementFile="~/Advertisement.xml"/>
        
</asp:Content>
