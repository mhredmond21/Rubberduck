﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using Rubberduck.Navigation.CodeExplorer;

namespace Rubberduck.UI.CodeExplorer
{
    /// <summary>
    /// Interaction logic for CodeExplorerControl.xaml
    /// </summary>
    public partial class CodeExplorerControl : UserControl
    {
        public CodeExplorerControl()
        {
            InitializeComponent();
        }

        private CodeExplorerViewModel ViewModel { get { return DataContext as CodeExplorerViewModel; } }

        private void TreeView_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // todo: execute a NavigateCommand
        }
    }
}
