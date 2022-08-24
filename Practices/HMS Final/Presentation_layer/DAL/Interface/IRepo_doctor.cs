using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepo_doctor<CLASS,ID,RT>
    {
        List<CLASS> Get();

        CLASS Get(ID id);

        RT Create(CLASS obj);

        bool Update(CLASS obj);

        bool Delete(ID id);

    }
}
