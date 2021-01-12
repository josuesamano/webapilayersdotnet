using ExplicacionCapas.DL;
using ExplicacionCapas.Transversal.Entities;
using System.Collections.Generic;

namespace ExplicacionCapa.BL
{
    public class UsersBL
    {
        private readonly UsersDL _usersDL;

        public UsersBL()
        {
            _usersDL = new UsersDL();
        }

        public IEnumerable<UserEntity> GetUsers() 
        {
            return _usersDL.GetUsers();
        }

        public UserEntity GetUser(int id) 
        {
            return _usersDL.GetUser(id);
        }

        public void Create(UserEntity entity) 
        {
            if (_usersDL.ExistUser(entity.Nombre))
            {
                throw new System.Exception("Name exist");
            }

            _usersDL.Create(entity);
        }

        public void Update(int id, UserEntity entity)
        {
            _usersDL.Update(id, entity);
        }

        public void Delete(int id)
        {
            _usersDL.Delete(id);
        }
    }
}
