using System;
using AutoMapper;
using TranslationPOC.MapperConfig;

namespace AutoMapperTranslation.MapperConfig
{
    public static class TypeEx
    {

        public static IMapper GetTypeMapper<T>(this Type type, string culture) where T : class
        {
            var builder = new AutoMapperAttributeBuilder<T>();
            var mapper = builder.BuildMapper(culture, type);
            return mapper;
        }
    }
}
