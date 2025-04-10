﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicShop
{
    internal interface IDataProcessor<T>
    {
        List<T> LoadData(string filePath);
        void SaveData(List<T> data, string filePath);
    }

}
