using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Windows;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Controls;

namespace s4_oop_6_7_8_9
{
    // в этом файле вся логика переключения между разными режимами
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


        private RelayCommand toAddModeCommand;
        public RelayCommand ToAddModeCommand
        {
            get
            {
                return toAddModeCommand ??
                    (toAddModeCommand = new RelayCommand(
                        obj =>
                        {
                            ToAddMode();
                            buffItem = ItemFabric.GetEmptyItem();
                            SelectedItem = buffItem;
                        }
                        ));
            }
        }

        private RelayCommand toEditModeCommand;
        public RelayCommand ToEditModeCommand
        {
            get
            {
                return toEditModeCommand ??
                    (toEditModeCommand = new RelayCommand(
                        obj =>
                        {
                            ToEditMode();
                            buffItem = SelectedItem.GetCopy();
                        },
                        obj =>
                        {
                            return !SelectedItem.IsNull() && SelectedItem.ItemVisibility;
                        }
                        ));
            }
        }

        private void ToAddMode()
        {
            IsAddButtonVisible = true;
            IsResetButtonVisible = true;
           
            IsDeleteButtonVisible = false;
            IsEditButtonVisible = false;
            IsSaveButtonVisible = false;
        }

        private bool InAddMode()
        {
            return IsAddButtonVisible && IsResetButtonVisible && !IsDeleteButtonVisible && !IsEditButtonVisible && !IsSaveButtonVisible;
        }

        //public void ToViewMode()
        //{
        //    IsAddButtonVisible = false;
        //    IsResetButtonVisible = false;
        //    IsEditButtonVisible = true;
        //    IsDeleteButtonVisible = true;
        //    IsSaveButtonVisible = false;
        //}

        private void ToEditMode()
        {
            IsResetButtonVisible = true;
            IsDeleteButtonVisible = true;

            IsAddButtonVisible = false;
            IsEditButtonVisible = false;
            IsSaveButtonVisible = false;
        }

        private bool InEditMode()
        {
            return IsDeleteButtonVisible && IsResetButtonVisible && !IsAddButtonVisible && !IsEditButtonVisible && !IsSaveButtonVisible;
        }
    }
}
