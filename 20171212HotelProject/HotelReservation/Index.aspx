<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="HotelReservation.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="intro">
        <div class="inner">
            <div class="content">
                <h1>Hotel Reservation</h1>
                <a class="btnRes" href="reservation.aspx">Rezervasyona Başla</a>
            </div>
        </div>
    </section>
</asp:Content>
