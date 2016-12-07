1<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="ProyectoVD.Inicio" %>

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
                <input type="button" class="btn btn-default" id="btnInsertar" value="Insertar" runat="server" onserverclick="clickInsertarNumeral" />
            </p>
        </div>
        <div class="col-md-8">
            <h2>Modificar o Eliminar</h2>
            <p>
                Escriba el concurso al que pertenece el numeral que desea modificar o eliminar y seleccione buscar.
            </p>
            <p>
                <input id="txtBuscarNumerales" type="text" class="form-control" runat="server" groupname="Submit1" required="required" title="Por favor, inserte un concurso." />
            </p>
            <p>
                <input type="button" class="btn btn-default" id="btnBuscar" value="Buscar" runat="server" groupname="Submit1" onserverclick="clickBuscarNumeral" />

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
                <input type="button" class="btn btn-default" id="btnInsertarPersona" value="Insertar" runat="server" onserverclick="clickInsertarPersona" />
            </p>
        </div>
        <div class="col-md-8">
            <h2>Modificar o Eliminar</h2>
            <p>
                Puede realizar la búsqueda utilizando alguno de los siquientes criterios, solo seleccione uno e introduzca la palabra a buscar.
            </p>
            <asp:RadioButton ID="rdbConcurso" Text="Concurso" Checked="True" GroupName="RadioGroup1" runat="server" />
            <asp:RadioButton ID="rdbCedula" Text="Cédula" Checked="false" GroupName="RadioGroup1" runat="server" />
            <asp:RadioButton ID="rdbNombre" Text="Nombre" Checked="false" GroupName="RadioGroup1" runat="server" />
            <p>
                <input id="txtBuscarPersona" type="text" class="form-control" runat="server" groupname="Submit2" required="required" title="Por favor, inserte un parámetro de búsqueda." />
            </p>
            <p>
                <input type="button" class="btn btn-default" id="btnBuscarPersona" value="Buscar" groupname="Submit2" runat="server" onserverclick="clickBuscarPersona" />

            </p>
        </div>
    </div>

</asp:Content>
