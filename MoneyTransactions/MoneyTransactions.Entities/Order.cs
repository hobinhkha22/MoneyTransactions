using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.Entities
{
    public class Order
    {
        [Key]
        [JsonProperty("OrderID")]
        public Guid OrderID { get; set; }
        [Required]
        [JsonProperty("Amount")]
        [DisplayFormat(DataFormatString = "{0:N5}", ApplyFormatInEditMode = true)]
        public decimal Amount { get; set; }
        [Required]
        [JsonProperty("Price")]
        public decimal Price { get; set; }
        [Required]
        [JsonProperty("CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }
        [Required]
        [JsonProperty("WalletID")]
        public Guid WalletID { get; set; }

        [JsonProperty("OrderType")]
        public string OrderType { get; set; }

        //[JsonProperty("Wallet")]
        //[JsonIgnore]
        public virtual Wallet Wallet { get; set; }

        //[JsonProperty("OrderDetails")]
        //[JsonIgnore]        
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
