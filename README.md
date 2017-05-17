# Zensible Mongo

Extension library to simplify working with mongo, it uses a builder pattern approach to performing calls to the mongo db, this  allows for specific type of calls to be stored.

# Motivation
We all had to perform simple mongo actions but because of the mindboogling poor api of the offical mongo driver instead gone insane.

For instance lets say we want to find a single document by id
```
var filter = Builders<BsonDocument>.Filter.Eq("_id", id);
var result = collection.Find(filter);
var document = await result.SingleOrDefaultAsync()
```

Alternative with zensible mongo
```
 var document = await collection.ForId(id).PullAsync();
```

Or lets assume you want to insert a document into mongo and get the id that it got inserted with
```
await collection.InsertOneAsync(document) <--- returns void
```
Hmm thats weired there doesn't seem to be a way to get the id... ofc it changes the id directly on the document you are passing it. Nice unsafe shared memory you got there!

Alternative with zensible mongo
```
 var documentWithID = await collection.Create(document).PushAsync()
 documentWithID.ShouldNotBe(document) //pass
```
ahh nice a cloned safe version that is different


# How To


### Query
For a look up simply chose a selector such as ForId, ForSingleWhere etc.

To Fetch a single document based on a condition.
```
 var document = await collection.ForSingleWhere(d => d.IsDue).PullAsync();
```
ForSingleWhere should be be read: For a Single document Where (predicate) is true..

To fetch all documents based on a condition.
```
 var document = await collection.ForAllWhere(d => d.IsDue).PullAsync();
```
ForAllWhere should be be read: For All document Where (predicate) is true...

To fetch all documents
```
 var document = await collection.ForAllWhere(d => d.IsDue).PullAsync();
```
ForAllWhere should be be read: For All document Where (predicate) is true...


### Update
Like with the query we begin by ForId/ForSingleWhere/For..
```
 var document = await collection.ForId(id)
                                .Set(d => d.Field, value)
                                .PushAsync();
```
BONUS: if the selection only refers to one document that document will be returned.

To change multiple fields simply string them together
```
 var document = await collection.ForId(id)
                                .Set(d => d.Field1, value1)
                                .Set(d => d.Field2, value2)
                                .Set(d => d.Field3, value3)
                                ..
                                ..
                                .PushAsync();
```


### Delete
Like with query simply attach delete and the result will be a delete
```
 var document = await collection.ForId(id).Delete().PushAsync();
```
BONUS: if the selection only refers to one document that document will be returned.


### Create
To insert a document in the mongo collection simply use Create
```
 var newDocument = await collection.Create(document).PushAsync();  // newDocument != document
```

For multiple documents 
```
 var manyNewDocs = await collection.Create(doc1, doc2, ...).PushAsync();
```

## What is up with the Pull/Push?
One of the features of this extension library is that actions can be stored and then used.

for instance lets say I have a mail server and I want to define a query for all read mails.
```
var allReadMailsQuery = collection.ForAllWhere(m => m.IsRead)
```

Now when I need it I can either fetch it, delete it etc etc..
```
var allReadMails = await allReadMailsQuery.PullAsync(); 
await allReadMailsQuery.Delete().PushAsync();
...
...
```


