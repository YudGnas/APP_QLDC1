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
    /// Interaction logic for Change.xaml
    /// </summary>
    public partial class Change : Window
    {   
        private Member member;
        public bool isChange;
        public Change(Member selectedMember)
        {
            InitializeComponent();
            member = selectedMember;

            // Load dữ liệu cũ lên form
            txtCharacter.Text = member.Character;
            txtName.Text = member.Name;
            txtSDT.Text = member.SDT;
            txtSoNguoiO.Text = member.so_nguoi_o;
            txtViTri.Text = member.vitri;
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
            member.Character = txtCharacter.Text;
            member.Name = txtName.Text;
            member.SDT = txtSDT.Text;
            member.so_nguoi_o = txtSoNguoiO.Text;
            member.vitri = txtViTri.Text;

            this.isChange = true; // Trả kết quả về MainWindow
            this.Close();
        }
    }
}
