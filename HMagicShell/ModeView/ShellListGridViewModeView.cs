﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMagicShell.ModeView
{
    class ShellListGridViewModeView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string m_strShellAddress = "";
        private DateTime m_dateCreateTime = DateTime.Now;
        private string m_strPassWord = "";

        public ShellListGridViewModeView()
        {

        }

        public ShellListGridViewModeView(string address, DateTime dateTime)
        {
            m_strShellAddress = address;
            m_dateCreateTime = dateTime;
        }
        public string ShellAddress
        {
            get => m_strShellAddress;

            set
            {
                m_strShellAddress = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ShellAddress)));
            }
        }

        public DateTime CreateTime
        {
            get => m_dateCreateTime;

            set
            {
                m_dateCreateTime = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CreateTime)));
            }
        }

        public string PassWord
        {
            get => m_strPassWord;

            set
            {
                m_strPassWord = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PassWord)));
            }
        }
    }
}
