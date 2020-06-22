<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebAppOperadorLogistico.Index" EnableEventValidation="false" %>

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
            <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
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
                        <a href="#" class="list-group-item list-group-item-action small text-white bg-dark">Operaciones</a>
                        <a href="#" class="list-group-item list-group-item-action small text-white bg-dark ">Solicitudes</a>
                        <a href="#" class="list-group-item list-group-item-action small text-white bg-dark ">Perfil</a>
                        <asp:Button ID="BtnCerrarSesion" runat="server" Text="Cerrar Sesión" type="submit" class="list-group-item list-group-item-action small text-white bg-dark" OnClick="BtnCerrarSesion_Click"/>           
                        </div>
                    </div>
                    <!-- /#sidebar-wrapper -->
                    <div id="page-content-wrapper" class="w-100 p-2">

                        <div class="container container-fluid">
                            <div class="row">
                                <div class="col-2"><img height ="70" width ="100" src="logistic.png" class="img-fluid"/></div>
                                <div class="col-10"><h1 class ="display-4">Operaciones actuales</h1></div>                                
                            </div>
                            
                            
                            

                            <div class="form-group"> 
                                
                                <asp:DataList ID="DataListOperations" runat="server" class="rounded small table table-borderless table-striped table-dark" OnSelectedIndexChanged="DataListOperations_SelectedIndexChanged" AutoPostBack="true" OnItemCreated="DataListOperations_ItemCreated" >
                                    <HeaderTemplate>
                                        <div class="row rounded text-white font-weight-bold bg-primary">
                                            <div class="col">Operacion</div>
                                            <div class="col">Tipo</div>
                                            <div class="col">Estatus</div>
                                            <div class="col">Avance</div>
                                            <div class="col">Detalles</div>
                                        </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col">
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Operacion")%>'></asp:Label>
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
                                                <asp:Button ID="BtnItem" CommandName="detailsView" CommandArgument='<%#Eval("Operacion")%>' runat="server" Text="Detalles" OnClick="BtnItem_Click" AutoPostBack="true" class=" btn-primary btn-sm"  />
                                            </div>
                                        </div>  
                                    </ItemTemplate>
                                </asp:DataList>

                            </div>
                        </div>

                    </div>
                </div>
            </form>
        </div> <!-- FIN JUMBOTRON -->
    </main>

</body>
</html>
