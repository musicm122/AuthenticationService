using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HackerFerretSoftware.SendOwl.Model
{
    public class License
    {
        public int id { get; set; }
        public int order_id { get; set; }
        public int product_id { get; set; }
        public string key { get; set; }
        public bool order_refunded { get; set; }
    }

    public class LicenseWrapper
    {
        public License license { get; set; }
    }


    public class Attachment
    {
        public string filename { get; set; }
        public int size { get; set; }
    }

    public class Product
    {
        public int id { get; set; }
        public string product_type { get; set; }
        public string name { get; set; }
        public bool pdf_stamping { get; set; }
        public string sales_limit { get; set; }
        public string self_hosted_url { get; set; }
        public string license_type { get; set; }
        public string license_fetch_url { get; set; }
        public string shopify_variant_id { get; set; }
        public string custom_field { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string price { get; set; }
        public string currency_code { get; set; }
        public string product_image_url { get; set; }
        public Attachment attachment { get; set; }
        public string instant_buy_url { get; set; }
        public string add_to_cart_url { get; set; }
    }

    public class ProductWrapper
    {
        public Product product { get; set; }
    }
}
