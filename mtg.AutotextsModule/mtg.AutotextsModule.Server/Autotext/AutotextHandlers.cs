using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using mtg.AutotextsModule.Autotext;

namespace mtg.AutotextsModule
{
  partial class AutotextFilteringServerHandler<T>
  {

    public override IQueryable<T> Filtering(IQueryable<T> query, Sungero.Domain.FilteringEventArgs e)
    {
      if (_filter == null)
        return query;
      
      if (_filter.Active || _filter.Closed)
        query = query.Where(a => _filter.Active && a.Status == Status.Active ||
                            _filter.Closed && a.Status == Status.Closed);
      
      if (_filter.Author != null)
        query = query.Where(a => a.Author == _filter.Author);
      
      if (_filter.UsageArea != null)
        query = query.Where(a => a.UsageArea == _filter.UsageArea);
      
      return query;
    }
  }

  partial class AutotextServerHandlers
  {

    public override void Created(Sungero.Domain.CreatedEventArgs e)
    {
      _obj.Author = Users.Current;
    }
  }

}