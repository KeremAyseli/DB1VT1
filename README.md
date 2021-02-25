# **DB1VT1**

DB1VT1 veritabanı yapısı şu anlık json dosyalar üzerinden çalışan bir arama yapısına sahip. Genel olarak arama algoritması şu şekilde çalışıyor; girilen anahtar kelime ilk önce harflerine bölünüyor ve her bir harfe konumuna göre puan veriliyor ve , verilen bu puanlar toplanınca anahtar kelimenin toplam puanı oluşuyor, oluşan bu puana göre bilgilerin kaydedileceği dosya aralığı belli oluyor. Bunu göreselleştirmek gerekirse:
### i=harfin olduğu konum
### x=harfin alfabede olduğu konum
### Formül= (i+x)*10 
|0 | 1| 2| 3| 4| 5| 6|  |
|--|--|--|--|--|--|--|--|
|m | e| r| h| a| b| a| =710(Merhaba kelimesinin değeri)|

Yukarıda bulunan değeri yine kendi belirlediğimiz aralıkta olan klasörlerin arasına yerleştiriyoruz,ben 100 puanlık klasör aralıkları belirlediğim için bu veri 700 ile 800 klasörüne kaydedilecek.

# **Kullanımı**
Öncellikle bir tablo yapısı oluşturuyoruz,oluşturduğumuz tablo yapısıyla bir Kayıt sınıfı tanımlıyoruz.

### **Kişiler sınıfı**
```
public int id { get;set; }
public string isim { get; set; }
public string soyisim { get; set; }
public int yas { get; set; }
```
### **Tablo ve veritabanı sınıfının oluşturulması**
```
Kişiler kişi = new Kişiler();
Kayıt<Kişiler> veriTabanıBaglnatı = new Kayıt<Kişiler>();
```
#### **Kişiler sınıfının doldurulması**
```
kişi.id = 1;
kişi.isim = "isim";
kişi.soyisim = "soyisim";
kişi.yas = 10;
``` 
## **Veri Kayıt etmek**
Burada ilk parametre aslında şu anlık işlevsiz durumda,çünkü orada tablo ismi isteniyor. Şu anlık program tablo ismine göre arama yapmıyor fakat ilerleyen zamanlarda yapmasını planladığım için parametre olarak tutuyorum, ikinci parametre ise tanımladğımız tablomuz, üçüncü olarak ise anahtar kelimemiz.
### **Parametreler**
**(String Tablo ismi,T Tablo,String AnahtarKelime)**
```
veriTabanıBaglnatı.KayıtGir("Kişiler", kişi, kişi.isim);
```
## **Veri Okumak**
Veri okuma işlemine parametre olarak sadece anahtar kelimeyi vermek yeterli oluyor daha sonra bulunan verileri tablo sınıfız halinde geri döndürüyor.
### **Parametreler**
**(String AnahtarKelime)**
```
veriTabanıBaglnatı.KayıtOku("isim");
```
## **Veri Bulmak**
Veri bulmak için parametre olarak basit bir linq sorgusu yazmak yeterli, geri tablo sınıfı tipli bir değer dönücektir.
### **Parametreler**
**(LINQ Sorgu)**
```
veriTabanıBaglnatı.VeriBul(Id => Id.id == 1,aramaİsim).id.ToString()
```
# **Hedefler**
Şu anlık veri seçme işlemini LINQ kullanarak sağlyorum ki gelecekte de böyle olmasını umuyorum çünkü hedefim NoSql bir veri tabanı yapmak.Şu anlık seçme işlemini IQueryable arayüzünü kullanarak yapmaktayım gelecekte bu yapılardan ziyade kendi arama yapılarımı oluşturmak istiyorum.
