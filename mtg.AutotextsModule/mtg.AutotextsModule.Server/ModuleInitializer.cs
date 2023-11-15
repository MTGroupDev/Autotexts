using System;
using System.Collections.Generic;
using System.Linq;
using Sungero.Core;
using Sungero.CoreEntities;
using Sungero.Domain.Initialization;

namespace mtg.AutotextsModule.Server
{
  public partial class ModuleInitializer
  {

    public override void Initializing(Sungero.Domain.ModuleInitializingEventArgs e)
    {
      // Создание ролей.
      InitializationLogger.Debug("Init: Create roles.");
      CreateRoles();
      
      // Создание областей использования.
      InitializationLogger.Debug("Init: Create usage areas.");
      CreateUsageAreas();
      
      //Выдача прав роли "Использование автотекстов".
      InitializationLogger.Debug("Init: Grant rights on usage of autotexts.");
      GrantRightsToAutotextsUseRole();
      
      //Выдача прав роли "Создание автотекстов".
      InitializationLogger.Debug("Init: Grant rights on creation of autotexts.");
      GrantRightsToAutotextsCreateRole();
    }
    
    /// <summary>
    /// Создать предопределенные роли.
    /// </summary>
    public static void CreateRoles()
    {
      InitializationLogger.Debug("Init: Create Default Roles");
      
      Sungero.Docflow.PublicInitializationFunctions.Module.CreateRole(Resources.RoleNameAutotextsUse, Resources.DescriptionAutotextsUseRole, Constants.Module.RoleGuid.AutotextsUseRole);
      Sungero.Docflow.PublicInitializationFunctions.Module.CreateRole(Resources.RoleNameAutotextsCreate, Resources.DescriptionAutotextsCreateRole, Constants.Module.RoleGuid.AutotextsCreateRole);
      
    }
    
    
    public static void CreateUsageAreas()
    {
      InitializationLogger.Debug("Init: Create usage areas.");
      CreateUsageArea(Resources.ApprovalTaskUsageAreaName, mtg.AutotextsModule.PublicConstants.Module.UsageAreaGuid.ApprovalTaskUsageArea);
    }
    
    public static void CreateUsageArea(string name, string guid)
    {
      InitializationLogger.DebugFormat("Init: Create AutotextUsageArea {0}", name);
      var usageArea = AutotextUsageAreas.GetAll(r => r.Guid == guid).FirstOrDefault();
      
      if (usageArea == null)
      {
        usageArea = AutotextUsageAreas.Create();
        usageArea.Name = name;
        usageArea.Guid = guid;
        usageArea.Save();
      }
      else
      {
        if (usageArea.Name != name)
        {
          InitializationLogger.DebugFormat("AutotextUsageArea '{0}'(Sid = {1}) renamed as '{2}'", usageArea.Name, usageArea.Guid, name);
          usageArea.Name = name;
          usageArea.Save();
        }
        
      }
    }
    
    /// <summary>
    /// Назначить права роли "Использование автотекстов".
    /// </summary>
    public static void GrantRightsToAutotextsUseRole()
    {
      InitializationLogger.Debug("Init: Grant rights on databooks to AutotextsUseRole");
      
      var role = Roles.GetAll().SingleOrDefault(n => n.Sid == Constants.Module.RoleGuid.AutotextsUseRole);
      if (role == null)
        return;
      
      // Модуль "Автотексты".
      AutotextsModule.Autotexts.AccessRights.Grant(role, DefaultAccessRightsTypes.Read);
      AutotextsModule.AutotextUsageAreas.AccessRights.Grant(role, DefaultAccessRightsTypes.Read);
    }
    
    /// <summary>
    /// Назначить права роли "Создание автотекстов".
    /// </summary>
    public static void GrantRightsToAutotextsCreateRole()
    {
      InitializationLogger.Debug("Init: Grant rights on databooks to AutotextsCreateRole");
      
      var role = Roles.GetAll().SingleOrDefault(n => n.Sid == Constants.Module.RoleGuid.AutotextsCreateRole);
      if (role == null)
        return;
      
      // Модуль "Автотексты".
      AutotextsModule.Autotexts.AccessRights.Grant(role, DefaultAccessRightsTypes.Create);
      AutotextsModule.AutotextUsageAreas.AccessRights.Grant(role, DefaultAccessRightsTypes.Read);
    }
  }
}
