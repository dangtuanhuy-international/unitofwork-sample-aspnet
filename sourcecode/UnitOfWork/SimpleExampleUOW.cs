using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace UnitOfWork
{
    public class SimpleExampleUOW<T> where T : IEntity
    {
        private List<IEntity> Changed = new List<IEntity>();
        private List<IEntity> New = new List<IEntity>();

        public void Add(IEntity obj)
        {
            New.Add(obj);
        }

        public void Committ()
        {
            var isCommit = false;
            using (TransactionScope scope = new TransactionScope())
            {
                if (Changed != null)
                {
                    isCommit = true;
                    foreach (IEntity o in Changed)
                        o.Update();
                }

                if (New != null)
                {
                    isCommit = true;
                    foreach (IEntity o in New)
                        o.Insert();
                }

                if (isCommit)
                    scope.Complete();
            }
        }

        public  void Load(IEntity o)
        {
            Changed  = o.Load() as List<IEntity>;
        }
    }
}
