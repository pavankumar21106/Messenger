# MongoDB

### MongoDB Atlas :

- The fully managed service for MongoDB deployments in the cloud

### MongoDB Enterprise :

- The subscription-based, self-managed version of MongoDB

### MongoDB Community :

- The source-available, free-to-use, and self-managed version of MongoDB

## Create database, table, index and user using c#

```C#
             var mongoClient = new MongoClient(mongoDBConfiguration.ConnectionString);
            var mongoDBDatabase = mongoClient.GetDatabase(mongoDBConfiguration.DataBaseName + "test");
            var collection = mongoDBDatabase.GetCollection<BsonDocument>("PatientHealthInfo");

            IndexKeysDefinition<BsonDocument> index_CallRegisterCode_PatientEMPI = "{\"CallRegisterCode\":1,\"PatientEMPI\":1}";
            var index_CallRegisterCode_PatientEMPI_Model = new CreateIndexModel<BsonDocument>(index_CallRegisterCode_PatientEMPI, new CreateIndexOptions
            {
                Unique = true
            });
            collection.Indexes.CreateOne(index_CallRegisterCode_PatientEMPI_Model);

            IndexKeysDefinition<BsonDocument> index_FirstName_LastName_DateOfBirth = "{\"Demographics.FirstName\":1,\"Demographics.LastName\":1,\"Demographics.DateOfBirth\":1}";
            var index_FirstName_LastName_DateOfBirth_Model = new CreateIndexModel<BsonDocument>(index_FirstName_LastName_DateOfBirth);
            collection.Indexes.CreateOne(index_FirstName_LastName_DateOfBirth_Model);


            var user = new BsonDocument
            { { "createUser", "imorph" }, { "pwd", "imorph786$" }, { "roles", new BsonArray { new BsonDocument { { "role", "readWrite" }, { "db", "Precedence-devtest" } } } }
            };
            var res = mongoDBDatabase.RunCommand<BsonDocument>(user);


```

## Create database, table, index and user using mongosh

``` shell

use ribbon-db-prod
db.createUser(
  {
    user: "imorph",
    pwd: "imorph786$",
    roles: [ { role: "readWrite", db: "ribbon-db-prod" } ]
  }
)
db.PatientHealthInfo.createIndex({"CallRegisterCode":1,"PatientEMPI":1},{unique:true});
db.PatientHealthInfo.createIndex({"Demographics.FirstName":1,"Demographics.LastName":1,"Demographics.DateOfBirth":1});

```


