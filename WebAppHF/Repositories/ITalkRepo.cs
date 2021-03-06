﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppHF.Models;

namespace WebAppHF.Repositories
{
    public interface ITalkRepo
    {
        IEnumerable<Talk> GetTalks();
        Talk GetTalk(int id);
        void AddTalk(Talk talk);
        void CreateTalk(Talk e);
        void UpdateTalk(Talk e);
        void Remove(Talk e);
    }
}