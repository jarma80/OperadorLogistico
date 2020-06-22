<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminIndex.aspx.cs" Inherits="WebAppOperadorLogistico.AdminIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.5.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>


    <script src="Scripts/gijgo/jquery-3.3.1.min.js"></script>
    <script src="Scripts/gijgo/js/gijgo.min.js" type="text/javascript"></script>
    <!--link href="Scripts/gijgo/css/gijgo.min.css" rel="stylesheet" type="text/css" /-->
    <link href="https://unpkg.com/gijgo@1.9.13/css/gijgo.min.css" rel="stylesheet" type="text/css" />

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
            <form id="form1" runat="server">
                <div class="d-flex" id="wrapper">
                    <!-- Sidebar -->
                    <div class="bg-primary border-right" id="sidebar-wrapper">
                        <div class="sidebar-heading p-4 text-white">
                            <asp:Label ID="LabelUser" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="list-group list-group-flush">
                        <a href="#" class="list-group-item list-group-item-action small text-white bg-dark">Resumen</a>
                        <a href="SelectCreate.aspx" class="list-group-item list-group-item-action small text-white bg-dark ">Crear Operación</a>
                        <a href="UpdateOperations.aspx" class="list-group-item list-group-item-action small text-white bg-dark ">Actualizar Estatus Operativo</a>
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
                                <div class="col-10"><h1 class ="display-4">Panel de Administrador</h1></div>                                
                            </div>
                        
                            <!-- Filtros de búsqueda-->
                            <div class="row mb-2">
                                 <div class="card text-white bg-dark w-100">
                                    <div class="card-header">Filtros de Búsqueda</div>
                                     <div class="card-body">
                                         <div class="col form-group">
                                            <div class="row">
                                                <div class="col-4 text-white-50">Desde
                                                    <asp:TextBox ID="datepicker" class ="form-control-label text-black bg-light" runat="server"></asp:TextBox>
                                                    <script>
                                                        $('#datepicker').datepicker({ format: 'yyyy-mm-dd' });
                                                    </script>
                                                </div>
                                                <div class="col-4 text-white-50">Hasta
                                                    <asp:TextBox ID="datepicker2" class ="form-control-label text-black bg-light" runat="server"></asp:TextBox>
                                                    <script>
                                                        $('#datepicker2').datepicker({ format: 'yyyy-mm-dd' });
                                                    </script>
                                                </div>
                                                <div class="col-4">
                                                    <asp:Button ID="BtnSearch" class="btn btn-primary small" runat="server" Text="Buscar" OnClick="BtnSearch_Click" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                 </div>
                            </div>

                            <!-- Lista de Operaciones de la Base de Datos-->
                            <div class="form-group"> 
                                
                                <asp:DataList ID="DataListOperations" runat="server" class="rounded small table table-borderless table-striped table-dark" AutoPostBack="true" OnItemCreated="DataListOperations_ItemCreated" >
                                    <HeaderTemplate>
                                        <div class="row rounded text-white font-weight-bold bg-primary">
                                            <div class="col">Codigo</div>
                                            <div class="col">Tipo</div>
                                            <div class="col">Estatus</div>
                                            <div class="col">Avance</div>
                                            <div class="col">Nombre</div>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Codigo")%>'></asp:Label>
                                            </div>
                                            <div class="col">
                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("Tipo")%>'></asp:Label>
                                            </div>
                                            <div class="col">
                                                <asp:Label ID="Label3" runat="server" Text='<%#Eval("Estatus")%>'></asp:Label>
                                            </div>
                                            <div class="col">
                                                <div class="progress bg-secondary">
                                                    <!-- Define a Panel that you can use to set these values -->
                                                    <asp:Panel ID="PercentagePanel" runat="server" CssClass="progress-bar"></asp:Panel>
                                                </div>
                                            </div>
                                            <div class="col">
                                                <asp:Label ID="Label4" runat="server" Text='<%#Eval("Nombre")%>'></asp:Label>
                                            </div>
                                        </div>  
                                    </ItemTemplate>
                                </asp:DataList>

                            </div>

                            <!-- Pager-->

                            <div class="card text-white bg-dark w-100">
                                <div class="card-body">
                                    <div class="row rounded text-white bg-dark align-content-center align-center">
                                        <div class="col form-group align-center align-content-center r">
                                            <asp:Button ID="BtnFistPage" runat="server" Text="<<" class="btn btn-primary small" OnClick="BtnFistPage_Click"/>
                                            <asp:Button ID="BtnPreviousPage" runat="server" Text="<" class="btn btn-primary small" OnClick="BtnPreviousPage_Click"/>
                                            <asp:Button ID="BtnNextPage" runat="server" Text=">" class="btn btn-primary small" OnClick="BtnNextPage_Click"/>
                                            <asp:Button ID="BtnLastPage" runat="server" Text=">>" class="btn btn-primary small" OnClick="BtnLastPage_Click"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </form>
        </div> <!-- FIN JUMBOTRON -->
    </main>

</body>
</html>
