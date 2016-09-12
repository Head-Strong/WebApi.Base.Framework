using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace WebApi.Custom.ModalBinder
{
    public class ModelBinderProvider : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            throw new System.NotImplementedException();
        }        
    }
}
