﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PersonStorage.Core.Application.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ValidationErrorResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ValidationErrorResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PersonStorage.Core.Application.Resources.ValidationErrorResource", typeof(ValidationErrorResource).Assembly);
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
        ///   Looks up a localized string similar to მოცემული CityId არ არსებობს.
        /// </summary>
        internal static string CityIdDoesNotExist {
            get {
                return ResourceManager.GetString("CityIdDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ფიზიკური პირის პირადი ნომერი არ არის უნიკალური.
        /// </summary>
        internal static string PersonalNumberIsnotValid {
            get {
                return ResourceManager.GetString("PersonalNumberIsnotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to მოცემული Person.Id არ არსებობს.
        /// </summary>
        internal static string PersonDoesNotExist {
            get {
                return ResourceManager.GetString("PersonDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to მოცემული RelatedPerson.CityId არ არსებობს.
        /// </summary>
        internal static string RelatedPersonCityIdDesNotExist {
            get {
                return ResourceManager.GetString("RelatedPersonCityIdDesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to მოცემული RelatedPersonId არ არსებობს..
        /// </summary>
        internal static string RelatedPersonDoesNotExist {
            get {
                return ResourceManager.GetString("RelatedPersonDoesNotExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to დაკავშირებული პირის პირადი ნომერი არ არის უნიკალური.
        /// </summary>
        internal static string RelatedPersonPnIsNotValid {
            get {
                return ResourceManager.GetString("RelatedPersonPnIsNotValid", resourceCulture);
            }
        }
    }
}
