using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Models.Example;
using Template.Persistence.Specifications;

namespace Template.Persistence.Example.Specifications;
internal sealed class GetExamplesSpecification : Specification<ExampleAggregateRoot>
{
    public GetExamplesSpecification() : base()
    {
        AddOrderBy(example => example.Id);
    }
}
