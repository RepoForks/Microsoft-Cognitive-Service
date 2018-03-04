<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script> 
function callback(json) { 
    $.map(json.ranking, function (element) {  
        //Custom rendering function given content info
        render({img:element.details[1].image, 
                title:element.details[1].title,
                onClick: element.id != json.rewardAction ? null :
                   function() {
                       $.ajax({type: "POST",
			       url: '//ds.microsoft.com/api/v2/demo/reward/' + json.eventId,
			       contentType: "application/json"});
                   }});
	});        
}                      
</script>

<script src="https://ds.microsoft.com/api/v2/devenvexe/rank/CSharpCorner" async></script>

$.ajax({
    url: "https://ds.microsoft.com/api/v2/devenvexe/rank/CSharpCorner?details=2&pretty=1",
    type: "GET",
    dataType: "jsonp",
    complete: function (xhr) { callback(xhr.responseJSON); }
});

</asp:Content>
