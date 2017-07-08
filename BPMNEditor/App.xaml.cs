using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using BPMNEditor.Views;


namespace BPMNEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            this.DispatcherUnhandledException += AppGlobalDispatcherUnhandledException;
        }

        private void AppGlobalDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            
        }
    }
}
