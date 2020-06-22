<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateClient.aspx.cs" Inherits="WebAppOperadorLogistico.CreateClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.5.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <title></title>
</head>
<body>

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
                                <div class="col-10"><h1 class ="display-4">Crear Cliente</h1></div>                                
                            </div>

                            <div class="row mb-2">
                                 <div class="card text-white bg-dark w-100">
                                    <div class="card-header">Capturar Datos</div>
                                     <div class="card-body">
                                         <div class="col form-group">
                                            
                                             <div class="row mb-2">
                                                <div class="col-2 small">
                                                    Nombre
                                                </div> 
                                                <div class="col-4 small">
                                                    <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
                                                </div>
                                            </div>

                                             <div class="row mb-2">
                                                <div class="col-2 small">
                                                    Apellido Paterno
                                                </div>
                                                <div class="col-3 small">
                                                    <asp:TextBox ID="TxtApellidoPaterno" runat="server"></asp:TextBox>
                                                </div>

                                                <div class="col-2 small">
                                                    Apellido Materno
                                                </div>
                                                <div class="col-3 small">
                                                    <asp:TextBox ID="TxtApellidoMaterno" runat="server"></asp:TextBox>
                                                </div>
                                             </div>

                                             <div class="row mb-2">
                                                <div class="col-2 small">
                                                    Email
                                                </div>
                                                 <div class="col-3 small">
                                                     <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                                                </div>
                                                 <div class="col-2 small">
                                                    Teléfono
                                                </div>
                                                 <div class="col-3 small">
                                                     <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
                                                 </div>
                                             </div>

                                             <div class="row mb-2">
                                                <div class="col-2 small">
                                                    CURP
                                                </div>
                                                <div class="col-3 small">
                                                    <asp:TextBox ID="TxtCURP" runat="server"></asp:TextBox>
                                                </div>
                                             </div>

                                             <div class="row mb-2">
                                                <div class="col-2 small">
                                                    Usuario
                                                </div>
                                                 <div class="col-3 small">
                                                     <asp:TextBox ID="TxtUserName" runat="server"></asp:TextBox>
                                                 </div>
                                                 <div class="col-2 small">
                                                    Password
                                                </div>
                                                 <div class="col-3 small">
                                                     <asp:TextBox ID="TxtPassword" runat="server" type="password"></asp:TextBox>
                                                 </div>
                                             </div>

                                             <div class="row mb-2 justify-content-center">
                                                <div class="col-12 small">
                                                    <asp:Button ID="BtnCreate" runat="server" Text="Crear Usuario" class="btn btn-primary small" OnClick="BtnCreate_Click" />
                                                </div>
                                             </div>

                                         </div>
                                     </div>
                                  </div>
                            </div>

                        </div>
                    </div>

                </div>
            </form>
        </div>
    </main>

</body>
</html>
