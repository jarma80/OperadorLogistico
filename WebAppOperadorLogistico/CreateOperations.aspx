<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateOperations.aspx.cs" Inherits="WebAppOperadorLogistico.EditOperations" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.5.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <title></title>
</head>
<body class =" bg-light">


    <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
        <a class="navbar-brand" href="#">Operador Logístico</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarCollapse">
            <ul class="navbar-nav mr-auto">
            <li class="nav-item">
            <a class="nav-link" href="#">Inicio <span class="sr-only">(actualmente)</span></a>
            </li>
            <li class="nav-item">
            <a class="nav-link" href="#">Contáctanos</a>
            </li>
            <li class="nav-item">
            <a class="nav-link" href="#" tabindex="-1" aria-disabled="true">Ayuda</a>
            </li>
            </ul>
            <form class="form-inline mt-2 mt-md-0">
            <input class="form-control mr-sm-2" type="text" placeholder="Search" aria-label="Search"/>
            <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Búsqueda</button>
            </form>
        </div>
    </nav>

    <main role="main" class="container">
        <div class="jumbotron bg-light">
            <form id="form2" runat="server">
                <div class="d-flex" id="wrapper">
                    <!-- Sidebar -->
                    <div class="bg-primary border-right" id="sidebar-wrapper">
                        <div class="sidebar-heading p-4 text-white">
                            <asp:Label ID="LabelOperador" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="list-group list-group-flush">
                        <a href="#" class="list-group-item list-group-item-action small text-white bg-dark">Resumen</a>
                        <a href="SelectCreate.aspx" class="list-group-item list-group-item-action small text-white bg-dark ">Operaciones</a>
                        <a href="#" class="list-group-item list-group-item-action small text-white bg-dark ">Búsqueda</a>
                        <a href="#" class="list-group-item list-group-item-action small text-white bg-dark ">Perfil</a>
                        <asp:Button ID="BtnCerrarSesion" runat="server" Text="Cerrar Sesión" type="submit" class="list-group-item list-group-item-action small text-white bg-dark" OnClick="BtnCerrarSesion_Click"/>           
                        </div>
                    </div>

                    <!-- /#sidebar-wrapper -->
                    <div id="page-content-wrapper" class="w-100 p-2">

                        <div class="container container-fluid">

                            <!-- Title-->
                            <div class="row">
                                <div class="col-2"><img height ="70" width ="100" src="logistic.png" class="img-fluid"/></div>
                                <div class="col-10"><h1 class ="display-4">Crear Operación</h1></div>                                
                            </div>

                            <div class="row mb-2">
                                <div class="card text-white bg-dark w-100">
                                    <div class="card-header">
                                        <asp:Label ID="LabelUser" runat="server" Text="Label" class ="text-white small"></asp:Label>
                                    </div>
                                    <div class="card-body">
                                        <h5 class="card-title text-white-50">
                                            Operación
                                        </h5>
                                        <div class="row p-0 form-group">
                                            <label for="exampleInputPassword1" class="text-white-50">Cliente</label>
                                        </div>
                                        <div class="row">
                                            <asp:TextBox ID="TxtBxCliente" runat="server" class="form-group"></asp:TextBox>
                                        </div>
                                        <div class="row p-0 form-group">
                                            <label for="exampleInputPassword1" class="text-white-50">Tipo de Operación (Logística/Aduana-logística)</label>
                                        </div>
                                        <div class="row">
                                            <!--<asp:TextBox ID="TxtBxTipoOperacion" runat="server" class="form-group"></asp:TextBox> -->
                                            <asp:DropDownList ID="ListTipoOperacion" AutoPostBack="true" runat="server" class="form-group" OnSelectedIndexChanged="ListTipoOperacion_SelectedIndexChanged1">
                                                <asp:ListItem>Aduana-Logística</asp:ListItem>
                                                <asp:ListItem>Logística</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="row p-0">
                                            <asp:Button ID="BtnInsertar" AutoPostBack="true" runat="server" Text="Crear Operación" class="btn btn-primary small form-group" OnClick="BtnInsertar_Click" />
                                        </div>
                                    </div>

                                </div>

                            </div>

                            <!--
                            <div class="row justify-content-center w-100">
                                <div class="col col-6 bg-dark border">
                                    <div class ="row p-2 bg-primary justify-content-end">
                                        
                                    </div>
                                    <div class ="row p-2 bg-primary justify-content-end">
                                        <asp:Label ID="LabelExito" runat="server" Text="Label" class ="text-white small"></asp:Label>
                                    </div>
                                    <div class ="row p-2">
                                        <div class="card bg-dark mb-3" style="max-width: 540px;">
                                            <div class="card-body">
                                                
                                            </div>                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                            -->
    
                        </div>
                    </div>

                </div>
            </form>
        </div>
    </main>


</body>
</html>
