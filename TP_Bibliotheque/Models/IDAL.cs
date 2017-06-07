using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Bibliotheque.Models
{
    // DAL
    // Data Access Layer

    // CRUD
    // Create Read Update Delete
    interface IDal<T> : IDisposable
    {

        void Add(T element);

        T Read(int id);

        void Update(int id, T element);

        void Delete(int id);

        List<T> GetAll();

        void DeleteAll();
    }
}
