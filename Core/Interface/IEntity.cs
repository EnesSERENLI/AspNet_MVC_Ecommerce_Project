using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IEntity<T> //If we want to change the ID type in the future, we can do it here.
    {
        T ID { get; set; }
    }
}
