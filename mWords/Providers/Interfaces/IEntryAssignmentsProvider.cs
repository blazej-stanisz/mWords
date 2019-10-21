﻿using mWords.Models.ApplicationModels;
using mWords.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mWords.Providers.Interfaces
{
    public interface IEntryAssignmentsProvider : IGenericProvider<EntryAssignment, EntryAssignmentAppModel>
    {
    }
}