using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    internal class ToDoModel : INotifyPropertyChanged
    {
        public bool _isDone;
        public string _text;
        public DateTime CraetionDate { get; set; } = DateTime.Now;

        public bool IsDone
        {
            get { return _isDone; }
            set
            {
                if (_isDone == value)
                    return;
                _isDone = value;
                OnPropertyChanged("IsDone");
            }
        }
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                    return;
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propName = " ")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        }
    }
}
