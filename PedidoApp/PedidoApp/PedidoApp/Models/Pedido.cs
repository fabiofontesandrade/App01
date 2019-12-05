using SQLite;

namespace PedidoApp.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Titulo{ get; set; }
        public decimal Preco { get; set; }
        public string Link { get; set; }
        public string Descricao { get; set; }
    }
}
