﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsociarNumerales.aspx.cs" Inherits="ProyectoVD.AsociarNumerales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <legend>
                <h1>Asociar Numerales:</h1>
            </legend>
            <div class="jumbotron well bs-component">
                <fieldset>
                    <legend style="padding-top: 30px">Información administrativa</legend>
                    <div class="row">
                        <div class="col-md-4">
                            <h4>Puntaje Unidad Académica:</h4>
                            <input type="text" id="txtPuntajeUA" class="form-control">
                        </div>
                        <div class="col-md-4">
                            <h4>Puntaje real:</h4>
                            <input type="text" id="txtPuntajeReal" class="form-control">
                        </div>

                        <div class="col-md-4">
                            <h4>Constancia de nombramiento:</h4>
                            <input type="text" id="txtConstancia" class="form-control">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <h4>Fecha de resultado:</h4>

                            <input runat="server" id="txtFecha" class="form-control" onselect="fechaDeEntradaCalendario_SelectionChanged" disabled />

                            <input id="fechaDeEntrada" value="Seleccione una fecha" style="width: 76%" class="form-control" type="button" runat="server" onserverclick="fechaDeEntrada_ServerClick" />

                            <asp:Calendar ID="fechaDeEntradaCalendario" runat="server" BorderStyle="Dashed" ForeColor="#7BC143" Height="80px" Width="100px" BorderWidth="1px" Visible="false" OnSelectionChanged="fechaDeEntradaCalendario_SelectionChanged">
                                <DayHeaderStyle ForeColor="#333333" Wrap="True" />
                                <DayStyle ForeColor="Black" />
                                <NextPrevStyle ForeColor="Black" />
                                <TitleStyle BackColor="#7BC143" ForeColor="#333333" />
                            </asp:Calendar>
                        </div>
                    </div>

                </fieldset>

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
            </div>
            <div class="row">
                <div class="col-xs-6 col-md-4">
                    <button type="button" id="btnGuardar" runat="server" class="form-control" style="background-color: forestgreen; color: white">Guardar</button>
                </div>
                <div class="col-xs-6 col-md-4">
                    <button type="button" id="btnGuardarInsertar" runat="server" class="form-control" style="background-color: forestgreen; color: white">Guardar y Agregar Persona</button>
                </div>
                <div class="col-xs-6 col-md-4">
                    <button type="button" id="btnCancelar" runat="server" class="form-control" style="background-color:red; color: white">Cancelar</button>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>