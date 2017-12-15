<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HotelReservation.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container form-div-bg"><br />
        <div class="form-group">
            <label for="inputEmail3" class="col-sm-2 control-label text-info">E_Mail</label>
            <div class="col-sm-5">
                <%-- <input type="email" class="form-control" id="inputEmail3" placeholder="Email" />--%>
                <asp:TextBox ID="txtMail" class="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <label for="inputEmail3" class="col-sm-2 control-label text-info">Password</label>
            <div class="col-sm-5">
                <%-- <input type="email" class="form-control" id="inputEmail3" placeholder="Email" />--%>
                <asp:TextBox ID="txtPassword" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <%--  <button type="submit" class="btn btn-default">Sign in</button> --%>
                <asp:Button ID="btnLogin" class="btn form-btn" runat="server" Text="Login" OnClick="btnLogin_Click" />
            </div>

        </div>
    </div>
</asp:Content>
