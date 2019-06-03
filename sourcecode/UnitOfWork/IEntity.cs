using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Models;

namespace UnitOfWork
{
    public interface IEntity
    {
        void Insert();
        void Update();
        List<IEntity> Load();
    }
}
