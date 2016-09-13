using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
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

                var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

                //if (valueProviderResult == null)
                //{
                //    bindingContext.ModelState.AddModelError(modelName, "");
                //}

                //var customerModel = bindingContext.Model as Customer;

                //var requestMessage = actionContext.Request;
                //var headers = requestMessage.Headers;

                //var customer = new Customer
                //{
                //    RequestTime = DateTime.Now,
                //    ClientIpAddress = headers.Host,
                //    UserAgent = headers?.UserAgent?.FirstOrDefault()?.Product.Name,                    
                //};

                //if(customerModel != null)
                //{
                //    customer.Name = customerModel.Name;
                //    customer.LastName = customerModel.LastName;
                //}

                //bindingContext.Model = customer;
            }

            return status;
        }
    }
}

