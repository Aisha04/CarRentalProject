<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Admin.Master" CodeBehind="vehicle.aspx.vb" Inherits="CarsRental.vehicle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
    <asp:Label ID="lblMsg" runat="server"></asp:Label>
      
        <table class="center">
            <tr>
                <td colspan="2"><h2>Vehicle Form</h2></td>
            </tr>
            <tr>
                <td>Registration Number</td>
                <td>
                     <asp:TextBox ID="RegNum" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" ControlToValidate="RegNum" ForeColor="Red" ErrorMessage="Registration Number is Required" ValidationGroup="Register1" ></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic" ErrorMessage="Should contain 4 digit only" ControlToValidate="RegNum" ForeColor ="Red" ValidationExpression="[0-9]{4}" ValidationGroup="Register1"></asp:RegularExpressionValidator>

                </td>
                </tr>
            <tr>
                <td>Color</td>
                <td>
                    <asp:TextBox ID="color" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="color" ForeColor="Red" ErrorMessage="Color is Required" ValidationGroup="Register1" ></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>Number of Doors</td>
                <td>
                    <asp:TextBox ID="door" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="door" ForeColor="Red" ErrorMessage="Color is Required" ValidationGroup="Register1" ></asp:RequiredFieldValidator>
                </td>
            </tr>
              <tr>
                <td>Available</td>
                <td>
                    <asp:TextBox ID="ava" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ava" ForeColor="Red" ErrorMessage="Availability is Required" ValidationGroup="Register1" ></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>Seat Capacity</td>
                <td>
                    <asp:TextBox ID="seat" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="seat" ForeColor="Red" ErrorMessage="Seat Capacity is Required" ValidationGroup="Register1" ></asp:RequiredFieldValidator>
                </td>
            </tr>
              <tr>
                <td>Fuel Type</td>
                <td>
                    <asp:TextBox ID="fuel" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="fuel" ForeColor="Red" ErrorMessage="Fuel Type is Required" ValidationGroup="Register1" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Engine</td>
                <td>
                    <asp:TextBox ID="engine" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="engine" ForeColor="Red" ErrorMessage="Engine is Required" ValidationGroup="Register1" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Price per day</td>
                <td>
                    <asp:TextBox ID="price" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="price" ForeColor="Red" ErrorMessage="Price is Required" ValidationGroup="Register1" ></asp:RequiredFieldValidator>
                </td>
            </tr>
            
          
            <tr>
                <td>Model Name</td>
                <td>
                      <asp:DropDownList runat="server" ID="Model">
                            
                        </asp:DropDownList> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorGender" runat="server" ControlToValidate="Model" ForeColor="Red" InitialValue="-1" ErrorMessage="Please select a Make" ValidationGroup ="Register1" ></asp:RequiredFieldValidator>
                </td>
            </tr>
           
                 <%-- <tr>
                <td colspan="2"> 
                    <asp:Button ID ="txtButton" runat="server" Text="Register" ValidationGroup="Register1" />
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
         
          <asp:GridView ID="gvModelDtl" DataKeyNames="VehicleId" AutoGenerateColumns="false"
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
                <asp:TemplateField HeaderText="Registration Number">
                    <ItemTemplate>
                        <asp:Label ID="reg" Text='<%#Eval("RegistrationNumber") %>'
                        runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Color">
                    <ItemTemplate>
                        <asp:Label ID="colors" Text='<%#Eval("Color") %>'
                        runat="server" Width="50px" Height="50px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Availability">
                    <ItemTemplate>
                        <asp:Label ID="availability" Text='<%#Eval("Available") %>'
                        runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Number Of Doors">
                    <ItemTemplate>
                        <asp:Label ID="doors" Text='<%#Eval("NumberOfDoors") %>'
                        runat="server"  />
                    </ItemTemplate>
                </asp:TemplateField>
                 
                <asp:TemplateField HeaderText="Price Per Day">
                    <ItemTemplate>
                        <asp:Label ID="prices" Text='<%#Eval("PricePerDay") %>'
                        runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                    <asp:TemplateField HeaderText="Seat Capacity">
                    <ItemTemplate>
                        <asp:Label ID="seats" Text='<%#Eval("SeatCapacity") %>'
                        runat="server" Width="50px" Height="50px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fuel Type">
                    <ItemTemplate>
                        <asp:Label ID="fuels" Text='<%#Eval("FuelType") %>'
                        runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Engine">
                    <ItemTemplate>
                        <asp:Label ID="engines" Text='<%#Eval("Engine") %>'
                        runat="server"  />
                    </ItemTemplate>
                </asp:TemplateField>

                 <asp:TemplateField HeaderText="Model Name">
                    <ItemTemplate>
                        <asp:Label ID="lblMake2" Text='<%#Eval("ModelName") %>'
                        runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
