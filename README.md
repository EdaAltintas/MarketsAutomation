# MarketsAutomation
Admin girişi ve kasiyer girişi olmak üzere 2 girişin olduğu bir satış ve stok takip yapıldığı Windows Forms Uygulaması.
Admin girişinde admin ekranı(form2) kasiyer girişinde sadece müşteri seçip satış yapabileceği satış ekranı(CashierLoginForm) açılacak.
Admin ekranı;
Admin ürün,kategori,satıcı,müşteri ve kasiyer ekleme,düzenleme,arama,silme işlerinde yetkili kişi.
Ürün eklemesi esnasında aynı isimde ürünler eklenmesi ve kasiyer ekleme esnasında da aynı kullanıcı isimli kasiyer eklenmesi karışıklığa
yol açmaması açısından engellendi.
Admin stok işlemleri ekranı ile de ürünler arasında arama yapıp ürünlere stok eklemesi yapabiliyor.Satışlar(ReportForm) ekranı
ile gün bazında arama yaparak satış id'lerine göre tüm satışlara; satılan ürünler hakkındaki tüm bilgilere erişebilmekte.

Kasiyer satış ekranı;
Kasiyer, kategorilerin bulunduğu kısımdan kategori seçimine göre ekrana ürünler getirip arasında seçim yapıyor ve adet bilgisi giriyor. 
Daha sonra müşteri seçimi için açılan ekrandan(CustomerSearchForm) müşterilerin çeşitli bilgilerine göre arama yaparak müşteri seçiyor.
Sipariş tamamlanıyor ve fiş ekranı bastırılıyor. Fiş ekranında müşteri ad ve sayodı,ürünler bilgisi listesi ve toplam fiyat belirtiliyor.
Ayrıca hangi üründen kaç adet satıldıysa ürünler tablosundan o üründen adet sayısı kadar eksilme yapılıyor ve satış esnasında eğer stokdaki kalan üründen fazla ürün satılmaya çalışılırsa ekrana stok sayısı basılarak yetersiz stok olduğu bilgisi getiriliyor.

Veri tabanı klasöründe ki script dosyasından veritabanı alınıp,giriş için kasiyer ve admin girişi yapılabilir.
admin giriş; Kullanıcı ad:admin şifre:12345
kasiyer giriş; Kullanıcı ad:eda şifre:1

ADMİN EKRAN

![adminEkran](https://user-images.githubusercontent.com/32361405/72665899-fa898300-3a1d-11ea-9ca6-e0d03009a43c.PNG)

ÜRÜN EKRANI

![urun](https://user-images.githubusercontent.com/32361405/72665931-43d9d280-3a1e-11ea-992c-0e84a2634c50.PNG)

SATIŞLAR EKRANI

![satislar](https://user-images.githubusercontent.com/32361405/72665942-5eac4700-3a1e-11ea-90de-d7c57ba8ef51.PNG)

STOK EKRANI

![stok](https://user-images.githubusercontent.com/32361405/72665950-6c61cc80-3a1e-11ea-9bed-6eb7fc803aa9.PNG)

KASİYER SATIŞ EKRANI

![kasiyerEkran](https://user-images.githubusercontent.com/32361405/72665956-7be11580-3a1e-11ea-88b3-749c9f17789f.png)

FİŞ EKRANI

![fis](https://user-images.githubusercontent.com/32361405/72665969-95825d00-3a1e-11ea-9b7d-6a8f0cc87750.PNG)
