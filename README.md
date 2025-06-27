# QR Web Api Task
Web api ozellikler:
* Algoritma ile Gs1 uyumlu 12 haneli random benzersiz numerik kod uretiyor ve kodu db ye kaydediyor.
* Kaydedilen tum gs1 kodlari getiriyor, id ile tek kod getiriyor.
* Girilen herhangi 12 haneli numerik kodu algoritma ile gs1 uyumlulugunu dogruluyor.
* Dummy api den id ile product verisi cekiyor, db ye kaydediyor ve cekilen veriyi gosteriyor. Id 1-150 arasi girilmesi gerekiyor. 

Teknolojiler ve tasarim:
Asp.net core api, mssql, ef core, algoritma, swagger, xunit, httpclient.
Clean architecture, mvc, swagger ui, async, di, solid.

Kullanim:
Mssql db icin ef core migrations yada ana klasor icindeki sql script kullanilabilir.
Tum api uclari swagger ui de mevcut, test edildi.



# EN
Web API Features:
* Generates a 12-digit random unique numeric code compatible with GS1 using an algorithm and saves it to the database.
* Retrieves all saved GS1 codes, and allows fetching a single code by its ID.
* Validates any given 12-digit numeric code for GS1 compliance using the algorithm.
* Fetches product data from a dummy API using an ID, saves it to the database, and displays the fetched data. The ID must be between 1 and 150.

Used technologies and design:
Asp.net core api, mssql, ef core, algoritma, swagger, xunit, httpclient.
Clean architecture, mvc, swagger ui, async, di, solid.

Usage:
For the MSSQL database, EF Core migrations or the SQL script in the main folder can be used.
All API endpoints are available in the Swagger UI and have been tested.

