﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpodIgly.Infrastructures
{
    public interface ICacheProvider
    {
        object Get(string key);

        void Set(string key, object data, int cacheTime);

        bool IsSet(string key);

        void Invalidate(string key);
    }
}