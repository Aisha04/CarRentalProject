<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Client.Master" CodeBehind="cars.aspx.vb" Inherits="CarsRental.cars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
   
        <asp:Repeater ID="rptCustomers" runat="server">
    <HeaderTemplate>
        <table >
            <%--<div>--%>
               <%-- <div scope="col" style="width: 80px">
                    Model Id
                </div>--%>
                <%--<div scope="col" style="width: 120px">
                    Model Name
                </div>--%>
               <%-- <div scope="col" style="width: 100px">
                                        Image
                </div>--%>

              <%--  <th scope="col" style="width: 120px">
                    Make Name
                </th>
                <th scope="col" style="width: 120px">
                    Type Name
                </th>--%>

            <%--</div>--%>

    </HeaderTemplate>
    <ItemTemplate>
        
           <%-- <div>
                 <div scope="col" style="width: 80px">
                    Model Id
                </div>
                <div>
                <asp:Label ID="lblModelId" runat="server" Text='<%# Eval("ModelId") %>' />
            </div>
                </div>--%>
          
         
        <%--   <%-- <td>
                <asp:Label ID="lblMakeName" runat="server" Text='<%# Eval("MakeName") %>' />
            </td>
             <td>
                <asp:Label ID="lblTypeName" runat="server" Text='<%# Eval("TypesName") %>' />--%>
            <%--</td--%>
            <th>
             <div style="width: 100px">
                                        Image
                </div>
                  <div>
                <asp:Image ID="Image" runat="server" ImageUrl='<%# Eval("Images") %>' />
            </div>
</th>
              <th>
                 <div style="width: 120px">
                    Model Name
                </div>
            <div>
                <asp:Label ID="lblModelName" runat="server" Text='<%# Eval("ModelName") %>' />
            </div>
             </th> 
        
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>


</div>
</asp:Content>
