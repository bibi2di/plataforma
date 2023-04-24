<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="FormularioFuncionesADM.aspx.vb" Inherits="ApliWebPlataforma.FormularioFuncionesADM" %>
   <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
       <style type="text/css">
        .style2
        {
            width: 66px;
        }
        .style3
        {
            text-align: justify;
            
        }
        .style12
        {
            width: 10px;
        }
        .style20
        {
            width: 202px;
        }
        .style23
        {
            width: 73px;
        }
        .style24
        {
            width: 309px;
           
        }
        .style27
        {
            width: 320px;
        }
        .style28
        {
            width: 174px;
        }
        .style31
        {
            width: 158px;
              color: #FF0000;
          }
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
            
            color:Black;
            font-size:medium;
              height: 426px;
          }
          .style102
          {
              text-decoration: underline;
              font-weight: bold;
              font-size: large;
          }
          .style103
          {
              width: 320px;
              color: #FF0000;
          }
          .style104
          {
              width: 309px;
              color: #FF0000;
          }
           .auto-style1 {
               width: 202px;
               height: 59px;
           }
           .auto-style2 {
               width: 320px;
               height: 59px;
           }
           .auto-style3 {
               width: 174px;
               height: 59px;
           }
           .auto-style4 {
               height: 59px;
           }
           .auto-style5 {
               height: 63px;
           }
           .auto-style6 {
               color: Black;
               font-size: medium;
               height: 2688px;
               width: 942px;
           }
    </style>
 </asp:Content>
   

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="header"><h1 class="style37">Funciones ADMINISTRADOR</h1></div>
    <div class="auto-style6">
    
        <br />

        <table >
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
                    Realice todas las funciones que quiera . Rellene los datos oportunos y pulse el 
                    botón.<br />
                    </td>
            </tr>
        </table>
            <br />
            <table >
                <tr>
                    <td class="style32">
                        &nbsp;</td>
                    <td class="style102">
                        Cambiar estado de un usuario</td>
                </tr>
        </table>
        <table >
            <tr>
                <td class="auto-style1">
                    </td>
                <td class="auto-style2" >
                    CCuenta del usuario a 
                    cambiar de estado</td>
                <td class="auto-style3">
                    <asp:DropDownList ID="nombreLogin" runat="server" DataSourceID="logins" DataTextField="USUARIOLOGIN" DataValueField="USUARIOLOGIN">
                    </asp:DropDownList>
                    <asp:AccessDataSource ID="logins" runat="server" DataFile="C:\TEMP\Plataforma_Larrazabal_Leon.mdb" SelectCommand="SELECT USUARIOLOGIN FROM USUARIOREG"></asp:AccessDataSource>
                </td>
                <td class="auto-style4">
                    <asp:Button ID="cambiarEstadoSocio" runat="server" Text="Cambiar estado" />
                </td>
            </tr>
            <tr>
                <td class="style20">
                    &nbsp;</td>
                <td class="style103" >
                    <asp:DataList ID="DataList1" runat="server" DataKeyField="usuariologin" DataSourceID="usuarios">
                        <ItemTemplate>
                            usuariologin:
                            <asp:Label ID="usuariologinLabel" runat="server" Text='<%# Eval("usuariologin") %>' />
                            <br />
                            nombre_apellido:
                            <asp:Label ID="nombre_apellidoLabel" runat="server" Text='<%# Eval("nombre_apellido") %>' />
                            <br />
                            direccion:
                            <asp:Label ID="direccionLabel" runat="server" Text='<%# Eval("direccion") %>' />
                            <br />
                            credito:
                            <asp:Label ID="creditoLabel" runat="server" Text='<%# Eval("credito") %>' />
                            <br />
                            Fecha_Hora_Alta:
                            <asp:Label ID="Fecha_Hora_AltaLabel" runat="server" Text='<%# Eval("Fecha_Hora_Alta") %>' />
                            <br />
                            Estado:
                            <asp:Label ID="EstadoLabel" runat="server" Text='<%# Eval("Estado") %>' />
                            <br />
<br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:AccessDataSource ID="usuarios" runat="server" DataFile="C:\TEMP\Plataforma_Larrazabal_Leon.mdb" SelectCommand="SELECT * FROM USUARIOREG WHERE USUARIOLOGIN=?">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="nombreLogin" Name="?" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:AccessDataSource>
                </td>
                <td class="style28">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="mostrarDatosSocio" runat="server" Text="Mostrar/Ocultar usuario" />
                </td>
            </tr>
        </table>
             
               <br />
        <table >
            <tr>
                <td class="style32">
                    &nbsp;</td>
                <td class="style102">
                    Dar de alta una película</td>
            </tr>
        </table>
        <table class="auto-style5" >
            <tr>
                <td class="style20">
                    &nbsp;</td>
                <td class="style12">
                    &nbsp;</td>
                <td class="style24">
                    Código de la película a dar de alta</td>
                <td class="style31">
                    <asp:TextBox ID="codPeliculaAlta" runat="server"  
                        ToolTip="Introduzca el código de la película a dar de alta" SkinID="-1"></asp:TextBox>
                </td>
                <td class="style23">
                    <asp:Button ID="DarDeAltaPeli" runat="server" Text="Dar de alta película" />
                    </td>
            </tr>
            <tr>
                <td class="style20">
                    &nbsp;</td>
                <td class="style12">
                    &nbsp;</td>
                <td class="style104">
                    <asp:TextBox ID="tituloPelicula" runat="server"></asp:TextBox>
&nbsp;&nbsp; Título</td>
                <td class="style31">
                    &nbsp;</td>
                <td class="style23">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style20">
                    &nbsp;</td>
                <td class="style12">
                    &nbsp;</td>
                <td class="style104">
                    <asp:TextBox ID="precioPelicula" runat="server"></asp:TextBox>
&nbsp;&nbsp; Precio</td>
                <td class="style31">
                    &nbsp;</td>
                <td class="style23">
                    &nbsp;</td>
            </tr>
            </table>
                      <br />
        <table >
            <tr>
                <td class="style32">
                    &nbsp;</td>
                <td class="style102">
                    Dar de baja una película</td>
            </tr>
        </table>
        <table >
            <tr>
                <td class="style20">
                    &nbsp;</td>
                <td class="style12">
                    &nbsp;</td>
                <td class="style24">
                    Código de la película a dar de baja</td>
                <td class="auto-style31">
                    <asp:DropDownList ID="codigoB" runat="server" DataSourceID="codigos" DataTextField="CODIGO" DataValueField="CODIGO">
                    </asp:DropDownList>
                    <asp:TextBox ID="codPeliculaBaja" runat="server"></asp:TextBox>
                    <asp:AccessDataSource ID="codigos" runat="server" DataFile="C:\TEMP\Plataforma_Larrazabal_Leon.mdb" SelectCommand="SELECT CODIGO FROM PELICULA WHERE ESTADO='Disponible'"></asp:AccessDataSource>
                </td>
                <td class="style23">
                    <asp:Button ID="DarDeBajaPeli" runat="server" Text="Dar de baja esta película" />
                    </td>
            </tr>
            <tr>
                <td class="style20">
                    &nbsp;</td>
                <td class="style12">
                    &nbsp;</td>
                <td class="style104">
                    <asp:DataList ID="DataList2" runat="server" DataKeyField="codigo" DataSourceID="datosPelicula">
                        <ItemTemplate>
                            codigo:
                            <asp:Label ID="codigoLabel" runat="server" Text='<%# Eval("codigo") %>' />
                            <br />
                            titulo:
                            <asp:Label ID="tituloLabel" runat="server" Text='<%# Eval("titulo") %>' />
                            <br />
                            estado:
                            <asp:Label ID="estadoLabel" runat="server" Text='<%# Eval("estado") %>' />
                            <br />
                            precio:
                            <asp:Label ID="precioLabel" runat="server" Text='<%# Eval("precio") %>' />
                            <br />
                            fecha_adq:
                            <asp:Label ID="fecha_adqLabel" runat="server" Text='<%# Eval("fecha_adq") %>' />
                            <br />
                            fecha_ret:
                            <asp:Label ID="fecha_retLabel" runat="server" Text='<%# Eval("fecha_ret") %>' />
                            <br />
<br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:AccessDataSource ID="datosPelicula" runat="server" DataFile="C:\TEMP\Plataforma_Larrazabal_Leon.mdb" SelectCommand="SELECT * FROM PELICULA WHERE CODIGO = ?">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="codigoB" Name="?" PropertyName="SelectedValue" />
                        </SelectParameters>
                    </asp:AccessDataSource>
                </td>
                <td class="style31">
                    &nbsp;</td>
                <td class="style23">
                    <asp:Button ID="mostrarDatosPeli" runat="server" 
                        Text="Mostrar/Ocultar película" />
                </td>
            </tr>
            </table>
    <table>
    <asp:Button ID="VolverPrincipal" runat="server" Text="Volver a la Página Principal" />
    </table>
    </div>
</asp:Content>
