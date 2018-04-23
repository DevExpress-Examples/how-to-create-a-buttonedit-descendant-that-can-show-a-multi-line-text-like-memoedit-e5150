using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace MultilineButtonEditExample {
    public partial class MainForm : DevExpress.XtraEditors.XtraForm {

        ProductList productList;

        public MainForm() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            productList = new ProductList(20);
            gcProductList.DataSource = productList;
        }
    }

    public class Product {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string MultiLineDescription { get; set; }

        public Product(int index) {
            Name = "Name " + index;
            ShortDescription = "This is a short description for " + Name;
            MultiLineDescription = " This is a first line, \r\n a second line \r\n, a third line of long description for " + Name;
        }
    }

    public class ProductList : BindingList<Product> {
        public ProductList(int count) {
            for(int i = 0; i < count; i++)
                Items.Add(new Product(i));
        }
    }
}
