﻿using Core.BaseModels;
using DataAccess.Dtos.Base;

namespace DataAccess.Dtos.Product
{
    public class ProductUpdateDto : ProductBaseDto, IIdenticalModel
    {
        public int Id { get ; set ; }
    }
}