using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinAllianceApp.Models;
using XamarinAllianceApp.Controllers;

namespace XamarinAllianceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterDetailPage : ContentPage
    {

        public Character Item { get; set; }
        

        public CharacterDetailPage(Character item)
        {
            InitializeComponent();
            Item = item;
            Title = item.Name;
            BindingContext = this;
        }

        
            
           
        
    }
}
