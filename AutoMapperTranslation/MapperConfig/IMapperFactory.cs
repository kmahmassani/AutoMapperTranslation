using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace TranslationPOC.MapperConfig
{
    public interface IMapperFactory<T1>
    {
        IMapper BuildMapper( string culture, Type targetExplicit = null);
    }
}
