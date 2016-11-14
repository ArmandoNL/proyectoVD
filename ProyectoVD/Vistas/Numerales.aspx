<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Numerales.aspx.cs" Inherits="ProyectoVD.Numerales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Agregar numeral:</h1>
    <div class="jumbotron">

        <h4>Codigo de concurso:</h4>
        <input type="text" id="txtConcurso" class="form-control" runat="server">

        <h4>Unidad académica:</h4>

        <asp:DropDownList ID="cbxUA" runat="server" AutoPostBack="true" CssClass="form-control" Width="30%"></asp:DropDownList>
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
                    <option>Adjudicado</option>
                    <option>Desierto</option>
                </select>
            </div>
        </div>
        <h4>Descripción</h4>
        <textarea id="txaDescripcion" class="form-control" rows="3" runat="server"></textarea>

        <input type="submit" class="btn btn-success" id="btnAceptar" value="Aceptar" runat="server" onserverclick="insertarNumeral" />
        <input type="button" class="btn btn-danger" id="Button1" value="Cancelar" runat="server" />
    </div>


</asp:Content>
