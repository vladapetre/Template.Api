using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Primitives;

namespace Template.Domain.Models.Template;

public record TemplateDescription(string Name, string Version) : IValueObject { }
