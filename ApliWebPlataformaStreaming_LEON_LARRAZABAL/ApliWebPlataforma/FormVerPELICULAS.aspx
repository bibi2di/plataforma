<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormVerPELICULAS.aspx.vb" Inherits="ApliWebPlataforma.FormVerPELICULAS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
          .style32
        {
            width: 185px;
        }
        .style37
        {
            font-size: large;
        }
                .style100
        {
            height: 525px;
            color:Black;
            font-size:medium;
        }
          .style102
          {
              text-decoration: underline;
              font-weight: bold;
              font-size: large;
        width: 477px;
    }
    .style103
    {
        font-weight: bold;
        font-size: large;
        width: 477px;
        color: red;
    }
        .auto-style1 {
            width: 185px;
            height: 28px;
        }
        .auto-style2 {
            font-weight: bold;
            font-size: large;
            width: 477px;
            color: red;
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header"><h1 class="style37">Catálogo PELÍCULAS</h1></div>
 <div class="style100">
 <br />
            <table >
             <tr>
                    <td class="style32">
                        &nbsp;</td>
                    <td class="style102">
                        <asp:Label ID="estrenos" runat="server" Text="ESTRENOS QUINCENA (fecha de hoy = )"></asp:Label>
                        </td>
                </tr>
             <tr>
                    <td class="auto-style1">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="TITULOS2">
                            <Columns>
                                <asp:BoundField DataField="titulo" HeaderText="titulo" SortExpression="titulo" />
                            </Columns>
                        </asp:GridView>
                        <asp:AccessDataSource ID="TITULOS2" runat="server" DataFile="C:\TEMP\Database2.mdb" SelectCommand="SELECT titulo FROM PELICULA WHERE (estado = 'Disponible')"></asp:AccessDataSource>
                        <asp:AccessDataSource ID="titulos" runat="server"></asp:AccessDataSource>
                    </td>
                    <td class="auto-style2">
                        <asp:GridView ID="GridView2" runat="server" DataSourceID="estrenosquincena">
                        </asp:GridView>
                        <asp:AccessDataSource ID="estrenosquincena" runat="server"></asp:AccessDataSource>
                    </td>
                </tr>
             <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="Nombre" runat="server"></asp:TextBox>
                        <asp:Button ID="Mostrar" runat="server" Text="Mostrar saludo" />
                    </td>
                </tr>
             <tr>
                    <td class="auto-style1">
                        &nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="Mensaje" runat="server"></asp:Label>
                    </td>
                </tr>
                </table>
 </div>
</asp:Content>
