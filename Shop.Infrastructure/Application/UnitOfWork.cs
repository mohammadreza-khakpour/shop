using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructure
{
    public interface UnitOfWork
    {
        public void Complete();
    }
}
