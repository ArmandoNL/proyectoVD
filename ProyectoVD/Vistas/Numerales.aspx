<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Numerales.aspx.cs" Inherits="ProyectoVD.Numerales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Agregar numeral:</h1>
    <div class="jumbotron">

        <h4>Número de concurso:</h4>
        <input type="text" class="form-control">

        <h4>Unidad académica:</h4>
        
        <asp:DropDownList ID="cbxUA" runat="server" AutoPostBack="true"></asp:DropDownList>
        <div class="row">
            <div class="col-md-4">
                <h4>Código:</h4>
                <input type="text" class="form-control">
            </div>
            <div class="col-md-4">
                <h4>Jornada:</h4>
                <input type="text" class="form-control" placeholder="Inserte una fracción">
            </div>
            <div class="col-md-4">
                <h4>Estado:</h4>
                <select class="form-control">
                    <option>Adjudicado</option>
                    <option>Desierto</option>
                </select>
            </div>
        </div>
        <h4>Descripción</h4>
        <textarea class="form-control" rows="3"></textarea>
    </div>

</asp:Content>
