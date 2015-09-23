namespace ZensibleMongo.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using NSubstitute;
    using Shouldly;
    using Xunit;

    public class MongoExtensionTest
    {
        private Expression<Func<DataExample, int>> SomeField => e => e.A;

        private Expression<Func<DataExample, bool>> SomeWhereTest => e => e.A == 0;
        



        [Fact]
        public async Task Create_Single_ReturnSingle()
        {
            var col = Substitute.For<IMongoCollection<DataExample>>();

            var data = new DataExample() { A = 0, B = 1 };

            var result = await col.Create(data).Push();

#pragma warning disable 4014
            col.Received().InsertOneAsync(data, default(CancellationToken));
#pragma warning restore 4014

            data.ShouldBe(result);

        }


        [Fact]
        public async Task Create_ManyItems_ReturnMany()
        {
            var col = Substitute.For<IMongoCollection<DataExample>>();

            var data = new DataExample() { A = 0, B = 1 };
            var manyData = new[] {data, data};

            var result = await col.Create(manyData)
                                  .Push();
            
#pragma warning disable 4014
            col.Received().InsertManyAsync(Arg.Any<IEnumerable<DataExample>>(), null, default(CancellationToken));
#pragma warning restore 4014

            result.ShouldBe(manyData);
        }


        [Fact]
        public async Task ForId_Set_UpdateAndReturn()
        {
            var col = Substitute.For<IMongoCollection<DataExample>>();
            var data = 0;
            var id = ValidObjectId();

            var result = await col.ForId(id)
                .Set(SomeField, data)
                .Push();

#pragma warning disable 4014
            col.Received().FindOneAndUpdateAsync(
                    Arg.Any<FilterDefinition<DataExample>>(),
                    Arg.Any<UpdateDefinition<DataExample>>());
#pragma warning restore 4014

            result.ShouldBeOfType<DataExample>();

        }

        [Fact]
        public async Task ForSingleWhere_Update_ReturnSingle()
        {
            var col = Substitute.For<IMongoCollection<DataExample>>();
            var data = 0;


            var result = await col.ForSingleWhere(SomeWhereTest)
                .Set(SomeField, data)
                .Push();

#pragma warning disable 4014
            col.Received().FindOneAndUpdateAsync(
                Arg.Any<FilterDefinition<DataExample>>(),
                Arg.Any<UpdateDefinition<DataExample>>());
#pragma warning restore 4014

            result.ShouldBeAssignableTo<DataExample>();

        }

        [Fact]
        public async Task ForAll_Set_ManyUpdates()
        {
            var col = Substitute.For<IMongoCollection<DataExample>>();
            var data = 0;

            await col.ForAll()
                     .Set(SomeField, data)
                     .Push();


#pragma warning disable 4014
            col.Received().UpdateManyAsync(
                    Arg.Any<FilterDefinition<DataExample>>(),
                    Arg.Any<UpdateDefinition<DataExample>>());
#pragma warning restore 4014

        }

        [Fact]
        public async Task ForAllWhere_Set_ManyUpdates()
        {
            var col = Substitute.For<IMongoCollection<DataExample>>();
            var data = 0;

            await col.ForAllWhere(SomeWhereTest)
                     .Set(SomeField, data)
                     .Push();

#pragma warning disable 4014
            col.Received().UpdateManyAsync(
                    Arg.Any<FilterDefinition<DataExample>>(),
                    Arg.Any<UpdateDefinition<DataExample>>());
#pragma warning restore 4014

        }

        [Fact]
        public async Task ForAllWhere_Delete_ManyDeletes()
        {
            var col = Substitute.For<IMongoCollection<DataExample>>();

            await col.ForAllWhere(SomeWhereTest)
                     .Delete()
                     .Push();

#pragma warning disable 4014
            col.Received().DeleteManyAsync(
                    Arg.Any<FilterDefinition<DataExample>>(),
                    Arg.Any<CancellationToken>());
#pragma warning restore 4014

        }

        [Fact]
        public async Task ForAll_Delete_ManyDeletes()
        {
            var col = Substitute.For<IMongoCollection<DataExample>>();

            var result = await col.ForAll()
                .Delete()
                .Push();

#pragma warning disable 4014
            col.Received().DeleteManyAsync(
                    Arg.Any<FilterDefinition<DataExample>>(),
                    Arg.Any<CancellationToken>()); ;
#pragma warning restore 4014

            result.ShouldBeAssignableTo<DeleteResult>();

        }

        [Fact]
        public async Task ForId_Delete_DeleteAndReturn()
        {
            var col = Substitute.For<IMongoCollection<DataExample>>();
            var id = ValidObjectId();

            var result = await col.ForId(id)
                .Delete()
                .Push();

#pragma warning disable 4014
            col.Received().FindOneAndDeleteAsync(
                Arg.Any<FilterDefinition<DataExample>>(),
                Arg.Any<FindOneAndDeleteOptions<DataExample>>(),
                Arg.Any<CancellationToken>());
#pragma warning restore 4014

            result.ShouldBeOfType<DataExample>();

        }

        [Fact]
        public async Task ForSingleWhere_Delete_ReturnSingle()
        {
            var col = Substitute.For<IMongoCollection<DataExample>>();

            var result = await col.ForSingleWhere(SomeWhereTest)
                .Delete()
                .Push();

#pragma warning disable 4014
            col.Received().FindOneAndDeleteAsync(
                Arg.Any<FilterDefinition<DataExample>>(),
                Arg.Any<FindOneAndDeleteOptions<DataExample>>(),
                Arg.Any<CancellationToken>());
#pragma warning restore 4014

            result.ShouldBeAssignableTo<DataExample>();

        }


        [Fact]
        public async Task ForId_Pull_ReturnSingle()
        {
            var col = Substitute.For<IMongoCollection<DataExample>>();
            var id = ValidObjectId();

            var result = await col.ForId(id).Pull();

#pragma warning disable 4014
            col.Received().FindAsync(
                Arg.Any<FilterDefinition<DataExample>>(),
                Arg.Any<FindOptions<DataExample, DataExample>>(),
                Arg.Any<CancellationToken>());
#pragma warning restore 4014

            result.ShouldBeAssignableTo<DataExample>();

        }


        [Fact]
        public async Task ForAllWhere_Pull_ReturnMany()
        {
            var col = Substitute.For<IMongoCollection<DataExample>>();

            var result = await col.ForAllWhere(SomeWhereTest)
                        .Pull().ToListAsync();

#pragma warning disable 4014
            col.Received().FindAsync(
               Arg.Any<FilterDefinition<DataExample>>(),
               Arg.Any<FindOptions<DataExample, DataExample>>(),
               Arg.Any<CancellationToken>());
#pragma warning restore 4014

            result.ShouldBeAssignableTo<List<DataExample>>();
        }

        [Fact]
        public async Task ForAll_Pull_ReturnMany()
        {
            var col = Substitute.For<IMongoCollection<DataExample>>();

            var result = await col.ForAll()
                .Pull().ToListAsync();

#pragma warning disable 4014
            col.Received().FindAsync(
              Arg.Any<FilterDefinition<DataExample>>(),
              Arg.Any<FindOptions<DataExample, DataExample>>(),
              Arg.Any<CancellationToken>());
#pragma warning restore 4014

            result.ShouldBeAssignableTo<List<DataExample>>();

        }

        [Fact]
        public async Task ForSingleWhere_Pull_ReturnSingle()
        {
            var col = Substitute.For<IMongoCollection<DataExample>>();

            var result = await col.ForSingleWhere(SomeWhereTest)
                .Pull();

#pragma warning disable 4014
            col.Received().FindAsync(
              Arg.Any<FilterDefinition<DataExample>>(),
              Arg.Any<FindOptions<DataExample, DataExample>>(),
              Arg.Any<CancellationToken>());
#pragma warning restore 4014

            result.ShouldBeAssignableTo<DataExample>();

        }

        public string ValidId()
        {
            return "507f191e810c19729de860ea";
        }

        public ObjectId ValidObjectId()
        {
            return ObjectId.Parse(ValidId());
        }


    }
}
