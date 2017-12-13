<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="reservation.aspx.cs" Inherits="HotelReservation.reservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-group">
        <label for="inputEmail3" class="col-sm-2 control-label">UserID</label>
        <div class="col-sm-5">
            <%-- <input type="email" class="form-control" id="inputEmail3" placeholder="Email" />--%>
            <asp:TextBox ID="txtUserID" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label for="inputEmail3" class="col-sm-2 control-label">First Name</label>
        <div class="col-sm-5">
            <%-- <input type="email" class="form-control" id="inputEmail3" placeholder="Email" />--%>
            <asp:TextBox ID="txtFirstName" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label for="inputEmail3" class="col-sm-2 control-label">Last Name</label>
        <div class="col-sm-5">
            <%-- <input type="email" class="form-control" id="inputEmail3" placeholder="Email" />--%>
            <asp:TextBox ID="txtLastName" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label for="inputEmail3" class="col-sm-2 control-label">Civilization Number</label>
        <div class="col-sm-5">
            <%-- <input type="email" class="form-control" id="inputEmail3" placeholder="Email" />--%>
            <asp:TextBox ID="txtCivilizationNumber" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label for="inputEmail3" class="col-sm-2 control-label">ReservationNo</label>
        <div class="col-sm-5">
            <%-- <input type="email" class="form-control" id="inputEmail3" placeholder="Email" />--%>
            <asp:TextBox ID="txtResNo" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label for="inputPassword3" class="col-sm-2 control-label">TypeID</label>
        <div class="col-sm-5">
            <%--<input type="password" class="form-control" id="inputPassword3" placeholder="Password"/>--%>
            <asp:TextBox ID="txtType" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="form-group">
        <label for="inputPassword3" class="col-sm-2 control-label">RoomID</label>
        <div class="col-sm-5">
            <%--<input type="password" class="form-control" id="inputPassword3" placeholder="Password"/>--%>
            <asp:TextBox ID="txtRoom" class="form-control" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Check_In</label>
        <label for="inputPassword3" class="col-sm-3 control-label">Check_Out</label>

    </div>

    <div class="form-group ">
        <div class="col-sm-3 col-sm-offset-2">
            <%--<input type="password" class="form-control" id="inputPassword3" placeholder="Password"/>--%>
            <asp:Calendar ID="check_inCal" runat="server" OnDayRender="check_inCal_DayRender" ></asp:Calendar>
        </div>
        <div class="col-sm-3">
            <%--<input type="password" class="form-control" id="inputPassword3" placeholder="Password"/>--%>
            <asp:Calendar ID="check_outCal"  runat="server" OnDayRender="check_outCal_DayRender"></asp:Calendar>
        </div>
    </div>


    <div class="form-group">
        <div class="col-sm-offset-2 col-sm-10">
            <%--  <button type="submit" class="btn btn-default">Sign in</button> --%>
            <asp:Button ID="btnReserve" class="btn btn-default" runat="server" Text="Sign Up" OnClick="btnReserve_Click" />
        </div>

    </div>

    <%-- TExtMode=number Min=1 Text=1 Autopostback=true --%>
</asp:Content>
