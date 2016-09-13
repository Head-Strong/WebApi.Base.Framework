using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using Newtonsoft.Json;
using WebApi.Domains;

namespace WebApi.Custom.ModalBinder
{
    public class CustomerModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var status = bindingContext.ModelType == typeof(Customer);

            if (status)
            {
                var modelName = bindingContext.ModelName;

                var customerModel = JsonConvert
                    .DeserializeObject<Customer>
                    (actionContext.Request.Content.ReadAsStringAsync().Result);

                if (customerModel == null)
                {
                    bindingContext.ModelState.AddModelError(modelName, "Model should not be null");
                }
                else
                {
                    var requestMessage = actionContext.Request;
                    var headers = requestMessage.Headers;

                    customerModel.RequestTime = DateTime.Now;
                    customerModel.ClientIpAddress = headers.Host;
                    customerModel.UserAgent = headers?.UserAgent?.FirstOrDefault()?.Product.Name;

                    bindingContext.Model = customerModel;
                }
            }

            return status;
        }
    }
}

