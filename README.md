# ToDoList

Bu proje ile; yapılacak işlemleri ekleyebilirsiniz, eklemiş olduğunuz itemları silebilirsiniz,
güncelleyebilirsiniz, id ye göre ilgili itemı getirebilirsiniz ve tüm yapılacak listesini çekebilirsiniz.

**Run Edilmesi Gereken Projeler:** <br>
ToDoList.API <br>
ToDoListUI/ToDoList.UI

**Solutionumun üzerindeki projeler:** <br>
ToDoListUI/ToDoList.UI  <br>
Test/ToDoList.BusinessTest  <br>
ToDoList.API <br>
ToDoList.BusinessLayer <br>
ToDoList.DataAccessLayer <br>


1) ToDoListUI/ToDoList.UI: <br>
UI projem. Asp.Net MVC projesi. Yapılacak listesi için arayüz bulunmakta. Bu sayfada ekleme, silme, güncelleme, listeleme işlemlerini yapabilirsiniz.
Ayrıca yapılacak listem içerisinde, ilgili item geldiğinde popup gözükmesi sağlandı.<br>
2) Test/ToDoList.BusinessTest: ToDoList.BusinessLayer  projesinin testi için oluşturuldu. Birim testlerim bulunmakta. <br>
3) ToDoList.API: Atılacak istekleri karşılayacak API projem. Buradaki controller methodları üzerinden ToDoList.BusinessLayer daki servisler çağırılır. <br>
4) ToDoList.BusinessLayer: Gerekli kontrollerin, işlerin yapıldığı katman. <br>
5) ToDoList.DataAccessLayer: Veritabanı işlemlerinin yapıldığı katman. <br>
