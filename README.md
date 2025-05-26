Web api ozellikler ve kullanim:
* Algoritma ile Gs1 uyumlu 12 haneli random numerik kod uretiyor ve kodu db ye kaydediyor.
* Kaydedilen tum gs1 kodlari getiriyor yada id ile kodu getiriyor.
* Girilen herhangi 12 haneli numerik kodu algoritma ile gs1 uyumlulugunu dogruluyor.
* Dummy api den id ile product verisi cekiyor, db ye kaydediyor ve cekilen veriyi gosteriyor. Id 1-150 arasi girilmesi gerekiyor. 


Teknolojiler:
Asp.net core mvc api, mssql, ef core, algoritma, swagger, xunit, httpclient.

Tasarim ve methodlar:
Clean architecture, mvc, swagger ui, async, di, solid.

Notlar:
Mssql db icin ef core migrations yada ana klasor icindeki script kullanilabilir.
Tum api uclari swagger ui de mevcut, test edildi. Bonus gorev de yapildi.
