using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS.services;
namespace GUI
{
    public partial class Brand : Form
    {
        BrandService brandService = new BrandService();
        public Brand()
        {
            InitializeComponent();
            IEnumerable<Brand> brands = brandService.GetAll();
        }
    }
}
