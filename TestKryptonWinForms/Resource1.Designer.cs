﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestKryptonWinForms {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resource1 {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource1() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TestKryptonWinForms.Resource1", typeof(Resource1).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to -- поиск &quot;плохих&quot; объектов
        ///-- (на которые нельзя найти ссылки)
        ///
        ///set nocount on;
        ///
        ///if OBJECT_ID(&apos;tempdb..#weakObj&apos;) is not null
        ///  drop table #weakObj;
        ///create table #weakObj (objId int primary key, objName varchar(100) not null);
        ///
        ///declare @objId int, @objName sysname;
        ///declare @res table (r int not null);
        ///
        ///declare cr cursor local
        ///for
        ///  select o.object_id objId
        ///  , OBJECT_SCHEMA_NAME(o.object_id, DB_ID()) + &apos;.&apos; + o.name objName
        ///  from sys.all_objects o
        ///  where o.type in (&apos;u&apos;, &apos;f&apos;, &apos;fn&apos;, &apos;p&apos;);
        ///        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string sampleSqlText {
            get {
                return ResourceManager.GetString("sampleSqlText", resourceCulture);
            }
        }
    }
}
