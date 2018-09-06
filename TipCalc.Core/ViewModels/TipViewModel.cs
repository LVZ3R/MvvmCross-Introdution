using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
    class TipViewModel : MvxViewModel
    {
        readonly ICalculationService calculationService;

        private double subTotal;
        private int generosity;
        private double tip;

        public double SubTotal
        {
            get => subTotal;
            set
            {
                subTotal = value;
                RaisePropertyChanged(() => SubTotal);

                Recalculate();
            }
        }

        public int Generosity
        {
            get => generosity;
            set
            {
                generosity = value;
                RaisePropertyChanged(() => Generosity);

                Recalculate();
            }
        }

        public double Tip
        {
            get => tip;
            set
            {
                tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        public TipViewModel(ICalculationService calculationService)
        {
            this.calculationService = calculationService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            subTotal = 100;
            generosity = 10;

            Recalculate();
        }

        private void Recalculate()
        {
            Tip = calculationService.TipAmount(SubTotal, Generosity);
        }
    }
}
