using System;
using System.ComponentModel;

namespace HowOldAreYouTest
{
    public class WindowViewModel : BaseViewModel
    {
        AgeData WhatAge = new AgeData();

        public int GetSetAge 
        { 
            get => WhatAge.Age;
            set => WhatAge.Age = value;
        }
    }
}