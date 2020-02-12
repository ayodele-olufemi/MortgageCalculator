using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MCalcMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        protected void ResetButton_Clicked(object sender, EventArgs e)
        {
            loanAmount.Text = "";
            annualRate.Text = "";
            loanDurationYears.Text = "";
            loanDurationMonths.Text = "";
            downPayment.Text = "";
            extraMonthlyPayment.Text = "";
        }
        async protected void CalculateButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                double loanAmountN = Double.Parse(loanAmount.Text);
                double annualRateN = Double.Parse(annualRate.Text);
                int loanDurationYearsN = Int32.Parse(loanDurationYears.Text);
                int loanDurationMonthsN = Int32.Parse(loanDurationMonths.Text);
                double downPaymentN = Double.Parse(downPayment.Text);
                double extraMonthlyPaymentN = Double.Parse(extraMonthlyPayment.Text);

                if (loanAmountN < 0)
                {
                    loanAmountError.Text = "Enter positive value";
                    loanAmountError.IsVisible = true;
                }
            }
            catch(Exception)
            {
                await DisplayAlert("Wrong values entered", "Please enter correct values", "OK");
            }
            
        }
    }
}