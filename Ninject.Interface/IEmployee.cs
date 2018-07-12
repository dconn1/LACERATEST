using Ninject.Model;
using System.Collections.Generic;

namespace Ninject.Interface
{
    public interface IEmployee
    {
        IEnumerable<EmployeeModel> GetAll();
        void Add(EmployeeModel model);
        void DeleteAll();
    }
}
