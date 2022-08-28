# assignment-2-serhatuluc
assignment-2-serhatuluc created by GitHub Classroom
<h3>Validation</h3>
<p>Merhabalar, Ödevde validasyonlar FluentValidation kütüphanesi kullanılarak sağlandı. Telefon numarası, email, isim ve soyisim formatı ise Fluentvalidation
kütüphanesinden "match" komutu içerisinde regex kullanılarak kontrolü sağlandı. </p>
<br />
<h3> FluentValidaiton'dan gelen "when" komutu </h3>
<p>Projenin içerisinde aynı zamanda iki extension bulunmaktadır. Bu
extensionlar FluentValidation kütüphanesinden gelen "when" komutu içerisinde kullanıldı. Bu komut boolean değer döndüren fonksiyonları içerisine kabul eder.
Eğer döndürülen değer true ise validasyon komutu çalışır. Bu özellik update requesti için kullanıldı. UpdateStaffCommandValidator içerisinde kullanılan bu komut
 sayesinde kullanıcı id girdikten sonra diğerlerine dokunmadan tek özelliği değiştirebilecektir.</p>

<br />
<h3> Model</h3>
<p>Bütün http requestlerde model kullanıldı. Get ve GetById için modelview kullanılarak dönüş yapıldı.</p>


![](screenshots/Get.PNG)
![](screenshots/GetById.PNG)
![](screenshots/Post.PNG)
![](screenshots/Put.PNG)
![](screenshots/Delete.PNG)



