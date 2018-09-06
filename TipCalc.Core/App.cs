using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross;
using MvvmCross.ViewModels;
using TipCalc.Core.ViewModels;
using TipCalc.Core.Services;

namespace TipCalc.Core
{
    class App : MvxApplication
    {
        public override void Initialize()
        {
            Mvx.RegisterType<ICalculationService, CalculationService>();

            RegisterAppStart<TipViewModel>();
        }
    }
}
