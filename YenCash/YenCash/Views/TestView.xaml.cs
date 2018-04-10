using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace YenCash
{
    public partial class TestView : ContentPage
    {
        public TestView()
        {
            InitializeComponent();
        }

        private void SubmitClicked(object sender, EventArgs e)
        {
            try
            {
                //Navigation.PushModalAsync(new UserLogin());
                Navigation.PushModalAsync(new SelectQuizSubject(new string[] { "Push" }));
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
