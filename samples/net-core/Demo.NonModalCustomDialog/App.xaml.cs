﻿using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using MvvmDialogs;

namespace Demo.NonModalCustomDialog
{
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SimpleIoc.Default.Register<IDialogService>(() => new DialogService());
        }
    }
}