<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="ProyectoVD.Personas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <fieldset style="margin-top: 2%">
                <legend>
                    <h1>Agregar persona:</h1>
                </legend>

                <div class="row">
                    <div class="col-xs-6 col-md-4">
                        <button type="button" id="btnInsertar" runat="server" class="form-control" onserverclick="clickInsertar" style="background-color: forestgreen; color: white">Insertar</button>
                    </div>
                    <div class="col-xs-6 col-md-4">
                        <button type="button" id="btnModificar" runat="server" class="form-control" onserverclick="clickModificar" style="background-color: forestgreen; color: white">Modificar</button>
                    </div>
                    <div class="col-xs-6 col-md-4">
                        <button type="button" id="btnEliminar" runat="server" class="form-control" onserverclick="clickEliminar" style="background-color: forestgreen; color: white">Eliminar</button>
                    </div>
                </div>


                <div class="jumbotron well bs-component">
                    <fieldset>
                        <legend>Datos personales</legend>
                        <div class="row">
                            <div class="col-md-4">
                                <h4>Cédula:</h4>
                                <input type="text" id="txtCedula" class="form-control" runat="server">
                            </div>
                            <div class="col-md-4">
                                <h4>Nombre:</h4>
                                <input type="text" id="txtNombre" class="form-control" runat="server">
                            </div>
                            <div class="col-md-4">
                                <h4>Grado académico:</h4>
                                <asp:DropDownList ID="cbxGradoAcademico" runat="server" AutoPostBack="true" CssClass="form-control" ></asp:DropDownList>

                            </div>
                        </div>
                        <div class="row">
                            <h4>Comentarios:</h4>
                            <textarea id="txaDescripcion" class="form-control" rows="5" runat="server"></textarea>
                        </div>
                    </fieldset>

                    <fieldset>
                        <legend style="padding-top: 30px">Notificaciones</legend>
                        <div class="row">
                            <div class="col-md-4">
                                <h4>Teléfonos:</h4>
                                <input id="txtTelefonos" type="text" class="form-control" runat="server">
                            </div>
                            <div class="col-md-4">
                                <h4>Correo:</h4>
                                <input type="text" id="txtCorreo" class="form-control" runat="server">
                            </div>
                            <div class="col-md-4">
                                <h4>Dirección física:</h4>
                                <input type="text" id="txtDireccion" class="form-control" runat="server">
                            </div>
                        </div>
                    </fieldset>
                </div>

                <div class="row">
                    <div class="col-xs-6 col-md-4">
                        <button type="button" id="btnGuardar" runat="server" onserverclick="clickGuardar" class="form-control" style="background-color: forestgreen; color: white">Guardar</button>
                    </div>
                    <div class="col-xs-6 col-md-4">
                        <button type="button" id="btnGuardarAsociar" runat="server" class="form-control" style="background-color: forestgreen; color: white">Guardar y Asociar Numerales</button>
                    </div>
                    <div class="col-xs-6 col-md-4">
                        <button type="button" id="btnCancelar" runat="server" class="form-control" onserverclick="clickCancelar" style="background-color: red; color: white">Cancelar</button>
                    </div>
                </div>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
