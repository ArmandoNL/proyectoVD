<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Numerales.aspx.cs" Inherits="ProyectoVD.Numerales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <legend>
                <h2>Numerales:</h2>
            </legend>

            <div class="row">
                <div class="col-xs-6 col-md-4">
                    <button type="button" id="btnInsertar" runat="server" class="form-control" style="background-color: forestgreen; color: white">Insertar</button>
                </div>
                <div class="col-xs-6 col-md-4">
                    <button type="button" id="btnModificar" runat="server" class="form-control" style="background-color: forestgreen; color: white">Modificar</button>
                </div>
                <div class="col-xs-6 col-md-4">
                    <button type="button" id="btnEliminar" runat="server" class="form-control" style="background-color: forestgreen; color: white">Eliminar</button>
                </div>
            </div>

            <div class="jumbotron well bs-component">

                <legend>
                    <h4>Codigo de concurso:</h4>
                </legend>
                <asp:TextBox ID="txtprueba" Columns="2" MaxLength="3" Text="1" runat="server"/>
                <input type="text" id="txtConcurso" class="form-control" runat="server">
                <button type="button" id="btnGuardarConcurso" runat="server" class="form-control" style="width: 27%">Guardar</button>


                <legend style="margin-top:30px">
                    <h4>Unidad académica:</h4>
                </legend>
                <asp:DropDownList ID="cbxUA" runat="server" AutoPostBack="true" CssClass="form-control" Width="30%"></asp:DropDownList>

                <legend style="margin-top:30px">
                    <h4>Información del numeral:</h4>
                </legend>

                <div class="row">
                    <div class="col-md-4">
                        <h4>Código:</h4>
                        <input type="text" id="txtCodNum" class="form-control" runat="server">
                    </div>
                    <div class="col-md-4">
                        <h4>Jornada:</h4>
                        <input type="text" id="txtJornada" class="form-control" runat="server" placeholder="Inserte una fracción">
                    </div>
                    <div class="col-md-4">
                        <h4>Estado:</h4>
                        <select class="form-control" id="cbxEstado" runat="server">
                            <option>Pendiente</option>
                            <option>Adjudicado</option>
                            <option>Desierto</option>
                        </select>
                    </div>
                </div>
                <h4>Descripción</h4>
                <textarea id="txaDescripcion" class="form-control" rows="3" runat="server"></textarea>

                <input type="submit" class="btn btn-success" id="btnAceptar" value="Aceptar" runat="server" onserverclick="clickAceptar" />
                <input type="button" class="btn btn-danger" id="Button1" value="Cancelar" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
