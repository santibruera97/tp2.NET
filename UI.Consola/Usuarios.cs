using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
    
        public UsuarioLogic UsuarioNegocio
        {
            get;
            set;
        } 

        public Usuarios()
        {
            UsuarioNegocio = new UsuarioLogic();
        }

        public void Menu()
        {
            Console.WriteLine("Menu Principal");
            Console.WriteLine("1-Listado General");
            Console.WriteLine("2-Consulta");
            Console.WriteLine("3-Agregar");
            Console.WriteLine("4-Modificar");
            Console.WriteLine("5-Eliminar");
            Console.WriteLine("6-Salir");
            ConsoleKeyInfo op = Console.ReadKey();  
            switch(op.Key){
                case ConsoleKey.D1: 
                    ListadoGeneral();
                    break;
                case ConsoleKey.D2:
                    Consultar();
                    break;
                case ConsoleKey.D3:
                   Agregar();
                    break;
                case ConsoleKey.D4:
                    Modificar();
                    break;
                case ConsoleKey.D5:
                    Eliminar();
                    break;
                
            }
            
            
            
            while (op.Key != ConsoleKey.D6)
            {
                Console.Clear();
                Console.WriteLine("Menu Principal");
                Console.WriteLine("1-Listado General");
                Console.WriteLine("2-Consulta");
                Console.WriteLine("3-Agregar");
                Console.WriteLine("4-Modificar");
                Console.WriteLine("5-Eliminar");
                Console.WriteLine("6-Salir");
                op = Console.ReadKey();
                switch (op.Key)
                {
                    case ConsoleKey.D1:
                        ListadoGeneral();
                        break;
                    case ConsoleKey.D2:
                        Consultar();
                        break;
                    case ConsoleKey.D3:
                       Agregar();
                        break;
                    case ConsoleKey.D4:
                        Modificar();
                        break;
                    case ConsoleKey.D5:
                        Eliminar();
                        break;
                    
                }
            } 
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            foreach(Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
            Console.ReadKey();
        }

        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}",usr.ID);
            Console.WriteLine("\t\tNombre: {0}",usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}",usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.EMail);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
        

        } 

        public void Consultar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del Usuario a Consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
                Console.ReadKey();
            } 
            catch(FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("El ID ingresado debe ser un entero");
            } 
            catch(Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }
        
        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a modificar");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.WriteLine("Ingrese nombre");
                usuario.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese apellido");
                usuario.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese nombre de usuario");
                usuario.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese E-mail");
                usuario.EMail = Console.ReadLine();
                Console.WriteLine("Ingrese clave");
                usuario.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese habilitacion de Usuario (1-Si / otro - No)");
                usuario.Habilitado = Console.ReadLine()=="1";
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario); 
            }
            catch(FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("El ID ingresado debe ser un entero");
            } 
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        } 

        public void Agregar()
        {
            Usuario usuario = new Usuario();
            Console.Clear();
            Console.WriteLine("Ingrese nombre");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese apellido");
            usuario.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese nombre de usuario");
            usuario.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese E-mail");
            usuario.EMail = Console.ReadLine();
            Console.WriteLine("Ingrese clave");
            usuario.Clave = Console.ReadLine();
            Console.WriteLine("Ingrese habilitacion de Usuario (1-Si / otro - No)");
            usuario.Habilitado = Console.ReadLine() == "1";
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}:", usuario.ID);
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del Usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("El ID ingresado debe ser un entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }


    }
}
