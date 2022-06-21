# NTier ECommerce Project

## Layers
* Core => Core layer. The foundation of the database. It can be used in a language other than C#. If it is desired to set up this database in a different language, it can be easily provided with this layer. Dependencies=> EntityFramework <hr/>
* Common => Auxiliary layer. MailSender, ImageUploader, RemoteIpAddress <hr/>
* DataAccess(DAL) => Data access layer. Entity, Map, Context. Dependencies=> EntityFramework <hr/>
* Business Logic Layer(BLL) => CRUD operations , Dependencies=> EntityFramework <hr/>
* Presentation (MVC_UI) => Presentation layer, Login operations, Register operations, Basket operations, Authorization operations
