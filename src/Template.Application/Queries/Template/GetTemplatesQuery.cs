using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Template.Application.Queries.Template;

public sealed class GetTemplatesQuery : IRequest<GetTemplatesQueryResponse>
{
}
