<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsociarNumerales.aspx.cs" Inherits="ProyectoVD.AsociarNumerales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <legend>
                <h1>Asociar Numerales:</h1>
            </legend>
            <div class="jumbotron well bs-component">

                <fieldset>
                    <legend style="padding-top: 30px">Agregar numerales</legend>

                    <input type="text" id="txtConcurso" class="form-control" runat="server">
                    <button type="button" id="btnBuscarNumerales" runat="server" class="form-control" onserverclick="clickBuscarNumerales" style="width: 24%">Buscar</button>

                    <asp:GridView ID="grvNumerales" runat="server" AllowSorting="true" Style="font: 16px arial; color: grey; border-color: gainsboro; margin-top: 2%; margin-bottom: 2%">

                        <SelectedRowStyle BackColor="#7BC143"
                            ForeColor="Black"
                            Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnConcursar" ToolTip="En Espera" runat="server" OnClick="clickConcursarModal" class="btn btn-default"><i class="glyphicon glyphicon-time"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnAdjudicar" ToolTip="Adjudicado" runat="server" OnClick="clickAdjudicarModal" class="btn btn-default"><i class="glyphicon glyphicon-ok"></i></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>

                </fieldset>
            </div>

            <div class="row">
                <div class="col-xs-6 col-md-4">
                </div>
                <div class="col-xs-6 col-md-4">
                    <button type="button" id="btnInsertarPersona" onserverclick="clickInsertarPersona" runat="server" class="form-control" style="background-color: forestgreen; color: white">Agregar nueva persona</button>
                </div>
                <div class="col-xs-6 col-md-4">
                    <button type="button" id="btnCancelar" runat="server" class="form-control" data-toggle="modal" data-target="#modalcancelar" style="background-color: red; color: white">Terminar</button>
                </div>

                <div class="modal fade" id="modalcancelar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title" id="myModalLabel">Cancelar Operación</h4>
                            </div>
                            <div class="modal-body">
                                <p>¿Desea Terminar? Es una operacion irreversible</p>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-success" runat="server" onserverclick="clickCancelar" data-dismiss="modal">Aceptar</button>
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="modal fade" id="modalAsociar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModal">Asociar numeral:</h4>
                        </div>
                        <div class="modal-body">
                            <p>Inserte la puntuación asignada.</p>
                            <div class="row">
                                <div class="col-md-4">
                                    <h4>Puntaje UA:</h4>
                                    <input type="text" id="txtPuntajeUA" runat="server" class="form-control">
                                </div>
                                <div class="col-md-4">
                                    <h4>Puntaje real:</h4>
                                    <input type="text" id="txtPuntajeReal" runat="server" class="form-control">
                                </div>

                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-success" runat="server" onserverclick="clickConcursar" data-dismiss="modal">Aceptar</button>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>


            <div class="modal fade" id="modalAdjudicar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModal2">Asignar numeral:</h4>
                        </div>
                        <div class="modal-body">
                            <p>Inserte la información solicitada para asociar el numeral.</p>

                            <div class="row">

                                <div class="col-md-4">
                                    <h4>Constancia de nombramiento:</h4>
                                    <input type="text" id="txtConstancia" runat="server" class="form-control">
                                </div>
                                <div class="col-md-4">
                                    <h4>Fecha de resultado:</h4>
                                    <input type="text" id="txtFecha" runat="server" class="form-control" placeholder="Formato: mm/dd/aaaa">
                                    
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-success" runat="server" onserverclick="clickAdjudicar" data-dismiss="modal">Aceptar</button>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
