using PSP.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace PSP.Interfaces
{
    public interface IClientService
    {
        List<Client> GetAll();
        Client GetById(Guid id);
        Client Create(Client client);

        Client Update(Guid id, Client client);
        void Delete(Guid id);
    }
}
