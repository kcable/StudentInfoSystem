using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExample
{
    class MainWindowViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private ICommand hiButtonCommand;
        private ICommand toggleExecuteCommand
        { get; set; }
        private bool canExecute = true;
        public string HiButtonContent
        {
            get { return "click to hi"; }
        }



        private string text;
        public string textBlockContent
        {
            get
            {
                if (string.IsNullOrEmpty(text))
                {
                    return "notClickedYet";
                }
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("textBlockContent");
            }
        }
        public bool CanExecute
        {
            get { return this.canExecute; }
            set
            {
                if (this.canExecute == value)
                { return; }
                this.canExecute = value;
            }
        }
        public ICommand ToggleExecuteCommand
        {
            get
            { return toggleExecuteCommand; }
            set
            { toggleExecuteCommand = value; }
        }
        public ICommand HiButtonCommand
        {
            get
            { return hiButtonCommand; }
            set
            { hiButtonCommand = value; }
        }
        public MainWindowViewModel()
        {
            //textBlockContent = "l";
            HiButtonCommand = new RelayCommand(ShowMessage, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }
        public void ShowMessage(object obj)
        {
            //it is good we do this with binding to some control
            textBlockContent = obj.ToString() + DateTime.Now.ToLongDateString();
            // System.Windows.MessageBox.Show(textBlockContent);



        }
        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }
    }
}
