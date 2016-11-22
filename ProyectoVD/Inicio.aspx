﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ProyectoVD.Inicio" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Insertar Numeral</h2>
            <p>
                Esta opción le permite insertar un nuevo numeral. 
            </p>
            <p>
                <input type="button" class="btn btn-default" id="btnInsertar" value="Insertar" runat="server" onserverclick="clickInsertar" />
            </p>
        </div>
        <div class="col-md-8">
            <h2>Modificar o Eliminar</h2>
            <p>
                Escriba el concurso al que pertenece el numeral que desea modificar o eliminar y seleccione buscar.
            </p>
            <p>
                <input id="txtBuscar" type="text" class="form-control" runat="server" required="required" title="Por favor, inserte un concurso." />
            </p>
            <p>
                <input type="submit" class="btn btn-default" id="btnBuscar" value="Buscar" runat="server" onserverclick="clickBuscar" />

            </p>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Insertar Persona</h2>
            <p>
                Esta opción le permite insertar una persona nueva y asignarle los numerales en los que está concursando. 
            </p>
            <p>
                <input type="button" class="btn btn-default" id="Button1" value="Insertar" runat="server" onserverclick="clickInsertar" />
            </p>
        </div>
        <div class="col-md-8">
            <h2>Modificar o Eliminar</h2>
            <p>
                Escriba el concurso al que pertenece el numeral que desea modificar o eliminar y seleccione buscar.
            </p>
            <p>
                <input id="Text1" type="text" class="form-control" runat="server" required="required" title="Por favor, inserte un concurso." />
            </p>
            <p>
                <input type="submit" class="btn btn-default" id="Submit1" value="Buscar" runat="server" onserverclick="clickBuscar" />

            </p>
        </div>
    </div>

</asp:Content>
