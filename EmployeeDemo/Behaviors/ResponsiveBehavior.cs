using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeDemo.Behaviors
{
    public class ResponsiveBehavior
    {


        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsResponsiveProperty =
            DependencyProperty.RegisterAttached("IsResponsive", 
                typeof(bool), 
                typeof(ResponsiveBehavior), 
                new PropertyMetadata(false, OnIsResponsiveChanged));


        public static bool GetIsResponsive(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsResponsiveProperty);
        }

        public static void SetIsResponsive(DependencyObject obj, bool value)
        {
            obj.SetValue(IsResponsiveProperty, value);
        }


        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HorizontalBreakpointProperty =
            DependencyProperty.RegisterAttached("HorizontalBreakpoint",
                typeof(double),
                typeof(ResponsiveBehavior),
                new PropertyMetadata(double.MaxValue));


        public static double GetHorizontalBreakpoint(DependencyObject obj)
        {
            return (double)obj.GetValue(HorizontalBreakpointProperty);
        }

        public static void SetHorizontalBreakpoint(DependencyObject obj, double value)
        {
            obj.SetValue(HorizontalBreakpointProperty, value);
        }


        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HorizontalBreakpointSettersProperty =
            DependencyProperty.RegisterAttached("HorizontalBreakpointSetters", 
                typeof(SetterBaseCollection), 
                typeof(ResponsiveBehavior), 
                new PropertyMetadata(new SetterBaseCollection()));

        public static SetterBaseCollection GetHorizontalBreakpointSetters(DependencyObject obj)
        {
            return (SetterBaseCollection)obj.GetValue(HorizontalBreakpointSettersProperty);
        }

        public static void SetHorizontalBreakpointSetters(DependencyObject obj, SetterBaseCollection value)
        {
            obj.SetValue(HorizontalBreakpointSettersProperty, value);
        }



        // Using a DependencyProperty as the backing store for IsHorizontalBreakpointSettersActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsHorizontalBreakpointSettersActiveProperty =
            DependencyProperty.RegisterAttached("IsHorizontalBreakpointSettersActive",
                typeof(bool), 
                typeof(ResponsiveBehavior), 
                new PropertyMetadata(false));

        public static bool GetIsHorizontalBreakpointSettersActive(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsHorizontalBreakpointSettersActiveProperty);
        }

        public static void SetIsHorizontalBreakpointSettersActive(DependencyObject obj, bool value)
        {
            obj.SetValue(IsHorizontalBreakpointSettersActiveProperty, value);
        }


        private static void OnIsResponsiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           if(d is FrameworkElement element)
            {
                Window window = Application.Current.MainWindow;

                if (GetIsResponsive(element))
                {
                    window.SizeChanged += (s, e) => UpdateElement(window, element);
                }
                else
                {
                    window.SizeChanged -= (s, e) => UpdateElement(window, element);
                }
            }
        }

        private static void UpdateElement(Window window, FrameworkElement element)
        {
           double windowWidth = window.Width;
            double breakpointWidth = GetHorizontalBreakpoint(element);

            if (windowWidth >= breakpointWidth && !GetIsHorizontalBreakpointSettersActive(element))
            {
                SetIsHorizontalBreakpointSettersActive(element, true);
                element.Style = CreateReponsivnessStyle(element);
            }
            else if (windowWidth < breakpointWidth && GetIsHorizontalBreakpointSettersActive(element))
            {
                SetIsHorizontalBreakpointSettersActive(element, false);
                element.Style = element.Style.BasedOn;
            }
        }

        private static Style CreateReponsivnessStyle(FrameworkElement element)
        {
            Style responsivnessStyle = new Style(element.GetType(), element.Style);

            foreach (Setter setter in GetHorizontalBreakpointSetters(element))
            {
                responsivnessStyle.Setters.Add(setter);
            }

            return responsivnessStyle;
        }
    }
}
