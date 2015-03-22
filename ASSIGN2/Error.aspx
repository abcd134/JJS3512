<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<div class="row">
    <div class="well col-md-10 col-md-offset-1 rowCol">
        <div class="panel panel-danger">
            <div class="panel-body  innerWell">
                <div class="row">
                    <div class="col-md-3">
                        <figure>
                            <img src="/images/shocking.jpg"
                                    alt="Cat getting shocked"
                                    title="Cat getting shocked" 
                                    class="img-responsive img-rounded" />
                        </figure>
                    </div>
                    <div class="col-md-9">
                        
                        <h3>
                            We are sorry, something broke.  We have recorded the
                            error and will get our developers to fix the problem
                            if we can. <br />
                        </h3>
                        <asp:Label ID="errorMessage" runat="server" Visible="false"/>
                        <h5>Thank you for your patience and understanding. <br /></h5>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>