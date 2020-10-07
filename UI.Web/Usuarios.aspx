<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios"
    MasterPageFile="~/Site.master" %>

<asp:Content ID="ContentUsuarios" ContentPlaceHolderID="bodyContentPlaceHolder" Runat="Server">
    <asp:Panel runat="server" ID="gridPanel">
        <asp:GridView runat="server" ID="gridView" AutoGenerateColumns="false"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                <asp:BoundField HeaderText="Apellido" DataField="Apellido"/>
                <asp:BoundField HeaderText="EMail" DataField="EMail"/>
                <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario"/>
                <asp:BoundField HeaderText="Habilitado" DataField="Habilitado"/>
                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True"/>
            </Columns>
        </asp:GridView>
    </asp:Panel> 
    <asp:Panel runat="server" ID ="formPanel" Visible="false">
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
        <asp:Checkbox ID="habilitadoCheckBox" runat="server"></asp:Checkbox>
        <br />
        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="claveTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
        <asp:TextBox ID="repetirClaveTextBox" runat="server"></asp:TextBox>
        <br />
    </asp:Panel> 
    <asp:Panel runat="server" ID="girdActionsPanel">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click1">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server">Nuevo</asp:LinkButton>
    </asp:Panel> 

    <asp:Panel runat="server" ID="fromActionsPanel">
        <asp:LinkButton ID="aceptarLinkButton" runat="server">Aceptar</asp:LinkButton>
        <asp:LinkButton ID="cancelarLinkButton" runat="server">Cancelar</asp:LinkButton>
    </asp:Panel>
</asp:Content>
