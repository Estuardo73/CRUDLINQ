using System;
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

            //InsertaEmpresas();
            // InsertarEmpleados();
            //InsertarCargo();
            //AsignarCargos();
            MostrarInformacion();
            //ActualizaEmpleado();
            //DeleteEmpleado();

            ShowData();

        }

        public void InsertaEmpresas()
        {
           /*dataContext.ExecuteCommand("delete from empresa");

            Empresa Empresa1 = new Empresa();
            Empresa1.Nombre = "Empresa 1 de Empresas";
            dataContext.Empresa.InsertOnSubmit(Empresa1);

            Empresa Empresa2 = new Empresa();
            Empresa2.Nombre = "Empresa 2 de Empresas";
            dataContext.Empresa.InsertOnSubmit(Empresa2);

            dataContext.SubmitChanges();*/

            Principal.ItemsSource = dataContext.Empresa;
        }

        public void InsertarEmpleados()
        {


           /* Empresa Empresa1 = dataContext.Empresa.First(em => em.Nombre.Equals("Empresa 1 de Empresas"));
            Empresa Empresa2 = dataContext.Empresa.First(em => em.Nombre.Equals("Empresa 2 de Empresas"));

            List<Empleado> listaEmp = new List<Empleado>();

            listaEmp.Add(new Empleado { Nombre = "Carlos", Apellido = "Lopez", IdEmpresa = Empresa1.Id });
            listaEmp.Add(new Empleado { Nombre = "Estuardo", Apellido = "Roca",IdEmpresa = Empresa1.Id });

            listaEmp.Add(new Empleado { Nombre = "Carlos", Apellido = "Lopez", IdEmpresa = Empresa2.Id });
            listaEmp.Add(new Empleado { Nombre = "Estuardo", Apellido = "Roca", IdEmpresa = Empresa2.Id });

            dataContext.Empleado.InsertAllOnSubmit(listaEmp);
            
            Empleado Emp1 = new Empleado();
            Emp1.Nombre = "Carlos";
            Emp1.Apellido = "Lopez Roca";
            Emp1.IdEmpresa = 4;
            dataContext.Empleado.InsertOnSubmit(Emp1);

            dataContext.SubmitChanges();*/

            Principal.ItemsSource = dataContext.Empleado;

        }

        public void InsertarCargo()
        {

            dataContext.ExecuteCommand("delete from Cargo");

            List<Cargo> cargos = new List<Cargo>();
            cargos.Add(new Cargo { NombreCargo = "Gerente de Sistemas" });
            cargos.Add(new Cargo { NombreCargo = "Director" });
            cargos.Add(new Cargo { NombreCargo = "Gerente de Calidad" });
            cargos.Add(new Cargo { NombreCargo = "Abogado"});
            dataContext.Cargo.InsertAllOnSubmit(cargos);            
            dataContext.Cargo.InsertOnSubmit(new Cargo { NombreCargo = "Asistente de Gerencia" });            
            dataContext.SubmitChanges();
            Principal.ItemsSource = dataContext.Cargo;
        }

        public void AsignarCargos()
        {
            List<CargoEmpleado> cargosEmp = new List<CargoEmpleado>();
            cargosEmp.Add(new CargoEmpleado { IdEmpleado = 3, IdCargo = 5 });
            cargosEmp.Add(new CargoEmpleado { IdEmpleado = 4, IdCargo = 6 });
            cargosEmp.Add(new CargoEmpleado { IdEmpleado = 5, IdCargo = 7 });
            cargosEmp.Add(new CargoEmpleado { IdEmpleado = 6, IdCargo = 8 });
            cargosEmp.Add(new CargoEmpleado { IdEmpleado = 7, IdCargo = 9 });

            dataContext.CargoEmpleado.InsertAllOnSubmit(cargosEmp);
            dataContext.SubmitChanges();
            Principal.ItemsSource = dataContext.CargoEmpleado;                     


        }

        public void  MostrarInformacion()
        {
            Principal.ItemsSource = dataContext.v_informacion;
        }

        public void ActualizaEmpleado()
        {
            Empleado buscar = dataContext.Empleado.First(em => em.Id.Equals(3));

            buscar.Nombre = "Carlos Estuardo";
            dataContext.SubmitChanges();
            MostrarInformacion();
        }

        public void DeleteEmpleado()
        {
            Empleado buscar = dataContext.Empleado.First(em => em.Id.Equals(7));
            dataContext.Empleado.DeleteOnSubmit(buscar);
            dataContext.SubmitChanges();
            MostrarInformacion();

        }

        public void ShowData()
        {
            vistaEmp.ItemsSource = dataContext.Empleado;
        }
    }
}
