using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace FSFControls
{
    public class VideoBox : ContentControl
    {
        public static readonly DependencyProperty ThumbnailProperty = DependencyProperty.Register("Thumbnail", typeof(ImageSource), typeof(VideoBox), null);
        public static readonly DependencyProperty VideoNameProperty = DependencyProperty.Register("VideoName", typeof(String), typeof(VideoBox), null);
        public static readonly DependencyProperty VideoIDProperty = DependencyProperty.Register("VideoID", typeof(String), typeof(VideoBox), null);

        public VideoBox()
        {
            DefaultStyleKey = typeof(VideoBox);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ContentPresenter presenter = this.GetTemplateChild("ContentContainer") as ContentPresenter;
        }

        public ImageSource Thumbnail
        {
            get { return GetValue(ThumbnailProperty) as ImageSource; }
            set { SetValue(ThumbnailProperty, value); }
        }
        public String VideoName
        {
            get { return GetValue(VideoNameProperty) as String; }
            set { SetValue(VideoNameProperty, value); }
        }
        public String VideoID
        {
            get { return GetValue(VideoIDProperty) as String; }
            set { SetValue(VideoIDProperty, value); }
        }
    }
}