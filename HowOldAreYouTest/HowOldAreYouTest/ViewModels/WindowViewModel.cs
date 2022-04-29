using System;
using System.ComponentModel;

namespace HowOldAreYouTest
{
    public class WindowViewModel : BaseViewModel
    {
        AgeData whatAge = new AgeData();

        public int GetSetAge 
        { 
            get => whatAge.Age;
            set => whatAge.Age = value;
        }
    }
}