using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Primitives;

namespace Template.Infrastructure.Mappers
{
    public interface IMapper<T> where T: IEntity
    {
    }
}
