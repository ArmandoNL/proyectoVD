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
                                <input type="text" class="form-control">
                            </div>
                            <div class="col-md-4">
                                <h4>Grado académico:</h4>
                                <select class="form-control">
                                    <option>Licenciatura</option>
                                    <option>Maestría académica</option>
                                    <option>Maestría profesional</option>
                                    <option>Doctorado</option>
                                </select>
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
                                <input id="txttelefonos" type="text" class="form-control">
                            </div>
                            <div class="col-md-4">
                                <h4>Correo:</h4>
                                <input type="text" class="form-control">
                            </div>
                            <div class="col-md-4">
                                <h4>Dirección física:</h4>
                                <input type="text" class="form-control">
                            </div>
                        </div>
                    </fieldset>

                    <fieldset>
                        <legend style="padding-top: 30px">Información administrativa</legend>
                        <div class="row">
                            <div class="col-md-4">
                                <h4>Puntaje Unidad Académica:</h4>
                                <input type="text" class="form-control">
                            </div>
                            <div class="col-md-4">
                                <h4>Puntaje real:</h4>
                                <input type="text" class="form-control">
                            </div>
                            <div class="col-md-4">
                                <h4>Fecha de resultado:</h4>
                                <input type="text" class="form-control">
                            </div>
                            <div class="col-md-4">
                                <h4>Constancia de nombramiento:</h4>
                                <input type="text" class="form-control">
                            </div>
                        </div>
                    </fieldset>

                    <fieldset>
                        <legend style="padding-top: 30px">Agregar numerales</legend>

                        <input type="text" id="txtConcurso" class="form-control" runat="server">
                        <button type="button" id="btnBuscarNumerales" runat="server" class="form-control" onserverclick="clickBuscarNumerales" style="width: 27%">Buscar</button>

                        <asp:GridView ID="grvNumerales" runat="server" AllowSorting="true" style="font:16px arial;color:grey;border-color:gainsboro;margin-top:2%; margin-bottom:2%">

                            <SelectedRowStyle BackColor="#7BC143"
                                ForeColor="Black"
                                Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnConcursar" ToolTip="En Espera" runat="server" OnClick="clickConcursar" class="btn btn-default"><i class="glyphicon glyphicon-time"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnAdjudicar" ToolTip="Adjudicado" runat="server" OnClick="clickAdjudicar" class="btn btn-default"><i class="glyphicon glyphicon-ok"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>

                    </fieldset>



                    <input type="submit" class="btn btn-success" id="btnAceptar" value="Aceptar" runat="server" onserverclick="clickAceptar" />
                    <input type="button" class="btn btn-danger" id="Button1" value="Cancelar" runat="server" onserverclick="clickCancelar" />
                </div>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
