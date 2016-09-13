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
                typeDescriptor = new AssociatedMetadataTypeTypeDescriptionProvider(type, ModalValidatorsTypes[type]).GetTypeDescriptor(type);

            return typeDescriptor;
        }
    }
}
