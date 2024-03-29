﻿using fmacias.Components.MVPVMModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControlLibraryDummyJobQueue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DummyFifoJobQueue : Window
    {
        private readonly IPresenter<DummyFifoJobQueue> presenter;
        public DummyFifoJobQueue(IPresenter<DummyFifoJobQueue> presenter)
        {
            InitializeComponent();
            this.presenter = presenter;
            presenter.SetView(this);
        }
        public IPresenter<DummyFifoJobQueue> Presenter => presenter;
    }
}
