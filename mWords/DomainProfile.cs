using AutoMapper;
using mWords.Models.EntityModels;
using mWords.Models.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mWords
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<DictionaryEntry, DictionaryEntryAppModel>();
            CreateMap<DictionarySet, DictionarySetAppModel>();
            CreateMap<EntryAssignment, EntryAssignmentAppModel>();
        }
    }
}
