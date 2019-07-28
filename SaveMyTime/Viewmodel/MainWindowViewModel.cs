using SaveMyTime.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SaveMyTime.Viewmodel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private string currentTime;

        public string CurrentTime
        {
            get { return currentTime; }
            set
            {
                currentTime = value;
                NotifyPropertychanged("CurrentTime");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertychanged(String propertyname) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));

        public MainWindowViewModel()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += GetTime;
            bw.RunWorkerAsync();
        }

        /// <summary>
        /// Starts the endless loop for 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetTime(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                CurrentTime = DateTimeHelper.GetCurrentDateTime();
                Thread.Sleep(1000);
            }
        }
    }
}
