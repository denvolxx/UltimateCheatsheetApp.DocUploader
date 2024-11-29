## DocUploader

Worker Microservice for [UltimateCheatsheetApp](https://github.com/denvolxx/UltimateCheatsheetApp)

# Requires:
* Kafka cluster
* Redis
* MongoDB

# Nugets:
- [Confluent.Kafka](https://www.nuget.org/packages/confluent.kafka/)
- [StackExchange.Redis](https://www.nuget.org/packages/stackexchange.redis)
- [EPPlus](https://github.com/EPPlusSoftware/EPPlus?form=MG0AV3)
- [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/microsoft.extensions.hosting)
- [MongoDB.Driver](https://www.nuget.org/packages/mongodb.driver)
- [MongoDB.Bson](https://www.nuget.org/packages/mongodb.bson)

# Project description
Worker project type, to add data from Excel file to the database. 
Consumes Kafka messages from [UltimateCheatsheetApp](https://github.com/denvolxx/UltimateCheatsheetApp) (Web API project). Excel document itself is uploaded into Redis before Kafka message is produced and accessed after application consumed message.  Message contains identifier for the Excel document in Redis. Data is processed, and populated to the MongoDB.

Basic formatting syntax for github readme here: https://docs.github.com/en/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax
