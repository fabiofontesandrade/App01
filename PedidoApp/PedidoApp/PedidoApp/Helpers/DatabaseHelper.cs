using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using PedidoApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace PedidoApp.Helpers
{
    public class DatabaseHelper
    {
        static SQLiteConnection sqlLiteConnection;
        public const string dbFileName = "PedidosDB.db";

        public DatabaseHelper()
        {
            //cria uma pasta base local para o dispositivo
            var pasta = new LocalRootFolder();
            //cria o arquivo
            var arquivo = pasta.CreateFile(dbFileName, CreationCollisionOption.OpenIfExists);
            //abre o DB
            sqlLiteConnection = new SQLiteConnection(arquivo.Path);
            //cria a tabela no BD
            sqlLiteConnection.CreateTable<Pedido>();
        }

        public List<Pedido> GetAllPedidos()
        {
            return (from data in sqlLiteConnection.Table<Pedido>()
                    select data).ToList();
        }

        public Pedido GetPedido(int id)
        {
            return sqlLiteConnection.Table<Pedido>().FirstOrDefault(t => t.Id == id);
        }

        public void DeleteAllPedidos()
        {
            sqlLiteConnection.DeleteAll<Pedido>();
        }

        public void DeletePedido(int id)
        {
            sqlLiteConnection.Delete<Pedido>(id);
        }

        public void InsertPedido(Pedido pedido)
        {
            sqlLiteConnection.Insert(pedido);
        }

        public void UpdatePedido(Pedido pedido)
        {
            sqlLiteConnection.Update(pedido);
        }
    }
}
