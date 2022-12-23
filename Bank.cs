using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSystem
{
    public class Bank
    {
        private static ulong clientsCounter;

        private readonly Dictionary<ulong, Client> clients = new Dictionary<ulong, Client>();

        public const string IdClientAmountMessage= "no client with this id";

        public List<Client> GetClients()
        {
            return clients.Values.ToList();
        }

        public Client GetClient(ulong id)
        {
            Client client;
            if (!clients.TryGetValue(id, out client))
            {
                throw new ArgumentOutOfRangeException("dictionary empty");
            }

            return client;
        }

        public void AddClient(Client client)
        {
            client.ID = ++clientsCounter;
            clients[client.ID] = client;
        }

        public void DeleteClient(ulong id)
        {
            if (!clients.ContainsKey(id))
            {

                throw new ArgumentOutOfRangeException("id", id,
                    "dictionary empty");
            }
            clients.Remove(id);

            clientsCounter = --clientsCounter;
        }
    }
}
