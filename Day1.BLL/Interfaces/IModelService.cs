using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Day1.BLL.DTObjects;
namespace Day1.BLL.Interfaces
{
    public interface IModelService : IService<ModelDTO>
    {
        Task<IEnumerable<ModelDTO>> GetModelDTOs(string name, DateTime dateBefore, DateTime dateFrom, UserDTO user);
    }
}
