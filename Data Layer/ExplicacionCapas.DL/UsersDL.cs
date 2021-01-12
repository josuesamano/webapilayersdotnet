using ExplicacionCapas.Transversal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExplicacionCapas.DL
{
    public class UsersDL
    {
        private static List<UserEntity> Users = new List<UserEntity>
        {
            new UserEntity { Id = 1, Nombre = "Enrique", ApellidoPaterno = "Gómez", ApellidoMaterno = null, FechaNacimiento = new DateTime(1993, 12, 12) },
            new UserEntity { Id = 2, Nombre = "Elizabeth", ApellidoPaterno = "González", ApellidoMaterno = null, FechaNacimiento = new DateTime(1993, 12, 12) },
            new UserEntity { Id = 3, Nombre = "Francisco", ApellidoPaterno = "Zamora", ApellidoMaterno = null, FechaNacimiento = new DateTime(1993, 12, 12) },
            new UserEntity { Id = 4, Nombre = "Sandra", ApellidoPaterno = "Quintana", ApellidoMaterno = null, FechaNacimiento = new DateTime(1993, 12, 12) },
            new UserEntity { Id = 5, Nombre = "Daniel", ApellidoPaterno = "Cerrato", ApellidoMaterno = null, FechaNacimiento = new DateTime(1993, 12, 12) }
        };

        public IEnumerable<UserEntity> GetUsers()
        {
            return Users;
        }

        public UserEntity GetUser(int id)
        {
            return Users.Find(x => x.Id == id);
        }

        public bool ExistUser(string nombre)
        {
            return Users.Where(x => x.Nombre == nombre).Any();
        }

        public int GetLastId() 
        {
            return Users.OrderByDescending(x => x.Id).Select(x => x.Id).First();
        }

        public void Create(UserEntity entity) 
        {
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }

            entity.Id = GetLastId() + 1;

            Users.Add(entity);
        }

        public void Update(int id, UserEntity entity) 
        {
            if (id == 0)
            {
                throw new Exception("id not found");
            }

            if (entity == null)
            {
                throw new Exception("Entity not found");
            }

            var user = GetUser(id);

            if (user == null)
            {
                throw new Exception("Record not found");
            }

            user.Nombre = entity.Nombre;
            user.ApellidoPaterno = entity.ApellidoPaterno;
            user.ApellidoMaterno = entity.ApellidoMaterno;
            user.FechaNacimiento = entity.FechaNacimiento;
        }

        public void Delete(int id) 
        {
            if (id == 0)
            {
                throw new Exception("id not found");
            }

            var user = GetUser(id);

            if (user == null)
            {
                throw new Exception("Record not found");
            }

            Users.Remove(user);
        }
    }
}
