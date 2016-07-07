using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using LCore.Extensions;
using LCore.Interfaces;
using LCore.Tools;

namespace LCore.Extensions
    {
    /// <summary>
    /// Extensions to Type and MemberInfo classes to allow seamless 
    /// gathering of XML comments directly from source code.
    /// 
    /// For the project you're analyzing you MUST check the 
    /// XML documentation option in Project Properties -> Build Tab
    /// </summary>
    [ExtensionProvider]
    public static class CommentExt
        {
        // ReSharper disable LoopCanBeConvertedToQuery
        /// <summary>
        /// Returns an ICodeComment object representing the XML comments
        /// for a particular MemberInfo (Method, Property, or Field)
        /// if comments exist. Null otherwise.
        /// </summary>
        /// <param name="In">The MemberInfo to read comments</param>
        /// <returns>An ICodeComment object if comments exist. Null otherwise.</returns>
        public static ICodeComment GetComments(this MemberInfo In)
            {
            var a = Assembly.GetAssembly(In is Type ? (Type)In : In.DeclaringType);

            string ProjectFolder = AppContext.BaseDirectory;

#if DEBUG
            string DocFile = L.File.CombinePaths(ProjectFolder, $"bin\\{a.GetName().Name}.xml");
#else
            String DocFile = L.File.CombinePaths(ProjectFolder, $"bin\\{a.GetName().Name}.xml");
#endif

            if (File.Exists(DocFile))
                {
                var doc = new XmlDocument();
                doc.Load(DocFile);

                var MemberNodes = doc.SelectNodes("//member");

                string CommentName = GetCommentName(In);

                if (MemberNodes != null)
                    foreach (XmlNode MemberNode in MemberNodes)
                        {
                        if (!string.Equals(MemberNode.Attributes?["name"].Value, CommentName))
                            continue;

                        var SummaryNode = MemberNode.SelectSingleNode("summary");
                        var RemarksNode = MemberNode.SelectSingleNode("remarks");
                        var ValueNode = MemberNode.SelectSingleNode("value");
                        string Returns = MemberNode.SelectSingleNode("returns")?.InnerText;

                        var TypeParamNodes = MemberNode.SelectNodes("typeparam");
                        var ExamplesParamNodes = MemberNode.SelectNodes("examples");
                        var ParamNodes = MemberNode.SelectNodes("param");
                        var ExceptionNodes = MemberNode.SelectNodes("exception");
                        var PermissionNodes = MemberNode.SelectNodes("permission");
                        var IncludesNodes = MemberNode.SelectNodes("include");

                        string Summary = SummaryNode?.InnerText ?? "";
                        //string Returns = ReturnsNode?.InnerText ?? "";

                        var TypeParameters = new List<Set<string, string>>();
                        var Params = new List<Set<string, string>>();
                        var Exceptions = new List<Set<string, string>>();
                        var Permissions = new List<Set<string, string>>();
                        var Includes = new List<Set<string, string>>();

                        if (TypeParamNodes != null)
                            foreach (XmlNode Node in TypeParamNodes)
                                {
                                if (Node.Attributes?["name"] != null)
                                    {
                                    string TypeName = Node.Attributes?["name"].Value;
                                    string TypeComments = Node.InnerText;

                                    TypeParameters.Add(new Set<string, string>(TypeName, TypeComments));
                                    }
                                }

                        if (IncludesNodes != null)
                            foreach (XmlNode Node in IncludesNodes)
                                {
                                if (Node.Attributes?["file"] != null)
                                    {
                                    string TypeFile = Node.Attributes?["file"].Value;
                                    string TypePath = Node.Attributes?["path"].Value;

                                    Includes.Add(new Set<string, string>(TypeFile, TypePath));
                                    }
                                }

                        var Examples = new List<string>();

                        if (ExamplesParamNodes != null)
                            Examples.AddRange(from XmlNode Node in ExamplesParamNodes select Node.InnerText);

                        if (ExceptionNodes != null)
                            foreach (XmlNode Node in ExceptionNodes)
                                {
                                if (Node.Attributes?["cref"] != null)
                                    {
                                    string ParamCref = Node.Attributes?["cref"].Value;
                                    string ParamDescription = Node.InnerText;

                                    Exceptions.Add(new Set<string, string>(ParamCref, ParamDescription));
                                    }
                                }

                        if (ParamNodes != null)
                            foreach (XmlNode Node in ParamNodes)
                                {
                                if (Node.Attributes?["name"] != null)
                                    {
                                    string ParamName = Node.Attributes?["name"].Value;
                                    string ParamDescription = Node.InnerText;

                                    Params.Add(new Set<string, string>(ParamName, ParamDescription));
                                    }
                                }

                        if (PermissionNodes != null)
                            foreach (XmlNode Node in PermissionNodes)
                                {
                                if (Node.Attributes?["cref"] != null)
                                    {
                                    string PermissionCref = Node.Attributes?["cref"].Value;
                                    string PermissionDescription = Node.InnerText;

                                    Permissions.Add(new Set<string, string>(PermissionCref, PermissionDescription));
                                    }
                                }

                        var Out = new CodeComment
                            {
                            Summary = Summary,
                            Returns = Returns,
                            Examples = Examples.ToArray(),
                            Parameters = Params.ToArray(),
                            Exceptions = Exceptions.ToArray(),
                            Permissions = Permissions.ToArray(),
                            TypeParameters = TypeParameters.ToArray(),
                            Includes = Includes.ToArray(),
                            Remarks = RemarksNode?.InnerText,
                            Value = ValueNode?.InnerText
                            };

                        return Out;
                        }
                }

            return null;
            }
        // ReSharper restore LoopCanBeConvertedToQuery

        private static string GetCommentName(this Type In)
            {
            const string Code = "T";

            return GetCommentName(Code, In.Namespace, In.Name, null, In.GetGenericArguments().Length);
            }

        private static string GetCommentName(this MethodInfo In)
            {
            return GetCommentName("M", In.DeclaringType?.Namespace, In.DeclaringType?.Name, In.Name, 0);
            }
        private static string GetCommentName(this FieldInfo In)
            {
            return GetCommentName("F", In.DeclaringType?.Namespace, In.DeclaringType?.Name, In.Name, 0);
            }
        private static string GetCommentName(this PropertyInfo In)
            {
            return GetCommentName("P", In.DeclaringType?.Namespace, In.DeclaringType?.Name, In.Name, 0);
            }

        private static string GetCommentName(this MemberInfo In)
            {
            if (In is PropertyInfo)
                return ((PropertyInfo)In).GetCommentName();
            if (In is FieldInfo)
                return ((FieldInfo)In).GetCommentName();
            if (In is MethodInfo)
                return ((MethodInfo)In).GetCommentName();
            if (In is Type)
                return ((Type)In).GetCommentName();

            return "";
            }

        private static string GetCommentName(string Code, string Namespace, string TypeName, string MemberName, int types)
            {
            string Out = $"{Code}:{Namespace}.{TypeName}";

            if (!string.IsNullOrEmpty(MemberName))
                Out += $".{MemberName}";

            if (types > 0)
                Out += $"``{types}";

            return Out;
            }
        }
    }
