<%@ Page Title="" Language="C#" MasterPageFile="~/home.master" AutoEventWireup="true" CodeFile="inicio.aspx.cs" Inherits="inicio_inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Sección de inicio</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section class="content-header">
      <h1>
        Bienvenido
        <small><asp:Label ID="lblnombre" runat="server" Text=""></asp:Label></small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="inicio.aspx"><i class="fa fa-dashboard"></i> Inicio</a></li>
        <%--<li><a href="#">Bienvenido</a></li>--%>
        <li class="active">Bienvenido</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
        Contenido
        

    </section>
</asp:Content>

