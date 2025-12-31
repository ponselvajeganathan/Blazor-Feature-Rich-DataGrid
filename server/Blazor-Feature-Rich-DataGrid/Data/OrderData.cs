using Microsoft.AspNetCore.Components;

namespace BlazorGrid.Data
{
    public class OrderData
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public int Quantity { get; set; }
        public double Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }

        public string ShipAddress { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public bool Verified { get; set; }
        public bool TrackingStatus { get; set; }
        public double Rating { get; set; }
        public string EmailID { get; set; }

        public string Genders { get; set; }

        public double ImageIndex { get; set; }

    }

  
}
