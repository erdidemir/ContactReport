# ContactReport

* NET Core
* Git
* Postgres
* CQRS
* Mediatr
* FluentValidation
* AutoMapper
* EntityFramework
* Clean Code
* Domain Driven Design
* Clean Architecture

Docker üzerinden portainer kurulumun yapılıyor.Portainer üzeridnen postgresql username/password şeklinde ayaralama yapılıyor.
Yine portainer üzerinden rabbitmq kuruluyor 1453 portunda hizmet veriyor.Oluşturulan raporlar rabbitmq aracılığı ile rapor servise gidiyor.
Buradan excel oluşturuluyor.Yine oluşturulan excel rabbit mq den gönderilerek tamamlanmış oluyor.
