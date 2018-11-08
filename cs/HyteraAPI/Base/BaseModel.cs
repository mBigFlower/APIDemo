using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyteraAPI.Base
{
    public class BaseModel : INotifyPropertyChanged
    {
        public static event Action NotifyRevised;

        public event PropertyChangedEventHandler PropertyChanged;
        virtual internal protected void OnPropertyChanged(string propertyName)
        {
            if(this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        bool isRevised;

        public bool IsRevised
        {
            get
            {
                return isRevised;
            }

            set
            {
                isRevised = value;
            }
        }
        virtual internal protected void OnRevised(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                IsRevised = true;
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        public BaseModel()
        {
        }


        public void Dispose()
        {
            Messenger.Default.Unregister(this);
        }
    }
}
