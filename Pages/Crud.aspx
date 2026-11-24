<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Crud.aspx.cs" Inherits="CRUD_ASP.Pages.Crud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center">
        <div class="col-lg-7 col-xl-6">
            <div class="card">
                <div class="card-header py-3">
                    <h4 class="mb-0">
                        <i class="bi bi-person-vcard me-2 text-primary"></i>
                        <asp:Label ID="lblTitulo" runat="server" Text="Nuevo usuario" />
                    </h4>
                </div>

                <div class="card-body p-4">

                    <div class="mb-3">
                        <label class="form-label fw-semibold">Nombre</label>
                        <div class="input-group">
                            <span class="input-group-text"><i class="bi bi-person"></i></span>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"
                                placeholder="Nombre completo" MaxLength="150" required="required" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-4 mb-3">
                            <label class="form-label fw-semibold">Edad</label>
                            <div class="input-group">
                                <span class="input-group-text"><i class="bi bi-123"></i></span>
                                <asp:TextBox ID="txtEdad" runat="server" TextMode="Number" CssClass="form-control"
                                    min="0" max="120" required="required" />
                            </div>
                        </div>

                        <div class="col-md-8 mb-3">
                            <label class="form-label fw-semibold">Fecha de nacimiento</label>
                            <div class="input-group">
                                <span class="input-group-text"><i class="bi bi-calendar-event"></i></span>
                                <asp:TextBox ID="txtFechaNac" runat="server" TextMode="Date" CssClass="form-control"
                                    required="required" />
                            </div>
                        </div>
                    </div>

                    <div class="mb-3">
                        <label class="form-label fw-semibold">Correo</label>
                        <div class="input-group">
                            <span class="input-group-text"><i class="bi bi-envelope"></i></span>
                            <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" CssClass="form-control"
                                placeholder="correo@ejemplo.com" MaxLength="150" required="required" />
                        </div>
                    </div>

                    <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-danger d-block msg-error" />

                    <div class="d-flex gap-2 justify-content-end pt-2">
                        <asp:Button ID="btnVolver" runat="server" Text="Volver"
                            CssClass="btn btn-outline-secondary" OnClick="BtnVolver_Click"
                            CausesValidation="false" formnovalidate="formnovalidate" />
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar"
                            CssClass="btn btn-success px-4" OnClick="BtnGuardar_Click" />
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar"
                            CssClass="btn btn-warning px-4" OnClick="BtnActualizar_Click" />
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>