using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Entities;

namespace Context
{
    public class FakeDbContext
    {
        public List<Usuario> UsersList = new List<Usuario>{
            new Usuario{Id = 1, Nombre="Ergo 1", NombreUsuario = "Ergo1", Celular = 3663223, Contrasena = "12131415", Correo ="qwe_1@qwe.com", Rol = new Roles{Id = 1, Nombre = "Usuario"}},
            new Usuario{Id = 2, Nombre="Ergo 2", NombreUsuario = "Ergo2", Celular = 3663224, Contrasena = "12131415", Correo ="qwe_2@qwe.com", Rol = new Roles{Id = 2, Nombre = "Administrador"}},
            new Usuario{Id = 3, Nombre="Ergo 3", NombreUsuario = "Ergo3", Celular = 3663225, Contrasena = "12131415", Correo ="qwe_3@qwe.com", Rol = new Roles{Id = 1, Nombre = "Usuario"}},
            new Usuario{Id = 4, Nombre="Ergo 4", NombreUsuario = "Ergo4", Celular = 3663226, Contrasena = "12131415", Correo ="qwe_4@qwe.com", Rol = new Roles{Id = 1, Nombre = "Usuario"}},
            new Usuario{Id = 5, Nombre="Ergo 5", NombreUsuario = "Ergo5", Celular = 3663227, Contrasena = "12131415", Correo ="qwe_5@qwe.com", Rol = new Roles{Id = 1, Nombre = "Usuario"}},
            new Usuario{Id = 6, Nombre="Ergo 6", NombreUsuario = "Ergo6", Celular = 3663228, Contrasena = "12131415", Correo ="qwe_6@qwe.com", Rol = new Roles{Id = 1, Nombre = "Usuario"}}
        }; 

        public List<Roles> RolesList = new List<Roles>{
            new Roles{Id = 1, Nombre = "Usuario"},
            new Roles{Id = 2, Nombre = "Administrador"}
        };

        public List<Log> LogsList = new List<Log>{
            new Log{Id = 1, Fecha = DateTime.Now, User = new Usuario{Id = 1, Nombre="Ergo 1", NombreUsuario = "Ergo1", Celular = 3663223, Contrasena = "12131415", Correo ="qwe@qwe.com", Rol = new Roles{Id = 1, Nombre = "Usuario"}}},
            new Log{Id = 2, Fecha = DateTime.Now.AddMinutes(2), User = new Usuario{Id = 1, Nombre="Ergo 1", NombreUsuario = "Ergo1", Celular = 3663223, Contrasena = "12131415", Correo ="qwe@qwe.com", Rol = new Roles{Id = 1, Nombre = "Usuario"}}},
            new Log{Id = 3, Fecha = DateTime.Now.AddMinutes(3), User = new Usuario{Id = 1, Nombre="Ergo 1", NombreUsuario = "Ergo1", Celular = 3663223, Contrasena = "12131415", Correo ="qwe@qwe.com", Rol = new Roles{Id = 1, Nombre = "Usuario"}}},
            new Log{Id = 4, Fecha = DateTime.Now.AddMinutes(4), User = new Usuario{Id = 1, Nombre="Ergo 1", NombreUsuario = "Ergo1", Celular = 3663223, Contrasena = "12131415", Correo ="qwe@qwe.com", Rol = new Roles{Id = 1, Nombre = "Usuario"}}},
        };
    }
}