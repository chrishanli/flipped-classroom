<%@ Page Title="问题主页" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QuestionPage.aspx.cs" Inherits="FCWebApp.Pages.QuestionPage" %>

<asp:Content ID="QuestionPage" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>问题主页 - <%= this.qvo.topic %></h2>
        <h4>发表日期：<%= this.qvo.questionDate %></h4>
    </div>
    
    <hr />
    <div class="container">
        <h4>问题原文：</h4>
        <p class="lead"><%= this.qvo.contents %></p>
    </div>

</asp:Content>
