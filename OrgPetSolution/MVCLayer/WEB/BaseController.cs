using MvcPresentationLayer.Models;
using System.Web.Mvc;

public class LoggedInBaseController : Controller
{
    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (string.IsNullOrWhiteSpace(Cookie.Get()))
        {
            filterContext.Result = new RedirectResult(Url.Action("Login", "Cliente"));
        }
        base.OnActionExecuting(filterContext);
    }
}