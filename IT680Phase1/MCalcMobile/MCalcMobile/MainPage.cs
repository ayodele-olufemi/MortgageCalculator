using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MCalcMobile
{
    public class MainPage : ContentPage
    {
        Entry loanAmount;
        Entry annualRate;
        Entry loanDurationYears;
        Entry loanDurationMonths;
        Entry downPayment;
        Entry extraMonthlyPayment;
        Button calculateButton;
        Label result;
        Label amortTbl;
        double monthlyPayment;

        public MainPage()
        {
            StackLayout panel = new StackLayout
            {
                Padding = new Thickness(20,20,20,20),
                BackgroundColor = Color.FromRgb(206, 221, 245)
            };

            StackLayout row1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            StackLayout row2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            StackLayout row3 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            StackLayout row4 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            StackLayout row5 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            StackLayout row6 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            row1.Children.Add(new Label
            {
                Text = "Loan Amount: ",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)), 
                VerticalTextAlignment = TextAlignment.Center, 
                WidthRequest = 150
            });

            row1.Children.Add(loanAmount = new Entry
            {
                Text = "170000", 
                WidthRequest = 170
            });

            row2.Children.Add(new Label
            {
                Text = "Annual Rate: ",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                WidthRequest = 150
            });

            row2.Children.Add(annualRate = new Entry
            {
                Text = "3",
                WidthRequest = 170
            });

            row3.Children.Add(new Label
            {
                Text = "Duration Years: ",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                WidthRequest = 150
            });

            row3.Children.Add(loanDurationYears = new Entry
            {
                Text = "15",
                WidthRequest = 170
            });

            row4.Children.Add(new Label
            {
                Text = "Duration Months: ",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                WidthRequest = 150
            });

            row4.Children.Add(loanDurationMonths = new Entry
            {
                Text = "0",
                WidthRequest = 170
            });

            row5.Children.Add(new Label
            {
                Text = "Down Payment: ",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                WidthRequest = 150
            });

            row5.Children.Add(downPayment = new Entry
            {
                Text = "0",
                WidthRequest = 170
            });

            row6.Children.Add(new Label
            {
                Text = "Extra Monthly Payment: ",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                VerticalTextAlignment = TextAlignment.Center,
                WidthRequest = 150
            });

            row6.Children.Add(extraMonthlyPayment = new Entry
            {
                Text = "50",
                WidthRequest = 170
            });


            panel.Children.Add(new Label
            {
                Text = "Mortgage Calculator",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)), 
                HorizontalTextAlignment = TextAlignment.Center, 
                TextColor = Color.Red, 
                Padding = new Thickness(20,0,0,0)
            });

            panel.Children.Add(row1);
            panel.Children.Add(row2);
            panel.Children.Add(row3);
            panel.Children.Add(row4);
            panel.Children.Add(row5);
            panel.Children.Add(row6);
            
            
            //panel.Children.Add(new Label
            //{
            //    Text = "Loan Amount: ",
            //    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            //});

            //panel.Children.Add(loanAmount = new Entry
            //{
            //    Text = "170000"
            //});

            //panel.Children.Add(new Label
            //{
            //    Text = "Annual Rate: ",
            //    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            //});

            //panel.Children.Add(annualRate = new Entry
            //{
            //    Text = "3"
            //});

            //panel.Children.Add(new Label
            //{
            //    Text = "Loan Duration Years: ",
            //    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            //});

            //panel.Children.Add(loanDurationYears = new Entry
            //{
            //    Text = "10"
            //});

            //panel.Children.Add(new Label
            //{
            //    Text = "Loan Duration Months: ",
            //    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            //});

            //panel.Children.Add(loanDurationMonths = new Entry
            //{
            //    Text = "0"
            //});

            //panel.Children.Add(new Label
            //{
            //    Text = "Down Payment: ",
            //    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            //});

            //panel.Children.Add(downPayment = new Entry
            //{
            //    Text = "2000"
            //});

            //panel.Children.Add(new Label
            //{
            //    Text = "Extra Monthly Payment: ",
            //    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            //});

            //panel.Children.Add(extraMonthlyPayment = new Entry
            //{
            //    Text = "50"
            //});

            panel.Children.Add(calculateButton = new Button
            {
                Text = "Calculate"
            });

            panel.Children.Add(result = new Label
            {
                Text = "",
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)), 
                IsVisible = false
            });

            panel.Children.Add(amortTbl = new Label
            {
                Text = ""
            });

           

            ScrollView scroll = new ScrollView();
            scroll.Content = panel;


            calculateButton.Clicked += OnCalculate;
            this.Content = scroll;
        }

        async void OnCalculate(object sender, EventArgs e)
        {
            try
            {
                double p1 = Double.Parse(loanAmount.Text);
                double p2 = Double.Parse(annualRate.Text);
                int p3 = Int32.Parse(loanDurationYears.Text);
                int p4 = Int32.Parse(loanDurationMonths.Text);
                double p5 = Double.Parse(downPayment.Text);
                double p6 = Double.Parse(extraMonthlyPayment.Text);
                
                monthlyPayment = CalculationLogic.CalcMonthlyPayment(p1, p2, p3, p4, p5, p6);
                result.Text = "The Monthly Payment is: " + monthlyPayment.ToString("C");
                result.IsVisible = true;

                CalculationLogic L = new CalculationLogic();
                List<AmortizationDataOut> AmortTable = L.GetAmortizationTable(p1, p2, p3, p4, p5, p6);
                amortTbl.Text = "Month\t\t\t Payment \t\t\t Interest \t\t\t Principal \t\t\t Balance";
                foreach (var item in AmortTable)
                {
                    amortTbl.Text = amortTbl.Text + "\n" + item.Months.ToString() + "\t\t\t\t\t\t" + monthlyPayment.ToString("C") + "\t\t\t" + item.Interest.ToString("C") + "\t\t\t" + item.Principal.ToString("C") + "\t\t\t" + item.Balance.ToString("C");
                }
                
            }
            catch(Exception)
            {
                await DisplayAlert("Wrong values entered", "Please enter correct values", "OK");
            }
            

        }
    }
}
