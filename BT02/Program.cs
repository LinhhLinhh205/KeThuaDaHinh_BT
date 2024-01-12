using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT02
{
    class SanPham
    {
        private string _ten;
        private double _giamua;

        public string Ten
        {
            get { return _ten; }

        }
        public double Giamua
        {
            get { return _giamua; }
            set
            {
                if (value >= 0)
                    _giamua = value;
            }
        }
        public SanPham()
        {
        }
        public SanPham(string ten, double giamua)
        {
            this._ten = ten;
            this._giamua = giamua;
        }
        public virtual double TinhGiaBan()
        {
            return 0;
        }
        public virtual void InChiTiet()
        {
            Console.WriteLine($"Ten san pham:{_ten}");
        }
        public virtual void Nhap()
        {
            Console.Write("Nhap ten san pham:");
            _ten = Console.ReadLine();
            Console.Write("Nhap gia mua cua san pham:");
            _giamua = double.Parse(Console.ReadLine());
        }
    }
    class Socola : SanPham
    {
        private double _loinhuan;
        public Socola()
        {
        }
        public Socola(string ten, double giamua) : base(ten, giamua)
        {
        }
        public override double TinhGiaBan()
        {
            _loinhuan = Giamua * 0.2;
            return Giamua + _loinhuan;
        }
        public override void InChiTiet()
        {
            base.InChiTiet();
            Console.WriteLine($"Gia ban:{TinhGiaBan()}");
        }
        public override void Nhap()
        {
            base.Nhap();
        }
    }
    class NuocUong : SanPham
    {
        private double _loinhuan;
        private double _chiphigiulanh;

        public NuocUong()
        {
        }
        public NuocUong(string ten, double giamua) : base(ten, giamua)
        {
        }
        public override double TinhGiaBan()
        {
            _loinhuan = Giamua * 0.15;
            _chiphigiulanh = Giamua * 0.1;
            return Giamua + _loinhuan + _chiphigiulanh;
        }
        public override void InChiTiet()
        {
            base.InChiTiet();
            Console.WriteLine($"Gia ban:{TinhGiaBan()}");
        }
        public override void Nhap()
        {
            base.Nhap();
        }
    }
    class QuanLySanPham 
    {
        private string _ten = "Cua Hang Ban Le";
        private SanPham[] _danhSachSP;
        public void Nhap()
        {
            Console.Write("Nhap so luong san pham:");
            int soluong = int.Parse(Console.ReadLine());

            _danhSachSP = new SanPham[soluong];

            for (int i = 0; i < soluong; i++)
            {

                Console.WriteLine("------Quan Ly San Pham------");
                Console.WriteLine("1. Socola");
                Console.WriteLine("2. Nuoc uong");
                Console.Write("Chon loai san pham:");
                int chon = int.Parse(Console.ReadLine());

                if (chon == 1)
                    _danhSachSP[i] = new Socola();
                else if (chon == 2)
                    _danhSachSP[i] = new NuocUong();
                _danhSachSP[i].Nhap();
            }
        }
        public void InDSSanPham()
        {
            Console.WriteLine($"Danh sach san pham cua {_ten}");
            for (int i = 0; i < _danhSachSP.Length; i++)
            {
                _danhSachSP[i].InChiTiet();

            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                QuanLySanPham quanlySP = new QuanLySanPham();
                quanlySP.Nhap();
                quanlySP.InDSSanPham();

                Console.ReadLine();
            }
        }
    }
}
