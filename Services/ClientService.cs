using Microsoft.EntityFrameworkCore;
using PSP.Data;
using PSP.Exceptions;
using PSP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSP.Services
{
    public class ClientService : IClientService
    {
        private readonly AppDbContext _context;

        private IQueryable<Client> Clients => _context.Clients;

        public ClientService(AppDbContext context)
        {
            _context = context;
        }

        public List<Client> GetAll()
        {
            return Clients.ToList();
        }

        public Client GetById(Guid id)
        {
            return _context.Find<Client>(id);
        }

        public Client Create(Client client)
        {
            client.clientId = new Guid();
            _context.Add<Client>(client);
            _context.SaveChanges();
            return client;
        }

        public Client Update(Guid id, Client client)
        {
            if (id != client.clientId)
            {
                throw new SqlException("id does not match the received model id");
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
                {
                    throw new SqlException("Model with this id does not exist");
                }
                else
                {
                    throw new SqlException("SQL ERROR");
                }
            }
            return client;
        }
     

        public void Delete(Guid id)
        {
            var client = _context.Clients.Find(id);
            if (client == null)
            {
                throw new SqlException("Model does not exists");
            }

            _context.Clients.Remove(client);
            _context.SaveChanges();
        }

        private bool ClientExists(Guid id)
        {
            return _context.Clients.Any(e => e.clientId == id);
        }
    }
}
