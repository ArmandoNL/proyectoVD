<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ProyectoVD.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Consultar Numerales</h1>
    <div class="jumbotron">
        <div class="row">
            <div class="col-md-6">
                <h2>Reporte 1: Verificar tiempos.</h2>
                <p style="font: 16px arial; color: grey; margin-top: 4%; margin-bottom: 4%">
                    <asp:RadioButton ID="rdbUAyC" Text="UA y Concurso" Checked="True" GroupName="RadioGroup1" runat="server" />
                    <asp:RadioButton ID="rdbUAyA" Text="UA y Año" Checked="false" GroupName="RadioGroup1" runat="server" />
                    <asp:RadioButton ID="rdbCoA" Text="Concurso o Año" Checked="false" GroupName="RadioGroup1" runat="server" />
                </p>
                <p>
                    <h4>Unidad Académica (UA):</h4>
                    <asp:DropDownList ID="cbxUA1" runat="server" AutoPostBack="true" CssClass="form-control" Width="30%"></asp:DropDownList>
                    <h4>Concurso:</h4>
                    <input id="txtConcurso1" type="text" class="form-control" runat="server" required="required" title="Por favor, inserte un concurso." />
                    <h4>Año:</h4>
                    <input id="txtAnno" type="text" class="form-control" runat="server" required="required" title="Por favor, inserte un concurso." />
                </p>
                <p>
                    <input type="button" class="btn btn-default" id="btnBuscar1" value="Buscar" runat="server" onserverclick="clickBuscar1" />
                </p>
            </div>
            <div class="col-md-6">
                <h2>Reporte 2: Verificar personas.</h2>
                <p>
                    <h4>Unidad Académica:</h4>
                    <asp:DropDownList ID="cbxUA2" runat="server" AutoPostBack="true" CssClass="form-control" Width="30%"></asp:DropDownList>
                    <h4>Concurso:</h4>
                    <input id="txtConcurso2" type="text" class="form-control" runat="server" required="required" title="Por favor, inserte un concurso." />
                </p>
                <p>
                    <input type="button" class="btn btn-default" id="btnBuscar2" value="Buscar" runat="server" onserverclick="clickBuscar2" />
                </p>
            </div>
        </div>
    </div>


    <p id="parrafo" visible="false">
        <asp:Label runat="server" ID="lblOfrecido" visible="false" ><H4>Ofrecido:</H4></asp:Label>
        <input id="txtOfrecido" type="text" class="form-control" runat="server" visible="false" />
        <asp:Label runat="server" ID="lblAdjudicado" visible="false" ><H4>Adjudicado:</H4></asp:Label>
        <input id="txtAdjudicado" type="text" class="form-control" runat="server" visible="false" />
        <asp:Label runat="server" ID="lblNoAdjudicado" visible="false" ><H4>No Adjudicado:</H4></asp:Label>
        <input id="txtNoAdjudicado" type="text" class="form-control" runat="server" visible="false" />
        <asp:Label runat="server" ID="lblEnEspera" visible="false" ><H4>En Espera:</H4></asp:Label>
        <input id="txtEnEspera" type="text" class="form-control" runat="server" visible="false" />
    </p>

    <asp:GridView ID="grvReporte" runat="server" AllowPaging="true" AllowSorting="true" Style="font: 16px arial; color: grey; border-color: gainsboro; margin-top: 2%; margin-bottom: 2%">

        <SelectedRowStyle BackColor="#7BC143"
            ForeColor="Black"
            Font-Bold="true" BorderStyle="Dotted" BorderWidth="1px" />

    </asp:GridView>

</asp:Content>
