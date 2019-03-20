using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using AutoMapperTranslation.MapperConfig;
using TranslationPOC.Attributes;

namespace TranslationPOC.MapperConfig
{
    public class AutoMapperAttributeBuilder<T1>
        : IMapperFactory<T1> where T1 : class
    {
        public AutoMapperAttributeBuilder()
        {
        }

        public IMapper BuildMapper(string culture, Type targetType)
        {            
            var map = new MapperConfiguration(x => x.CreateMap(typeof(T1), targetType));

            if (targetType.GetProperties().Any(p => p.GetCustomAttributes<Translatable>().Any()))
            {
                var expression = new MapperConfigurationExpression();
                var exp = expression.CreateMap(typeof(T1), targetType);
                
                foreach (var pro in targetType.GetProperties().Where(p => p.GetCustomAttributes<Translatable>().Any()))
                {
                    foreach (var attrDescriptor in pro.GetCustomAttributes<Translatable>())
                    {
                        exp.ForMember(pro.Name, opt => opt.ResolveUsing(sourceVal => translate(pro.GetValue(sourceVal), culture)));
                    }
                }
                
                map = new MapperConfiguration(expression);
            }

            return map.CreateMapper();
        }


        private object translate(object sourceVal, string culture)
        {
            return sourceVal + " in " + culture;
        }

        public IMapper BuildMapper(Type targetExplicit = null)
        {
            throw new NotImplementedException();
        }
    }
}
