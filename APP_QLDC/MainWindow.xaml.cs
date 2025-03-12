using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Linq;

namespace APP_QLDC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Member> currentmembers { get; set; }
        public ObservableCollection<Member> allmembers { get; set; }
        private int currentPage = 1;
        private int itemsPerPage = 10;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            var converter = new BrushConverter();
            
            currentmembers = new ObservableCollection<Member>();

            allmembers = new ObservableCollection<Member>
            {
                new Member { Character = "A", Name = "Sáng", SDT = "1234", so_nguoi_o = "2", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P101" },
                new Member { Character = "B", Name = "Quang", SDT = "1234", so_nguoi_o = "3", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P102" },
                new Member { Character = "C", Name = "Ngọc", SDT = "1234", so_nguoi_o = "4", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P103" },
                new Member { Character = "D", Name = "Quân", SDT = "1234", so_nguoi_o = "1", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P104" },
                new Member { Character = "E", Name = "Phúc", SDT = "1234", so_nguoi_o = "2", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P105" },
                new Member { Character = "F", Name = "Tuấn", SDT = "1234", so_nguoi_o = "2", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P106" },
                new Member { Character = "G", Name = "Vũ", SDT = "1234", so_nguoi_o = "3", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P107" },
                new Member { Character = "H", Name = "Nam", SDT = "1234", so_nguoi_o = "4", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P108" },
                new Member { Character = "I", Name = "Lâm", SDT = "1234", so_nguoi_o = "1", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P109" },
                new Member { Character = "J", Name = "Dương", SDT = "1234", so_nguoi_o = "2", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P1010" },

                new Member { Character = "A", Name = "Sáng", SDT = "1234", so_nguoi_o = "2", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P201" },
                new Member { Character = "B", Name = "Quang", SDT = "1234", so_nguoi_o = "3", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P202" },
                new Member { Character = "C", Name = "Ngọc", SDT = "1234", so_nguoi_o = "4", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P203" },
                new Member { Character = "D", Name = "Quân", SDT = "1234", so_nguoi_o = "1", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P204" },
                new Member { Character = "E", Name = "Phúc", SDT = "1234", so_nguoi_o = "2", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P205" },
                new Member { Character = "F", Name = "Tuấn", SDT = "1234", so_nguoi_o = "2", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P206" },
                new Member { Character = "G", Name = "Vũ", SDT = "1234", so_nguoi_o = "3", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P207" },
                new Member { Character = "H", Name = "Nam", SDT = "1234", so_nguoi_o = "4", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P208" },
                new Member { Character = "I", Name = "Lâm", SDT = "1234", so_nguoi_o = "1", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P209" },
                new Member { Character = "J", Name = "Dương", SDT = "1234", so_nguoi_o = "2", Bgcolor = (Brush)converter.ConvertFromString("#1098ad"), vitri = "P2010" },
            };

            // Creat new member
            
            
            LoadPage(currentPage);
            UpdateMember();

            //MemberDataGrid.ItemsSource = currentmembers;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void Border_MouseLeftButunDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void LoadPage(int page)
        {
            currentmembers.Clear();
            int startIndex = (page - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, allmembers.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                currentmembers.Add(allmembers[i]);
            }

            MemberDataGrid.ItemsSource = currentmembers;
            UpdateMember();
        }
        public void UpdateMember()
        {
            for (int i = 0; i < currentmembers.Count; i++)
            {
                currentmembers[i].STT = i + 1;
            }
        }


        private void addbutton_Click(object sender, RoutedEventArgs e)
        {
            addMember add = new addMember();
            add.ShowDialog();

            if(add.isAdd == true)
            {
                Member NewMember = add.NewMember;
                allmembers.Add(NewMember);
                UpdateMember();
            }
            MemberDataGrid.ItemsSource = currentmembers;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {          
            Button button = sender as Button;
            Member selectedMember = button.Tag as Member;
            // Lấy dữ liệu của hàng được chọn
            Change change = new Change(selectedMember);
            change.ShowDialog();

            if (selectedMember != null)
            {
                // Mở cửa sổ chỉnh sửa với dữ liệu của thành viên này
                Change editWindow = new Change(selectedMember);
                // Nếu người dùng bấm "Lưu"
                if (editWindow.isChange == true) 
                {   
                    // Cập nhật lại DataGrid
                    MemberDataGrid.Items.Refresh();
                }
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            currentPage--;
            if (currentPage < 1) currentPage = 1;
            LoadPage(currentPage);
            MessageBox.Show(currentPage.ToString());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            currentPage++;
            if(currentPage > 9) currentPage = 9;
            LoadPage(currentPage);
            MessageBox.Show(currentPage.ToString());
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Member memberToDelete)
            {
                // Xác nhận trước khi xóa
                MessageBoxResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa {memberToDelete.Name} không?",
                    "Xác nhận xóa",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {   
                    // Xóa khỏi danh sách
                    currentmembers.Remove(memberToDelete); 
                }               
            }
            MemberDataGrid.ItemsSource = null;
            MemberDataGrid.ItemsSource = currentmembers;
            UpdateMember();
        }

        
    }
    public class Member : INotifyPropertyChanged
    {   
        public int STT {  get; set; }
        private string? _name;
        private string? _sdt;
        private string? _soNguoiO;

        public string? Number { get; set; }
        public string? Character { get; set; }

        public string? Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string? SDT
        {
            get => _sdt;
            set
            {
                _sdt = value;
                OnPropertyChanged(nameof(SDT));
            }
        }

        public string? so_nguoi_o
        {
            get => _soNguoiO;
            set
            {
                _soNguoiO = value;
                OnPropertyChanged(nameof(so_nguoi_o));
            }
        }

        public string? vitri { get; set; }
        public Brush? Bgcolor { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}