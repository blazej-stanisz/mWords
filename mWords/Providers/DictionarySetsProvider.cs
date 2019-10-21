using AutoMapper;
using Microsoft.Extensions.Logging;
using mWords.Data;
using mWords.Models.ApplicationModels;
using mWords.Models.EntityModels;
using mWords.Providers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Providers
{
    public class DictionarySetsProvider : 
        GenericProvider<DictionarySet, DictionarySetAppModel>, 
        IGenericProvider<DictionarySet, DictionarySetAppModel>, 
        IDictionarySetsProvider
    {
        public DictionarySetsProvider(ILogger<GenericProvider<DictionarySet, DictionarySetAppModel>> logger, ApplicationDbContext context, IMapper mapper) : base(logger, context, mapper)
        {
        }
    }
}
