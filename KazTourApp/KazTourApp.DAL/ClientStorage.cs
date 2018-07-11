using KazTourApp.Shared.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KazTourApp.DAL
{
    public class ClientStorage
    {
        public void AddClient(ClientRecord record)
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var clients = db.GetCollection<ClientRecord>("clients");
                clients.Insert(record);
            }
        }

        public List<ClientRecord> ReadAllClients()
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var clients = db.GetCollection<ClientRecord>("clients");
                return clients.FindAll().ToList();
            }
        }

        public void UpdateClient(int id, ClientRecord record)
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var clients = db.GetCollection<ClientRecord>("clients");
                clients.Update(id, record);
            }
        }

        public ClientRecord ReadClient(int id)
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var clients = db.GetCollection<ClientRecord>("clients");
                return clients.FindOne(x => x.Id == id);
            }
        }

        public void RemoveClient(int id)
        {
            using (var db = new LiteDatabase(@"С:\Users\Dakosia\source\repos\CSharp\KazTourApp\KazTourApp.DAL\LiteDb.db"))
            {
                var clients = db.GetCollection<ClientRecord>("clients");
                clients.Delete(id);
            }
        }
    }
}
