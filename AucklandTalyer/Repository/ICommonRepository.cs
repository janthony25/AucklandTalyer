﻿using AucklandTalyer.Models;

namespace AucklandTalyer.Repository
{
    public interface ICommonRepository
    {
        public List<tblParts> GetPartsData();
    }
}
