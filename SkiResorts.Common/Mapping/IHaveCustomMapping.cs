﻿namespace SkiResorts.Common.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile profile);
    }
}
