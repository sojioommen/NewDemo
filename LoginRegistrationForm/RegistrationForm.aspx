<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="LoginRegistrationForm.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
<style>
    .bgColor{
        background:#ff6a00
    }
</style>
</head>
<body>
    <div class="container text-center">
  <div class="row">
    <div class="col">
  
    </div>
    <div class="col-lg-5 bgColor rounded">

        <div class="bg-primary p-4 mb-3">
<h1>Registration Form</h1>
        </div>
      <form  runat="server" method="POST">
       
<div class="mb-3">
 <asp:TextBox ID="name" CssClass="form-control" placeholder="Name" runat="server"></asp:TextBox>
</div>
<div class="mb-3">
 <asp:TextBox ID="email" TextMode="Email" CssClass="form-control" placeholder="soji@gmail.com" runat="server"></asp:TextBox>
</div>
<div class="mb-3">
 <asp:TextBox ID="phone" CssClass="form-control" placeholder="Phone"  runat="server"></asp:TextBox>
</div>

<div class="mb-3">
 <asp:TextBox ID="password" CssClass="form-control"  placeholder="Password"  runat="server"></asp:TextBox>
</div>
          <div class="mb-3">
 <asp:TextBox ID="cpassword" CssClass="form-control" placeholder="Cpassword"  runat="server"></asp:TextBox>
</div>




  <div class="d-grid gap-2 d-md-flex ">
      <asp:HyperLink ID="HyperLink1" CssClass="btn btn-secondary" href="LoginForm.aspx" runat="server">Home</asp:HyperLink>
      <asp:Button ID="Button5" CssClass="btn btn-danger" runat="server" Text="Register" OnClick="Button5_Click"  />
    


 
</div>
      </form>
        <asp:Label Text="" ID="lblError" runat="server"></asp:Label>
    </div>
    <div class="col">
    
    </div>
  </div>
</div>
</body>
</html>
