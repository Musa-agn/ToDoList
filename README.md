# ToDoList

Bu proje ile; yapılacak işlemleri ekleyebilirsiniz, eklemiş olduğunuz itemları silebilirsiniz,
güncelleyebilirsiniz, id ye göre ilgili itemı getirebilirsiniz ve tüm yapılacak listesini çekebilirsiniz.


Solutionumun üzerindeki projeler: 
ToDoListUI/ToDoList.UI
Test/ToDoList.BusinessTest 
ToDoList.API 
ToDoList.BusinessLayer 
ToDoList.DataAccessLayer


1)ToDoListUI/ToDoList.UI
UI projem. Asp.Net MVC projesi. Yapılacak listesi için arayüz bulunmakta. Bu sayfada ekleme, silme, güncelleme, listeleme işlemlerini yapabilirsiniz.
Ayrıca yapılacak listem içerisinde, ilgili item geldiğinde popup gözükmesi sağlandı.
2)Test/ToDoList.BusinessTest  ToDoList.BusinessLayer  projesinin testi için oluşturuldu. Birim testlerim bulunmakta. 
3)ToDoList.API  Atılacak istekleri karşılayacak API projem. Buradaki controller methodları üzerinden ToDoList.BusinessLayer daki servisler çağırılır. 
4)ToDoList.BusinessLayer  Gerekli kontrollerin, işlerin yapıldığı katman. 
5)ToDoList.DataAccessLayer Veritabanı işlemlerinin yapıldığı katman