using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Hdq.Lib.Tests
{
    public class Error
    {
    }

    public class TypeA
    {
        public TypeA(string description)
        {
            Description = description;
        }
        public string Description { get; }
    }

    public class TypeB
    {
        public TypeB(string description)
        {
            Description = description;
        }
        public string Description { get; }
    }

    [TestFixture]
    public class EitherTests
    {
        [Test]
        public void EitherBindInvokesFunctionOnRight()
        {
            Either<Error, TypeB> Func(TypeA a) => new Either<Error, TypeB>(new TypeB(a.Description));

            Either<Error, TypeA> eitherA = new Either<Error, TypeA>(new TypeA("abc"));

            var result = eitherA.Bind((Func<TypeA, Either<Error, TypeB>>) Func);

            result.Do(e => { Assert.Fail("Should not be an error"); },
                b => b.Description.Should().Be("abc"));
        }
        
        [Test]
        public void EitherBindPassesOnErrorOnLeft()
        {
            Either<Error, TypeB> Func(TypeA a) => new Either<Error, TypeB>(new TypeB(a.Description));
            Either<Error, TypeA> eitherError = new Either<Error, TypeA>(new Error());
            var result = eitherError.Bind((Func<TypeA, Either<Error, TypeB>>) Func);
            result.Do(e => { Assert.Pass("Either.Bind passes through left (error) value"); },
                b => Assert.Fail("Value should be left (error) value, not right"));
        }
    }
}
