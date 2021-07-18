using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AngularETicaret.Core.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }// T tipi göndericem ve bana bool bi deger dönmesi gerek diyorum
        List<Expression<Func<T, object>>> Includes{ get;}//T tipi bi deger göndericem ve bana object bi deger dönmesi gerek diyorum
    }
}
