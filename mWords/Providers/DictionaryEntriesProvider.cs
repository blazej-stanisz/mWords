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
    public class DictionaryEntriesProvider :
        GenericProvider<DictionaryEntry, DictionaryEntryAppModel>,
        IGenericProvider<DictionaryEntry, DictionaryEntryAppModel>,
        IDictionaryEntriesProvider
    {
        public DictionaryEntriesProvider(ILogger<GenericProvider<DictionaryEntry, DictionaryEntryAppModel>> logger, ApplicationDbContext context, IMapper mapper) : base(logger, context, mapper)
        {
        }
    }
}
