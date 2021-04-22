using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s4_oop_6_7_8_9
{
    partial class ViewModel
    {

        // кнопки
        bool isAddButtonVisible;
        public bool IsAddButtonVisible
        {
            get => isAddButtonVisible;
            set
            {
                isAddButtonVisible = value;
                OnPropertyChanged("IsAddButtonVisible");
            }
        }

        bool isResetButtonVisible;
        public bool IsResetButtonVisible
        {
            get => isResetButtonVisible;
            set
            {
                isResetButtonVisible = value;
                OnPropertyChanged("IsResetButtonVisible");
            }
        }

        bool isEditButtonVisible;
        public bool IsEditButtonVisible
        {
            get => isEditButtonVisible;
            set
            {
                isEditButtonVisible = value;
                OnPropertyChanged("IsEditButtonVisible");
            }
        }

        bool isDeleteButtonVisible;
        public bool IsDeleteButtonVisible
        {
            get => isDeleteButtonVisible;
            set
            {
                isDeleteButtonVisible = value;
                OnPropertyChanged("IsDeleteButtonVisible");
            }
        }

        bool isSaveButtonVisible;
        public bool IsSaveButtonVisible
        {
            get => isSaveButtonVisible;
            set
            {
                isSaveButtonVisible = value;
                OnPropertyChanged("IsSaveButtonVisible");
            }
        }

        public void ToNewMode()
        {
            IsAddButtonVisible = true;
            IsResetButtonVisible = true;
            IsEditButtonVisible = false;
            IsDeleteButtonVisible = false;
            IsSaveButtonVisible = false;
        }

        public void ToViewMode()
        {
            IsAddButtonVisible = false;
            IsResetButtonVisible = false;
            IsEditButtonVisible = true;
            IsDeleteButtonVisible = true;
            IsSaveButtonVisible = false;
        }

        public void ToEditMode()
        {
            IsAddButtonVisible = false;
            IsResetButtonVisible = false;
            IsEditButtonVisible = false;
            IsDeleteButtonVisible = true;
            IsSaveButtonVisible = true;
        }
    }
}
