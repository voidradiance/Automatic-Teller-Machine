# C-Sharp-Project-ATM
Create a console application using C# with the requirement to create an Automatic Teller Machine (ATM) console interface.


ATM
Siapkan data 5 dummy untuk menyimpan informasi noKartu (int, 9 digit), pin (int, 6 digit) dan saldo.
Misal :
No Kartu	Pin	    Saldo
123459876	123134	15000
987654321	432425	5000

Tampilan Menu Utama :
 
(Buat validasi no kartu jika tidak tersedia di data dummy)
 
(Buat validasi jika password salah)
 
(Validasikan agar input hanya di antara 1 - 6)


Jika User memilih menu informasi saldo (1) :
“Saldo Anda : Rp.15.000,00” (User akan di bawa kembali ke Menu)

Jika User memilih menu Tarik Uang (2) maka :
“Masukkan jumlah uang yang akan ditarik“ (Validasikan)
(Jika Saldo tak mencukupi)
“Maaf Saldo anda tidak cukup”
(Jika berhasil)
“Sukses Tarik”  (User akan di bawa kembali ke Menu)

Jika User memilih menu Setor Uang (3) maka :
“Masukkan jumlah uang yang akan disetor“ (Validasikan)

(Jika User setor : 30000)
(Jika berhasil)
“Sukses Setor” 
“Saldo Anda : Rp.50000,00” (User akan di bawa kembali ke Menu)

Jika User memilih menu Transfer Uang (4) maka :
“Masukkan No Kartu Penerima :” (Validasikan)
"Masukkan jumlah uang yang akan ditransfer : " (Validasikan)
(Jika saldo tak cukup)
“Maaf Saldo Anda Tak Mencukupi. Saldo Anda : Rp.20000,00”
(Jika Berhasil)
“Berhasil Tranfer ke (NoKartu) sebesar Rp.50000” (User akan di bawa kembali ke Menu)

Jika User memilih menu Ganti pin  (5) maka :
 “Masukkan pin baru :” (Validasikan)
(Jika berhasil)
"Sukses Ubah Pin"
