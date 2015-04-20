using System;
using System.Linq;
using System.Web.UI.WebControls;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Aspects;
using Orchard.DisplayManagement;
using Orchard.Environment.Extensions;
using Orchard.Mvc.Filters;
using Orchard.Roles.Models;
using Orchard.Security;
using System.Web.Mvc;

namespace Mmr.InlineEditing.Filters
{
    // We use this filter as a clean way of inserting our top bar into the layout.
    [OrchardFeature("Mmr.InlineEditing")]
    public class InlineEditingTopBarFilter : FilterProvider, IResultFilter
    {
        private readonly IWorkContextAccessor _wca;
        private readonly IShapeFactory _shapeFactory;
        private readonly IAuthorizer _authorizer;
        

        public InlineEditingTopBarFilter(
            IWorkContextAccessor workContextAccessor,
            IShapeFactory shapeFactory,
            IAuthorizer authorizer            
            )
        {
            _wca = workContextAccessor;
            _shapeFactory = shapeFactory;
            _authorizer = authorizer;            
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            // First we make some checks before inserting our top bar.
            if(filterContext.Result as ViewResult == null)  return;
            if (Orchard.UI.Admin.AdminFilter.IsApplied(filterContext.RequestContext)) return;
            if (filterContext.Result is PartialViewResult) return;

            //IUser owner = _content.As<ICommonPart>().Owner;
            
            //if (!_authorizer.Authorize(Orchard.Core.Contents.Permissions.EditContent)) return;           

                    
            var r = _wca.GetContext(filterContext).CurrentUser.As<UserRolesPart>();
            if (r == null) return;
            if (r.Roles.Any(p => p == "vendedor")) {

                if (!IsOwner(((filterContext.RequestContext.HttpContext).Request).RawUrl, (_wca.GetContext(filterContext).CurrentUser).UserName)) return;
            }
            else {
                if (!_authorizer.Authorize(Orchard.Core.Contents.Permissions.EditContent)) return;    
            }

            // Here we insert our topbar into the body.
            _wca.GetContext(filterContext).Layout.Zones["Body"].Add(_shapeFactory.Create("InlineEditing_TopBar"), ":before");

        }

        private bool IsOwner(string page, string user) {
            //si es vendedor miramos que la pagina sea suya por url. Mejorar!
            var pageParts = page.Split('/');
            if (page.Split('/').Length > 2) {
                return pageParts[2].Equals(user, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public void OnResultExecuted(ResultExecutedContext filterContext) { }

    }
}