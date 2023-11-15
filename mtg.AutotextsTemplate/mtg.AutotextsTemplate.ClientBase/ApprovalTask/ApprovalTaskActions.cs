using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using mtg.AutotextsTemplate.ApprovalTask;

namespace mtg.AutotextsTemplate.Client
{
  partial class ApprovalTaskActions
  {
    public virtual void UseAutotext(Sungero.Domain.Client.ExecuteActionArgs e)
    {
      // Пример использования автотекста в задаче на согласование.
      var text = mtg.AutotextsModule.PublicFunctions.Module.Remote.GetAutotexts(mtg.AutotextsModule.PublicConstants.Module.UsageAreaGuid.ApprovalTaskUsageArea).ShowSelect();
      if (text != null) 
        _obj.ActiveText = text.Text;
      return;
    }

    public virtual bool CanUseAutotext(Sungero.Domain.Client.CanExecuteActionArgs e)
    {
      return _obj.Status == Sungero.Docflow.ApprovalTask.Status.Draft;
    }

  }

}