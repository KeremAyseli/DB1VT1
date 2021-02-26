# **DB1VT1**

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
