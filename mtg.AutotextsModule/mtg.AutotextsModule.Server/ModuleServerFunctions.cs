using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;

namespace mtg.AutotextsModule.Server
{
  public class ModuleFunctions
  {
    /// <summary>
    /// Получить список автотекстов с учетом области использования.
    /// </summary>
    /// <param name="usageAreaGuid">Guid области использования.</param>
    [Public, Remote]
    public static IQueryable<IAutotext> GetAutotexts(string usageAreaGuid)
    {
      //TODO В текущем варианте пользователю доступны все автотексты сооветствующей области. Для отбора используется панель фильтрации. 
      //Для адаптации под конкретные ограничения дорабатывать тут.
      var query = Autotexts.GetAll(x => x.Status == mtg.AutotextsModule.Autotext.Status.Active && Equals(x.UsageArea.Guid, usageAreaGuid));
      
      return query;
    }
  }
}