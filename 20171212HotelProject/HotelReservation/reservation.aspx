<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="reservation.aspx.cs" Inherits="HotelReservation.reservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="form-group">
        <label for="inputPassword3" class="col-sm-3 control-label">Check_In</label>
        <label for="inputPassword3" class="col-sm-3 control-label">Check_Out</label>

    </div>

    <div class="form-group ">
        <div class="col-sm-3 col-sm-offset-2">
            <%--calender for check-in--%>
            <asp:Calendar ID="check_inCal" runat="server" OnDayRender="check_inCal_DayRender"></asp:Calendar>
        </div>
        <div class="col-sm-3">
            <%--Calender for check-out--%>
            <asp:Calendar ID="check_outCal" runat="server" OnDayRender="check_outCal_DayRender"></asp:Calendar>
        </div>
    </div>


    <div class="form-group">
        <div class="col-sm-1 col-sm-offset-2">
            <%-- <input type="email" class="form-control" id="inputEmail3" placeholder="Email" />--%>
            <asp:DropDownList ID="ddlPersonCount" AutoPostBack="True" CssClass="dropdown dropdown-toggle btn btn-warning btn-lg" runat="server" OnSelectedIndexChanged="ddlPersonCount_SelectedIndexChanged"></asp:DropDownList>
            <%--            <asp:TextBox ID="txtUserID" class="form-control" runat="server"></asp:TextBox>--%>
        </div>
        <div class="col-sm-1">
            <%-- <input type="email" class="form-control" id="inputEmail3" placeholder="Email" />--%>
            <asp:DropDownList ID="ddlType" CssClass="dropdown dropdown-toggle btn btn-warning btn-lg" runat="server"></asp:DropDownList>
            <%--            <asp:TextBox ID="txtUserID" class="form-control" runat="server"></asp:TextBox>--%>
        </div>
        <div class="col-sm-1 col-sm-offset-1">
            <%-- <input type="email" class="form-control" id="inputEmail3" placeholder="Email" />--%>
            <asp:DropDownList ID="ddlRooms" CssClass="dropdown dropdown-toggle btn btn-warning btn-lg" runat="server"></asp:DropDownList>
            <%--            <asp:TextBox ID="txtUserID" class="form-control" runat="server"></asp:TextBox>--%>
        </div>
    </div>
 


    <div id="personInfo" runat="server">

    </div>



    <div class="form-group">
        <div class="col-sm-offset-5 col-sm-10">
            <%--  <button type="submit" class="btn btn-default">Sign in</button> --%>
            <asp:Button ID="btnReserve" class="btn btn-warning btn-lg" runat="server" Text="Sign Up" OnClick="btnReserve_Click" />
            <br />
        </div>

    </div>

    <%-- TExtMode=number Min=1 Text=1 Autopostback=true --%>
</asp:Content>
