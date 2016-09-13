using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.Validation.Providers;
using WebApi.Domains;
using WebApi.Domains.MetaData;

namespace WebApi.Custom.Validator
{
    public class CustomValidateProvider : DataAnnotationsModelValidatorProvider
    {
        private static readonly Dictionary<Type, Type> ModalValidatorsTypes = new Dictionary<Type, Type>();

        static CustomValidateProvider()
        {
            ModalValidatorsTypes.Add(typeof(Customer), typeof(CustomerMetaData));
        }

        protected override ICustomTypeDescriptor GetTypeDescriptor(Type type)
        {
            var typeDescriptor = base.GetTypeDescriptor(type);

            if (ModalValidatorsTypes.ContainsKey(type))
            {
                var associatedMetadataTypeTypeDescriptionProvider = 
                    new AssociatedMetadataTypeTypeDescriptionProvider(type, ModalValidatorsTypes[type]);

                typeDescriptor = associatedMetadataTypeTypeDescriptionProvider.GetTypeDescriptor(type);
            }

            return typeDescriptor;
        }
    }
}
