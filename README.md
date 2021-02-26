# **DB1VT1 TR**


# **[DB1VT1 ENG](#https://github.com/KeremAyseli/Veri_tabani/blob/master/README.md#db1vt1-eng-1****)**

# **DB1VT1 TR**
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
Burada ilk parametre aslında şu anlık işlevsiz durumda,çünkü orada tablo ismi isteniyor. Şu anlık program tablo ismine göre arama yapmıyor fakat ilerleyen zamanlarda yapmasını planladığım için parametre olarak tutuyorum. ikinci parametre ise tanımladğımız tablomuz. üçüncü olarak ise anahtar kelimemiz.
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
Veri bulmak için parametre olarak basit bir linq sorgusu ve bir anahatar kelime yazmak yeterli, geri tablo sınıfı tipli bir değer dönücektir.
### **Parametreler**
**(LINQ Sorgu,string AnahtarKelime)**
```
veriTabanıBaglnatı.VeriBul(Id => Id.id == 1,aramaİsim).id.ToString()
```
# **Hedefler**
Şu anlık veri seçme işlemini LINQ kullanarak sağlyorum ki gelecekte de böyle olmasını umuyorum çünkü hedefim NoSql bir veri tabanı yapmak.Şu anlık seçme işlemini IQueryable arayüzünü kullanarak yapmaktayım gelecekte bu yapılardan ziyade kendi arama yapılarımı oluşturmak istiyorum.


# **DB1VT1 ENG**

The DB1VT1 data connection currently has a search structure running over json files. Generally, its algorithm is as follows; The entered keyword is first divided by a letter and its score is given according to a letter, and when these points are added, the key total score is formed, according to this score, the file range to be saved is determined. To illustrate this:
### i = position of the letter
### x = position where the letter is in the alphabet
### Formula = (i + x) * 10
|0 | 1| 2| 3| 4||
|--|--|--|--|--|--|
|h | e| l| l| o|  =690(It's value of hello)|

We place the above value between the folders that are in the range we have determined, since I have specified the 100-point folder ranges, this data will be saved in the 600 and 700 folders.

# **How To Use**
First we need a table class like person etc.

### **Person class**
```
public int id { get;set; }
public string name { get; set; }
public string surname { get; set; }
public int age { get; set; }
```
### **Table and Database class definition**
```
Person per = new Person();
Kayıt<Person> veriTabanıBaglnatı = new Kayıt<Person>();
```
#### **Fill the person class**
```
per.id = 1;
per.name = "name";
per.surname = "surname";
per.age = 10;
``` 
## **İnsert Data**
Thats here method first parameter is usless for now,because it's want table name.For now it's don't searched with table name,but this for future plan.Second parameter is for table class.Third is for keyword.
### **Parameters**
**(String TableName,T Table,String Keyword)**
```
veriTabanıBaglnatı.KayıtGir("Person", per, per.name);
```
## **Read Data**
Read data process,you need just one keyword,its return the data in your table class type.
### **Parameters**
**(String Keyword)**
```
veriTabanıBaglnatı.KayıtOku("name");
```
## **Find Data**
To find data, a simple linq query and a keyword as a parameter are sufficient to find data, and return data in your table class type.
### **Parametre**
**(LINQ Query,string keyword)**
```
veriTabanıBaglnatı.VeriBul(Id => Id.id == 1,keyword).id.ToString()
```
# **Goals**
I do the instant data selection process using LINQ, and I hope it will be like this in the future because my goal is to make a NoSql database. I do the instant selection process using the IQueryable interface.
