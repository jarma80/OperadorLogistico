<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppOperadorLogistico.Login" %>

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


<style>
html,body{
    height:100%;
}

.flex-fill {
    flex:1;
}
</style>

<div class="container-fluid d-flex h-100 flex-column">
    <!-- I want this container to stretch to the height of the parent -->
    <div class="row bg-primary h-100">
        <div class="col col-5 col-sm-5 align-self-center text-center text-white">
            <p class="display-4">Login</p>
        </div>
        
        <div class="row bg-dark flex-fill d-flex justify-content-start">
        <!-- I want this row height to filled the remaining height -->
            <div class="col col-7 col-sm-7  portlet-container portlet-dropzone align-self-center">
                <!-- if row is not the right to stretch the remaining height, this column also fine -->
                <div class="container align-items-center p-2 mt-2">
                    <form id="form1" runat="server">
                        <div class="form-group">
                            <label for="exampleInputEmail1" class="text-white-50">Usuario</label>
                            <asp:TextBox ID="TextUsuario" runat="server" class="form-control" placeholder ="Escriba su usuario"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="text-white-50">Password</label>
                            <asp:TextBox ID="TextPassword" runat="server" type="password" class="form-control" placeholder ="Escriba su clave"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1" class="text-white-50">Tipo de Usuario</label>
                            <asp:DropDownList ID="DropDownListRol" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListRol_SelectedIndexChanged">
                                <asp:ListItem>Cliente</asp:ListItem>
                                <asp:ListItem>Operador Logístico</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="row justify-content-center">
                            <asp:Button ID="BtnIngresar" runat="server" Text="Ingresar" type="submit" class="btn btn-primary small" OnClick="BtnIngresar_Click"/>
                        </div>
                    </form>
                </div>
            </div>
        </div>

    </div>
    
</div>

    <!--

<div class="container">
  <div class="row ">
    <div class="col-4">
      <div class="jumbotron align-self-center text-center bg-dark text-white">
  <div class="display-4 ">Login</div>
  <p>Ingrese sus credenciales por favor</p>
</div>
    </div>
    <div class="col-8">
      <h3>Column 2</h3>
      <p>Lorem ipsum dolor..</p>
    </div>
  </div>
</div>

        -->

  
    <div class="row justify-content-center">
        <div class="col-6">
            
        </div>
    </div>

    
</body>
</html>
