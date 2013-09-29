using Microsoft.Phone.Controls;
using System.Windows.Navigation;

namespace FSF.Pages
{
    public partial class Videos : PhoneApplicationPage
    {
        public Videos()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("source"))
            {
                switch (NavigationContext.QueryString["source"])
                {
                    case "fil": txt_title.Text = "FILMS"; break;
                    case "ske": txt_title.Text = "SKETCHES"; break;
                    case "cot": txt_title.Text = "COMMENTS OF THE WEEK"; break;
                    case "bts": txt_title.Text = "BEHIND THE SCENES"; break;
                    case "wir": txt_title.Text = "WEEKS IN REVIEW"; break;
                }
            }
        }
    }
}