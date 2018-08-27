using System.Collections;
using System.Collections.Generic;

namespace Paylocity.Controllers
{
    public class Cost
    {
        public Cost()
        {
            Items = new List<Item>();
        }
        public decimal Total { get; set; }
        public List<Item> Items { get; private set; }
}
}