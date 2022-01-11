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
using System.Configuration;


namespace CRUD_LINQ
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DataClasses1DataContext dataContext;


        public MainWindow()
        {
            InitializeComponent();

            string miConexionSQL = ConfigurationManager.ConnectionStrings["CRUD_LINQ.Properties.Settings.ConexionEmpresa"].ConnectionString;

            dataContext = new DataClasses1DataContext(miConexionSQL);           

        }

        public void InsertaEmpresas()
        {
            Empresa Empresa1 = new Empresa();

        }
    }
}
