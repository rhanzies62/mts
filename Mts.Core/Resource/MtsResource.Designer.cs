﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mts.Core.Resource {
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
    public class MtsResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MtsResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Mts.Core.Resource.MtsResource", typeof(MtsResource).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This account is locked due to multiple login error attempts.
        /// </summary>
        public static string AccountLocked {
            get {
                return ResourceManager.GetString("AccountLocked", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to BCT.
        /// </summary>
        public static string AdminCreateUpdateBy {
            get {
                return ResourceManager.GetString("AdminCreateUpdateBy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Admin.
        /// </summary>
        public static string AdminRole {
            get {
                return ResourceManager.GetString("AdminRole", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email address or password are not found.
        /// </summary>
        public static string EmailPasswordNotFound {
            get {
                return ResourceManager.GetString("EmailPasswordNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Business name already exist.
        /// </summary>
        public static string InvalidBusinessName {
            get {
                return ResourceManager.GetString("InvalidBusinessName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email address already registered.
        /// </summary>
        public static string InvalidEmail {
            get {
                return ResourceManager.GetString("InvalidEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid Role name and Business Name.
        /// </summary>
        public static string InvalidRoleBusiness {
            get {
                return ResourceManager.GetString("InvalidRoleBusiness", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid token.
        /// </summary>
        public static string InvalidToken {
            get {
                return ResourceManager.GetString("InvalidToken", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ##link##.
        /// </summary>
        public static string LinkTkn {
            get {
                return ResourceManager.GetString("LinkTkn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Refresh token not valid.
        /// </summary>
        public static string RefreshTokenNotValid {
            get {
                return ResourceManager.GetString("RefreshTokenNotValid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;!DOCTYPE html&gt;
        ///&lt;html&gt;
        ///&lt;head&gt;
        ///	&lt;title&gt;Registration Request&lt;/title&gt;
        ///&lt;/head&gt;
        ///&lt;body&gt;
        ///&lt;div&gt;
        ///&lt;h1&gt;Welcome&lt;/h1&gt;
        ///&lt;p&gt;We receive your request of registration. Please click the link below to continue your registration process.&lt;/p&gt;
        ///&lt;a href=&quot;##link##&quot;&gt;##link##&lt;/a&gt;
        ///&lt;/body&gt;
        ///&lt;/html&gt;.
        /// </summary>
        public static string RegistrationRequest {
            get {
                return ResourceManager.GetString("RegistrationRequest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Role already assigned to this feature.
        /// </summary>
        public static string RoleAlreadyAssignToFeature {
            get {
                return ResourceManager.GetString("RoleAlreadyAssignToFeature", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Role already assigned to this user.
        /// </summary>
        public static string RoleAlreadyAssignToUser {
            get {
                return ResourceManager.GetString("RoleAlreadyAssignToUser", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Role already exist.
        /// </summary>
        public static string RoleAlreadyExist {
            get {
                return ResourceManager.GetString("RoleAlreadyExist", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An internal server error was caught. .
        /// </summary>
        public static string ServiceInternalServerError {
            get {
                return ResourceManager.GetString("ServiceInternalServerError", resourceCulture);
            }
        }
    }
}
