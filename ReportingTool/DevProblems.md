 - ``UseBrowserLink()`` not working.
 1. Tools - NuGet Package Manager - Manage NuGet Packages for Solution ..
 2. Install ``Microsoft.VisualStudio.Web.BrowserLink``

 - ``app.UseMvcWithDefaultRoute()`` error.
 Change ``services.AddMvc()`` to ``services.AddMvc(option => option.EnableEndpointRouting = false)``