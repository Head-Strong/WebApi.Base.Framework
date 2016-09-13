using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using WebApi.Domains;

namespace WebApi.Custom.ModalBinder
{
    public class CustomModelBinderProvider : ModelBinderProvider
    {
        private static readonly Dictionary<Type, Type> CustomProvider;

        static CustomModelBinderProvider()
        {
            CustomProvider = new Dictionary<Type, Type> {{typeof(Customer), typeof(CustomerModelBinder)}};
        }

        public override IModelBinder GetBinder(HttpConfiguration configuration, Type modelType)
        {
            var modelBinder = default(IModelBinder);
            var getRegistered = CustomProvider.ContainsKey(modelType);

            if (getRegistered)
            {
                var modelBinderType = CustomProvider[modelType];

                if (modelBinderType != default(Type))
                {
                    modelBinder = modelBinderType.Assembly.CreateInstance(modelBinderType.FullName) as IModelBinder;
                }
            }

            return modelBinder;
        }
    }
}
