<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CRUD_ASP.Pages.Index" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card">
        <div class="card-header d-flex justify-content-between align-items-center py-3">
            <h4 class="mb-0"><i class="bi bi-people-fill me-2 text-primary"></i>Usuarios</h4>
            <a href="Crud.aspx" class="btn btn-primary">
                <i class="bi bi-plus-lg me-1"></i>Nuevo usuario
            </a>
        </div>

        <div class="card-body p-0">
            <div class="table-responsive">
                <asp:GridView ID="gvusuarios" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-hover mb-0" GridLines="None"
                    HeaderStyle-CssClass="table-light text-uppercase small text-muted"
                    EmptyDataText="No hay usuarios registrados."
                    EmptyDataRowStyle-CssClass="text-center text-muted p-4">
                    <Columns>
                        <asp:BoundField DataField="idUsuario" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-CssClass="fw-semibold" />
                        <asp:BoundField DataField="Edad" HeaderText="Edad" />
                        <asp:BoundField DataField="Correo" HeaderText="Correo" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de nacimiento"
                            DataFormatString="{0:dd/MM/yyyy}" />

                        <asp:TemplateField HeaderText="Acciones" ItemStyle-CssClass="text-end text-nowrap"
                            HeaderStyle-CssClass="text-end">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnRead" runat="server"
                                    Text='<i class="bi bi-eye"></i>' ToolTip="Ver"
                                    CssClass="btn btn-icon btn-outline-info"
                                    CommandName="Leer" CommandArgument='<%# Eval("idUsuario") %>'
                                    OnClick="BtnRead_Click" />
                                <asp:LinkButton ID="btnUpdate" runat="server"
                                    Text='<i class="bi bi-pencil-square"></i>' ToolTip="Editar"
                                    CssClass="btn btn-icon btn-outline-warning"
                                    CommandName="Actualizar" CommandArgument='<%# Eval("idUsuario") %>'
                                    OnClick="BtnUpdate_Click" />
                                <asp:LinkButton ID="btnDelete" runat="server"
                                    Text='<i class="bi bi-trash3"></i>' ToolTip="Eliminar"
                                    CssClass="btn btn-icon btn-outline-danger"
                                    CommandName="Eliminar" CommandArgument='<%# Eval("idUsuario") %>'
                                    OnClick="BtnDelete_Click"
                                    OnClientClick="return confirm('¿Seguro que deseas eliminar este usuario?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>