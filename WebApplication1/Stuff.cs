using System;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace WebApplication1
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }

    public class Query
    {
        public Book GetBook() =>
            new Book
            {
                Title = "C# in depth.",
            };
    }

    public class Mutation
    {
        public async Task<Book?> UpdateBook(Guid id)
        {
            await Task.CompletedTask;
            throw new ApplicationException("ohno");
            return new Book();
        }
    }

    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor
                .Field(f => f.UpdateBook(default))
                //.UseMutationConvention()  // this doesn't seem to make any difference
                //.Error<ApplicationException>() // this doesn't seem to make any difference either
                ;
        }
    }
}