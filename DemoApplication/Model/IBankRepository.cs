using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApplication.Model
{
    public interface IBankRepository
    {
        public Task<List<Bank>> GetBank();
    }
}
