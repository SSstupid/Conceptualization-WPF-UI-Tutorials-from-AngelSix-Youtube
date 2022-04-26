using System;
using System.ComponentModel;

namespace HowOldAreYouTest
{
    public class WindowViewModel : BaseViewModel
    {
        AgeData WhatAge = new AgeData();

        public int GetSetAge { get; set; }

        public WindowViewModel() => GetSetAge = WhatAge.Age;
    }
}