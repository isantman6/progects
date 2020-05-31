using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DomainModels
{
   public class ItemCore
    {
        int Id { get; set; }

        string Name { get; set; }
        string Author { get; set; }
        float Price { get; set; }

    }
}
