using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AngelSixMVVM.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string boldTitle = "AVALONIA";

        [ObservableProperty]
        private string regularTitle = "LOUDNESS METER";

        [ObservableProperty]
        private bool channelConfigListOpen = false;

        [RelayCommand]
        private void ChannelConfigBtnClick() => ChannelConfigListOpen ^= true;

        public MainWindowViewModel()
        {
            //Task.Run(async () =>
            //{
            //    await Task.Delay(2000);
            //    BoldTitle = "NEW TITLE";
            //});
        }
    }
}
