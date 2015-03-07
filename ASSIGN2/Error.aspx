<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<style> 
   .well {background-color:gold;}
   .innerWell {
        background-color: lightgoldenrodyellow;
    }
   .panel-heading{font-size:2em;
                  font-style:italic;
                  font-weight:800;
   }
</style>

<h2><%: Title %>.</h2>

<div class="row">
    <div class="well col-md-10 col-md-offset-1">
        <div class="panel panel-danger">
            <div class="panel-heading">Shocking we know, but Error, Error, Error!!</div>
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
                        <h5>Thank you for your patience and understanding. <br /></h5>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>