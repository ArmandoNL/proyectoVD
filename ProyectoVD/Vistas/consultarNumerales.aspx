﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarNumerales.aspx.cs" Inherits="ProyectoVD.consultarNumerales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h1>Consultar Numerales</h1>
            <div class="jumbotron">
                <div class="row">
                    <div class="col-md-8">
                        <h2>Modificar o Eliminar</h2>
                        <p>
                            <input id="txtBuscar" type="text" class="form-control" runat="server" required="required" title="Por favor, inserte un concurso." />
                        </p>
                    </div>
                </div>
            </div>


            <asp:GridView ID="grvNumerales" runat="server" AllowPaging="true" AllowSorting="true" Style="font: 16px arial; color: grey; border-color: gainsboro; margin-top: 2%; margin-bottom: 2%">

                <SelectedRowStyle BackColor="#7BC143"
                    ForeColor="Black"
                    Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnConsultar" ToolTip="Consultar" runat="server" OnClick="clickConsultar" class="btn btn-default"><i class="glyphicon glyphicon-search"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnModificar" ToolTip="Modificar" runat="server" OnClick="clickModificar" class="btn btn-default"><i class="glyphicon glyphicon-pencil"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEliminar" ToolTip="Eliminar" runat="server" OnClick="clickEliminar" class="btn btn-default"><i class="glyphicon glyphicon-trash"></i></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>


            <div class="modal fade" id="modalEliminar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" id="myModalLabel">Eliminar numeral</h4>
                        </div>
                        <div class="modal-body">
                            <p>¿Seguro que desea Eliminar el numeral? Esta es una operacion irreversible.</p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-success" runat="server" onserverclick="clickEliminarNumeralBD" data-dismiss="modal">Aceptar</button>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
