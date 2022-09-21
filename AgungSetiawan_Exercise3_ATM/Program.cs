using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgungSetiawan_Exercise3_ATM
{
    class Program
    {

        public static Dictionary<string, string> KartuAndPin()
        {
            Dictionary<string, string> kartuAndPin = new Dictionary<string, string>();
            kartuAndPin.Add("111111111", "222222");
            kartuAndPin.Add("222222222", "333333");
            kartuAndPin.Add("333333333", "444444");
            kartuAndPin.Add("444444444", "555555");
            kartuAndPin.Add("555555555", "666666");

            return kartuAndPin;
        }

        public static Dictionary<string, int> KartuAndSaldo()
        {
            Dictionary<string, int> kartuAndSaldo = new Dictionary<string, int>();
            kartuAndSaldo.Add("111111111", 150000);
            kartuAndSaldo.Add("222222222", 50000);
            kartuAndSaldo.Add("333333333", 67000);
            kartuAndSaldo.Add("444444444", 250000);
            kartuAndSaldo.Add("555555555", 1800000);

            return kartuAndSaldo;
        }


        public static string ProsesInput()
        {
            try
            {
                Console.WriteLine("Masukkan nomor kartu : ");
                string noKartu = Console.ReadLine();
                string myKey = KartuAndPin().FirstOrDefault(x => x.Value == KartuAndPin()[noKartu]).Key;
                return myKey;
            }
            catch (Exception)
            {
                Console.WriteLine("No kartu tidak tersedia, silahkan masukan kembali");
                return ProsesInput();
            }
        }

        public static string ProsesInputPin()
        {
            try
            {
                Console.WriteLine("Masukkan Pin Anda \t: ");
                string nomorPin = Console.ReadLine().Trim();
                nomorPin = KartuAndPin()[ProsesInput()];
                return nomorPin;

            }
            catch (Exception)
            {
                Console.WriteLine("Pin yang anda masukan salah, silahkan masukan kembali\n");
                return ProsesInputPin();
            }
        }



        static void Main(string[] args)
        {
            List<string> historyTransaksi = new List<string>();

            Boolean looping = true;
            while (looping)
            {
                Console.WriteLine("========================================================================================");
                Console.WriteLine("\t\t\tSelamat datang di ATM Sederhana\t\t\t");
                Console.WriteLine("========================================================================================");
                ProsesInput();
                ProsesInputPin();
                while (looping)
                {
                    int tarikUangInt, setorUangInt, transferUangInt;

                    Console.WriteLine("========================================================================================");
                    Console.WriteLine("1. Informasi Saldo\n" +
                                        "2. Tarik Uang\n" +
                                        "3. Setor Uang\n" +
                                        "4. Transfer\n" +
                                        "5. Ganti Pin\n" +
                                        "6. History\n" +
                                        "7. Menu Utama\n" +
                                        "8. Exit\n" +
                                        "Pilih menu (1-8) : ");
                    Console.WriteLine("========================================================================================");
                    string menuUtama = Console.ReadLine().Trim();
                    int menuUtamaInt;
                    while (!int.TryParse(menuUtama, out menuUtamaInt) || (!(menuUtamaInt > 0 && menuUtamaInt <= 8)))
                    {
                        Console.WriteLine("Menu yang anda pilih tidak tersedia, silahkan masukan kembali\n");
                        menuUtama = Console.ReadLine();
                        continue;
                    }

                    if (menuUtama == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("Saldo Anda : {0}", KartuAndSaldo()[ProsesInput()].ToString("C"));
                    }
                    else if (menuUtama == "2")
                    {
                        Console.WriteLine("Masukan jumlah uang yang akan ditarik");
                        string tarikUang = Console.ReadLine().Trim();
                        while (!int.TryParse(tarikUang, out tarikUangInt) || tarikUangInt >= KartuAndSaldo()[ProsesInput()])
                        {
                            Console.Clear();
                            Console.WriteLine("Maaf Saldo anda tidak cukup");
                        }
                        Console.Clear();
                        Console.WriteLine("Tarik sukses");
                        KartuAndSaldo()[ProsesInput()] -= tarikUangInt;
                    }
                    else if (menuUtama == "3")
                    {
                        Console.WriteLine("Masukan jumlah uang yang akan disetor");
                        string setorUang = Console.ReadLine().Trim();
                        while (!int.TryParse(setorUang, out setorUangInt))
                        {
                            Console.Clear();
                            Console.WriteLine("Maaf jumlah uang yang anda setor tidak valid");
                        }
                        Console.Clear();
                        Console.WriteLine("Setor sukses");
                        KartuAndSaldo()[ProsesInput()] += setorUangInt;
                    }
                    else if (menuUtama == "4")
                    {
                        while (looping)
                        {
                            Console.WriteLine("Masukan nomor kartu penerima : ");
                            string nomorPenerima = Console.ReadLine().Trim();
                            if (!(nomorPenerima.Equals("111111111")) && !(nomorPenerima.Equals("222222222")) && !(nomorPenerima.Equals("333333333")) && !(nomorPenerima.Equals("444444444")) && !(nomorPenerima.Equals("555555555")))
                            {
                                Console.Clear();
                                Console.WriteLine("No kartu tidak tersedia, silahkan masukan kembali\n");
                            }
                            else
                            {
                                Console.WriteLine("Masukan jumlah uang yang akan di transfer");
                                string transferUang = Console.ReadLine().Trim();
                                while (!int.TryParse(transferUang, out transferUangInt) || transferUangInt > KartuAndSaldo()[ProsesInput()])
                                {
                                    Console.Clear();
                                    Console.WriteLine("Maaf Saldo anda tidak mencukupi, saldo anda : {0}", KartuAndSaldo()[ProsesInput()].ToString("C"));
                                }

                                Console.Clear();
                                Console.WriteLine($"Berhasil Transfer ke {nomorPenerima} sebesar {transferUang}");
                                KartuAndSaldo()[ProsesInput()] -= transferUangInt;
                                KartuAndSaldo()[nomorPenerima] += transferUangInt;
                                string list = $"Tanggal: {DateTime.Now}:: Debet: 0:: Kredit {transferUangInt.ToString("C")}:: Saldo {KartuAndSaldo()[ProsesInput()].ToString("C")}:: Status Sukses:: Keterangan Transfer";
                                historyTransaksi.Add(list);
                                break;
                            }
                        }
                    }
                    else if (menuUtama == "5")
                    {
                        Console.WriteLine("Masukkan pin baru : ");
                        string pinBaru = Console.ReadLine().Trim();
                        if (!(Convert.ToInt32(pinBaru.Length) == Convert.ToInt32(ProsesInputPin().Length)))
                        {
                            Console.Clear();
                            Console.WriteLine("Maaf pin yang anda masukan tidak sesuai (harus 6 nomor), masukan kembali : ");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Sukses Ubah Pin");
                            KartuAndPin()[ProsesInput()] = pinBaru;
                        }
                    }
                    else if (menuUtama == "6")
                    {
                        Console.Clear();
                        Console.WriteLine("History Transaksi");
                        foreach (string item in historyTransaksi)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    else if (menuUtama == "7")
                    {
                        Console.Clear();
                        historyTransaksi.Clear();
                        looping = true;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("========================================================================================");
                        Console.WriteLine("\t\t\tTerimakasih telah menggunakan ATM ini");
                        Console.WriteLine("========================================================================================");
                        return;
                    }

                }
            }
        }

    }
}
