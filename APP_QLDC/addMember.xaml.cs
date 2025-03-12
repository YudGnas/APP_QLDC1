using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace APP_QLDC
{
    /// <summary>
    /// Interaction logic for addMember.xaml
    /// </summary>
    public partial class addMember : Window
    {
        public Member NewMember { get; private set; }
        public bool isAdd;
        public addMember()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void Border_MouseLeftButunDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NewMember = new Member
            {
                Character = txtCharacter.Text,
                Name = txtName.Text,
                SDT = txtSDT.Text,
                so_nguoi_o = txtSoNguoiO.Text,
                vitri = txtViTri.Text,
                Bgcolor = System.Windows.Media.Brushes.LightBlue // Màu mặc định
            };

            this.isAdd = true; // Đánh dấu là đã nhập thành công
            this.Close();
        }
    }
}
