using System;
using CoreAnimation;
using CoreGraphics;
using MiniEarnings;
using MiniEarnings.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomGradientRoundEdgeView), typeof(CustomGradientRoundEdgeViewRender))]
namespace MiniEarnings.iOS
{
    public class CustomGradientRoundEdgeViewRender : VisualElementRenderer<StackLayout>
    {
        public CustomGradientRoundEdgeViewRender() { }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);

        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            //Draw(this.Frame);
        }

        //public override void Draw(CGRect rect)
        //{
        //    base.Draw(rect);
        //}

        public override void Draw(CoreGraphics.CGRect rect)
        {
            base.Draw(rect);

            CustomGradientRoundEdgeView stack = (CustomGradientRoundEdgeView)this.Element;
            CGColor startColor = stack.StartColor.ToCGColor();
            CGColor endColor = stack.EndColor.ToCGColor();
            string gradientStyle = stack.gradientMode;

            /*
            #region for Vertical Gradient  

            var gradientLayer = new CAGradientLayer();

            #endregion

            #region for Horizontal Gradient  

            //var gradientLayer = new CAGradientLayer()
            //{
            //  StartPoint = new CGPoint(0, 0.5),
            //  EndPoint = new CGPoint(1, 0.5)
            //};

            #endregion
            */

            try
            {
                if (stack.HasBorderColor == true && stack.BorderColor != null)
                {
                    //double min = Math.Min(Element.Width, Element.Height);
                    //Control.Layer.CornerRadius = (float)(min / 2.0);
                    //Control.Layer.MasksToBounds = false;
                    //Control.Layer.BorderColor = Color.White.ToCGColor();
                    //Control.Layer.BorderWidth = 1;
                    //Control.ClipsToBounds = true;

                    double min = Math.Min(Element.Width, Element.Height);
                    //this.Layer.CornerRadius = (float)(min / 2.0);
                    this.Layer.MasksToBounds = false;
                    this.Layer.BorderColor = stack.BorderColor.ToCGColor();
                    this.Layer.BorderWidth = 1;
                    this.ClipsToBounds = true;
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                //Debug.WriteLine("Unable to create circle image: " + ex);
            }

            var gradientLayer = new CAGradientLayer();
            if (gradientStyle == "Vertical")
            {

            }
            else
            {
                gradientLayer.StartPoint = new CGPoint(0, 0.5);
                gradientLayer.EndPoint = new CGPoint(1, 0.5);
            }
            gradientLayer.Frame = rect;
            gradientLayer.Colors = new CGColor[] { startColor, endColor };
            gradientLayer.ModelLayer.CornerRadius = (float)(stack.cornerRadius);
            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}