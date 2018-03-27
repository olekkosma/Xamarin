using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GymProgress.Behavior
{
    class ExerciseValidation : Behavior<SearchBar>
    {
        protected override void OnAttachedTo(SearchBar bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnBindableTextChanged;
        }

        protected override void OnDetachingFrom(SearchBar bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnBindableTextChanged;
        }

        private static void OnBindableTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!(sender is SearchBar entry))
                return;
            string exer = e.NewTextValue;
            if (exer.Length < 2)
            {
                entry.BackgroundColor = Color.Red;
            }
            else
            {
                entry.BackgroundColor = Color.Default;
            }
        }
    }
}
