using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using Microcharts;
using Entry = Microcharts.Entry;
using Xamarin.Forms;

namespace GymProgress.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticView : ContentPage
    {
        
        public StatisticView()
        {
            InitializeComponent();
            var entries = new[]
            {
                  new Entry(200)
                 {
                   Label = "January",
                    Color = SKColor.Parse("#266489")
                },
                 new Entry(400)
                  {
                    Label = "February",
                     Color = SKColor.Parse("#68B9C0")
                 },
                 new Entry(800)
                    {
                     Label = "March",
                     Color = SKColor.Parse("#90D585")
                    },
                 new Entry(700)
                    {
                     Label = "March",
                     Color = SKColor.Parse("#90D585")
                    },
                 new Entry(800)
                    {
                     Label = "March",
                     Color = SKColor.Parse("#90D585")
                    },
                 new Entry(1000)
                    {
                     Label = "March",
                     Color = SKColor.Parse("#90D585")
                    }
                };
            Chart1.Chart = new LineChart() { Entries = entries };

        }
    }
}