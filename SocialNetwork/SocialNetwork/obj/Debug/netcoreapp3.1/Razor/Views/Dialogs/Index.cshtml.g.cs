#pragma checksum "C:\Users\Arter\ASP\SocialNetwork\SocialNetwork\Views\Dialogs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2700f62b08692f0e3d99830cf8464c916d98b529"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dialogs_Index), @"mvc.1.0.view", @"/Views/Dialogs/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2700f62b08692f0e3d99830cf8464c916d98b529", @"/Views/Dialogs/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9af4978b9c2bfca24ef48e96efe5f8573634464", @"/Views/_ViewImports.cshtml")]
    public class Views_Dialogs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<div id=""loginBlock"">
    Введите логин:<br/>
    <input id=""userName"" type=""text""/>
    <input id=""loginBtn"" type=""button"" value=""Войти""/>
</div><br/>

<div id=""header""></div><br/>

<div id=""inputForm"">
    <input type=""text"" id=""message""/>
    <input type=""button"" id=""sendBtn"" value=""Отправить""/>
</div>
");
#nullable restore
#line 15 "C:\Users\Arter\ASP\SocialNetwork\SocialNetwork\Views\Dialogs\Index.cshtml"
     foreach(var mess in ViewBag.messages)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <label><b>");
#nullable restore
#line 17 "C:\Users\Arter\ASP\SocialNetwork\SocialNetwork\Views\Dialogs\Index.cshtml"
             Write(mess.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b> ");
#nullable restore
#line 17 "C:\Users\Arter\ASP\SocialNetwork\SocialNetwork\Views\Dialogs\Index.cshtml"
                                Write(mess.Text);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label><br/><br/>\r\n");
#nullable restore
#line 18 "C:\Users\Arter\ASP\SocialNetwork\SocialNetwork\Views\Dialogs\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div id=""chatroom""></div>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/microsoft-signalr/3.1.7/signalr.min.js""></script>
<script>
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl(""/chat"")
        .build();

    let userName = '';
    // получение сообщения от сервера
    hubConnection.on('Send', function (message, userName) {

        // создаем элемент <b> для имени пользователя
        let userNameElem = document.createElement(""b"");
        userNameElem.appendChild(document.createTextNode(userName + ': '));

        // создает элемент <p> для сообщения пользователя
        let elem = document.createElement(""p"");
        elem.appendChild(userNameElem);
        elem.appendChild(document.createTextNode(message));

        var firstElem = document.getElementById(""chatroom"").firstChild;
        document.getElementById(""chatroom"").insertBefore(elem, firstElem);

    });

    // установка имени пользователя
    document.getElementById(""loginBtn"").addEve");
            WriteLiteral(@"ntListener(""click"", function (e) {
        userName = document.getElementById(""userName"").value;
        document.getElementById(""header"").innerHTML = '<h3>Welcome ' + userName + '</h3>';
    });
    // отправка сообщения на сервер
    document.getElementById(""sendBtn"").addEventListener(""click"", function (e) {
        let message = document.getElementById(""message"").value;
        hubConnection.invoke(""Send"", message, '");
#nullable restore
#line 52 "C:\Users\Arter\ASP\SocialNetwork\SocialNetwork\Views\Dialogs\Index.cshtml"
                                          Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n        hubConnection.invoke(\"Save\", message, \'");
#nullable restore
#line 53 "C:\Users\Arter\ASP\SocialNetwork\SocialNetwork\Views\Dialogs\Index.cshtml"
                                          Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', ");
#nullable restore
#line 53 "C:\Users\Arter\ASP\SocialNetwork\SocialNetwork\Views\Dialogs\Index.cshtml"
                                                                Write(ViewBag.IDD);

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n    });\r\n\r\n    hubConnection.start();\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591