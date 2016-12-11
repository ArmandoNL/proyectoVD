<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Numerales.aspx.cs" Inherits="ProyectoVD.Numerales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <fieldset style="margin-top: 2%">
                <legend>
                    <h2>Numerales:</h2>
                </legend>

                <div class="row">
                    <div class="col-xs-6 col-md-4">
                        <button type="button" id="btnInsertar" runat="server" class="form-control" onserverclick="clickInsertar" style="background-color: forestgreen; color: white">Insertar</button>
                    </div>
                    <div class="col-xs-6 col-md-4">
                        <button type="button" id="btnModificar" runat="server" class="form-control" onserverclick="clickModificar" style="background-color: forestgreen; color: white">Modificar</button>
                    </div>
                    <div class="col-xs-6 col-md-4">
                        <button type="button" id="btnEliminar" runat="server" class="form-control" data-toggle="modal" data-target="#modalEliminar" style="background-color: forestgreen; color: white">Eliminar</button>
                    </div>
                </div>

                <div class="jumbotron well bs-component">

                    <legend>
                        <h4>Codigo de concurso:</h4>
                    </legend>
                    <input type="text" id="txtConcurso" class="form-control" runat="server">
                    <button type="button" id="btnGuardarConcurso" runat="server" class="form-control" style="width: 27%">Guardar</button>


                    <legend style="margin-top: 30px">
                        <h4>Unidad académica:</h4>
                    </legend>
                    <asp:DropDownList ID="cbxUA" runat="server" AutoPostBack="true" CssClass="form-control" Width="30%"></asp:DropDownList>

                    <legend style="margin-top: 30px">
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
                                <option>En Espera</option>
                                <option>Adjudicado</option>
                                <option>Desierto</option>
                            </select>
                        </div>
                    </div>
                    <h4>Descripción</h4>
                    <textarea id="txaDescripcion" class="form-control" rows="5" runat="server"></textarea>
                </div>

                <div class="row">
                        <div class="col-xs-6 col-md-4">
                        </div>
                        <div class="col-xs-6 col-md-4">
                            <button type="button" id="btnAceptar" runat="server" class="form-control" style="background-color: forestgreen; color: white">Guardar</button>
                        </div>
                        <div class="col-xs-6 col-md-4">
                            <button type="button" id="btnCancelar" runat="server" class="form-control" data-toggle="modal" data-target="#modalcancelar" style="background-color: red; color: white">Cancelar</button>
                        </div>

                        <div class="modal fade" id="modalcancelar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title" id="myModalLabel">Cancelar Operación</h4>
                                    </div>
                                    <div class="modal-body">
                                        <p>¿Desea Cancelar? Es una operacion irreversible</p>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-success" runat="server" onserverclick="clickCancelar" data-dismiss="modal">Aceptar</button>
                                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                <div class="modal fade" id="modalEliminar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabel1">Eliminar numeral</h4>
                        </div>
                        <div class="modal-body">
                            <p>¿Seguro que desea Eliminar el numeral? Esta es una operacion irreversible.</p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-success" runat="server" onserverclick="clickEliminar" data-dismiss="modal">Aceptar</button>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>

            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
