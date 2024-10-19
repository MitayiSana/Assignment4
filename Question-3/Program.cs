using Question_3;

namespace Question_3
{
    public enum CommodityCategory
    {
        Furniture,
        Grocery,
        Service

    }
    public class Commodity
    {
        public Commodity(CommodityCategory category, string commodityName, int commodityQuantity, double commodityPrice)
        {
            Category = category;
            CommodityName = commodityName;
            CommodityQuantity = commodityQuantity;
            CommodityPrice = commodityPrice;
        }
        public CommodityCategory Category { get; set; }
        public string CommodityName { get; set; }
        public int CommodityQuantity { get; set; }
        public double CommodityPrice { get; set; }
    }
    public class PrepareBill
    {
        private readonly IDictionary<CommodityCategory, double> _taxRates;
        public PrepareBill()
        {
            _taxRates = new Dictionary<CommodityCategory, double>();
        }
        public void SetTaxRates(CommodityCategory category, double taxRate)
        {
            if (!_taxRates.ContainsKey(category))
            {
                _taxRates.Add(category, taxRate);
            }
        }
        public double CalculateBillAmount(IList<Commodity> items)
        {
            double total = 0;

            foreach (var item in items)
            {
                double price = 0, tax = 0;
                try
                {
                    if (!_taxRates.ContainsKey(item.Category))
                    {
                        throw new Exception();
                    }
                    else
                    {
                        price = item.CommodityPrice * item.CommodityQuantity;
                        tax = ((item.CommodityPrice * _taxRates[item.Category]) / 100) * item.CommodityQuantity;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                total += price + tax;
            }
            return total;
        }
    }
}
public class Program
{
    static void Main(string[] args)
    {
        var commodities = new List<Commodity>()
        {
          new Commodity(CommodityCategory.Furniture,"Bed",2,50000),
          new Commodity(CommodityCategory.Grocery,"Flour",5,80),
          new Commodity(CommodityCategory.Service,"Insurance",8,8500),
        };
        var PrepareBill = new PrepareBill();
        PrepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
        PrepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
        PrepareBill.SetTaxRates(CommodityCategory.Service, 12);

        var billAmount = PrepareBill.CalculateBillAmount(commodities);
        Console.WriteLine($"{billAmount}");
    }
}
